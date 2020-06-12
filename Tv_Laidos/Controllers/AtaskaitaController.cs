using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tv_Laidos.Repos;
using Tv_Laidos.ViewModels;

namespace Tv_Laidos.Controllers
{
    public class AtaskaitaController : Controller
    {
        LaidosBusenosRepository busenos = new LaidosBusenosRepository();
        AtaskaitaRepository ataskaitaRepo = new AtaskaitaRepository();
        // GET: Ataskaita
        public ActionResult Index(int? NuoMetai, int? IkiMetai, int? NuoReitingas, int? LaidosBusena)
        {
            var ataskaita = new AtaskaitaViewModel();
            ataskaita.NuoMetai = (NuoMetai == null) ? 0 : (int)NuoMetai;
            ataskaita.IkiMetai = (IkiMetai == null) ? 0 : (int)IkiMetai;
            ataskaita.NuoReitingas = (NuoReitingas == null) ? 0 : (int)NuoReitingas;
            ataskaita.LaidosBusena = (LaidosBusena == null) ? 0 : (int)LaidosBusena;
            PopulateList(ataskaita);

            //if (!(NuoMetai is null || IkiMetai is null || NuoReitingas is null || LaidosBusena is null))
                ataskaita.tvlaidos = ataskaitaRepo.getAtaskaita(NuoMetai, IkiMetai, NuoReitingas, LaidosBusena);
            return View(ataskaita);
        }

        private void PopulateList(AtaskaitaViewModel atasakaita)
        {
            var visosLytis = busenos.getLaidosBusenos();

            List<SelectListItem> busenosList = new List<SelectListItem>();

            foreach (var item in visosLytis)
            {
                busenosList.Add(new SelectListItem() { Value = item.id_laidos_busena.ToString(), Text = item.name });
            }

            atasakaita.BusenaList = busenosList;
        }
    }
}
