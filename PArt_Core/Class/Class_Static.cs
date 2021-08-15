using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Web;
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using Tweetinvi;
using HtmlAgilityPack;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PayeshEngine;

namespace PArtCore.Class
{
    public static class Class_Static
    {
        public static string conn = GlobalSetting.ConnectionServerPanel;
        public static String FTP_Url = "37.228.138.106/HostingSpaces/admin1/media.e-sepaar.net/wwwroot/voice";
        public static String FTP_UserName = "ftp_maysam";
        public static String FTP_Password = "1qaz@WSX1qaz";
        public static string SQLite_DBName = "db_text_2_speech.db3";
        public static string Application_Path = "";

        public static int? ToNullableInt(this string s)
        {
            int i;
            if (int.TryParse(s, out i)) return i;
            return null;
        }
        public static bool FTP_Upload(string filePath)
        {
            FileInfo fileInf = new FileInfo(filePath);

            string uri = "ftp://" + FTP_Url + "/" + fileInf.Name;
            var request = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + FTP_Url + "/" + fileInf.Name));
            // Get the object used to communicate with the server.
            //   FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(FTP_UserName, FTP_Password);
            request.KeepAlive = false;
            request.UseBinary = true;

            //    request.UsePassive = true;

            request.ContentLength = fileInf.Length;

            int buffLength = 2048;
            byte[] buff = new byte[buffLength];


            int contentLen;
            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
            FileStream fs = fileInf.OpenRead();
            try
            {
                // Stream to which the file to be upload is written
                System.IO.Stream strm = request.GetRequestStream();
                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);
                // Until Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the FTP Upload Stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();
                // MessageBox.Show("Upload OK");
                return true;
            }
            catch (Exception ex)
            {
                return false;
                // MessageBox.Show(ex.Message, "Upload Error");
            }

        }
        public static string RemoveTextUserIds(string text)
        {
            try
            {


                var finalTxt = "";
                var spilText = text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries); ;

                foreach (var spil in spilText)
                {
                    var txt = (spil + "").Trim();
                    if (txt.StartsWith("@"))
                    {
                        finalTxt += " ";
                    }
                    //else if(txt=="RT")
                    else
                    {
                        finalTxt += txt + " ";
                    }
                }
                return finalTxt;

            }
            catch
            {
                return text;
            }
        }
        public static IEnumerable<Tweetinvi.Models.ITweet> GetTweets(string tag, int ParminId = 0)
        {
            var OAuthConsumerKey = "";
            var OAuthConsumerSecret = "";
            var OAuthConsumerAccessToken = "";
            var OAuthConsumerAccessTokenSecret = "";
            if (ParminId != 0)
            {

                DataSet dsparminSocialAccount = null;
                List<Tbl_ParminSocialAccount_Type> ParminSocialAccountList;
                dsparminSocialAccount = (new Tbl_ParminSocialAccount_Type()).GetData();
                ParminSocialAccountList = Tbl_ParminSocialAccount_Type.GetFromDataRows(dsparminSocialAccount.Tables[0].Select());
                Tbl_ParminSocialAccount_Type socialAccount = ParminSocialAccountList.FirstOrDefault(i => i.ParminID == ParminId);
                OAuthConsumerKey = socialAccount.OAuthConsumerKey;
                OAuthConsumerSecret = socialAccount.OAuthConsumerSecret;
                OAuthConsumerAccessToken = socialAccount.OAuthConsumerAccessToken;
                OAuthConsumerAccessTokenSecret = socialAccount.OAuthConsumerAccessTokenSecret;
                var twitter = new Twitter
                {
                    OAuthConsumerKey = socialAccount.OAuthConsumerKey,
                    OAuthConsumerSecret = socialAccount.OAuthConsumerSecret,
                    OAuthConsumerAccessToken = socialAccount.OAuthConsumerAccessToken,
                    OAuthConsumerAccessTokenSecret = socialAccount.OAuthConsumerAccessTokenSecret
                };
            }
            else
            {
                OAuthConsumerKey = "8Yzm9cpILyQChhvTkYOHihWnU";
                OAuthConsumerSecret = "tU0Tyd4ogWqN7DjAIZf0Gg3S2Itfmc4LJYfqt9J0qfLR4K1VO1";
                OAuthConsumerAccessToken = "104894923-hjoEKDKIVd7AOSggqX3ovMeRnsFr9lArIyJn2TSE";
                OAuthConsumerAccessTokenSecret = "NS8lddFurezSWjnYP0Ha4dgPfiQjNvvHxGwgKnFWJ3RXx";
                var twitter = new Twitter
                {
                    OAuthConsumerKey = "8Yzm9cpILyQChhvTkYOHihWnU",
                    OAuthConsumerSecret = "tU0Tyd4ogWqN7DjAIZf0Gg3S2Itfmc4LJYfqt9J0qfLR4K1VO1",
                    OAuthConsumerAccessToken = "104894923-hjoEKDKIVd7AOSggqX3ovMeRnsFr9lArIyJn2TSE",
                    OAuthConsumerAccessTokenSecret = "NS8lddFurezSWjnYP0Ha4dgPfiQjNvvHxGwgKnFWJ3RXx"
                };
            }

            // var search = twitter.GetSearch("MaysammRajabi", txtTag.Text, 50, null, null).Result;

            Auth.SetUserCredentials(OAuthConsumerKey, OAuthConsumerSecret, OAuthConsumerAccessToken, OAuthConsumerAccessTokenSecret);

            return Search.SearchTweets(tag);
        }
        public static IEnumerable<Tweetinvi.Models.ITweet> GetTweetsSingle(string tag, int tweetid, int ParminId = 0)
        {
            var OAuthConsumerKey = "";
            var OAuthConsumerSecret = "";
            var OAuthConsumerAccessToken = "";
            var OAuthConsumerAccessTokenSecret = "";
            if (ParminId != 0)
            {

                DataSet dsparminSocialAccount = null;
                List<Tbl_ParminSocialAccount_Type> ParminSocialAccountList;
                dsparminSocialAccount = (new Tbl_ParminSocialAccount_Type()).GetData();
                ParminSocialAccountList = Tbl_ParminSocialAccount_Type.GetFromDataRows(dsparminSocialAccount.Tables[0].Select());
                Tbl_ParminSocialAccount_Type socialAccount = ParminSocialAccountList.FirstOrDefault(i => i.ParminID == ParminId);
                OAuthConsumerKey = socialAccount.OAuthConsumerKey;
                OAuthConsumerSecret = socialAccount.OAuthConsumerSecret;
                OAuthConsumerAccessToken = socialAccount.OAuthConsumerAccessToken;
                OAuthConsumerAccessTokenSecret = socialAccount.OAuthConsumerAccessTokenSecret;
                var twitter = new Twitter
                {
                    OAuthConsumerKey = socialAccount.OAuthConsumerKey,
                    OAuthConsumerSecret = socialAccount.OAuthConsumerSecret,
                    OAuthConsumerAccessToken = socialAccount.OAuthConsumerAccessToken,
                    OAuthConsumerAccessTokenSecret = socialAccount.OAuthConsumerAccessTokenSecret
                };
            }
            else
            {
                OAuthConsumerKey = "8Yzm9cpILyQChhvTkYOHihWnU";
                OAuthConsumerSecret = "tU0Tyd4ogWqN7DjAIZf0Gg3S2Itfmc4LJYfqt9J0qfLR4K1VO1";
                OAuthConsumerAccessToken = "104894923-hjoEKDKIVd7AOSggqX3ovMeRnsFr9lArIyJn2TSE";
                OAuthConsumerAccessTokenSecret = "NS8lddFurezSWjnYP0Ha4dgPfiQjNvvHxGwgKnFWJ3RXx";
                var twitter = new Twitter
                {
                    OAuthConsumerKey = "8Yzm9cpILyQChhvTkYOHihWnU",
                    OAuthConsumerSecret = "tU0Tyd4ogWqN7DjAIZf0Gg3S2Itfmc4LJYfqt9J0qfLR4K1VO1",
                    OAuthConsumerAccessToken = "104894923-hjoEKDKIVd7AOSggqX3ovMeRnsFr9lArIyJn2TSE",
                    OAuthConsumerAccessTokenSecret = "NS8lddFurezSWjnYP0Ha4dgPfiQjNvvHxGwgKnFWJ3RXx"
                };
            }

            // var search = twitter.GetSearch("MaysammRajabi", txtTag.Text, 50, null, null).Result;
            //Tweetinvi.Parameters.ISearchTweetsParameters a = new Tweetinvi.Parameters.ISearchTweetsParameters();
            //a.MaxId = tweetid;
            Auth.SetUserCredentials(OAuthConsumerKey, OAuthConsumerSecret, OAuthConsumerAccessToken, OAuthConsumerAccessTokenSecret);
            return Search.SearchTweets(tag);
        }

        public static bool IsInternetConnected()
        {
            //try
            //{
            //    using (var client = new WebClient())
            //    {

            //        using (var stream = client.OpenRead("http://www.google.com"))
            //        {

            //            return true;
            //        }
            //    }
            //}
            //catch
            //{
            //    return false;
            //}
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 5000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
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
        public static string ShamsiFull(DateTime now)
        {
            return Persia.Calendar.ConvertToPersian(now).ToString("N");

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
        public static string GetOnTimeDate(DateTime date)
        {
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
        public static string NormalizeText2Speech(string txt)
        {

            txt = txt.Replace("تراکنش", "تَراکُنِش");
            txt = txt.Replace("ارائه کننده", "ارائه‌کننده");
            txt = txt.Replace("سرمایه گذاری", "سرمایه‌گذاری");
            txt = txt.Replace("زیان دهی", "زیان‌دهی");
            txt = txt.Replace("خوش حساب", "خوش‌حساب");
            //  txt = txt.Replace("/", "،"); ariana Ariana_punc1 is ok but Ariana_punc2 need replace
            txt = txt.Replace("دندان پزشکی", "دندان‌پزشکی");
            txt = txt.Replace("مدد جویان", "مدد‌جویان");
            txt = txt.Replace("هفته نامه", "هفته‌مانه");
            txt = txt.Replace("بدون میل", "بدون‌مِیل");
            txt = txt.Replace("بیکار شده", "بیکار‌شده");
            txt = txt.Replace("بیان اینکه", "بیانِ اینکه");
            txt = txt.Replace("دست و پنجه", "دست‌و‌پنجه");
            txt = txt.Replace("تحویل شده", "تحویل‌شده");
            txt = txt.Replace("می گوید", "میگوید");

            return txt;
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
        public static string SplitTextByWord(string text, int count)
        {
            try
            {
                var strReturn = "";
                string[] strArr;
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
            catch (Exception ex)
            {

                return "";
            }

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
        private const string key = "AIzaSyDoE0akrBvl1f3IIRLpuXpVBDsxTfa4ceg";
        public static string GoogleShortenLink(string url)
        {
            string post = "{\"longUrl\": \"" + url + "\"}";
            string shortUrl = url;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/urlshortener/v1/url?key=" + key);

            try
            {
                request.ServicePoint.Expect100Continue = false;
                request.Method = "POST";
                request.ContentLength = post.Length;
                request.ContentType = "application/json";
                request.Headers.Add("Cache-Control", "no-cache");

                using (System.IO.Stream requestStream = request.GetRequestStream())
                {
                    byte[] postBuffer = Encoding.ASCII.GetBytes(post);
                    requestStream.Write(postBuffer, 0, postBuffer.Length);
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (System.IO.Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader responseReader = new StreamReader(responseStream))
                        {
                            string json = responseReader.ReadToEnd();
                            shortUrl = Regex.Match(json, @"""id"": ?""(?<id>.+)""").Groups["id"].Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // if Google's URL Shortner is down...
                //  System.Diagnostics.Debug.WriteLine(ex.Message);
                //  System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            return shortUrl;
        }
        public static List<string> RemoveEzafeStr(string inp)
        {

            string[] arr = {   "با", "از", "تا", "بی", "که",
                               "زیر", "روی", "را", "به", "ها",
                               "برای", "مگر", "جز", "الا", "چون",
                               "اندر", "غیر", "مانند", "نیز",
                               "بدون", "بهر", "هر","بیرون","پایین",
                               "پشت","پس","پیش","در","درون","کنار","مثل","الی" };

            inp = PersianAlpha(inp);

            List<string> resultList = new List<string>();

            foreach (string result in inp.Split(' ').ToList())
            {
                if (result == "") continue;

                var resultStr = PersianAlpha(result);
                var arrFind = Array.FindAll(arr, s => s.Equals(resultStr));
                if (arrFind.Length == 0)
                {
                    if (!resultList.Any(t => t == resultStr))
                        resultList.Add(PersianAlpha(resultStr));
                }
            }

            return resultList;
        }
        public static List<Tbl_News_Type> RemoveDuplicate(List<Tbl_News_Type> dt)
        {
            if (dt == null) return dt;
            if (dt.Count == 0) return dt;


            List<Tbl_News_Type> tempdt = new List<Tbl_News_Type>();
            //  tempdt = dt.DefaultView.ToTable();
            tempdt = dt;
            var tempdt2 = new List<Tbl_News_Type>();





            var lstDeletedNews = new List<int>();

            foreach (var newRow in tempdt.OrderByDescending(t => t.NewsRate))
            {
                var lstRelateList = new Dictionary<int, string>();
                var lstNewDeletedNews = new List<int>();

                try
                {
                    var newsID = newRow.NewsID;

                    // آیا در لیست خبرهای حذف شده می باشد؟
                    if (lstDeletedNews.Any(t => t == newsID)) continue;

                    if (string.IsNullOrWhiteSpace(newRow.NewsTitle)) continue;
                    //tempdt.Rows[i]["RelateList"] = "(";


                    var newsTitle = Class_Static.PersianAlpha(newRow.NewsTitle).Trim();

                    // عنوان خبر بدون حرف اضافه
                    var sourceKeys = Class_Static.RemoveEzafeStr(newsTitle);

                    string related = "";
                    List<int> RelatedIds = new List<int>();
                    foreach (var newsNew in tempdt.OrderByDescending(t => t.NewsRate))
                    {
                        var newsIDNew = newsNew.NewsID;
                        // آیا این خبر مقایسه ای در لیست خبرهای مرتبط خبر اصلی هست؟
                        if (lstNewDeletedNews.Any(t => t == newsIDNew)) continue;

                        if (newsID == newsIDNew) continue;
                        var newsTitleCompare = Class_Static.PersianAlpha(newsNew.NewsTitle).Trim();

                        // عنوان خبر بدون حرف اضافه
                        var disSource = Class_Static.RemoveEzafeStr(newsTitleCompare);
                        int findCount = 0;

                        // بررسی تعداد کلمات مشابه
                        foreach (string key in sourceKeys)
                        {
                            if (disSource.Where(p => p == key).Count() > 0)
                            {
                                findCount = findCount + 1;
                            }
                        }

                        if (findCount >= (sourceKeys.Count / 2))
                        {
                            lstRelateList.Add(newsNew.NewsID, newsNew.SiteTitle);
                            related += newsNew.SiteTitle + " - ";
                            RelatedIds.Add(newsNew.NewsID);
                            //tempdt.Rows[i]["RelateList"] += tempdt.Rows[b]["SiteTitle"].ToString() + " - ";
                            try
                            {
                                lstDeletedNews.Add(newsIDNew);
                                lstNewDeletedNews.Add(newsIDNew);
                                //   tempdt.Rows.Remove(tempdt.Rows[b]);


                            }
                            catch
                            {

                            }
                        }

                    }



                    if (related != "")
                    {
                        related = related.Trim();
                        related = related.Substring(0, related.Length - 1);
                        newRow.RelateList = "(" + related + ")";
                        newRow.RelateListIds = RelatedIds;

                    }
                    else
                    {
                        newRow.RelateList = "";
                        newRow.RelateListIds = RelatedIds;
                    }
                    tempdt2.Add(newRow);


                }
                catch
                {
                    continue;
                }
                //if (tempdt.Rows[i]["IsChild"].ToString() != "1")
                //{
                //    if ((tempdt.Rows[i]["NewsTitle"].ToString() == tempdt.Rows[i - 1]["NewsTitle"].ToString()) && (tempdt.Rows[i]["SiteTitle"].ToString() == tempdt.Rows[i - 1]["SiteTitle"].ToString()))
                //    {
                //        tempdt.Rows.Remove(tempdt.Rows[i]);
                //    }
                //}
            }



            var dtFinal = tempdt2;

            return dtFinal;
        }
        public static List<Tbl_News_Type> RemoveDuplicateSam(List<Tbl_News_Type> dt, int duplicatePercent, List<Tbl_Sites_Type> lstSites)
        {
            if (dt == null) return dt;
            if (dt.Count == 0) return dt;


            List<Tbl_News_Type> tempdt = new List<Tbl_News_Type>();
            //  tempdt = dt.DefaultView.ToTable();
            tempdt = dt;
            var tempdt2 = new List<Tbl_News_Type>();





            var lstDeletedNews = new List<int>();

            foreach (var newRow in tempdt.OrderByDescending(t => t.NewsRate))
            {
                var lstRelateList = new Dictionary<int, string>();
                var lstNewDeletedNews = new List<int>();

                try
                {
                    var newsID = newRow.NewsID;

                    // آیا در لیست خبرهای حذف شده می باشد؟
                    if (lstDeletedNews.Any(t => t == newsID)) continue;

                    if (string.IsNullOrWhiteSpace(newRow.NewsTitle)) continue;
                    //tempdt.Rows[i]["RelateList"] = "(";



                    var newsTitle = Class_Static.PersianAlpha(newRow.NewsTitle).Trim();
                    // حذف نام سایت ها در عنوان سایت
                    foreach (var site in lstSites)
                    {
                        try { newsTitle = newsTitle.Replace(site.SiteTitle, ""); }
                        catch { continue; }
                    }


                    // متن خبر بدون حرف اضافه و حروف تکراری
                    var sourceKeys = Class_Static.RemoveEzafeStr(newsTitle);

                    string related = "";
                    List<int> RelatedIds = new List<int>();
                    foreach (var newsNew in tempdt.OrderByDescending(t => t.NewsRate))
                    {
                        var newsIDNew = newsNew.NewsID;
                        // آیا این خبر مقایسه ای در لیست خبرهای مرتبط خبر اصلی هست؟
                        if (lstNewDeletedNews.Any(t => t == newsIDNew)) continue;

                        if (newsID == newsIDNew) continue;

                        var newsTitleCompare = Class_Static.PersianAlpha(newsNew.NewsTitle).Trim();

                        // حذف نام سایت ها در عنوان سایت
                        foreach (var site in lstSites)
                        {
                            try { newsTitleCompare = newsTitleCompare.Replace(site.SiteTitle, ""); }
                            catch { continue; }
                        }

                        // متن خبر بدون حرف اضافه و حروف تکراری
                        var disSource = Class_Static.RemoveEzafeStr(newsTitleCompare);
                        int findCount = 0;

                        // بررسی تعداد کلمات مشابه
                        foreach (string key in sourceKeys)
                        {
                            if (disSource.Where(p => p == key).Count() > 0)
                            {
                                findCount = findCount + 1;
                            }
                        }

                        // بیش از 50 درصد تشابه در متن خبر
                        var comparePercent = ((sourceKeys.Count * duplicatePercent) / 100);


                        if (findCount >= comparePercent)
                        {
                            lstRelateList.Add(newsNew.NewsID, newsNew.SiteTitle);
                            related += newsNew.SiteTitle + " - ";
                            RelatedIds.Add(newsNew.NewsID);
                            //tempdt.Rows[i]["RelateList"] += tempdt.Rows[b]["SiteTitle"].ToString() + " - ";
                            try
                            {
                                lstDeletedNews.Add(newsIDNew);
                                lstNewDeletedNews.Add(newsIDNew);
                                //   tempdt.Rows.Remove(tempdt.Rows[b]);


                            }
                            catch
                            {

                            }
                        }

                    }



                    if (related != "")
                    {
                        related = related.Trim();
                        related = related.Substring(0, related.Length - 1);
                        newRow.RelateList = "(" + related + ")";
                        newRow.RelateListIds = RelatedIds;

                    }
                    else
                    {
                        newRow.RelateList = "";
                        newRow.RelateListIds = RelatedIds;
                    }
                    tempdt2.Add(newRow);


                }
                catch
                {
                    continue;
                }
                //if (tempdt.Rows[i]["IsChild"].ToString() != "1")
                //{
                //    if ((tempdt.Rows[i]["NewsTitle"].ToString() == tempdt.Rows[i - 1]["NewsTitle"].ToString()) && (tempdt.Rows[i]["SiteTitle"].ToString() == tempdt.Rows[i - 1]["SiteTitle"].ToString()))
                //    {
                //        tempdt.Rows.Remove(tempdt.Rows[i]);
                //    }
                //}
            }



            var dtFinal = tempdt2;

            return dtFinal;
        }
        public static Tuple<int, int, int, int> GetNewsKeysAndKeysCount(List<Tbl_RssKeywords_Type> lstKeywords, int keyId, string title, string lead, string body, string panelIds)
        {
            var keyTitleCount = 0;
            var keyLeadCount = 0;
            var keyBodyCount = 0;
            var keys = 0;
            try
            {

                var currentKey = lstKeywords.FirstOrDefault(t => t.KeyId == keyId);

                string newsMerge = Class_Static.PersianAlpha(title + lead + body);

                var lstKey = new List<string>();

                newsMerge = newsMerge.Replace("-", " ");
                newsMerge = newsMerge.Replace(".", " . ");
                newsMerge = newsMerge.Replace(":", " : ");
                newsMerge = newsMerge.Replace("?", " ? ");
                newsMerge = newsMerge.Replace("!", " ! ");
                newsMerge = newsMerge.Replace("،", " ، ");
                newsMerge = " " + newsMerge + " ";
                string findKeywords = "";
                foreach (var key in lstKeywords)
                {
                    foreach (var itemKey in key.KeywordName.Split('+'))
                    {
                        if (string.IsNullOrWhiteSpace(itemKey)) continue;

                        key.KeywordName = Class_Static.PersianAlpha((itemKey));
                        if (newsMerge.IndexOf(" " + itemKey + " ") > -1)
                        {

                            if (findKeywords.IndexOf(" " + itemKey + " ") == -1)
                            {
                                keys++;
                                lstKey.Add(itemKey);
                            }

                        }
                    }
                }

                foreach (var item in lstKey)
                {
                    keyTitleCount += Regex.Matches(title, item).Count;
                    keyLeadCount += Regex.Matches(lead, item).Count;
                    keyBodyCount += Regex.Matches(body, item).Count;
                }
            }
            catch
            {

            }

            return new Tuple<int, int, int, int>(keys, keyTitleCount, keyLeadCount, keyBodyCount);

        }
        public static List<Tbl_News_Type> RatingNews(string parmins, List<Tbl_News_Type> data)
        {
            var dt = DateTime.Now;
            Class_Core_Keyword _clsCoreKeyword = new Class_Core_Keyword();
            List<Tbl_RssKeywords_Type> lstKeywords = new List<Tbl_RssKeywords_Type>();
            var pc = new System.Globalization.PersianCalendar();
            var lstTopSiteIDs = new List<int>() { 172, 205, 170, 406, 188, 186, 245, 192, 195, 136, 204, 180, 430, 148, 147, 261, 155, 137, 422, 544, 162, 158, 527, 168, 191, 216, 300 };
            foreach (var item in data)
            {
                try
                {
                    var newsRate = 0;

                    if (lstTopSiteIDs.Any(t => t == item.SiteID))
                    {
                        newsRate += 10;
                    }
                    else
                    {
                        newsRate += 5;
                    }





                    var year = Convert.ToInt32((item.NewsDateIndex + "").Substring(0, 4));
                    var month = Convert.ToInt32((item.NewsDateIndex + "").Substring(4, 2));
                    var day = Convert.ToInt32((item.NewsDateIndex + "").Substring(6, 2));

                    var hour = Convert.ToInt32(item.NewsTime.Substring(0, 2));
                    var min = Convert.ToInt32(item.NewsTime.Substring(3));
                    var dtNews = pc.ToDateTime(year, month, day, hour, min, 0, 0);
                    TimeSpan difference = dtNews - dt;
                    var diffMinutes = Convert.ToInt32(difference.TotalMinutes);
                    if (diffMinutes > -10)
                    {


                        newsRate += 10;

                    }
                    else if (diffMinutes > -20)
                    {
                        newsRate += 8;

                    }
                    else if (diffMinutes > -30)
                    {
                        newsRate += 6;

                    }
                    else if (diffMinutes > -40)
                    {
                        newsRate += 4;

                    }
                    else if (diffMinutes > -50)
                    {
                        newsRate += 2;

                    }
                    else
                    {
                        newsRate += 1;

                    }

                    if (!string.IsNullOrWhiteSpace(item.NewsPicture))
                    {
                        newsRate += 5;
                    }



                    if (lstKeywords == null || lstKeywords.Count == 0)
                    {
                        if (string.IsNullOrWhiteSpace(parmins))
                        {
                            parmins = _clsCoreKeyword.SelectSingle(data.FirstOrDefault().KeywordId).PanelId + "";
                        }

                        lstKeywords = _clsCoreKeyword.SelectAll(parmins);
                    }

                    var keys = Class_Static.GetNewsKeysAndKeysCount(lstKeywords, item.KeywordId, item.NewsTitle, item.NewsLead, item.NewsBody, parmins);
                    if (keys.Item1 == 1)
                    {


                        newsRate += 2;

                    }
                    else if (keys.Item1 == 2)
                    {
                        newsRate += 4;

                    }
                    else if (keys.Item1 == 3)
                    {
                        newsRate += 6;

                    }
                    else if (keys.Item1 == 4)
                    {
                        newsRate += 8;

                    }
                    else if (keys.Item1 > 4)
                    {
                        newsRate += 10;

                    }
                    else
                    {
                        newsRate += 1;

                    }

                    newsRate += keys.Item2 * 5;
                    newsRate += keys.Item3 * 3;
                    newsRate += keys.Item4 * 1;

                    item.NewsRate = newsRate;

                    // dicNewsRate.Add(item.NewsID, newsRate);

                }
                catch
                {
                    continue;
                }

            }
            return data;

        }
        public static byte[] DownloadFile(string url)
        {
            byte[] resByte = null;
            try
            {


                using (WebClient wc = new WebClient())
                {
                    resByte = wc.DownloadData(new System.Uri(url));
                }
            }
            catch
            {

            }
            return resByte;
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
                retText = retText.Replace("&raquo;", "»");
                retText = retText.Replace("&laquo;", "«");
                try
                {
                    retText = Regex.Replace(retText, @"<[^>]+>|&nbsp;|&nbsp|&zwnj;", " ").Trim();
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
        public static DataSet ExecuteDataset(string ConnectionString, string Cmd, CommandType type, SqlParameter[] prms = null)
        {
            string connection = GlobalSetting.ConnectionServerPanel;

            if (string.IsNullOrWhiteSpace(ConnectionString))
                ConnectionString = connection;
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = Cmd;

            cmd.CommandType = type;
            if (prms != null)
            {
                foreach (SqlParameter p in prms)
                {
                    cmd.Parameters.Add(p);
                }
            }
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();

            conn.Open();
            da.Fill(ds);
            conn.Close();

            return ds;
        }
        public static int ExecuteNonQuery(string ConnectionString, string cmdText, CommandType type, SqlParameter[] prms)
        {
            string connection = GlobalSetting.ConnectionServerPanel;
            if (string.IsNullOrWhiteSpace(ConnectionString))
                ConnectionString = connection;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = type;

                    if (prms != null)
                    {
                        foreach (SqlParameter p in prms)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static string ExecuteScalar(string ConnectionString, string cmdText, CommandType type, SqlParameter[] prms)
        {
            string connection = GlobalSetting.ConnectionServerPanel;
            if (string.IsNullOrWhiteSpace(ConnectionString))
                ConnectionString = connection;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = type;

                    if (prms != null)
                    {
                        foreach (SqlParameter p in prms)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                    conn.Open();
                    return cmd.ExecuteScalar().ToString();
                }
            }
        }

    }
}
