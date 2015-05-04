using SportsStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsStore.Domain.Entities
{
    public class OrderViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public ShippingDetails ShippingDetails { get; set; }
    }
}
