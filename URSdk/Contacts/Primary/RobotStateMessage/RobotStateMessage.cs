using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using URSdk;

namespace URSdk
{
    #region RobotStateMessage

    public class RobotModeData : SubMessageItem
    {
        public RobotModeData()
        {
            PackageType = PackageType.RobotModeData;
        }
        //[SdkCheck(5,8)]
        //public long timestamp { set; get; }
        [SdkCheck(8, 1)]
        public bool isRealRobotConnected { set; get; }
        [SdkCheck(9, 1)]
        public bool isRealRobotEnabled { set; get; }
        [SdkCheck(10, 1)]
        public bool isRobotPowerOn { set; get; }
        [SdkCheck(11, 1)]
        public bool isEmergencyStopped { set; get; }
        [SdkCheck(12, 1)]
        public bool isProtectiveStopped { set; get; }
        [SdkCheck(13, 1)]
        public bool isProgramRunning { set; get; }
        [SdkCheck(14, 1)]
        public bool isProgramPaused { set; get; }
        [SdkCheck(15, 1)]
        public RobotMode robotMode { set; get; }
        [SdkCheck(16, 1)]
        public ControlMode controlMode { set; get; }
        [SdkCheck(17, 8)]
        public double targetSpeedFraction { set; get; }
        [SdkCheck(25, 8)]
        public double speedScaling { set; get; }
        [SdkCheck(33, 8)]
        public double targetSpeedFractionLimit { set; get; }
        [SdkCheck(41, 1)]
        public byte reserved { set; get; }

    }
    public class JointDataEach : SubMessageItem
    {
        [SdkCheck(0, 8)]
        public double q_actual { set; get; }
        [SdkCheck(8, 8)]
        public double q_target { set; get; }
        [SdkCheck(16, 8)]
        public double qd_actual { set; get; }
        [SdkCheck(24, 4)]
        public float I_actual { set; get; }
        [SdkCheck(28, 4)]
        public float V_actual { set; get; }
        [SdkCheck(32, 4)]
        public float T_motor { set; get; }
        [SdkCheck(36, 4)]
        public float T_micro { set; get; }
        [SdkCheck(40, 1)]
        public JointMode JointMode { set; get; }
    }
    public class JointData : SubMessageItem
    {
        public JointData()
        {
            PackageType = PackageType.JointData;
        }
        [SdkCheck(0, 41)]
        public JointDataEach JointDataEach1 { set; get; }
        [SdkCheck(41, 41)]
        public JointDataEach JointDataEach2 { set; get; }
        [SdkCheck(82, 41)]
        public JointDataEach JointDataEach3 { set; get; }
        [SdkCheck(123, 41)]
        public JointDataEach JointDataEach4 { set; get; }
        [SdkCheck(164, 41)]
        public JointDataEach JointDataEach5 { set; get; }
        [SdkCheck(205, 41)]
        public JointDataEach JointDataEach6 { set; get; }
    }
    public class CartesianInfo : SubMessageItem
    {
        public CartesianInfo()
        {
            PackageType = PackageType.CartesianInfo;
        }
        [SdkCheck(0, 8)]
        public double X { set; get; }
        [SdkCheck(8, 8)]
        public double Y { set; get; }
        [SdkCheck(16, 8)]
        public double Z { set; get; }
        [SdkCheck(24, 8)]
        public double RX { set; get; }
        [SdkCheck(32, 8)]
        public double RY { set; get; }
        [SdkCheck(40, 8)]
        public double RZ { set; get; }
        [SdkCheck(48, 8)]
        public double TCPOffsetX { set; get; }
        [SdkCheck(56, 8)]
        public double TCPOffsetY { set; get; }
        [SdkCheck(64, 8)]
        public double TCPOffsetZ { set; get; }
        [SdkCheck(72, 8)]
        public double TCPOffsetRX { set; get; }
        [SdkCheck(80, 8)]
        public double TCPOffsetRY { set; get; }
        [SdkCheck(88, 8)]
        public double TCPOffsetRZ { set; get; }
    }
    public class ForceModeData : SubMessageItem
    {
        public ForceModeData()
        {
            PackageType = PackageType.ForceModeData;
        }
        [SdkCheck(0, 8)]
        public double FX { set; get; }
        [SdkCheck(8, 8)]
        public double FY { set; get; }
        [SdkCheck(16, 8)]
        public double FZ { set; get; }
        [SdkCheck(24, 8)]
        public double FRX { set; get; }
        [SdkCheck(32, 8)]
        public double FRY { set; get; }
        [SdkCheck(40, 8)]
        public double FRZ { set; get; }
    }
    public class CalibrationData : SubMessageItem
    {
        public CalibrationData()
        {
            PackageType = PackageType.CalibrationData;
        }
        [SdkCheck(0, 8)]
        public double X { set; get; }
        [SdkCheck(8, 8)]
        public double Y { set; get; }
        [SdkCheck(16, 8)]
        public double Z { set; get; }
        [SdkCheck(24, 8)]
        public double RX { set; get; }
        [SdkCheck(32, 8)]
        public double RY { set; get; }
        [SdkCheck(40, 8)]
        public double RZ { set; get; }
    }
    public class MasterboardData : SubMessageItem
    {
        public MasterboardData()
        {
            PackageType = PackageType.MasterboardData;
        }
        [SdkCheck(0, 4)]
        public int digitalInputBits { set; get; }
        [SdkCheck(4, 4)]
        public int digitalOutputBits { set; get; }

        [SdkCheck(8, 1)]
        public byte analogInputRange0 { set; get; }
        [SdkCheck(9, 1)]
        public byte analogInputRange1 { set; get; }

        [SdkCheck(10, 8)]
        public double analogInput0 { set; get; }
        [SdkCheck(18, 8)]
        public double analogInput1 { set; get; }
        [SdkCheck(26, 1)]
        public byte analogOutputDomain0 { set; get; }
        [SdkCheck(27, 1)]
        public byte analogOutputDomain1 { set; get; }


        [SdkCheck(28, 8)]
        public double analogOutput0 { set; get; }
        [SdkCheck(36, 8)]
        public double analogOutput1 { set; get; }

        [SdkCheck(44, 4)]
        public float masterBoardTemperature { set; get; }
        [SdkCheck(48, 4)]
        public float robotVoltage48V { set; get; }
        [SdkCheck(52, 4)]
        public float robotCurrent { set; get; }
        [SdkCheck(56, 4)]
        public float masterIOCurrent { set; get; }
        [SdkCheck(60, 1)]
        public SafetyMode safetyMode { set; get; }


    }
    #endregion
    #region RobotMessage
    public class RobotMessage : Message
    {
        [SdkMethod((int)RobotMessageType.SafetyMode, "安全模式数据")]
        public SafetyModeMessage SafetyModeMessage { set; get; } = new SafetyModeMessage();

        [SdkMethod((int)RobotMessageType.ErrorCode, "错误信息数据")]
        public RobotCommMessage RobotCommMessage { set; get; } = new RobotCommMessage();


        [SdkMethod((int)RobotMessageType.RequestValue, "错误信息数据")]
        public RequestValueMessage RequestValueMessage { set; get; } = new RequestValueMessage();

        private Dictionary<byte, PropertyInfo> packs = null;
        public RobotMessage() : base()
        {
            MessageType = MessageType.RobotMessage;
            packs = this.GetType().GetProperties().Where(p => p.GetCustomAttribute<SdkMethodAttribute>() != null)
                .ToDictionary(p => (byte)p.GetCustomAttribute<SdkMethodAttribute>().Index, p => p);

        }
        public override void Prase(byte[] buf)
        {
            if (buf[4] != (byte)MessageType) return;
            var size = (int)UTools.GetLongValue(buf.Take(4).ToArray());
            var type = buf[15];
            if (!packs.ContainsKey(type))
            {
                return;
            }
            var v = packs[type].GetValue(this) as SubMessageItem;
            var sub = v.Prase(buf.Skip(15).Take(size - 15).ToArray());
            packs[type].SetValue(this, sub);
        }
    }
    public class SafetyModeMessage : SubMessageItem
    {
        public SafetyModeMessage()
        {
            RobotMessageType = RobotMessageType.SafetyMode;
        }
        [SdkCheck(0, 4)]
        public int robotMessageCode { set; get; }
        [SdkCheck(4, 4)]
        public int robotMessageArgument { set; get; }
        [SdkCheck(8, 1)]
        public SafetyMode safetyModeType { set; get; }
        [SdkCheck(9, 4)]
        public int reportDataType { set; get; }
        [SdkCheck(13, 4)]
        public int reportData { set; get; }

    }
    public class RobotCommMessage : SubMessageItem
    {
        public RobotCommMessage()
        {
            RobotMessageType = RobotMessageType.ErrorCode;
        }
        [SdkCheck(0, 4)]
        public int robotMessageCode { set; get; }
        [SdkCheck(4, 4)]
        public int robotMessageArgument { set; get; }
        [SdkCheck(8, 1)]
        public SafetyMode robotMessageReportLevel { set; get; }
        [SdkCheck(9, 4)]
        public int robotMessageDataType { set; get; }
        [SdkCheck(13, 4)]
        public int robotMessageData { set; get; }
        [SdkCheck(17, -1, isStr: true)]
        public string Msg { set; get; }

    }
    public class RequestValueMessage : SubMessageItem
    {
        public RequestValueMessage()
        {
            RobotMessageType = RobotMessageType.RequestValue;
        }
        [SdkCheck(0, 4)]
        public int RequestId { set; get; }
        [SdkCheck(4, 1)]
        public int RequestType { set; get; }
        [SdkCheck(5, -1, isStr: true)]
        public string Msg { set; get; }

    }
    #endregion
    public class RobotStateMessage : Message
    {
        [SdkMethod((int)PackageType.RobotModeData, "状态数据")]
        public RobotModeData RobotModeData { set; get; } = new RobotModeData();
        [SdkMethod((int)PackageType.JointData, "关节数据")]
        public JointData JointData { set; get; } = new JointData();
        [SdkMethod((int)PackageType.CartesianInfo, "迪卡尔坐标")]
        public CartesianInfo CartesianInfo { set; get; } = new CartesianInfo();

        [SdkMethod((int)PackageType.ForceModeData, "力量模式数据")]
        public ForceModeData ForceModeData { set; get; } = new ForceModeData();

        [SdkMethod((int)PackageType.CalibrationData, "迪卡尔坐标")]
        public CalibrationData CalibrationData { set; get; } = new CalibrationData();

        [SdkMethod((int)PackageType.MasterboardData, "Masterboard")]
        public MasterboardData MasterboardData { set; get; } = new MasterboardData();

        private Dictionary<byte, PropertyInfo> packs = null;

        public RobotStateMessage() : base()
        {
            MessageType = MessageType.RobotState;
            packs = this.GetType().GetProperties().Where(p => p.GetCustomAttribute<SdkMethodAttribute>() != null)
                .ToDictionary(p => (byte)p.GetCustomAttribute<SdkMethodAttribute>().Index, p => p);

        }
        public override void Prase(byte[] buf)
        {

            if (buf[4] != (byte)MessageType) return;
            var size = (int)UTools.GetLongValue(buf.Take(4).ToArray());
            if (size != buf.Length) return;
            int index = 5;
            while (index < (buf.Length - 1) && (buf.Length - index) > 5)
            {
                index += check(buf.Skip(index).ToArray(), out SubMessageItem sub);
                if (sub != null)
                {
                    packs[(byte)sub.PackageType].SetValue(this, sub);
                }
            }
        }
        private int check(byte[] buf, out SubMessageItem sub)
        {
            var size = (int)UTools.GetLongValue(buf.Take(4).ToArray());
            if (buf.Length < size)
            {
                sub = null;
                return buf.Length;
            }
            if (!packs.ContainsKey(buf[4]))
            {
                sub = null;
                return buf.Length;
            }
            var v = packs[buf[4]].GetValue(this) as SubMessageItem;
            sub = v.Prase(buf.Skip(5).Take(size).ToArray());
            return size;
        }

        public void Printf()
        {
            if (JointData != null && JointData.JointDataEach1 != null)
            {
                //var p = 180/Math.PI;
                //Console.WriteLine($"JointData:{JointData.JointDataEach1.q_actual*p},{JointData.JointDataEach2.q_actual * p},{JointData.JointDataEach3.q_actual * p},{JointData.JointDataEach4.q_actual * p},{JointData.JointDataEach5.q_actual * p},{JointData.JointDataEach6.q_actual * p}");
                // Console.WriteLine($"JointData:{JointData.JointDataEach1.qd_actual * p},{JointData.JointDataEach2.qd_actual * p},{JointData.JointDataEach3.qd_actual * p},{JointData.JointDataEach4.qd_actual * p},{JointData.JointDataEach5.qd_actual * p},{JointData.JointDataEach6.qd_actual * p}");
            }
            //if (CalibrationData != null)
            //{ 
            //    Console.WriteLine($"CalibrationData:{CalibrationData.X},{CalibrationData.Y},{CalibrationData.Z},{CalibrationData.RX},{CalibrationData.RY},{CalibrationData.RZ}");
            //    //Console.WriteLine($"CalibrationData:{CalibrationData.JointDataEach1.qd_actual * p},{JointData.JointDataEach2.qd_actual * p},{JointData.JointDataEach3.qd_actual * p},{JointData.JointDataEach4.qd_actual * p},{JointData.JointDataEach5.qd_actual * p},{JointData.JointDataEach6.qd_actual * p}");
            //}
            if (CartesianInfo != null)
            {
                //Console.WriteLine($"CartesianInfo:{Math.Round( CartesianInfo.X,5)},{Math.Round(CartesianInfo.Y, 5)},{Math.Round(CartesianInfo.Z, 5)},{Math.Round(CartesianInfo.RX, 5)},{Math.Round(CartesianInfo.RY, 5)},{Math.Round(CartesianInfo.RZ,5)}");
                //Console.WriteLine($"CalibrationData:{CalibrationData.JointDataEach1.qd_actual * p},{JointData.JointDataEach2.qd_actual * p},{JointData.JointDataEach3.qd_actual * p},{JointData.JointDataEach4.qd_actual * p},{JointData.JointDataEach5.qd_actual * p},{JointData.JointDataEach6.qd_actual * p}");
            }
            if (RobotModeData != null)
            {
                Console.WriteLine($"enabled:{RobotModeData.isRealRobotEnabled} run:{RobotModeData.isProgramRunning} controlMode:{RobotModeData.controlMode} safemode:{MasterboardData.safetyMode}");
            }

        }
    }
}
