using System;
using System.Data.Entity;
using System.Threading.Tasks;
using eShopWeb.IBLL;

namespace eShopWeb.BLL
{
    public class UsersManager : IUsersManager
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pwd"></param>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        public bool Login(string email, string pwd, out Guid userGuid)
        {
            using (IDAL.IUsersService usersSvc = new DAL.UsersService())
            {
                var user = usersSvc.GetAllAsync().FirstOrDefaultAsync(m => m.Email == email && m.LoginPwd == pwd);
                user.Wait();
                var data = user.Result;
                if (data == null)
                {
                    userGuid = new Guid();
                    return false;
                }
                else
                {
                    userGuid = data.Id;
                    return true;
                }

            }
        }
    }
}