using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tv_Laidos.Models;

namespace Tv_Laidos.ViewModels
{
    public class TvLaidaEditViewModel
    {
        [DisplayName("ID")]
        [Required]
        public int id_TV_LAIDA { get; set; }
        [DisplayName("Pavadinimas")]
        [MaxLength(50)]
        [Required]
        public string pavadinimas { get; set; }
        [DisplayName("Trukmė")]
        [Required]
        public int trukme { get; set; }
        [DisplayName("Išleidimo metai")]
        
        [Required]
        public int isleidimo_metai { get; set; }
        [DisplayName("Reitingai")]
        [Required]
        public float reitingai { get; set; }
        [DisplayName("Vidutinis įvertinimas")]
        //[DataType(DataType.Currency)]
        [Range(1, 10.0f)]
        [Required]
        public float ziurovu_vidutinis_ivertinimas { get; set; }
        [DisplayName("Aprašymas")]
        [MaxLength(255)]
        [Required]
        public string aprasymas { get; set; }
        [DisplayName("Rodymo būsena")]
        [Required]
        public int busena { get; set; }
        [DisplayName("Žanras")]
        [Required]
        public int zanras { get; set; }
        [DisplayName("Amžiaus reikalavimas")]
        [Required]
        public int amziaus_reikalavimas { get; set; }

        public List<Apdovanojimas> apdovanojimai { get; set; }

        public IList<SelectListItem> BusenaList { get; set; }
        public IList<SelectListItem> ZanroList { get; set; }
        public IList<SelectListItem> AmziausReikalavimoList { get; set; }
    }
}