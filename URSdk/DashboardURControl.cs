using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks; 

namespace URSdk
{
    /// <summary>
    /// Dashboard 接口是由机器人人机界面进程（示教器显示）负责维护和执行的一个端
    /// 口。该端口主要负责接收上位机指令， 执行 机器人 初始化 、 加载程序、 开始和 暂停程序
    /// 运行 以及 设置用户角色等操作，上位机可以远程操作机器人就如同操作示教器一样。
    /// 该接口主要应用在自动启动机器人，无示教器应用（无示教器情况下如何设置 UR 机器
    /// 人请参考无示教器设置）等场合。
    /// /// Dashboard 接口接收上位机发送的 Dashboard 命令字符串，机器人接收后，返回 执行结果字符串。
    /// </summary>
    public class DashboardURControl : URControl
    {
        public const int WaitSocketRecvBackTime = 200; 
        public DashboardURControl(string ip):base(ip, PortType.Dashboard)
        {
           
        }
        /// <summary>
        ///V1.4 Loads the  specified  program
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        [SdkMethod(0,"加载程序")]
        public Boolean Load(string program)
        {
            if (string.IsNullOrEmpty(program)) return false;
            string result = string.Empty;
            if (!SendCommand(string.Format("{0} {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, program), ref result))
            {
                return false;
            }
            if (result.StartsWith("loading program:"))
            {
                return true;
            }
            else
            {
                return false;
            } 
        }
        /// <summary>
        ///V1.4 Starts program,if any program is loaded and robot is ready
        /// </summary>
        /// <returns></returns>
        [SdkMethod(1,"运行已加载的程序")]
        public Boolean Play()
        {
            string result = string.Empty;
            if (!SendCommand(string.Format("{0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ref result))
            {
                return false;
            }
            if (result.StartsWith("starting program"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// V1.4 Stops running program
        /// </summary>
        /// <returns></returns>
        [SdkMethod(2, "停止已运行的程序")]
        public Boolean Stop()
        {
            string result = string.Empty;
            if (!SendCommand(string.Format("{0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ref result))
            {
                return false;
            }
            if (result.StartsWith("stopped"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///V1.4 Pauses the running program
        /// </summary>
        /// <returns></returns>
        [SdkMethod(3, "暂停已运行的程序")]
        public Boolean Pause()
        {
            string result = string.Empty;
            if (!SendCommand(string.Format("{0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ref result))
            {
                return false;
            }
            if (result.StartsWith("pausing program"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// V1.4 Closes connection
        /// </summary>
        /// <returns></returns>
        [SdkMethod(4, "退出连接")]
        public Boolean Quit()
        {
            string result = string.Empty;
            if (!SendCommand(string.Format("{0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ref result))
            {
                return false;
            }
            if (result.StartsWith("disconnected"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// V1.4 Shuts down and turns off robot and controller
        /// </summary>
        /// <returns></returns>
        [SdkMethod(5, "关闭机器人")]
        public Boolean Shutdown()
        {
            string result = string.Empty;
            if (!SendCommand(string.Format("{0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ref result))
            {
                return false;
            }
            if (result.StartsWith("shutting down"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// V1.6 Execution state
        /// </summary>
        /// <returns></returns>
        [SdkMethod(6, "运行状态")]
        public Boolean Running()
        {
            string result = string.Empty;
            if (!SendCommand(string.Format("{0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ref result))
            {
                return false;
            }
            if (result.EndsWith("true"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// V1.6 Robot mode enquiry
        /// </summary>
        /// <returns></returns>
        [SdkMethod(7, "机器人状态")]
        public RobotmodeType Robotmode()
        {
            string result = string.Empty;
            if (!SendCommand(string.Format("{0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ref result))
            {
                return RobotmodeType.NO_CONTROLLER;
            } 
            if (Enum.TryParse<RobotmodeType>(result.Split(':')[1], true,out RobotmodeType type))
            {
                return type;
            }
            else
            {
                return RobotmodeType.POWER_OFF;
            }
        }
        /// <summary>
        ///V1.6 Which program is loaded
        /// </summary>
        /// <returns></returns>
        [SdkMethod(8, "获取加载的程序")]
        public string Get_Loaded_Program()
        {
            string result = string.Empty;
            if (!SendCommand(string.Format("{0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ref result))
            {
                return null;
            }
            if (result.StartsWith("program loaded"))
            {
                return result.Split(':').Last();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// V1.6
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [SdkMethod(9, "弹窗")]
        public Boolean Popup(string str)
        {
            string result = string.Empty;
            if (!SendCommand(string.Format("{0} {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,str), ref result))
            {
                return false;
            }
            if (result.StartsWith("showing popup"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// V1.6
        /// </summary>
        /// <returns></returns>
        [SdkMethod(10, "关闭弹窗")]
        public Boolean Close_Popup()
        {
            string result = string.Empty;
            if (!SendCommand(string.Format("{0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ref result))
            {
                return false;
            }
            if (result.StartsWith("closing popup"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// V1.8.11657 Adds log- message to the Log history
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        [SdkMethod(11, "添加日志")]
        public Boolean AddToLog(string log)
        {
            string result = string.Empty;
            if (!SendCommand(string.Format("{0} {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,log), ref result))
            {
                return false;
            }
            if (result.StartsWith("added log message"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///v1.8.11997 Returns the state of the active
        /// </summary>
        /// <returns></returns>
        [SdkMethod(12, "程序状态")]
        public Boolean ProgramState()
        {
            string result = string.Empty;
            if (!SendCommand(string.Format("{0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ref result))
            {
                return false;
            }
            if (result.StartsWith("playing"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// V3.0 Powers on the robot arm
        /// </summary>
        /// <returns></returns>
        [SdkMethod(13, "上电")]
        public Boolean Power_On()
        {
            string result = string.Empty;
            if (!SendCommand(string.Format("{0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ref result))
            {
                return false;
            }
            if (result.StartsWith("powering on"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [SdkMethod(14, "下电")]
        public Boolean Power_OFF()
        {
            string result = string.Empty;
            if (!SendCommand(string.Format("{0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ref result))
            {
                return false;
            }
            if (result.StartsWith("powering off"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// V3.0
        /// </summary>
        /// <returns></returns>
        [SdkMethod(15, "松闸")]
        public Boolean Brake_Release()
        {
            string result = string.Empty;
            if (!SendCommand(string.Format("{0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ref result))
            {
                return false;
            }
            if (result.StartsWith("brake releasing"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [SdkMethod(16, "安全状态")]
        public SafetyMode Safetymode()
        {
            string result = string.Empty;
            if (!SendCommand(string.Format("{0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ref result))
            {
                return SafetyMode.SAFETY_MODE_FAULT;
            }
            if (Enum.TryParse<SafetyMode>(result.Split(':')[1], true, out SafetyMode type))
            {
                return type;
            }
            else
            {
                return SafetyMode.SAFETY_MODE_FAULT;
            }
        }
        /// <summary>
        /// V3.1 Closes the current popup and unlocks protective stop
        /// </summary>
        /// <returns></returns>
        [SdkMethod(17, "解锁保护停止")]
        public Boolean Unlock_Protective_Stop()
        {
            string result = string.Empty;
            if (!SendCommand(string.Format("{0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ref result))
            {
                return false;
            }
            if (result.StartsWith("protective stop releasing"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        ///V3.1 Closes a safety popup
        /// </summary>
        /// <returns></returns>
        [SdkMethod(18, "关闭安全弹窗")]
        public Boolean Close_Safety_Popup()
        {
            string result = string.Empty;
            if (!SendCommand(string.Format("{0}", System.Reflection.MethodBase.GetCurrentMethod().Name), ref result))
            {
                return false;
            }
            if (result.StartsWith("closing safety popup"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="command"></param>
        /// <param name="value">小写</param>
        /// <returns></returns>
        private Boolean SendCommand(string command,ref string value)
        { 
            Value = null;
            try
            {
                command = command.ToLower().Replace("_", " ");
                if (!SendScript(command))
                {
                    return false;
                }
                Thread.Sleep(WaitSocketRecvBackTime);
                value = Value?.ToString().ToLower();
                if (string.IsNullOrEmpty(value))
                {
                    return false;
                } 
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                Value = null; 
            }
        }
         
        public override object OnRecvBuf(byte[] buf)
        { 
            if(buf == null)
            {
                return null;
            }
            var str = Encoding.ASCII.GetString(buf).Trim('\n');
            Console.WriteLine("RecvFrom: " + str);
            return str; 
        } 

    }
}
