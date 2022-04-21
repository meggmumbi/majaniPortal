using MajaniPortal.Nav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class NewAgentOnboarding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empNo"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    NAV nav = Config.ReturnNav();
                    List<DropDownList> CustomerCategorylist = new List<DropDownList>();
                    var FactoriesCategory = nav.KTDAFactories.ToList();
                    foreach (var item in FactoriesCategory)
                    {
                        DropDownList itemlist = new DropDownList();
                        itemlist.Code = item.Code;
                        itemlist.Name = item.Factory_Branch_Name;
                        CustomerCategorylist.Add(itemlist);
                    }
                    factorycode.DataSource = CustomerCategorylist;
                    factorycode.DataValueField = "Code";
                    factorycode.DataTextField = "Name";
                    factorycode.DataBind();
                    factorycode.Items.Insert(0, "--Select Factory Name--");


                    List<DropDownList> AgentsCategorylist = new List<DropDownList>();
                    var AgentsCategory = nav.CommissionGroup.Where(x => x.Onboard == true).ToList();
                    foreach (var item in AgentsCategory)
                    {
                        DropDownList itemlist = new DropDownList();
                        itemlist.Code = item.Code;
                        itemlist.Name = item.Description;
                        AgentsCategorylist.Add(itemlist);
                    }
                    agentcategory.DataSource = AgentsCategorylist;
                    agentcategory.DataValueField = "Code";
                    agentcategory.DataTextField = "Name";
                    agentcategory.DataBind();
                    agentcategory.Items.Insert(0, "--Select Agent Category--");
                }

            }
        }
        protected void SubmitApplications_Click(object sender, EventArgs e)
        {
            var tfactorycode = factorycode.SelectedValue.Trim();
            var tagentcategory = agentcategory.SelectedValue.Trim();
            var ttxtName = txtName.Text.Trim();
            var ttxtidNumber = txtidNumber.Text.Trim();
            var ttxtmobileNumber = txtmobileNumber.Text.Trim();
            string empNo = this.Session["empNo"].ToString();
            var status = new Config().ObjNav().FnNewBCCAgentDetails(empNo, tfactorycode, tagentcategory, ttxtName, ttxtidNumber, ttxtmobileNumber);
            var res = status.Split('*');
            if (res[0] == "success")
            {
                Response.Redirect("AgentsLists.aspx");
            }
            else
            {

                feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + res[1] + "</div>";

            }

        }
    }
}