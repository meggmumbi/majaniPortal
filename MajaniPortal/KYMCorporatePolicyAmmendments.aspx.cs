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
    public partial class KYMCorporatePolicyAmmendments : System.Web.UI.Page
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
                    List<string> tmodeofpayments = new List<string>();
                    tmodeofpayments.Add("-----Select Grower Type of Applicants-------");
                    tmodeofpayments.Add("KTDA check Off");
                    tmodeofpayments.Add("KTDA Bonus");
                    tmodeofpayments.Add("Mpesa");
                    tmodeofpayments.Add("Other");
                    tmodeofpayments.Add("Corporate Checkoff");
                    tmodeofpayments.Add("Cheque");
                    tmodeofpayments.Add("Bank Deposit");
                    tmodeofpayments.Add("Cheque");
                    tmodeofpayments.Add("Cash Payments");
                    tmodeofpayments.Add("Guarantor Form");
                    tmodeofpayments.Add("Green Leaf");
                    modeofpaymentss.DataSource = tmodeofpayments;
                    modeofpaymentss.DataBind();

                    List<string> tlblpolicybusinessType = new List<string>();
                    tlblpolicybusinessType.Add("Existing");
                    membertypes.DataSource = tlblpolicybusinessType;
                    membertypes.DataBind();
                    
                    List<string> ttxtrelationships = new List<string>();
                    ttxtrelationships.Add("-----Select Relationship------");
                    ttxtrelationships.Add("Spouse");
                    ttxtrelationships.Add("Daughter");
                    ttxtrelationships.Add("Son");
                    txtrelationship.DataSource = ttxtrelationships;
                    txtrelationship.DataBind();

                    List<string> benttxtrelationships = new List<string>();
                    benttxtrelationships.Add("-----Select Relationship------");
                    benttxtrelationships.Add("Spouse");
                    benttxtrelationships.Add("Father");
                    benttxtrelationships.Add("Daughter");
                    benttxtrelationships.Add("Son");
                    benttxtrelationships.Add("Brother");
                    benttxtrelationships.Add("Sister");
                    benttxtrelationships.Add("Mother");
                    benttxtrelationships.Add("Trust Fund");
                    benttxtrelationships.Add("Aunt");
                    benttxtrelationships.Add("Uncle");
                    benttxtrelationships.Add("Grand Mother");
                    benttxtrelationships.Add("Grand Father");
                    benttxtrelationships.Add("Guardian");
                    benttxtrelationships.Add("Sponsor");
                    benttxtrelationships.Add("Nephew");
                    benttxtrelationships.Add("Niece");
                    bentxtrelationships.DataSource = benttxtrelationships;
                    bentxtrelationships.DataBind();

                    List<DropDownList> lblagentsubcategorylist = new List<DropDownList>();
                    var tlblagentsubcategory = nav.CommissionGroup.ToList();
                    foreach (var item in tlblagentsubcategory)
                    {
                        DropDownList itemlist = new DropDownList();
                        itemlist.Code = item.Code;
                        itemlist.Name = item.Description;
                        lblagentsubcategorylist.Add(itemlist);
                    }
                    lblagentsubcategorydetail.DataSource = lblagentsubcategorylist;
                    lblagentsubcategorydetail.DataValueField = "Code";
                    lblagentsubcategorydetail.DataTextField = "Name";
                    lblagentsubcategorydetail.DataBind();
                    lblagentsubcategorydetail.Items.Insert(0, "--Select Agent Sub Category--");


                    var ttNatureofBusiness = nav.NatureofBusiness.ToList();
                    List<DropDownList> ttNatureofBusinesslist = new List<DropDownList>();
                    foreach (var item in ttNatureofBusiness)
                    {
                        DropDownList itemcodelist = new DropDownList();
                        itemcodelist.Code = item.Code;
                        itemcodelist.Name = item.Name;
                        ttNatureofBusinesslist.Add(itemcodelist);
                    }


                    List<string> productbillingcycles = new List<string>();
                    productbillingcycles.Add("-----Select Product Billing Cycle-------");
                    productbillingcycles.Add("Month");
                    invoiceperiod.DataSource = productbillingcycles;
                    invoiceperiod.DataBind();
                    
                    List<string> ttxtgend = new List<string>();
                    ttxtgend.Add("-----Select Gender-------");
                    ttxtgend.Add("Male");
                    ttxtgend.Add("Female");
                    txtgenders.DataSource = ttxtgend;
                    txtgenders.DataBind();

                    var ApplicationNumber = Convert.ToString(Request.QueryString["ContractNo"]);
                    if (ApplicationNumber != null)
                    {
                        var Application = nav.ServiceContracts.Where(x => x.Contract_No == ApplicationNumber).ToList();
                        foreach (var item in Application)
                        {
                            var CustomerInfor = nav.Customer.Where(x => x.No == item.Customer_No).ToList();
                            foreach (var itemCustomer in CustomerInfor)
                            {
                                customerCategorydetails.Text = item.Customer_Category;
                                subcustomerCategordetail.Text = item.Customer_Sub_Category;
                                applicanttypes.Text = item.Applicant_Type;
                                growerNumber.Text = item.Grower_No_Client_ID;
                                txtFactoryCode.Text = item.Factory_Code_Branch_Code;
                                ttxtFactoryName.Text = item.Factory_Name_Branch_Name;
                                growerapplicanttypes.Text = itemCustomer.Grower_Type_of_Applicant;
                                txtcompanyname.Text = itemCustomer.Company_Name;
                                countryresidences.Text = itemCustomer.Nationality;
                                lblcountiess.Text = item.County;
                                telnumber1.Text = item.Tel_Mobile_No;
                                telnumber2.Text = itemCustomer.Tel_Mobile_No_2;
                                txtaddress.Text = item.Address;
                                tnatureofbusinessess.Text = item.Nature_of_Business_Sector;
                                certificateofincpoperation.Text = itemCustomer.Cert_of_Incorporation_No;
                                officelocation.Text = itemCustomer.Office_Location;
                                txtbuilding.Text = itemCustomer.Building;
                                bankaccountNumber.Text = itemCustomer.Bank_A_C_No;
                                bankaccountname.Text = itemCustomer.Bank_Name;
                                krapinnumber.Text = item.KRA_Pin_No;
                                txtgoogle.Text = itemCustomer.Google;
                                txttwitter.Text = itemCustomer.Twitter;
                                txtfcebook.Text = itemCustomer.Facebook;
                                txtlinkedin.Text = itemCustomer.LinkedIn;
                                lblproduct.Text = item.Product;
                                insurer.Text = item.Insurer;
                                serviceperiod.Text = item.Service_Period;
                                lbldepartmentdetails.Text = item.Business_Type;
                                lblpolicyTypedetails.Text = item.Policy_Type;
                                lblproduct.Text = item.Product;
                                insurer.Text = item.Insurer;
                                serviceperiod.Text = item.Service_Period;
                                dailyhealthbenefits.SelectedValue = item.DHB;
                            }
                        }
                        string tpoduct = lblproduct.Text.Trim();
                        var MedicalSchedule = nav.MedicalSchedule.Where(x => x.Product_Code == tpoduct && x.Premium_TB_Options == "ADULT").ToList();
                        List<DropDownList> MedicalSchedulelist = new List<DropDownList>();
                        foreach (var item in MedicalSchedule)
                        {
                            DropDownList code = new DropDownList();
                            code.Code = item.Benefit_Limit;
                            code.Name = item.Benefit_Limit;
                            MedicalSchedulelist.Add(code);
                        }
                        dailyhealthbenefits.DataSource = MedicalSchedulelist;
                        dailyhealthbenefits.DataValueField = "Code";
                        dailyhealthbenefits.DataTextField = "Name";
                        dailyhealthbenefits.DataBind();
                        dailyhealthbenefits.Items.Insert(0, "--Select DHB--");
                    }

                    hasgrowerNo.Checked = true;
                    growerdetails.Visible = true;

                    List<string> tdependantconditions = new List<string>();
                    tdependantconditions.Add("-----Select------");
                    tdependantconditions.Add("Yes");
                    tdependantconditions.Add("No");
                    dependantconditions.DataSource = tdependantconditions;
                    dependantconditions.DataBind();

                    List<string> tagentDetail = new List<string>();
                    tagentDetail.Add("-----Select Agent Detail-------");
                    tagentDetail.Add("Direct Business");
                    tagentDetail.Add("Agent Business");
                    tagentDetail.Add("Refferal Business");
                    agentDetail.DataSource = tagentDetail;
                    agentDetail.DataBind();

                    financier.Visible = false;

                }

            }

        }
        protected void DeleteDependant_Click(object sender, EventArgs e)
        {
            var tremovedependantCode = removedependantCode.Text.Trim();
            string docNo = Request.QueryString["QuoteNo"].Trim();
            var Applicant = Session["empNo"].ToString();
            var status = new Config().ObjNav().DeleteClientPolicyAmendmentssDependant(docNo, tremovedependantCode);
            var res = status.Split('*');
            if (res[0] == "success")
            {
                txtdependantsfeedbackdetails.InnerHtml = "<div class='alert alert-success'>" + res[1] + "</div>";

            }
            else
            {
                txtdependantsfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + res[1] + "</div>";

            }
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string docNo = Request.QueryString["ContractNo"].Trim();
            string GrowerNo = Request.QueryString["GrowerNo"].Trim();
            string CustomerNo = Request.QueryString["CustomerNo"].Trim();
            try
            {
                if (flag)
                {
                    feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    string empNo = Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnNewPolicyAmmendmentscorporate(docNo);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("KYMCorporatePolicyAmmendments.aspx?GrowerNo=" + GrowerNo + "&&ContractNo=" + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + res[2] + "&step=2");

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
        protected void VadlidateBeneficiary_Click(object sender, EventArgs e)
        {

            string docNo = Request.QueryString["ContractNo"].Trim();
            string GrowerNo = Request.QueryString["GrowerNo"].Trim();
            string CustomerNo = Request.QueryString["CustomerNo"].Trim();
            string QuoteNo = Request.QueryString["QuoteNo"].Trim();
            var status = new Config().ObjNav().FnValidateClientBeneficiaryPolicyAmmendments(docNo);
            var res = status.Split('*');
            if (res[0] == "success")
            {
                Response.Redirect("KYMCorporatePolicyAmmendments.aspx?GrowerNo=" + GrowerNo + "&&ContractNo=" + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=5");
            }
            if (res[0] == "missingconditions")
            {
                txtdependantsfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + res[1] + "</div>";

            }
            else
            {
                benefeciariesfeedback.InnerHtml = "<div class='alert alert-danger'>Kindly Fill in at least One Beneficiary Details before you proceed." + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

            }
        }
        protected void AgentDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tagentDetail = agentDetail.SelectedIndex;
            var tagentnSubCategoryDetail = lblagentsubcategorydetail.SelectedValue.Trim();
            string agentdetaildescription = "";
            if (tagentDetail == 1)
            {
                agentdetaildescription = "Direct Business";
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
                lblsalesgentcode.DataSource = Salespersonslist;
                lblsalesgentcode.DataValueField = "Code";
                lblsalesgentcode.DataTextField = "Name";
                lblsalesgentcode.DataBind();
                lblsalesgentcode.Items.Insert(0, "--Select Region Code--");

            }


            if (tagentDetail == 2)
            {
                agentdetaildescription = "Agent Business";
                NAV nav = Config.ReturnNav();
                var Salesperson = nav.Salespeople_Purchasers.Where(x => x.Agent_Category == tagentnSubCategoryDetail).ToList();
                List<DropDownList> Salespersonslist = new List<DropDownList>();
                foreach (var item in Salesperson)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Code;
                    code.Name = item.Name;
                    Salespersonslist.Add(code);
                }
                lblsalesgentcode.DataSource = Salespersonslist;
                lblsalesgentcode.DataValueField = "Code";
                lblsalesgentcode.DataTextField = "Name";
                lblsalesgentcode.DataBind();
                lblsalesgentcode.Items.Insert(0, "--Select Agent SalesPerson Code--");
            }
            if (tagentDetail == 3)
            {
                agentdetaildescription = "Refferal Business";
                NAV nav = Config.ReturnNav();
                var Salesperson = nav.Salespeople_Purchasers.Where(x => x.Agent_Category == tagentnSubCategoryDetail).ToList();
                List<DropDownList> Salespersonslist = new List<DropDownList>();
                foreach (var item in Salesperson)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Code;
                    code.Name = item.Name;
                    Salespersonslist.Add(code);
                }
                lblsalesgentcode.DataSource = Salespersonslist;
                lblsalesgentcode.DataValueField = "Code";
                lblsalesgentcode.DataTextField = "Name";
                lblsalesgentcode.DataBind();
                lblsalesgentcode.Items.Insert(0, "--Select Agent SalesPerson Code--");
            }
        }
       
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);

                return ms.ToArray();
            }
        }
        protected void Update_Text(object sender, EventArgs e)
        {


            int ttxtrelationship = txtrelationship.SelectedIndex;
            string depedanttype = "";
            if (ttxtrelationship == 1 || ttxtrelationship == 2 || ttxtrelationship == 7)
            {
                ttxtdependanttype.Text = "Adult";
                string docNo = Request.QueryString["QuoteNo"].Trim();
                NAV nav = Config.ReturnNav(); ;
                var ClientDetails = nav.SalesHeader.Where(x => x.No == docNo);
                foreach (var item in ClientDetails)
                {
                    dhb.Text = Convert.ToString(item.DHB);
                    var schedules = nav.MedicalSchedules.Where(x => x.Product_Code == item.Product && x.Benefit_Type == "DHB" && x.Premium_TB_Options == "ADULT" && x.Benefit_Limit == item.DHB);
                    foreach (var item1 in schedules)
                    {
                        dhbpremium.Text = Convert.ToString(item1.Premium);

                    }
                }
            }
            if (ttxtrelationship == 1)
            {
                //default Dependant Value
                // txtdependantcodes.Text = "01";
            }
            else
            {
                ttxtdependanttype.Text = "Child";
                string docNo = Request.QueryString["QuoteNo"].Trim();
                NAV nav = Config.ReturnNav(); ;
                var ClientDetails = nav.SalesHeader.Where(x => x.No == docNo);
                foreach (var item in ClientDetails)
                {
                    dhb.Text = Convert.ToString(item.DHB);
                    var schedules = nav.MedicalSchedules.Where(x => x.Product_Code == item.Product && x.Benefit_Type == "DHB" && x.Premium_TB_Options == "CHILD" && x.Benefit_Limit == item.DHB);
                    foreach (var item1 in schedules)
                    {
                        dhbpremium.Text = Convert.ToString(item1.Premium);
                        //dhb.Text = Convert.ToString(item1.Benefit_Limit);
                    }
                }
            }
            SCPanel.Update();

        }
        protected void ValidateDate_Text(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now.Date;
            DateTime dob = DateTime.ParseExact(txtdateob.Text.Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            if (dob > today)
            {
                lblError.InnerText = "The Date of Birth cannot be greater than Today";
            }
            int ttxtrelationship = txtrelationship.SelectedIndex;
            if (ttxtrelationship == 1)
            {
                int age = CalculateAge(dob);
                if (age < 18)
                {
                    lblError.InnerText = "The Spouse age cannot be less than 18 years";
                }
            }
            txtage.Text = Convert.ToString(CalculateAge(dob));
            SCPanel.Update();
        }
        
        protected void PromoteDepedant_Click(object sender, EventArgs e)
        {
            var tpromoteCode = promoteCode.Text.Trim();
            string docNo = Request.QueryString["QuoteNo"].Trim();
            var status = new Config().ObjNav().PromotetoBeneficiaryPolicyAmmendments(docNo, tpromoteCode);
            var res = status.Split('*');
            if (res[0] == "success")
            {
                txtdependantsfeedbackdetails.InnerHtml = "<div class='alert alert-success'>" + res[1] + "</div>";

            }
            else
            {

                txtdependantsfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + res[1] + "</div>";

            }

        }
        protected void ValidateAge_Text(object sender, EventArgs e)
        {
            DateTime dob = DateTime.ParseExact(txtdobs.Text.Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            txtages.Text = Convert.ToString(CalculateAge(dob));
            SCPanel2.Update();
        }
      
        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
        protected void SubmitCommunicationDetails_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string docNo = Request.QueryString["ContractNo"].Trim();
            string GrowerNo = Request.QueryString["GrowerNo"].Trim();
            string CustomerNo = Request.QueryString["CustomerNo"].Trim();
            string QuoteNo = Request.QueryString["QuoteNo"].Trim();

            string ttelnumber2 = telnumber2.Text.Trim();
            string txtfacebook = txtfcebook.Text.Trim();
            string ttxtemail = txtemail.Text.Trim();
            string ttxttwitter = txttwitter.Text.Trim();
            string ttxtaddress = txtaddress.Text.Trim();
            string ttxtlinkedin = txtlinkedin.Text.Trim();
            string ttxtgoogle = txtgoogle.Text.Trim();
            try
            {
                if (flag)
                {
                    communicationfeedbackDetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                }
                else
                {
                    Response.Redirect("KYMCorporatePolicyAmmendments.aspx?GrowerNo=" + GrowerNo + "&&ContractNo=" + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=3");

                }
            }
            catch (Exception ex)
            {
                communicationfeedbackDetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
            }
        }

        protected void AddDependants_Click(object sender, EventArgs e)
        {
            string ApplicationNumber = Request.QueryString["QuoteNo"].Trim();
            string GrowerNumber = Request.QueryString["GrowerNo"].Trim();
            ApplicationNumber = ApplicationNumber.Replace('/', '_');
            ApplicationNumber = ApplicationNumber.Replace(':', '_');
            string path1 = Config.FilesLocation() + "New Clients/";
            string str1 = Convert.ToString(ApplicationNumber);
            string Imagedepedantphotobytes = (dynamic)null;
            string folderName = path1 + str1 + "/";
            string str = "";
            bool flag = false;
            string dependantCode = txtdependantcodes.Text.Trim();
            if (dependantCode.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string name = txtname.Text.Trim();
            if (name.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            int selectedIndex1 = txtrelationship.SelectedIndex;
            if (selectedIndex1 < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string idNo = "";
            if (selectedIndex1 == 1)
            {
                idNo = lblIdNumber.Text.Trim();
                if (idNo.Length < 1)
                {
                    flag = true;
                    str = "Please fill all highlighted fields with *(Mandatory Fields)";
                }
            }
            else
            {
                idNo = lblIdNumber.Text.Trim();
            }
            string s = txtdateob.Text.Trim();
            if (s.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            int tdependantconditions = dependantconditions.SelectedIndex;
            if (tdependantconditions < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string age = txtage.Text.Trim();
            if (age.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            int ttxtgenders = txtgenders.SelectedIndex;
            if (ttxtgenders < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            int tdependant = 0;
            string dependant = ttxtdependanttype.Text.Trim();
            if (dependant.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            if (dependant == "Adult")
            {
                tdependant = 1;
            }
            else
            {
                tdependant = 2;
            }

            string dHB = dhb.Text.Trim();
            if (dHB.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string premium = dhbpremium.Text.Trim();
            if (premium.Length < 1M)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            if (depedantphoto.HasFile == true)
            {

                string extension = System.IO.Path.GetExtension(depedantphoto.FileName);
                if (extension == ".Bmp" || extension == ".bmp" || extension == ".BMP" || extension == ".jpg" || extension == ".png" || extension == ".Jpeg" || extension == ".jpeg" || extension == ".Png" || extension == ".JPEG" || extension == ".PNG")
                {
                    var imageCounter = 0;
                    string filename = dependantCode + "_" + GrowerNumber + "_DependantPhoto" + extension;
                    if (!Directory.Exists(folderName))
                    {
                        Directory.CreateDirectory(folderName);
                    }
                    depedantphoto.SaveAs(folderName + filename);
                    string imagePath = folderName + filename;
                    System.Drawing.Image img = System.Drawing.Image.FromFile(imagePath);
                    byte[] Imagedepedantphoto = ImageToByteArray(img);
                    Imagedepedantphotobytes = Convert.ToBase64String(Imagedepedantphoto);
                }
                else
                {
                    txtdependantsfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + "The File extension is not allowed. Kindly upload only png,jpg files" + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }

                txtdependantsfeedbackdetails.InnerHtml = "<div class='alert alert-success'>" + "The Dependant Details has been successfully submitted" + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
            }
            else
            {
                Imagedepedantphotobytes = "";
            }
            try
            {
                if (flag)
                {
                    txtdependantsfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    DateTime dateTime = new DateTime();
                    DateTime exact = DateTime.ParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    string docNo = Request.QueryString["QuoteNo"].Trim();
                    var status = new Config().ObjNav().FnPolicyAmmendmentscreCreateClientDependants(docNo, dependantCode, name, exact, selectedIndex1, idNo, Convert.ToDecimal(age), tdependant, dHB, Convert.ToDecimal(premium), Imagedepedantphotobytes, ttxtgenders, tdependantconditions);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        txtdependantcodes.Text = "";
                        txtname.Text = "";
                        txtage.Text = "";
                        txtdateob.Text = "";
                        ttxtdependanttype.Text = "";
                        txtgenders.SelectedIndex = 0;
                        dhb.Text = "";
                        dhbpremium.Text = "";
                    }
                    else
                    {
                        txtdependantsfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>The New Client Application Details Could not be Submitted.Kindly Try Again" + res[1] + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                    }
                }
            }
            catch (Exception ex)
            {
                txtdependantsfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
            }
        }
        protected void upload_Click(object sender, EventArgs e)
        {
            string path1 = ConfigurationManager.AppSettings["FilesLocation"] + "Existing Policy/";
            string str1 = Request.QueryString["requisitionNo"].Trim().Replace('/', '_').Replace(':', '_');
            string GrowerNumber = Request.QueryString["GrowerNumber"].Trim().Trim().Replace('/', '_').Replace(':', '_');
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
                                string str2 = GrowerNumber + '_' + filetoupload.FileName.Replace(':', '_');
                                string str3 = path2 + str2;
                                string str4 = str3;
                                this.filetoupload.SaveAs(str3);
                                if (File.Exists(str3))
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                                }
                                else
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                                }
                            }
                            else
                            {
                                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                            }
                        }
                        else
                        {
                            documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents folder defined does not exist in the server. Please contact support. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                        }
                    }
                    else
                    {
                        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again Later<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                    }
                }
                catch (Exception ex)
                {
                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents could not be uploaded. Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
            }
            else
            {
                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>Please select the documents to upload. Both are required <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

            }
        }

       
        protected void nextstep_Click(object sender, EventArgs e)
        {
            int num1;
            string str;
            string GrowerNumber = Request.QueryString["GrowerNumber"].Trim();
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
            Response.Redirect("KYMCorporateClientApplication.aspx?requisitionNo=" + str + "&&GrowerNumber=" + GrowerNumber + "&step=" + (object)num2);
        }
        protected void ValidateFormUpload(object sender, EventArgs e)
        {

            var tmodeofpayments = modeofpaymentss.SelectedValue.Trim();
            if (tmodeofpayments == "KTDA check Off")
            {
                List<string> productbillingcycles = new List<string>();
                productbillingcycles.Add("Month");
                invoiceperiod.DataSource = productbillingcycles;
                invoiceperiod.DataBind();
            }
            else if (tmodeofpayments == "Corporate Checkoff")
            {
                List<string> productbillingcycles = new List<string>();
                productbillingcycles.Add("Month");
                invoiceperiod.DataSource = productbillingcycles;
                invoiceperiod.DataBind();
            }
            else if (tmodeofpayments == "Guarantor Form")
            {
                List<string> productbillingcycles = new List<string>();
                productbillingcycles.Add("Year");
                invoiceperiod.DataSource = productbillingcycles;
                invoiceperiod.DataBind();
            }
            else if (tmodeofpayments == "Green Leaf")
            {
                List<string> productbillingcycles = new List<string>();
                productbillingcycles.Add("Year");
                invoiceperiod.DataSource = productbillingcycles;
                invoiceperiod.DataBind();
            }
            else if (tmodeofpayments == "KTDA Staff deduction")
            {
                List<string> productbillingcycles = new List<string>();
                productbillingcycles.Add("Year");
                invoiceperiod.DataSource = productbillingcycles;
                invoiceperiod.DataBind();
            }
            else
            {
                List<string> productbillingcycles = new List<string>();
                productbillingcycles.Add("Year");
                invoiceperiod.DataSource = productbillingcycles;
                invoiceperiod.DataBind();
            }
        }
        protected void previousstep_Click(object sender, EventArgs e)
        {
            int num1;
            string str;
            string GrowerNumber = Request.QueryString["GrowerNumber"].Trim();
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
            Response.Redirect("KYMCorporateClientApplication.aspx?requisitionNo=" + str + "&&GrowerNumber=" + GrowerNumber + "&step=" + num2);
        }

       
        protected void SubmitApplication_Click(object sender, EventArgs e)
        {
            try
            {
                var step = Convert.ToInt32(Request.QueryString["step"].Trim());
                var Requisition = Request.QueryString["QuoteNo"].Trim();
                var status = new Config().ObjNav().SendIndividualKYMPolicyAmmendmentApproval(Requisition);
                var res = status.Split('*');
                if (res[0] == "success")
                {
                    Response.Redirect("KYMOpenClientApplications.aspx");
                }
                else
                {
                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The New Client Application Details Could not be Submitted for Approval" + res[1] + "</div>";

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void SubmitPolicyDetails_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            var dhb = dailyhealthbenefits.SelectedValue.Trim();
            int tmodeofpaymentss = modeofpaymentss.SelectedIndex;
            if (tmodeofpaymentss < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            int tagentDetail = agentDetail.SelectedIndex;
            if (tagentDetail < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tlblagentsubcategorydetail = lblagentsubcategorydetail.SelectedValue.Trim();
            if (tlblagentsubcategorydetail.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tlblsalesgentcode = lblsalesgentcode.SelectedValue.Trim();
            if (tlblsalesgentcode.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tttxtreferalmobilenumber = txtreferalmobilenumber.Text.Trim();
            int ttxtreferalmobilenumber = 0;
            if (tttxtreferalmobilenumber.Length > 1)
            {
                ttxtreferalmobilenumber = Convert.ToInt32(tttxtreferalmobilenumber);
            }
            string ttxtrefferalname = txtrefferalname.Text.Trim();
            try
            {
                if (flag)
                {
                    policyfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    string docNo = Request.QueryString["ContractNo"].Trim();
                    string GrowerNo = Request.QueryString["GrowerNo"].Trim();
                    string CustomerNo = Request.QueryString["CustomerNo"].Trim();
                    string QuoteNo = Request.QueryString["QuoteNo"].Trim();
                    var Applicant = Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnPolicyAmmendmentsUpdates(QuoteNo, dhb, tmodeofpaymentss, tagentDetail, tlblagentsubcategorydetail, tlblsalesgentcode, ttxtrefferalname, ttxtreferalmobilenumber);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("KYMCorporatePolicyAmmendments.aspx?GrowerNo=" + GrowerNo + "&&ContractNo=" + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=4");

                    }
                    else
                    {
                        policyfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>The New Client Application Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";

                    }
                }
            }
            catch (Exception ex)
            {
                policyfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
            }
        }
       
        protected void DeleteBeneficiary_Click(object sender, EventArgs e)
        {
            var tbeneficiarycodetoRemove = beneficiarycodetoRemove.Text.Trim();
            string docNo = Request.QueryString["QuoteNo"].Trim();
            var Applicant = Session["empNo"].ToString();
            var status = new Config().ObjNav().DeleteClientPolicyAmendmentsBeneficiary(docNo, tbeneficiarycodetoRemove);
            var res = status.Split('*');
            if (res[0] == "success")
            {
                benefeciariesfeedback.InnerHtml = "<div class='alert alert-success'>" + res[1] + "</div>";
            }
            else
            {
                benefeciariesfeedback.InnerHtml = "<div class='alert alert-danger'>" + res[1] + "</div>";
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
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string name = txtnames.Text.Trim();
            if (name.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            int selectedIndex = bentxtrelationships.SelectedIndex;
            if (selectedIndex < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string s = txtdobs.Text.Trim();
            if (s.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string idNo = txtidnumbers.Text.Trim();
            if (idNo.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string age = txtages.Text.Trim();
            if (age.Length < 1M)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            int ttxtgender2 = 0;
            //if(ttxtgender2< 1)
            //{
            //    flag = true;
            //    str = "Please fill all highlighted fields with *(Mandatory Fields)";
            //}
            string allocation = txtallocation.Text.Trim();
            decimal tallocation = 0;
            if (allocation.Length < 1)
            {
                tallocation = 0;
            }
            else
            {
                tallocation = Convert.ToDecimal(allocation);
            }
            try
            {
                if (flag)
                {
                    benefeciariesfeedback.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {

                    DateTime dateTime = new DateTime();
                    DateTime exact = DateTime.ParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    string docNo = Request.QueryString["QuoteNo"].Trim();
                    string GrowerNumber = Request.QueryString["GrowerNo"].Trim();
                    var status = new Config().ObjNav().FnPolicyAmmendmentsCreateClientBeneficiary(docNo, beneficiary, name, selectedIndex, exact, idNo, Convert.ToDecimal(age), tallocation, ttxtgender2);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        txtallocation.Text = "";
                        txtnames.Text = "";
                        txtages.Text = "";
                        txtidnumbers.Text = "";
                        txtnames.Text = "";
                        bentxtrelationships.SelectedIndex = 0;
                        txtbeneficiary.Text = "";
                        txtdobs.Text = "";
                        benefeciariesfeedback.InnerHtml = "<div class='alert alert-success'>" + res[1] + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                    }
                    else
                    {
                        benefeciariesfeedback.InnerHtml = "<div class='alert alert-danger'>The New Client Application Details Could not be Submitted.Kindly Try Again" + res[1] + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                    }
                }
            }
            catch (Exception ex)
            {
                benefeciariesfeedback.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
            }
        }
        protected void UploadDocumentsApplication_Click(object sender, EventArgs e)
        {
            try
            {

                string ApplicationNumber = Request.QueryString["ContractNo"].Trim();
                string GrowerNumber = Request.QueryString["GrowerNo"].Trim();
                ApplicationNumber = ApplicationNumber.Replace('/', '_');
                ApplicationNumber = ApplicationNumber.Replace(':', '_');
                string path1 = Config.FilesLocation() + "New Clients/";
                string str1 = Convert.ToString(ApplicationNumber);
                string folderName = path1 + str1 + "/";
                bool error = false;
                string message = "";
                try
                {

                    if (filetoupload.HasFile)
                    {
                        string extension = System.IO.Path.GetExtension(filetoupload.FileName);
                        if (new Config().IsAllowedExtension(extension))
                        {
                            string filename = GrowerNumber + "_ScannedApplication" + extension;
                            if (!Directory.Exists(folderName))
                            {
                                Directory.CreateDirectory(folderName);
                            }
                            if (File.Exists(folderName + filename))
                            {
                                File.Delete(folderName + filename);
                            }
                            filetoupload.SaveAs(folderName + filename);
                        }
                        else
                        {
                            error = true;
                            message += message.Length > 0 ? "<br>" : "";
                            message += "The file extension of the Scanned application is not allowed,Kindly upload Pdf files";
                        }

                    }
                    else
                    {
                        error = true;
                        message += message.Length > 0 ? "<br>" : "";
                        message += "Kindly Upload the  Scanned Application before you proceed";

                    }
                }
                catch (Exception ex)
                {
                    error = true;
                    message += message.Length > 0 ? "<br>" : "";
                    message += "Kindly Upload the  Scanned Application before you proceed" + ex;
                }
                try
                {
                    if (guardianshipletter.HasFile)
                    {
                        string extension = System.IO.Path.GetExtension(guardianshipletter.FileName);
                        if (new Config().IsAllowedExtension(extension))
                        {
                            string filename = GrowerNumber + "_OtherDocument " + extension;
                            if (!Directory.Exists(folderName))
                            {
                                Directory.CreateDirectory(folderName);
                            }
                            if (File.Exists(folderName + filename))
                            {
                                File.Delete(folderName + filename);
                            }
                            guardianshipletter.SaveAs(folderName + filename);
                        }
                        else
                        {
                            error = true;
                            message += message.Length > 0 ? "<br>" : "";
                            message += "The file extension of the Other is not allowed";
                        }

                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    error = true;
                    message += message.Length > 0 ? "<br>" : "";
                    message += "Kindly Upload the  Other before you proceed" + ex;
                }

                try
                {
                    //if (principalmemberphoto.HasFile == true)
                    //{
                    //    string extension = System.IO.Path.GetExtension(principalmemberphoto.FileName);
                    //    if (extension == ".jpg" || extension == ".JPEG" || extension == ".png" || extension == ".PNG" || extension == ".jpeg" || extension == ".gif")
                    //    {
                    //        string filename = GrowerNumber + "_Certificate" + extension;
                    //        if (!Directory.Exists(folderName))
                    //        {
                    //            Directory.CreateDirectory(folderName);
                    //        }
                    //        if (File.Exists(folderName + filename))
                    //        {
                    //            File.Delete(folderName + filename);
                    //        }
                    //        principalmemberphoto.SaveAs(folderName + filename);
                    //    }
                    //    else
                    //    {
                    //        error = true;
                    //        message += message.Length > 0 ? "<br>" : "";
                    //        message += "The file extension of the Principal Photo is not allowed,Kindly upload PDF files";
                    //    }

                    //}
                    //else
                    //{
                    //    error = true;
                    //    message += message.Length > 0 ? "<br>" : "";
                    //    message += "Kindly Upload the Principal Photo before you proceed";
                    //}
                }
                catch (Exception ex)
                {
                    error = true;
                    message += message.Length > 0 ? "<br>" : "";
                    message += "Kindly Upload the Principal Photo before you proceed" + ex;

                }
                if (error)
                {
                    documentsfeedback.InnerHtml = Config.GetAlert("danger", message);
                }
                else
                {
                    documentsfeedback.InnerHtml = Config.GetAlert("success", "The Documents has been uploaded successfully");

                }
            }
            catch (Exception y)
            {
                documentsfeedback.InnerHtml = Config.GetAlert("danger", y.Message);
            }
        }
    }
}