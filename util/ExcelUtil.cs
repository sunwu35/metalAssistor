using metalAssistor.entity;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

namespace metalAssistor.util
{
    class ExcelUtil
    {
        public static FilmBean ReadFilm(string fileName)
        {
            FilmBean b = new FilmBean();
            try
            {

                Workbook workbook = new Workbook();
                workbook.LoadFromFile(fileName);
                Worksheet sheet = workbook.Worksheets["Report"];
                CellRange range = sheet.Range[sheet.FirstRow, sheet.FirstColumn, sheet.LastRow, sheet.LastColumn];
                DataTable dt = sheet.ExportDataTable(range, true, true);

                //b.Name = ssplit[0].Trim();
                //b.Type = ssplit[1].Trim();
                //b.Product = ssplit[0].Split(':', '：')[1].Trim();
                //b.Dir = ssplit[1].Split(':', '：')[1].Trim();
                //b.Block = ssplit[2].Split(':', '：')[1].Trim();
                //b.Application = unitLine[2].Split(':', '：')[1].Trim();

                //b.OrderNo = unitLine[0].Split(':', '：')[1].Trim();
                //b.BatchNo = unitLine[1].Split(':', '：')[1].Trim();
                //b.Tester = unitLine[2].Split(':', '：')[1].Trim();


                //foreach (string item in allLine[3])
                //{
                //    t = regex.Match(item.Split('=')[2].Trim()).Value;
                //    b.Data.Add(float.Parse(t));
                //}


                b.Mean = float.Parse(dt.Rows[12][1].ToString());

                //b.StandardDeviation = float.Parse(t);

                //b.COV = float.Parse(t);

                //b.Range = float.Parse(t);

                //b.ReadingsNumber = float.Parse(t);

                //b.MaxReading = float.Parse(t);

                //b.MinReading = float.Parse(t);

                //b.MeasuringTime = float.Parse(t);
                int i = 0;
                for(;i< sheet.LastRow; i++)
                {
                    if (dt.Rows[i][0].ToString() == "读数 #") break;
                }

                DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyy/MM/dd HH:mm;ss";
                b.Time = Convert.ToDateTime(dt.Rows[i+1][1]);
            }
            catch (Exception e)
            {
                return null;
            }
            return b;
        }
    }
}
