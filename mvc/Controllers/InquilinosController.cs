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
    public class InquilinosController : Controller
    {
        private readonly IRepositorioInquilino repo;


        public InquilinosController (IRepositorioInquilino repoInq){
            this.repo=repoInq;
        }
        [Authorize]
        // GET: Inquilinos
        public ActionResult Index()
        {
            try{
                var claims =User.Claims;
                string Rol = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                ViewBag.Rol=Rol;
                IList<Inquilino> inqui=repo.GetObtenerTodos();
                return View(inqui);
            }catch(Exception ex){
                throw;
            }
        }
        [Authorize]
        // GET: Inquilinos/Details/5
        public ActionResult Details(int InquiId)
        {
            try{
                var claims =User.Claims;
                string Rol = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                ViewBag.Rol=Rol;
                Inquilino inqui=repo.Obtener(InquiId);
                return View(inqui);
            }catch(Exception ex){
                throw;
            }
        }
        [Authorize]
        // GET: Inquilinos/Create
        public ActionResult Create()
        {
            try{
                var claims =User.Claims;
                string Rol = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                ViewBag.Rol=Rol;
                return View();
            }catch(Exception ex){
                throw;
            }
        }

        // POST: Inquilinos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inquilino inqui)
        {
            try
            {
                // TODO: Add insert logic here
                int res=repo.Create(inqui);
                if(res>0){
                    return RedirectToAction(nameof(Index));
                }else{
                    return View();
                }

            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [Authorize]
        // GET: Inquilinos/Edit/5
        public ActionResult Edit(int InquiId)
        {
            try{
                Inquilino inq=repo.Obtener(InquiId);
                return View(inq);
            }catch(Exception ex){
                throw;
            }
        }

        // POST: Inquilinos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int InquiId, Inquilino inqui)
        {
            try
            {
                // TODO: Add update logic here
                repo.Edit(inqui);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [Authorize(Policy = "Administrador")]
        // GET: Inquilinos/Delete/5
        public ActionResult Delete(int InquiId)
        {
            try{
                var claims =User.Claims;
                string Rol = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                ViewBag.Rol=Rol;
                Inquilino inq=repo.Obtener(InquiId);
                return View(inq);
            }catch(Exception ex){
                throw;
            }


        }

        // POST: Inquilinos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int InquiId, Inquilino inqui)
        {
            try
            {

                // TODO: Add delete logic here
                int res=repo.Delete(InquiId);
                if(res>0){
                    return Redirect("/inquilinos");
                }else{
                    return View();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}