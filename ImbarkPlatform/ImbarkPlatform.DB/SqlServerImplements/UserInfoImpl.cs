using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ImbarkPlatform.DB.Helper;
using ImbarkPlatform.DB.Interfaces;
using ImbarkPlatform.Lib.UserManagement;

namespace ImbarkPlatform.DB.SqlServerImplements
{
    public class UserInfoImpl : IUserInfo
    {
        public void AddUser( UserInfo user )
        {
            DBConnection conn = null;
            try
            {
                string sqlInsert = string.Format(@"INSERT INTO [UserInfo](
                                                            [Nickname], 
                                                            [Email], 
                                                            [Password], 
                                                            [IsActive], 
                                                            [ActiveCode],
                                                            [ActiveCodeExpireTime], 
                                                            [LastActiveTime], 
                                                            [Role])
                                                    VALUES(@Nickname, 
                                                            @Email, 
                                                            @Password, 
                                                            @IsActive, 
                                                            @ActiveCode,
                                                            @ActiveCodeExpireTime, 
                                                            @LastActiveTime, 
                                                            @Role)");
                Hashtable ht = new Hashtable();
                BindingFlags bf = BindingFlags.Instance | BindingFlags.Public;
                PropertyInfo[] properties = user.GetType().GetProperties(bf);
                foreach ( PropertyInfo pi in properties )
                {
                    ht.Add(pi.Name, pi.GetValue(user));
                }
                conn = ConnectionFactory.GetConnection();
                conn.ExecuteNonQuery(sqlInsert, ht);
                conn.CommitTransaction();
            }
            catch
            {
                if ( conn != null )
                {
                    conn.RollbackTransaction();
                }
                throw;
            }
            finally
            {
                if ( conn != null )
                {
                    conn.Close();
                }
            }
        }

        public void UpdateUser( UserInfo user )
        {
            throw new NotImplementedException();
        }

        public void GetUserById( int userId )
        {
            throw new NotImplementedException();
        }

        public void GetUserByEmail( string email )
        {
            throw new NotImplementedException();
        }

        public void DeleteUser( int userId )
        {
            throw new NotImplementedException();
        }

    }
}
