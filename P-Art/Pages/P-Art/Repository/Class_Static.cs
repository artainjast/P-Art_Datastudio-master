using FarsiLibrary.Utils;
using HtmlAgilityPack;
using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using PayeshEngine;

using System.Web.Mail;

namespace PArt.Pages.P_Art.Repository
{
    public static class Class_Static
    {

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
             (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
        public static string MasterConnection = GlobalSetting.ConnectionServerPanel;// @"Data Source=130.185.78.142\Enterprise;Initial Catalog=DB_DDN;Persist Security Info=True;User ID=sa;Password=1qaz@WSX";
        //public static string MasterConnection = @"Data Source =.; Initial Catalog = DB_DDN; Integrated Security = True";
        private const string GoogleShortenKey = "AIzaSyDoE0akrBvl1f3IIRLpuXpVBDsxTfa4ceg";
        public static string MiladiToShamsiIndex(DateTime date)
        {
            return Persia.Calendar.ConvertToPersian(date).ToString().Replace("/", "");
        }
        public static string GoogleShortenLink(string url)
        {
            string post = "{\"longUrl\": \"" + url + "\"}";
            string shortUrl = url;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/urlshortener/v1/url?key=" + GoogleShortenKey);

            try
            {
                request.ServicePoint.Expect100Continue = false;
                request.Method = "POST";
                request.ContentLength = post.Length;
                request.ContentType = "application/json";
                request.Headers.Add("Cache-Control", "no-cache");

                using (Stream requestStream = request.GetRequestStream())
                {
                    byte[] postBuffer = Encoding.ASCII.GetBytes(post);
                    requestStream.Write(postBuffer, 0, postBuffer.Length);
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader responseReader = new StreamReader(responseStream))
                        {
                            string json = responseReader.ReadToEnd();
                            shortUrl = Regex.Match(json, @"""id"": ?""(?<id>.+)""").Groups["id"].Value;
                        }
                    }
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                // if Google's URL Shortner is down...
                //  System.Diagnostics.Debug.WriteLine(ex.Message);
                //  System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            return shortUrl;
        }

        public static string StrPersianWeekday(string weekday)
        {
            var weekdayName = "";
            switch (weekday.ToLower())
            {
                case "saturday":
                    weekdayName = "شنبه";
                    break;
                case "sunday":
                    weekdayName = "یکشنبه";
                    break;
                case "monday":
                    weekdayName = "دوشنبه";
                    break;
                case "tuesday":
                    weekdayName = "سه شنبه";
                    break;
                case "wednesday":
                    weekdayName = "چهارشنبه";
                    break;
                case "thursday":
                    weekdayName = "پنجشنبه";
                    break;
                case "friday":
                    weekdayName = "جمعه";
                    break;

                default:
                    weekdayName = weekday;
                    break;
            }
            return weekdayName;
        }
        public static string StrMonth(string month)
        {
            month = ArabicAlpha(month);
            var monthName = "";
            switch (month)
            {
                case "فروردين":
                    monthName = "01";
                    break;
                case "ارديبهشت":
                    monthName = "02";
                    break;
                case "اردی‌بهشت":
                    monthName = "02";
                    break;
                case "خرداد":
                    monthName = "03";
                    break;
                case "تير":
                    monthName = "04";
                    break;
                case "مرداد":
                    monthName = "05";
                    break;
                case "شهريور":
                    monthName = "06";
                    break;
                case "مهر":
                    monthName = "07";
                    break;
                case "آبان":
                    monthName = "08";
                    break;
                case "آذر":
                    monthName = "09";
                    break;
                case "دي":
                    monthName = "10";
                    break;
                case "دی":
                    monthName = "10";
                    break;
                case "دى":
                    monthName = "10";
                    break;
                case "بهمن":
                    monthName = "11";
                    break;
                case "اسفند":
                    monthName = "12";
                    break;
                default:
                    monthName = month;
                    break;
            }
            return monthName;
        }
        public static string StrMonthName(string month)
        {
            month = ArabicAlpha(month);
            var monthName = "";
            switch (month)
            {
                case "01":
                    monthName = "فروردين";
                    break;
                case "1":
                    monthName = "فروردين";
                    break;
                case "02":
                    monthName = "ارديبهشت";
                    break;
                case "2":
                    monthName = "ارديبهشت";
                    break;
                case "03":
                    monthName = "خرداد";
                    break;
                case "3":
                    monthName = "خرداد";
                    break;
                case "04":
                    monthName = "تير";
                    break;
                case "4":
                    monthName = "تير";
                    break;
                case "05":
                    monthName = "مرداد";
                    break;
                case "5":
                    monthName = "مرداد";
                    break;
                case "06":
                    monthName = "شهريور";
                    break;
                case "6":
                    monthName = "شهريور";
                    break;
                case "07":
                    monthName = "مهر";
                    break;
                case "7":
                    monthName = "مهر";
                    break;
                case "08":
                    monthName = "آبان";
                    break;
                case "8":
                    monthName = "آبان";
                    break;
                case "09":
                    monthName = "آذر";
                    break;
                case "9":
                    monthName = "آذر";
                    break;
                case "10":
                    monthName = "دی";
                    break;
                case "11":
                    monthName = "بهمن";
                    break;
                case "12":
                    monthName = "اسفند";
                    break;
                default:
                    monthName = month;
                    break;
            }
            return monthName;
        }
        public static string StrDayOfMonthWord(string day)
        {
            day = ArabicAlpha(day);
            var dayName = "";
            switch (day)
            {
                case "01":
                    dayName = "یکم";
                    break;
                case "1":
                    dayName = "یکم";
                    break;
                case "02":
                    dayName = "دوم";
                    break;
                case "2":
                    dayName = "دوم";
                    break;
                case "03":
                    dayName = "سوم";
                    break;
                case "3":
                    dayName = "سوم";
                    break;
                case "04":
                    dayName = "چهارم";
                    break;
                case "4":
                    dayName = "چهارم";
                    break;
                case "05":
                    dayName = "پنجم";
                    break;
                case "5":
                    dayName = "پنجم";
                    break;
                case "06":
                    dayName = "ششم";
                    break;
                case "6":
                    dayName = "ششم";
                    break;
                case "07":
                    dayName = "هفتم";
                    break;
                case "7":
                    dayName = "هففتم";
                    break;
                case "08":
                    dayName = "هشتم";
                    break;
                case "8":
                    dayName = "هشتم";
                    break;
                case "09":
                    dayName = "نهم";
                    break;
                case "9":
                    dayName = "نهم";
                    break;
                case "10":
                    dayName = "دهم";
                    break;
                case "11":
                    dayName = "یازدهم";
                    break;
                case "12":
                    dayName = "دوازدهم";
                    break;
                case "13":
                    dayName = "سیزدهم";
                    break;
                case "14":
                    dayName = "چهاردهم";
                    break;
                case "15":
                    dayName = "پانزدهم";
                    break;
                case "16":
                    dayName = "شانزدهم";
                    break;
                case "17":
                    dayName = "هفدهم";
                    break;
                case "18":
                    dayName = "هجدهم";
                    break;
                case "19":
                    dayName = "نوزدهم";
                    break;
                case "20":
                    dayName = "بیستم";
                    break;
                case "21":
                    dayName = "بیست و یکم";
                    break;
                case "22":
                    dayName = "بیست و دوم";
                    break;
                case "23":
                    dayName = "بیست و سوم";
                    break;
                case "24":
                    dayName = "بیست و چهارم";
                    break;
                case "25":
                    dayName = "بیست و پنجم";
                    break;
                case "26":
                    dayName = "بیست و ششم";
                    break;
                case "27":
                    dayName = "بیست و هفتم";
                    break;
                case "28":
                    dayName = "بیست و هشتم";
                    break;
                case "29":
                    dayName = "بیست و نهم";
                    break;
                case "30":
                    dayName = "سی ام";
                    break;
                case "31":
                    dayName = "سی و یکم";
                    break;

                default:
                    dayName = day;
                    break;
            }
            return dayName;
        }
        public static string GetOnTimeDate(DateTime date)
        {
            var dt = DateTime.Now;
            TimeSpan difference = dt - date;
            var time = Class_Static.RoundTenNum(dt.Hour) + ":" + Class_Static.RoundTenNum(dt.Minute);
            int minute = Convert.ToInt32(difference.TotalMinutes);
            int hour = Convert.ToInt32(difference.Hours);
            int days = Convert.ToInt32(difference.TotalDays);
            if (dt.Year == date.Year && dt.Month == date.Month && dt.Day == date.Day)
            {
                if (hour == 0)
                {
                    return minute + " دقیقه " + " پیش ";
                }
                else
                {
                    return hour + " ساعت " + (minute % 60) + " دقیقه " + " پیش ";
                }

            }
            //if (difference.TotalDays > 0 && difference.TotalDays < 1)
            //{




            //}
            //else if (days == 1)
            //{
            //    return "دیروز"+" " + time;
            //}
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
        public static string GetAbsoluteTime(string time)
        {
            try
            {
                return Class_Static.RoundTenNum(time.Split(':')[0]) +
                      ":" + Class_Static.RoundTenNum(time.Split(':')[1]);

            }
            catch
            {

                return time.Substring(0, 2) + ":" + time.Substring(2, 2);
            }
        }
        public static string ArabicAlpha(string txt)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt))
                    return "";
                return txt.Replace("ی", "ي").Replace("ک", "ك");

            }
            catch (Exception)
            {
                return null;

            }
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
                return null;

            }
        }
        public static string ConvertToLatinNumberSam(string txt)
        {
            txt = txt
                .Replace("۰", "0")
                .Replace("۱", "1")
                .Replace("۲", "2")
                .Replace("۳", "3")
                .Replace("۴", "4")
                .Replace("۵", "5")
                .Replace("۶", "6")
                .Replace("v", "7")
                .Replace("۸", "8")
                .Replace("۹", "9")

                .Replace("٠", "0")
                .Replace("١", "1")
                .Replace("٢", "2")
                .Replace("٣", "3")
                .Replace("٤", "4")
                .Replace("٥", "5")
                .Replace("٦", "6")
                .Replace("٧", "7")
                .Replace("٨", "8")
                .Replace("٩", "9")


                .Replace("۰", "0")
                .Replace("۱", "1")
                .Replace("۲", "2")
                .Replace("۳", "3")
                .Replace("۴", "4")
                .Replace("۵", "5")
                .Replace("۶", "6")
                .Replace("۷", "7")
                .Replace("۸", "8")
                .Replace("۹", "9")


                .Replace("٠", "0")
                .Replace("١", "1")
                .Replace("٢", "2")
                .Replace("٣", "3")
                .Replace("٤", "4")
                .Replace("٥", "5")
                .Replace("٦", "6")
                .Replace("٧", "7")
                .Replace("٨", "8")
                .Replace("٩", "9");

            return txt;
        }
        public static string EnglishToPersianNumber(this string persianStr)
        {
            string result = persianStr
                .Replace("0", "۰")
                .Replace("1", "۱")
                .Replace("2", "۲")
                .Replace("3", "۳")
                .Replace("4", "۴")
                .Replace("5", "۵")
                .Replace("6", "۶")
                .Replace("7", "۷")
                .Replace("8", "۸")
                .Replace("9", "۹");

            return result;
        }
        public static string GetTime()
        {
            var dt = DateTime.Now;
            return (RoundTenNum(dt.Hour) + ":" + RoundTenNum(dt.Minute));
        }
        public static string ShortTxt(string txt, int lnth)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt))
                {
                    return "";
                }
                if (txt.Length > lnth)
                {
                    txt = txt.Trim().Replace('\r', ';').Replace('\n', ' ');

                    return txt.Substring(0, lnth) + "...";
                }
                else
                {
                    txt = txt.Trim().Replace('\r', ';').Replace('\n', ' ');

                    return txt;
                }
            }
            catch (Exception)
            {

                return txt;
            }
        }
        public static string GetDomainName(string url)
        {
            try
            {
                Uri myUri = new Uri(url);
                string host = myUri.Host;
                return host;
            }
            catch (Exception)
            {

                return "";
            }
        }
        public static string SplitTextByWord(string text, int count)
        {
            try
            {
                var strReturn = "";
                if (string.IsNullOrEmpty(text)) return "";

                //   strArr = text.Split(' ');
                var counter = 1;
                foreach (var item in text.Split(' '))
                {
                    if (counter <= count)
                    {

                        if (string.IsNullOrWhiteSpace(strReturn))
                        {
                            strReturn += item;
                        }
                        else
                        {
                            strReturn += " " + item;
                        }
                        counter++;
                    }
                    else
                    {
                        break;
                    }


                }
                return strReturn;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                return "";
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
        public static int ToInt(object s)
        {
            int i;
            if (int.TryParse(s.ToString(), out i)) return i;
            return 0;
        }
        public static int? ToNullableInt(string s)
        {
            int i;
            if (int.TryParse(s, out i)) return i;
            return null;
        }
        public static long GetIntFarsiDate(DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();

            var year = pc.GetYear(date).ToString();
            var month = RoundTenNum(pc.GetMonth(date));
            var day = RoundTenNum(pc.GetDayOfMonth(date));

            return Convert.ToInt64((year + month + day));
        }
        public static string GetFarsiDate(DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();


            var year = pc.GetYear(Convert.ToDateTime(date)).ToString();
            var month = RoundTenNum(pc.GetMonth(Convert.ToDateTime(date)));
            var day = RoundTenNum(pc.GetDayOfMonth(Convert.ToDateTime(date)));

            return (year + "/" + month + "/" + day);
        }
        public static string GetFarsiDateFull(DateTime date)
        {

            return Persia.Calendar.ConvertToPersian(Convert.ToDateTime(date)).ToString("N");
        }
        public static DateTime ConvertIntFarsiDate(string fDate)
        {
            PersianCalendar pc = new PersianCalendar();
            if (string.IsNullOrWhiteSpace(fDate.ToString()) || fDate.Length < 8)
                return DateTime.Now;
            if (fDate.Split('/').Count() > 1)
            {
                var dateSplit = fDate.Split('/');
                return pc.ToDateTime(Convert.ToInt32(RoundTenNum(dateSplit[0])),
                    Convert.ToInt32(RoundTenNum(dateSplit[1])),
                    Convert.ToInt32(RoundTenNum(dateSplit[2])),
                    0, 0, 0, 0, 0);
            }
            //   fDate = fDate.Replace("/", "");

            return pc.ToDateTime(Convert.ToInt32(fDate.Substring(0, 4)), Convert.ToInt32(fDate.Substring(4, 2)), Convert.ToInt32(fDate.Substring(6, 2)), 0, 0, 0, 0, 0);



        }
        public static string ConvertStrFarsiDate(string fDate)
        {


            return fDate.Substring(0, 4) + "/" + fDate.Substring(4, 2) + "/" + fDate.Substring(6, 2);



        }

        public static string RemoveScriptsTags(string txt)
        {
            try
            {
                //
                //Regex rRemScript = new Regex(@"<script [^>]*>[\s\S]*?</script>");
                //Regex rRemStyles = new Regex(@"<style [^>]*>[\s\S]*?</style>");
                //Regex rRemStyles2 = new Regex(@"<!--[if gte mso 9]>[\s\S]*?<![endif]-->");

                //txt= rRemScript.Replace(txt, "");
                //txt = rRemStyles.Replace(txt, "");
                //txt = rRemStyles2.Replace(txt, "");
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(txt);

                //doc.DocumentNode.Descendants()
                //                .Where(n => n.Name == "script" || n.NodeType == HtmlNodeType.Comment)
                //                .ToList()
                //                .ForEach(n => n.Remove());
#pragma warning disable CS0219 // The variable 'finalText' is assigned but its value is never used
                var finalText = "";
#pragma warning restore CS0219 // The variable 'finalText' is assigned but its value is never used
                foreach (var node in doc.DocumentNode.Descendants())
                {
                    if (node.NodeType == HtmlNodeType.Comment || node.Name == "script")
                    {
                        node.ParentNode.RemoveChild(node);

                    }

                }
                return doc.DocumentNode.InnerText;
            }
            catch
            {
                return txt;
            }

        }

        public static string ShamisiBySlash(string fDate)
        {
            if (string.IsNullOrWhiteSpace(fDate))
                return fDate;
            if (fDate.Split('/').Count() > 1)
            {
                return fDate;
            }
            else
            {
                return fDate.Substring(0, 4) + "/" + fDate.Substring(4, 2) + "/" + fDate.Substring(6, 2);
            }
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

        public static string ShamisiWithoutSlash(string fDate)
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
        public static string GetAbsoulateTextFromHtmlNode(HtmlNode nodeBody)
        {
            var retText = "";
            try
            {
                nodeBody.Descendants()
         .Where(n => n.Name == "script" || n.Name == "style")
         .ToList()
         .ForEach(n => n.Remove());

                //foreach (var comment in nodeBody.ChildNodes.ToList())
                //{
                //    try
                //    {

                //        if (!comment.InnerText.StartsWith("DOCTYPE"))
                //            comment.ParentNode.RemoveChild(comment);


                //    }
                //    catch
                //    {
                //        continue;
                //    }
                //}
                try
                {
                    foreach (var comment in nodeBody.ChildNodes.ToList())
                    {
                        try
                        {
                            if (comment.NodeType == HtmlNodeType.Comment)
                                comment.ParentNode.RemoveChild(comment);

                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
                catch
                {

                }
                try
                {
                    foreach (var comment in nodeBody.SelectNodes("//comment()").ToList())
                    {
                        try
                        {
                            comment.ParentNode.RemoveChild(comment);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
                catch
                {

                }

                retText = nodeBody.InnerText.Trim();
                try
                {
                    retText = Regex.Replace(retText, @"<[^>]+>|&nbsp;|&zwnj;", "").Trim();
                }
                catch
                {

                }
                try
                {
                    retText = Regex.Replace(retText, @"\s{2,}", " ").Trim();

                }
                catch
                {

                }
                return retText;

            }
            catch
            {
                return nodeBody.InnerText;
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
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
            return obj;
        }
        public static string GetIPAddress()
        {
            try
            {
                string strHostName = System.Net.Dns.GetHostName();
#pragma warning disable CS0618 // 'Dns.Resolve(string)' is obsolete: 'Resolve is obsoleted for this type, please use GetHostEntry instead. http://go.microsoft.com/fwlink/?linkid=14202'
                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName().ToString());
#pragma warning restore CS0618 // 'Dns.Resolve(string)' is obsolete: 'Resolve is obsoleted for this type, please use GetHostEntry instead. http://go.microsoft.com/fwlink/?linkid=14202'
                IPAddress ipAddress = ipHostInfo.AddressList[0];

                return ipAddress.ToString();
            }
            catch
            {
                return "";
            }
        }
        public static string GetUserIP()
        {
            try
            {
                HttpContext currentContext = HttpContext.Current;
                string ipAddress = currentContext.Request.UserHostAddress;
                return ipAddress;
            }
            catch
            {
                return "";
            }
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "";
        }
        public static List<Tbl_News_Type> LoadRelatedNews(List<Tbl_News_Type> GroupNewsList)
        {

            int MaxCharSize = 250;

            int ComparePercent = 45;

            List<Tbl_News_Type> compiledNewsList = new List<Tbl_News_Type>();
            List<Tbl_News_Type> newsList1 = GroupNewsList;
            List<Tbl_News_Type> newsList2 = newsList1;
            var allNewsList = newsList1;
            var listDup = new List<int>();
            for (int f = 0; f < newsList1.Count; f++)
            {
                // اگر خبر قبلا مرتبط خبری شده بود دیگر خبر را بررسی نکن
                if (listDup.Any(t => t == newsList1[f].NewsID)) continue;
                string firstText1;
                string firstTitle1 = SpaceToWord(newsList1[f].NewsTitle);
                //بررسی اینکه خبر لید دارد یا نه
                if (newsList1[f].NewsLead != string.Empty)
                    if (newsList1[f].NewsLead.Length > MaxCharSize)
                    {
                        string str = newsList1[f].NewsLead.Substring(0, MaxCharSize);
                        firstText1 = SpaceToWord(newsList1[f].NewsTitle + " " + str);
                    }
                    else
                    {
                        string str = string.Empty;
                        if (newsList1[f].NewsBody.Length > MaxCharSize)
                            str = newsList1[f].NewsBody.Substring(0, MaxCharSize);
                        else str = newsList1[f].NewsBody;
                        firstText1 = SpaceToWord(newsList1[f].NewsTitle + " " + str);
                    }
                else
                {
                    int charLocation = newsList1[f].NewsBody.IndexOf(".", StringComparison.Ordinal);

                    if (newsList1[f].NewsBody.Length > MaxCharSize)
                        firstText1 = SpaceToWord(newsList1[f].NewsTitle + " " + newsList1[f].NewsBody.Substring(0, MaxCharSize));
                    else
                        firstText1 = SpaceToWord(newsList1[f].NewsTitle + " " + newsList1[f].NewsBody);
                }
                string firstText2 = removeIligalCharacter(firstText1);
                var firstList = firstText2.Split(new string[] { " " },
                      StringSplitOptions.RemoveEmptyEntries).ToList();
                var firstTiteList = removeIligalCharacter(firstTitle1).Split(new string[] { " " },
                      StringSplitOptions.RemoveEmptyEntries).ToList();
                var firstListTemp = new List<string>();
                var firstTitleListTemp = new List<string>();
                //جهت مشخص نمودن کلمات اصلی متن
                //به ازای کلمات جداشده ترکیب عنوان و خلاصه و متن خبر
                foreach (var s in firstList)
                {
                    //آیا کلمه اضافه وجود دارد
                    if (IsContainPrepositionPersianWord(s) == false)
                    {
                        firstListTemp.Add(s);
                    }
                }
                //به ازای کلمات جداشده فقط عنوان خبر
                foreach (var s in firstTiteList)
                {
                    //آیا کلمه اضافه وجود دارد
                    if (IsContainPrepositionPersianWord(s) == false)
                    {
                        firstTitleListTemp.Add(s);
                    }
                }



                for (int g = 0; g < newsList2.Count; g++)
                {
                    if (listDup.Any(t => t == newsList2[g].NewsID)) continue;
                    string secondText1;
                    string secondTitle1 = SpaceToWord(newsList2[g].NewsTitle);
                    if (newsList2[g].NewsLead != string.Empty)
                        if (newsList2[g].NewsLead.Length > MaxCharSize)
                        {
                            string str = newsList2[g].NewsLead.Substring(0, MaxCharSize);
                            secondText1 = SpaceToWord(newsList2[g].NewsTitle + " " + str);
                        }
                        else
                        {
                            string str = string.Empty;
                            if (newsList2[g].NewsBody.Length > MaxCharSize)
                                str = newsList2[g].NewsBody.Substring(0, MaxCharSize);
                            else
                                str = newsList2[g].NewsLead;
                            secondText1 = SpaceToWord(newsList2[g].NewsTitle + " " + str);
                        }
                    else
                    {
                        int charLocation = newsList2[g].NewsBody.IndexOf(".", StringComparison.Ordinal);

                        if (newsList2[g].NewsBody.Length > MaxCharSize)
                            secondText1 = SpaceToWord(newsList2[g].NewsTitle + " " + newsList2[g].NewsBody.Substring(0, MaxCharSize));
                        else secondText1 = SpaceToWord(newsList2[g].NewsTitle + " " + newsList2[g].NewsBody);

                    }
                    string secondText2 = removeIligalCharacter(secondText1);
                    var secondList = secondText2.Split(new string[] { " " },
                        StringSplitOptions.RemoveEmptyEntries).ToList();
                    var secondTitleList = secondTitle1.Split(new string[] { " " },
                       StringSplitOptions.RemoveEmptyEntries).ToList();
                    var secondTitleListTemp = new List<string>();
                    var secondListTemp = new List<string>();
                    foreach (var h in secondList)
                    {
                        if (IsContainPrepositionPersianWord(h) != true)
                        {
                            secondListTemp.Add(h);

                        }

                    }
                    foreach (var h in secondTitleList)
                    {
                        if (IsContainPrepositionPersianWord(h) != true)
                        {
                            secondTitleListTemp.Add(h);

                        }

                    }

                    int firstLength = firstListTemp.Count;
                    int secondLength = secondListTemp.Count;
                    int found = 0;
                    double relatedPercent = 0;

                    int firstTitleLength = firstTitleListTemp.Count;
                    int secondTitleLength = secondTitleListTemp.Count;
                    int foundTitle = 0;
                    double relatedTitlePercent = 0;

                    if (newsList1[f].NewsID != newsList2[g].NewsID)
                    {
                        #region CheckTitleNewsText
                        for (int j = 0; j < secondTitleLength; j++)
                        {
                            if (firstTitleListTemp.Any(t => t == secondTitleListTemp[j]))
                                foundTitle++;
                        }

                        if (foundTitle > 0)
                        {
                            relatedTitlePercent = (foundTitle * 100) / secondTitleLength;
                        }
                        if (relatedTitlePercent >= 80)
                        {
                            listDup.Add(newsList2[g].NewsID);
                            if (compiledNewsList.Any(t => t.NewsID == newsList1[f].NewsID))
                            {
                                var RELATE = compiledNewsList.
                                      FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                      .RelateListIds;

                                var RELATE_Strings = compiledNewsList.
                                    FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                    .RelateListStrings;

                                if (RELATE == null)
                                    RELATE = new List<int>();

                                if (RELATE_Strings == null)
                                    RELATE_Strings = new List<string>();

                                RELATE.Add(newsList2[g].NewsID);

                                RELATE_Strings.Add(newsList2[g].NewsID + "$" + newsList2[g].SiteTitle + "$" + newsList2[g].NewsTitle);

                                compiledNewsList.
                                    FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                    .RelateListIds = RELATE;

                                compiledNewsList.
                                    FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                    .RelateListStrings = RELATE_Strings;
                            }
                            else
                            {

                                var news = newsList1[f];

                                var REl = new List<int>();
                                REl.Add(newsList2[g].NewsID);

                                var REl_Strings = new List<string>();
                                REl_Strings.Add(newsList2[g].NewsID + "$" + newsList2[g].SiteTitle + "$" + newsList2[g].NewsTitle);


                                news.RelateListIds = REl;
                                news.RelateListStrings = REl_Strings;
                                compiledNewsList.Add(news);
                            }
                        }
                        else
                        {
                            #region CheckFullNewsText
                            for (int j = 0; j < secondLength; j++)
                            {
                                if (firstListTemp.Any(t => t == secondListTemp[j]))
                                    found++;
                            }

                            if (found > 0)
                            {
                                relatedPercent = (found * 100) / secondLength;
                            }
                            if (relatedPercent >= ComparePercent)
                            {
                                listDup.Add(newsList2[g].NewsID);
                                if (compiledNewsList.Any(t => t.NewsID == newsList1[f].NewsID))
                                {
                                    var RELATE = compiledNewsList.
                                          FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                          .RelateListIds;

                                    var RELATE_Strings = compiledNewsList.
                                        FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                        .RelateListStrings;

                                    if (RELATE == null)
                                        RELATE = new List<int>();

                                    if (RELATE_Strings == null)
                                        RELATE_Strings = new List<string>();

                                    RELATE.Add(newsList2[g].NewsID);

                                    RELATE_Strings.Add(newsList2[g].NewsID + "$" + newsList2[g].SiteTitle + "$" + newsList2[g].NewsTitle);

                                    compiledNewsList.
                                        FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                        .RelateListIds = RELATE;

                                    compiledNewsList.
                                        FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                        .RelateListStrings = RELATE_Strings;
                                }
                                else
                                {

                                    var news = newsList1[f];

                                    var REl = new List<int>();
                                    REl.Add(newsList2[g].NewsID);

                                    var REl_Strings = new List<string>();
                                    REl_Strings.Add(newsList2[g].NewsID + "$" + newsList2[g].SiteTitle + "$" + newsList2[g].NewsTitle);


                                    news.RelateListIds = REl;
                                    news.RelateListStrings = REl_Strings;
                                    compiledNewsList.Add(news);
                                }
                            }
                            else
                            {
                                if (compiledNewsList.Any(t => t.NewsID == newsList1[f].NewsID))
                                {


                                }
                                else
                                {
                                    var news = newsList1[f];

                                    compiledNewsList.Add(news);
                                }
                            }
                            #endregion

                            //////////if (compiledNewsList.Any(t => t.NewsID == newsList1[f].NewsID))
                            //////////{


                            //////////}
                            //////////else
                            //////////{
                            //////////    var news = newsList1[f];

                            //////////    compiledNewsList.Add(news);
                            //////////}
                        }
                        #endregion


                    }

                }
            }
            allNewsList = allNewsList.Where(i => listDup.Contains(i.NewsID)).ToList();

            //compiledNewsList = compiledNewsList.OrderBy(d => d.SortOrder).ThenBy(d => d.NewsDateIndex).ThenBy(d => d.NewsTime).ToList();
            List<Tbl_News_Type> finalList = new List<Tbl_News_Type>();
            finalList = compiledNewsList;
            foreach (var i in compiledNewsList.ToList())
            {
                if (listDup.Any(t => t == i.NewsID))
                {
                    var find = finalList.Find(j => j.NewsID == i.NewsID);
                    try
                    {
                        // var dupped = finalList.FirstOrDefault(t => t.NewsID == find.NewsID);
                        foreach (var item in finalList)
                        {
                            if (item.NewsID != find.NewsID && item.RelateListIds.Any(t => t == find.NewsID))
                            {
                                if (find.RelateListIds.Count > 0)
                                {
                                    var oldRelate = item.RelateListIds;
                                    var newsRelate = oldRelate;
                                    foreach (var item0 in find.RelateListIds)
                                    {
                                        if (!newsRelate.Any(t => t == item0))
                                        {
                                            newsRelate.Add(item0);
                                        }
                                    }
                                    var oldRelateStr = item.RelateListStrings;
                                    var newsRelateStr = oldRelateStr;
                                    foreach (var item0 in find.RelateListStrings)
                                    {
                                        if (!newsRelateStr.Any(t => t == item0))
                                        {
                                            newsRelateStr.Add(item0);
                                        }
                                    }
                                    finalList.FirstOrDefault(t => t.NewsID == item.NewsID).RelateListIds = newsRelate;
                                    finalList.FirstOrDefault(t => t.NewsID == item.NewsID).RelateListStrings = newsRelateStr;
                                }

                            }

                        }
                        finalList.Remove(find);
                    }
                    catch { continue; }

                }
            }
            return finalList;
        }
        //public static List<Tbl_News_Type> LoadRelatedNews(List<Tbl_News_Type> GroupNewsList)
        //{

        //    int MaxCharSize = 250;

        //    int ComparePercent = 45;

        //    List<Tbl_News_Type> compiledNewsList = new List<Tbl_News_Type>();
        //    List<Tbl_News_Type> newsList1 = GroupNewsList;
        //    List<Tbl_News_Type> newsList2 = newsList1;
        //    var allNewsList = newsList1;
        //    var listDup = new List<int>();
        //    for (int f = 0; f < newsList1.Count; f++)
        //    {
        //        // اگر خبر قبلا مرتبط خبری شده بود دیگر خبر را بررسی نکن
        //        if (listDup.Any(t => t == newsList1[f].NewsID)) continue;
        //        string first1;

        //        if (newsList1[f].NewsLead != string.Empty)
        //            if (newsList1[f].NewsLead.Length > MaxCharSize)
        //            {
        //                string str = newsList1[f].NewsLead.Substring(0, MaxCharSize);
        //                first1 = SpaceToWord(newsList1[f].NewsTitle + " " + str);
        //            }
        //            else
        //            {
        //                string str = string.Empty;
        //                if (newsList1[f].NewsBody.Length > MaxCharSize)
        //                    str = newsList1[f].NewsBody.Substring(0, MaxCharSize);
        //                else str = newsList1[f].NewsBody;
        //                first1 = SpaceToWord(newsList1[f].NewsTitle + " " + str);
        //            }
        //        else
        //        {
        //            int charLocation = newsList1[f].NewsBody.IndexOf(".", StringComparison.Ordinal);

        //            //if (charLocation > 0)
        //            //{
        //            if (newsList1[f].NewsBody.Length > MaxCharSize)
        //                first1 = SpaceToWord(newsList1[f].NewsTitle + " " + newsList1[f].NewsBody.Substring(0, MaxCharSize));
        //            else
        //                first1 = SpaceToWord(newsList1[f].NewsTitle + " " + newsList1[f].NewsBody);
        //            //}
        //            //else first1 = SpaceToWord(newsList1[f].NewsTitle);

        //        }
        //        string first2 = removeIligalCharacter(first1);
        //        var firstList = first2.Split(new string[] { " " },
        //              StringSplitOptions.RemoveEmptyEntries).ToList();
        //        var firstListTemp = new List<string>();
        //        foreach (var s in firstList)
        //        {
        //            if (IsContainPrepositionPersianWord(s) == false)
        //            {
        //                firstListTemp.Add(s);
        //            }

        //        }
        //        for (int g = 0; g < newsList2.Count; g++)
        //        {
        //            if (listDup.Any(t => t == newsList2[g].NewsID)) continue;
        //            string second1;
        //            if (newsList2[g].NewsLead != string.Empty)
        //                if (newsList2[g].NewsLead.Length > MaxCharSize)
        //                {
        //                    string str = newsList2[g].NewsLead.Substring(0, MaxCharSize);
        //                    second1 = SpaceToWord(newsList2[g].NewsTitle + " " + str);
        //                }
        //                else
        //                {
        //                    string str = string.Empty;
        //                    if (newsList2[g].NewsBody.Length > MaxCharSize)
        //                        str = newsList2[g].NewsBody.Substring(0, MaxCharSize);
        //                    else
        //                        str = newsList2[g].NewsLead;
        //                    second1 = SpaceToWord(newsList2[g].NewsTitle + " " + str);
        //                }
        //            else
        //            {
        //                int charLocation = newsList2[g].NewsBody.IndexOf(".", StringComparison.Ordinal);

        //                //if (charLocation > 0)
        //                //{
        //                if (newsList2[g].NewsBody.Length > MaxCharSize)
        //                    second1 = SpaceToWord(newsList2[g].NewsTitle + " " + newsList2[g].NewsBody.Substring(0, MaxCharSize));
        //                else second1 = SpaceToWord(newsList2[g].NewsTitle + " " + newsList2[g].NewsBody);
        //                //}
        //                //else second1 = SpaceToWord(newsList2[g].NewsTitle);

        //            }
        //            string second2 = removeIligalCharacter(second1);
        //            var secondList = second2.Split(new string[] { " " },
        //                StringSplitOptions.RemoveEmptyEntries).ToList();
        //            var secondListTemp = new List<string>();
        //            foreach (var h in secondList)
        //            {
        //                if (IsContainPrepositionPersianWord(h) != true)
        //                {
        //                    secondListTemp.Add(h);

        //                }

        //            }
        //            // secondList= secondListTemp;

        //            int firstLength = firstListTemp.Count;
        //            int secondLength = secondListTemp.Count;
        //            int found = 0;
        //            double relatedPercent = 0;

        //            //compiledNewsList = newsList1;
        //            if (newsList1[f].NewsID != newsList2[g].NewsID)
        //            {


        //                for (int j = 0; j < secondLength; j++)
        //                {
        //                    if (firstListTemp.Any(t => t == secondListTemp[j]))
        //                        found++;
        //                }

        //                if (found > 0)
        //                {
        //                    relatedPercent = (found * 100) / secondLength;
        //                }
        //                if (relatedPercent >= ComparePercent)
        //                {
        //                    listDup.Add(newsList2[g].NewsID);
        //                    if (compiledNewsList.Any(t => t.NewsID == newsList1[f].NewsID))
        //                    {
        //                        var RELATE = compiledNewsList.
        //                              FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
        //                              .RelateListIds;

        //                        var RELATE_Strings = compiledNewsList.
        //                            FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
        //                            .RelateListStrings;

        //                        if (RELATE == null)
        //                            RELATE = new List<int>();

        //                        if (RELATE_Strings == null)
        //                            RELATE_Strings = new List<string>();

        //                        RELATE.Add(newsList2[g].NewsID);

        //                        RELATE_Strings.Add(newsList2[g].NewsID + "$" + newsList2[g].SiteTitle + "$" + newsList2[g].NewsTitle);

        //                        compiledNewsList.
        //                            FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
        //                            .RelateListIds = RELATE;

        //                        compiledNewsList.
        //                            FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
        //                            .RelateListStrings = RELATE_Strings;
        //                    }
        //                    else
        //                    {

        //                        var news = newsList1[f];

        //                        var REl = new List<int>();
        //                        REl.Add(newsList2[g].NewsID);

        //                        var REl_Strings = new List<string>();
        //                        REl_Strings.Add(newsList2[g].NewsID + "$" + newsList2[g].SiteTitle + "$" + newsList2[g].NewsTitle);


        //                        news.RelateListIds = REl;
        //                        news.RelateListStrings = REl_Strings;



        //                        compiledNewsList.Add(news);
        //                    }
        //                }
        //                else
        //                {
        //                    if (compiledNewsList.Any(t => t.NewsID == newsList1[f].NewsID))
        //                    {


        //                    }
        //                    else
        //                    {
        //                        var news = newsList1[f];

        //                        compiledNewsList.Add(news);
        //                    }
        //                }
        //            }

        //        }
        //    }
        //    allNewsList = allNewsList.Where(i => listDup.Contains(i.NewsID)).ToList();

        //    //compiledNewsList = compiledNewsList.OrderBy(d => d.SortOrder).ThenBy(d => d.NewsDateIndex).ThenBy(d => d.NewsTime).ToList();
        //    List<Tbl_News_Type> finalList = new List<Tbl_News_Type>();
        //    finalList = compiledNewsList;
        //    foreach (var i in compiledNewsList.ToList())
        //    {
        //        if (listDup.Any(t => t == i.NewsID))
        //        {
        //            var find = finalList.Find(j => j.NewsID == i.NewsID);
        //            try
        //            {
        //                // var dupped = finalList.FirstOrDefault(t => t.NewsID == find.NewsID);
        //                foreach (var item in finalList)
        //                {
        //                    if (item.NewsID != find.NewsID && item.RelateListIds.Any(t => t == find.NewsID))
        //                    {
        //                        if (find.RelateListIds.Count > 0)
        //                        {
        //                            var oldRelate = item.RelateListIds;
        //                            var newsRelate = oldRelate;
        //                            foreach (var item0 in find.RelateListIds)
        //                            {
        //                                if (!newsRelate.Any(t => t == item0))
        //                                {
        //                                    newsRelate.Add(item0);
        //                                }
        //                            }
        //                            var oldRelateStr = item.RelateListStrings;
        //                            var newsRelateStr = oldRelateStr;
        //                            foreach (var item0 in find.RelateListStrings)
        //                            {
        //                                if (!newsRelateStr.Any(t => t == item0))
        //                                {
        //                                    newsRelateStr.Add(item0);
        //                                }
        //                            }
        //                            finalList.FirstOrDefault(t => t.NewsID == item.NewsID).RelateListIds = newsRelate;
        //                            finalList.FirstOrDefault(t => t.NewsID == item.NewsID).RelateListStrings = newsRelateStr;
        //                        }

        //                    }

        //                }
        //                finalList.Remove(find);
        //            }
        //            catch { continue; }

        //        }
        //    }
        //    return finalList;
        //}
        public static List<Tbl_News_Type> LoadRelatedNewsTimeline(List<Tbl_News_Type> GroupNewsList)
        {

            int MaxCharSize = 250;

            int ComparePercent = 45;

            List<Tbl_News_Type> compiledNewsList = new List<Tbl_News_Type>();
            List<Tbl_News_Type> newsList1 = GroupNewsList;
            List<Tbl_News_Type> newsList2 = newsList1;
            var allNewsList = newsList1;
            var listDup = new List<int>();
            for (int f = 0; f < newsList1.Count; f++)
            {
                // اگر خبر قبلا مرتبط خبری شده بود دیگر خبر را بررسی نکن
                if (listDup.Any(t => t == newsList1[f].NewsID)) continue;
                string first1;
                if (newsList1[f].NewsLead != string.Empty)
                    if (newsList1[f].NewsLead.Length > MaxCharSize)
                    {
                        string str = newsList1[f].NewsLead.Substring(0, MaxCharSize);
                        first1 = SpaceToWord(newsList1[f].NewsTitle + " " + str);
                    }
                    else
                    {
                        string str = string.Empty;
                        if (newsList1[f].NewsBody.Length > MaxCharSize)
                            str = newsList1[f].NewsBody.Substring(0, MaxCharSize);
                        else str = newsList1[f].NewsBody;
                        first1 = SpaceToWord(newsList1[f].NewsTitle + " " + str);
                    }
                else
                {
                    int charLocation = newsList1[f].NewsBody.IndexOf(".", StringComparison.Ordinal);

                    //if (charLocation > 0)
                    //{
                    if (newsList1[f].NewsBody.Length > MaxCharSize)
                        first1 = SpaceToWord(newsList1[f].NewsTitle + " " + newsList1[f].NewsBody.Substring(0, MaxCharSize));
                    else
                        first1 = SpaceToWord(newsList1[f].NewsTitle + " " + newsList1[f].NewsBody);
                    //}
                    //else first1 = SpaceToWord(newsList1[f].NewsTitle);

                }
                string first2 = removeIligalCharacter(first1);
                var firstList = first2.Split(new string[] { " " },
                      StringSplitOptions.RemoveEmptyEntries).ToList();
                var firstListTemp = new List<string>();
                foreach (var s in firstList)
                {
                    if (IsContainPrepositionPersianWord(s) == false)
                    {
                        firstListTemp.Add(s);
                    }

                }
                for (int g = 0; g < newsList2.Count; g++)
                {
                    if (listDup.Any(t => t == newsList2[g].NewsID)) continue;
                    string second1;
                    if (newsList2[g].NewsLead != string.Empty)
                        if (newsList2[g].NewsLead.Length > MaxCharSize)
                        {
                            string str = newsList2[g].NewsLead.Substring(0, MaxCharSize);
                            second1 = SpaceToWord(newsList2[g].NewsTitle + " " + str);
                        }
                        else
                        {
                            string str = string.Empty;
                            if (newsList2[g].NewsBody.Length > MaxCharSize)
                                str = newsList2[g].NewsBody.Substring(0, MaxCharSize);
                            else
                                str = newsList2[g].NewsLead;
                            second1 = SpaceToWord(newsList2[g].NewsTitle + " " + str);
                        }
                    else
                    {
                        int charLocation = newsList2[g].NewsBody.IndexOf(".", StringComparison.Ordinal);

                        //if (charLocation > 0)
                        //{
                        if (newsList2[g].NewsBody.Length > MaxCharSize)
                            second1 = SpaceToWord(newsList2[g].NewsTitle + " " + newsList2[g].NewsBody.Substring(0, MaxCharSize));
                        else second1 = SpaceToWord(newsList2[g].NewsTitle + " " + newsList2[g].NewsBody);
                        //}
                        //else second1 = SpaceToWord(newsList2[g].NewsTitle);

                    }
                    string second2 = removeIligalCharacter(second1);
                    var secondList = second2.Split(new string[] { " " },
                        StringSplitOptions.RemoveEmptyEntries).ToList();
                    var secondListTemp = new List<string>();
                    foreach (var h in secondList)
                    {
                        if (IsContainPrepositionPersianWord(h) != true)
                        {
                            secondListTemp.Add(h);

                        }

                    }
                    // secondList= secondListTemp;

                    int firstLength = firstListTemp.Count;
                    int secondLength = secondListTemp.Count;
                    int found = 0;
                    double relatedPercent = 0;

                    //compiledNewsList = newsList1;
                    if (newsList1[f].NewsID != newsList2[g].NewsID)
                    {


                        for (int j = 0; j < secondLength; j++)
                        {
                            if (firstListTemp.Any(t => t == secondListTemp[j]))
                                found++;
                        }

                        if (found > 0)
                        {
                            relatedPercent = (found * 100) / secondLength;
                        }
                        if (relatedPercent >= ComparePercent)
                        {
                            listDup.Add(newsList2[g].NewsID);
                            if (compiledNewsList.Any(t => t.NewsID == newsList1[f].NewsID))
                            {
                                var RELATE = compiledNewsList.
                                      FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                      .RelateListIds;

                                var RELATE_Strings = compiledNewsList.
                                    FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                    .RelateListStrings;

                                if (RELATE == null)
                                    RELATE = new List<int>();

                                if (RELATE_Strings == null)
                                    RELATE_Strings = new List<string>();

                                RELATE.Add(newsList2[g].NewsID);

                                RELATE_Strings.Add(newsList2[g].NewsID + "$" + newsList2[g].SiteTitle + "$" + newsList2[g].NewsTitle);

                                compiledNewsList.
                                    FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                    .RelateListIds = RELATE;

                                compiledNewsList.
                                    FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                    .RelateListStrings = RELATE_Strings;
                                compiledNewsList.
                                    FirstOrDefault(t => t.NewsID == newsList1[f].NewsID).RelateListIdsCount = compiledNewsList.
                                    FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                    .RelateListIds.Count;
                            }
                            else
                            {

                                var news = newsList1[f];
                                // news.NewsID = newsList1[f].NewsID;
                                //  news.NewsTitle = newsList1[f].NewsTitle;
                                // news.NewsLead = newsList1[f].NewsLead;
                                //  news.NewsBody = newsList1[f].NewsBody;
                                //  news.NewsDateIndex = newsList1[f].NewsDateIndex;

                                var REl = new List<int>();
                                REl.Add(newsList2[g].NewsID);

                                var REl_Strings = new List<string>();
                                //REl_Strings.Add(newsList2[g].SiteTitle);
                                REl_Strings.Add(newsList2[g].NewsID + "$" + newsList2[g].SiteTitle + "$" + newsList2[g].NewsTitle);


                                news.RelateListIds = REl;
                                news.RelateListStrings = REl_Strings;
                                try { news.RelateListIdsCount = news.RelateListIds.Count; } catch { news.RelateListIdsCount = 0; }



                                compiledNewsList.Add(news);
                            }
                        }
                        else
                        {
                            if (compiledNewsList.Any(t => t.NewsID == newsList1[f].NewsID))
                            {


                            }
                            else
                            {
                                var news = newsList1[f];

                                compiledNewsList.Add(news);
                            }
                        }
                    }

                }
                string relatedSites = "";
                string relatedIds = "";

                if (compiledNewsList.
                                   FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                   .RelateListStrings != null)
                {
                    foreach (var r in compiledNewsList.
                                       FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                       .RelateListStrings)
                    {
                        relatedSites += r.Split('$')[1] + "،";
                        relatedIds += r.Split('$')[0] + ",";
                    }
                    relatedSites = relatedSites.Substring(0, relatedSites.Length - 1);
                    relatedSites = relatedSites.Replace("،", "<i class='fa fa-arrow-left' ></i>");
                    relatedIds = relatedIds.Substring(0, relatedIds.Length - 1);
                }
                compiledNewsList.FirstOrDefault(t => t.NewsID == newsList1[f].NewsID).RelateListSites = relatedSites;
                compiledNewsList.FirstOrDefault(t => t.NewsID == newsList1[f].NewsID).RelatedNewsStringIds = relatedIds;
            }
            // compiledNewsList = compiledNewsList.Where(i => listDup.Contains(i.NewsID)).ToList();

            compiledNewsList = compiledNewsList.OrderBy(d => d.NewsDateIndex).ThenBy(d => d.NewsTime).ToList();
            List<Tbl_News_Type> finalList = new List<Tbl_News_Type>();
            finalList = compiledNewsList;
            foreach (var i in compiledNewsList.ToList())
            {
                if (listDup.Any(t => t == i.NewsID))
                {
                    var find = finalList.Find(j => j.NewsID == i.NewsID);
                    try
                    {
                        // var dupped = finalList.FirstOrDefault(t => t.NewsID == find.NewsID);
                        foreach (var item in finalList)
                        {
                            if (item.NewsID != find.NewsID && item.RelateListIds.Any(t => t == find.NewsID))
                            {
                                if (find.RelateListIds.Count > 0)
                                {
                                    var oldRelate = item.RelateListIds;
                                    var newsRelate = oldRelate;
                                    foreach (var item0 in find.RelateListIds)
                                    {
                                        if (!newsRelate.Any(t => t == item0))
                                        {
                                            newsRelate.Add(item0);
                                        }
                                    }
                                    var oldRelateStr = item.RelateListStrings;
                                    var newsRelateStr = oldRelateStr;
                                    foreach (var item0 in find.RelateListStrings)
                                    {
                                        if (!newsRelateStr.Any(t => t == item0))
                                        {
                                            newsRelateStr.Add(item0);
                                        }
                                    }
                                    finalList.FirstOrDefault(t => t.NewsID == item.NewsID).RelateListIds = newsRelate;
                                    finalList.FirstOrDefault(t => t.NewsID == item.NewsID).RelateListStrings = newsRelateStr;
                                }

                            }

                        }
                        finalList.Remove(find);
                    }
                    catch { continue; }

                }
            }
            return finalList;
        }
        public static List<Tbl_News_Type> LoadRelatedNews2(List<Tbl_News_Type> GroupNewsList)
        {
            List<Tbl_News_Type> finalList = new List<Tbl_News_Type>();
            List<int> relatedNewsId = new List<int>();
            foreach (var n in GroupNewsList)
            {
                string[] ids = null;
                if (n.RelatedNewsStringIds != null && n.RelatedNewsStringIds != string.Empty)
                {
                    if (n.RelatedNewsStringIds.Contains(","))
                    {
                        ids = n.RelatedNewsStringIds.Split(',');
                        for (int j = 0; j < ids.Count(); j++)
                        {
                            relatedNewsId.Add(Convert.ToInt32(ids[j]));
                        }
                    }
                    else
                    {
                        relatedNewsId.Add(Convert.ToInt32(n.RelatedNewsStringIds));
                    }
                }
            }

            finalList = GetFromData(GroupNewsList.OrderBy(d => d.SortOrder).ThenBy(d => d.NewsDateIndex).
                ThenBy(d => d.NewsTime).ToList()).Where(i => !relatedNewsId.Contains(i.NewsID)).ToList();
            return finalList;

        }
        public static List<Tbl_News_Type> GetFromData(List<Tbl_News_Type> news)
        {
            List<Tbl_News_Type> list = new List<Tbl_News_Type>();
            foreach (var r in news)
            {
                try
                {
                    Tbl_News_Type n = new Tbl_News_Type();
                    try { n.NewsID = r.NewsID; } catch { n.NewsID = 0; }
                    try { n.CreateUser = r.CreateUser; } catch { }
                    try { n.SiteLogo = r.SiteLogo; } catch { }
                    try { n.NewsTitle = r.NewsTitle; } catch { }
                    try { n.NewsLead = r.NewsLead; } catch { }
                    try { n.NewsBody = r.NewsBody; } catch { }
                    try { n.SiteTitle = r.SiteTitle; } catch { n.SiteTitle = ""; }
                    try { n.NewsGroupOrder = Class_Static.ToNullableInt(r.NewsGroupOrder.ToString()); } catch { }
                    try { n.SiteID = r.SiteID; } catch { }
                    try { n.GroupOrder = Class_Static.ToNullableInt(r.GroupOrder.ToString()); } catch { }
                    try { n.GroupName = r.GroupName; } catch { }
                    try { n.NewsDateIndex = r.NewsDateIndex; } catch { }
                    try { n.KeywordId = r.KeywordId; } catch { }
                    try { n.GroupId = r.GroupId; } catch { }
                    try { n.NewsLinkCRC = r.NewsLinkCRC; } catch { }
                    try { n.IsFeederNews = r.IsFeederNews; } catch { }
                    try { n.SortOrder = r.SortOrder; } catch { }
                    try { n.Color = r.Color; } catch { }
                    try { n.IsSelected = r.IsSelected; } catch { }
                    try { n.NewsValue = r.NewsValue; } catch { }
                    try { n.CreateDate = r.CreateDate; } catch { }
                    try { n.NewsTime = r.NewsTime; } catch { }
                    try { n.NewsDate = r.NewsDate; } catch { }
                    try { n.KeyIds = r.KeyIds; } catch { }
                    try { n.NewsLink = r.NewsLink; } catch { }
                    try { n.NewsPicture = r.NewsPicture; } catch { }
                    try { n.RelatedNewsStringIds = r.RelatedNewsStringIds; } catch { n.RelatedNewsStringIds = ""; }
                    string[] ids = null;
                    if (r.RelatedNewsStringIds != null && r.RelatedNewsStringIds != string.Empty)
                    {
                        n.RelateListIds = new List<int>();
                        if (n.RelatedNewsStringIds.Contains(","))
                        {

                            ids = n.RelatedNewsStringIds.Split(',');
                            for (int j = 0; j < ids.Count(); j++)
                            {

                                n.RelateListIds.Add(Convert.ToInt32(ids[j]));
                            }
                        }
                        else
                        {
                            n.RelateListIds.Add(Convert.ToInt32(n.RelatedNewsStringIds));
                        }
                    }
                    list.Add(n);
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }
            }
            return list;
        }
        public static string SpaceToWord(string input)
        {
            var lst = new List<string>() { ".", ",", "!", "-", "\u2000", ")", "(", "[", "]", "{", "}" , ":" ,
                "،","‌","%","*","_","<" , ">" , "»","«","=","\"","/","؟","?","\r\n","\r","\n"
            };
            input = input.Replace("\r\n", " ");
            input = input.Replace("\r", " ");
            input = input.Replace("\n", " ");
            input = input.Trim();
            foreach (var sec in lst)
            {

                input = input.Replace(sec, " " + sec + " ");

            }

            input = input + " ";
            return input;
        }
        public static string removeIligalCharacter(string input)
        {
            var lst = new List<string>() { ".", ",", "!", "-", "\u2000", ")", "(", "[", "]", "{", "}" , ":" ,
                "،","‌","%","*","_","<" , ">" , "»","«","=","\"","/","؟","?","\r\n","\r","\n"
            };
            input = input.Replace("\r\n", " ");
            input = input.Replace("\r", " ");
            input = input.Replace("\n", " ");
            input = input.Trim();
            foreach (var sec in lst)
                input = input.Replace(sec, " ");

            return input;
        }
        public static bool IsContainPrepositionPersianWord(string input)
        {
            List<string> lst = new List<string>() { "از", "الی", "الاّ", "اندر", "با", "بدون", "بر", "برای", "به", "بهر", "بی" , "تا" ,
                "جز","‌چون","در","ضد","علیه","غیر" , "مانند" , "مثل","مگر","واسه‎ی","غیراز","اگر","اما","باری","پس","تا","چه","هریک","ای","ضمن","های","حالی",
                "خواه","‌زیرا","که","لیکن","نیز","و" , "ولی" , "هم","یا","‎آن‌","ازبس","اگرچه","چنان‌چه","چنان‌که","اکنون","ازاین‌روی","آن‌گاه","این","را","روی","رو","آنها"
            };
            bool result = false;
            foreach (string s in lst)
                if (input == s)
                {
                    result = true;
                    if (result == true)
                        break;
                }
            return result;
        }
        public static string HighlightKeywords(Tbl_RssKeywords currentKey, string txt, List<Tbl_RssKeywords> keywords)
        {
            var item_Key = "";
            if (string.IsNullOrWhiteSpace(txt))
            {
                return "";
            }
            txt = txt.Replace(@"http://www.talanews.com/fa/plugins/content/jumultithumb/img.php?src=Li4vLi4vLi4vaW1hZ2VzL3N0b3JpZXMvYmFua29fYmltZS9KQUhBTkdJUkkuanBnJmFtcDt3PTgwMCZhbXA7aD02MDAmYW1wO3E9MTAw", "");
            txt = txt.Replace("<br/>", "");
            txt = txt.Replace("<br>", "");
            HtmlNode txtHtml = HtmlNode.CreateNode(txt);
            string newsMerge = Class_Static.PersianAlpha(Class_Static.GetAbsoulateTextFromHtmlNode(txtHtml));

            newsMerge = newsMerge.Replace("-", " ");
            newsMerge = newsMerge.Replace(".", " . ");
            newsMerge = newsMerge.Replace(":", " : ");
            newsMerge = newsMerge.Replace("?", " ? ");
            newsMerge = newsMerge.Replace("!", " ! ");
            newsMerge = newsMerge.Replace("،", " ، ");
            newsMerge = " " + newsMerge + " ";

            var findKeywords = new List<string>();
            foreach (var key in keywords)
            {
                if (!key.KeywordName.Contains('+'))
                {
                    //foreach (var itemKey in key.KeywordName)
                    //{

                    item_Key = Class_Static.PersianAlpha((key.KeywordName)).ToLower() + "";

                    if (newsMerge.IndexOf(" " + item_Key + " ") > -1)
                    {
                        if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(item_Key.Trim())))
                        {
                            findKeywords.Add(Class_Static.PersianAlpha(item_Key.Trim()));
                        }

                    }
                    //}
                }
                else
                {
                    foreach (var itemKey in key.KeywordName.Split('+'))
                    {

                        item_Key = Class_Static.PersianAlpha((itemKey)).ToLower() + "";

                        if (newsMerge.IndexOf(" " + item_Key + " ") > -1)
                        {
                            if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(item_Key.Trim())))
                            {
                                findKeywords.Add(Class_Static.PersianAlpha(item_Key.Trim()));
                            }

                        }
                    }
                }



            }


            if (currentKey != null)
            {

                if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(currentKey.KeywordName.Trim())))
                {
                    findKeywords.Add(Class_Static.PersianAlpha(currentKey.KeywordName.Trim()));

                }

            }
            foreach (var item in findKeywords)
            {
                try
                {
                    var txthighlight = (item + "").Trim();
                    newsMerge = newsMerge.Replace(item, "<span class='highlight'>" + txthighlight + "</span>");
                }
                catch
                {

                }
            }

            return newsMerge.Trim();
        }

        public static string HighlightSocialKeywords(Tbl_SocialMediaKey currentKey, string txt, List<Tbl_SocialMediaKey> keywords)
        {
            var item_Key = "";
            if (string.IsNullOrWhiteSpace(txt))
            {
                return "";
            }
            txt = txt.Replace(@"http://www.talanews.com/fa/plugins/content/jumultithumb/img.php?src=Li4vLi4vLi4vaW1hZ2VzL3N0b3JpZXMvYmFua29fYmltZS9KQUhBTkdJUkkuanBnJmFtcDt3PTgwMCZhbXA7aD02MDAmYW1wO3E9MTAw", "");
            txt = txt.Replace("<br/>", "");
            txt = txt.Replace("<br>", "");
            HtmlNode txtHtml = HtmlNode.CreateNode(txt);
            string newsMerge = Class_Static.PersianAlpha(Class_Static.GetAbsoulateTextFromHtmlNode(txtHtml));

            newsMerge = newsMerge.Replace("-", " ");
            newsMerge = newsMerge.Replace(".", " . ");
            newsMerge = newsMerge.Replace(":", " : ");
            newsMerge = newsMerge.Replace("?", " ? ");
            newsMerge = newsMerge.Replace("!", " ! ");
            newsMerge = newsMerge.Replace("،", " ، ");
            newsMerge = " " + newsMerge + " ";

            var findKeywords = new List<string>();
            foreach (var key in keywords)
            {
                if (key.Title.Contains('+'))
                {
                    //foreach (var itemKey in key.KeywordName)
                    //{

                    item_Key = Class_Static.PersianAlpha((key.Title)).ToLower() + "";

                    if (newsMerge.IndexOf(" " + item_Key + " ") > -1)
                    {
                        if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(item_Key.Trim())))
                        {
                            findKeywords.Add(Class_Static.PersianAlpha(item_Key.Trim()));
                        }

                    }
                    //}
                }
                else
                {
                    foreach (var itemKey in key.Title.Split('+'))
                    {

                        item_Key = Class_Static.PersianAlpha((itemKey)).ToLower() + "";

                        if (newsMerge.IndexOf(" " + item_Key + " ") > -1)
                        {
                            if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(item_Key.Trim())))
                            {
                                findKeywords.Add(Class_Static.PersianAlpha(item_Key.Trim()));
                            }

                        }
                    }
                }



            }


            if (currentKey != null)
            {

                if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(currentKey.Title.Trim())))
                {
                    findKeywords.Add(Class_Static.PersianAlpha(currentKey.Title.Trim()));

                }

            }
            foreach (var item in findKeywords)
            {
                try
                {
                    var txthighlight = (item + "").Trim();
                    newsMerge = newsMerge.Replace(item, "<span class='highlight'>" + txthighlight + "</span>");
                }
                catch
                {

                }
            }

            return newsMerge.Trim();
        }
        public static string HighlightKeywordsBultanMedia(Tbl_RssKeywords currentKey, string txt, List<Tbl_RssKeywords> keywords)
        {
            var item_Key = "";
            if (string.IsNullOrWhiteSpace(txt))
            {
                return "";
            }
            txt = txt.Replace(@"http://www.talanews.com/fa/plugins/content/jumultithumb/img.php?src=Li4vLi4vLi4vaW1hZ2VzL3N0b3JpZXMvYmFua29fYmltZS9KQUhBTkdJUkkuanBnJmFtcDt3PTgwMCZhbXA7aD02MDAmYW1wO3E9MTAw", "");
            //HtmlNode txtHtml = HtmlNode.CreateNode(txt);
            string newsMerge = Class_Static.PersianAlpha(txt);

            newsMerge = newsMerge.Replace("-", " ");
            newsMerge = newsMerge.Replace(".", " . ");
            newsMerge = newsMerge.Replace(":", " : ");
            newsMerge = newsMerge.Replace("?", " ? ");
            newsMerge = newsMerge.Replace("!", " ! ");
            newsMerge = newsMerge.Replace("،", " ، ");
            newsMerge = " " + newsMerge + " ";

            var findKeywords = new List<string>();
            foreach (var key in keywords)
            {
                if (!key.KeywordName.Contains('+'))
                {
                    //foreach (var itemKey in key.KeywordName)
                    //{

                    item_Key = Class_Static.PersianAlpha((key.KeywordName)).ToLower() + "";

                    if (newsMerge.IndexOf(" " + item_Key + " ") > -1)
                    {
                        if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(item_Key.Trim())))
                        {
                            findKeywords.Add(Class_Static.PersianAlpha(item_Key.Trim()));
                        }

                    }
                    //}
                }
                else
                {
                    foreach (var itemKey in key.KeywordName.Split('+'))
                    {

                        item_Key = Class_Static.PersianAlpha((itemKey)).ToLower() + "";

                        if (newsMerge.IndexOf(" " + item_Key + " ") > -1)
                        {
                            if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(item_Key.Trim())))
                            {
                                findKeywords.Add(Class_Static.PersianAlpha(item_Key.Trim()));
                            }

                        }
                    }
                }



            }


            if (currentKey != null)
            {

                if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(currentKey.KeywordName.Trim())))
                {
                    findKeywords.Add(Class_Static.PersianAlpha(currentKey.KeywordName.Trim()));

                }

            }
            foreach (var item in findKeywords)
            {
                try
                {
                    var txthighlight = (item + "").Trim();
                    newsMerge = newsMerge.Replace(item, "<span class='highlight'>" + txthighlight + "</span>");
                }
                catch
                {

                }
            }

            return newsMerge.Trim();
        }
        public static string HighLight(string txt, string key)
        {
            var item_Key = "";
            string newsMerge = Class_Static.PersianAlpha(txt);

            newsMerge = newsMerge.Replace("-", " ");
            newsMerge = newsMerge.Replace(".", " . ");
            newsMerge = newsMerge.Replace(":", " : ");
            newsMerge = newsMerge.Replace("?", " ? ");
            newsMerge = newsMerge.Replace("!", " ! ");
            newsMerge = newsMerge.Replace("،", " ، ");
            newsMerge = " " + newsMerge + " ";

            var findKeywords = new List<string>();
            if (key.Contains('+'))
            {
                //foreach (var itemKey in key.KeywordName)
                //{

                item_Key = Class_Static.PersianAlpha((key)).ToLower() + "";

                if (newsMerge.IndexOf(" " + item_Key + " ") > -1)
                {
                    if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(item_Key.Trim())))
                    {
                        findKeywords.Add(Class_Static.PersianAlpha(item_Key.Trim()));
                    }

                }
                if (newsMerge.IndexOf(" #" + item_Key.Replace(" ", "_") + " ") > -1)
                {
                    if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(item_Key.Trim())))
                    {
                        findKeywords.Add(Class_Static.PersianAlpha("#" + item_Key.Trim().Replace(" ", "_")));
                    }

                }
                //}
            }
            else
            {
                foreach (var itemKey in key.Split('+'))
                {

                    item_Key = Class_Static.PersianAlpha((itemKey)).ToLower() + "";

                    if (newsMerge.IndexOf(" " + item_Key + " ") > -1)
                    {
                        if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(item_Key.Trim())))
                        {
                            findKeywords.Add(Class_Static.PersianAlpha(item_Key.Trim()));
                        }

                    }

                    if (newsMerge.IndexOf(" #" + item_Key.Replace(" ", "_") + " ") > -1)
                    {
                        if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(item_Key.Trim())))
                        {
                            findKeywords.Add(Class_Static.PersianAlpha("#" + item_Key.Trim().Replace(" ", "_")));
                        }

                    }
                }
            }


            foreach (var item in findKeywords)
            {
                try
                {
                    var txthighlight = (item + "").Trim();
                    newsMerge = newsMerge.Replace(item, "<span class='highlight'>" + txthighlight + "</span>");
                }
                catch
                {

                }
            }

            return newsMerge.Trim();

        }


        public static string PrepareNewsLead(object NewsLead)
        {
            NewsLead = Class_Static.PersianAlpha(NewsLead + "");
            NewsLead = (NewsLead + "").Replace(";;", "");
            NewsLead = (NewsLead + "").Replace("; ;", "");
            var str = "";

            var continueKeys = new string[] { ".", "!", "?", ",", "'", "''" };
            foreach (var strings in (NewsLead + "").Split('.'))
            {

                if (!string.IsNullOrWhiteSpace(strings))
                {
                    if (continueKeys.Any(t => t == strings.Trim()))
                    {
                        str += strings;
                    }
                    else
                    {
                        if (strings.Length < 150)
                        {
                            str += strings;

                        }
                        else
                        {
                            str += " <br/> " + strings + ".";
                        }
                    }
                }
            }
            return str;
        }
        public static string PrepareNewsBody(object newsBody)
        {
            newsBody = Class_Static.PersianAlpha(newsBody + "");
            newsBody = (newsBody + "").Replace(";;", "");
            newsBody = (newsBody + "").Replace("; ;", "");
            var str = "";
            //   var continueKeys = new string[] { ".", "!", "?", ",", "'", "''" };
            var continueKeys = new string[] { ".", };
#pragma warning disable CS0219 // The variable 'maxLength' is assigned but its value is never used
            var maxLength = 2500;
#pragma warning restore CS0219 // The variable 'maxLength' is assigned but its value is never used
            //  var maxLength = 25000;
            string[] bodyArray = (newsBody + "").Split('.');
            foreach (var strings in bodyArray)
            {
                //   if (str.Length > maxLength) continue;

                if (!string.IsNullOrWhiteSpace(strings))
                {

                    if (continueKeys.Any(t => t == strings.Trim()))
                    {
                        str += continueKeys;
                    }
                    else
                    {
                        if (strings.Length < 300)
                        {
                            str += strings;

                        }
                        else
                        {
                            str += " <br/> " + strings + ".";
                        }

                    }
                }
            }
            return str;
        }
        public static bool UrlExists(string url)
        {
            try
            {
                new System.Net.WebClient().DownloadData(url);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static List<Tbl_News_Type> GenerateNewsTags(List<Tbl_News_Type> items, List<int?> panelIds)
        {

            Class_Keywords _clsKeyword = new Class_Keywords();
            var keywords = new List<Tbl_RssKeywords>();

            keywords = _clsKeyword.GetRssKeywordByPanelIds(panelIds);

            foreach (var item in items)
            {
                if (item.NewsGroupOrder != null)
                {
                    var selectedKey = keywords.FirstOrDefault(t => t.GroupOrder == item.NewsGroupOrder);
                    if (selectedKey != null)
                    {
                        try
                        {
                            item.GroupOrder = (selectedKey.GroupOrder);
                            item.GroupName = (selectedKey.GroupName + "");
                            item.NewsKeyTagsOrder = Convert.ToInt32(selectedKey.OrderItem);
                            item.NewsKeyGroupsOrder = Convert.ToInt32(selectedKey.GroupOrder);
                            try
                            {
                                item.OrderItem = Convert.ToInt32(selectedKey.OrderItem);
                            }
                            catch { item.OrderItem = 0; }
                            //  item.NewsKeyTagsOrder = Convert.ToInt32(orderedKey.OrderItem);
                            // item.NewsKeyGroupsOrder = Convert.ToInt32(orderedKey.GroupOrder);
                        }
                        catch
                        {

                        }
                        continue;

                    }
                }


                var newsKeyTags = new List<int>();
                var newsKeyGroups = new List<int>();
                string newsMerge = Class_Static.PersianAlpha(item.NewsTitle + " " + item.NewsLead + " " + item.NewsBody).ToLower().Trim();


                newsMerge = newsMerge.Replace("-", " ");
                newsMerge = newsMerge.Replace(".", " . ");
                newsMerge = newsMerge.Replace(":", " : ");
                newsMerge = newsMerge.Replace("?", " ? ");
                newsMerge = newsMerge.Replace("!", " ! ");
                newsMerge = newsMerge.Replace("،", " ، ");
                newsMerge = newsMerge.Replace(",", " , ");
                newsMerge = newsMerge.Replace("»", " » ");
                newsMerge = newsMerge.Replace("«", " « ");
                newsMerge = newsMerge.Replace("(", " ( ");
                newsMerge = newsMerge.Replace(")", " ) ");
                newsMerge = newsMerge.Replace("}", " } ");
                newsMerge = newsMerge.Replace("{", " { ");
                newsMerge = newsMerge.Replace("*", " * ");
                newsMerge = newsMerge.Replace("<", " < ");
                newsMerge = newsMerge.Replace(">", " > ");
                newsMerge = newsMerge.Replace("/", " / ");
                //newsMerge = newsMerge.Replace("\", " \\ ");

                newsMerge = " " + newsMerge + " ";



                string findKeywords = "";
                var dic = new Dictionary<int, int?>();
                foreach (var key in keywords)
                {
                    // if (key.OrderItem == null) key.OrderItem = 0;
                    if (key.GroupOrder == null) key.GroupOrder = 0;
                    try
                    {
                        key.KeywordName = Class_Static.PersianAlpha((key.KeywordName)).ToLower().Trim();
                        var spils = key.KeywordName.Split(new string[] { "+" }, StringSplitOptions.RemoveEmptyEntries); ;

                        var findCount = 0;
                        foreach (var spilItem in spils)
                        {
                            if (newsMerge.IndexOf(" " + spilItem.Trim() + " ") > -1)
                            {
                                findCount++;

                            }

                        }
                        if (findCount == spils.Count())
                        {
                            newsKeyTags.Add(Convert.ToInt32(key.KeyId));

                            newsKeyGroups.Add(Convert.ToInt32(key.GroupOrder));

                            if (!dic.Any(t => t.Key == key.KeyId))
                            {
                                dic.Add(key.KeyId, key.PanelId);
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }

                try
                {
                    var currentKey = keywords.FirstOrDefault(t => t.KeyId == Convert.ToInt32(item.KeywordId));
                    //    if (currentKey.OrderItem == null) currentKey.OrderItem = 0;
                    if (currentKey.GroupOrder == null) currentKey.GroupOrder = 0;
                    if (currentKey != null)
                    {
                        if (findKeywords.IndexOf(" " + currentKey.KeywordName + " ") == -1)
                        {
                            dic.Add(currentKey.KeyId, currentKey.PanelId);

                            newsKeyTags.Add(Convert.ToInt32(currentKey.KeyId));

                            newsKeyGroups.Add(Convert.ToInt32(currentKey.GroupOrder));
                        }

                    }

                }
                catch
                {

                }


                item.NewsKeyTags = newsKeyTags;
                item.NewsKeyGroups = newsKeyGroups;


                //   var resultKey = newsKeyTags.GroupBy(t => t).OrderByDescending(t => t.Count()).Select(g => g.First()).ToList();
                //   var orderedKey = keywords.FirstOrDefault(t => t.KeyId == resultKey.FirstOrDefault());
                //var resultKey = newsKeyTags.Where(t=>t);
                var orderedKey = keywords.FirstOrDefault(t => t.GroupOrder == newsKeyGroups.OrderBy(n => n).ToList().FirstOrDefault());

                try
                {
                    item.GroupOrder = (orderedKey.GroupOrder);
                    item.NewsKeyTagsOrder = Convert.ToInt32(orderedKey.OrderItem);
                    item.NewsKeyGroupsOrder = Convert.ToInt32(orderedKey.GroupOrder);
                }
                catch
                {

                }



            }
            return items;



        }


        public static List<Tbl_SocialMediaPost> GenerateNewsTags1(List<Tbl_SocialMediaPost> items, List<int?> panelIds)
        {
            List<Tbl_SocialMediaPost> items2 = new List<Tbl_SocialMediaPost>();
            Class_Keywords _clsKeyword = new Class_Keywords();
            var keywords = new List<Tbl_SocialMediaKey>();

            keywords = _clsKeyword.GetSocialRssKeywordByPanelIds(panelIds);


            var keywords2 = new List<Tbl_NewsGroup>();

            keywords2 = _clsKeyword.GetgroupRssKeywordByPanelIds(panelIds);
            foreach (var item in keywords2)
            {




                var selectedKey = keywords.FirstOrDefault(t => t.GroupId_FK == item.GroupId);
                if (selectedKey != null)
                {
                    try
                    {
                        //item.GroupName = (selectedKey.);
                        item.ParminId = (selectedKey.ParminID_FK);
                        item.GroupId = Convert.ToInt32(selectedKey.GroupId_FK);
                        //item.NewsKeyGroupsOrder = Convert.ToInt32(selectedKey.GroupOrder);
                        //try
                        //{
                        //    item.OrderItem = Convert.ToInt32(selectedKey.OrderItem);
                        //}
                        //catch { item.OrderItem = 0; }
                        //  item.NewsKeyTagsOrder = Convert.ToInt32(orderedKey.OrderItem);
                        // item.NewsKeyGroupsOrder = Convert.ToInt32(orderedKey.GroupOrder);
                    }
                    catch
                    {

                    }
                    continue;
                }



            }
            foreach (var item in items)
            {


                var newsKeyTags = new List<int>();
                var newsKeyGroups = new List<int>();
                string newsMerge = Class_Static.PersianAlpha(item.Text).ToLower().Trim();


                newsMerge = newsMerge.Replace("-", " ");
                newsMerge = newsMerge.Replace(".", " . ");
                newsMerge = newsMerge.Replace(":", " : ");
                newsMerge = newsMerge.Replace("?", " ? ");
                newsMerge = newsMerge.Replace("!", " ! ");
                newsMerge = newsMerge.Replace("،", " ، ");
                newsMerge = newsMerge.Replace(",", " , ");
                newsMerge = newsMerge.Replace("»", " » ");
                newsMerge = newsMerge.Replace("«", " « ");
                newsMerge = newsMerge.Replace("(", " ( ");
                newsMerge = newsMerge.Replace(")", " ) ");
                newsMerge = newsMerge.Replace("}", " } ");
                newsMerge = newsMerge.Replace("{", " { ");
                newsMerge = newsMerge.Replace("*", " * ");
                newsMerge = newsMerge.Replace("<", " < ");
                newsMerge = newsMerge.Replace(">", " > ");
                newsMerge = newsMerge.Replace("/", " / ");
                //newsMerge = newsMerge.Replace("\", " \\ ");

                newsMerge = " " + newsMerge + " ";



                string findKeywords = "";
                var dic = new Dictionary<int, int?>();
                foreach (var key in keywords)
                {
                    // if (key.OrderItem == null) key.OrderItem = 0;

                    try
                    {
                        key.Title = Class_Static.PersianAlpha((key.Title)).ToLower().Trim();
                        var spils = key.Title.Split(new string[] { "+" }, StringSplitOptions.RemoveEmptyEntries); ;

                        var findCount = 0;
                        foreach (var spilItem in spils)
                        {
                            if (newsMerge.IndexOf(" " + spilItem.Trim() + " ") > -1)
                            {
                                findCount++;

                            }

                        }
                        if (findCount == spils.Count())
                        {
                            newsKeyTags.Add(Convert.ToInt32(key.SocialMediaKeyID));

                            newsKeyGroups.Add(Convert.ToInt32(key.GroupId_FK));

                            if (!dic.Any(t => t.Key == key.SocialMediaKeyID))
                            {
                                dic.Add(key.SocialMediaKeyID, key.ParminID_FK);
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }

                try
                {
                    var currentKey = keywords.FirstOrDefault(t => t.SocialMediaKeyID == Convert.ToInt32(item.SocialMediaKeyID_FK));
                    //    if (currentKey.OrderItem == null) currentKey.OrderItem = 0;
                    if (currentKey.GroupId_FK == null) currentKey.GroupId_FK = 0;
                    if (currentKey != null)
                    {
                        if (findKeywords.IndexOf(" " + currentKey.Title + " ") == -1)
                        {
                            dic.Add(currentKey.SocialMediaKeyID, currentKey.ParminID_FK);

                            newsKeyTags.Add(Convert.ToInt32(currentKey.SocialMediaKeyID));

                            newsKeyGroups.Add(Convert.ToInt32(currentKey.GroupId_FK));
                        }

                    }

                }
                catch
                {

                }


                //item.NewsKeyTags = newsKeyTags;
                //item.NewsKeyGroups = newsKeyGroups;


                //   var resultKey = newsKeyTags.GroupBy(t => t).OrderByDescending(t => t.Count()).Select(g => g.First()).ToList();
                //   var orderedKey = keywords.FirstOrDefault(t => t.KeyId == resultKey.FirstOrDefault());
                //var resultKey = newsKeyTags.Where(t=>t);
                var orderedKey = keywords.FirstOrDefault(t => t.GroupId_FK == newsKeyGroups.OrderBy(n => n).ToList().FirstOrDefault());

                //try
                //{
                //    item.GroupOrder = (orderedKey.GroupId_FK);
                //    item.NewsKeyTagsOrder = Convert.ToInt32(orderedKey.OrderItem);
                //    item.NewsKeyGroupsOrder = Convert.ToInt32(orderedKey.GroupOrder);
                //}
                //catch
                //{

                //}





            }
            return items;
        }

        public static string GetMediaType(object type)
        {
            if (type.ToString() == "1")
                return "سایت های خبری";
            else if (type.ToString() == "2")
                return "سایر اخبار";
            else if (type.ToString() == "3")
                return "تلگرام";
            else if (type.ToString() == "4")
                return "توییتر";
            else if (type.ToString() == "5")
                return "اینستاگرام";
            else return "سایت های خبری";
        }
        public static string ConvertIndexDateTimeToDateString(object DateTimeIndex)
        {
            string year = DateTimeIndex.ToString().Substring(0, 4);
            string month = DateTimeIndex.ToString().Substring(4, 2);
            string day = DateTimeIndex.ToString().Substring(6, 2);
            string hour = DateTimeIndex.ToString().Substring(8, 2);
            string minute = "";
            try { minute = DateTimeIndex.ToString().Substring(10, 2); } catch { minute = "00"; };
            return year + "/" + month + "/" + day;
        }
        public static string ConvertIndexDateTimeToTimeString(object DateTimeIndex)
        {
            string hour = DateTimeIndex.ToString().Substring(8, 2);
            string minute = DateTimeIndex.ToString().Substring(10, 2);
            return hour + ":" + minute;
        }
        public static string ConvertIndexDateTimeToDateString(string DateTimeIndex)
        {
            string year = DateTimeIndex.Substring(0, 4);
            string month = DateTimeIndex.Substring(4, 2);
            string day = DateTimeIndex.Substring(6, 2);
            string hour = DateTimeIndex.Substring(8, 2);
            string minute = DateTimeIndex.Substring(10, 2);
            return year + "/" + month + "/" + day;
        }
        public static string ConvertIndexDateTimeToTimeString(string DateTimeIndex)
        {

            string hour = DateTimeIndex.Substring(8, 2);
            string minute = DateTimeIndex.Substring(10, 2);
            return hour + ":" + minute;
        }
        public static string ConvertIndexDateTimeToDateTimeString(string DateTimeIndex)
        {
            string year = DateTimeIndex.Substring(0, 4);
            string month = DateTimeIndex.Substring(4, 2);
            string day = DateTimeIndex.Substring(6, 2);
            string hour = DateTimeIndex.Substring(8, 2);
            string minute = DateTimeIndex.Substring(10, 2);
            return year + "/" + month + "" + day + " " + hour + ":" + minute;
        }
        public static string ConvertIndexLongToIntString(string DateTimeIndex)
        {
            string year = DateTimeIndex.Substring(0, 4);
            string month = DateTimeIndex.Substring(4, 2);
            string day = DateTimeIndex.Substring(6, 2);
            return year + "" + month + "" + day;
        }



        public static void SendEmail(string FromEmail, string Password,
            string ToEmail, string Subject, string Message, int smtpPort, string DisplayName,
            string smtpServer, string cc = "", string bcc = "",
            bool smtpUseDefaultCredentials = true,
           bool enableSsl = false)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);

                smtpClient.Credentials = new System.Net.NetworkCredential(FromEmail, Password);
                smtpClient.UseDefaultCredentials = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

                //Setting From , To and CC
                mail.From = new MailAddress(FromEmail, DisplayName);
                mail.To.Add(new MailAddress(ToEmail));
                mail.CC.Add(new MailAddress(cc));

                smtpClient.Send(mail);
            }
            catch
            {
                try
                {
                    SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);

                    smtpClient.Credentials = new System.Net.NetworkCredential(FromEmail, Password);
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = false;
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

                    //Setting From , To and CC
                    mail.From = new MailAddress(FromEmail, DisplayName);
                    mail.To.Add(new MailAddress(ToEmail));
                    if (cc != "")
                        mail.CC.Add(new MailAddress(cc));

                    smtpClient.Send(mail);
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }
            }

        }


        public static string RemoveIligallUnicodeCharacter(string text)
        {
            System.Text.Encoding Utf8Encoder = System.Text.Encoding.GetEncoding("UTF-8",
new System.Text.EncoderReplacementFallback(string.Empty),
new System.Text.DecoderReplacementFallback(string.Empty)
);
            return Utf8Encoder.GetString(Utf8Encoder.GetBytes(text));
        }

        public class MyWebClient : WebClient
        {

            protected override WebRequest GetWebRequest(Uri address)
            {
                HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                request.ContentType = "application/json; charset=utf-8";


                return request;
            }
        }
        public static string ConvertIndexDateToCorrectDate(int DateIndex)
        {
            string index = DateIndex.ToString();
            string year = index.Substring(0, 4);
            string month = index.Substring(4, 2);
            string day = index.Substring(6, 2);
            return year + "/" + month + "/" + day;
        }
        public static string ConvertIndexDateTimeToCorrectDateTime(long DateTimeIndex)
        {
            string index = DateTimeIndex.ToString();
            string year = index.Substring(0, 4);
            string month = index.Substring(4, 2);
            string day = index.Substring(6, 2);
            string hour = index.Substring(8, 2);
            string min = index.Substring(10, 2);
            return year + "/" + month + "/" + day + " " + hour + ":" + min;
        }
        public static string RemoveLastCharacter(string input)
        {
            try { input = input.Remove(input.Length - 1); }
            catch { }
            return input;
        }

        public static void SetCookie(string key, string value, TimeSpan expires)
        {
            HttpCookie cookie = new HttpCookie(key, value);

            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                var cookieOld = HttpContext.Current.Request.Cookies[key];
                cookieOld.Expires = DateTime.Now.Add(expires);
                cookieOld.Value = cookie.Value;
                HttpContext.Current.Response.Cookies.Add(cookieOld);
            }
            else
            {
                cookie.Expires = DateTime.Now.Add(expires);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        public static void RemoveCookie(string key)
        {
            HttpCookie cookie = new HttpCookie(key, string.Empty);

            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                var cookieOld = HttpContext.Current.Request.Cookies[key];
                cookieOld.Expires = DateTime.Now.AddDays(-1);
                cookieOld.Value = cookie.Value;
                HttpContext.Current.Response.Cookies.Add(cookieOld);
            }
            else
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        public static string GetCookie(string key)
        {
            string value = string.Empty;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[key];

            if (cookie != null)
            {
                // For security purpose, we need to encrypt the value.
                HttpCookie decodedCookie = cookie;
                value = decodedCookie.Value;
            }
            else
            { value = string.Empty; }
            return value;
        }


    }
}