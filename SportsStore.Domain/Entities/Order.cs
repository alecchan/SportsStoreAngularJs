using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsStore.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string   Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public bool GiftWrap { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
