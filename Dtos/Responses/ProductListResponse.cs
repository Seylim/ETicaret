using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Responses
{
    public class ProductListResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TradeMark { get; set; }
        public string Description { get; set; }
        public int Discount { get; set; }
        public float SalePrice { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
