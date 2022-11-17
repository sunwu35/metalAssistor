using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace metalAssistor.HttpUtil
{
    class LoginMode
    {
        private string access_token;
        private string expires_in;

        public string Access_token { get => access_token; set => access_token = value; }
        public string Expires_in { get => expires_in; set => expires_in = value; }
    }
}
