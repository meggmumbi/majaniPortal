using MajaniPortal.Nav;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class NewPolicyQuote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NAV nav = Config.ReturnNav();
                List<DropDownList> list = new List<DropDownList>();
                var Customer = nav.Customer.ToList<Customer>();
                foreach (var item in Customer)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.No;
                    code.Name = item.No + " " + item.Name;
                    list.Add(code);
                }
                lblcustomers.DataSource = list;
                lblcustomers.DataValueField = "Code";
                lblcustomers.DataTextField = "Name";
                lblcustomers.DataBind();
                lblcustomers.Items.Insert(0, "--Select Policy Holder  No--");

                List<DropDownList> Salespersonslist = new List<DropDownList>();
                var Salespersons = nav.Salespeople_Purchasers.ToList();
                foreach (var item in Salespersons)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Code;
                    code.Name = item.Name;
                    Salespersonslist.Add(code);
                }
                lblAgentCode.DataSource = Salespersonslist;
                lblAgentCode.DataValueField = "Code";
                lblAgentCode.DataTextField = "Name";
                lblAgentCode.DataBind();
                lblAgentCode.Items.Insert(0, "--Select Agent SalesPerson Code--");

                var PolicyTypes = nav.PolicyTypes.Where(x => x.Business_Type == "Micro-Insurance").ToList();
                List<DropDownList> PolicyTypeslist = new List<DropDownList>();
                foreach (var item in PolicyTypes)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Policy_Type_Code;
                    code.Name = item.Policy_Type_Decription;
                    PolicyTypeslist.Add(code);
                }
                txtpolicytype.DataSource = PolicyTypeslist;
                txtpolicytype.DataValueField = "Code";
                txtpolicytype.DataTextField = "Name";
                txtpolicytype.DataBind();
                txtpolicytype.Items.Insert(0, "--Select Policy Types--");

                var MedicalSchedule = nav.MedicalSchedule.ToList();
                List<DropDownList> MedicalSchedulelist = new List<DropDownList>();
                foreach (var item in MedicalSchedule)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Benefit_Limit;
                    code.Name = item.Benefit_Limit;
                    MedicalSchedulelist.Add(code);
                }
                dhbs.DataSource = MedicalSchedulelist;
                dhbs.DataValueField = "Code";
                dhbs.DataTextField = "Name";
                dhbs.DataBind();
                dhbs.Items.Insert(0, "--Select DHB--");

                List<string> modeofpayment = new List<string>();
                modeofpayment.Add("-----Select Mode of Payments-------");
                modeofpayment.Add("KTDA check Off");
                modeofpayment.Add("KTDA Bonus");
                modeofpayment.Add("Mpesa");
                modeofpayment.Add("Other");
                modeofpayment.Add("Corporate Checkoff");
                lblmodeofpayments.DataSource = modeofpayment;
                lblmodeofpayments.DataBind();

                List<string> productbillingcycles = new List<string>();
                productbillingcycles.Add("-----Select Product Billing Cycle-------");
                productbillingcycles.Add("Month");
                productbillingcycles.Add("Two Months");
                productbillingcycles.Add("Quarter");
                productbillingcycles.Add("Half Year");
                productbillingcycles.Add("Year");
                productbillingcycles.Add("None");
                lblproductbillingCycle.DataSource = productbillingcycles;
                lblproductbillingCycle.DataBind();
                

                List<string> lblpolicybusinessType = new List<string>();
                lblpolicybusinessType.Add("-----Select Business Type-------");
                lblpolicybusinessType.Add("New");
                lblpolicybusinessType.Add("Existing");
                lblpolicybusinessType.Add("Renewal");
                lblpolicybusinessType.Add("Extension");
                lblpolicybusinessType.Add("Addition");
                lblpolicybusinessType.Add("Adjustment");
                lblpolicybusinessType.Add("Cancellation");
                lblmembertype.DataSource = lblpolicybusinessType;
                lblmembertype.DataBind();


                List<string> ttxtgender2 = new List<string>();
                ttxtgender2.Add("-----Select Gender-------");
                ttxtgender2.Add("Male");
                ttxtgender2.Add("Female");
                txtgender2.DataSource = ttxtgender2;
                txtgender2.DataBind();

                List<string> txtgend = new List<string>();
                txtgend.Add("-----Select Gender-------");
                txtgend.Add("Male");
                txtgend.Add("Female");
                txtgenders.DataSource = txtgend;
                txtgenders.DataBind();

                List<string> txtrelation = new List<string>();
                txtrelation.Add("-----Select Relationship------");
                txtrelation.Add("Spouse");
                txtrelation.Add("Father");
                txtrelation.Add("Daughter");
                txtrelation.Add("Son");
                txtrelation.Add("Brother");
                txtrelation.Add("Sister");
                txtrelation.Add("Mother");
                txtrelation.Add("Trust Fund");
                txtrelation.Add("Aunt");
                txtrelation.Add("Uncle");
                txtrelation.Add("Grand Mother");
                txtrelation.Add("Grand Father");
                txtrelation.Add("Guardian");
                txtrelation.Add("Sponsor");
                txtrelation.Add("Nephew");
                txtrelation.Add("Niece");
                txtrelationship.DataSource = txtrelation;
                txtrelationship.DataBind();


                List<string> bentxtrelation = new List<string>();
                bentxtrelation.Add("-----Select Relationship------");
                bentxtrelation.Add("Spouse");
                bentxtrelation.Add("Father");
                bentxtrelation.Add("Daughter");
                bentxtrelation.Add("Son");
                txtrelation.Add("Brother");
                bentxtrelation.Add("Sister");
                bentxtrelation.Add("Mother");
                bentxtrelation.Add("Trust Fund");
                bentxtrelation.Add("Aunt");
                bentxtrelation.Add("Uncle");
                bentxtrelation.Add("Grand Mother");
                bentxtrelation.Add("Grand Father");
                bentxtrelation.Add("Guardian");
                bentxtrelation.Add("Sponsor");
                bentxtrelation.Add("Nephew");
                bentxtrelation.Add("Niece");
                bentxtrelationships.DataSource = bentxtrelation;
                bentxtrelationships.DataBind();
                
                List<string> agentdetail = new List<string>();
                agentdetail.Add("-----Select Agent Details-------");
                agentdetail.Add("Direct Business");
                agentdetail.Add("Agent Business");
                agentdetail.Add("Referral Business");
                lblagentDetails.DataSource = agentdetail;
                lblagentDetails.DataBind();

                List<string> txtdependanttypes = new List<string>();
                txtdependanttypes.Add("-----Select Dependant Type-------");
                txtdependanttypes.Add("Adult");
                txtdependanttypes.Add("Child");
                txtdependanttype.DataSource = txtdependanttypes;
                txtdependanttype.DataBind();
            }
            }
        protected void Next_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string policyholderNo = lblcustomers.SelectedValue.Trim();
            if (policyholderNo.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Customer Category";
            }
            string policyType = txtpolicytype.SelectedValue.Trim();
            if (policyType.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Policy Type";
            }
            string typeofApplication = typeofapplication.Text.Trim();
            if (typeofApplication.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Type of Application";
            }
            int selectedIndex1 = lblmodeofpayments.SelectedIndex;
            if (selectedIndex1 < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Mode of Payments";
            }
            int selectedIndex2 = lblproductbillingCycle.SelectedIndex;
            if (selectedIndex2 < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Product Billing Cycle";
            }
            int selectedIndex3 = lblmembertype.SelectedIndex;
            if (selectedIndex3 < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Member Type";
            }
            int selectedIndex4 = lblagentDetails.SelectedIndex;
            if (selectedIndex4 < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Agent Detail";
            }
            string agentcode = lblAgentCode.Text.Trim();
            if (agentcode.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Agent Code";
            }
            string dhb =dhbs.Text.Trim();
            if (dhb.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for DHB";
            }
            string ttxtreferalmobilenumber = txtreferralMobileNumber.Text.Trim();
            string ttxtreferralName =txtreferralName.Text.Trim();
            string ttxtreferalidnumber = txtreferalidnumber.Text.Trim();
            try
            {
                if (flag)
                {
                    feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    string empNo = Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnExistingMicroInsuranceDetails(empNo, policyholderNo, policyType, typeofApplication, selectedIndex1, selectedIndex2, selectedIndex3, selectedIndex4, agentcode, dhb, ttxtreferalmobilenumber, ttxtreferralName, ttxtreferalidnumber);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("NewPolicyQuote.aspx?requisitionNo=" + res[2] + "&step=2");

                    }
                    else
                    {

                        feedbackdetails.InnerHtml = "<div class='alert alert-danger'>The New Client Application Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";
                    }
                }
            }
            catch (Exception ex)
            {
               feedbackdetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
            }
        }

        protected void nextstep_Click(object sender, EventArgs e)
        {
            int num1;
            string str;
            try
            {
                num1 = Convert.ToInt32(Request.QueryString["step"].Trim());
                str = Request.QueryString["requisitionNo"].Trim();
            }
            catch (Exception ex)
            {
                num1 = 0;
                str = "";
            }
            int num2 = num1 + 1;
            Response.Redirect("NewPolicyQuote.aspx?requisitionNo=" + str + "&step=" + (object)num2);
        }

        protected void previousstep_Click(object sender, EventArgs e)
        {
            int num1;
            string str;
            try
            {
                num1 = Convert.ToInt32(Request.QueryString["step"].Trim());
                str = Request.QueryString["requisitionNo"].Trim();
            }
            catch (Exception ex)
            {
                num1 = 0;
                str = "";
            }
            int num2 = num1 - 1;
            Response.Redirect("NewPolicyQuote.aspx?requisitionNo=" + str + "&step=" + num2);
        }

        protected void AddBeneficaries_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string beneficiary = txtbeneficiary.Text.Trim();
            if (beneficiary.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Beneficiary";
            }
            string name = txtnames.Text.Trim();
            if (name.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Name";
            }
            int selectedIndex = bentxtrelationships.SelectedIndex;
            if (selectedIndex < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Relationship";
            }
            string s = txtdobs.Text.Trim();
            if (s.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Date of Birth";
            }
            DateTime dateTime = new DateTime();
            DateTime exact = DateTime.ParseExact(s, "yyyy-MM-dd",CultureInfo.InvariantCulture);
            string idNo = txtidnumbers.Text.Trim();
            if (idNo.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for ID Number";
            }
            Decimal age = Convert.ToDecimal(txtages.Text.Trim());
            if (age < 1M)
            {
                flag = true;
                str = "Please Enter a Valid Value for Age";
            }
            if (txtgender2.Text.Trim().Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Gender";
            }
            Decimal allocation = Convert.ToDecimal(txtallocation.Text.Trim());
            if (allocation < 1M)
            {
                flag = true;
                str = "Please Enter a Valid Value for Allocation";
            }
            try
            {
                if (flag)
                {
                    txtbeneficiariesdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    string docNo = this.Request.QueryString["requisitionNo"].Trim();
                    var status = new Config().ObjNav().FnCreatePolicytBeneficiary(docNo, beneficiary, name, selectedIndex, exact, idNo, age, allocation);
                  var res =status.Split('*');
                    if (res[0] == "success")
                    {
                        txtbeneficiariesdetails.InnerHtml = "<div class='alert alert-success'>The Beneficiaries Details was successfully Added</div>";
                    }
                    else
                    {
                        txtbeneficiariesdetails.InnerHtml = "<div class='alert alert-danger'>The New Client Application Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";
                    }
                }
            }
            catch (Exception ex)
            {
                feedbackdetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
            }
        }

        protected void upload_Click(object sender, EventArgs e)
        {
            string path1 = ConfigurationManager.AppSettings["FilesLocation"] + "Existing Policy/";
            string str1 = Request.QueryString["requisitionNo"].Trim().Replace('/', '_').Replace(':', '_');
            string path2 = path1 + str1 + "/";
            if (filetoupload.HasFile)
            {
                try
                {
                    if (Directory.Exists(path1))
                    {
                        Path.GetExtension(filetoupload.FileName);
                        string extension = Path.GetExtension(filetoupload.FileName);
                        bool flag = true;
                        try
                        {
                            if (!Directory.Exists(path2))
                                Directory.CreateDirectory(path2);
                        }
                        catch (Exception ex)
                        {
                            flag = false;
                            documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                        }
                        if (flag)
                        {
                            if (new Config().IsAllowedExtension(extension))
                            {
                                string str2 = this.filetoupload.FileName.Replace(':', '_');
                                string str3 = path2 + str2;
                                string str4 = str3;
                                filetoupload.SaveAs(str3);
                                if (File.Exists(str3))
                                    documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                                else
                                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                            }
                            else
                              documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                        }
                        else
                            documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents folder defined does not exist in the server. Please contact support. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    }
                    else
                       documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again Later<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                catch (Exception ex)
                {
                   documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents could not be uploaded. Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
            }
            else
               documentsfeedback.InnerHtml = "<div class='alert alert-danger'>Please select the documents to upload. Both are required <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
        }

        protected void AddDependants_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string dependantCode =txtdependantcodes.Text.Trim();
            if (dependantCode.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Dependent Code";
            }
            string name = txtname.Text.Trim();
            if (name.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Name";
            }
            int selectedIndex1 = txtrelationship.SelectedIndex;
            if (selectedIndex1 < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Relationship";
            }
            string s = txtdateob.Text.Trim();
            if (s.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Date of Birth";
            }
            DateTime dateTime = new DateTime();
            DateTime exact = DateTime.ParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string idNo = txtidnumber.Text.Trim();
            if (idNo.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for ID Number";
            }
            Decimal age = Convert.ToDecimal(txtage.Text.Trim());
            if (age < 1M)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Age";
            }
            if (txtgenders.Text.Trim().Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Genders";
            }
            int selectedIndex2 = txtdependanttype.SelectedIndex;
            if (selectedIndex2 < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Dependent Type";
            }
            string dHB = dhb.Text.Trim();
            if (dHB.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for DHB";
            }
            Decimal premium = Convert.ToDecimal(dhbpremium.Text.Trim());
            if (premium < 1M)
            {
                flag = true;
                str = "Please Enter a Valid  Value for DHB Premium";
            }
            try
            {
                if (flag)
                {
                    txtdependantsfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    string docNo = this.Request.QueryString["requisitionNo"].Trim();
                    var status = new Config().ObjNav().FnCreatePolicyDependants(docNo, dependantCode, name, selectedIndex1, exact, idNo, age, selectedIndex2, dHB, premium);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        txtdependantsfeedbackdetails.InnerHtml = "<div class='alert alert-success'>The Dependants Details was successfully Added</div>";
                    }
                    else
                    {
                        txtdependantsfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>The New Client Application Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";
                    }
                }
            }
            catch (Exception ex)
            {
                this.feedbackdetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
            }
        }

        protected void Poducts_Onclick(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string ttxtpolicytype = this.txtpolicytype.SelectedValue.Trim();
            this.typeofapplication.DataSource =nav.Items.Where(x => x.Policy_Type == ttxtpolicytype && x.Insurance_Item_type == "Insurance").ToList();
            this.typeofapplication.DataTextField = "Description";
            this.typeofapplication.DataValueField = "No";
            this.typeofapplication.DataBind();
        }
    }
}
