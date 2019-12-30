using eShopWeb.Models.GoodViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using eShopWeb.BLL;
using System.Threading.Tasks;
using eShopWeb.DTO;
using eShopWeb.Models;

namespace eShopWeb.Controllers
{
    public class GoodsController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> GoodsList()
        {
            Task<List<GoodsDetailDto>> goodDetailses= new GoodDetailsManager().GetAllGoodDetails();
            return View(await new GoodsManager().GetAllGoods());
        }

        // GET: Goods
        [HttpGet]
        public ActionResult CreateGood()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGood(CreateGoodViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IGoodsManager goodsManager = new GoodsManager();
                goodsManager.AddGoods(model.Name, model.ImgsUrl, model.Price, model.PriceOld);
                return RedirectToAction("GoodsList");
            }
            ModelState.AddModelError("", "您录入的信息有误");
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> EditGood(Guid id)
        {
            IBLL.IGoodsManager goodsManager = new GoodsManager();
            var good = await goodsManager.GetOneById(id);
            return View(new CreateGoodViewModel()
            {
                Id=good.id,
                Name = good.name,
                Price = good.price,
                PriceOld = good.price_old,
                ImgsUrl = good.imgUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditGood(CreateGoodViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IGoodsManager goodsManager = new GoodsManager();
                await goodsManager.EditGoods(model.Id, model.Name,model.ImgsUrl, model.Price, model.PriceOld);
                return RedirectToAction("GoodsList");
            }
            else
                return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            IBLL.IGoodsManager goodsManager = new GoodsManager();
            await goodsManager.DeleteGoods(id);
            return RedirectToAction("GoodsList");
        }
    }
}