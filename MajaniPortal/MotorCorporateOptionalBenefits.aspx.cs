using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class MotorCorporateOptionalBenefits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Load Optional Benefits
            AutoPopulateOptionalBenefits_Onlick();
            if (!IsPostBack)
            {
                var optionalbenefits = Config.ReturnNav().InsuranceOptions.ToList();
                List<DropDownList> optionalbenefitslist = new List<DropDownList>();
                foreach (var item in optionalbenefits)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Code;
                    code.Name = item.Description;
                    optionalbenefitslist.Add(code);
                }
                insuranceOptions.DataSource = optionalbenefitslist;
                insuranceOptions.DataValueField = "Code";
                insuranceOptions.DataTextField = "Name";
                insuranceOptions.DataBind();
                insuranceOptions.Items.Insert(0, "--Select Insurance Optional Benefit--");


            }
        }
        protected void previousstep_Click(object sender, EventArgs e)
        {
            string docNo = Request.QueryString["requisitionNo"].Trim();
            Response.Redirect("MotorCorporateClientApplications.aspx?requisitionNo=" + docNo + "&step=4");

        }
        protected void AddInsuranceBenefits_Click(object sender, EventArgs e)
        {

            var tinsuranceOptions = insuranceOptions.SelectedValue.Trim();
            var ttxtamounts = txtamounts.Text.Trim();
            string docNo = Request.QueryString["requisitionNo"].Trim();
            string RiskCode = Request.QueryString["Code"].Trim();
            var status = new Config().ObjNav().FnAddInsuranceOptionalBenefits(docNo, RiskCode, tinsuranceOptions, Convert.ToDecimal(ttxtamounts));
            var res = status.Split('*');
            if (res[0] == "success")
            {
                AutoPopulateOptionalBenefits_Onlick();
                individualinsurancefeedback.InnerHtml = "<div class='alert alert-success'>" + res[1] + "</div>";
                txtamounts.Text = Convert.ToString(0);
                insuranceOptions.DataSource = null;
            }
            else
            {
                individualinsurancefeedback.InnerHtml = "<div class='alert alert-danger'>" + res[1] + "</div>";

            }
        }
        protected void AutoPopulateOptionalBenefits_Onlick()
        {
            var nav = Config.ReturnNav();
            var RiskCode = Request.QueryString["Code"].Trim();
            var RequisitionNo = Request.QueryString["requisitionNo"].Trim();
            var applications = nav.RiskInsuranceOptions.Where(r => r.Client_App_No == RequisitionNo && r.Risk_Code == RiskCode);
            foreach (var application in applications)
            {
                txtoptionalbenefits.Text = Convert.ToString(application.Total_Options_Amount);
            }
        }
    }
}