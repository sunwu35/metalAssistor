using metalAssistor.util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace metalAssistor.entity
{
    [Serializable]
    public class WedgeTaskBean : SubTaskBean
    {
        private float minPull;
        private float maxPull;
        private float behavior;

        public float MinPullLoad { get => minPull; set => minPull = value; }
        public float MaxPullLoad { get => maxPull; set => maxPull = value; }
        public float Behavior { get => behavior; set => behavior = value; }

        public override CheckUnit AddUnit()
        {
            int i = 0;
            bool end = false;
            while (!end)
            {
                i++; end = true;
                foreach (CheckUnit item in units)
                {
                    if (item.Name == Name + i) end = false;
                }
            }
            WedgeUnit u = new WedgeUnit(Name + i, TaskType);
            units.Add(u);
            return u;
        }

        public override SubTaskBean Clone()
        {
            return JsonConvert.DeserializeObject<WedgeTaskBean>(JsonConvert.SerializeObject(this));
        }

        protected override void ChangeUnit(int c)
        {
            if (units.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    Units.Add(new WedgeUnit(Name + (i + 1), TaskType));
                }
            }
        }

        public override bool IsStandard(CheckUnit unit)
        {
            foreach (WedgePoint point in unit.Points)
            {
                if (!string.IsNullOrWhiteSpace(point.Bareaking))
                    return false;
            }
            return true;
        }
    }
    [Serializable]
    public class WedgeUnit : CheckUnit
    {
        public WedgeUnit(string name, int taskType) : base(name, taskType) { }

        public override CheckPoint AddPoint()
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
            WedgePoint u = new WedgePoint("测点" + i);
            points.Add(u);
            return u;
        }

        protected override void DefaultPoint(int taskType)
        {
            int pointNum = TaskTypeUtil.GetCheckPonitNum(taskType);
            for (int i = 1; i < pointNum + 1; i++) { points.Add(new WedgePoint("测点" + i)); }
        }
    }
    [Serializable]
    public class WedgePoint : CheckPoint
    {
        private string bareaking;
        private int bareakingNO;
        private float angle;
        private float aperture;
        public WedgePoint(string name) : base(name) { }

        public string Bareaking { get => bareaking; set { bareaking = value; bareakingNO = TaskTypeUtil.BreakingNO(value); } }
        public float Angle { get => angle; set => angle = value; }
        public float Aperture { get => aperture; set => aperture = value; }
        public int BareakingNO { get => bareakingNO; set => bareakingNO = value; }
    }
}
