using metalAssistor.entity;
using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace metalAssistor.util
{
    class WordUtil
    {
        public const string BeiJingShenTai= "TDT6U";
        public const string HuNanXiangDian = "HR1100";
        public static FilmBean ReadFilm(string fileName)
        {
            FilmBean b = new FilmBean();
            try
            {
                List<List<string>> allLine = new List<List<string>>();

                List<string> unitLine = new List<string>();

                Document document = new Document(fileName);
                foreach (Section section in document.Sections)
                {
                    foreach (Paragraph paragraph in section.Paragraphs)
                    {
                        if (string.IsNullOrEmpty(paragraph.Text.Trim()))
                        {
                            if (unitLine.Count > 0)
                            {
                                allLine.Add(unitLine);
                                unitLine = new List<string>();
                            }
                        }
                        else
                        {
                            unitLine.Add(paragraph.Text);
                        }
                    }
                }
                if(unitLine.Count > 0) allLine.Add(unitLine);

                unitLine = allLine[1];
                string[] ssplit = unitLine[0].Replace("     ", ":").Split(':');
                b.Name = ssplit[0].Trim();
                b.Type = ssplit[1].Trim();
                ssplit = unitLine[1].Split('\t');
                b.Product = ssplit[0].Split(':', '：')[1].Trim();
                b.Dir = ssplit[1].Split(':', '：')[1].Trim();
                b.Block = ssplit[2].Split(':', '：')[1].Trim();
                b.Application= unitLine[2].Split(':', '：')[1].Trim();

                unitLine = allLine[2];
                b.OrderNo= unitLine[0].Split(':', '：')[1].Trim();
                b.BatchNo = unitLine[1].Split(':', '：')[1].Trim();
                b.Tester = unitLine[2].Split(':', '：')[1].Trim();

                Regex regex = new Regex("(-?\\d+)(\\.\\d+)?", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                string t;
                foreach (string item in allLine[3])
                {
                    t = regex.Match(item.Split('=')[2].Trim()).Value;
                    b.Data.Add(float.Parse(t));
                }

                unitLine = allLine[4];
                t = regex.Match(unitLine[0].Split('\t')[1].Trim()).Value;
                b.Mean=float.Parse(t);
                t = regex.Match(unitLine[1].Split('\t')[1].Trim()).Value;
                b.StandardDeviation = float.Parse(t);
                t = regex.Match(unitLine[2].Split('\t')[1].Trim()).Value;
                b.COV = float.Parse(t);
                t = regex.Match(unitLine[3].Split('\t')[1].Trim()).Value;
                b.Range = float.Parse(t);
                t = regex.Match(unitLine[4].Split('\t')[1].Trim()).Value;
                b.ReadingsNumber = float.Parse(t);
                t = regex.Match(unitLine[5].Split('\t')[1].Trim()).Value;
                b.MaxReading = float.Parse(t);
                t = regex.Match(unitLine[6].Split('\t')[1].Trim()).Value;
                b.MinReading = float.Parse(t);
                t = regex.Match(unitLine[7].Split('\t')[1].Trim()).Value;
                b.MeasuringTime = float.Parse(t);

                DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyy/MM/dd HH:mm;ss";
                b.Time = Convert.ToDateTime(unitLine[9].Replace(" ", "").Replace("Date:", "").Replace("Time:", " "), dtFormat);

                //document = new Document();
                //document.AddSection();
                
                //for (int i = 0; i < 20; i++)
                //{
                //    document.Sections[0].AddParagraph().Text = "来啦";
                //    document.Sections[0].AddParagraph().Text = "去死";
                //    Table table=document.Sections[0].AddTable(true);
                //    table.ResetCells(2, 3);
                //}
                //document.SaveToFile(Application.StartupPath + "//111.docx");
            }
            catch (Exception e)
            {
                return null;
            }
            return b;
        }

        public static SclerometerBean ReadSclerometer(string fileName)
        {
            SclerometerBean b = new SclerometerBean();
            try
            {

                Document document = new Document(fileName);
                Section section = document.Sections[0];
                Table t1 = section.Tables[0] as Table;
                Table t2 = section.Tables[1] as Table;

                b.SubmitUnit = t1.Rows[0].Cells[1].FirstParagraph.Text.Trim();
                b.SubmitTime = t1.Rows[0].Cells[3].FirstParagraph.Text.Trim();
                b.Name = t1.Rows[1].Cells[1].FirstParagraph.Text.Trim();
                b.Number = t1.Rows[1].Cells[3].FirstParagraph.Text.Trim();
                int count;
                int.TryParse(t1.Rows[2].Cells[1].FirstParagraph.Text.Trim(), out count);
                b.Count = count;

                b.SuperLimit = GetValue(t1.Rows[3].Cells[1].FirstParagraph.Text.Trim());
                b.UpperLimit = GetValue(t1.Rows[3].Cells[3].FirstParagraph.Text.Trim());


                b.DeviceNo = t1.Rows[5].Cells[1].FirstParagraph.Text.Trim();
                b.StandardNo = t1.Rows[5].Cells[3].FirstParagraph.Text.Trim();
                b.Diameter = GetValue(t1.Rows[6].Cells[1].FirstParagraph.Text.Trim());
                b.Pressure = GetValue(t1.Rows[6].Cells[3].FirstParagraph.Text.Trim());

                int i = 0;
                for (; i < t1.Rows.Count; i++)
                {
                    if (t1.Rows[i].Cells[0].FirstParagraph.Text == "测量结果") break;
                }
                i += 3;
                for(;i< t1.Rows.Count; i++)
                {
                    TableRow r = t1.Rows[i];
                    if (!Regex.IsMatch(r.Cells[0].FirstParagraph.Text.Trim(), "^[0-9]+$")) break;
                    Measure m = new Measure();
                    m.Order = int.Parse(r.Cells[0].Paragraphs[0].Text.Trim());                   
                    m.Depth = GetValue(r.Cells[1].Paragraphs[0].Text.Trim());
                    m.Y = GetValue(r.Cells[2].Paragraphs[0].Text.Trim());
                    m.D1 = GetValue(r.Cells[3].Paragraphs[0].Text.Trim());
                    m.D2 = GetValue(r.Cells[4].Paragraphs[0].Text.Trim());
                    m.Hardness = GetValue(r.Cells[5].Paragraphs[0].Text.Trim());
                    b.Measures.Add(m);

                    if (!Regex.IsMatch(r.Cells[7].FirstParagraph.Text.Trim(), "^[0-9]+$")) continue;
                    m = new Measure();
                    m.Order = int.Parse(r.Cells[7].Paragraphs[0].Text.Trim());
                    m.Depth = GetValue(r.Cells[8].Paragraphs[0].Text.Trim());
                    m.Y = GetValue(r.Cells[9].Paragraphs[0].Text.Trim());
                    m.D1 = GetValue(r.Cells[10].Paragraphs[0].Text.Trim());
                    m.D2 = GetValue(r.Cells[11].Paragraphs[0].Text.Trim());
                    m.Hardness = GetValue(r.Cells[12].Paragraphs[0].Text.Trim());
                    b.Measures.Add(m);
                }

                for (; i < t1.Rows.Count; i++)
                {
                    //string r = t1.Rows[i].Cells[0].FirstParagraph.Text;
                    if (t1.Rows[i].Cells[0].FirstParagraph.Text.Trim().StartsWith ("Case")) break;
                }

                b.CaseDepth= GetValue(t1.Rows[i].Cells[1].Paragraphs[0].Text.Trim());
                b.CaseHardness = GetValue(t1.Rows[i].Cells[3].Paragraphs[0].Text.Trim());

                for (; i < t1.Rows.Count; i++)
                {
                    if (t1.Rows[i].Cells[0].FirstParagraph.Text == "统计结果") break;
                }
                i++;
                b.Max = GetValue(t1.Rows[i].Cells[1].Paragraphs[0].Text.Trim());
                b.Min = GetValue(t1.Rows[i].Cells[3].Paragraphs[0].Text.Trim());
                i++;
                b.Avg = GetValue(t1.Rows[i].Cells[1].Paragraphs[0].Text.Trim());
                b.Std = GetValue(t1.Rows[i].Cells[3].Paragraphs[0].Text.Trim());
                i++;
                b.Cp = GetValue(t1.Rows[i].Cells[1].Paragraphs[0].Text.Trim());
                b.Cpk = GetValue(t1.Rows[i].Cells[3].Paragraphs[0].Text.Trim());

                DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyy年MM月dd日";
                b.TestTime = Convert.ToDateTime(t2.Rows[1].Cells[2].Paragraphs[0].Text.Trim(), dtFormat);

            }
            catch (Exception e)
            {
                return null;
            }
            return b;
        }

        private static float GetValue(string t)
        {
            float v;
            return float.TryParse(t, out v) ? v : float.NaN;
        }
    }
}
