using System;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using URSdk; 

namespace URSdk
{
    public class RealtimeURControl : URControl
    { 
        public RealtimeURControl(string ip):base(ip, PortType.Realtime)
        {
           
        }  
        public override object OnRecvBuf(byte[] buf)
        {
            if (buf == null || buf.Length < 4||buf.Length<1060) return null;
            //计算长度 
           var s= RealtimeModel.Parse(buf);
            if(s==null)
            {
                return null;
            } 
            //Console.WriteLine("Actual_TCP_Pose:" + s.Actual_TCP_Pose.ToString());
            //Console.WriteLine("IsMoving:" + s.IsMoving()); 
           // Console.WriteLine("Q_Actual:" + s.Actual_Joint_Positions.ToString());
           //// Console.WriteLine("Actual_Joint_Current:" + s.Actual_Joint_Current.ToString());
           // Console.WriteLine("Actual_TCP_Pose:" + s.Actual_TCP_Pose.ToString());
            //Console.WriteLine("TCP_Force:" + s.TCP_Force.ToString());
            //Console.WriteLine("Motor_Temperatures:" + s.Motor_Temperatures.ToString());
            return s;
        }  
    }
}
