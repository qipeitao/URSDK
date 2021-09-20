using System;
using System.Collections.Generic;
using System.Text; 

namespace URSdk
{
   public class URSDKHelper
    {
        public string Ip {private set; get; }

        public PrimaryURControl PrimaryURControl { private set; get; }
       // public RealtimeURControl RealtimeURControl { private set; get; }
        public DashboardURControl DashboardURControl { private set; get; }

        public Vector TCPVector
        {
            get
            {
                if(!PrimaryURControl.IsStart)
                {
                    return null;
                }
                else
                {
                    return PrimaryURControl.TCPVector;
                } 
            }
        }
        public Vector TCPJointVector
        {
            get
            {
                if (!PrimaryURControl.IsStart)
                {
                    return null;
                }
                else
                {
                    return PrimaryURControl.TCPJointVector;
                }
            }
        }
        public Boolean IsMove
        {
            get
            {
                if (!PrimaryURControl.IsStart)
                {
                    return false;
                }
                else
                {
                    return PrimaryURControl.IsMove;
                }
            }
        }
        public SafetyMode SafetyMode
        {
            get
            {
                if (!PrimaryURControl.IsStart)
                {
                    return SafetyMode.SAFETY_MODE_FAULT;
                }
                else
                {
                    return PrimaryURControl.SafetyMode;
                }
            }
        }
        public RobotMode RobotMode
        {
            get
            {
                if (!PrimaryURControl.IsStart)
                {
                    return RobotMode.ROBOT_MODE_DISCONNECTED;
                }
                else
                {
                    return PrimaryURControl.RobotMode;
                }
            }
        }
       
        public Boolean IsConnected
        {
            get
            {
                if(PrimaryURControl!=null&& PrimaryURControl.IsStart&& DashboardURControl!=null&& DashboardURControl.IsStart)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public URSDKHelper(string ip)
        {
            Ip = ip;
            PrimaryURControl = new PrimaryURControl(ip);
           // RealtimeURControl = new RealtimeURControl(ip);
            DashboardURControl = new DashboardURControl(ip);
        }
        public void Start()
        {
            PrimaryURControl.StartSocket();
            //RealtimeURControl.StartSocket();
            DashboardURControl.StartSocket();
        }
         
        public void Stop()
        {
            PrimaryURControl.StopSocket();
            //RealtimeURControl.StopSocket();
            DashboardURControl.StopSocket();
        }

        public Boolean SendScript(string script)
        {
            return PrimaryURControl.SendScript(script);
        }
        public Boolean SendScripts(List<string> scripts)
        {
            return PrimaryURControl.SendScripts(scripts);
        }
    }
}
