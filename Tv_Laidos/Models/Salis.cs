using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tv_Laidos.Models
{
    public class Salis
    {
        [DisplayName("Šalis")]
        [MaxLength(50)]
        [Required]
        public string  pavadinimas { get; set; }
        [DisplayName("Gyventojų skaičius")]
        [Range(0,int.MaxValue)]
        [Required]
        public int gyventoju_skaicius { get; set; }
        [DisplayName("ID")]
        [Required]
        public int id_SALIS { get; set; }
    }
}