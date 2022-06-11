using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Requests
{
    public class AddProductRequest
    {
        public string Name { get; set; }
        public string TradeMark { get; set; }
        public short Stock { get; set; }
        public string Description { get; set; }
        public int Discount { get; set; }
        public float PurchasePrice { get; set; }
        public float SalePrice { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
