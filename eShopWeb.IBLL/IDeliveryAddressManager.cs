using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopWeb.Models;

namespace eShopWeb.IBLL
{
    public interface IDeliveryAddressManager
    {
        Task AddDeliveryAddress(DeliveryAddress deliveryAddress);

        Task<List<DeliveryAddress>> GetDeliveryAddressByUserGuid(Guid userGuid);

        Task AddDeliveryAddress(string name, string phone, string sheng, string city, string town, string moreAddress, Guid userGuid);
    }
}