using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Tv_Laidos.Models
{
    public class Veikejas
    {
        public string vardas { get; set; }
        public string pavarde { get; set; }
        public int id_VEIKEJAI { get; set; }
        public int fk_TV_LAIDAid_TV_LAIDA { get; set; }
        public int fk_AKTORIUSid_AKTORIUS { get; set; }
    }
}