using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using PArtCore.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art.UserControls
{
    public partial class UC_ChartWelcome : System.Web.UI.UserControl
    {
        Class_Zaman _clsZm = new Class_Zaman();
        public Tbl_Parmin ParminTable = new Tbl_Parmin();
        Pages.P_Art.Repository.Class_Ado _clsAdo = new Pages.P_Art.Repository.Class_Ado();
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string UserPanelString = "";
            if (!IsPostBack)
            {
                var today = _clsZm.Today();
                //   txt_fromDate.Value = _clsZm.AddDayShamsi(today ,-2);
                //txt_fromDate.Value = today;
                //txt_toDate.Value = today;
                var UserPanelList = Class_Layer.UserPanels();
                var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();
                UserPanelString = ParminTable.ParminID.ToString();
                hddParmin.Value = UserPanelString;
                List<Tbl_BultanSettings> settings = (new Class_BultanSetting()).GetList(ParminTable.ParminID);

                UserPanelList = new List<int?>();
                UserPanelString = "";
                UserPanelList = Class_Layer.UserPanels();
                if (UserPanelList != null)
                {
                    foreach (var i in UserPanelList)
                    {
                        UserPanelString += "," + i;
                    }
                    if (!String.IsNullOrWhiteSpace(UserPanelString))
                        UserPanelString = UserPanelString.Substring(1);
                }
                hddParmin2.Value = UserPanelString;
                newspaper.InnerText = LoadNewsPaper();
            }
        }
        public string LoadNewsPaper()
        {
            try
            {
               
             

                var headerHtml = @" <header class='clearfix'>
                                                 <div class='right'>  <span class='headerTitle'> گیشه مطبوعات </span></div>   
                                                  
                                     
                                    </header>";

                var footerHtml = @"<footer><span>" + 1 + @"</span></footer>";

                var htmlNewsPaper = "";

              var  sqlCmdNimta = @" select nimtaId,'http://media.e-sepaar.net/nimta/' 
                            + OriginalImage as 'Path','http://media.e-sepaar.net/nimta/' 
                            + LargePath as 'LargePath',Title,SiteID_FK From Tbl_Nimta where NimtaDate = '1399/08/22'";
              


                var allNewsPaper = _clsAdo.FillDataTable(sqlCmdNimta);
                if (allNewsPaper != null && allNewsPaper.Rows.Count > 0)
                {
                    var nimtaCounter = 0;
                    var nimtaHtml = "";
                    foreach (DataRow nimtaRow in allNewsPaper.Rows)
                    {
                        nimtaCounter += 1;
                        nimtaHtml += @" <div class='nimtaItem nimtaOrderItem" + nimtaCounter + "'  id='nimta" + nimtaRow["nimtaId"] + @"'>
                                <a href='" + nimtaRow["Path"] + @"' data-src='" + nimtaRow["Path"] + @"' class='fancybox' rel='group'>
                                   
                                    <img class='lazy' src='http://media.e-sepaar.net/logo/nopic.jpg'  data-src='" + nimtaRow["Path"] + @"' />

                                   
                                </a>
                            </div>";
                       

                    }
                    if (!string.IsNullOrWhiteSpace(nimtaHtml))
                    {
                        htmlNewsPaper = headerHtml + nimtaHtml + footerHtml;

                    }

                }
                return htmlNewsPaper;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}