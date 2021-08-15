using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace AnalyzeReportMaker.Class
{
  public  static class Class_Static
    {
        public static string conn = @"data source=e-sepaar.net\enterprise;initial catalog=DB_DDN;persist security info=True;user id=sa;password=1qaz@WSX";// GlobalSetting.ConnectionServerPanel;// 
        public static List<T> ConvertDataTableToClass<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    T item = GetItem<T>(row);

                    data.Add(item);

                }
            }
            catch
            {

            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            try
            {
                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (pro.Name == column.ColumnName)
                        {

                            try
                            {

                                if (dr[column.ColumnName].GetType() == typeof(string) || dr[column.ColumnName].GetType() == typeof(String) || dr[column.ColumnName].GetType() == typeof(Char) || dr[column.ColumnName].GetType() == typeof(char))
                                {
                                    pro.SetValue(obj, Class_Static.PersianAlpha(dr[column.ColumnName]), null);

                                }
                                else
                                {
                                    pro.SetValue(obj, dr[column.ColumnName], null);
                                }
                                //  pro.SetValue(obj, dr[column.ColumnName], null);



                            }
                            catch
                            {
                                pro.SetValue(obj, null, null);
                            }
                        }
                        else
                            continue;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return obj;
        }
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
        public static string ArabicAlpha(object txt)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt.ToString()))
                    return "";
                return txt.ToString().Replace("ی", "ي").Replace("ک", "ك");

            }
            catch (Exception)
            {
                return txt + "";

            }
        }
        public static string InjectionOk(object input)
        {
            var inp = HttpUtility.HtmlEncode(input + "");
            //   inp = inp.Replace("--", "");
            //  inp = inp.Replace("'", "");
            inp = inp.Replace("select", "");
            inp = inp.Replace("delete", "");
            inp = inp.Replace("insert", "");
            inp = inp.Replace("drop", "");
            inp = inp.Replace("trucate", "");
            inp = inp.Replace("update", "");

            return HttpUtility.HtmlDecode(inp);
        }
        public static string PersianAlpha(object txt)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt + ""))
                    return "";
                return (txt + "").Replace("ي", "ی").Replace("ك", "ک");

            }
            catch (Exception)
            {
                return txt + "";

            }
        }
        public static string ConvertToEnNumber(object txt)
        {

            try
            {
                return Persia.PersianWord.ConvertToLatinNumber(txt + "");
            }
            catch { return txt + ""; }

        }
        public static string ConvertToFaNumber(object txt)
        {
            try
            {

                return Persia.PersianWord.ToPersianString(txt + "");
            }
            catch { return txt + ""; }

        }
        public static string ShamsiBySlash(object fDate)
        {
            var fDateStr = fDate + "";
            try
            {
                if (string.IsNullOrWhiteSpace(fDateStr))
                    return fDateStr;
                if (fDate.ToString().Split('/').Count() > 1)
                {
                    return fDateStr;
                }
                else
                {
                    return fDateStr.Substring(0, 4) + "/" + fDateStr.Substring(4, 2) + "/" + fDateStr.Substring(6, 2);
                }
            }
            catch
            {
                return fDateStr;
            }
        }
        public static string ShamsiWithoutSlash(string fDate)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fDate))
                    return fDate;
                if (fDate.Split('/').Count() < 1)
                {
                    return fDate;
                }
                else
                {
                    fDate = fDate.Replace("/", "");
                    fDate = fDate.Replace("/", "");
                    return fDate.Substring(0, 4) + fDate.Substring(4, 2) + fDate.Substring(6, 2);
                }
            }
            catch
            {
                return fDate;
            }
        }

        public static string MiladiToShamsi(DateTime date)
        {
            return Persia.Calendar.ConvertToPersian(date).ToString();
        }
        public static string MiladiToShamsiIndex(DateTime date)
        {
            return Persia.Calendar.ConvertToPersian(date).ToString().Replace("/", "");
        }
        public static DateTime ShamsiToMiladi(object fDate)
        {
            try
            {
                var fDateStr = fDate.ToString();
                if (string.IsNullOrWhiteSpace(fDateStr))
                    return DateTime.Now;

                PersianCalendar pc = new PersianCalendar();

                if (fDateStr.Split('/').Count() > 1)
                {
                    var year = fDateStr.Split('/')[0] + "";
                    if (year.Length < 3)
                    {
                        year = "13" + year;
                    }
                    return pc.ToDateTime(
                        Convert.ToInt32(year),
                        Convert.ToInt32(fDateStr.Split('/')[1]),
                        Convert.ToInt32(fDateStr.Split('/')[2]),
                        0, 0, 0, 0);
                }
                else
                {
                    fDateStr = fDateStr.Replace("/", "");

                    if (fDateStr.Length == 6)
                    {
                        fDateStr = "13" + fDateStr;
                    }
                    return pc.ToDateTime(
                        Convert.ToInt32(fDateStr.Substring(0, 4)),
                        Convert.ToInt32(fDateStr.Substring(4, 2)),
                        Convert.ToInt32(fDateStr.Substring(6, 2)),
                        0, 0, 0, 0);
                }


            }
            catch
            {
                return DateTime.Now;

            }


        }
        public static string DiffrentDate(object ddate)
        {

            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            var newsDtTime = new DateTime();
            if (!string.IsNullOrWhiteSpace(ddate + ""))
            {
                newsDtTime = Convert.ToDateTime(ddate);
            }
            else
            {
                newsDtTime = DateTime.Now;
            }



            return Class_Static.GetOnTimeDate(newsDtTime);


        }
        public static string GetOnTimeDate(DateTime date)
        {
            var newsTimeAgo = "";
            var dt = DateTime.Now;
            TimeSpan difference = date - dt;

            var strCompare = "";
            if (difference.Seconds < 0)
            {
                strCompare = " قبل ";
            }
            else if (difference.Seconds > 0)
            {
                strCompare = " بعد ";

            }
            var time = Class_Static.RoundTenNum(date.Hour) + ":" + Class_Static.RoundTenNum(date.Minute);

            var minute = 0;
            var hour = 0;
            var days = 0;
            if (difference.TotalMinutes < 0)
                minute = (Convert.ToInt32(difference.TotalMinutes) * -1);
            else
                minute = Convert.ToInt32(difference.TotalMinutes);

            if (difference.TotalHours < 0)
                hour = (Convert.ToInt32(difference.TotalHours) * -1);
            else
                hour = Convert.ToInt32(difference.TotalHours);

            if (difference.TotalDays < 0)
                days = (Convert.ToInt32(difference.TotalDays) * -1);
            else
                days = Convert.ToInt32(difference.TotalDays);


            if (dt.Year == date.Year && dt.Month == date.Month && dt.Day == date.Day)
            {
                if (hour == 0)
                {
                    return minute + " دقیقه " + strCompare;
                }
                else
                {
                    return hour + " ساعت " + (minute % 60) + " دقیقه " + strCompare;
                }

            }
            //if (difference.TotalDays > 0 && difference.TotalDays < 1)
            //{




            //}
            else if (days == 1)
            {
                if (difference.Seconds < 0)
                {
                    return "دیروز" + " " + time;
                }
                else
                {
                    return "فردا" + " " + time;

                }
            }
            else
            {

                return Persia.Calendar.ConvertToPersian(date).ToString() + " - " + Class_Static.RoundTenNum(date.Hour) + ":" + Class_Static.RoundTenNum(date.Minute) + " ";
            }
            //if (days == 0)
            //{
            //    if (minutes < 1)
            //    {
            //        return newsTimeAgo = " لحظاتی پیش ";
            //    }
            //    else if (minutes < 60)
            //    {
            //        newsTimeAgo = minutes + "";

            //        newsTimeAgo = newsTimeAgo + " دقیقه پیش ";

            //        return newsTimeAgo;
            //    }

            //    else
            //    {
            //        newsTimeAgo = (minutes / 60) + "";
            //        if (newsTimeAgo.IndexOf("/") > -1)
            //            newsTimeAgo = newsTimeAgo.Substring(0, newsTimeAgo.IndexOf("/"));
            //        newsTimeAgo += " ساعت پیش ";
            //        return newsTimeAgo;

            //    }
            //}

            //else if (days == 1)
            //{


            //    newsTimeAgo = "دیروز ";
            //    return newsTimeAgo;

            //}

            //else
            //{


            //    newsTimeAgo = Persia.PersianWord.ToPersianString(newsTimeAgo);
            //    return newsTimeAgo;

            //}

        }
     
        public static string RoundTenNum(int num)
        {
            if (num >= 10)
            {
                return num.ToString();
            }
            else
            {
                return ("0" + num);
            }
        }
        public static string RoundTenNum(string number)
        {
            var num = Convert.ToInt32(number);
            if (num >= 10)
            {
                return num.ToString();
            }
            else
            {
                return ("0" + num);
            }
        }
    }
}
