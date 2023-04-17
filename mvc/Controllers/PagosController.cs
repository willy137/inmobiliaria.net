using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using mvc.Models;

namespace mvc.Controllers
{
    public class PagosController : Controller
    {
        // GET: Pagos
        
        private readonly IRepositorioPago repoP;
        private readonly IRepositorioContrato repoC;

        private readonly IRepositorioInquilino repoInq;

        private readonly IRepositorioPropietario repoProp;

        public PagosController(IRepositorioInquilino repoIn, IRepositorioContrato repoC, IRepositorioPago repoP, IRepositorioPropietario repoPr){
            this.repoP=repoP;
            this.repoC=repoC;
            this.repoInq=repoIn;
            this.repoProp=repoPr;
        }
        [Authorize]
        public ActionResult Index()
        {
            try{
                var claims =User.Claims;
                string Rol = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                ViewBag.Rol=Rol;
                IList<Pago> pagos=repoP.GetObtenerTodos();
                return View(pagos);
            }catch(Exception ex){
                throw;
            }
        }
        [Authorize]
        // GET: Pagos/Details/5
        public ActionResult Details(int PagoId)
        {
            try{
                var claims =User.Claims;
                string Rol = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                ViewBag.Rol=Rol;
                Pago pago=repoP.Obtener(PagoId);
                return View(pago);
            }catch(Exception ex){
                throw;
            }
        }
        [Authorize]
        // GET: Pagos/Create
        public ActionResult Create()
        {
            try{
                var claims =User.Claims;
                string Rol = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                ViewBag.Rol=Rol;
                ViewBag.contrato=repoC.GetObtenerTodos();
                ViewBag.inqui=repoInq.GetObtenerTodos();
                return View();
            }catch(Exception ex){
                throw;
            }
        }

        // POST: Pagos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pago pago)
        {
            try
            {
                int res=repoP.Create(pago);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [Authorize]
        public ActionResult CreatePedir(int ContratoId)
        {
            try{
                var claims =User.Claims;
                string Rol = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                ViewBag.Rol=Rol;
                ViewBag.contrato=repoC.Obtener(ContratoId);
                ViewBag.inqui=repoInq.GetObtenerTodos();
                return View();
            }catch(Exception ex){
                throw;
            }
        }


        // GET: Pagos/Edit/5
        public ActionResult Edit(int PagoId)
        {
            try{
                var claims =User.Claims;
                string Rol = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                ViewBag.Rol=Rol;
                Pago pago=repoP.Obtener(PagoId);
                ViewBag.contra=repoC.Obtener(Convert.ToInt32(pago.ContratoId));
                return View(pago);
            }catch(Exception ex){
                throw;
            }
        }

        // POST: Pagos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int PagoId, Pago pago)
        {
            try
            {
                // TODO: Add update logic here
                repoP.Edit(pago);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Policy = "Administrador")]
        // GET: Pagos/Delete/5
        public ActionResult Delete(int PagoId)
        {
            try{
                var claims =User.Claims;
                string Rol = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                ViewBag.Rol=Rol;
                Pago pago=repoP.Obtener(PagoId);
                return View(pago);
            }catch(Exception ex){
                throw;
            }
        }

        // POST: Pagos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int PagoId, Pago pago)
        {
            try
            {
                // TODO: Add delete logic here
                repoP.Delete(PagoId);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex){
                throw;
            }
        }
        [Authorize]
        //Get
        public ActionResult PedirPagos(int ContratoId)
        {
            try{
                var claims =User.Claims;
                string Rol = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                ViewBag.Rol=Rol;
                int i=ContratoId;
                IList<Pago> pagos=repoP.ObtenerPagos(ContratoId);
                foreach(var item in pagos){
                    item.inmueble.Duenio=repoProp.Obtener(Convert.ToInt32(item.inmueble.PropId));
                }
                ViewBag.contra=repoC.Obtener(ContratoId);
                return View(pagos);
            }catch(Exception ex){
                throw;
            }
        }
    }
}