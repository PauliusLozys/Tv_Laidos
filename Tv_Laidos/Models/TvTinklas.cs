using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Tv_Laidos.Models
{
    public class TvTinklas
    {
        [DisplayName("Pavadinimas")]
        [MaxLength(50)]
        [Required]
        public string pavadinimas { get; set; }

        [DisplayName("Adresas")]
        [MaxLength(50)]
        [Required]
        public string  adresas { get; set; }

        [DisplayName("Žiurovų skaičius")]
        [Required]
        public int ziurovu_skaicius { get; set; }

        [DisplayName("Savininkas")]
        [MaxLength(50)]
        [Required]
        public string savininkas { get; set; }

        [DisplayName("Vadovas")]
        [MaxLength(50)]
        [Required]
        public string vadovas { get; set; }

        [DisplayName("ID")]
        [Required]
        public int id_TV_TINKLAS { get; set; }

        [DisplayName("Įkūrimo šalis")]
        [Required]
        public int fk_SALIS_id_SALIS { get; set; }

        public IList<SelectListItem> salis { get; set; }
    }
}