using System;
using System.ComponentModel.DataAnnotations;

namespace ProdMan_Models.Tables
{
    public class ProductEigenschappenKoppeling
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        public int ProductEigenschappenId { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        public int  ProductId { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        public DateTime AanmaakDatum { get; set; }
    }
}
