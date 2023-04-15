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
    public class InmueblesController : Controller
    {

        private readonly IRepositorioInmueble repoI;
        private readonly IRepositorioPropietario repoP;

        public InmueblesController (IRepositorioPropietario repo,IRepositorioInmueble repoI){
            this.repoI=repoI;
            this.repoP=repo;
        }
        

        [Authorize]
        // GET: Inmuebles
        public ActionResult Index()
        {
            try{
                IList<Inmueble> inmus=repoI.GetObtenerTodos(); 
                return View(inmus);
            }catch(Exception ex){
                throw;
            }
        
        }
        [Authorize]
        // GET: Inmuebles/Details/5
        public ActionResult Details(int InmuId)
        {
            try{
                Inmueble inmu=repoI.Obtener(InmuId); 
                return View(inmu);
            }catch(Exception ex){
                throw;
            }
        }
        [Authorize]
        // GET: Inmuebles/Create
        public ActionResult Create()
        {   
            try{
                ViewBag.Prop=repoP.GetObtenerTodos();
                return View();
            }catch(Exception ex){
                throw;
            }
        }

        // POST: Inmuebles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inmueble inmueble)
        {
            try
            {
                // TODO: Add insert logic here
                Propietario prop=repoP.Obtener(Convert.ToInt32(inmueble.PropId));
                if(prop!=null){
                    int res=repoI.Create(inmueble);
                    if(res>0){
                        return RedirectToAction(nameof(Index));
                    }
                }
                var num=1;
                return View(num);

            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [Authorize]
        // GET: Inmuebles/Edit/5
        public ActionResult Edit(int InmuId)
        {
            try{
                ViewBag.prop=repoP.GetObtenerTodos();
                Inmueble inmu=repoI.Obtener(InmuId);
                return View(inmu);
            }catch(Exception ex){
                throw;
            }

        }

        // POST: Inmuebles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inmueble inmu)
        {
            try
            {
                // TODO: Add update logic here
                repoI.Edit(inmu);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [Authorize(Policy = "Administrador")]
        // GET: Inmuebles/Delete/5
        public ActionResult Delete(int InmuId)
        {
            try{
                Inmueble inmu=repoI.Obtener(InmuId);
                return View(inmu);
            }catch(Exception ex){
                throw;
            }

        }

        // POST: Inmuebles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int InmuId, Inmueble inmu)
        {
            try
            {
                // TODO: Add delete logic here
                int res=repoI.Delete(InmuId);
                if(res>0){
                    return RedirectToAction(nameof(Index));
                }else{
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }
    }
}