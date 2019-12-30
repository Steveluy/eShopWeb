using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopWeb.IBLL
{
    public interface IUsersManager
    {
        bool Login(string email, string pwd, out Guid userGuid);
    }
}
