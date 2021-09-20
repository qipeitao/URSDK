using System;
using System.Collections.Generic;
using System.Text;

namespace URSdk
{
    /// <summary>
    /// 暴漏的方法
    /// </summary>
   public class SdkMethodAttribute : Attribute
    {
        public int Index { set; get; } 
        public string Des { set; get; }
        public SdkMethodAttribute(int index,string des)
        {
            this.Index = index;
            this.Des = des;
        }
    }
}
