using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using URSdk;

namespace URSdk
{
    /// <summary>
    /// 
    /// </summary>
    public class RealtimeModel
    {
        /// <summary>
        /// 块长度
        /// </summary>
        [SdkCheck(0, 4,1)]
        public int MessageSize { set; get; }
        /// <summary>
        /// Time elapsed since the controller was started
        /// </summary>
        [SdkCheck(4, 8)]
        public double Time { set; get; }

        /// <summary>
        /// Target joint positions
        /// 目标位置
        /// </summary>
        [SdkCheck(12, 48, 6)]
        public Vector Target_Joint_Position { set; get; }
        /// <summary>
        /// Target joint velocities
        /// 目标角度 速度
        /// </summary>
        [SdkCheck(60, 48, 6)]
        public Vector Target_Joint_Velocitie { set; get; }

        /// <summary>
        /// Target joint accelerations
        /// </summary>
        [SdkCheck(108, 48, 6)]
        public Vector QDD_Target { set; get; }

        /// <summary>
        /// Target joint currents
        /// </summary>
        [SdkCheck(156, 48, 6)]
        public Vector I_Target { set; get; }

        /// <summary>
        /// Target joint moments (torques)
        /// </summary>
        [SdkCheck(204, 48, 6)]
        public Vector M_Target { set; get; }

        /// <summary>
        /// Actual joint positions
        /// 当前位置
        /// </summary>
        [SdkCheck(252, 48, 6)]
        public Vector Actual_Joint_Positions { set; get; }

        /// <summary>
        /// Actual joint velocities
        /// 当前角度 速度
        /// </summary>
        [SdkCheck(300, 48, 6)]
        public Vector Actual_Joint_Velocitie { set; get; }

        /// <summary>
        /// Actual joint currents
        /// </summary>
        [SdkCheck(348, 48, 6)]
        public Vector Actual_Joint_Current { set; get; }

        /// <summary>
        /// Joint control currents
        /// </summary>
        [SdkCheck(396, 48, 6)]
        public Vector I_Control { set; get; }

        /// <summary>
        /// Actual Cartesian coordinates of the tool: (x,y,z,rx,ry,rz),
        /// where rx, ry and rz is a rotation vector representation of 
        /// the tool orientation
        /// </summary>
        [SdkCheck(444, 48, 6)]
        public Vector Actual_TCP_Pose { set; get; }

        /// <summary>
        /// Actual speed of the tool given in Cartesian coordinates
        /// </summary>
        [SdkCheck(492, 48, 6)]
        public Vector TCP_Speed_Actual { set; get; }

        /// <summary>
        /// Generalised forces in the TCP
        /// </summary>
        [SdkCheck(540, 48, 6)]
        public Vector TCP_Force { set; get; }

        /// <summary>
        /// Target Cartesian coordinates of the tool: (x,y,z,rx,ry,rz),
        /// where rx, ry and rz is a rotation vector representation of the tool orientation
        /// </summary>
        [SdkCheck(588, 48, 6)]
        public Vector Tool_Vector_Target { set; get; }

        /// <summary>
        /// Target speed of the tool given in Cartesian coordinates
        /// </summary>
        [SdkCheck(636, 48, 6)]
        public Vector TCP_Speed_Target { set; get; }

        /// <summary>
        /// Current state of the digital inputs. 
        /// NOTE: these are bits encoded as int64_t, 
        /// e.g. a value of 5 corresponds to bit 0 and bit 2 set high
        /// </summary>

        [SdkCheck(684, 8, 1)]
        public double Digital_Input_Bits { set; get; }

        /// <summary>
        /// Temperature of each joint in degrees celsius
        /// 各个关节温度
        /// </summary>
        [SdkCheck(692, 48, 6)]
        public Vector Motor_Temperatures { set; get; }

        /// <summary>
        /// Controller realtime thread execution time
        /// </summary>
        [SdkCheck(740, 8, 1)]
        public double Controller_Timer { set; get; }

        /// <summary>
        /// A value used by Universal Robots software only
        /// </summary>
        [SdkCheck(748, 8, 1)]
        public double Test_Value { set; get; }

        /// <summary>
        /// Robot mode
        /// </summary>
        [SdkCheck(756, 8, 1)]
        public RobotMode RobotMode { set; get; }

        /// <summary>
        /// Joint control modes
        /// </summary>
        [SdkCheck(764, 48, 6)]
        public Vector Joint_Modes { set; get; }

        /// <summary>
        /// Joint control modes
        /// </summary>
        [SdkCheck(812, 8, 1)]
        public SafetyMode Safety_Mode { set; get; }

        /// <summary>
        /// 软件自留
        /// </summary>
        [SdkCheck(820, 48, 6)]
        public Vector Unkonw1 { set; get; }

        /// <summary>
        /// Tool x,y and z accelerometer values (software version 1.7)
        /// </summary>
        [SdkCheck(868, 24, 3)]
        public VectorSp Tool_Accelerometer { set; get; }

        /// <summary>
        /// 自留
        /// </summary>
        [SdkCheck(892, 48, 6)]
        public Vector UnKonw2 { set; get; }

        /// <summary>
        /// Speed scaling of the trajectory limiter
        /// </summary>
        [SdkCheck(940, 8, 1)]
        public double Speed_Scaling { set; get; }

        /// <summary>
        /// Norm of Cartesian linear momentum
        /// </summary>
        [SdkCheck(948, 8, 1)]
        public double Linear_Momentum_Norm { set; get; }

        [SdkCheck(956, 8, 1)]
        public double UnKonw3 { set; get; }
        [SdkCheck(964, 8, 1)]
        public double UnKonw4 { set; get; }

        /// <summary>
        /// Masterboard: Main voltage
        /// </summary>
        [SdkCheck(972, 8, 1)]
        public double V_Main { set; get; }
        /// <summary>
        /// Masterboard: Robot voltage (48V)
        /// </summary>
        [SdkCheck(980, 8, 1)]
        public double V_Robot { set; get; }

        /// <summary>
        /// Masterboard: Robot current
        /// </summary>
        [SdkCheck(988, 8, 1)]
        public double I_Robot { set; get; }

        /// <summary>
        /// Actual joint voltages
        /// </summary>
        [SdkCheck(996, 48, 6)]
        public Vector Actual_Joint_Voltages { set; get; }

        /// <summary>
        /// Digital outputs
        /// </summary>
        [SdkCheck(1044, 8, 1)]
        public double Digital_Outputs { set; get; }

        /// <summary>
        /// 
        /// </summary>
        [SdkCheck(1052, 8, 1)]
        public ProgramState Program_State { set; get; }

        /// <summary>
        /// Elbow position
        /// </summary>
        [SdkCheck(1060, 24, 3)]
        public VectorSp Elbow_Position { set; get; }

        /// <summary>
        /// Elbow velocity
        /// </summary>
        [SdkCheck(1084, 24, 3)]
        public VectorSp Elbow_Velocity { set; get; }

        public static RealtimeModel Parse(byte[] bs)
        {
            var result = new RealtimeModel();
            try
            {
                typeof(RealtimeModel).GetProperties().ToList().ForEach(p =>
            {
                var attr = p.GetCustomAttribute<SdkCheckAttribute>();
                if (attr != null&&bs.Length> attr.StartIndex)
                { 
                    var bb = bs.Skip(attr.StartIndex).Take(attr.Length).ToArray(); 
                        var value = UTools.GetBitValue(p.PropertyType, attr, bb); 
                          if (p.PropertyType.IsEnum && value is double )
                          {  
                                p.SetValue(result, Convert.ChangeType(value, UTools.IntType)); 
                            }
                            else
                            {
                                p.SetValue(result, value);
                            } 
                }
            });  
                return result;
            }
            catch (Exception ex)
            {
                //部分枚举项 存在错误，抛出不处理
                 Console.WriteLine(ex);
            }
            return null;
        }
       
       

    }
}
