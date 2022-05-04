using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class AgentRegReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var nav = Config.ReturnNav();
                var Tcontact = nav.ClientApplicationQuery.Where(r => r.Agent_Salespersons_Code == Convert.ToString(Session["empNo"]));

                txtDates.DataSource = Tcontact;
                txtDates.DataValueField = "Document_Date";
                txtDates.DataTextField = "Document_Date";
                txtDates.DataBind();
                txtDates.Items.Insert(0, "--Select start Date--");


                endDate.DataSource = Tcontact;
                endDate.DataValueField = "Document_Date";
                endDate.DataTextField = "Document_Date";
                endDate.DataBind();
                endDate.Items.Insert(0, "--Select End Date--");

            }

        }

        protected void generate_Click(object sender, EventArgs e)
        {

            feedback.InnerHtml = "";

            Boolean Error = false;

            string s = txtDates.SelectedValue;
            string sendDate = endDate.SelectedValue;
            if (s.Length < 1)
            {
                Error = true;
                feedback.InnerHtml = "<div class='alert alert-danger'>Please provide a  valid start date<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
            }
            if (sendDate.Length < 1)
            {
                Error = true;
                feedback.InnerHtml = "<div class='alert alert-danger'>Please provide a valid end date<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
            }


            if (!Error)
            {
                try
                {
                    DateTime dateTime = new DateTime();
                    DateTime exact = Convert.ToDateTime(s);
                    DateTime exactEnd = Convert.ToDateTime(sendDate);
                    string agentNo = Convert.ToString(Session["empNo"]);
                   
                    String status = new Config().ObjNav().FnGenerateAgentsRegReport(agentNo, exact, exactEnd);
                    String[] info = status.Split('*');
                    if (info[0] == "success")
                    {
                        p9form.Attributes.Add("src", ResolveUrl(info[1]));
                    }
                    else
                    {
                        feedback.InnerHtml = "<div class='alert alert-" + info[0] + "'>" + info[1] + "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    }
                }
                catch (Exception t)
                {
                    feedback.InnerHtml = "<div class='alert alert-danger'>" + t.Message + "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                }

            }
        }
    }
    
}