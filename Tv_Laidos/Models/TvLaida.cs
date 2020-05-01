using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tv_Laidos.Models
{
    public class TvLaida
    {
        public string pavadinimas { get; set; }
        public int trukme { get; set; }
        public int isleidimo_metai { get; set; }
        public float reitingai { get; set; }
        public float ziurovu_vidutinis_ivertinimas { get; set; }
        public string aprasymas { get; set; }
        public LaidosBusena busena { get; set; }
        public Kategorija zanras { get; set; }
        public AmziausCenzas amziaus_reikalavimas { get; set; }
        public int id_TV_LAIDA { get; set; }
    }
}