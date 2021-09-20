using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using URSdk;

namespace URSdk
{
    public class SubMessageItem
    {
        public RobotMessageType RobotMessageType { set; get; }
        public PackageType PackageType { set; get; }
        public virtual SubMessageItem Prase(byte[] bs)
        {
            try
            {
                this.GetType().GetProperties().ToList().ForEach(p =>
                {
                    var attr = p.GetCustomAttribute<SdkCheckAttribute>();
                    if (p.PropertyType.BaseType == typeof(SubMessageItem))
                    {
                        var obj = p.PropertyType.Assembly.CreateInstance(p.PropertyType.FullName) as SubMessageItem;
                        var vv = obj.Prase(bs.Skip(attr.StartIndex).Take(attr.Length).ToArray());
                        p.SetValue(this, vv);
                    }
                    else
                    {
                        if (attr != null)
                        {
                            if (attr.IsStr)
                            {
                                byte[] bbb = null;
                                if (attr.Length == -1)
                                {
                                    bbb = bs.Skip(attr.StartIndex).ToArray();
                                }
                                else
                                {
                                    bbb = bs.Skip(attr.StartIndex).Take(attr.Length).ToArray();
                                }
                                var value = Encoding.UTF8.GetString(bbb);
                                p.SetValue(this, value);
                            }
                            else if (bs.Length > attr.StartIndex)
                            {
                                var bb = bs.Skip(attr.StartIndex).Take(attr.Length).ToArray();
                                var value = UTools.GetBitValue(p.PropertyType, attr, bb);
                                p.SetValue(this, value);
                            }
                        }
                    }
                });
                return this;
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
