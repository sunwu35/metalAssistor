using System;

namespace metalAssistor.util
{
    internal class Test
    {
        public string Test1 { get; set; }
        public string Test2 { get; set; }
        public string Test3 { get; set; }
        public string Test4 { get; set; }
        public string Test5 { get; set; }
        public string Test6 { get; set; }

        //Parse方法会在自定义读写CSV文件时用到
        public static Test Parse(string[] fields)
        {
            try
            {
                Test ret = new Test();
                ret.Test1 = fields[0];
                ret.Test2 = fields[1];
                ret.Test3 = fields[2];
                ret.Test4 = fields[3];
                ret.Test5 = fields[4];
                ret.Test6 = fields[5];
                return ret;
            }
            catch (Exception)
            {
                //做一些异常处理，写日志之类的
                return null;
            }
        }
    }
}