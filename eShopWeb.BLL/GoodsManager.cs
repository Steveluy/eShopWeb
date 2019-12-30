using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using eShopWeb.DAL;
using eShopWeb.DTO;
using eShopWeb.IBLL;
using eShopWeb.IDAL;
using eShopWeb.Models;

namespace eShopWeb.BLL
{
    public class GoodsManager : IGoodsManager
    {
        public async Task AddGoods(string name, string imgUrl, double price, double price_old)
        {
            using (var GoodSer = new GoodsService())
            {
                await GoodSer.CreateAsync(new Goods()
                {
                    Name = name,
                    ImgUrl = imgUrl,
                    Price = price,
                    Price_old = price_old
                });
            }
        }

        public async Task EditGoods(Guid id, string name, string imgUrl, double price, double price_old)
        {
            using (IDAL.IGoodsService goodsService = new GoodsService())
            {
                var good = await goodsService.GetOneByIdAsync(id);
                good.Name = name;
                good.ImgUrl = imgUrl;
                good.Price = price;
                good.Price_old = price_old;
                await goodsService.EditAsync(good);
            }
        }

        public async Task<List<DTO.GoodsDTO>> GetAllGoods()
        {
            using (IDAL.IGoodsService goodService = new GoodsService())
            { 
                var goodsDtos = await goodService.GetAllAsync().Select(m => new GoodsDTO()
                {
                    id = m.Id,
                    name = m.Name,
                    imgUrl = m.ImgUrl,
                    price = m.Price,
                    price_old = m.Price_old
                }).ToListAsync();
                using (IGoodDetailService goodDetailService = new GoodDetailService())
                {

                    foreach (var goodsDto in goodsDtos)
                    {
                        goodsDto.imgsUrl=new List<string>();
                        var goodDetails= goodDetailService.GetAllAsync().Where(m => m.GoodsId == goodsDto.id).ToList();
                        foreach (var goodDetail in goodDetails)
                            goodsDto.imgsUrl.Add(goodDetail.ImgUrl);;
                    }
                }
                return goodsDtos;
            }
        }

        public async Task<DTO.GoodsDTO> GetOneById(Guid id)
        {
            using (IDAL.IGoodsService goodsService = new GoodsService())
            {
                var data = await goodsService.GetAllAsync()
                    .Where(m => m.Id == id)
                    .Select(m => new DTO.GoodsDTO()
                    {
                        id = m.Id,
                        name = m.Name,
                        price = m.Price,
                        price_old = m.Price_old,
                        imgUrl = m.ImgUrl
                    }).FirstAsync();
                return data;
            }
        }

        public async Task DeleteGoods(Guid id) {
            using (var GoodSer = new GoodsService()) {
                await GoodSer.RemoveAsync(id);
            }
        }

        //public Task<List<GoodsDetailDto>> GetAllGoodDetails()
        //{
        //    using (IGoodsService goodsService=new GoodsService())
        //    {
        //        var data = await goodsService.GetAllAsync();
        //    }
        //}
    }
}
