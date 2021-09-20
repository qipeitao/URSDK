using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using URSdk;

namespace URSdk
{
   public class UTools
    {
        public static Type DoubleType = typeof(Double);
        public static Type BooleanType = typeof(Boolean);
        public static Type FloatType = typeof(float);
        public static Type IntType = typeof(int);
        public static Type Int64Type = typeof(Int64);
        public static Type VectorType = typeof(Vector);
        public static Type VectorSpType = typeof(VectorSp);
        /// <summary>
        /// 获取数组和
        /// </summary>
        /// <param name="bs">顺序高位-低位</param>
        /// <returns></returns>
        public static long GetLongValue(params byte[] bs)
        {
            long value = 0; 
            var bss = bs.Reverse().ToArray();
            for (var i=0;i<bs.Length;i++)
            {
                value += ((long)bss[i] << (i * 8));
            }
            return value;
        }
        public static object GetBitValue(Type type, SdkCheckAttribute attr, byte[] bs)
        {
            var sp = attr.Length / attr.ValueNum;
            List<object> vs = new List<object>();
            for (var i = 0; i < attr.Length; i += sp)
            {
                if (sp == 8)
                {
                    vs.Add(BitConverter.ToDouble(bs.Skip(i).Take(sp).Reverse().ToArray(), 0));
                }
                else if(sp==4&&type== FloatType)
                {
                    vs.Add(BitConverter.ToSingle(bs.Skip(i).Take(sp).Reverse().ToArray(),0));
                }
                else if (sp == 4 && type == IntType)
                {
                    vs.Add(BitConverter.ToInt32(bs.Skip(i).Take(sp).Reverse().ToArray(), 0));
                }
                else if (sp == 4 && type == Int64Type)
                {
                    vs.Add(BitConverter.ToInt64(bs.Skip(i).Take(sp).Reverse().ToArray(), 0));
                }
                else
                {
                    vs.Add(GetLongValue(bs.Skip(i).Take(sp).ToArray()));
                }
            }
            if (type == VectorType)
            {
                return Vector.Parse( vs.Select(p=>(double)p).ToArray());
            }
            else if (type == VectorSpType)
            {
                return VectorSp.Parse(vs.Select(p => (double)p).ToArray());
            }
             else if(type ==BooleanType)
            {
                return (long)vs.FirstOrDefault() > 0 ? true : false;
            }
            else if(type.IsEnum)
              {
                return Convert.ChangeType(vs.FirstOrDefault(), IntType);
            }
            else
            {
                return Convert.ChangeType(vs.FirstOrDefault(), type);
            }
            //return vs.FirstOrDefault();
        }
        
    }
}
