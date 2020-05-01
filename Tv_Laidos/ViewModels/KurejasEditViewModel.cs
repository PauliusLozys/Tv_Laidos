using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Tv_Laidos.Models;

namespace Tv_Laidos.ViewModels
{
    public class KurejasEditViewModel
    {
        [DisplayName("Vardas")]
        [MaxLength(50)]
        [Required]
        public string vardas { get; set; }
        [DisplayName("Pavardė")]
        [MaxLength(50)]
        [Required]
        public string pavarde { get; set; }
        [DisplayName("Gimimo metai")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime gimimo_metai { get; set; }
        [DisplayName("Role")]
        [MaxLength(50)]
        [Required]
        public string role { get; set; }
        [DisplayName("Lytis")]
        [Required]
        public int lytis { get; set; }
        [DisplayName("ID")]
        [Required]
        public int id_KUREJAS { get; set; }

        public List<Kuria> kuriaLaidas { get; set; }
        public List<SelectListItem> TvLaidosList { get; set; }

        public IList<SelectListItem> LytisList { get; set; }
    }
}