using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tv_Laidos.ViewModels
{
    public class AktoriusEditViewModel
    {
        [DisplayName("Vardas")]
        [MaxLength(50)]
        [Required]
        public string vardas { get; set; }
        [DisplayName("Pavardė")]
        [MaxLength(50)]
        public string pavarde { get; set; }
        [DisplayName("Gimimo metai")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime gimimo_metai { get; set; }
        [DisplayName("Lytis")]
        [Required]
        public int lytis { get; set; }
        [DisplayName("ID")]
        [Required]
        public int id_AKTORIUS { get; set; }

        public IList<SelectListItem> LytisList { get; set; }
    }
}