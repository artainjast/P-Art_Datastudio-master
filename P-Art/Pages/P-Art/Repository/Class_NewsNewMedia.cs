using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P_Art.Pages.P_Art.ModelNewMeda;
using P_Art.Pages.P_Art.Repository;
using System.Data;
using System.Data.SqlClient;
using PArt.Core;
using System.Text;
using PArt.Pages.P_Art.Repository;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_NewsNewMedia
    {
        private DB_RubikaEntities _db = new DB_RubikaEntities();
        //Class_Sites _site = new Class_Sites();
        Class_Panels cls_panel = new Class_Panels();
        Class_Ado _clsAdo = new Class_Ado();
        Class_Zaman _clsZm = new Class_Zaman();


        public DataSet GetAllNewsDataTableByNewsIds(string newsIds)
        {
             SqlParameter[] sqlParams = {
                new SqlParameter("@" + "NewsIds",newsIds),
        };
            DataSet ds = Class_Ado.ExecuteDataset(_db.Database.Connection.ConnectionString, "p_NewMedia_BultanNews_GetData", CommandType.StoredProcedure, sqlParams);
            return ds;
        }

    }
}