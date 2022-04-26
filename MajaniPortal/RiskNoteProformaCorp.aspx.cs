using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class RiskNoteProformaCorp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {



                feedback.InnerHtml = "";

                Boolean Error = false;

                try
                {

                }

                catch (Exception)
                {
                    Error = true;
                    feedback.InnerHtml = "<div class='alert alert-danger'>Please provide a valid start date<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }

                try
                {

                }
                catch (Exception)
                {
                    Error = true;
                    feedback.InnerHtml = "<div class='alert alert-danger'>Please provide a valid end date<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                if (!Error)
                {
                    try
                    {

                        string applicationNo = Request.QueryString["requisitionNo"];
                        String status = new Config().ObjNav().FnGenerateReport(applicationNo);
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

        protected void next_Click(object sender, EventArgs e)
        {
            string docNo = Request.QueryString["requisitionNo"];
            Response.Redirect("CorporateAgricultureUnd.aspx?requisitionNo=" + docNo + "&step=5");

        }

        protected void previoes_Click(object sender, EventArgs e)
        {
            string docNo = Request.QueryString["requisitionNo"];
            string tproduct = Request.QueryString["product"];
            Response.Redirect("CorporateAgricultureUnd.aspx?requisitionNo=" + docNo + "&step=4" + "&product=" + tproduct);



        }

    }
}