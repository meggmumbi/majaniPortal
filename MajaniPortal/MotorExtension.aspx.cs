using MajaniPortal.Nav;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class MotorExtension : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                NAV nav = Config.ReturnNav();
                List<DropDownList> Cutsomerslist = new List<DropDownList>();
                var Customers = nav.Customer.ToList();
                foreach (var item in Customers)
                {
                    DropDownList itemlist = new DropDownList();
                    itemlist.Code = item.No;
                    itemlist.Name = item.No+"_"+item.Name;
                    Cutsomerslist.Add(itemlist);
                }
                customerNo.DataSource = Cutsomerslist;
                customerNo.DataValueField = "Code";
                customerNo.DataTextField = "Name";
                customerNo.DataBind();
                customerNo.Items.Insert(0, "--Select Customer Name--");


                List<DropDownList> policylist = new List<DropDownList>();
                var Policies = nav.ServiceContracts.Where(c=>c.Business_Type=="General").ToList();
                foreach (var item in Policies)
                {
                    DropDownList itemlist = new DropDownList();
                    itemlist.Code = item.Contract_No;
                    itemlist.Name = item.Contract_No+"_"+item.Name;
                    policylist.Add(itemlist);
                }
                contractNo.DataSource = policylist;
                contractNo.DataValueField = "Code";
                contractNo.DataTextField = "Name";
                contractNo.DataBind();
                contractNo.Items.Insert(0, "--Select Policy Name--");

                var tcustomerNo = Convert.ToString(Request.QueryString["customerNo"]);
                if (tcustomerNo != null)
                {
                    List<DropDownList> motorpolicyrislist = new List<DropDownList>();
                    var riskdetails = nav.PolicyRiskDetails.Where(c => c.Customer_No == tcustomerNo).ToList();
                    foreach (var item in riskdetails)
                    {
                        DropDownList itemlist = new DropDownList();
                        itemlist.Code = item.Code;
                        itemlist.Name = item.Registration_No;
                        motorpolicyrislist.Add(itemlist);
                    }
                    txtriskCode.DataSource = motorpolicyrislist;
                    txtriskCode.DataValueField = "Code";
                    txtriskCode.DataTextField = "Name";
                    txtriskCode.DataBind();
                    txtriskCode.Items.Insert(0, "--Select Risk Code--");
                }
            }
        }
        protected void Contracts_Onclick(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string tcustomerNo = customerNo.SelectedValue.Trim();
            var customerdetails = nav.Customer.Where(x => x.No == tcustomerNo).ToList();
            foreach (var item in customerdetails)
            {
                corporateName.Text = item.Corporate_Company_Name;
                firstName.Text = item.First_Name;
                middleName.Text = item.Middle_Name;
                lastname.Text = item.Last_Name;
                idNumber.Text = item.ID_No_Passport_No;
            }
            var tPolicies= nav.ServiceContracts.Where(x => x.Customer_No == tcustomerNo);
            List<DropDownList> tPolicieslist = new List<DropDownList>();
            foreach (var item in tPolicies)
            {
                DropDownList itemlist = new DropDownList();
                itemlist.Code = item.Contract_No;
                itemlist.Name = item.Contract_No + "_" + item.Name;
                tPolicieslist.Add(itemlist);
            }
            contractNo.DataSource = tPolicieslist;
            contractNo.DataValueField = "Code";
            contractNo.DataTextField = "Name";
            contractNo.DataBind();
            contractNo.Items.Insert(0, "--Select Policy Name--");
        }
        protected void PolicyDetails_Onclick(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string tcontractNo = contractNo.SelectedValue.Trim();
            var tPolicies = nav.ServiceContracts.Where(x => x.Contract_No == tcontractNo);
            foreach (var item in tPolicies)
            {
                policyNo.Text = item.Policy_No;
            }
        }
        protected void RiskDetails_Onclick(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string ttxtriskCode = txtriskCode.SelectedValue.Trim();
            var riskdetails = nav.PolicyRiskDetails.Where(x => x.Code == ttxtriskCode);
            foreach (var item in riskdetails)
            {
                txtRegistration.Text = item.Registration_No;
                txtMake.Text = item.Make;
                txtModel.Text = item.Model;
            }
        }
        protected void validateEndDate_Click(object sender, EventArgs e)
        {
            string RequsitionNumber = Request.QueryString["requisitionNo"].Trim();
            var tcertificateStartDate = certificateStartDate.Text.Trim();
            DateTime tPolicyStartDate = DateTime.ParseExact(tcertificateStartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            int tduration = (Convert.ToInt32(certificateperiod.Text.Trim()) - 1);
            DateTime tPolicyEndDate = tPolicyStartDate.AddDays(tduration);
            certificateendDate.Text = Convert.ToDateTime(tPolicyEndDate).ToString("MM-dd-yyyy");

        }
        protected void Next_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string tcustomerNo = customerNo.SelectedValue.Trim();
            if (tcustomerNo.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tcontractNo = contractNo.SelectedValue.Trim();
            if (tcontractNo.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tpaymentamount = paymentamount.Text.Trim();
            if (tpaymentamount.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tpaymentreferenceCode = paymentreferenceCode.Text.Trim();
            if (tpaymentreferenceCode.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tdatepaid = datepaid.Text.Trim();
            if (tdatepaid.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
           
            try
            {
                if (flag)
                {
                    feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                   
                    DateTime datespaid = DateTime.ParseExact(tdatepaid, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    string empNo = this.Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnMotorGeneralDetailsExtension(tcustomerNo, tcontractNo,Convert.ToDecimal(tpaymentamount), tpaymentreferenceCode, datespaid);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("MotorExtension.aspx?requisitionNo=" + res[2] + "&customerNo=" + tcustomerNo + "&step=2");

                    }
                    else
                    {
                        feedbackdetails.InnerHtml = "<div class='alert alert-danger'>The Motor Extension Application Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";

                    }
                }
            }
            catch (Exception ex)
            {
                feedbackdetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Applications Details." + ex.Message + "</div>";
            }
        }
        protected void InitiateExtension_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string ttxtriskCode = txtriskCode.SelectedValue.Trim();
            if (ttxtriskCode.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tcertificateStartDate = certificateStartDate.Text.Trim();
            if (tcertificateStartDate.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tcertificateperiod = certificateperiod.Text.Trim();
            if (tcertificateperiod.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            try
            {
                if (flag)
                {
                    feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    string RequsitionNumber = Request.QueryString["requisitionNo"].Trim();
                    DateTime datecertificateStartDate = DateTime.ParseExact(tcertificateStartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    string empNo = this.Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnMotorExtensionVehicleDetails(ttxtriskCode, RequsitionNumber, datecertificateStartDate,Convert.ToInt32(tcertificateperiod));
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("Default.aspx");
                        feedbackdetails.InnerHtml = "<div class='alert alert-danger'>The Motor Extension Application Details has been successfully Submitted"+ "</div>";
                    }
                    else
                    {
                        feedbackdetails.InnerHtml = "<div class='alert alert-danger'>The Motor Extension Application Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";

                    }
                }
            }
            catch (Exception ex)
            {
                feedbackdetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Applications Details." + ex.Message + "</div>";
            }
        }
    }
}