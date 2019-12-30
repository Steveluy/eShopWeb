using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eShopWeb.Models.GoodViewModel
{
    public class CreateGoodViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name="品名")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "缩略图URL")]
        public string ImgsUrl { get; set; }
        [Required]
        [Display(Name = "当前售价")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "原价")]
        public double PriceOld { get; set; }
    }
}