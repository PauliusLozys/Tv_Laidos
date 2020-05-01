using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tv_Laidos.Models
{
    public class Epizodas
    {
        [DisplayName("Pavadinimas")]
        [Required]
        public string pavadinimas { get; set; }
        [DisplayName("Aprašymas")]
        [Required]
        public string aprasymas { get; set; }
        [DisplayName("Direktorius")]
        [Required]
        public string direktorius { get; set; }
        [DisplayName("Epizodo numeris")]
        public int epizodo_numeris { get; set; }
        [DisplayName("Epizodo ID")]
        public int id_EPIZODAS { get; set; }
        [DisplayName("Sezonas ID")]
        public int fk_SEZONASid_SEZONAS { get; set; }
    }
}