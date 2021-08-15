using P_Art.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using P_Art.Pages.P_Art.ModelNews;
using System.IO;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class Keywords : System.Web.UI.Page
    {
        Class_Keywords _clsKeywords = new Class_Keywords();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (bool.Parse(Session["IsAdmin"].ToString()) != true)
            {
                Class_Layer.SignOutCookie();
                Response.Redirect("/login/");

            }
         
            if (IsPostBack)
            {
                string target = Request["__EVENTTARGET"] + "";
                string parameter = Request["__EVENTARGUMENT"] + ""; // parameter
                if (target.ToLower().Trim() == "edit_key")
                {
                    lnk_edit_key_Click(parameter);
                }
            }
            else
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            Class_Keywords _cls = new Class_Keywords();

            var data = _cls.GetRssKeywordByPanelIds(Class_Layer.UserPanels()).OrderBy(t => t.GroupOrder).ThenBy(t => t.OrderItem).ToList();
            var keyGroups = data.GroupBy(t => t.GroupName).Select(g => g.First()).OrderBy(t => t.GroupOrder).ThenBy(t => t.OrderItem).ToList();




            //rpt_Groups.DataSource = null;
            //rpt_Groups.DataSource = data;
            //rpt_Groups.DataBind();

            //panel_key.Update();

            //foreach (var item in data.OrderBy(t => t.KeywordName))
            //{
            //    if (ddlKeyGroups.Items.FindByValue(item.PanelId + "") == null)
            //    {
            //        ddlKeyGroups.Items.Add(new ListItem { Text = item.KeywordName, Value = item.PanelId + "" });
            //    }


            //}



            var html = "";
            ltKeyGroups.Text = "";
            foreach (var group in keyGroups)
            {
                html += "<div id='group_item' class='group_item clearfix' >";
                if (!string.IsNullOrWhiteSpace(group.GroupName))
                {
                    html += @"<div class='groupNameDetails clearfix'>
                                <label>" + group.GroupOrder + @"</label>
                                <label title='[" + group.GroupName + @"]' >" + group.GroupName + @"</label>

                            </div>";
                }
                foreach (var item in data.Where(t => t.GroupName == group.GroupName).OrderBy(t => t.OrderItem).ThenBy(t => t.KeywordName).ToList())
                {
                    html += @"<div class='clearfix' style='padding: 3px;'>


                                <input type='hidden' id='fld_color' value='" + item.Color + @"' />
                                <input type='hidden' id='fld_keyId' value='" + item.KeyId + @"' />

                                <input type='color' id='color_box' value='" + item.Color + @"'  />


                                <a style='' id='color_span' href='#updatekey' onclick='ShowEditTagPopup(" + item.KeyId + @")' class='keyOrder'>" + item.OrderItem + @"</a>

                                <a id='lnk_edit_key' class='keyTitle'  href='#updatekey' onclick='ShowEditTagPopup(" + item.KeyId + @")' data-keyid='" + item.KeyId + @"'>
                                 <label title='[" + item.KeywordName + @"]' >" + item.KeywordName + @" </label>
                                </a>
                            </div>";
                }
                html += @"</div>";
            }

            ltKeyGroups.Text = html;

        }
        protected void rpt_Groups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HtmlGenericControl _div = e.Item.FindControl("group_item") as HtmlGenericControl;
            if (_div == null) return;


            TextBox ctrl = e.Item.FindControl("color_box") as TextBox;




        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            //DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            //foreach (RepeaterItem item in rpt_Groups.Items)
            //{
            //    HiddenField fldKeyId = item.FindControl("fld_keyId") as HiddenField;
            //    TextBox ctrl = item.FindControl("color_box") as TextBox;
            //    TextBox txtindex = item.FindControl("color_span") as TextBox;
            //    {
            //        db.Database.ExecuteSqlCommand("update Tbl_RssKeywords set OrderItem=" + txtindex.Text + ",Color='" + ctrl.Text + "' where KeyId=" + fldKeyId.Value);
            //    }
            //}

            LoadData();
        }

        protected void lnk_edit_key_Click(string keyid)
        {

            Class_Keywords _clsKey = new Class_Keywords();
            var result = _clsKey.GetRssKeywordById(int.Parse(keyid));

            txt_keywordTitle.Text = result.KeywordName;
            txt_key_periority.Text = result.OrderItem.ToString();
            txt_color.Text = result.Color;
            txt_notLike.Text = result.NotLike;
            txt_mobiles.Text = result.Mobiles;
            txtGroupName.Text = result.GroupName;
            txtGroupOrder.Text = result.GroupOrder + "";
            ddlType.SelectedIndex = ddlType.Items.IndexOf(ddlType.Items.FindByValue(result.Type.ToString()));
            ViewState["CurrentKey"] = keyid;

            if (result.IsMobileNotification == null)
            {
                result.IsMobileNotification = false;
            }

            if (result.IsMobileSMS == null)
            {
                result.IsMobileSMS = false;
            }

            rbtnNotificationActive.SelectedValue = result.IsMobileNotification.ToString().ToLower();
            rbtnSmsActive.SelectedValue = result.IsMobileSMS.ToString().ToLower();

            var sendTelegram = "false";
            if (result.IsTelegramChannel != null)
            {
                sendTelegram = result.IsTelegramChannel.ToString().ToLower();
            }

            rbtnSendTelegram.SelectedValue = sendTelegram;


            btn_remove.Visible = true;
            imgLogo.ImageUrl = result.KeywordImage;
            // panel_remove.Update();

            // panel_keywords.Update();
            ScriptManager.RegisterStartupScript(this, typeof(Button), "src", "showModal();", true);
        }

        protected void btn_new_keyword_Click(object sender, EventArgs e)
        {

            btn_remove.Visible = false;
            panel_remove.Update();

            ScriptManager.RegisterStartupScript(this, typeof(Button), "src", "showModal();", true);
            ViewState["CurrentKey"] = null;
        }

        protected void lnk_close_Click(object sender, EventArgs e)
        {
            txt_notLike.Text = "";
            txt_mobiles.Text = "";
            txt_keywordTitle.Text = "";
            txt_key_periority.Text = "";
            txt_color.Text = "";

            ScriptManager.RegisterStartupScript(this, typeof(Button), "src", "CloseModal();", true);
            ViewState["CurrentKey"] = null;
        }

        protected void btn_Save_keyword_Click(object sender, EventArgs e)
        {
            if (txt_keywordTitle.Text.Trim() == "")
            {
                txt_keywordTitle.BackColor = System.Drawing.Color.Red;
                return;
            }
            txt_keywordTitle.BackColor = System.Drawing.Color.White;
            var keywordGroup = txtGroupName.Text;
            int panelId = int.Parse(Class_Layer.UserPanels()[0].ToString());
            int orderItem = 1000;
            try
            {
                orderItem = int.Parse(txt_key_periority.Text);
            }
            catch
            {

            }
            var img = imgLogo.ImageUrl;
            if (fupLogo.HasFile)
            {

                var _tempPath = @"C:\HostingSpaces\admin1\media.e-sepaar.net\wwwroot\Images\KeywordsPicture\";
                if (Directory.Exists(_tempPath) == false)
                {
                    Directory.CreateDirectory(_tempPath);
                }

                var file = fupLogo.PostedFile;
                string extTopicImg = Path.GetExtension(file.FileName).ToLower();

                var rnd = new Random();
                var keyId = rnd.Next(100, 100000);
                if (ViewState["CurrentKey"] != null)
                {
                    keyId = Convert.ToInt32(ViewState["CurrentKey"]);
                }
                var fileNameOK = keyId + "_" + txt_keywordTitle.Text.Replace("+", "-").Replace(" ", "-").Replace("--", "-") + extTopicImg;


                var finalPath = Path.Combine(_tempPath, fileNameOK);

                fupLogo.SaveAs(finalPath);
                img = "http://media.e-sepaar.net/Images/KeywordsPicture/" + fileNameOK;

            }

            var isMobileNotification = Convert.ToBoolean(rbtnNotificationActive.SelectedValue);
            var isSmsActive = Convert.ToBoolean(rbtnSmsActive.SelectedValue);
            var isTelegram = Convert.ToBoolean(rbtnSendTelegram.SelectedValue);
            var groupOrder = 0;
            try
            {
                groupOrder = Convert.ToInt32(txtGroupOrder.Text);
            }
            catch
            {

            }
            if (ViewState["CurrentKey"] == null)
            {
                _clsKeywords.InsertKeyword(txt_keywordTitle.Text, panelId, txt_color.Text, txt_notLike.Text, orderItem, txt_mobiles.Text, img, isMobileNotification, isSmsActive, keywordGroup, isTelegram, groupOrder , Convert.ToInt32(ddlType.SelectedValue));
            }
            else
            {
                _clsKeywords.UpdateKeyword(int.Parse(ViewState["CurrentKey"].ToString()), txt_keywordTitle.Text, panelId, txt_color.Text, txt_notLike.Text, orderItem, txt_mobiles.Text, img, isMobileNotification, isSmsActive, keywordGroup, isTelegram, groupOrder, Convert.ToInt32(ddlType.SelectedValue));
            }

            ScriptManager.RegisterStartupScript(this, typeof(Button), "src", "CloseModal();", true);
            ViewState["CurrentKey"] = null;
            LoadData();
        }

        protected void btn_remove_Click(object sender, EventArgs e)
        {
            _clsKeywords.DeleteKeyword(int.Parse(ViewState["CurrentKey"].ToString()));
            ScriptManager.RegisterStartupScript(this, typeof(Button), "src", "CloseModal();", true);
            ViewState["CurrentKey"] = null;


            LoadData();
        }

    }
}