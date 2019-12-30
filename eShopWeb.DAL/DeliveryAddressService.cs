using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShopWeb.IDAL;
using eShopWeb.Models;

namespace eShopWeb.DAL
{
    public class DeliveryAddressService:BaseService<DeliveryAddress>,IDeliveryAddressService
    {
        public DeliveryAddressService() : base(new eShopContext())
        {

        }
    }
}
