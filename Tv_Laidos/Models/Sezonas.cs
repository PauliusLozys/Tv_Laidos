using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tv_Laidos.Models
{
    public class Sezonas
    {
        public int isleidimo_data { get; set; }
        public int pabaigos_data { get; set; }
        public int epizodu_skaicius { get; set; }
        public int sezono_numeris { get; set; }
        public int id_SEZONAS { get; set; }
        public int fk_TV_LAIDAid_TV_LAIDA { get; set; }
    }
}