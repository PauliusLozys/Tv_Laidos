using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tv_Laidos.Models;
using Tv_Laidos.Repos;

namespace Tv_Laidos.Controllers
{
    public class TvTinklaiController : Controller
    {
        TvTinklaiRepository tinklaiRepo = new TvTinklaiRepository();
        SalisRepository salisRepo = new SalisRepository();


        // GET: TvTinklai
        public ActionResult Index()
        {
            return View(tinklaiRepo.getTvTinklai());
        }

        // GET: TvTinklai/Create
        public ActionResult Create()
        {
            TvTinklas tinklas = new TvTinklas();
            PopulateSelections(tinklas);
            return View(tinklas);
        }

        // POST: TvTinklai/Create
        [HttpPost]
        public ActionResult Create(TvTinklas tinklas)
        {
            try
            {
                // TODO: Add insert logic here

                tinklaiRepo.addTvTinklas(tinklas);

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(tinklas);
                return View(tinklas);
            }
        }

        // GET: TvTinklai/Edit/5
        public ActionResult Edit(int id)
        {
            TvTinklas tinklas = tinklaiRepo.getTvTinklas(id);
            PopulateSelections(tinklas);
            return View(tinklas);
        }

        // POST: TvTinklai/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TvTinklas tinklas)
        {
            try
            {
                // TODO: Add update logic here

                tinklaiRepo.updateTvTinklas(tinklas);
                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(tinklas);
                return View(tinklas);
            }
        }

        // GET: TvTinklai/Delete/5
        public ActionResult Delete(int id)
        {
            TvTinklas tinklas = tinklaiRepo.getTvTinklas(id);
            return View(tinklas);
        }

        // POST: TvTinklai/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TvTinklas tinklas)
        {
            try
            {
                // TODO: Add delete logic here
                tinklaiRepo.deletetvTinklas(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public void PopulateSelections(TvTinklas tvTinklas)
        {
            var salis = salisRepo.getSalis();
            List<SelectListItem> selectListSalys = new List<SelectListItem>();

            foreach (var item in salis)
            {
                selectListSalys.Add(new SelectListItem { Value = item.id_SALIS.ToString(), Text = item.pavadinimas }); ;
            }

            tvTinklas.salis = selectListSalys;
        }
    }
}
