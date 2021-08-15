using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarsiLibrary.Utils;

namespace PArt.Core
{
    public class Class_Zaman
    {

        public string GetTodayLongString()
        {
            PersianDate pp = DateTime.Now;
            return pp.ToString("D");


        }

        public string Today()
        {
            PersianDate pp = DateTime.Now;
            return pp.ToString().Substring(0, 10);

        }
        public string MiladiToShamsi(string Miladi)
        {
            return PersianDateConverter.ToPersianDate(DateTime.Parse(Miladi)).ToString();


        }

        public DateTime ShamsiToMiladi(object fDate)
        {
            try
            {
                var fDateStr = fDate.ToString();
                if (string.IsNullOrWhiteSpace(fDateStr))
                    return DateTime.Now;

                PersianCalendar pc = new PersianCalendar();
               
                if (fDateStr.Split('/').Count() > 1)
                {
                    string[] date = fDateStr.Split(' ');
                    var year = date[0].Split('/')[0] + "";
                    if (year.Length < 3)
                    {
                        year = "13" + year;
                    }

                    DateTime resultDate = pc.ToDateTime(
                        Convert.ToInt32(year),
                        Convert.ToInt32(date[0].Split('/')[1]),
                        Convert.ToInt32(date[0].Split('/')[2]),
                        0, 0, 0, 0);
                    return resultDate;
                }
                else
                {
                    fDateStr = fDateStr.Replace("/", "");

                    DateTime resultDate = pc.ToDateTime(
                        Convert.ToInt32(fDateStr.Substring(0, 4)),
                        Convert.ToInt32(fDateStr.Substring(4, 2)),
                        Convert.ToInt32(fDateStr.Substring(6, 2)),
                        0, 0, 0, 0);
                    return resultDate;
                }


            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return DateTime.Now;

            }

        }

        public string AddDay(string shamsi, int days)
        {
            DateTime dt = ShamsiToMiladi(shamsi);

            dt = dt.AddDays(days);
            return MiladiToShamsi(dt.ToString());


        }
        public string AddDayShamsi(string shamsi, int days)
        {
            DateTime dt = ShamsiToMiladi(shamsi);

            dt = dt.AddDays(days);
            PersianDate pp = dt;
            return pp.ToString().Substring(0, 10);


    }
    public string GetNewsDate(string NewsDate)
        {
            try
            {
                PersianDate pDate = PersianDate.Parse(NewsDate);

                return pDate.ToString("D");
            }
            catch
            {
                return "";
            }
        }
    }
}