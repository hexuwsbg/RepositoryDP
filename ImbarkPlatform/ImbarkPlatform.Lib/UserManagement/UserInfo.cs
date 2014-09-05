using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImbarkPlatform.Lib.UserManagement
{
    public class UserInfo
    {
        public int UserId { set; get; }
        public string Nickname { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }
        public string ActiveCode { set; get; }
        public DateTime ActiveCodeExpireTime { set; get; }
        public DateTime LastActiveTime { set; get; }
        public CommEnum.UserRole Role { set; get; }
    }
}
