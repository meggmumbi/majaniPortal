using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class ICTHelpDesk : System.Web.UI.Page
    {
       

         protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getCategories();
            }

        }

        protected void addICTHelpDeskRequest_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean error = false;
                string message = "";
                string ictCategories = category.SelectedValue.Trim();
                string desc = Description.Text.ToString();
                if (string.IsNullOrEmpty(desc))
                {
                    error = true;
                    message = "Please enter description ";

                }
                if (error)
                {
                    ictFeedback.InnerHtml = "<div class='alert alert-danger'> '" + message + "'<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                }
                else
                {
                    string empNo = Session["employeeNo"].ToString();
                    var status = new Config().ObjNav().CreateIctRequest(empNo, desc, ictCategories);
                    string[] info = status.Split('*');
                    if (info[0] == "success")
                    {
                        ictFeedback.InnerHtml = "<div class='alert alert-success'> '" + info[1] + "' <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                        "setTimeout(function() { window.location.replace('Dashboard.aspx') }, 5000);", true);
                    }
                    else
                    {
                        ictFeedback.InnerHtml = "<div class='alert alert-danger'> '" + info[1] + "' <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    }
                }
            }
            catch (Exception m)
            {
                ictFeedback.InnerHtml = "<div class='alert alert-danger'> '" + m.Message + "'<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
            }
        }

        public void getCategories()
        {
            var nav = Config.ReturnNav();
            var categories = nav.ICTHelpDeskCategory.ToList();
            category.DataSource = categories;
            category.DataValueField = "Code";
            category.DataTextField = "Description";
            category.DataBind();

        }
    }
}