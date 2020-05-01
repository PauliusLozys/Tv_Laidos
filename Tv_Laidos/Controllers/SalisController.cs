using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tv_Laidos.Models;
using Tv_Laidos.Repos;

namespace Tv_Laidos.Controllers
{
    public class SalisController : Controller
    {
        SalisRepository salys = new SalisRepository();

        // GET: Salis
        public ActionResult Index()
        {
            return View(salys.getSalis());
        }

        // GET: Salis/Create
        public ActionResult Create()
        {
            Salis sal = new Salis();
            return View(sal);
        }

        // POST: Salis/Create
        [HttpPost]
        public ActionResult Create(Salis salis)
        {
            try
            {
                // TODO: Add insert logic here

                salys.addSalis(salis);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(salis);
            }
        }

        // GET: Salis/Edit/5
        public ActionResult Edit(int id)
        {
            Salis salis = salys.getSalis(id);
            return View(salis);
        }

        // POST: Salis/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Salis salis)
        {
            try
            {
                // TODO: Add update logic here
                salys.updateSalis(salis);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(salis);
            }
        }

        // GET: Salis/Delete/5
        public ActionResult Delete(int id)
        {
            Salis salis = salys.getSalis(id);
            return View(salis);
        }

        // POST: Salis/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                salys.deleteSalis(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
