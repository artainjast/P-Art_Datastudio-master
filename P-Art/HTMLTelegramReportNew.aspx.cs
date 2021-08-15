using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PArt.Core;
using P_Art.Pages.P_Art.Repository;
using P_Art.Pages.P_Art.ModelNews;
using System.Text;

namespace P_Art
{
    public partial class HTMLTelegramReportNew : System.Web.UI.Page
    {
        private Class_Zaman _zm = new Class_Zaman();
        List<int?> UserPanelList = new List<int?>();
        public static string UserPanelString = "";
        DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        int ArchiveId = 0;
        int pageSize = 1050;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["ArchiveId"] != null)
                {
                    BultanArchiveIdHiddenField.Value = (Request.QueryString["ArchiveId"] + "").Trim();
                    ArchiveId = int.Parse(Request.QueryString["ArchiveId"]);
                }

                string date = _zm.Today();
                UserPanelList = Class_Layer.UserPanels();
                if (UserPanelList != null)
                {
                    foreach (var i in UserPanelList)
                    {
                        UserPanelString += "," + i;
                    }
                    if (!String.IsNullOrWhiteSpace(UserPanelString))
                        UserPanelString = UserPanelString.Substring(1);
                    BultanTitlePhrase.InnerText = "بولتن پیام رسان تلگرام ";
                    CurrentUserLabel.InnerText = (new Class_Panels()).GetParminById(Convert.ToInt32(UserPanelList[0])).AgName;

                }

            }
            var Bultan = _db.Tbl_BultanArchive.Where(B => B.ArchiveId == ArchiveId).FirstOrDefault();
            if (Bultan != null)
            {
                FromDateHiddenField.Value = FromDateLabel.Text = Bultan.FromDateIndex.Insert(4, "/").Insert(7, "/");
                ToDateHiddenField.Value = ToDateLabel.Text = Bultan.ToDateIndex.Insert(4, "/").Insert(7, "/");
            }
            else
            {
                FromDateHiddenField.Value = _zm.Today();
                ToDateHiddenField.Value = _zm.Today();
            }

            List<long> MessageIds = new List<long>();
            foreach (var Id in Bultan.SelectedNews.Split(','))
            {
                try
                {
                    MessageIds.Add(Convert.ToInt64(Id));
                }
                catch
                {
                    continue;
                }
            }

            var TelegramMessages = _db.Tbl_TLPMessage.Where(M => MessageIds.Contains(M.ID)).ToList();
            int rowIndex = 0;
            int pageNumber = 0;
            StringBuilder HTML = new StringBuilder();
            int currentPageCharIndex = 0;
            //HTML.AppendLine(@"<div class='page A4 pageCover persian persianNum'>");
            //HTML.AppendLine(@"<div class='pageContent'>");
            foreach (var Message in TelegramMessages)
            {
               
                int MessageCharSize = Message.MessageText.Length + 370;
                if (pageSize - currentPageCharIndex < MessageCharSize)
                {
                    pageNumber++;
                    rowIndex++;
                    currentPageCharIndex = MessageCharSize;
                    if (!String.IsNullOrEmpty(HTML.ToString()))
                    {
                        HTML.AppendLine(@"</div>");//div.pageContent
                        HTML.AppendLine(@"<span class='pageNumber'>");
                        HTML.AppendLine(rowIndex.ToString());
                        HTML.AppendLine(@"</span>");
                        HTML.AppendLine(@"</div>");//div.pageCover
                    }

                    HTML.AppendLine(@"<div class='page A4 pageCover persian persianNum'>");
                    HTML.AppendLine(@"<div class='pageContent'>");

                    HTML.AppendLine(@"<div class='MessageHeadder'>");

                    HTML.AppendLine(@"<span class='rowIndex'>");
                    HTML.AppendLine(rowIndex.ToString());
                    HTML.AppendLine(@"</span>");//rowIndex

                    HTML.AppendLine(@"<span class='MessageDateTime'>");
                    HTML.AppendLine(Message.MessageDate + " - " + Message.MessageTime);
                    HTML.AppendLine(@"</span>");//MessageDateTime

                    HTML.AppendLine(@"</div>");//div.MessageHeadder

                    HTML.AppendLine(@"<div class='MessageStyle'>");
                    HTML.AppendLine(Message.MessageText);

                    HTML.AppendLine(@"<div class='MessageFooter'>");

                    HTML.AppendLine(@"<span class='MessageChannel'>");
                    HTML.AppendLine(GetChannelName((int)Message.ChannelID));
                    HTML.AppendLine(@"</span>");//MessageChannel

                    HTML.AppendLine(@"</div>");//MessageFooter

                    HTML.AppendLine(@"</div>"); //MessageStyle


                }
                else
                {
                    currentPageCharIndex += MessageCharSize;
                    rowIndex++;

                    if (String.IsNullOrEmpty(HTML.ToString()))
                    {
                        HTML.AppendLine(@"<div class='page A4 pageCover persian persianNum'>");
                        HTML.AppendLine(@"<div class='pageContent'>");
                    }

                    HTML.AppendLine(@"<div class='MessageHeadder'>");

                    HTML.AppendLine(@"<span class='rowIndex'>");
                    HTML.AppendLine(rowIndex.ToString());
                    HTML.AppendLine(@"</span>");//rowIndex

                    HTML.AppendLine(@"<span class='MessageDateTime'>");
                    HTML.AppendLine(Message.MessageDate + " - " + Message.MessageTime);
                    HTML.AppendLine(@"</span>");//MessageDateTime

                    HTML.AppendLine(@"</div>");//div.MessageHeadder

                    HTML.AppendLine(@"<div class='MessageStyle'>");
                    HTML.AppendLine(Message.MessageText);

                    HTML.AppendLine(@"<div class='MessageFooter'>");

                    HTML.AppendLine(@"<span class='MessageChannel'>");
                    HTML.AppendLine(GetChannelName((int)Message.ChannelID));
                    HTML.AppendLine(@"</span>");//MessageChannel

                    HTML.AppendLine(@"</div>");//MessageFooter

                    HTML.AppendLine(@"</div>"); //MessageStyle

                }



            }
            pageNumber++;
            HTML.AppendLine(@"</div>");//div.pageContent
            HTML.AppendLine(@"<span class='pageNumber'>");
            HTML.AppendLine(pageNumber.ToString());
            HTML.AppendLine(@"</span>");
            HTML.AppendLine(@"</div>");//div.pageCover

            BultanContent.Text = HTML.ToString();

        }

        public string GetChannelName(int ChannelID)
        {
            string ChannelName = _db.Tbl_TLPChannels.Where(C => C.ChannelID == ChannelID).Select(C => C.ChannelTitle).FirstOrDefault();
            return ChannelName;
        }
    }
}