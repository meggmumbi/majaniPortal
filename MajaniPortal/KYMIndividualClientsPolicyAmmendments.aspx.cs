using MajaniPortal.Nav;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace MajaniPortal
{
    public partial class KYMIndividualClientsPolicyAmmendments : System.Web.UI.Page
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


                    //Load Financiers

                    hasgrowerNo.Checked = true;

                    //var Conditions = Config.ReturnNav().PreExistingConditions.ToList();
                    //List<DropDownList> Conditionslist = new List<DropDownList>();
                    //foreach (var item in Conditions)
                    //{
                    //    DropDownList code = new DropDownList();
                    //    code.Code = item.code;
                    //    code.Name = item.Description;
                    //    Conditionslist.Add(code);
                    //}
                    //txtConditionName.DataSource = Conditionslist;
                    //txtConditionName.DataValueField = "Code";
                    //txtConditionName.DataTextField = "Name";
                    //txtConditionName.DataBind();
                    //txtConditionName.Items.Insert(0, "--Select Pre Existing Conditions--");

                    var tttxtoccupations = nav.Occupations.ToList();
                    List<DropDownList> ttxtoccupationslist = new List<DropDownList>();
                    foreach (var item in tttxtoccupations)
                    {
                        DropDownList itemcodelist = new DropDownList();
                        itemcodelist.Code = item.Code;
                        itemcodelist.Name = item.Name;
                        ttxtoccupationslist.Add(itemcodelist);
                    }
                    ttxtoccupation.DataSource = ttxtoccupationslist;
                    ttxtoccupation.DataValueField = "Code";
                    ttxtoccupation.DataTextField = "Name";
                    ttxtoccupation.DataBind();
                    ttxtoccupation.Items.Insert(0, "--Select Occupation--");



                    List<string> tlblpolicybusinessType = new List<string>();
                    tlblpolicybusinessType.Add("Existing");
                    membertypes.DataSource = tlblpolicybusinessType;
                    membertypes.DataBind();

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

                    List<string> ttxtrelationships = new List<string>();
                    ttxtrelationships.Add("-----Select Relationship------");
                    ttxtrelationships.Add("Spouse");
                    ttxtrelationships.Add("Daughter");
                    ttxtrelationships.Add("Son");
                    txtrelationship.DataSource = ttxtrelationships;
                    txtrelationship.DataBind();

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

                    var countiesCodes = nav.DimensionValueList.Where(x => x.Dimension_Code == "COUNTIES").ToList();
                    List<DropDownList> countiesCodeslist = new List<DropDownList>();
                    foreach (var item in countiesCodes)
                    {
                        DropDownList code = new DropDownList();
                        code.Code = item.Code;
                        code.Name = item.Name;
                        countiesCodeslist.Add(code);
                    }
                    lblcountyCodes.DataSource = countiesCodeslist;
                    lblcountyCodes.DataValueField = "Code";
                    lblcountyCodes.DataTextField = "Name";
                    lblcountyCodes.DataBind();
                    lblcountyCodes.Items.Insert(0, "--Select County Codes--");


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

                    List<string> ttxtgend = new List<string>();
                    ttxtgend.Add("-----Select Gender-------");
                    ttxtgend.Add("Male");
                    ttxtgend.Add("Female");
                    txtgenders.DataSource = ttxtgend;
                    txtgenders.DataBind();

                    lblgenders.DataSource = ttxtgend;
                    lblgenders.DataBind();

                    List<string> tlblmaritalstatus = new List<string>();
                    tlblmaritalstatus.Add("-----Select Marital Status-------");
                    tlblmaritalstatus.Add("Married");
                    tlblmaritalstatus.Add("Single");
                    lblmaritalstatuss.DataSource = tlblmaritalstatus;
                    lblmaritalstatuss.DataBind();

                    List<string> identity = new List<string>();
                    identity.Add("-----Select Identity Type-------");
                    identity.Add("ID");
                    identity.Add("Passport");
                    idtypes.DataSource = identity;
                    idtypes.DataBind();

                    List<string> txtrelation = new List<string>();
                    txtrelation.Add("-----Select Title------");
                    txtrelation.Add("Mr");
                    txtrelation.Add("Major");
                    txtrelation.Add("Captain");
                    txtrelation.Add("Sir");
                    txtrelation.Add("Madam");
                    txtrelation.Add("Doctor");
                    txtrelation.Add("Prof");
                    txtrelation.Add("Pastor");
                    txtrelation.Add("Mrs");
                    txtrelation.Add("Miss");
                    lbltitles.DataSource = txtrelation;
                    lbltitles.DataBind();

                    var tpostcodes = nav.postcodes.ToList();
                    List<DropDownList> postcodeslist = new List<DropDownList>();
                    foreach (var item in tpostcodes)
                    {
                        DropDownList itemcodelist = new DropDownList();
                        itemcodelist.Code = item.Code;
                        itemcodelist.Name = item.Code + " " + item.City;
                        postcodeslist.Add(itemcodelist);
                    }
                    postcodes.DataSource = postcodeslist;
                    postcodes.DataValueField = "Code";
                    postcodes.DataTextField = "Name";
                    postcodes.DataBind();
                    postcodes.Items.Insert(0, "--Select Post Codes--");


                    var ApplicationNumber = Convert.ToString(Request.QueryString["ContractNo"]);
                    if (ApplicationNumber != null)
                    {
                        var Application = nav.ServiceContracts.Where(x => x.Contract_No == ApplicationNumber).ToList();
                        foreach (var item in Application)
                        {
                            var CustomerInfor = nav.Customer.Where(x => x.No == item.Customer_No).ToList();
                            foreach (var itemCustomer in CustomerInfor)
                            {
                                txtfirstname.Text = item.First_Name;
                                customerCategorys.Text = item.Customer_Category;
                                customerSubCategorys.Text = item.Customer_Sub_Category;
                                applicationTypesdetails.Text = item.Applicant_Type;
                                txtMiddleName.Text = item.Middle_Name;
                                txtlastname.Text = item.Last_Name;
                                txtHudumaNo.Text = item.Huduma_No;
                                growerNumber.Text = item.Grower_No_Client_ID;
                                txtFactoryCode.Text = item.Factory_Code_Branch_Code;
                                ttxtFactoryName.Text = item.Factory_Name_Branch_Name;

                               idtypes.SelectedValue = itemCustomer.ID_Type;
                               


                               
                                txtIdNumber.Text = itemCustomer.ID_No_Passport_No;
                                growerapplicanttypedetails.Text = itemCustomer.Grower_Type_of_Applicant;
                                lblgenders.SelectedValue = item.Gender;
                                lbltitles.SelectedValue = item.Title;
                                countyofresidence.Text = item.Country_Region_Code;
                                lblcountyCodes.Text = item.Bill_to_County;
                                krapinNumber.Text = item.KRA_Pin_No;
                                ttxtoccupation.SelectedValue = item.Occupation;
                                txtDOB.Text = Convert.ToDateTime(item.Date_of_Birth).ToString("MM/dd/yyyy");
                                telnumber1.Text = item.Tel_Mobile_No;
                                telnumber2.Text = itemCustomer.Tel_Mobile_No_2;
                                txtaddress.Text = item.Address;
                                postcodes.SelectedValue = item.Post_Code;
                                lblcity.Text = item.City;
                                txtgoogle.Text = itemCustomer.Google;
                                txttwitter.Text = itemCustomer.Twitter;
                                txtfcebook.Text = itemCustomer.Facebook;
                                txtlinkedin.Text = itemCustomer.LinkedIn;
                                lblmaritalstatuss.SelectedValue = item.Marital_Status;
                                lbltitles.SelectedValue = item.Title;
                                lbldepartmentdetails.Text = item.Business_Type;
                                lblpolicyTypedetails.Text = item.Policy_Type;
                                lblproduct.Text = item.Product;
                                insurer.Text = item.Insurer;
                                serviceperiod.Text = item.Service_Period;
                                txtreferalmobilenumber.Text = "";
                                dailyhealthbenefits.SelectedValue = item.DHB;
                                txtrefferalname.Text = "";
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

                   
                    

                    financier.Visible = false;
                    growerdetails.Visible = true;
                    generalformgurantor.Visible = false;
                    generalformcheckoffs.Visible = false;
                    generalformgreenleaf.Visible = false;
                    generalformktdastaffdeduction.Visible = false;
                }
            }
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
        protected void Next_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            int kgender = 0;
            int kmaritalStatus = 0;
            string docNo = Request.QueryString["ContractNo"].Trim();
            string GrowerNo = Request.QueryString["GrowerNo"].Trim();
            string CustomerNo = Request.QueryString["CustomerNo"].Trim();          
            string tIdtype = idtypes.SelectedValue;
            string ttxtIdNumber = txtIdNumber.Text;
            string tlblgenders = lblgenders.SelectedValue;
            string s = this.txtDOB.Text.Trim();
            string tttxtoccupation = ttxtoccupation.SelectedValue;
            string tlblmaritalstatuss = lblmaritalstatuss.SelectedValue;
            string tlblcountyCodes = lblcountyCodes.SelectedValue;

            if(tIdtype.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields). Id type cannot be empty";
            }

           
            if (ttxtIdNumber.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields). Id/Passport cannot be empty";
            }
            if (tlblgenders.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields). Id/Passport cannot be empty";
            }
          
            if (s.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields. Date of birth cannot be empty)";
            }
            if (tttxtoccupation.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields. Occupation cannot be empty)";
            }
            if (tlblmaritalstatuss.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields. Marital Status cannot be empty)";
            }
            if (tlblcountyCodes.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields. County cannot be empty)";
            }
            

            try
            {
                if (flag)
                {
                    feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {

                    if (tlblgenders == "Male")
                    {
                        kgender = 1;
                    }
                    if (tlblgenders == "Female")
                    {
                         kgender = 2;
                    }
                    if (tlblmaritalstatuss == "Married")
                    {
                        kmaritalStatus = 1;
                    }
                    if (tlblmaritalstatuss == "Single")
                    {
                        kmaritalStatus = 2;
                    }

                    DateTime dateTime = new DateTime();
                    DateTime exact = DateTime.ParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    string empNo = Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnNewPolicyAmmendments(docNo, ttxtIdNumber, kgender, exact, tttxtoccupation, kmaritalStatus, tlblcountyCodes);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("KYMIndividualClientsPolicyAmmendments.aspx?GrowerNo=" + GrowerNo + "&&ContractNo=" + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + res[2] + "&step=2");

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

        protected void ValidateFactoryDetail_Click(object sender, EventArgs e)
        {
            var tgrowerNumber = growerNumber.Text.Trim();
            var status = new Config().ObjNav().FnCheckifGrowerNoExist(tgrowerNumber);
            var res = status.Split('*');
            if (res[0] == "danger")
            {
                growerdetails.InnerText = "The Grower Number Provided Already Exist.Kindly use a different Unique Grower No.";

            }
            else
            {
                growerdetails.InnerText = "";
            }

        }
        protected void ValidateIDNumberDetail_Click(object sender, EventArgs e)
        {

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
                Response.Redirect("KYMIndividualClientsPolicyAmmendments.aspx?GrowerNo=" + GrowerNo + "&&ContractNo=" + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=5");
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
        protected void PolicyDetails_Click()
        {
            NAV nav = Config.ReturnNav();
            var ContractNo = Convert.ToString(Request.QueryString["ContractNo"]);
            if (ContractNo != null)
            {
                var Application = nav.ServiceContracts.Where(x => x.Contract_No == ContractNo).ToList();
                foreach (var item in Application)
                {

                }
            }
        }
        protected void AddDependants_Click(object sender, EventArgs e)
        {
            string ApplicationNumber = Request.QueryString["QuoteNo"].Trim();
            string GrowerNumber = Request.QueryString["GrowerNo"].Trim();
            ApplicationNumber = ApplicationNumber.Replace('/', '_');
            ApplicationNumber = ApplicationNumber.Replace(':', '_');
            string path1 = Config.FilesLocation() + "MicroInsurance Amendement/";
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
                    string fullfileName = folderName+ filename;
                    if (!Directory.Exists(folderName))
                    {
                        Directory.CreateDirectory(folderName);
                    }
                    depedantphoto.SaveAs(folderName + filename);
                    Config.navExtender.AddLinkToRecord("MicroInsurance Amendement", ApplicationNumber, fullfileName, "");
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
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);

                return ms.ToArray();
            }
        }
        //protected void DisplayHealthConditions_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (rdropdownyesconditions.SelectedValue == "Yes")
        //    {
        //        displayhealthConditions1.Visible = true;
        //    }
        //    else
        //    {
        //        displayhealthConditions1.Visible = false;

        //    }
        //}
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
        protected void ValidateAge_Text(object sender, EventArgs e)
        {
            DateTime dob = DateTime.ParseExact(txtdobs.Text.Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            txtages.Text = Convert.ToString(CalculateAge(dob));
            SCPanel2.Update();
        }
        protected void PrincipalValidateDate_Text(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now.Date;
            DateTime dob = DateTime.ParseExact(txtDOB.Text.Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            if (dob > today)
            {
                datevalidator.InnerText = "The Date of Birth cannot be greater than Today";
            }
            int age = CalculateAge(dob);
            if (age < 18)
            {
                datevalidator.InnerText = "The Principal Member age cannot be less than 18 years";
            }
            else
            {
                datevalidator.Visible = false;
            }
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

            string ttelnumber1 = telnumber1.Text.Trim();
            if (ttelnumber1.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string txtcity = lblcity.SelectedValue.Trim();
            if (txtcity.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string ttelnumber2 = telnumber2.Text.Trim();
            //if (ttelnumber2.Length < 1)
            //{
            //    flag = true;
            //    str = "Please Enter a Valid Value for Tel/Mobile Number 2";
            //}
            string txtfacebook = txtfcebook.Text.Trim();
            //if (txtfacebook.Length < 1)
            //{
            //    flag = true;
            //    str = "Please Enter a Valid Value for Facebook Account";
            //}
            string ttxtemail = txtemail.Text.Trim();
            //if (ttxtemail.Length < 1)
            //{
            //    flag = true;
            //    str = "Please Enter a Valid Value for Email Addresss";
            //}
            string ttxtpostcodes = postcodes.SelectedValue.Trim();
            if (ttxtpostcodes.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for postcode";
            }
            string ttxtaddress = txtaddress.Text.Trim();
            //if (ttxtaddress.Length < 1)
            //{
            //    flag = true;
            //    str = "Please fill all highlighted fields with *(Mandatory Fields)";
            //}
            string ttxtlinkedin = txtlinkedin.Text.Trim();

            string ttxtgoogle = txtgoogle.Text.Trim();
            //if (ttxtgoogle.Length < 1)
            //{
            //    flag = true;
            //    str = "Please Enter a Valid Value for Google Account";
            //}
            try
            {
                if (flag)
                {
                    communicationfeedbackDetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                }
                else
                {
                  
                    var Applicant = Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnAmmendCommunicationDetails(QuoteNo, ttelnumber1, txtcity, ttxtaddress, ttxtpostcodes, ttxtemail);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("KYMIndividualClientsPolicyAmmendments.aspx?GrowerNo=" + GrowerNo + "&&ContractNo=" + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=3");

                    }
                    else
                    {
                        communicationfeedbackDetails.InnerHtml = "<div class='alert alert-danger'>Th New Client Application Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";

                    }


                   

                }
            }
            catch (Exception ex)
            {
                communicationfeedbackDetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
            }
        }
        protected void PostCodes_OnClick(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string tpostcodes = postcodes.SelectedValue.Trim();
            var allpostcodes = nav.postcodes.Where(x => x.Code == tpostcodes);
            List<DropDownList> allpostcodesList = new List<DropDownList>();
            foreach (var item in allpostcodes)
            {
                DropDownList code = new DropDownList();
                code.Code = item.City;
                code.Name = item.City;
                allpostcodesList.Add(code);
            }
            lblcity.DataSource = allpostcodesList;
            lblcity.DataTextField = "Code";
            lblcity.DataValueField = "Code";
            lblcity.DataBind();
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
                                string str2 = filetoupload.FileName.Replace(':', '_');
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
            string tttxtreferalmobilenumber =txtreferalmobilenumber.Text.Trim();
            int ttxtreferalmobilenumber = 0;
            if (tttxtreferalmobilenumber.Length > 1)
            {
                ttxtreferalmobilenumber =Convert.ToInt32(tttxtreferalmobilenumber);
            }
            string ttxtrefferalname = txtrefferalname.Text.Trim();
            //if (ttxtrefferalname.Length < 1)
            //{
            //    flag = true;
            //    str = "Please fill all highlighted fields with *(Mandatory Fields)";
            //}
            try
            {
                if (flag)
                {
                    policyfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    var documentsmodeofpayments = modeofpaymentss.SelectedValue.Trim();
                    string ApplicationNumber = Request.QueryString["QuoteNo"].Trim();
                    string GrowerNo = Request.QueryString["GrowerNo"];
                    ApplicationNumber = ApplicationNumber.Replace('/', '_');
                    ApplicationNumber = ApplicationNumber.Replace(':', '_');
                    string path1 = Config.FilesLocation() + "MicroInsurance Amendement/";
                    string rQuisitionNo = Request.QueryString["QuoteNo"].Trim();
                    string str1 = Convert.ToString(ApplicationNumber);
                    string folderName = path1 + str1 + "/";
                    bool error = false;
                    string message = "";
                    if (documentsmodeofpayments == "KTDA check Off")
                    {
                        try
                        {
                            if (checkoffform.HasFile)
                            {
                                string extension = System.IO.Path.GetExtension(checkoffform.FileName);
                                if (new Config().IsAllowedExtension(extension))
                                {
                                    string filename = GrowerNo + "_CheckOffForm" + extension;
                                    string fullfileName = folderName + filename;
                                    if (!Directory.Exists(folderName))
                                    {
                                        Directory.CreateDirectory(folderName);
                                    }
                                    if (File.Exists(folderName + filename))
                                    {
                                        File.Delete(folderName + filename);
                                    }
                                    checkoffform.SaveAs(folderName + filename);
                                    Config.navExtender.AddLinkToRecord("MicroInsurance Amendement", rQuisitionNo, fullfileName, "");
                                }
                                else
                                {
                                    error = true;
                                    message += message.Length > 0 ? "<br>" : "";
                                    message += "The file extension of the Check off Form is not allowed,Kindly upload Pdf files";
                                }

                            }
                            else
                            {
                                error = true;
                                message += message.Length > 0 ? "<br>" : "";
                                message += "Kindly Upload the Check off Form before you proceed";

                            }
                        }
                        catch (Exception ex)
                        {
                            error = true;
                            message += message.Length > 0 ? "<br>" : "";
                            message += "Kindly Upload the  Check off Form before you proceed" + ex;
                        }
                    }
                    else if (documentsmodeofpayments == "Corporate Checkoff")
                    {
                        try
                        {
                            if (checkoffform.HasFile)
                            {
                                string extension = System.IO.Path.GetExtension(checkoffform.FileName);
                                if (new Config().IsAllowedExtension(extension))
                                {
                                    string filename = GrowerNo + "_CheckOffForm" + extension;
                                    string fullfileName = folderName + filename;
                                    if (!Directory.Exists(folderName))
                                    {
                                        Directory.CreateDirectory(folderName);
                                    }
                                    if (File.Exists(folderName + filename))
                                    {
                                        File.Delete(folderName + filename);
                                    }
                                    checkoffform.SaveAs(folderName + filename);
                                    Config.navExtender.AddLinkToRecord("MicroInsurance Amendement", rQuisitionNo, fullfileName, "");
                                }
                                else
                                {
                                    error = true;
                                    message += message.Length > 0 ? "<br>" : "";
                                    message += "The file extension of the Check Off Form is not allowed,Kindly upload Pdf files";
                                }

                            }
                            else
                            {
                                error = true;
                                message += message.Length > 0 ? "<br>" : "";
                                message += "Kindly Upload the Check Off Form before you proceed";

                            }
                        }
                        catch (Exception ex)
                        {
                            error = true;
                            message += message.Length > 0 ? "<br>" : "";
                            message += "Kindly Upload the Check Off Form before you proceed" + ex;
                        }
                    }
                    else if (documentsmodeofpayments == "Guarantor Form")
                    {
                        try
                        {
                            if (guarantorform.HasFile)
                            {
                                string extension = System.IO.Path.GetExtension(guarantorform.FileName);
                                if (new Config().IsAllowedExtension(extension))
                                {
                                    string filename = GrowerNo + "_GuarantorForm" + extension;
                                    string fullfileName = folderName + filename;
                                    if (!Directory.Exists(folderName))
                                    {
                                        Directory.CreateDirectory(folderName);
                                    }
                                    if (File.Exists(folderName + filename))
                                    {
                                        File.Delete(folderName + filename);
                                    }
                                    guarantorform.SaveAs(folderName + filename);
                                    Config.navExtender.AddLinkToRecord("MicroInsurance Amendement", rQuisitionNo, fullfileName, "");
                                }
                                else
                                {
                                    error = true;
                                    message += message.Length > 0 ? "<br>" : "";
                                    message += "The file extension of the Guarantor Form is not allowed,Kindly upload Pdf files";
                                }

                            }
                            else
                            {
                                error = true;
                                message += message.Length > 0 ? "<br>" : "";
                                message += "Kindly Upload the Guarantor Form before you proceed";

                            }
                        }
                        catch (Exception ex)
                        {
                            error = true;
                            message += message.Length > 0 ? "<br>" : "";
                            message += "Kindly Upload the  Guarantor Form before you proceed" + ex;
                        }
                    }
                    else if (documentsmodeofpayments == "Green Leaf")
                    {
                        try
                        {
                            if (checkoffform.HasFile)
                            {
                                string extension = System.IO.Path.GetExtension(checkoffform.FileName);
                                if (new Config().IsAllowedExtension(extension))
                                {
                                    string filename = GrowerNo + "_GreenLeaf" + extension;
                                    string fullfileName = folderName + filename;
                                    if (!Directory.Exists(folderName))
                                    {
                                        Directory.CreateDirectory(folderName);
                                    }
                                    if (File.Exists(folderName + filename))
                                    {
                                        File.Delete(folderName + filename);
                                    }
                                    checkoffform.SaveAs(folderName + filename);
                                    Config.navExtender.AddLinkToRecord("MicroInsurance Amendement", rQuisitionNo, fullfileName, "");
                                }
                                else
                                {
                                    error = true;
                                    message += message.Length > 0 ? "<br>" : "";
                                    message += "The file extension of the Guarantor Form is not allowed,Kindly upload Pdf files";
                                }

                            }
                            else
                            {
                                error = true;
                                message += message.Length > 0 ? "<br>" : "";
                                message += "Kindly Upload the Guarantor Form before you proceed";

                            }
                        }
                        catch (Exception ex)
                        {
                            error = true;
                            message += message.Length > 0 ? "<br>" : "";
                            message += "Kindly Upload the  Guarantor Form before you proceed" + ex;
                        }
                    }
                    else if (documentsmodeofpayments == "KTDA Staff deduction")
                    {
                        try
                        {
                            if (ktdastafform.HasFile)
                            {
                                string extension = System.IO.Path.GetExtension(ktdastafform.FileName);
                                if (new Config().IsAllowedExtension(extension))
                                {
                                    string filename = GrowerNo + "_KTDAStaffDeductionForm" + extension;
                                    string fullfileName = folderName + filename;
                                    if (!Directory.Exists(folderName))
                                    {
                                        Directory.CreateDirectory(folderName);
                                    }
                                    if (File.Exists(folderName + filename))
                                    {
                                        File.Delete(folderName + filename);
                                    }
                                    ktdastafform.SaveAs(folderName + filename);
                                    Config.navExtender.AddLinkToRecord("MicroInsurance Amendement", rQuisitionNo, fullfileName, "");
                                }
                                else
                                {
                                    error = true;
                                    message += message.Length > 0 ? "<br>" : "";
                                    message += "The file extension of the KTDA Staff Deduction Form is not allowed,Kindly upload Pdf files";
                                }

                            }
                            else
                            {
                                error = true;
                                message += message.Length > 0 ? "<br>" : "";
                                message += "Kindly Upload the KTDA Staff Deduction Form before you proceed";

                            }
                        }
                        catch (Exception ex)
                        {
                            error = true;
                            message += message.Length > 0 ? "<br>" : "";
                            message += "Kindly Upload the KTDA Staff Deduction Form before you proceed" + ex;
                        }
                    }
                    if (error)
                    {
                        policyfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    }
                    string docNo = Request.QueryString["ContractNo"].Trim();
                    //string GrowerNo = Request.QueryString["GrowerNo"].Trim();
                    string CustomerNo = Request.QueryString["CustomerNo"].Trim();
                    string QuoteNo = Request.QueryString["QuoteNo"].Trim();
                    var Applicant = Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnPolicyAmmendmentsUpdates(QuoteNo, dhb, tmodeofpaymentss, tagentDetail, tlblagentsubcategorydetail, tlblsalesgentcode, ttxtrefferalname, ttxtreferalmobilenumber);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("KYMIndividualClientsPolicyAmmendments.aspx?GrowerNo=" + GrowerNo + "&&ContractNo=" + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=4");

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
        protected void Applications_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //protected void DependantType_OnSelectChange(object sender, EventArgs e)
        // {
        //     int ttxtrelationship = txtrelationship.SelectedIndex;
        //     string depedanttype = "";
        //     if (ttxtrelationship == 1||ttxtrelationship==2||ttxtrelationship==7)
        //     {
        //         txtdependanttype.SelectedIndex = 1;
        //         //NAV nav = Config.ReturnNav();;
        //         //var ClientDetails = nav.Conta.Where(x => x.Policy_Type == tlblproduct && x.Insurance_Item_type == "Insurance");
        //         //foreach (var item in productDetails)
        //         //{
        //         //    insurer.Text = item.Insurer;
        //         //    txtinsurerName.Text = item.Insurer_Name;
        //         //    invoiceperiod.Text = item.Invoice_Period;
        //         //    serviceperiod.Text = item.Service_Period;
        //         //    txtpolicyno.Text = item.Last_Policy_No_Used;
        //         //}

        //     }
        //     else
        //     {
        //         txtdependanttype.SelectedIndex = 2;
        //     }


  

        protected void nextstep_Click(object sender, EventArgs e)
        {
            int num1;
            string str;
            string GrowerNumber = Request.QueryString["GrowerNo"].Trim();
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
            Response.Redirect("KYMIndividualClientApplication.aspx?requisitionNo=" + str + "&&GrowerNumber=" + GrowerNumber + "&step=" + num2);
        }

        protected void previousstep_Click(object sender, EventArgs e)
        {
            int num1;
            string str;
            string GrowerNumber = Request.QueryString["GrowerNo"].Trim();
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
            Response.Redirect("KYMIndividualClientApplication.aspx?requisitionNo=" + str + "&&GrowerNumber=" + GrowerNumber + "&step=" + num2);
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
        protected void UploadDocumentsApplication_Click(object sender, EventArgs e)
        {
            try
            {

                string ApplicationNumber = Request.QueryString["ContractNo"].Trim();
                string GrowerNumber = Request.QueryString["GrowerNo"].Trim();
                ApplicationNumber = ApplicationNumber.Replace('/', '_');
                ApplicationNumber = ApplicationNumber.Replace(':', '_');
                string path1 = Config.FilesLocation() + "MicroInsurance Amendement/";
                string rQuisitionNo = Request.QueryString["QuoteNo"].Trim();
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
                            string fullfileName = folderName + filename;
                            if (!Directory.Exists(folderName))
                            {
                                Directory.CreateDirectory(folderName);
                            }
                            if (File.Exists(folderName + filename))
                            {
                                File.Delete(folderName + filename);
                            }
                            filetoupload.SaveAs(folderName + filename);
                            Config.navExtender.AddLinkToRecord("MicroInsurance Amendement", rQuisitionNo, fullfileName, "");
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
                            string fullfileName = folderName + filename;
                            if (!Directory.Exists(folderName))
                            {
                                Directory.CreateDirectory(folderName);
                            }
                            if (File.Exists(folderName + filename))
                            {
                                File.Delete(folderName + filename);
                            }
                            guardianshipletter.SaveAs(folderName + filename);
                            Config.navExtender.AddLinkToRecord("MicroInsurance Amendement", rQuisitionNo, fullfileName, "");
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
                    //error = true;
                    //message += message.Length > 0 ? "<br>" : "";
                    //message += "Kindly Upload the  Other before you proceed" + ex;
                }

                //try
                //{
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
                //}
                //catch (Exception ex)
                //{
                //    error = true;
                //    message += message.Length > 0 ? "<br>" : "";
                //    message += "Kindly Upload the Principal Photo before you proceed" + ex;

                //}
                if (error)
                {
                    documentsfeedback.InnerHtml = Config.GetAlert("danger", message);
                }
                else
                {
                    documentsfeedback.InnerHtml = Config.GetAlert("success", "The Documents have been uploaded successfully");

                }
            }
            catch (Exception y)
            {
                documentsfeedback.InnerHtml = Config.GetAlert("danger", y.Message);
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
        protected void ValidateFormUpload(object sender, EventArgs e)
        {

            var tmodeofpayments = modeofpaymentss.SelectedValue.Trim();
            if (tmodeofpayments == "KTDA check Off")
            {
                generalformcheckoffs.Visible = true;
                generalformgurantor.Visible = false;
                generalformgreenleaf.Visible = false;
                generalformktdastaffdeduction.Visible = false;
                List<string> productbillingcycles = new List<string>();
                productbillingcycles.Add("Month");
                invoiceperiod.DataSource = productbillingcycles;
                invoiceperiod.DataBind();
            }
            else if (tmodeofpayments == "Corporate Checkoff")
            {
                generalformcheckoffs.Visible = true;
                generalformgurantor.Visible = false;
                generalformgreenleaf.Visible = false;
                generalformktdastaffdeduction.Visible = false;
                List<string> productbillingcycles = new List<string>();
                productbillingcycles.Add("Month");
                invoiceperiod.DataSource = productbillingcycles;
                invoiceperiod.DataBind();
            }
            else if (tmodeofpayments == "Guarantor Form")
            {
                generalformgurantor.Visible = true;
                generalformcheckoffs.Visible = false;
                generalformgreenleaf.Visible = false;
                generalformktdastaffdeduction.Visible = false;
                List<string> productbillingcycles = new List<string>();
                productbillingcycles.Add("Year");
                invoiceperiod.DataSource = productbillingcycles;
                invoiceperiod.DataBind();
            }
            else if (tmodeofpayments == "Green Leaf")
            {
                generalformgreenleaf.Visible = true;
                generalformgurantor.Visible = false;
                generalformcheckoffs.Visible = false;
                generalformktdastaffdeduction.Visible = false;
                List<string> productbillingcycles = new List<string>();
                productbillingcycles.Add("Year");
                invoiceperiod.DataSource = productbillingcycles;
                invoiceperiod.DataBind();
            }
            else if (tmodeofpayments == "KTDA Staff deduction")
            {
                generalformktdastaffdeduction.Visible = true;
                generalformgurantor.Visible = false;
                generalformcheckoffs.Visible = false;
                generalformgreenleaf.Visible = false;
                List<string> productbillingcycles = new List<string>();
                productbillingcycles.Add("Year");
                invoiceperiod.DataSource = productbillingcycles;
                invoiceperiod.DataBind();
            }
            else
            {
                generalformgurantor.Visible = false;
                generalformcheckoffs.Visible = false;
                generalformgreenleaf.Visible = false;
                generalformktdastaffdeduction.Visible = false;
                List<string> productbillingcycles = new List<string>();
                productbillingcycles.Add("Year");
                invoiceperiod.DataSource = productbillingcycles;
                invoiceperiod.DataBind();
            }
        }
    }
}