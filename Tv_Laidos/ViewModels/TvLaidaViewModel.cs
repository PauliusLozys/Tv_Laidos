using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Tv_Laidos.Models;

namespace Tv_Laidos.ViewModels
{
    public class TvLaidaViewModel
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Laidos Pavadinimas")]
        public string pavadinimas { get; set; }
        [DisplayName("Išleidimo metai")]
        public int isleidimo_metai { get; set; }
        [DisplayName("Amžiaus reikalavimas")]
        public string amziaus_reikalavimas{ get; set; }

    }
}