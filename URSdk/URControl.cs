using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using URSdk;

namespace URSdk
{
    public class URControl
    {
        private object valuev;
        public object Value { set { valuev = value;
                //Console.WriteLine("value set:"+value);
            } get => valuev; }
        protected Socket socket;
        protected string ip;
        protected PortType portType;

        public URControl(string ip,PortType portType)
        {
            this.ip = ip;
            this.portType = portType;
        }
        public Boolean IsStart { set; get; } = false;
        public void StartSocket()
        {
            StopSocket();
            IsStart = true; 
            Task.Run(() =>
            {
                while (IsStart)
                {
                    try
                    {
                        socket = new Socket(SocketType.Stream, ProtocolType.IP);
                        socket.Connect(ip, (int)portType);
                        byte[] buf = new byte[65535];
                        while(socket!=null&&socket.Connected)
                        {
                            int n = socket.Receive(buf);
                            if (n != 0)
                            { 
                               Value= OnRecvBuf(buf.Take(n).ToArray()); 
                            }
                        } 
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    finally
                    {
                        if (socket!=null&&socket.Connected)
                        {
                            socket.Close();
                            socket.Dispose();
                        }
                        socket = null;
                    }
                }
            }); 
        } 
        public virtual object OnRecvBuf(byte[] buf)
        {
            return null;
        }
        /// <summary>
        /// 发送脚本，必须以\n 结尾
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public virtual Boolean SendScript(string script)
        {
            try
            {
                script = script.Trim();
               // Console.WriteLine("SendTo: " + script);
                if(!script.EndsWith("\n"))
                {
                    script += "\n";
                } 
                byte[] bufs = Encoding.ASCII.GetBytes(script); 
                socket.Send(bufs);
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public void StopSocket()
        {
            IsStart = false;
            if (socket!=null&&socket.Connected)
            {
                socket.Close(); 
            }
            socket = null;
        }
    }
}
