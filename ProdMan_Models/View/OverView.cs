using System.Collections.Generic;
using ProdMan_Models.Tables;

namespace ProdMan_Models.View
{
    public class OverView
    {   
        public List<Product> Products { get; set; }

        public List<Leverancier> Leveranciers { get; set; }

        public List<ProductGroep> ProductGroeps { get; set; }
    }
}
