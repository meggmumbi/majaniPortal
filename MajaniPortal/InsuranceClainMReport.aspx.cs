using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class InsuranceClainMReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                // var nav = Config.ReturnNav();
                // var Tcontact = nav.InsuranceClaims.Where(r => r.Requestor == Convert.ToString(Session["empNo"]));

                factoryName.Text = Convert.ToString(Session["factoryCode"]);


            }

        }

        protected void generate_Click(object sender, EventArgs e)
        {

            feedback.InnerHtml = "";

            Boolean Error = false;

            string s = txtDate.Text;
            string endD = textEndDate.Text;

            if (s.Length < 1)
            {
                Error = true;
                feedback.InnerHtml = "<div class='alert alert-danger'>Please provide a  valid start date<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
            }
            DateTime dateTime = new DateTime();
            DateTime exact = Convert.ToDateTime(s);
            DateTime exactend = Convert.ToDateTime(endD);

            string tfactoryName = factoryName.Text;
            if (tfactoryName.Length < 1)
            {
                Error = true;
                feedback.InnerHtml = "<div class='alert alert-danger'>Please enter factory Name<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
            }
            //var nav = Config.ReturnNav();
            //var Tcontact = nav.InsuranceClaims.Where(r => r.Requestor == Convert.ToString(Session["empNo"]) && r.Date_Created==exact).ToList();
            //if (Tcontact.Count < 1)
            //{
            //    Error = true;
            //    feedback.InnerHtml = "<div class='alert alert-danger'>There is no application made on this date"+exact+"<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
            //}
            //var Tcontactend = nav.InsuranceClaims.Where(r => r.Requestor == Convert.ToString(Session["empNo"]) && r.Date_Created == exactend).ToList();
            //if (Tcontactend.Count < 1)
            //{
            //    Error = true;
            //    feedback.InnerHtml = "<div class='alert alert-danger'>There is no application made on this date" + exactend + "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
            //}

            if (!Error)
            {
                try
                {
                    
                 
                    string agentNo = Convert.ToString(Session["empNo"]);

                    String status = new Config().ObjNav().FnGeneratClaimReport(exact, tfactoryName, agentNo, exactend);
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