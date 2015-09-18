using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProdMan_Models.Tables
{
    public class ProductEigenschappen
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Eigenschap omschrijving")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Eigenschap Nummer")]
        public int Nummer { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Prijs Factor")]
        public decimal PrijsFactor { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Toeslag")]
        public decimal Toeslag { get; set; }
    }
}
