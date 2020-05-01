using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tv_Laidos.Models
{
    public class Aktorius
    {
        public string vardas { get; set; }
        public string pavarde { get; set; }
        public DateTime gimino_metai { get; set; }
        public Lytis lytis { get; set; }
        public int id_AKTORIUS { get; set; }       
       
    }
}