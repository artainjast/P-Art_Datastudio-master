using P_Art.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art
{
    public partial class ExportExcell : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DoExcellReport();
        }
        public class ExportList
        {
            public int KeywordId { get; set; }
            public string KeyworName { get; set; }
            public int Count { get; set; }
        }
        private void DoExcellReport()
        {
            try
            {

                var sql = @"SELECT KeywordId,Count(KeywordId) as CountT  FROM Tbl_News WHERE NewsID IN (SELECT NewsID FROM [dbo].[Tbl_Relation_NewsParminPanel] WHERE ParminPanelId=24) GROUP BY KeywordId ORDER BY CountT DESC";

                var _clsAdo = new Class_Ado();
                var dt = _clsAdo.FillDataTable(sql);
                var lst = new List<ExportList>();
                foreach (DataRow dr in dt.Rows)
                {
                    var item = new ExportList();
                    try
                    {
                        item.Count = Convert.ToInt32(dr["CountT"]);

                    }
                    catch
                    {
                        item.Count = 0;
                    }
                    try
                    {
                        item.KeywordId = Convert.ToInt32(dr["KeywordId"]);
                    }
                    catch
                    {
                        item.KeywordId = 0;
                    }
                    try
                    {
                        var sql2 = "SELECT KeywordName FROM Tbl_RssKeywords WHERE KeyId=" + item.KeywordId;
                        var dt2 = _clsAdo.FillDataTable(sql2);
                        item.KeyworName = dt2.Rows[0]["KeywordName"].ToString();
                    }
                    catch
                    {
                        item.KeyworName = "متفرقه";

                    }

                    lst.Add(item);

                }

                var fileName = "exportList";


                //The Clear method erases any buffered HTML output.
                Response.Clear();
                Response.Buffer = true;
                Response.ClearHeaders();

                //The AddHeader method adds a new HTML header and value to the response sent to the client.
                Response.AddHeader("Cache-Control", "no-store, no-cache");
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName + ".xls"));
                Response.Charset = Encoding.UTF8.WebName;
                //The ContentType property specifies the HTTP content type for the response.
                Response.ContentType = "application/ms-excel";
                //Implements a TextWriter for writing information to a string. The information is stored in an underlying StringBuilder.
                using (StringWriter sw = new StringWriter())
                {
                    //Writes markup characters and text to an ASP.NET server control output stream. This class provides formatting capabilities that ASP.NET server controls use when rendering markup to clients.
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        //  Create a form to contain the List
                        System.Web.UI.WebControls.Table table = new System.Web.UI.WebControls.Table();
                        TableRow row = new TableRow();

                        var listHead = new string[] { "ردیف", "نام کلید واژه", "تعداد اخبار" };
                        //   foreach (PropertyInfo proinfo in new SelectAllCompanyShow(1, "Name").GetType().GetProperties())
                        foreach (var proinfo in listHead)
                        {
                            TableHeaderCell hcell = new TableHeaderCell();
                            hcell.Font.Name = "Arial";
                            hcell.Font.Bold = true;
                            hcell.Font.Size = FontUnit.Medium;
                            hcell.HorizontalAlign = HorizontalAlign.Center;
                            hcell.VerticalAlign = VerticalAlign.Top;
                            hcell.Text = proinfo;
                            row.Cells.Add(hcell);
                        }
                        table.Rows.Add(row);
                        //  add each of the data item to the table
                        var counter = 1;
                        foreach (var emp in lst)
                        {
                            TableRow row1 = new TableRow();

                            row1.Font.Size = FontUnit.Small;
                            row1.Font.Name = "Tahoma";
                            row1.Font.Bold = false;
                            row1.HorizontalAlign = HorizontalAlign.Center;
                            row1.VerticalAlign = VerticalAlign.Middle;
                            TableCell cellRowIndex = new TableCell();
                            TableCell cellFName = new TableCell();
                            TableCell cellLName = new TableCell();



                            cellRowIndex.Text = counter + "";
                            cellFName.Text = emp.KeyworName;
                            cellLName.Text = emp.Count + "";


                            row1.Cells.Add(cellRowIndex);
                            row1.Cells.Add(cellFName);
                            row1.Cells.Add(cellLName);


                            table.Rows.Add(row1);
                            counter++;
                        }
                        //  render the table into the htmlwriter
                        table.RenderControl(htw);
                        //  render the htmlwriter into the response
                        Response.Write(sw.ToString());
                        Response.Flush();
                        Response.Close();
                    }
                }
            }

#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }

    }
}