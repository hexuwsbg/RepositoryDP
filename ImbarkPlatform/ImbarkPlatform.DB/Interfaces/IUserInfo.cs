using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImbarkPlatform.Lib.UserManagement;

namespace ImbarkPlatform.DB.Interfaces
{
    public interface IUserInfo
    {
        /// <summary>
        /// add one user to db
        /// </summary>
        /// <param name="user"></param>
        void AddUser( UserInfo user );
        /// <summary>
        /// update user to db
        /// </summary>
        /// <param name="user"></param>
        void UpdateUser( UserInfo user );
        /// <summary>
        /// Gets a user by id
        /// </summary>
        /// <param name="userId"></param>
        void GetUserById( int userId );
        /// <summary>
        /// Gets a user by email address
        /// </summary>
        /// <param name="email"></param>
        void GetUserByEmail( string email );
        /// <summary>
        /// delete a user logically
        /// </summary>
        /// <param name="userId"></param>
        void DeleteUser( int userId );
    }
}
