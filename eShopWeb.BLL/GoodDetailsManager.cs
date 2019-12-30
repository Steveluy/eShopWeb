using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using eShopWeb.DAL;
using eShopWeb.DTO;
using eShopWeb.IBLL;
using eShopWeb.IDAL;
using eShopWeb.Models;

namespace eShopWeb.BLL
{
    public class GoodDetailsManager : IGoodDetailsManager
    {
        public async Task<List<GoodsDetailDto>> GetAllGoodDetails()
        {
            using (var goodDetail=new GoodDetailService())
            {
                var goodDetailList = await goodDetail.GetAllAsync().Select(m => new GoodsDetailDto()
                {
                    Id = m.Id,
                    ImgUrl=m.ImgUrl,
                    Update=m.CreateTime,
                    IsRemoved = m.IsRemoved,
                    GoodsId = m.GoodsId
                }).ToListAsync();

                using (IGoodsService goodSev=new GoodsService())
                {
                    foreach (var goodsDetailDto in goodDetailList)
                    {
                        var goods = await goodSev.GetOneByIdAsync(goodsDetailDto.GoodsId);
                        goodsDetailDto.GoodsName = goods.Name;
                    }
                    return goodDetailList;
                }
            }
        }
    }
}