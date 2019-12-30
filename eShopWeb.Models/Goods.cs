
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShopWeb.Models
{
    public class Goods : BaseEntity
    {
        /// <summary>
        /// 商品的名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 商品的缩略图url
        /// </summary>
        public string ImgUrl { get; set; }

        /// <summary>
        /// 商品的当前售价
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// 商品的原价
        /// </summary>
        public double Price_old { get; set; }
    }
}
