
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
 
using System.Windows.Forms;

namespace metalAssistor.entity
{
    class InfoBean
    {
        private string manufactor = "北京圣泰实时电气技术有限公司";
        private string type = "TDT6U";
        private string serial = "asdgfghhkjhkgc";
        private string version = "1.0.0.0";
        private string path = "";
        private string spec = "M24,M27,M30,M36,M42";
        private string behaviorBolt = "4.8,5.6,8.8";
        private string behaviorNut = "5,6,8,10";
        private string breaking = "完好,上,中,下";
        private string uRL = "http://192.168.31.227:8080";

        public string Manufactor { get => manufactor; set => manufactor = value; }
        public string Type { get => type; set => type = value; }
        public string Serial { get => serial; set => serial = value; }
        public byte[] VersionArray
        {
            get
            {
                byte[] v = { 1, 0, 0, 0 };
                try
                {
                    string[] vs = version.Split('.');
                    v[0] = byte.Parse(vs[0]);
                    v[1] = byte.Parse(vs[1]);
                    v[2] = byte.Parse(vs[2]);
                    v[3] = byte.Parse(vs[3]);
                }
                catch { }
                return v;
            }
            set => version = string.Format("{0}.{1}.{2}.{3}", version[0], version[1], version[2], version[3]);
        }
        public string Path { get => path; set => path = value; }
        public string Version { get => version; set => version = value; }
        public string Spec { get => spec; set => spec = value; }
        public string BehaviorBolt { get => behaviorBolt; set => behaviorBolt = value; }
        public string BehaviorNut { get => behaviorNut; set => behaviorNut = value; }
        public string Breaking { get => breaking; set => breaking = value; }
        public string URL { get => uRL; set => uRL = value; }

        public static InfoBean Create()
        {
            InfoBean b = new InfoBean();
            try
            {
                Dictionary<string, string> d = new Dictionary<string, string>();
                using (StreamReader s = new StreamReader(Application.StartupPath + "//conf//info.properties"))
                {
                    string line;
                    while ((line = s.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (line.StartsWith("//") || line.StartsWith("#")) continue;
                        if (line.Contains("="))
                        {
                            string[] str = line.Split('=');
                            d.Add(str[0], str[1]);
                        }
                    }
                }
                if (d.ContainsKey("manufactor")) b.Manufactor = d["manufactor"];
                if (d.ContainsKey("type")) b.Type = d["type"];
                if (d.ContainsKey("serial")) b.Serial = d["serial"];
                if (d.ContainsKey("version")) b.version = d["version"];
                if (d.ContainsKey("path")) b.Path = d["path"];
                if (d.ContainsKey("behaviorBolt")) b.behaviorBolt = d["behavior"];
                if (d.ContainsKey("behaviorNut")) b.behaviorNut = d["behavior"];
                if (d.ContainsKey("spec")) b.Spec = d["spec"];
                if (d.ContainsKey("url")) b.URL = d["url"];
            }
            catch
            {

            }
            return b;
        }
    }
}
