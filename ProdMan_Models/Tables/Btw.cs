using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProdMan_Models.Tables
{
    public class Btw
    {        
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("BTW Naam")]
        public string BtwNaam { get; set; }

        [Required(ErrorMessage = "Verplicht!")]
        [DisplayName("BTW Percentage")]
        public int BtwValue { get; set; }        
    }
}
