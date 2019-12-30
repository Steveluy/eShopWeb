using eShopWeb.DTO;
using eShopWeb.IDAL;
using eShopWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace eShopWeb.DAL
{
    public class GoodsService: BaseService<Goods>, IGoodsService
    {
        public GoodsService() : base(new eShopContext())
        {
        }
    }
}
