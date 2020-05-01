using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tv_Laidos.Models
{
    public class Apdovanojimas
    {
        [DisplayName("Kategorija")]
        [MaxLength(50)]
        [Required]
        public string kategorija { get; set; }
        [DisplayName("Nominantas")]
        [MaxLength(50)]
        [Required]
        public string nominantas { get; set; }
        [DisplayName("Gavimo metai")]
        [Required]
        public int gavimo_metai { get; set; }
        [DisplayName("ID")]
        [Required]
        public int id_APDOVANOJIMAS { get; set; }
        public int fk_TV_LAIDAid_TV_LAIDA { get; set; }
    }
}