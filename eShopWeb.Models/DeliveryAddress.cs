using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopWeb.Models
{
    public class DeliveryAddress : BaseEntity
    {
        /// <summary>
        /// 收货人
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 收货人手机号
        /// </summary>
        [Required]
        public string Phone { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        [Required]
        public string Sheng { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        [Required]
        public string City { get; set; }
        /// <summary>
        /// 区/镇
        /// </summary>
        [Required]
        public string Town { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        [Required]
        public string MoreAddress { get; set; }

        [ForeignKey(nameof(Users))]
        public Guid UserGuid { get; set; }

        public Users Users { get; set; }
    }
}
