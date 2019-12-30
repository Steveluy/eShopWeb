using System;
using System.Linq;
using System.Threading.Tasks;
using eShopWeb.IDAL;
using eShopWeb.Models;

namespace eShopWeb.DAL
{
    public class UsersService : BaseService<Users>, IUsersService
    {
        public UsersService() : base(new eShopContext())
        {
        }
    }
}