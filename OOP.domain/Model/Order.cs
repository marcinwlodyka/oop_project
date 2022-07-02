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
        public int pizzaId { get; set; }
        public int sizeId { get; set; }
        public string orderDate { get; set; }
        public string address { get; set; }
    }
}
