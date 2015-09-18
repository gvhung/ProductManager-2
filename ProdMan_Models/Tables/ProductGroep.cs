using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProdMan_Models.Tables
{
    public class ProductGroep
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Nummer: ")]
        public int Nummer { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Naam: ")]
        public string Naam { get; set; }
    }
}
