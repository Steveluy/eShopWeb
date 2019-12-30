using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using eShopWeb.BLL;
using eShopWeb.Filters;
using eShopWeb.Models.UserViewModel;

namespace eShopWeb.Controllers
{
    public class HomeController : Controller
    {
        [EShopAuthAttrbute]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                IBLL.IUsersManager userManager = new UsersManager();
                Guid userGuid;
                if (userManager.Login(loginViewModel.Email, loginViewModel.LoginPwd, out userGuid))
                {
                    //设置为记住我
                    if (loginViewModel.RememberMe)
                    {
                        Response.Cookies.Add(new HttpCookie("loginName")
                        {
                            Value = loginViewModel.Email,
                            Expires = DateTime.Now.AddDays(7)
                        });
                        Response.Cookies.Add(new HttpCookie("userGuid")
                        {
                            Value = userGuid.ToString(),
                            Expires = DateTime.Now.AddDays(7)
                        });
                    }
                    else
                    {
                        Session["loginName"] = loginViewModel.Email;
                        Session["userGuid"] = userGuid;
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "您输入的账号不正确！");
                }
            }

            return View(loginViewModel);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            //HttpCookie cookieLoginName = Request.Cookies["loginName"];
            //if (cookieLoginName != null) cookieLoginName.Expires = DateTime.Now.AddDays(-1);
            //HttpCookie cookieUserGuid = Request.Cookies["userGuid"];
            //if (cookieUserGuid != null) cookieUserGuid.Expires = DateTime.Now.AddDays(-1);
            //Session["loginName"] = "";
            //Session["userGuid"] = "";
            return RedirectToAction("Index");
        }
    }
}