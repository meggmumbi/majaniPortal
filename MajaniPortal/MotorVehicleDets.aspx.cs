using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class MotorVehicleDets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void generate_Click(object sender, EventArgs e)
        {
            string customerNo = Convert.ToString(Request.QueryString["customerNo"]);
            string contractNo = Convert.ToString(Request.QueryString["contractNo"]);
            string No = Convert.ToString(Request.QueryString["No"]);
            try
            {

                String status = new Config().ObjNav().FnGenerateCertificate(customerNo, No);
                String[] info = status.Split('*');
                if (info[0] == "success")
                {
                    feedback.InnerHtml = "<div class='alert alert-" + info[0] + "'>" + info[1] + "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
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