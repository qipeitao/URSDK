using System;
using System.Collections.Generic;
using System.Text;

namespace URSdk
{
   public enum RobotMessageType:int
    {
        SafetyMode=5,
        ErrorCode=6,
        Key=7,
        ProgramLabelThreads=14,
        Popup=2,
        RequestValue=9,
        Text=0,
        RuntimeException=10,
       // VariableUpdate=2,
        GlobalVariablesUpdate=1,
    }
}
