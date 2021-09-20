using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace URSdk
{
    public enum JointMode : int
    {
        JOINT_MODE_RESET = 235,
        JOINT_MODE_SHUTTING_DOWN,
        JOINT_PART_D_CALIBRATION_MODE = 237,
        JOINT_MODE_BACKDRIVE = 238,
        JOINT_MODE_POWER_OFF = 239,
        JOINT_MODE_READY_FOR_POWER_OFF = 240,
        JOINT_MODE_NOT_RESPONDING = 245,
        JOINT_MODE_MOTOR_INITIALISATION,
        JOINT_MODE_BOOTING,
        JOINT_PART_D_CALIBRATION_ERROR_MODE = 248,
        JOINT_MODE_BOOTLOADER,
        JOINT_CALIBRATION_MODE,
        JOINT_MODE_VIOLATION = 251,
        JOINT_MODE_FAULT,
        JOINT_MODE_RUNNING = 253,
        JOINT_MODE_IDLE,
    }
    public enum ToolMode : int
    {
        JOINT_MODE_RESET = 235,
        JOINT_MODE_SHUTTING_DOWN,
        JOINT_MODE_POWER_OFF = 239,
        JOINT_MODE_NOT_RESPONDING = 245,
        JOINT_MODE_BOOTING = 247,
        JOINT_MODE_BOOTLOADER = 249,
        JOINT_MODE_FAULT = 252,
        JOINT_MODE_RUNNING = 253,
        JOINT_MODE_IDLE = 255,
    }
    public enum RobotMode : int
    {
        ROBOT_MODE_DISCONNECTED=-1,
        ROBOT_MODE_CONFIRM_SAFETY,
        ROBOT_MODE_BOOTING,
        ROBOT_MODE_POWER_OFF,
        ROBOT_MODE_POWER_ON,
        ROBOT_MODE_IDLE,
        ROBOT_MODE_BACKDRIVE,
        ROBOT_MODE_RUNNING,
        ROBOT_MODE_UPDATING_FIRMWARE,
    }
    public enum ControlMode : int
    {
        CONTROL_MODE_POSITION,
        CONTROL_MODE_TEACH,
        CONTROL_MODE_FORCE,
        CONTROL_MODE_TORQUE,

    }
    [Description("机器人模式")]
    public enum RobotmodeType : int
    {
        [Description("NO_CONTROLLER")]
        NO_CONTROLLER,
        [Description("未连接")]
        DISCONNECTED ,
        [Description("安全保护")]
        CONFIRM_SAFETY,
        [Description("引导")]
        BOOTING ,
        [Description("断电")]
        POWER_OFF,
        [Description("上电")]
        POWER_ON , 
        [Description("等待")]
        IDLE,
        [Description("BACKDRIVE")]
        BACKDRIVE,
        [Description("运行")]
        RUNNING,
    }
}
