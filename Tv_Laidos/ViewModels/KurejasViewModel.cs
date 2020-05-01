using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tv_Laidos.ViewModels
{
    public class KurejasViewModel
    {
        [DisplayName("Vardas")]
        public string vardas { get; set; }
        [DisplayName("Pavardė")]
        public string pavarde { get; set; }
        [DisplayName("Gimimo metai")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime gimimo_metai { get; set; }
        [DisplayName("Role")]
        public string role { get; set; }
        [DisplayName("Lytis")]
        public string lytis { get; set; }
        [DisplayName("ID")]
        public int id_KUREJAS { get; set; }
    }
}