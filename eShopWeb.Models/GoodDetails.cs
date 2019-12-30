using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopWeb.Models
{
    public class GoodDetails:BaseEntity
    {
        /// <summary>
        /// 商品详情的图片的URL
        /// </summary>
        [Required]
        public string ImgUrl { get; set; }

        [ForeignKey(nameof(Goods))] 
        public Guid GoodsId { get; set; }
        public Goods Goods { get; set; }
    }
}
