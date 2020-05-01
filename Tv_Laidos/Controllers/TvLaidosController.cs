using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tv_Laidos.Repos;
using Tv_Laidos.ViewModels;

namespace Tv_Laidos.Controllers
{
    public class TvLaidosController : Controller
    {
        TvLaidosRepository tvLaidos = new TvLaidosRepository();
        LaidosBusenosRepository busena = new LaidosBusenosRepository();
        KategorijosRepository zanras = new KategorijosRepository();
        AmziausCenzaiRepository amzius = new AmziausCenzaiRepository();
        ApdovanojimaiRepository apdovanojimai = new ApdovanojimaiRepository();

        // GET: TvLaidos
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(tvLaidos.getShows());
        }

        // GET: TvLaidos/Create
        public ActionResult Create()
        {
            TvLaidaEditViewModel laida = new TvLaidaEditViewModel();
            //Užpildomi pasirinkimų sąrašai duomenimis iš duomenų saugyklų
            PopulateSelections(laida);
            return View(laida);
        }

        // POST: TvLaidos/Create
        [HttpPost]
        public ActionResult Create(TvLaidaEditViewModel laida)
        {
            try
            {
                    int laidos_id = tvLaidos.addShow(laida);

                    if (laidos_id < 0)
                    {
                        ViewBag.failed = "Nepavyko iterpti apdovanojimo";
                        return View(laida);
                    }

                    if (laida.apdovanojimai != null)
                    {
                        foreach (var item in laida.apdovanojimai)
                        {
                            if(item.fk_TV_LAIDAid_TV_LAIDA == 0)
                            {
                                item.fk_TV_LAIDAid_TV_LAIDA = laidos_id;
                                apdovanojimai.addApdovanojimas(item);
                            }
                        }
                    }
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(laida);
                return View(laida);
            }
        }

        // GET: TvLaidos/Edit/5
        public ActionResult Edit(int id)
        {
            TvLaidaEditViewModel laida = tvLaidos.getShow(id);
            laida.apdovanojimai = apdovanojimai.getApdovanojimai(id);
            PopulateSelections(laida);
            return View(laida);
        }

        // POST: TvLaidos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TvLaidaEditViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                tvLaidos.updateShow(collection);
                apdovanojimai.deleteApdovanojimas(id);

                if(collection.apdovanojimai != null)
                {
                    foreach (var item in collection.apdovanojimai)
                    {
                        item.fk_TV_LAIDAid_TV_LAIDA = id;
                        apdovanojimai.addApdovanojimas(item);
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }

        // GET: TvLaidos/Delete/5
        public ActionResult Delete(int id)
        {
            TvLaidaEditViewModel laida = tvLaidos.getShow(id);
            return View(laida);
        }

        // POST: TvLaidos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                 tvLaidos.deleteShow(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void PopulateSelections(TvLaidaEditViewModel laida)
        {
            var zanrai = zanras.getKategorija();
            var amziai = amzius.getAmziausCenzai();
            var busenos = busena.getLaidosBusenos();

            List<SelectListItem> selectListZanrai = new List<SelectListItem>();
            List<SelectListItem> selectListAmziai = new List<SelectListItem>();
            List<SelectListItem> selectListBusenos = new List<SelectListItem>();

            foreach (var item in zanrai)
            {
                selectListZanrai.Add(new SelectListItem() { Value = Convert.ToString(item.id_kategorija), Text = item.name });
            }
            foreach (var item in amziai)
            {
                selectListAmziai.Add(new SelectListItem() { Value = Convert.ToString(item.id_amziaus_cenzas), Text = item.name });
            }
            foreach (var item in busenos)
            {
                selectListBusenos.Add(new SelectListItem() { Value = Convert.ToString(item.id_laidos_busena), Text = item.name });
            }

            laida.AmziausReikalavimoList = selectListAmziai;
            laida.BusenaList = selectListBusenos;
            laida.ZanroList = selectListZanrai;


            laida.apdovanojimai = apdovanojimai.getApdovanojimai(laida.id_TV_LAIDA);

        }
    }
}
