using System;
using System.Collections.Generic;
using System.Text;
using URSdk; 

namespace URSdk
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class VectorExtend
    {
        /// <summary>
        /// 是否为零位
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Boolean IsZero(this Vector vector)
        {
            if (vector.X == 0 && vector.Y == 0 && vector.Z == 0
                && vector.RX == 0 && vector.RY == 0 && vector.RZ == 0)
            {
                return true;
            }
            return false;
        } }
    public static class RealtimeModelExtend
    {
        /// <summary>
        /// 是否正在移动
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool IsMoving(this RealtimeModel model)
        {
            if(model.TCP_Speed_Actual.IsZero() && model.Target_Joint_Velocitie.IsZero())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
