using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tv_Laidos.Models
{
    public class Kuria
    {
        [DisplayName("Laida")]
        [Required]
        public int fk_TV_LAIDAid_TV_LAIDA { get; set; }
        [DisplayName("kūrėjas")]
        [Required]
        public int fk_KUREJASid_KUREJAS { get; set; }
    }
}