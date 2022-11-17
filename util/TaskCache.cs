using metalAssistor.entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace metalAssistor.util
{
    class TaskCache
    {
        public static void SaveTaskCache(List<TaskBean> dir)
        {
            try
            {
                if (dir == null || dir.Count == 0) return;
                if (!Directory.Exists(Application.StartupPath + @"\cache"))
                {
                    Directory.CreateDirectory(Application.StartupPath + @"\cache");
                }
                if (File.Exists(Application.StartupPath + @"\cache\TaskCache.dat"))
                {
                    File.Delete(Application.StartupPath + @"\cache\TaskCache.dat");
                }
                using (FileStream fs = new FileStream(Application.StartupPath + @"\cache\TaskCache.dat", FileMode.Create))
                {
                    //StreamWriter sw = new StreamWriter(fs);                  
                    //string ss = JsonConvert.SerializeObject(dir, Formatting.Indented);
                    //File.WriteAllText(Application.StartupPath + @"\cache\TaskCache.json", ss);
                    //sw.Write(JsonConvert.SerializeObject(dir));
                    //sw.Flush();
                    //sw.Close();
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, dir);
                    fs.Flush();
                    fs.Close();
                }
                //MessageBox.Show("保存完成");
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }

        public static List<TaskBean> GetTaskCache()
        {
            List<TaskBean> p =new List<TaskBean>();
            try
            {
                if (File.Exists(Application.StartupPath + @"\cache\TaskCache.dat"))
                {
                    using (FileStream fs = new FileStream(Application.StartupPath + @"\cache\TaskCache.dat", FileMode.Open))
                    {
                        //if (File.Exists(Application.StartupPath + @"\cache\TaskCache.json"))
                        //{
                        //    var setting = new JsonSerializerSettings()
                        //    {
                        //        SerializationBinder = new Newtonsoft.Json.Serialization.DefaultSerializationBinder()
                        //    };
                        //    p = JsonConvert.DeserializeObject<List<TaskBean>>(File.ReadAllText(Application.StartupPath + @"\cache\TaskCache.json"),setting);
                        //}
                        BinaryFormatter bf = new BinaryFormatter();
                        p = bf.Deserialize(fs) as List<TaskBean>;
                    }
                       
                }
            }
            catch (Exception e) 
            { 
                 Console.WriteLine(e.Message);
            }
            return p;
        }



        public static void SaveSubTaskCache(TaskBean tb)
        {
            try
            {
                if (tb == null || tb.SubTaskBeans.Count == 0) return;
                if (!Directory.Exists(Application.StartupPath + @"\cache"))
                {
                    Directory.CreateDirectory(Application.StartupPath + @"\cache");
                }
                using (FileStream fs = new FileStream(Application.StartupPath + @"\cache\" + tb.TaskId + ".dat", FileMode.Create))
                {
                    //StreamWriter sw = new StreamWriter(fs);                  
                    //string ss = JsonConvert.SerializeObject(dir, Formatting.Indented);
                    //File.WriteAllText(Application.StartupPath + @"\cache\TaskCache.json", ss);
                    //sw.Write(JsonConvert.SerializeObject(dir));
                    //sw.Flush();
                    //sw.Close();
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, tb.SubTaskBeans);
                    fs.Flush();
                    fs.Close();
                }
                //MessageBox.Show("保存完成");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static List<SubTaskBean> GetSubTaskCache(string id)
        {
            List<SubTaskBean> p = null;
            try
            {
                if (File.Exists(Application.StartupPath + @"\cache\" + id + ".dat"))
                {
                    using (FileStream fs = new FileStream(Application.StartupPath + @"\cache\" + id + ".dat", FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        p = bf.Deserialize(fs) as List<SubTaskBean>;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return p == null ? new List<SubTaskBean>() : p;
        }

    }
}
