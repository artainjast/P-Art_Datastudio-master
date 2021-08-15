using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace P_Art.Pages.P_Art.Repository
{
    public enum CurrencyType : byte
    {
        Currency = 1,
        CurrencyExchange = 2,
        GoldCoin = 3
    }
    public class Class_CurrencyStats
    {
        public int CurrencyStatsId { get; set; }
        public string Title { get; set; }
        public string LastUpdateDateTimeIndex { get; set; }
        public string DateIndex { get; set; }
        public string Price { get; set; }
        public string Diffrence { get; set; }
        public byte CurrencyType { get; set; }
        public static List<Class_CurrencyStats> GetFromDataRows(DataRow[] Rows)
        {
            List<Class_CurrencyStats> list = new List<Class_CurrencyStats>();
            foreach (DataRow r in Rows)
            {
                Class_CurrencyStats item = new Class_CurrencyStats();
                try { item.CurrencyStatsId = Convert.ToInt32(r["CurrencyStatsId"]); } catch { item.CurrencyStatsId = 0; }
                try { item.Title = r["Title"].ToString(); } catch { item.Title = string.Empty; }
                try { item.LastUpdateDateTimeIndex = r["LastUpdateDateTimeIndex"].ToString(); } catch { item.LastUpdateDateTimeIndex = string.Empty; }
                try { item.DateIndex = r["DateIndex"].ToString(); } catch { item.DateIndex = string.Empty; }
                try { item.Price = r["Price"].ToString(); } catch { item.Price = "0"; }
                try { item.Diffrence = r["Diffrence"].ToString(); } catch { item.Diffrence = "0"; }
                try { item.CurrencyType = Convert.ToByte(r["CurrencyType"]); } catch { item.CurrencyType = 0; }
                list.Add(item);
            }
            return list;
        }
        public static List<Class_CurrencyStats> GetList(string DateIndex)
        {
            string connectionString = "";
            DataSet ds = Class_Ado.ExecuteDataset(connectionString, @"SELECT Title,Price,Diffrence,LastUpdateDateTimeIndex,CurrencyType FROM Tbl_CurrencyStats WHERE DateIndex='" +
                        DateIndex + "'", CommandType.Text);
            List<Class_CurrencyStats> list = GetFromDataRows(ds.Tables[0].Select());
            return list;
        }
        public static List<Class_CurrencyStats> GetList(string DateIndex, byte CurrencyType)
        {
            string connectionString = "";
            DataSet ds = Class_Ado.ExecuteDataset(connectionString,
                @"SELECT Title,Price,Diffrence,LastUpdateDateTimeIndex,CurrencyType FROM Tbl_CurrencyStats WHERE DateIndex='" +
                        DateIndex + "' AND CurrencyType=" + CurrencyType + "", CommandType.Text);
            List<Class_CurrencyStats> list = GetFromDataRows(ds.Tables[0].Select());
            return list;
        }
    }
}