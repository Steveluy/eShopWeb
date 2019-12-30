using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopWeb.Models
{
    public class Users:BaseEntity
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime Brithday { get; set; }
        /// <summary>
        /// 性别男为1，女为0
        /// </summary>
        public int Sex { get; set; }
        [Required]
        public string LoginPwd { get; set; }
    }
}
