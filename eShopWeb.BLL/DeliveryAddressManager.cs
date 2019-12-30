using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using eShopWeb.DAL;
using eShopWeb.IBLL;
using eShopWeb.IDAL;
using eShopWeb.Models;

namespace eShopWeb.BLL
{
    public class DeliveryAddressManager : IDeliveryAddressManager
    {
        public async Task AddDeliveryAddress(DeliveryAddress deliveryAddress)
        {
            using (var deliveryAddressServ = new DeliveryAddressService())
            {
                //await deliveryAddressServ.CreateAsync(new DeliveryAddress()
                //{
                //    Name = deliveryAddress.Name,
                //    Phone = deliveryAddress.Phone,
                //    Sheng = deliveryAddress.Sheng,
                //    City = deliveryAddress.City,
                //    Town = deliveryAddress.Town,
                //    MoreAddress = deliveryAddress.MoreAddress,
                //    UserGuid = deliveryAddress.UserGuid
                //});
                await deliveryAddressServ.CreateAsync(deliveryAddress);
            }
        }

        public async Task AddDeliveryAddress(string name, string phone, string sheng, string city, string town, string moreAddress, Guid userGuid)
        {
            using (var deliveryAddressServ = new DeliveryAddressService())
            {
                await deliveryAddressServ.CreateAsync(new DeliveryAddress()
                {
                    Name = name,
                    Phone = phone,
                    Sheng = sheng,
                    City = city,
                    Town = town,
                    MoreAddress = moreAddress,
                    UserGuid = userGuid
                });
                // await deliveryAddressServ.CreateAsync(deliveryAddress);
            }
        }

        public async Task<List<DeliveryAddress>> GetDeliveryAddressByUserGuid(Guid userGuid)
        {
            using (IDAL.IDeliveryAddressService deliveryAddress = new DeliveryAddressService())
            {
                return await deliveryAddress.GetAllAsync().Where(m=>m.UserGuid==userGuid).ToListAsync();
            }
        }
    }
}