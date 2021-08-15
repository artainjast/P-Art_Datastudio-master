using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PArtCore.Class
{
    public  class Twitter
    {
        public string OAuthConsumerSecret { get; set; }
        public string OAuthConsumerKey { get; set; }
        public string OAuthConsumerAccessToken { get; set; }
        public string OAuthConsumerAccessTokenSecret { get; set; }

        public class TweetsUser
        {
            public string name { get; set; }
            public string url { get; set; }
            public string screen_name { get; set; }
            public string profile_image_url { get; set; }
            public string description { get; set; }
        }




        public class Url
        {
            public string url { get; set; }
            public string expanded_url { get; set; }
            public string display_url { get; set; }
            public int[] indices { get; set; }
        }

        public class Entities
        {
            public Url[] urls { get; set; }
        }

        public class Metadata
        {
            public int recent_retweets { get; set; }
            public string result_type { get; set; }
        }

        public class Result
        {
            public string created_at { get; set; }
            public Entities entities { get; set; }
            public string from_user { get; set; }
            public string lang { get; set; }
            public int from_user_id { get; set; }
            public string from_user_id_str { get; set; }
            public object geo { get; set; }
            public object id { get; set; }
            public string id_str { get; set; }
            public string iso_language_code { get; set; }
            public Metadata metadata { get; set; }
            public string profile_image_url { get; set; }
            public string source { get; set; }
            public string sourceFinal { get; set; }
            public string text { get; set; }
            public object to_user_id { get; set; }
            public object to_user_id_str { get; set; }
            public TweetsUser user { get; set; }



        }
        public class search_metadata
        {
            public double completed_in { get; set; }
            public long max_id { get; set; }
            public string max_id_str { get; set; }
            public string next_page { get; set; }
            public int page { get; set; }
            public string query { get; set; }
            public string refresh_url { get; set; }
            public int results_per_page { get; set; }
            public int since_id { get; set; }
            public string since_id_str { get; set; }
        }
        public class RootObject
        {

            public Result[] statuses { get; set; }
            public search_metadata search_metadata { get; set; }

        }
        public async Task<IEnumerable<string>> GetTwitts(string userName, int count, string accessToken = null)
        {
            if (accessToken == null)
            {
                accessToken = await GetAccessToken();
            }

            var requestUserTimeline = new HttpRequestMessage(HttpMethod.Get, string.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?count={0}&screen_name={1}&trim_user=1&exclude_replies=1", count, userName));
            requestUserTimeline.Headers.Add("Authorization", "Bearer " + accessToken);
            var httpClient = new HttpClient();
            HttpResponseMessage responseUserTimeLine = await httpClient.SendAsync(requestUserTimeline);
            var serializer = new JavaScriptSerializer();
            dynamic json = serializer.Deserialize<object>(await responseUserTimeLine.Content.ReadAsStringAsync());
            var enumerableTwitts = (json as IEnumerable<dynamic>);

            if (enumerableTwitts == null)
            {
                return null;
            }
            return enumerableTwitts.Select(t => (string)(t["text"].ToString()));
        }
        public async Task<RootObject> GetSearch(string userName, string tag, int count, long? since_id, long? max_id, string accessToken = null)
        {

            accessToken = OAuthConsumerAccessToken;



            var since_id_str = "";
            var max_id_str = "";
            if (since_id != null)
            {
                since_id_str = "&since_id=" + since_id;

            }
            if (max_id != null)
            {
                max_id_str = "&max_id=" + max_id;

            }
            var url = string.Format("https://api.twitter.com/1.1/search/tweets.json?q={0}&count={1}&result_type=recent" + since_id_str + max_id_str, tag, count);

            var requestUserTimeline = new HttpRequestMessage(HttpMethod.Get, url);
            requestUserTimeline.Headers.Add("Authorization", "Bearer " + accessToken);
            var httpClient = new HttpClient();
            HttpResponseMessage responseUserTimeLine = await httpClient.SendAsync(requestUserTimeline);
            var serializer2 = new JavaScriptSerializer();
            var obj = serializer2.Deserialize<dynamic>(await responseUserTimeLine.Content.ReadAsStringAsync());
            var res = responseUserTimeLine.Content.ReadAsStringAsync().Result.ToString();
            // var josn2 = serializer2.Deserialize<dynamic>(res);

            JsonSerializer serializer = new JsonSerializer();
            //  var res = await responseUserTimeLine.Content.ReadAsStringAsync();
            // dynamic json = serializer.Deserialize<object>(new JsonTextReader(new StringReader(res)));


            RootObject rootObject = (RootObject)serializer.Deserialize(new JsonTextReader(new StringReader(res)), typeof(RootObject));

            if (rootObject.statuses != null)
            {
                foreach (var tweet in rootObject.statuses)
                {
                    string source = "web";
                    if (tweet.source.ToLower().Contains("web"))
                    { }
                    if (tweet.source.ToLower().Contains("ios"))
                    { source = "ios"; }
                    if (tweet.source.ToLower().Contains("android"))
                    { source = "android"; }

                    if (tweet.source.ToLower().Contains("windows"))
                    { source = "windows"; }

                    if (tweet.source.ToLower().Contains("mac"))
                    { source = "mac"; }

                    tweet.sourceFinal = source;
                    // byte[] bytes = Encoding.Default.GetBytes(tweet.text);
                    //var myString = Encoding.UTF8.GetString(bytes);

                    UTF8Encoding utf8 = new UTF8Encoding();
                    string unicodeString = tweet.text;
                    byte[] encodedBytes = utf8.GetBytes(unicodeString);
                    unicodeString = Encoding.UTF8.GetString(encodedBytes);
                    Console.OutputEncoding = Encoding.UTF8;
                    Console.InputEncoding = Encoding.UTF8;
                    Console.WriteLine(tweet.text);
                    // this.Items.Add(new TweetViewModel(tweet.profile_image_url, tweet.text));
                }
            }
            return rootObject;
        }

        public async Task<string> GetAccessToken()
        {
           try
            {
                var httpClient = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.twitter.com/oauth2/token");
                var customerInfo = Convert.ToBase64String(new UTF8Encoding().GetBytes(OAuthConsumerKey + ":" + OAuthConsumerSecret));
                request.Headers.Add("Authorization", "Basic " + customerInfo);
                request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

                HttpResponseMessage response = await httpClient.SendAsync(request);

                string json = await response.Content.ReadAsStringAsync();
                var serializer = new JavaScriptSerializer();
                dynamic item = serializer.Deserialize<object>(json);
                return item["access_token"];
            }
            catch
            {
                return null;
            }
        }
    }
}