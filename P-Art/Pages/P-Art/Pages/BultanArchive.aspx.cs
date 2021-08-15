using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FarsiLibrary.Utils;
using P_Art.Pages.P_Art.Repository;
using System.IO;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class BultanArchive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();

            if (IsPostBack) return;
            txt_fromDate.Text = Class_Layer.MiladiToShamsi(DateTime.Now.AddDays(-30));
            txt_toDate.Text = Class_Layer.MiladiToShamsi(DateTime.Now);

            btn_Show_Click(sender, e);
        }

        protected void btn_Show_Click(object sender, EventArgs e)
        {
            Class_BultanArchive _cls = new Class_BultanArchive();
            Class_Panels _clsPanel = new Class_Panels();

            long fromdate = long.Parse(txt_fromDate.Text.Replace("/", ""));
            long todate = long.Parse(txt_toDate.Text.Replace("/", ""));

            int parminId = _clsPanel.GetParminById(Class_Layer.UserPanels()[0].Value).ParminID;
            //   string key = _clsPanel.GetParminById(Class_Layer.UserPanels()[0].Value).ParminGid.Value.ToString();

              rpt_result.DataSource = _cls.GetBultanByDate(fromdate, todate, parminId).OrderByDescending(t => t.ArchiveId).ToList();


         
            rpt_result.DataBind();
        }

        public static string CalculateFileSize(object filePath)
        {
            try
            {


                if (filePath == null) return "";
                filePath = HttpContext.Current.Server.MapPath("~/BultanArchive/") + filePath;

                FileInfo file = new FileInfo(filePath.ToString());
                return ConvertBytesToMegabytes(file.Length).ToString("0.00");
            }
            catch
            {
                return "";
            }
        }

        private static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }


        public static string FormatDate(object date)
        {
            return date.ToString().Substring(0, 4) + "/" + date.ToString().Substring(4, 2) + "/" + date.ToString().Substring(6, 2);
        }

        protected void btn_remove_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            Class_BultanArchive _cls = new Class_BultanArchive();
            _cls.DeleteBultan(int.Parse(btn.CommandArgument));
            btn_Show_Click(sender, e);

        }
        public static string GetBultanFilePath(string path)
        {
            if (path.ToLower().Trim().StartsWith("http://") || path.ToLower().Trim().Contains("www."))
            {
                return path;
            }
            else
            {
                return string.Format("http://new.e-sepaar.net/BultanArchive/{0}", path);
            }
        }
        public static string GetBultanFileType(string path)
        {
            try
            {
                if (path.ToLower().StartsWith("http") || path.ToLower().StartsWith("html"))
                {
                    return "بولتن موضوعی";
                }
                else
                {
                    return CalculateFileSize(path) + " MB";

                }
            }
            catch
            {
                return "";
            }
        }
    }
}