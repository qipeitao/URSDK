using System;
using System.Collections.Generic;
using System.Text;

namespace URSdk
{
   public enum PackageType:int
    {
        RobotModeData = 0,
        JointData = 1,
        TooData = 2,
        MasterboardData = 3,
        CartesianInfo = 4,
        KinematicsInfo = 5,
        ConfigurationData = 6,
        ForceModeData = 7,
        AdditionalInfo = 8,
        CalibrationData = 9,
        SafetyData = 10,
        ToolCommunicationInfo = 11,
        ToolModeInfo = 12,
        SingularityInfo = 13,
    }
}
