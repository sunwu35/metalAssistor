using metalAssistor.util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace metalAssistor.entity
{
    [Serializable]
    public class GuaranteeTaskBean: SubTaskBean
    {
        private float loadTime;
        private float proofLoad;
        private float behavior;
        public float LoadTime { get => loadTime; set => loadTime = value; }
        public float ProofLoad { get => proofLoad; set => proofLoad = value; }
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
            GuaranteeUnit u = new GuaranteeUnit(Name + i, TaskType);
            units.Add(u);
            return u;
        }

        public override SubTaskBean Clone()
        {
            return JsonConvert.DeserializeObject<GuaranteeTaskBean>(JsonConvert.SerializeObject(this));
        }

        protected override void ChangeUnit(int c)
        {
            if (units.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    Units.Add(new GuaranteeUnit(Name + (i + 1), TaskType));
                }
            }
        }

        public override bool IsStandard(CheckUnit unit)
        {
            foreach (GuaranteePoint point in unit.Points)
            {
                if (!(point.Elongating == "完好"))
                    return false;
            }
            return true;
        }
    }
    [Serializable]
    public class GuaranteeUnit : CheckUnit
    {
        public GuaranteeUnit(string name, int taskType) : base(name, taskType) { }

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
            GuaranteePoint u = new GuaranteePoint("测点" + i);
            points.Add(u);
            return u;
        }

        protected override void DefaultPoint(int taskType)
        {
            int pointNum = TaskTypeUtil.GetCheckPonitNum(taskType);
            for (int i = 1; i < pointNum + 1; i++) { points.Add(new GuaranteePoint("测点" + i)); }
        }
    }
    [Serializable]
    public class GuaranteePoint : CheckPoint
    {
        private string elongating;
        private string afterLoad;
        public GuaranteePoint(string name) : base(name) { }

        public string Elongating { get => elongating; set => elongating = value; }
        public string AfterLoad { get => afterLoad; set => afterLoad = value; }
    }
}