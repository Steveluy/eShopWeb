using System.Collections.Generic;
using System.Threading.Tasks;
using eShopWeb.DTO;
using eShopWeb.Models;

namespace eShopWeb.IBLL
{
    public interface IGoodDetailsManager
    {
        Task<List<GoodsDetailDto>> GetAllGoodDetails();
    }
}