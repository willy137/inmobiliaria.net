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
    public class PropietariosController : Controller
    {
        // GET: Propietario
        private readonly IRepositorioPropietario repoP;

        public PropietariosController(IRepositorioPropietario repo){
            this.repoP=repo;
        }

        [Authorize]
        public ActionResult Index()
        {
            try{
                IList<Propietario> p=repoP.GetObtenerTodos();
                return View(p);
            }catch(Exception ex){
                throw;
            }
        }
        [Authorize]
        // GET: Propietario/Details/5
        public ActionResult Details(int PropId)
        {
            Propietario p=repoP.Obtener(PropId);
            return View(p);
        }

        [Authorize]
        // GET: Propietario/Details/5
        public ActionResult Pedir(Propietario prop)
        {
            IList<Propietario> p=repoP.BuscarNom(prop.Nombre);
            
            return View(p);
        }
        [Authorize]
        // GET: Propietario/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        // POST: Propietario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Propietario prop)
        {
            try{
                // TODO: Add insert logic here
                int resul=repoP.Create(prop);
                if(resul>0){
                    return RedirectToAction(nameof(Index));
                }else{
                    return View();
                }
            }catch(Exception ex)
            {
                throw;
            }

        }
        [Authorize]
        // GET: Propietario/Edit/5
        public ActionResult Edit(int PropId)
        {
            Propietario p=repoP.Obtener(PropId);
            return View(p);
        }

        // POST: Propietario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int PropId, Propietario prop)
        {
            try
            {
                repoP.Edit(prop);
                // TODO: Add update logic here
                return RedirectToAction(nameof(Index));
            }
           catch(Exception ex)
            {
                throw;
            }
        }
        
        [Authorize(Policy="Administrador")]
        // GET: Propietario/Delete/5
        public ActionResult Delete(int PropId)
        {
            Propietario p=repoP.Obtener(PropId);
            return View(p);
        }

        // POST: Propietario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int PropId, Propietario prop)
        {
            try
            {
                // TODO: Add delete logic here
                int resul=repoP.Delete(PropId);

                if(resul>0){
                    return Redirect("/propietarios");
                }else{

                    return View();
                }
            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}