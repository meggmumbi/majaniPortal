using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class ClientProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                feedback.InnerHtml = "";
           
                    try
                    {


                        string agentNo = Convert.ToString(Session["empNo"]);
                        string tContract = Request.QueryString["ContractNo"];
                        String status = new Config().ObjNav().FnGeneratreProfile(tContract);
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