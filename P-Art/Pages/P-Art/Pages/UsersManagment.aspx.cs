using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class UsersManagment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var sidebarPC = Master.FindControl("pc_SideBar") as Panel;
            sidebarPC.Visible = false;
            Master.Controls.Remove(sidebarPC);


            Class_Layer.CheckSession();

            if (!IsPostBack)
            {
                LoadData();
                LoadPanelKeywords();
            }
        }
        DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private void LoadData()
        {
            var panels = Class_Layer.UserPanels();
            var parminId = (panels.FirstOrDefault()) + "";

            var data = _db.Tbl_AgenceMembers.Where(t => t.ParminIds == parminId).ToList();

            grvData.DataSource = data;
            grvData.DataBind();
        }
        protected void grvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvData.PageIndex = e.NewPageIndex;
            LoadData();
        }

        protected void grvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdfMemberID = (e.Row.FindControl("hdfMemberID") as HiddenField);
                HiddenField hdfMemberActive = (e.Row.FindControl("hdfMemberActive") as HiddenField);

                DropDownList ddlActive = (e.Row.FindControl("ddlActive") as DropDownList);

                ddlActive.SelectedValue = hdfMemberActive.Value.ToLower();
            }

        }
        private void LoadPanelKeywords()
        {
            var panels = Class_Layer.UserPanels();
            var parminId = Convert.ToInt32(panels.FirstOrDefault());


            var data = _db.Tbl_RssKeywords.Where(t => t.PanelId == parminId && t.Active == true).ToList();



            ddlUserSmsKeywords.Items.Clear();


            foreach (var item in data)
            {
                var el = new ListItem();
                el.Text = Class_Static.PersianAlpha(item.KeywordName);
                el.Value = item.KeyId + "";
                el.Selected = false;

                //if (lst.Contains(item.KeyId))
                //{
                //    el.Attributes.Add("class", "selected");
                //    el.Selected = true;
                //}
                ddlUserSmsKeywords.Items.Add(el);
            }

        }
        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            var btn = sender as LinkButton;

            hdfUserID.Value = btn.CommandArgument;
            var memberID = Convert.ToInt32(hdfUserID.Value);
            var member = _db.Tbl_AgenceMembers.FirstOrDefault(t => t.MemberID == memberID);

            ltUserAddEdit.Text = "ویرایش کاربر" + " - " + member.UserName;

            txtPassword.Text = member.Password;
            txtUserMobile.Text = member.Mobile;
            txtUserName.Text = member.UserName;
            if (member.Active == null)
            {
                member.Active = true;
            }
            rbtnUserActive.SelectedValue = member.Active.ToString().ToLower();

            if (member.keywords != null)
            {
                foreach (var item in member.keywords.Split(','))
                {

                    try
                    {
                        ddlUserSmsKeywords.Items.FindByValue(item).Selected = true;
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {
                        continue;
                    }
                }
            }

            mutiview1.ActiveViewIndex = 1;
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            hdfUserID.Value = "";

            ltUserAddEdit.Text = "ثبت کاربر جدید";
            mutiview1.ActiveViewIndex = 1;


        }

        protected void btnRegUserData_Click(object sender, EventArgs e)
        {

            var keywords = "";
            foreach (ListItem item in ddlUserSmsKeywords.Items)
            {
                if (item.Selected)
                {
                    keywords += "," + item.Value;
                }
            }
            if (!string.IsNullOrWhiteSpace(keywords))
            {
                keywords = keywords.Substring(1);
            }

            var username = txtUserName.Text;
            var password = txtPassword.Text;
            var active = Convert.ToBoolean(rbtnUserActive.SelectedValue);
            var mobile = txtUserMobile.Text;


            var panels = Class_Layer.UserPanels();
            var parminId = panels.FirstOrDefault() + "";

            var memberId = 0;
            if (string.IsNullOrWhiteSpace(hdfUserID.Value))
            {

                // check user count for panel not>10
                var allUsers = _db.Tbl_AgenceMembers.Where(t => t.ParminIds.Contains(parminId)).ToList();
                if(allUsers.Count>9)
                {
                    lblRes.Text = "عدم ثبت کاربر بدلیل اتمام حد مجاز ثبت کاربر";
                    return;
                }

                foreach (ListItem listItem in ddlUserSmsKeywords.Items)
                {
                    if (listItem.Selected)
                    {
                        var keyId = Convert.ToInt32(listItem.Value);
                        var keyword = _db.Tbl_RssKeywords.FirstOrDefault(t => t.KeyId == keyId);

                        if (string.IsNullOrWhiteSpace(keyword.Mobiles))
                        {
                            keyword.Mobiles = mobile;
                        }
                        else
                        {
                            keyword.Mobiles += "," + mobile;
                        }
                    }
                    _db.SaveChanges();
                }



                //add
                var item = new Tbl_AgenceMembers();
                item.Active = active;
                item.UserName = username;
                item.ParminIds = parminId;
                item.Password = password;
                item.keywords = keywords;
                item.AgenceID = 54;
                item.Mobile = mobile;

                item.SignupDate = DateTime.Now;

                _db.Tbl_AgenceMembers.Add(item);
                _db.SaveChanges();
                memberId = item.MemberID;

            }
            else
            {

                memberId = Convert.ToInt32(hdfUserID.Value);
                //edit
                var item = _db.Tbl_AgenceMembers.FirstOrDefault(t => t.MemberID == memberId);

                if (string.IsNullOrWhiteSpace(item.Mobile))
                {
                    item.Mobile = "";
                }

                foreach (ListItem listItem in ddlUserSmsKeywords.Items)
                {
                    if (string.IsNullOrWhiteSpace(item.Mobile))
                    {
                        break;
                    }

                    var keyId = Convert.ToInt32(listItem.Value);
                    var keyword = _db.Tbl_RssKeywords.FirstOrDefault(t => t.KeyId == keyId);

                    var keyMobile = keyword.Mobiles;
                    keyMobile = keyMobile.Replace("," + item.Mobile, "");
                    keyMobile = keyMobile.Replace(item.Mobile, "");
                    keyword.Mobiles = keyMobile;

                    _db.SaveChanges();

                }

                item.Active = active;
                item.UserName = username;
                item.ParminIds = parminId;
                item.Password = password;
                item.keywords = keywords;
                item.Mobile = mobile;


                //SaveChanges
                _db.SaveChanges();

                foreach (ListItem listItem in ddlUserSmsKeywords.Items)
                {
                    var keyId = Convert.ToInt32(listItem.Value);

                    var keyword = _db.Tbl_RssKeywords.FirstOrDefault(t => t.KeyId == keyId);

                    if (listItem.Selected)
                    {



                        if (string.IsNullOrWhiteSpace(keyword.Mobiles))
                        {
                            keyword.Mobiles = mobile;
                        }
                        else
                        {
                            keyword.Mobiles += "," + mobile;
                        }


                        //SaveChanges
                        _db.SaveChanges();

                    }
                    else
                    {
                        var keyMobile = keyword.Mobiles;

                        keyMobile = keyMobile.Replace("," + item.Mobile, "");
                        keyMobile = keyMobile.Replace(item.Mobile, "");

                        keyword.Mobiles = keyMobile;

                        _db.SaveChanges();

                    }
                }





            }



            lblRes.Text = "عملیات با موفقیت انجام شد.";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mutiview1.ActiveViewIndex = 0;
        }
    }
}