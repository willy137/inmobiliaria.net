using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace Inmobiliaria.Controllers
{
    public class ContratosController : Controller
    {


        private readonly IRepositorioContrato repoC;
        private readonly IRepositorioInmueble repoInmu;

        private readonly IRepositorioInquilino repoInqui;

         public ContratosController (IRepositorioContrato repoC,IRepositorioInmueble repoI, IRepositorioInquilino repoInq){
            this.repoC=repoC;
            this.repoInmu=repoI;
            this.repoInqui=repoInq;
        }


        [Authorize]
        // GET: Contratos
        public ActionResult Index()
        {
            try{
                IList<Contrato> contratos= repoC.GetObtenerTodos();
                return View(contratos);
            }catch(Exception ex){
                throw;
            }
        }
        [Authorize]
        // GET: Contratos/Details/5
        public ActionResult Details(int ContratoId)
        {
            try{
                Contrato contrato= repoC.Obtener(ContratoId);
                return View(contrato);
            }catch(Exception ex){
                throw;
            }
        }
        [Authorize]
        // GET: Contratos/Create
        public ActionResult Create()
        {  
            try{
                ViewBag.inquis=repoInqui.GetObtenerTodos();
                ViewBag.Inmuebles=repoInmu.GetObtenerTodos();
                return View();
            }catch(Exception ex){
                throw;
            }
        }

        // POST: Contratos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contrato con)
        {
            try
            {
                // TODO: Add insert logic here
                repoC.Create(con);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [Authorize]
        // GET: Contratos/Edit/5
        public ActionResult Edit(int ContratoId)
        {   
            try
            {
                ViewBag.inmu=repoInmu.GetObtenerTodos();
                ViewBag.inqui=repoInqui.GetObtenerTodos();
                Contrato con=repoC.Obtener(ContratoId);
                return View(con);
            }
            catch(Exception ex)
            {
              throw;
            }
        }

        // POST: Contratos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Contrato contra)
        {
            try
            {
                // TODO: Add update logic here
                int res=repoC.Edit(contra);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [Authorize(Policy = "Administrador")]
        // GET: Contratos/Delete/5
        public ActionResult Delete(int ContratoId)
        {
            try
            {
                Contrato con=repoC.Obtener(ContratoId);
                return View(con);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        // POST: Contratos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int ContratoId, Contrato contrato)
        {
            try
            {
                // TODO: Add delete logic here
                repoC.Delete(ContratoId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}