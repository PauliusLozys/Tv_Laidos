using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tv_Laidos.Repos;
using Tv_Laidos.ViewModels;

namespace Tv_Laidos.Controllers
{
    public class KurejaiController : Controller
    {
        KurejaiRepository kurejai = new KurejaiRepository();
        LytisRepository lytis = new LytisRepository();
        TvLaidosRepository tvlaidos = new TvLaidosRepository();
        KuriaRepository kuriaRepo = new KuriaRepository();

        // GET: Kurejai
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(kurejai.getKurejai());
        }
        // GET: Kurejai/Create
        public ActionResult Create()
        {
            KurejasEditViewModel kurejas = new KurejasEditViewModel();
            PopulateSelections(kurejas);
            return View(kurejas);
        }

        // POST: Kurejai/Create
        [HttpPost]
        public ActionResult Create(KurejasEditViewModel kurejas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int kurejoID = kurejai.addKurejas(kurejas);

                    if (kurejoID < 0)
                    {
                        ViewBag.failed = "Nepavyko iterpti apdovanojimo";
                        return View(kurejas);
                    }

                    if (kurejas.kuriaLaidas != null)
                    {
                        foreach (var item in kurejas.kuriaLaidas)
                        {
                            item.fk_KUREJASid_KUREJAS = kurejoID;
                            kuriaRepo.addKuriamas(item);
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(kurejas);
                return View();
            }
        }

        // GET: Kurejai/Edit/5
        public ActionResult Edit(int id)
        {
            KurejasEditViewModel kurejas = kurejai.getKurejas(id);
            PopulateSelections(kurejas);
            return View(kurejas);
        }

        // POST: Kurejai/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, KurejasEditViewModel kurejas)
        {
            try
            {
                kurejai.updateKurejas(kurejas);
                kuriaRepo.deleteKuria(id);

                if (kurejas.kuriaLaidas != null)
                {
                    foreach (var item in kurejas.kuriaLaidas)
                    {
                        item.fk_KUREJASid_KUREJAS = id;
                        kuriaRepo.addKuriamas(item);
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(kurejas);
                return View(kurejas);
            }
        }

        // GET: Kurejai/Delete/5
        public ActionResult Delete(int id)
        {
            KurejasEditViewModel kurejas = kurejai.getKurejas(id);
            return View(kurejas);
        }

        // POST: Kurejai/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here


                kurejai.deleteKurejas(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void PopulateSelections(KurejasEditViewModel kurejas)
        {
            var lytys = lytis.getLytis();
            var tv = tvlaidos.getShows();

            List<SelectListItem> selectListLytis = new List<SelectListItem>();
            List<SelectListItem> selectLaida = new List<SelectListItem>();


            foreach (var item in tv)
            {
                selectLaida.Add(new SelectListItem() { Value = Convert.ToString(item.id), Text = item.pavadinimas });
            }
            foreach (var item in lytys)
            {
                selectListLytis.Add(new SelectListItem() { Value = Convert.ToString(item.id_lytis), Text = item.name });
            }

            kurejas.LytisList = selectListLytis;
            kurejas.TvLaidosList = selectLaida;
            kurejas.kuriaLaidas = kuriaRepo.getKuria(kurejas.id_KUREJAS);
        }
    }
}
