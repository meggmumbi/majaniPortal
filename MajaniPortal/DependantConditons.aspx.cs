using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class DependantConditons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var Conditions = Config.ReturnNav().PreExistingConditions.ToList();
                List<DropDownList> Conditionslist = new List<DropDownList>();
                foreach (var item in Conditions)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.code;
                    code.Name = item.Description;
                    Conditionslist.Add(code);
                }
                txtConditionName.DataSource = Conditionslist;
                txtConditionName.DataValueField = "Code";
                txtConditionName.DataTextField = "Name";
                txtConditionName.DataBind();
                txtConditionName.Items.Insert(0, "--Select Pre Existing Conditions--");
            }
        }
        
       protected void previousstep_Click(object sender, EventArgs e)
        {
            string docNo = Request.QueryString["requisitionNo"].Trim();
            string GrowerNumber = Request.QueryString["GrowerNumber"].Trim();
            Response.Redirect("KYMIndividualClientApplication.aspx?requisitionNo=" + docNo + "&&GrowerNumber="+ GrowerNumber+ "&step=4");

        }
        protected void AddConditions_Click(object sender, EventArgs e)
        {
            var ttxtConditionName = txtConditionName.SelectedValue.Trim();
            string tDependantNo = Request.QueryString["DependantNo"].Trim();
            string docNo = Request.QueryString["requisitionNo"].Trim();
            var status = new Config().ObjNav().FnAddDependantConditions(docNo, ttxtConditionName, tDependantNo);
            var res = status.Split('*');
            if (res[0] == "success")
            {

                conditionsfeedback.InnerHtml = "<div class='alert alert-success'>" + res[1] + "</div>";
            }
            else
            {
                conditionsfeedback.InnerHtml = "<div class='alert alert-danger'>" + res[1] + "</div>";

            }
        }
    }
}