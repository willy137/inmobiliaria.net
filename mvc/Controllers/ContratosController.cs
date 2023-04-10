using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace Inmobiliaria.Controllers
{
    public class ContratosController : Controller
    {


        private readonly RepositorioContrato repoC= new RepositorioContrato();

        private readonly RepositorioInmueble repoInmu= new RepositorioInmueble();

        private readonly RepositorioInquilino repoInqui=new RepositorioInquilino();

        // GET: Contratos
        public ActionResult Index()
        {
            try{
                List<Contrato> contratos= repoC.GetContratos();
                return View(contratos);
            }catch(Exception ex){
                throw;
            }
        }

        // GET: Contratos/Details/5
        public ActionResult Details(int ContratoId)
        {
            try{
                Contrato contrato= repoC.ObtenerContrato(ContratoId);
                return View(contrato);
            }catch(Exception ex){
                throw;
            }
        }

        // GET: Contratos/Create
        public ActionResult Create()
        {  
            try{
                ViewBag.inquis=repoInqui.GetInquilino();
                ViewBag.Inmuebles=repoInmu.GetInmuebles();
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

        // GET: Contratos/Edit/5
        public ActionResult Edit(int ContratoId)
        {   
            try
            {
                Contrato con=repoC.ObtenerContrato(ContratoId);
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

        // GET: Contratos/Delete/5
        public ActionResult Delete(int ContratoId)
        {
            try
            {
                Contrato con=repoC.ObtenerContrato(ContratoId);
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