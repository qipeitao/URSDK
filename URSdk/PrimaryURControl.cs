using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;  

namespace URSdk
{  
    /// <summary>
    /// 接口由机器人控制进程维护和执行的端口
    /// </summary>
    public class PrimaryURControl : URControl
    {
        public RobotMessage RobotMessage { private set; get; } = new RobotMessage();
        public RobotStateMessage RobotStateMessage { private set; get; } = new RobotStateMessage();

        public Vector TCPVector
        {
            get
            {
                return Vector.Parse(new double[]{RobotStateMessage.CartesianInfo.X,
                    RobotStateMessage.CartesianInfo.Y,
                    RobotStateMessage.CartesianInfo.Z,
                    RobotStateMessage.CartesianInfo.RX,
                    RobotStateMessage.CartesianInfo.RY, RobotStateMessage.CartesianInfo.RZ });
            }
        }
        public Vector TCPJointVector
        {
            get
            {
                if (RobotStateMessage == null|| RobotStateMessage.JointData==null|| RobotStateMessage.JointData.JointDataEach1==null)
                {
                    return null; 
                }
                return Vector.Parse(new double[]{RobotStateMessage.JointData.JointDataEach1.q_actual,
                    RobotStateMessage.JointData.JointDataEach2.q_actual,
                    RobotStateMessage.JointData.JointDataEach3.q_actual,
                    RobotStateMessage.JointData.JointDataEach4.q_actual,
                    RobotStateMessage.JointData.JointDataEach5.q_actual,
                    RobotStateMessage.JointData.JointDataEach6.q_actual });
            }
        } 
        public Boolean IsMove
        {
            get
            {
                return RobotStateMessage.RobotModeData.isProgramRunning;
            }
        }
        public SafetyMode SafetyMode
        {
            get
            {
                return RobotStateMessage.MasterboardData.safetyMode;
            }
        }
        public RobotMode RobotMode
        {
            get
            {
                return RobotStateMessage.RobotModeData.robotMode;
            }
        }
      
        public const int WaitSocketRecvBackTime = 200; 
        public PrimaryURControl(string ip):base(ip, PortType.Primary)
        {
           
        } 
        public Boolean SendScripts(List<string> scripts)
        {
            if(scripts==null || scripts.Count==0)
            {
                return true;
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("def functionName():");
            scripts.ForEach(p =>
            {
                sb.AppendLine(" "+p);
            });
            sb.AppendLine("end");
           return SendScript(sb.ToString());
        }

        public override object OnRecvBuf(byte[] buf)
        {
          var length=  UTools.GetLongValue(buf.Take(4).ToArray()); 
            //Console.WriteLine($"RecvFrom:{buf.Length} -{length}-{buf[4]}");
            RobotMessage.Prase(buf);
             RobotStateMessage.Prase(buf);
           //RobotStateMessage.Printf();
            return null;
        }

    }
}
