using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tv_Laidos.Models
{
    public class Kurejas
    {
        public string vardas { get; set; }
        public string pavarde { get; set; }
        public DateTime gimimo_metai { get; set; }
        public string role { get; set; }
        public Lytis lytis { get; set; }
        public int id_KUREJAS { get; set; }
    }
}