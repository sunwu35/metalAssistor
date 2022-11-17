using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace metalAssistor.entity
{
    [Serializable]
    public class TaskBean
    {
        private string company;
        private string voltage;
        private string station;
        private string mode;
        private string iD;
        private string taskName;
        private string createTime;

        private List<SubTaskBean> subTaskBeans = new List<SubTaskBean>();

        public TaskBean()
        {
            iD = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        public string CompanyName { get => company; set => company = value; }
        public string VoltageName { get => voltage; set => voltage = value; }
        public string StationName { get => station; set => station = value; }
        public string StationStatus { get => mode; set => mode = value; }

        public string TaskName
        {
            get => taskName;
            set => taskName = value; 
        }
        public string TaskId { get => iD; set => iD = value; }
        public List<SubTaskBean> SubTaskBeans { get => subTaskBeans; set => subTaskBeans = value; }
        public string CreateTime { get => createTime; set => createTime = value; }

        public static TaskBean Create()
        {
            TaskBean tb = new TaskBean();
            tb.CompanyName = "长沙公司";
            tb.VoltageName = "500kV";
            tb.StationName = "小子变电站";
            tb.StationStatus = "新建";
            tb.iD = "1234567890";
            tb.taskName= tb.company + tb.voltage + tb.station + "变电站" + tb.mode + "工程" + "金属检测任务";
            return tb;
        }
    }
}
