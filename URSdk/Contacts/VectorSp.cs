using System;
using System.Collections.Generic;
using System.Text;

namespace URSdk
{
    /// <summary>
    /// 位置封装 3个double
    /// </summary>
   public class VectorSp
    {
        private VectorSp(double d1, double d2, double d3)
        {
            X = d1;Y = d2;Z = d3;
        }
        private VectorSp(double[] ds):this(ds[0], ds[1], ds[2])
        {
            
        }
        public Double X { set; get; }
        public Double Y { set; get; }
        public Double Z { set; get; } 
        public static VectorSp Parse(double[] bs)
        {
            if(bs==null||bs.Length!=3)
            {
                return null;
            }
            /////////////////////////////
            return new VectorSp(bs);
        }
        public override string ToString()
        {
            return string.Format("X:{0} Y:{1} Z:{2}",Math.Round( X,5), Math.Round(Y, 5), Math.Round(Z, 5));
        }
        public string ToScriptString()
        {
            return string.Format("{0},{1},{2}", Math.Round(X, 5), Math.Round(Y, 5), Math.Round(Z, 5));
        }
    }
}
