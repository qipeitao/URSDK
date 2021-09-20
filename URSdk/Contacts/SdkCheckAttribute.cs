using System;
using System.Collections.Generic;
using System.Text;

namespace URSdk
{
    /// <summary>
    /// 解析特性
    /// </summary>
   public class SdkCheckAttribute: Attribute
    {
        /// <summary>
        /// 起始位置
        /// </summary>
        public int StartIndex {private set; get; }
        /// <summary>
        /// 长度
        /// </summary>
        public int Length { private set; get; }
        /// <summary>
        /// 值个数
        /// </summary>
        public int ValueNum { private set; get; }
        public Boolean IsStr { private set; get; }
        public SdkCheckAttribute(int startIndex,int length, int valueNum=1,Boolean isStr=false)
        {
            StartIndex = startIndex;
            Length = length;
            ValueNum = valueNum;
            IsStr = isStr;
        }
    }
}
