using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace metalAssistor.entity
{
    //硬度计
    class SclerometerBean
    {
        private string submitUnit;
        private string submitTime;
        private string name;
        private string number;
        private int count;
        private float superLimit;
        private float upperLimit;

        private string deviceNo;
        private string standardNo;
        private float diameter;//mm
        private float pressure;//g

        private List<Measure> measures=new List<Measure>();

        private float caseDepth;//mm
        private float caseHardness;//HV


        private float max;
        private float min;
        private float avg;
        private float std;
        private float cp;
        private float cpk;


        private DateTime testTime;

        public string SubmitUnit { get => submitUnit; set => submitUnit = value; }
        public string SubmitTime { get => submitTime; set => submitTime = value; }
        public string Name { get => name; set => name = value; }
        public string Number { get => number; set => number = value; }
        public int Count { get => count; set => count = value; }
        public float SuperLimit { get => superLimit; set => superLimit = value; }
        public float UpperLimit { get => upperLimit; set => upperLimit = value; }
        public string DeviceNo { get => deviceNo; set => deviceNo = value; }
        public string StandardNo { get => standardNo; set => standardNo = value; }
        public float Diameter { get => diameter; set => diameter = value; }
        public float Pressure { get => pressure; set => pressure = value; }
        public float CaseDepth { get => caseDepth; set => caseDepth = value; }
        public float CaseHardness { get => caseHardness; set => caseHardness = value; }
        public float Max { get => max; set => max = value; }
        public float Min { get => min; set => min = value; }
        public float Avg { get => avg; set => avg = value; }
        public float Std { get => std; set => std = value; }
        public float Cp { get => cp; set => cp = value; }
        public float Cpk { get => cpk; set => cpk = value; }
        public DateTime TestTime { get => testTime; set => testTime = value; }
        internal List<Measure> Measures { get => measures; set => measures = value; }
    }
    class Measure
    {
        private int order;
        private float depth;//mm
        private float y;//mm
        private float d1;//µm
        private float d2;//µm
        private float hardness;//HV

        public int Order { get => order; set => order = value; }
        public float Depth { get => depth; set => depth = value; }
        public float Y { get => y; set => y = value; }
        public float D1 { get => d1; set => d1 = value; }
        public float D2 { get => d2; set => d2 = value; }
        public float Hardness { get => hardness; set => hardness = value; }
    }
}
