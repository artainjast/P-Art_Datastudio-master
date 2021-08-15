using PayeshEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PArtCore.Class
{
  public  class Class_Ado
    {
        public bool IsServerConnected(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                connectionString = Class_Static.conn;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    //Program.WriteLogException(ex, "Class_Ado_IsServerConnected");
                    try
                    {
                       // ExceptionUtility.LogException(ex, "Class_Ado_IsServerConnected" + connectionString);
                    }
                    catch
                    {

                    }
                    return false;
                }
            }
        }

        public DataTable FillDatabase(string cnnString, string command, List<SqlParameter> sqlparams)
        {
            try
            {
                //cnnString = "";
                if (string.IsNullOrWhiteSpace(cnnString))
                    cnnString = Class_Static.conn;

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
                                dtr.SelectCommand.Parameters.Add(Class_Static.ArabicAlpha(Class_Static.ConvertToEnNumber(Class_Static.InjectionOk(param))));
                            }
                        }
                        dtr.Fill(dt);

                        cnn.Close();


                    }
                    cnn.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                try
                {
                  //  ExceptionUtility.LogException(ex, "Class_Ado_FillDatabase--sql--" + command);
                }
                catch
                {

                }
                //   Program.WriteLogException(ex, "Class_Ado_FillDatabase--sql--" + command);
                return null;
            }


        }
        public DataTable FillDatabaseParametric(string cnnString, string command, List<ColumnData_Type> sqlparams)
        {
            try
            {
                //cnnString = "";
                if (string.IsNullOrWhiteSpace(cnnString))
                    cnnString = Class_Static.conn;

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
                                        p1.Value = Class_Static.ArabicAlpha(Class_Static.ConvertToEnNumber(Class_Static.InjectionOk(param.ColumnValue)));
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
            catch (Exception ex)
            {
                try
                {
                   // ExceptionUtility.LogException(ex, "Class_Ado_FillDatabaseParametric--sql--" + command);
                }
                catch
                {

                }
                //   Program.WriteLogException(ex, "Class_Ado_FillDatabase--sql--" + command);
                return null;
            }


        }

        public int ExecuteSQL(string cnnString, string command, List<SqlParameter> sqlparams)
        {
            var res = 0;
            try
            {

                if (string.IsNullOrWhiteSpace(cnnString))
                    cnnString = Class_Static.conn;

                using (var cnn = new SqlConnection(cnnString))
                {
                    cnn.Open();

                    using (var cmd = new SqlCommand(command, cnn))
                    {
                        cmd.Parameters.Clear();
                        if (sqlparams != null)
                        {
                            foreach (var param in sqlparams)
                            {
                                cmd.Parameters.Add(Class_Static.ArabicAlpha(Class_Static.ConvertToEnNumber(Class_Static.InjectionOk(param))));
                            }
                        }


                        if (command.ToUpper().Contains("SCOPE_IDENTITY"))
                        {
                            res = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                        else
                        {
                            cmd.ExecuteNonQuery();
                            res = 1;
                        }

                        cnn.Close();
                    }

                    cnn.Close();
                }
                return res;
            }
            catch (Exception ex)
            {
                try
                {
                  //  ExceptionUtility.LogException(ex, "Class_Ado_ExecuteSQL--sql--" + command);
                }
                catch
                {

                } // Program.WriteLogException(ex, "Class_Ado_ExecuteSQL--sql--" + command);

                return res;
            }


        }
        public int ExecuteSQLParametric(string cnnString, string Tbl_Name, SqlOperation_Type sqlOperation, List<ColumnData_Type> columns, string returnColumn)
        {
            var res = 0;
            var command = "";
            try
            {
                if (SqlOperation_Type.INSERT == sqlOperation)
                {
                    var paramList = "";
                    var columnList = "";
                    foreach (var item in columns)
                    {
                        paramList += "," + item.ParamName;
                        columnList += "," + item.ColumnName;
                    }
                    var outputSql = "";

                    outputSql = "Output Inserted." + returnColumn;

                    paramList = paramList.Substring(1);
                    columnList = columnList.Substring(1);
                    command = "INSERT INTO " + Tbl_Name + " (" + columnList + ") " + outputSql + " VALUES  (" + paramList + ")";
                }
                else if (SqlOperation_Type.UPDATE == sqlOperation)
                {
                    var paramList = "";
                    var whereSql = "";

                    var index = 0;
                    foreach (var item in columns)
                    {
                        if (!item.IsWhereParam)
                        {
                            paramList += "," + item.ColumnName + "=" + item.ParamName;

                        }
                        else
                        {
                            whereSql += " AND " + item.ColumnName + "=" + item.ParamName;
                        }
                        index++;
                    }



                    paramList = paramList.Substring(1);

                    if (!string.IsNullOrWhiteSpace(whereSql))
                    { whereSql = " WHERE " + whereSql.Trim().Substring(3); }

                    command = "UPDATE " + Tbl_Name + " SET " + paramList + whereSql;
                }
                else if (SqlOperation_Type.DELETE == sqlOperation)
                {

                    var whereSql = "";


                    foreach (var item in columns)
                    {
                        if (item.IsWhereParam)
                        {

                            whereSql += " AND " + item.ColumnName + "=" + item.ParamName;
                        }

                    }




                    if (!string.IsNullOrWhiteSpace(whereSql))
                    { whereSql = " WHERE " + whereSql.Trim().Substring(3); }

                    command = "DELETE FROM " + Tbl_Name + whereSql;
                }

                if (string.IsNullOrWhiteSpace(cnnString))
                    cnnString = Class_Static.conn;

                using (var cnn = new SqlConnection(cnnString))
                {
                    cnn.Open();

                    using (var cmd = new SqlCommand(command, cnn))
                    {
                        cmd.Parameters.Clear();
                        if (columns != null)
                        {
                            foreach (var param in columns)
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
                                    else if (param.ColumnType == SqlDbType.TinyInt)
                                    {
                                        p1.Value = Convert.ToByte(param.ColumnValue);
                                    }
                                    else if (param.ColumnType == SqlDbType.VarBinary)
                                    {
                                        p1.Value = (param.ColumnValue);
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
                                        p1.Value = Class_Static.ArabicAlpha(Class_Static.ConvertToEnNumber(Class_Static.InjectionOk(param.ColumnValue)));
                                    }
                                }



                                cmd.Parameters.Add(p1);
                            }
                        }


                        if (command.ToUpper().Contains("SCOPE_IDENTITY") || command.ToLower().Contains("output inserted"))
                        {
                            res = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                        else
                        {
                            cmd.ExecuteNonQuery();
                        }

                        cnn.Close();
                    }

                    cnn.Close();
                }
                return res;
            }
            catch (Exception ex)
            {
                //ExceptionUtility.LogException(ex, "");

                try
                {
                   // ExceptionUtility.LogException(ex, "Class_Ado_ExecuteSQLParametric--sql--" + command);
                }
                catch
                {

                }

                return res;
            }


        }
        public int ExecuteSQLParametricFull(string cnnString, string sql, List<ColumnData_Type> columns)
        {
            var res = 0;
            var command = sql;
            try
            {


                if (string.IsNullOrWhiteSpace(cnnString))
                    cnnString = Class_Static.conn;

                using (var cnn = new SqlConnection(cnnString))
                {
                    cnn.Open();

                    using (var cmd = new SqlCommand(command, cnn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Clear();
                        if (columns != null)
                        {
                            foreach (var param in columns)
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
                                        p1.Value = Class_Static.ArabicAlpha(Class_Static.ConvertToEnNumber(Class_Static.InjectionOk(param.ColumnValue)));
                                    }
                                }



                                cmd.Parameters.Add(p1);
                            }
                        }


                        if (command.ToUpper().Contains("SCOPE_IDENTITY"))
                        {
                            res = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                        else
                        {
                            cmd.ExecuteNonQuery();
                            res = 1;
                        }

                        cnn.Close();
                    }

                    cnn.Close();
                }

                return res;
            }
            catch (Exception ex)
            {
                // Program.WriteLogException(ex, "Class_Ado_ExecuteSQL--sql--" + command);
                try
                {
                  //  ExceptionUtility.LogException(ex, "Class_Ado_ExecuteSQLParametricFull--sql--" + command);
                }
                catch
                {

                }
                return res;
            }


        }
        public int ExecuteScalarSQL(string cnnString, string command, List<SqlParameter> sqlparams)
        {



            var res = 0;
            try
            {
                if (string.IsNullOrWhiteSpace(cnnString))
                    cnnString = Class_Static.conn;

                using (var cnn = new SqlConnection(cnnString))
                {
                    cnn.Open();

                    using (var cmd = new SqlCommand(command, cnn))
                    {
                        cmd.Parameters.Clear();
                        if (sqlparams != null)
                        {
                            foreach (var param in sqlparams)
                            {
                                cmd.Parameters.Add(Class_Static.ArabicAlpha(Class_Static.ConvertToEnNumber(Class_Static.InjectionOk(param))));
                            }
                        }
                        res = Convert.ToInt32(cmd.ExecuteScalar());
                        cnn.Close();
                    }
                    cnn.Close();
                }
                return res;

            }
            catch (Exception ex)
            {
                try
                {
                 //   ExceptionUtility.LogException(ex, "Class_Ado_ExecuteScalarSQL--sql--" + command);
                }
                catch
                {

                }
                return res;

            }

        }
        public  int ExecuteNonQuery(string ConnectionString, string cmdText, CommandType type, SqlParameter[] prms)
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
    }
}
