using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProdMan_Models.Tables
{
    public class Leverancier
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Leverancier Nummer: ")]
        public int Nummer { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Leverancier Naam: ")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Adres: ")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Postcode: ")]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Plaats: ")]
        public string Plaats { get; set; }

        [DisplayName("Telefoon 1: ")]
        public string Telefoon1 { get; set; }

        [DisplayName("Telefoon 2: ")]
        public string Telefoon2 { get; set; }

        [DisplayName("Fax: ")]
        public string Fax { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("E-mail: ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Website: ")]
        public string Website { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Contact Persoon: ")]
        public string ContactPersoon { get; set; }
    }
}
