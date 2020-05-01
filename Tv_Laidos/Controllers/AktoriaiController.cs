using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tv_Laidos.Repos;
using Tv_Laidos.ViewModels;

namespace Tv_Laidos.Controllers
{
    public class AktoriaiController : Controller
    {
        AktoriaiRepository aktoriai = new AktoriaiRepository();
        LytisRepository lytis = new LytisRepository();


        // GET: Aktoriai
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(aktoriai.getAktoriai());
        }

        // GET: Aktoriai/Create
        public ActionResult Create()
        {
            AktoriusEditViewModel aktorius = new AktoriusEditViewModel();
            PopulateSelections(aktorius);
            return View(aktorius);
        }

        // POST: Aktoriai/Create
        [HttpPost]
        public ActionResult Create(AktoriusEditViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                aktoriai.addAktorius(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View();
            }
        }

        // GET: Aktoriai/Edit/5
        public ActionResult Edit(int id)
        {
            AktoriusEditViewModel aktorius = aktoriai.getAktorius(id);
            PopulateSelections(aktorius);
            return View(aktorius);
        }

        // POST: Aktoriai/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AktoriusEditViewModel collection)
        {
            try
            {
                // TODO: Add update logic here

                aktoriai.updateAktorius(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }

        // GET: Aktoriai/Delete/5
        public ActionResult Delete(int id)
        {
            AktoriusEditViewModel aktorius = aktoriai.getAktorius(id);
            return View(aktorius);
        }

        // POST: Aktoriai/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                aktoriai.deleteAktorius(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public void PopulateSelections(AktoriusEditViewModel aktorius)
        {
            var lytys = lytis.getLytis();

            List<SelectListItem> selectListLytis = new List<SelectListItem>();

            foreach (var item in lytys)
            {
                selectListLytis.Add(new SelectListItem() { Value = Convert.ToString(item.id_lytis), Text = item.name });
            }

            aktorius.LytisList = selectListLytis;
        }

    }
}
