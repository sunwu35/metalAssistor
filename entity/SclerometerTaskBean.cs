using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace metalAssistor.entity
{
    [Serializable]
    public class SclerometerTaskBean : SubTaskBean
    {
        private float behavior;
        private float minHV;
        private float maxHV;

        public float Behavior { get => behavior; set => behavior = value; }
        public float MinHV { get => minHV; set => minHV = value; }
        public float MaxHV { get => maxHV; set => maxHV = value; }

        public override SubTaskBean Clone()
        {
            return JsonConvert.DeserializeObject<SclerometerTaskBean>(JsonConvert.SerializeObject(this));
        }

        public override bool IsStandard(CheckUnit unit)
        {
            foreach (CheckPoint point in unit.Points)
            {
                if (point.Value < minHV || point.Value > maxHV)
                    return false;
            }
            return true;
        }
    }
}
