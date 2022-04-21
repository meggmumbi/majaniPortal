using MajaniPortal.Nav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            try
            {
                string mUsername = username.Text.Trim();
                string mPassword = password.Text.Trim();
                bool flag1 = false;
                if (mUsername.Length < 1)
                {
                    flag1 = true;
                    feedback.InnerHtml = "<div class='alert alert-danger'>Please UserName address cannot be Empty</div>";
                }
                if (mPassword.Length < 4)
                {
                    flag1 = true;
                    feedback.InnerHtml = "<div class='alert alert-danger'>Please input a Correct Password to Access the System</div>";
                }
                NAV nav = Config.ReturnNav();
                var majaniportalusers = nav.HRPortalUsers.Where(r => r.Employee_No == mUsername && r.Password_Value == mPassword && r.State == "Enabled"&& r.Record_Type=="Employee" &&r.Employee_No !=null).ToList();
                if (majaniportalusers.Count() >0)
                {
                    foreach (var user in majaniportalusers)
                    {

                        string fullName = user.Full_Name;
                        string lastName = user.Last_Name;
                        string idNumber = user.ID_Number;
                        string userName = user.User_Name;
                        string address = user.Address;
                        Session["empNo"] = user.Employee_No;
                        Session["Profile"] = user.Profiles;
                        Session["Role"] = user.Record_Type;
                        Session["name"] = user.First_Name + "  " + user.Middle_Name + "  " + user.Last_Name;
                        Response.Redirect("Default.aspx");
                    }
                }

                var majaniportalusers1 = nav.HRPortalUsers.Where(r => r.Member_No == mUsername && r.Password_Value == mPassword && r.State == "Enabled" ).ToList();
                if (majaniportalusers1.Count() >0)
                {
                    foreach (var user in majaniportalusers1)
                    {
                        Session["empNo"] = user.Member_No;
                        Session["name"] = user.First_Name + " " + user.Middle_Name + " " + user.Last_Name;
                        Session["Role"] = user.Record_Type;
                        Response.Redirect("MemberDashboard.aspx");

                    }
                }
                if (majaniportalusers1.Count==0 && majaniportalusers.Count == 0)
                {
                    feedback.InnerHtml = "<div class='alert alert-danger'>The User with the given Details does not exist. Kindly Login with the Correct User Credentials.</div>";

                }
            }
            catch (Exception ex)
            {
                feedback.InnerHtml = "<div class='alert alert-danger'>We experienced an error while Login you in. Kindly try again Later.</div>";
            }
        }
    }
}
