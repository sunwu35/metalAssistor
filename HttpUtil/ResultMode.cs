using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace metalAssistor.HttpUtil
{
    class ResultMode
    {
        private string code="500";
        private string msg="未知错误";
        private object data;

        public string Code { get => code; set => code = value; }
        public string Msg { get => msg; set => msg = value; }
        public object Data { get => data; set => data = value; }
    }
}
