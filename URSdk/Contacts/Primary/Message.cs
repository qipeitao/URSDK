using System;
using System.Collections.Generic;
using System.Text;
using URSdk;

namespace URSdk
{
    public class Message
    {
        public int Size { set; get; }
        public MessageType MessageType { set; get; }
        public virtual void Prase(byte[] buf)
        {

        }
    }
}
