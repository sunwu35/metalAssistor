using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace metalAssistor.util
{
    class TaskTypeUtil
    {
        public const int DisconnectSwitch = 1;
        public const int SwitchCabinet = 2;
        public const int CopperBar = 6;
        //public const int GroundDevice = 7;
        //public const int DisconnectSwitchZn = 10;
        //public const int Fastening = 11;
        public const int MechanicsBehaviorSclerometer = 20;
        public const int MechanicsBehaviorWedge = 21;
        public const int MechanicsBehaviorGuarantee = 22;


        public const string DisconnectSwitchS = "隔离开关触头镀银层厚度检测"; //   \
        public const string SwitchCabinetS = "开关柜触头镀银层厚度检测";// 2 \
        public const string CopperBarS = "铜排连接导电接触部位镀银层厚度检测";// 6 1
        //public const string GroundDeviceS = "变电站接地装置涂覆层厚度检测";// 7  5  无厂家规格
        //public const string DisconnectSwitchZnS = "隔离开关外露传动机构件镀锌层厚度检测";// 10 1
        //public const string FasteningS = "变电导流部件紧固件镀锌层厚度检测";// 11 3 有厂家规格
         public const string MechanicsBehaviorSclerometerS = "输电线路地脚螺栓、螺母硬度检测";
        public const string MechanicsBehaviorWedgeS = "输电线路螺栓楔负载检测";
        public const string MechanicsBehaviorGuaranteeS = "输电线路螺母保证载荷检测";

        public static string GetSubTaskS(int type)
        {
            if (type == DisconnectSwitch) return DisconnectSwitchS;
            if (type == SwitchCabinet) return SwitchCabinetS;
            if (type == CopperBar) return CopperBarS;
            if (type == MechanicsBehaviorSclerometer) return MechanicsBehaviorSclerometerS;
            if (type == MechanicsBehaviorWedge) return MechanicsBehaviorWedgeS;
            if (type == MechanicsBehaviorGuarantee) return MechanicsBehaviorGuaranteeS;
            return DisconnectSwitchS;
        }


        public static float GetStandard(int taskType)
        {
            if (taskType == DisconnectSwitch) return 20;
            if (taskType == SwitchCabinet) return 8;
            if (taskType == CopperBar) return 8;
            return 8;
        }

        public static float[] GetSclerometerStabdard(string name, string behavior)
        {
            if (name.Contains("螺栓"))
            {
                if (behavior == "4.6")
                {
                    return new float[] { 120, 220 };
                }
                if (behavior == "5.6")
                {
                    return new float[] { 155, 220 };
                }
                if (behavior == "8.8")
                {
                    return new float[] { 255, 335 };
                }
                return new float[] { 120, 335 };
            }
            else
            {
                if (behavior == "5")
                {
                    return new float[] { 146, 302 };
                }
                if (behavior == "6")
                {
                    return new float[] { 170, 302 };
                }
                if (behavior == "8")
                {
                    return new float[] { 233, 353 };
                }
                if (behavior == "10")
                {
                    return new float[] { 272, 353 };
                }
                return new float[] { 146, 353 };
            }
        }


        public static int GetCheckPonitNum(int taskType)
        {
            if (taskType == MechanicsBehaviorGuarantee ||
                taskType == MechanicsBehaviorSclerometer ||
                taskType == MechanicsBehaviorWedge)
                return 1;
            return 5;
        }


        public static object[] Breaking()
        {
            return new object[] { "上", "中", "下" };
        }
        public static int BreakingNO(string t)
        {
            object[] os = Breaking();
            for (int i = 0; i < os.Length; i++)
            {
                if (os[i].ToString() == t) return i + 1;
            }
            return 0;
        }


        public static object[] Elongating()
        {
            return new object[] { "脱扣","断裂","完好" };
        }

        public static object[] AfterLoad()
        {
            return new object[] { "手旋出", "扳手旋出，不超半扣", "超过半扣扳手旋出或无法旋出" };
        }
    }
}
