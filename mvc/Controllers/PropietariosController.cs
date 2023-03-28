using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace Inmobiliaria.Controllers
{
    public class PropietariosController : Controller
    {
        // GET: Propietario
        private readonly RepositorioPropietario repo= new RepositorioPropietario();
        public ActionResult Index()
        {
            List<Propietario> p=repo.GetPropietario();
            return View(p);
        }

        // GET: Propietario/Details/5
        public ActionResult Details(int id_prop)
        {
            Propietario p=repo.Obtener(id_prop);
            return View(p);
        }

        // GET: Propietario/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        // POST: Propietario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Propietario prop)
        {
    
            // TODO: Add insert logic here
            int resul=repo.Create(prop);
            if(resul>0){
                return RedirectToAction(nameof(Index));
            }else{
                return View();
            }

        }

        // GET: Propietario/Edit/5
        public ActionResult Edit(int Id_prop)
        {
            Propietario p=repo.Obtener(Id_prop);
            return View(p);
        }

        // POST: Propietario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id_prop, Propietario prop)
        {
            try
            {
                repo.Edit(prop);
                // TODO: Add update logic here
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Propietario/Delete/5
        public ActionResult Delete(int Id_prop)
        {
            Propietario p=repo.Obtener(Id_prop);
            return View(p);
        }

        // POST: Propietario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id_prop, Propietario prop)
        {
            try
            {
                // TODO: Add delete logic here
                int resul=repo.Delete(Id_prop);

                if(resul>0){
                    return Redirect("/propietarios");
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