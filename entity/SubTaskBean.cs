using metalAssistor.util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace metalAssistor.entity
{
    //DisconnectSwitchBean
    [Serializable]
    public class SubTaskBean
    {
        private string voltage;
        private string manufacturer;
        private string type;
        private int count;
        protected List<CheckUnit> units = new List<CheckUnit>();
        private int taskType = 1;
        private string id;
        private string name;
        private bool isUpload = false;

        private string deviceModel;
        private string deviceNO;

        private float standard;//微米

        public SubTaskBean()
        {
            id = "dsb" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        public string Voltage { get => voltage; set => voltage = value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public string Type { get => type; set => type = value; }
        public List<CheckUnit> Units { get => units; set => units = value; }
        public int Count { get => count; set { count = value; ChangeUnit(value); } }

        public int TaskType { get => taskType; set => taskType = value; }
        public string Id { get => id; set => id = value; }
        public bool IsUpload { get => isUpload; set => isUpload = value; }
        public string Name { get => name; set => name = value; }
        public string DeviceModel { get => deviceModel; set => deviceModel = value; }
        public string DeviceNO { get => deviceNO; set => deviceNO = value; }
        public float Standard { get => standard; set => standard = value; }

        public string FullName()
        {
            return voltage + "·" + manufacturer + "·" + type + "—" + name;
        }

        protected virtual void ChangeUnit(int c)
        {
            if (units.Count == 0)
            {
                for (int i = 0; i < c && i < 5; i++)
                {
                    Units.Add(new CheckUnit(name+(i+1), taskType));
                }
            }
        }
        public virtual CheckUnit AddUnit()
        {
            int i=0;
            bool end = false;
            while (!end)
            {
                i++;end = true;
                foreach(CheckUnit item in units)
                {
                    if (item.Name == name + i) end = false;
                }
            }
            CheckUnit u = new CheckUnit(name + i, taskType);
            units.Add(u);
            return u;
        }

        public virtual SubTaskBean Clone()
        {
            return JsonConvert.DeserializeObject<SubTaskBean>(JsonConvert.SerializeObject(this));
        }

        public virtual bool IsStandard(CheckUnit unit)
        {
            foreach (CheckPoint point in unit.Points)
            {
                if (point.Value < standard)
                    return false;
            }
            return true;
        }
    }
    [Serializable]
    public class CheckUnit
    {
        private string id;
        private string name;

        protected List<CheckPoint> points = new List<CheckPoint>();

        public CheckUnit(string name, int taskType)
        {
            this.name = name;
            id = Guid.NewGuid().ToString();
            DefaultPoint(taskType);
        }
        protected virtual void DefaultPoint(int taskType)
        {
            int pointNum = TaskTypeUtil.GetCheckPonitNum(taskType);
            for (int i = 1; i < pointNum + 1; i++) { points.Add(new CheckPoint("测点" + i)); }
        }
        public virtual CheckPoint AddPoint()
        {
            int i = 0;
            bool end = false;
            while (!end)
            {
                i++; end = true;
                foreach (CheckPoint item in points)
                {
                    if (item.Name == "测点" + i) end = false;
                }
            }
            CheckPoint u = new CheckPoint("测点" + i);
            points.Add(u);
            return u;
        }

        public List<CheckPoint> Points { get => points; set => points = value; }
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
    [Serializable]
    public class CheckPoint
    {
        private float value=float.NaN;
        private string time;
        private string id;
        private string name;
        public CheckPoint(string name)
        {
            this.name = name;
            id = Guid.NewGuid().ToString();
        }
        public float Value { get => value; set => this.value = value; }
        public string Time { get => time; set => time = value; }
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
