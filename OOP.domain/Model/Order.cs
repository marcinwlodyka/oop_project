using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.domain.Model
{
    public class Order
    {
        public int id { get; set; }
        public string pizzaId { get; set; }
        public int size { get; set; }
        public string orderDate { get; set; }
        public int delivererId { get; set; }
        public string address { get; set; }
    }
}
