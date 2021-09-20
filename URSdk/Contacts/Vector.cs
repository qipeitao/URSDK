using System;
using System.Collections.Generic;
using System.Text;

namespace URSdk
{
    /// <summary>
    /// 位置封装 6个double
    /// </summary>
   public class Vector
    {
        private Vector(double d1, double d2, double d3, double d4, double d5, double d6)
        {
            X = d1;Y = d2;Z = d3; RX = d4;RY = d5;RZ = d6;
        }
        private Vector(double[] ds):this(ds[0], ds[1], ds[2], ds[3], ds[4], ds[5])
        {
            
        }
        public Double X { set; get; }
        public Double Y { set; get; }
        public Double Z { set; get; }
        public Double RX { set; get; }
        public Double RY { set; get; }
        public Double RZ { set; get; }
        public static Vector Parse(double[] bs)
        {
            if(bs==null||bs.Length!=6)
            {
                return null;
            }
            /////////////////////////////
            return new Vector(bs);
        }
        public override string ToString()
        {
            return string.Format("X:{0},Y:{1},Z:{2},RX:{3},RY:{4},RZ:{5}",
                
                Math.Round(X,5), Math.Round(Y, 5), Math.Round(Z, 5), 
                Math.Round(RX, 4), Math.Round(RY, 4), Math.Round(RZ, 4));
        }
        public  string ToScriptString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5}",

                Math.Round(X, 5), Math.Round(Y, 5), Math.Round(Z, 5),
                Math.Round(RX, 4), Math.Round(RY, 4), Math.Round(RZ, 4));
        }
    }
}
