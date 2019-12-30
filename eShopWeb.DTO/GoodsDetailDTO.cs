using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopWeb.DTO
{
    public class GoodsDetailDto
    {
        public Guid Id { get; set; }
        public string ImgUrl { get; set; }
        public DateTime Update { get; set; }
        public bool IsRemoved { get; set; }
        public Guid GoodsId { get; set; }
        public string GoodsName { get; set; }
    }
}
