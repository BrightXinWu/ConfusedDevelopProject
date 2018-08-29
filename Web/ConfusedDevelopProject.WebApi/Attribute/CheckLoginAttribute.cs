using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfusedDevelopProject.WebApi
{
    public class CheckLoginAttribute : Attribute
    {
        public bool IsNeedLogin = false;

        public CheckLoginAttribute(bool isNeed)
        {
            this.IsNeedLogin = isNeed;
        }
    }
}