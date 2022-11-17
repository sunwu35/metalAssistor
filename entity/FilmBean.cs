using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace metalAssistor.entity
{
    //镀层
    class FilmBean
    {
        private string name;
        private string type;
        private string product;
        private string dir;
        private string block;
        private string application;

        private string orderNo;
        private string batchNo;
        private string tester;

        private Image picture;

        private float mean;//     平均数 	    5.102 μm
        private float standardDeviation;//标准差 	    0.023 μm
        private float cOV;//      0.45				 
        private float range;//     0.055 μm
        private float readingsNumber;//         4				
        private float minReading;//     5.07 μm
        private float maxReading;//       5.13 μm
        private float measuringTime;//       15 sec
        private string operators;//     		
        private DateTime time;  // 2022/9/19  Time:  17:43:41

        private List<float> data = new List<float>();

        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public string Product { get => product; set => product = value; }
        public string Dir { get => dir; set => dir = value; }
        public string Block { get => block; set => block = value; }
        public string Application { get => application; set => application = value; }
        public string OrderNo { get => orderNo; set => orderNo = value; }
        public string BatchNo { get => batchNo; set => batchNo = value; }
        public string Tester { get => tester; set => tester = value; }
        public Image Picture { get => picture; set => picture = value; }
        public float Mean { get => mean; set => mean = value; }
        public float StandardDeviation { get => standardDeviation; set => standardDeviation = value; }
        public float COV { get => cOV; set => cOV = value; }
        public float Range { get => range; set => range = value; }
        public float ReadingsNumber { get => readingsNumber; set => readingsNumber = value; }
        public float MinReading { get => minReading; set => minReading = value; }
        public float MaxReading { get => maxReading; set => maxReading = value; }
        public float MeasuringTime { get => measuringTime; set => measuringTime = value; }
        public string Operators { get => operators; set => operators = value; }
        public DateTime Time { get => time; set => time = value; }
        public List<float> Data { get => data; set => data = value; }
    }
}
