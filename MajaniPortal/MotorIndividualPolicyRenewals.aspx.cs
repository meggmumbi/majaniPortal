using MajaniPortal.Nav;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class MotorIndividualPolicyRenewals : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NAV nav = Config.ReturnNav();
                try
                {
                    var requisitionNo = Request.QueryString["QuoteNo"].Trim();
                    if (requisitionNo != null)
                    {
                        var productDetails = nav.SalesHeader.Where(x => x.No == requisitionNo);
                        foreach (var item in productDetails)
                        {
                            totalsvaluesuminsured.Text = Convert.ToString(item.Total_Value_Sum_Insured);
                            totalpremium.Text = Convert.ToString(item.Total_Premiums);
                        }
                    }
                    else
                    {

                    }
                }
                catch (Exception)
                {

                }

                List<string> tmodeofpayments = new List<string>();
                tmodeofpayments.Add("-----Select Grower Type of Applicants-------");
                tmodeofpayments.Add("KTDA check Off");
                tmodeofpayments.Add("KTDA Bonus");
                tmodeofpayments.Add("Mpesa");
                tmodeofpayments.Add("Other");
                tmodeofpayments.Add("Corporate Checkoff");
                tmodeofpayments.Add("Bank Deposit");
                tmodeofpayments.Add("Cheque");
                tmodeofpayments.Add("Cash Payments");
                tmodeofpayments.Add("Guarantor Form");
                tmodeofpayments.Add("Green Leaf");
                modeofpayments.DataSource = tmodeofpayments;
                modeofpayments.DataBind();

                List<string> tagentDetail = new List<string>();
                tagentDetail.Add("-----Select Agent Detail-------");
                tagentDetail.Add("Direct Business");
                //tagentDetail.Add("Agent Business");
                //tagentDetail.Add("Refferal Business");
                agentDetails.DataSource = tagentDetail;
                agentDetails.DataBind();


                var ApplicationNumber = Convert.ToString(Request.QueryString["ContractNo"]);
                if (ApplicationNumber != null)
                {
                    var Application = nav.ServiceContracts.Where(x => x.Contract_No == ApplicationNumber).ToList();
                    foreach (var item in Application)
                    {
                        var CustomerInfor = nav.Customer.Where(x => x.No == item.Customer_No).ToList();
                        foreach (var itemCustomer in CustomerInfor)
                        {
                            contractNo.Text = ApplicationNumber;
                            calenderDays.Text = item.Service_Period;
                            customerCategory.Text = item.Customer_Category;
                            if (item.Customer_Type == "Individual")
                            {
                                policyholdeName.Text = item.Name;
                            }
                            else
                            {
                                policyholdeName.Text = item.Corporate_Company_Name;
                            }
                            PolicyNumbes.Text = item.Policy_No;
                            MobileNumber.Text = item.Tel_Mobile_No;
                            customerCategory.Text = item.Customer_Category;
                            insurareName.Text = item.Insurer_Name;
                            policyType.Text = item.Policy_Type;
                        }
                    }
                }

            }
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string docNo = Request.QueryString["ContractNo"].Trim();
            string CustomerNo = Request.QueryString["CustomerNo"].Trim();
            string tstatDate = policyStartDates.Text;
            int tagentDetails = agentDetails.SelectedIndex;
            string tsalesgentcode = salesgentcode.SelectedValue.Trim();

            DateTime ttpolicystartDate = DateTime.Now;
            var tpolicystartDate = policyStartDates.Text.Trim();
            if (tpolicystartDate.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            else
            {
                ttpolicystartDate = DateTime.ParseExact(tpolicystartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            int tmodeofpayments = 0;
            if (modeofpayments.SelectedIndex > 1)
            {
                tmodeofpayments = modeofpayments.SelectedIndex;

            }
            else
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            var tpaymentsReferenceCode = paymentsReferenceCode.Text.Trim();
            if (tpaymentsReferenceCode.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            var tpaidAmount = paidAmount.Text.Trim();
            if (tpaidAmount.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            DateTime tdatepaid = DateTime.Now;
            var ttdatepaid = datepaid.Text.Trim();
            if (ttdatepaid.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            else
            {
                tdatepaid = DateTime.ParseExact(ttdatepaid, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            try
            {
                if (flag)
                {
                    feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    string empNo = Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnNewMotorIndividualPolicyRenewals(docNo, ttpolicystartDate, tagentDetails, tsalesgentcode, tmodeofpayments, tpaymentsReferenceCode, tdatepaid, Convert.ToDecimal(tpaidAmount));
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("MotorIndividualPolicyRenewals.aspx?ContractNo=" + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + res[2] + "&step=2");

                    }
                    else
                    {
                        feedbackdetails.InnerHtml = "<div class='alert alert-danger'>The Policy Renewal Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";

                    }
                }
            }
            catch (Exception ex)
            {
                feedbackdetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
            }
        }

        protected void UpdateRiskDetails_Click(object sender, EventArgs e)
        {

            string docNo = Request.QueryString["QuoteNo"].Trim();
            string CustomerNo = Request.QueryString["CustomerNo"].Trim();
            var tregistrationNumber = registrationNumber.Text.Trim();
            var tvalueinsured = valueinsured.Text.Trim();
            var Applicant = Session["empNo"].ToString();
            var status = new Config().ObjNav().FnUpdateMotorIndividualPolicySumInsured(Applicant, docNo, tregistrationNumber, Convert.ToDecimal(tvalueinsured));
            var res = status.Split('*');
            if (res[0] == "success")
            {
                submitApplications.InnerHtml = "<div class='alert alert-success'>" + res[1] + "</div>";

            }
            else
            {
                submitApplications.InnerHtml = "<div class='alert alert-danger'>" + res[1] + "</div>";

            }
        }
        protected void SubmitApplication_Click(object sender, EventArgs e)
        {
            try
            {
                var step = Convert.ToInt32(Request.QueryString["step"].Trim());
                var Requisition = Request.QueryString["QuoteNo"].Trim();
                var status = new Config().ObjNav().SendMotoRenewalIndividualClientApplicationApproval(Requisition);
                var res = status.Split('*');
                if (res[0] == "success")
                {
                    Response.Redirect("MotorPolicies.aspx");
                }
                else
                {
                    submitApplications.InnerHtml = "<div class='alert alert-danger'>The Motor Policy Renewal Details Could not be Submitted for Approval" + res[1] + "</div>";

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        protected void validateEndDate_Click(object sender, EventArgs e)
        {

            var PolicyStartDate = policyStartDates.Text.Trim();
            DateTime tPolicyStartDate = DateTime.ParseExact(PolicyStartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            int tduration = (365 - 1);
            DateTime tPolicyEndDate = tPolicyStartDate.AddDays(tduration);
            policyEndDates.Text = Convert.ToDateTime(tPolicyEndDate).ToString("MM/dd/yyyy");

        }

        protected void PostCodes_OnClick(object sender, EventArgs e)
        {

        }
        protected void nextstep_Click(object sender, EventArgs e)
        {
            int num1;
            string str;
            string docNo = Request.QueryString["ContractNo"].Trim();
            string CustomerNo = Request.QueryString["CustomerNo"].Trim();
            string QuoteNo = Request.QueryString["QuoteNo"].Trim();
            try
            {
                num1 = Convert.ToInt32(Request.QueryString["step"].Trim());

            }
            catch (Exception ex)
            {
                num1 = 0;
                str = "";
            }
            int num2 = num1 + 1;
            Response.Redirect("MotorIndividualPolicyAmmendments.aspx?ContractNo=" + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=" + num2);

        }

        protected void previousstep_Click(object sender, EventArgs e)
        {
            int num1;
            string str;
            string docNo = Request.QueryString["ContractNo"].Trim();
            string CustomerNo = Request.QueryString["CustomerNo"].Trim();
            string QuoteNo = Request.QueryString["QuoteNo"].Trim();
            try
            {
                num1 = Convert.ToInt32(Request.QueryString["step"].Trim());

            }
            catch (Exception ex)
            {
                num1 = 0;
                str = "";
            }
            int num2 = num1 - 1;
            Response.Redirect("MotorIndividualPolicyAmmendments.aspx?ContractNo=" + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=" + num2);
        }


        protected void GetTotalValueSumInsured_Onlick()
        {
            NAV nav = Config.ReturnNav();
            var requisitionNo = Request.QueryString["QuoteNo"].Trim();
            var productDetails = nav.SalesHeader.Where(x => x.No == requisitionNo);
            foreach (var item in productDetails)
            {
                totalsvaluesuminsured.Text = Convert.ToString(item.Total_Value_Sum_Insured);
                totalpremium.Text = Convert.ToString(item.Total_Premiums);
                totalpremiumspayables.Text = "";
            }
        }

        protected void AgentDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tagentDetail = agentDetails.SelectedIndex;
            string agentdetaildescription = "";
            if (tagentDetail == 1)
            {
                agentdetaildescription = "Direct Business";
                //agentsalespersoncode.Visible = true;
                //salesgentcode.Visible = true;
                //referralname.Visible = false;
                //txtrefferalname.Visible = false;
                //referralnumber.Visible = false;
                //txtreferalidnumber.Visible = false;
                //referalmobilenumber.Visible = false;
                //txtreferalmobilenumber.Visible = false;
                SalesAgendCodes_SelectedIndexChanged();
            }
            if (tagentDetail == 2)
            {
                agentdetaildescription = "Agent Business";
                //agentsalespersoncode.Visible = true;
                //salesgentcode.Visible = true;
                //referralname.Visible = false;
                //txtrefferalname.Visible = false;
                //referralnumber.Visible = false;
                //txtreferalidnumber.Visible = false;
                //referalmobilenumber.Visible = false;
                //txtreferalmobilenumber.Visible = false;
                SalesAgendCodes_SelectedIndexChanged();
            }
            //if (tagentDetail == 3)
            //{
            //    agentdetaildescription = "Refferal Business";
            //    agentsalespersoncode.Visible = false;
            //    salesgentcode.Visible = false;
            //    referralname.Visible = true;
            //    txtrefferalname.Visible = true;
            //    referralnumber.Visible = true;
            //    txtreferalidnumber.Visible = true;
            //    referalmobilenumber.Visible = true;
            //    txtreferalmobilenumber.Visible = true;
            //    SalesAgendCodes_SelectedIndexChanged();
            //}
        }
        protected void SalesAgendCodes_SelectedIndexChanged()
        {
            int tagentDetail = agentDetails.SelectedIndex;
            string agentdetaildescription = "";
            if (tagentDetail == 1)
            {
                NAV nav = Config.ReturnNav();
                var Salesperson = nav.ResponsibilityCenters.Where(x => x.Operating_Unit_Type == "Region");
                List<DropDownList> Salespersonslist = new List<DropDownList>();
                foreach (var item in Salesperson)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Code;
                    code.Name = item.Name;
                    Salespersonslist.Add(code);
                }
                salesgentcode.DataSource = Salespersonslist;
                salesgentcode.DataValueField = "Code";
                salesgentcode.DataTextField = "Name";
                salesgentcode.DataBind();
                salesgentcode.Items.Insert(0, "--Select Region Code--");

            }
            else
            {
                NAV nav = Config.ReturnNav();
                var Salesperson = nav.Salespeople_Purchasers.ToList();
                List<DropDownList> Salespersonslist = new List<DropDownList>();
                foreach (var item in Salesperson)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Code;
                    code.Name = item.Name;
                    Salespersonslist.Add(code);
                }
                salesgentcode.DataSource = Salespersonslist;
                salesgentcode.DataValueField = "Code";
                salesgentcode.DataTextField = "Name";
                salesgentcode.DataBind();
                salesgentcode.Items.Insert(0, "--Select Agent SalesPerson Code--");
            }
        }
        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
    }
}