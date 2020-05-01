using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tv_Laidos.ViewModels
{
    public class AktoriusViewModel
    {
        [DisplayName("Vardas")]
        public string vardas { get; set; }
        [DisplayName("Pavardė")]
        public string pavarde { get; set; }
        [DisplayName("Gimimo metai")]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime gimino_metai { get; set; }
        [DisplayName("Lytis")]
        public string lytis { get; set; }
        [DisplayName("ID")]
        public int id_AKTORIUS { get; set; }
    }
}