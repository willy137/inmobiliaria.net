using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class InquilinosController : Controller
    {

        private readonly RepositorioInquilino repo= new RepositorioInquilino();
        // GET: Inquilinos
        public ActionResult Index()
        {
            List<Inquilino> inqui=repo.GetInquilino();
            return View(inqui);
        }

        // GET: Inquilinos/Details/5
        public ActionResult Details(int id_inqui)
        {
            Inquilino inqui=repo.ObtenerInqui(id_inqui);
            return View(inqui);
        }

        // GET: Inquilinos/Create
        public ActionResult Create()
        {
            return View();
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
            catch
            {
                return View();
            }
        }

        // GET: Inquilinos/Edit/5
        public ActionResult Edit(int id_inqui)
        {
            Inquilino inq=repo.ObtenerInqui(id_inqui);
            return View(inq);
        }

        // POST: Inquilinos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id_inqui, Inquilino inqui)
        {
            try
            {
                // TODO: Add update logic here
                repo.EditI(inqui);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Inquilinos/Delete/5
        public ActionResult Delete(int Id_inqui)
        {
            Inquilino inq=repo.ObtenerInqui(Id_inqui);
            return View(inq);
        }

        // POST: Inquilinos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id_inqui, Inquilino inqui)
        {
            try
            {

                // TODO: Add delete logic here
                int res=repo.Delete(Id_inqui);
                if(res>0){
                    return Redirect("/inquilinos");
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