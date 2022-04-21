using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class DebitNotePrintOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string tReportNumber = Request.QueryString["ReportNumber"].Trim();
                    string status = new Config().ObjNav().GenerateDebitNote(tReportNumber);
                    string[] info = status.Split('*');
                    if (info[0] == "success")
                    {
                        string embed = "<object data=\"{0}\" type=\"application/pdf\" width=\"1000px\" height=\"300px\">";
                        embed += "If you are unable to view the report, you can download from <a href = \"{0}\">Here</a>";
                        embed += "</object>";
                        ltEmbed.Text = string.Format(embed, ResolveUrl("~/DebitNotes/" + tReportNumber + ".pdf"));
                    }
                    else
                    {
                        feedback.InnerHtml = "<div class='alert alert-danger'>The Report could not be Successfully Generated.Kindly try Again Later</div>" + info[1];
                    }

                }
                catch (Exception t)
                {
                    documentsFeedback.InnerHtml = "<div class='alert alert-danger'>" + t.Message + "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                }
            }
        }

    }
}