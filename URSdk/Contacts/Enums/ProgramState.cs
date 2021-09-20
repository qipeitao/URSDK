using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace URSdk
{
   public enum ProgramState:int
    {
        [Description("停止")]
        Stopped = 1,
        [Description("运行")]
        Running = 2,
    }
}
