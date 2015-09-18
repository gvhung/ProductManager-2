using ProdMan_Models.Tables;

namespace ProdMan_Models.View
{
    public class ProductView
    {
        public Product Product { get; set; }

        public Btw Btw { get; set; }

        public ProductGroep ProductGroep { get; set; }

        public Leverancier Leverancier { get; set; }

        public ProductEigenschappenKoppeling ProductEigenschappenKoppeling { get; set; }
    }
}
