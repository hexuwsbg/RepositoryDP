using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ImbarkPlatform.DB.Interfaces;
using ImbarkPlatform.Lib.UserManagement;
using ImbarkPlatform.Services.AccountManagement.AccountServiceInterfaces;
using System.Reflection;

namespace ImbarkPlatform.Services.AccountManagement.AccountServiceImplements
{
    public class AccountServiceImpl : IAccountService
    {
        private IUserInfo userInfoDAO;

        public AccountServiceImpl()
        {
            string db = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            string className = string.Format("ImbarkPlatform.DB.{0}Implements.UserInfoImpl", db);
            this.userInfoDAO = (IUserInfo)Assembly.Load("ImbarkPlatform.DB").CreateInstance(className);
        }

        public bool Login( UserInfo userInfo )
        {
            throw new NotImplementedException();
        }

        public void Register( UserInfo userInfo )
        {
            DateTime now = DateTime.Now;
            userInfo.IsActive = false;
            userInfo.LastActiveTime = now;
            userInfo.ActiveCode = Guid.NewGuid().ToString() + "_" + Guid.NewGuid().ToString();
            userInfo.ActiveCodeExpireTime = now.AddDays(15);
            userInfoDAO.AddUser(userInfo);
        }

        public bool ActivateUser( UserInfo userInfo )
        {
            throw new NotImplementedException();
        }
    }
}
