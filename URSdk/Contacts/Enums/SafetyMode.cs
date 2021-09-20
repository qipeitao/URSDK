using System;
using System.Collections.Generic;
using System.Text;

namespace URSdk
{
    public enum SafetyMode : int
    {
        SAFETY_MODE_NORMAL = 1,
        SAFETY_MODE_REDUCED,
        SAFETY_MODE_PROTECTIVE_STOP,
        SAFETY_MODE_RECOVERY,
        SAFETY_MODE_SAFEGUARD_STOP,
        SAFETY_MODE_SYSTEM_EMERGENCY_STOP,
        SAFETY_MODE_ROBOT_EMERGENCY_STOP,
        SAFETY_MODE_VIOLATION,
        SAFETY_MODE_FAULT,
        SAFETY_MODE_VALIDATE_JOINT_ID=10,
        SAFETY_MODE_UNDEFINED_SAFETY_MODE 
    }
}
