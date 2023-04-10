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
        public ActionResult Details(int InquiId)
        {
            Inquilino inqui=repo.ObtenerInqui(InquiId);
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
            catch(Exception ex)
            {
                throw;
            }
        }

        // GET: Inquilinos/Edit/5
        public ActionResult Edit(int InquiId)
        {
            Inquilino inq=repo.ObtenerInqui(InquiId);
            return View(inq);
        }

        // POST: Inquilinos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int InquiId, Inquilino inqui)
        {
            try
            {
                // TODO: Add update logic here
                repo.EditI(inqui);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        // GET: Inquilinos/Delete/5
        public ActionResult Delete(int InquiId)
        {
            try{
            Inquilino inq=repo.ObtenerInqui(InquiId);
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