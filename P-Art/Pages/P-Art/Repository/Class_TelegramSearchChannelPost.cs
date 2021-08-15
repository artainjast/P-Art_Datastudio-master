using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PArt.Pages.P_Art.Repository;
using System.Data;
using System.Data.SqlClient;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_TelegramSearchChannelPost
    {
        public int ChannelPostID { get; set; }
        public int TelegramChannelID { get; set; }
        public int Telegram_Id { get; set; }
        public DateTime Message_Date { get; set; }
        public string Message_DateTimeIndex { get; set; }
        public string Message_Text { get; set; }
        public long Text_CRC { get; set; }
        public static List<Class_TelegramSearchChannelPost> GetFromDataRows(DataRow[] Rows)
        {
            List<Class_TelegramSearchChannelPost> list = new List<Class_TelegramSearchChannelPost>();
            foreach (DataRow r in Rows)
            {
                Class_TelegramSearchChannelPost social = new Class_TelegramSearchChannelPost();
                social.TelegramChannelID = Convert.ToInt32(r["TelegramChannelID"]);
                social.Telegram_Id = Convert.ToInt32(r["Telegram_Id"]);
                social.ChannelPostID = Convert.ToInt32(r["ChannelPostID"]);
                social.Message_Date = Convert.ToDateTime(r["Message_Date"]);
                social.Message_Text = r["Message_Text"].ToString();
                social.Message_DateTimeIndex = r["Message_DateTimeIndex"].ToString();
                social.Text_CRC = Convert.ToInt64(r["Text_CRC"]);
                list.Add(social);
            }
            return list;
        }
        public DataSet GetData(int PageCount, int PageIndex, string PanelIds, long FromDate,
            long ToDate, string Search, string KeysIds)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "PageCount",PageCount),
                new SqlParameter("@" + "PageIndex",PageIndex),
                 new SqlParameter("@" + "PanelIds",PanelIds),
                new SqlParameter("@" + "FromDate",FromDate) ,
                 new SqlParameter("@" + "ToDate",ToDate),
                new SqlParameter("@" + "Search",Search),
                 new SqlParameter("@" + "KeysIds",KeysIds)
        };
            return Class_Ado.ExecuteDataset("", "p_TelegramPost_GetAlldata", CommandType.StoredProcedure, sqlParams);
        }
    }
}