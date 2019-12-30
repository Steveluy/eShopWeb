using System.Data.Entity;
using System.Linq;
using eShopWeb.DTO;
using eShopWeb.IDAL;
using eShopWeb.Models;

namespace eShopWeb.DAL
{
    public class GoodDetailService : BaseService<GoodDetails>, IGoodDetailService
    {
        public GoodDetailService() : base(new eShopContext())
        {

        }
    }
}