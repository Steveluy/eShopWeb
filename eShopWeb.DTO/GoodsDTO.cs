using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopWeb.DTO
{
    public class GoodsDTO
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string imgUrl { get; set; }
        public double price { get; set; }
        public double price_old { get; set; }
        public List<string> imgsUrl { get; set; }
    }
}
