using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfusedDevelopProject.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserContext
    {
        /// <summary>
        /// 当前人信息
        /// </summary>
        UserInfo WorkUserInfo { get; set; }
    }
}
