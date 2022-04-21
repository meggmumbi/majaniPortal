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
    public partial class KYMPolicyAmendments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NAV nav = Config.ReturnNav();
                List<DropDownList> list = new List<DropDownList>();
                var Salespersons = nav.Salespeople_Purchasers.ToList();
                foreach (var item in Salespersons)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Code;
                    code.Name = item.Name;
                    list.Add(code);
                }
                policyTypes.DataSource = list;
                policyTypes.DataValueField = "Code";
                policyTypes.DataTextField = "Name";
                policyTypes.DataBind();
                policyTypes.Items.Insert(0, "--Select Agent SalesPerson Code--");

                var PolicyTypes = nav.PolicyTypes.Where(x => x.Business_Type == "Micro-Insurance").ToList();
                List<DropDownList> PolicyTypeslist = new List<DropDownList>();
                foreach (var item in PolicyTypes)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Policy_Type_Code;
                    code.Name = item.Policy_Type_Decription;
                    PolicyTypeslist.Add(code);
                }
                policyTypes.DataSource = PolicyTypeslist;
                policyTypes.DataValueField = "Code";
                policyTypes.DataTextField = "Name";
                policyTypes.DataBind();
                policyTypes.Items.Insert(0, "--Select Policy Types--");


                var ServiceContracts = nav.ServiceContracts.Where(x => x.Contract_Insurance_Type == "Insurance").ToList();
                List<DropDownList> ServiceContractslist = new List<DropDownList>();
                foreach (var item in ServiceContracts)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Contract_No;
                    code.Name = item.Customer_No + " " + item.Name;
                    ServiceContractslist.Add(code);
                }
                policyNumber.DataSource = ServiceContractslist;
                policyNumber.DataValueField = "Code";
                policyNumber.DataTextField = "Name";
                policyNumber.DataBind();
                policyNumber.Items.Insert(0, "--Select Policy No--");


                var Salesperson = nav.Salespeople_Purchasers.ToList();
                List<DropDownList> Salespersonslist = new List<DropDownList>();
                foreach (var item in Salesperson)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Code;
                    code.Name = item.Name;
                    Salespersonslist.Add(code);
                }
                agentcodes.DataSource = Salespersonslist;
                agentcodes.DataValueField = "Code";
                agentcodes.DataTextField = "Name";
                agentcodes.DataBind();
                agentcodes.Items.Insert(0, "--Select Agent SalesPerson Code--");

                List<string> txtrelationships = new List<string>();
                txtrelationships.Add("-----Select Title------");
                txtrelationships.Add("Spouse");
                txtrelationships.Add("Father");
                txtrelationships.Add("Daughter");
                txtrelationships.Add("Son");
                txtrelationships.Add("Brother");
                txtrelationships.Add("Sister");
                txtrelationships.Add("Mother");
                txtrelationships.Add("Trust Fund");
                txtrelationships.Add("Aunt");
                txtrelationships.Add("Uncle");
                txtrelationships.Add("Grand Mother");
                txtrelationships.Add("Grand Father");
                txtrelationships.Add("Guardian");
                txtrelationships.Add("Sponsor");
                txtrelationships.Add("Nephew");
                txtrelationships.Add("Niece");
                bentxtrelationships.DataSource = txtrelationships;
                bentxtrelationships.DataBind();


                List<string> txtdependanttypes = new List<string>();
                txtdependanttypes.Add("-----Select Agent Details-------");
                txtdependanttypes.Add("Adult");
                txtdependanttypes.Add("Child");
                txtdependanttype.DataSource = txtdependanttypes;
                txtdependanttype.DataBind();

                List<string> txtrelation = new List<string>();
                txtrelation.Add("-----Select Title------");
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

                List<string> txtgender = new List<string>();
                txtgender.Add("-----Select Gender-------");
                txtgender.Add("Male");
                txtgender.Add("Female");
                txtgender2.DataSource = txtgender;
                txtgender2.DataBind();

                List<string> txtgend = new List<string>();
                txtgend.Add("-----Select Gender-------");
                txtgend.Add("Male");
                txtgend.Add("Female");
                txtgenders.DataSource = txtgend;
                txtgenders.DataBind();

                List<string> modeofpayment = new List<string>();
                modeofpayment.Add("-----Select Mode of Payments-------");
                modeofpayment.Add("KTDA check Off");
                modeofpayment.Add("KTDA Bonus");
                modeofpayment.Add("Mpesa");
                modeofpayment.Add("Other");
                modeofpayment.Add("Corporate Checkoff");
                modeofpayments.DataSource = modeofpayment;
                modeofpayments.DataBind();

                List<string> agentdetail = new List<string>();
                agentdetail.Add("-----Select Agent Details-------");
                agentdetail.Add("Direct Business");
                agentdetail.Add("Agent Business");
                agentdetail.Add("Referral Business");
                agentdetails.DataSource = agentdetail;
                agentdetails.DataBind();


                List<string> productbillingcycles = new List<string>();
                productbillingcycles.Add("-----Select Product Billing Cycle-------");
                productbillingcycles.Add("Month");
                productbillingcycles.Add("Two Months");
                productbillingcycles.Add("Quarter");
                productbillingcycles.Add("Half Year");
                productbillingcycles.Add("Year");
                productbillingcycles.Add("None");
                productbillingcycle.DataSource = productbillingcycles;
                productbillingcycle.DataBind();
                
                List<string> lblpolicybusinessType = new List<string>();
                lblpolicybusinessType.Add("-----Select Product Billing Cycle-------");
                lblpolicybusinessType.Add("New");
                lblpolicybusinessType.Add("Existing");
                lblpolicybusinessType.Add("Renewal");
                lblpolicybusinessType.Add("Extension");
                lblpolicybusinessType.Add("Addition");
                lblpolicybusinessType.Add("Adjustment");
                lblpolicybusinessType.Add("Cancellation");
                membertypes.DataSource = lblpolicybusinessType;
                membertypes.DataBind();

            }
        }
        protected void Next_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string policyNo = policyNumber.SelectedValue.Trim();
            if (policyNo.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Policy No";
            }
            string policyType = policyTypes.SelectedValue.Trim();
            if (policyType.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Policy Type";
            }
            string typeofApplication =typeofapplications.Text.Trim();
            if (typeofApplication.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Type of Application";
            }
            int selectedIndex1 = modeofpayments.SelectedIndex;
            if (selectedIndex1 < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Mode of Payments";
            }
            int selectedIndex2 = productbillingcycle.SelectedIndex;
            if (selectedIndex2 < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Product Billing Cycle";
            }
            int selectedIndex3 = membertypes.SelectedIndex;
            if (selectedIndex3 < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Member Type";
            }
            int selectedIndex4 = agentdetails.SelectedIndex;
            if (selectedIndex4 < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Agent Details";
            }
            string agentCode = agentcodes.Text.Trim();
            if (agentCode.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Agent Code";
            }
            try
            {
                if (flag)
                {
                   feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    string empNo = this.Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnNewPolicyAmmendment(empNo, policyNo, policyType, typeofApplication, selectedIndex1, selectedIndex2, selectedIndex3, selectedIndex4, agentCode);
                    var res = status.Split('*');
                    if (res[0] == "success")
                       Response.Redirect("KYMPolicyAmendments.aspx?requisitionNo=" + res[2] + "&step=2");
                    else
                       feedbackdetails.InnerHtml = "<div class='alert alert-danger'>The New Client Application Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";
                }
            }
            catch (Exception ex)
            {
               feedbackdetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
            }
        }
        protected void AddBeneficaries_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string beneficiary = txtbeneficiary.Text.Trim();
            if (beneficiary.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Beneficiary";
            }
            string name = txtnames.Text.Trim();
            if (name.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Name";
            }
            int selectedIndex = bentxtrelationships.SelectedIndex;
            if (selectedIndex < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Relationship Type";
            }
            string s = txtdobs.Text.Trim();
            if (s.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Date of Birth";
            }
            DateTime dateTime = new DateTime();
            DateTime exact = DateTime.ParseExact(s, "yyyy-MM-dd",CultureInfo.InvariantCulture);
            string idNo =txtidnumbers.Text.Trim();
            if (idNo.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for ID Number";
            }
            Decimal age = Convert.ToDecimal(txtages.Text.Trim());
            if (age < 1M)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Age";
            }
            if (txtgender2.SelectedValue.Trim().Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Gender";
            }
            Decimal allocation = Convert.ToDecimal(txtallocation.Text.Trim());
            if (allocation < 1M)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Allocation";
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
                    string[] strArray = new Config().ObjNav().FnCreatePolicytBeneficiary(docNo, beneficiary, name, selectedIndex, exact, idNo, age, allocation).Split('*');
                    if (strArray[0] == "success")
                      txtbeneficiariesdetails.InnerHtml = "<div class='alert alert-success'>The Beneficiaries Details was successfully Added</div>";
                    else
                        txtbeneficiariesdetails.InnerHtml = "<div class='alert alert-danger'>Th New Client Application Details Could not be Submitted.Kindly Try Again" + strArray[1] + "</div>";
                }
            }
            catch (Exception ex)
            {
               feedbackdetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
            }
        }

        protected void AddDependants_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string dependantCode =txtdependantcodes.Text.Trim();
            if (dependantCode.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value  Dependant Code";
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
            string idNo = lblIdNumber.Text.Trim();
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
            if (txtgenders.SelectedValue.Trim().Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Gender";
            }
            int selectedIndex2 = txtdependanttype.SelectedIndex;
            if (selectedIndex2 < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Dependant Type";
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
                str = "Please Enter a Valid  Value for DHB Premimum";
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
                       txtdependantsfeedbackdetails.InnerHtml = "<div class='alert alert-success'>The Dependants Details was successfully Added</div>";
                    else
                     txtdependantsfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>The New Client Application Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";
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
           Response.Redirect("KYMPolicyAmendments.aspx?requisitionNo=" + str + "&step=" +num2);
        }

        protected void previousstep_Click(object sender, EventArgs e)
        {
            int num1;
            string str;
            try
            {
                num1 = Convert.ToInt32(this.Request.QueryString["step"].Trim());
                str = Request.QueryString["requisitionNo"].Trim();
            }
            catch (Exception ex)
            {
                num1 = 0;
                str = "";
            }
            int num2 = num1 - 1;
           Response.Redirect("KYMPolicyAmendments.aspx?requisitionNo=" + str + "&step=" +num2);
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
                                this.filetoupload.SaveAs(str3);
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

        protected void Poducts_Onclick(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string ttxtpolicytype = this.policyTypes.SelectedValue.Trim();
            this.typeofapplications.DataSource = nav.Items.Where(x => x.Policy_Type == ttxtpolicytype && x.Insurance_Item_type == "Insurance").ToList();
            this.typeofapplications.DataTextField = "Description";
            this.typeofapplications.DataValueField = "No";
            this.typeofapplications.DataBind();
        }
    }
}
