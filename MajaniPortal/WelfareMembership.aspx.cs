using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class WelfareMembership : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                getEmployees();
            }
        }

        protected void requestmembership_Click(object sender, EventArgs e)
        {
            Boolean error = false;
            string message = "";
            //String RaisedBy = employeeno.SelectedValue;
            String tDescription = description.Text.Trim();
            //if (string.IsNullOrEmpty(RaisedBy))
            //{
            //    error = true;
            //    message = "Please enter Employee Number ";

            //}
            if (error == true)
            {
                membershipFeedback.InnerHtml = "<div class='alert alert-danger'> '" + message + "'<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

            }
            else
            {
                try
                {
                    string empNo = Session["employeeNo"].ToString();
                    string welfareNo = "";
                    var status =new Config().ObjNav().CreateWelfareMembership(welfareNo, empNo, tDescription);

                    string[] info = status.Split('*');
                    if (info[0] == "success")
                    {
                        membershipFeedback.InnerHtml = "<div class='alert alert-success'>" + info[1] + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    }
                    else
                    {
                        membershipFeedback.InnerHtml = "<div class='alert alert-danger'>" + info[1] + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    }



                }
                catch (Exception ex)
                {

                    membershipFeedback.InnerHtml = "<div class='alert alert-danger'> '" + ex.Message + "'<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                }



            }
        }
        public void getEmployees()
        {
            var nav =  Config.ReturnNav();
            var vendors = nav.Employees.ToList();
            employeeno.DataSource = vendors;
            employeeno.DataValueField = "No";
            employeeno.DataTextField = "No";
            employeeno.DataBind();
        }
    }
}