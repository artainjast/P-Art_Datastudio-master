using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PArt.Pages.P_Art.Repository;
using P_Art.Pages.P_Art.Repository;
using System.Net;
using P_Art.Pages.P_Art.ModelNews;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class AddNews : System.Web.UI.Page
    {
        DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        public static int NewsId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;


            if (Request.QueryString["Id"] != null)
            {
                NewsId = Convert.ToInt32(Request.QueryString["Id"].ToString());
            }


            if (NewsId != 0)
            {
                var _clsNews = new Class_News();
                var news = _clsNews.GetNewsById(NewsId);
                if (news != null)
                {
                    txt_date.Text = news.NewsDate;
                    LoadKeywordList((int)news.KeywordId);
                    LoadSource((int)news.SiteID);
                    txt_newsTime.Text = news.NewsTime;
                    txt_lead.Text = news.NewsLead;
                    txt_picture.Text = news.NewsPicture;
                    txt_title.Text = news.NewsTitle;
                    txt_body.Text = news.NewsBody;
                    txt_link.Text = news.NewsLink;
                }
            }
            else
            {
                txt_date.Text = Class_Layer.MiladiToShamsi(DateTime.Now);
                LoadKeywordList(0);
                LoadSource(0);
                txt_newsTime.Text = DateTime.Now.ToString("HH:mm");
                txt_lead.Text = "";
                txt_picture.Text = "";
                txt_title.Text = "";
                txt_body.Text = "";
                txt_link.Text = "";
            }

        }

        private void LoadKeywordList(int KeyId)
        {
            var _clsKeywords = new Class_Keywords();
            var keys = _clsKeywords.GetRssKeywordByPanelIds(Class_Layer.UserPanels());
            List<KeywordType> keywords = new List<KeywordType>();
            foreach (var k in keys)
            {
                KeywordType key = new KeywordType();
                key.KeyID = k.KeyId;
                key.KeywordName = (k.GroupOrder != null ? "( " + k.GroupOrder + " )" : string.Empty) +
                    (k.GroupName != null ? " " + k.GroupName + "" : string.Empty) + " - " +
                    k.KeywordName;
                key.GroupName = k.GroupName != null ? k.GroupName : "";
                try { key.GroupOrder = (int)k.GroupOrder; } catch { key.GroupOrder = 0; }
                key.Active = (bool)k.Active;
                keywords.Add(key);
            }


            ddlKeywordList.DataSource = keywords;
            ddlKeywordList.DataTextField = "KeywordName";
            ddlKeywordList.DataValueField = "KeyID";
            ddlKeywordList.DataBind();
            if (KeyId != 0)
                ddlKeywordList.SelectedIndex = ddlKeywordList.Items.IndexOf(ddlKeywordList.Items.FindByValue(KeyId.ToString()));
            else ddlKeywordList.SelectedIndex = 0;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                Class_News _clsNews = new Class_News();
                PArt.Core.HtmlRemoval _html = new PArt.Core.HtmlRemoval();
                txt_title.Text = _html.NormalText(txt_title.Text, false);
                txt_lead.Text = _html.NormalText(txt_lead.Text, false);
                txt_body.Text = _html.NormalText(txt_body.Text, false);
                var keyID = 330;
                if (ddlKeywordList.SelectedValue != null || ddlKeywordList.SelectedValue != "")
                {
                    keyID = Convert.ToInt32(ddlKeywordList.SelectedValue);
                }
                if (NewsId == 0)
                {

                    var SiteID = int.Parse(SelectedSiteIDHiddenField.Value.ToString());
                    _clsNews.InsertNew(Class_Layer.UserPanels()[0], SiteID, txt_newsTime.Text, txt_title.Text, txt_lead.Text, txt_body.Text, txt_link.Text, txt_picture.Text, txt_date.Text, keyID, Convert.ToByte(ddlNewsTypeShow.SelectedValue));
                }

                else
                {
                    _clsNews.UpdateNewsLog(NewsId, Class_Layer.CurrentUser().UserName, Class_Static.GetUserIP(), Class_Layer.MiladiToShamsi(DateTime.Now), (int)Class_Layer.UserPanels()[0]);
                    _clsNews.UpdateNews(NewsId, txt_title.Text, txt_lead.Text, txt_body.Text, txt_date.Text, txt_newsTime.Text, txt_link.Text, txt_picture.Text, keyID);
                }

                txt_lead.Text = "";
                txt_picture.Text = "";
                txt_title.Text = "";
                txt_body.Text = "";
                txt_link.Text = "";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('خبر با موفقیت ثبت گردید');</script>", false);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('ثبت خبر انجام نشد');</script>", false);
            }
            

            

        }
        protected string GetIPAddress()
        {
            string ip = "";
            IPHostEntry ipEntry = Dns.GetHostEntry(GetCompCode());
            IPAddress[] addr = ipEntry.AddressList;
            ip = addr[2].ToString();
            return ip;
        }
        public static string GetCompCode()  // Get Computer Name
        {
            string strHostName = "";
            strHostName = Dns.GetHostName();
            return strHostName;
        }
        public string GetIP()
        {
            string Str = "";
            Str = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(Str);
            IPAddress[] addr = ipEntry.AddressList;
            return addr[addr.Length - 1].ToString();

        }
        private void LoadSource(int SiteId)
        {

            Class_Sites _clsSites = new Class_Sites();
            SitesListView.DataSource = null;

            var SitesTable = _clsSites.GetAllSites();
            SitesListView.DataSource = SitesTable;
            SitesListView.DataBind();
           

            
            if (SiteId != 0)
            {
                try
                {
                    SelectedSiteTextBox.Text = _db.AllSitesView.Where(s => s.SiteID == SiteId).Select(s => s.SiteTitle).FirstOrDefault();
                }
                catch
                { }
                
                
            }
            //Class_Sites _clsSites = new Class_Sites();
            //SitesListBox.Items.Clear();

            //foreach (var item in _clsSites.GetAllSites())
            //{
            //    ListItem newItem = new ListItem();
            //    newItem.Text = item.SiteTitle;
            //    newItem.Value = item.SiteID.ToString();

            //    SitesListBox.Items.Add(newItem);

            //    if (SiteId != 0)
            //        SitesListBox.SelectedIndex = drp_source.Items.IndexOf(SitesListBox.Items.FindByValue(SiteId.ToString()));
            //    else SitesListBox.SelectedIndex = 0;
        //}
        }
        public class KeywordType
        {
            public int KeyID { get; set; }
            public string KeywordName { get; set; }
            public string GroupName { get; set; }
            public int GroupOrder { get; set; }
            public bool Active { get; set; }
        }
    }
}