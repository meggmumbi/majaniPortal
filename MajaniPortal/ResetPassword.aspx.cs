using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Next_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                this.feedback.InnerHtml = "<div class='alert alert-danger'>" + ex.Message + "</div>";
            }
        }
    }
}