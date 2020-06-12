using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tv_Laidos.ViewModels
{
    public class SAtaskaitaViewModel
    {
        [DisplayName("Laidos Pavadinimas")]
        public string Pavadinimas { get; set; }
        [DisplayName("Įvertis")]
        public float ZiurovuIvertinimas { get; set; }
        [DisplayName("Išleidimo metai")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Metai { get; set; }
        [DisplayName("Žanras")]
        public string Zanras { get; set; }
        [DisplayName("Būsena")]
        public string Laidos_Busena { get; set; }
        [DisplayName("Epizodų sk.")]
        public int EpizoduSkaicius { get; set; }
        [DisplayName("apdovanijimų sk.")]
        public int ApdovanojimuKiekis { get; set; }
        [DisplayName("Kurėjų sk.")]
        public int kurejuKiekis { get; set; }
        [DisplayName("Sezono nr.")]
        public int SezonoNumeris { get; set; }
        public int SezonuKiekis { get; set; }
        public int MinIvertinimas { get; set; }
        public int MaxIvertinimas { get; set; }
        [DisplayName("Išleista")]
        public int IsleidimoData { get; set; }
        [DisplayName("Užbaigta")]
        public int PabaigosData { get; set; }
    }
}