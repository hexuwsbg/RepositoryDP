using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImbarkPlatform.DB.Interfaces;
using ImbarkPlatform.Lib.UserManagement;

namespace ImbarkPlatform.Services.AccountManagement.AccountServiceInterfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// User login
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns>FALSE: login failed;  TRUE: login succeeded</returns>
        bool Login(UserInfo userInfo);
        /// <summary>
        /// Registers a user
        /// </summary>
        /// <param name="userInfo"></param>
        void Register( UserInfo userInfo );
        /// <summary>
        /// Activates a user
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        bool ActivateUser( UserInfo userInfo );
    }
}
