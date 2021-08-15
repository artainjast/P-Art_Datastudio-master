using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PArt.Pages.P_Art.Repository;
using PayeshEngine;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_Ado
    {
        
        public DataTable FillDatabaseParametric(string cnnString, string command, List<ColumnData_Type> sqlparams)
        {
            try
            {
                //cnnString = "";
                if (string.IsNullOrWhiteSpace(cnnString))
                    cnnString = Class_Static.MasterConnection;

                DataTable dt = new DataTable();
                using (var cnn = new SqlConnection(cnnString))
                {
                    cnn.Open();

                    using (var dtr = new SqlDataAdapter(command, cnn))
                    {


                        dtr.SelectCommand.Parameters.Clear();
                        if (sqlparams != null)
                        {
                            foreach (var param in sqlparams)
                            {
                                var p1 = new SqlParameter(param.ParamName, param.ColumnType);
                                if (param.ColumnValue == null || string.IsNullOrWhiteSpace(param.ColumnValue + ""))
                                {
                                    p1.Value = DBNull.Value;
                                }
                                else
                                {
                                    if (param.ColumnType == SqlDbType.Int)
                                    {
                                        p1.Value = Convert.ToInt32(param.ColumnValue);
                                    }
                                    else if (param.ColumnType == SqlDbType.SmallInt)
                                    {
                                        p1.Value = Convert.ToInt16(param.ColumnValue);
                                    }
                                    else if (param.ColumnType == SqlDbType.BigInt)
                                    {
                                        p1.Value = Convert.ToInt64(param.ColumnValue);
                                    }
                                    else if (param.ColumnType == SqlDbType.Bit)
                                    {
                                        p1.Value = Convert.ToBoolean(param.ColumnValue);
                                    }
                                    else if (param.ColumnType == SqlDbType.DateTime)
                                    {
                                        p1.Value = Convert.ToDateTime(param.ColumnValue);
                                    }
                                    else
                                    {
                                        p1.Value =(Class_Static.InjectionOk(param.ColumnValue));
                                    }
                                }



                                dtr.SelectCommand.Parameters.Add(p1);
                            }
                        }
                        dtr.Fill(dt);

                        cnn.Close();


                    }
                    cnn.Close();
                }
                return dt;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                try
                {
                 //   ExceptionUtility.LogException(ex, "Class_Ado_FillDatabaseParametric--sql--" + command);
                }
                catch
                {

                }
                //   Program.WriteLogException(ex, "Class_Ado_FillDatabase--sql--" + command);
                return null;
            }


        }

        public DataTable FillDataTable(string Command)
        {
            try
            {


                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = Class_Static.MasterConnection;

                cnn.Open();


                SqlDataAdapter dtr = new SqlDataAdapter();
                dtr.SelectCommand = new SqlCommand();
                dtr.SelectCommand.Connection = cnn;
                dtr.SelectCommand.CommandText = Command;
                dtr.SelectCommand.CommandTimeout = 600;
                DataTable dt = new DataTable();
                dtr.Fill(dt);

                cnn.Close();
                return dt;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return null;
            }
        }
        public void ExecuteCommand(string command)
        {
            try
            {


                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = Class_Static.MasterConnection;
                cnn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = command;

                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch
            {

            }
        }
        public static DataSet ExecuteDataset(string ConnectionString, string Cmd, CommandType type, SqlParameter[] prms = null)
        {
            string connection = GlobalSetting.ConnectionServerPanel;// @"data source=130.185.78.142\enterprise;initial catalog=DB_DDN;persist security info=True;user id=sa;password=1qaz@WSX";
            //string connection = @"Data Source =.; Initial Catalog = DB_DDN; Integrated Security = True";
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
        public static DataTable ExecuteDatatable(string ConnectionString, string Cmd, CommandType type, SqlParameter[] prms = null)
        {
            string connection = GlobalSetting.ConnectionServerPanel;// @"data source=130.185.78.142\enterprise;initial catalog=DB_DDN;persist security info=True;user id=sa;password=1qaz@WSX";
            //string connection = @"Data Source =.; Initial Catalog = DB_DDN; Integrated Security = True";
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

            return ds.Tables[0];
        }
        public static int ExecuteNonQuery(string ConnectionString, string cmdText, CommandType type, SqlParameter[] prms)
        {
            string connection = GlobalSetting.ConnectionServerPanel;//@"data source=130.185.78.142\enterprise;initial catalog=DB_DDN;persist security info=True;user id=sa;password=1qaz@WSX";
            //string connection = @"Data Source =.; Initial Catalog = DB_DDN; Integrated Security = True";
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
            string connection = GlobalSetting.ConnectionServerPanel;// @"data source=130.185.78.142\enterprise;initial catalog=DB_DDN;persist security info=True;user id=sa;password=1qaz@WSX";
            //string connection = @"Data Source =.; Initial Catalog = DB_DDN; Integrated Security = True";
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