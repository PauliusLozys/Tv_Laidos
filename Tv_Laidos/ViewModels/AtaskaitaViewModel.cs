using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tv_Laidos.ViewModels
{
    public class AtaskaitaViewModel
    {
        [Required]
        public int NuoMetai { get; set; }
        [Required]
        public int IkiMetai { get; set; }
        [Range(0,10)]
        [Required]
        public int NuoReitingas{ get; set; }
        public int LaidosBusena { get; set; }
        public IList<SelectListItem> BusenaList { get; set; }

        public List<SAtaskaitaViewModel> tvlaidos;

    }
}