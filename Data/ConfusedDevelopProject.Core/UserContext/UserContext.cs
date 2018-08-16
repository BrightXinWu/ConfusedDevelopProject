using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfusedDevelopProject.Core
{
    public class UserContext : IUserContext
    {
        public UserInfo WorkUserInfo { get; set; }
    }
}