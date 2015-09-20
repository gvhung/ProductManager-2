using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdMan_Models.Tables
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Product Naam")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Product Code")]
        [Index(IsUnique = true)]
        public int Nummer { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Excl. Prijs: ")]
        public decimal Prijs { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Btw: ")]
        public int BtwId { get; set; }
        
        [DisplayName("Leveranciers Product Code: ")]
        public string LeveranciersCode { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Leverancier: ")]
        public int LeveranciersId { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Productgroep: ")]
        public int ProductgroepId { get; set; }

        [DisplayName("Zoek Termen: ")]
        public string Zoekcode { get; set; }

        [DisplayName("Aktief: ")]
        public Boolean Aktief { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Aanmaak Datum: ")]
        public DateTime AanmaakDatum { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("Laatste Aanpassing: ")]
        public DateTime WijziginsDatum { get; set; }
    }
}