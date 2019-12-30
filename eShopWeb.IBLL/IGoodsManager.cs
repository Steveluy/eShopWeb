using eShopWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShopWeb.DTO;

namespace eShopWeb.IBLL
{
    public interface IGoodsManager
    {
        /// <summary>
        /// 添加新商品
        /// </summary>
        /// <param name="Name">商品名称</param>
        /// <param name="ImgUrl">商品缩略图</param>
        /// <param name="price">当前售价</param>
        /// <param name="price_old">商品原价</param>
        /// <returns></returns>
        Task AddGoods(string name, string imgUrl, double price, double price_old);
        Task<List<DTO.GoodsDTO>> GetAllGoods();
        Task<DTO.GoodsDTO> GetOneById(Guid id);
        Task EditGoods(Guid id, string name, string imgUrl, double price, double price_old);
        Task DeleteGoods(Guid id);
    }
}
