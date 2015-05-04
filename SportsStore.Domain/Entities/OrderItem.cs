using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SportsStore.Domain.Entities
{
    [Table("OrderItems")]
    public class OrderItem
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
