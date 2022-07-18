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
    public partial class KYMIndividualClientApplication : System.Web.UI.Page
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
                    var CustomerCategory = nav.CustomerCategory.Where(x => x.Individual == true).ToList();
                    foreach (var item in CustomerCategory)
                    {
                        DropDownList itemlist = new DropDownList();
                        itemlist.Code = item.Code;
                        itemlist.Name = item.Description;
                        CustomerCategorylist.Add(itemlist);
                    }
                    customerCategory.DataSource = CustomerCategorylist;
                    customerCategory.DataValueField = "Code";
                    customerCategory.DataTextField = "Name";
                    customerCategory.DataBind();
                    customerCategory.Items.Insert(0, "--Select Customer Category--");

                    var PolicyTypes = Config.ReturnNav().PolicyTypes.Where(x => x.Insurance_Category == "MICRO-INSURANCE").ToList();
                    List<DropDownList> PolicyTypesList = new List<DropDownList>();
                    foreach (var item in PolicyTypes)
                    {
                        DropDownList code = new DropDownList();
                        code.Code = item.Policy_Type_Code;
                        code.Name = item.Policy_Type_Code;
                        PolicyTypesList.Add(code);
                    }
                    lblpolicyType.DataSource = PolicyTypesList;
                    lblpolicyType.DataTextField = "Code";
                    lblpolicyType.DataValueField = "Name";
                    lblpolicyType.DataBind();
                    lblpolicyType.Items.Insert(0, "--Select Policy Type--");

                    //Load Financiers
                    //var KTDAFARMERS = Config.ReturnNav().KTDAFARMERS.Where(x => x.Business_Type == "MICRO-INSURANCE").ToList();
                    //List<DropDownList> KTDAFARMERSlist = new List<DropDownList>();
                    //foreach (var item in KTDAFARMERS)
                    //{
                    //    DropDownList code = new DropDownList();
                    //    code.Code = item.Grower_No;
                    //    code.Name = item.Grower_No + " " + item.Name;
                    //    KTDAFARMERSlist.Add(code);
                    //}
                    //txtfinancier.DataSource = KTDAFARMERSlist;
                    //txtfinancier.DataValueField = "Code";
                    //txtfinancier.DataTextField = "Name";
                    //txtfinancier.DataBind();
                    //txtfinancier.Items.Insert(0, "--Select Financier--");

                    hasgrowerNo.Checked = true;

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

                    List<DropDownList> customerSubCategorylist = new List<DropDownList>();
                    var tcustomerSubCategory = nav.CustomerSubCategory.Where(x => x.Corporate == false).ToList();
                    foreach (var item in tcustomerSubCategory)
                    {
                        DropDownList itemlist = new DropDownList();
                        itemlist.Code = item.Code;
                        itemlist.Name = item.Description;
                        customerSubCategorylist.Add(itemlist);
                    }
                    customerSubCategory.DataSource = customerSubCategorylist;
                    customerSubCategory.DataValueField = "Code";
                    customerSubCategory.DataTextField = "Name";
                    customerSubCategory.DataBind();
                    customerSubCategory.Items.Insert(0, "--Select Customer Sub Category--");

                    //List<string> lblhasbinders = new List<string>();
                    //lblhasbinders.Add("-----SelectHas Binder-------");
                    //lblhasbinders.Add("Yes");
                    //lblhasbinders.Add("No");
                    //lblhasbinder.DataSource = lblhasbinders;
                    //lblhasbinder.DataBind();

                    List<string> ttxtrelationships = new List<string>();
                    ttxtrelationships.Add("-----Select Relationship------");
                    ttxtrelationships.Add("Spouse");
                    ttxtrelationships.Add("Daughter");
                    ttxtrelationships.Add("Son");
                    txtrelationship.DataSource = ttxtrelationships;
                    txtrelationship.DataBind();

                    List<string> ttdropdownyesconditions = new List<string>();
                    ttdropdownyesconditions.Add("-----Select------");
                    ttdropdownyesconditions.Add("Yes");
                    ttdropdownyesconditions.Add("No");
                    rdropdownyesconditions.DataSource = ttdropdownyesconditions;
                    rdropdownyesconditions.DataBind();

                    List<string> tdependantconditions = new List<string>();
                    tdependantconditions.Add("-----Select------");
                    tdependantconditions.Add("Yes");
                    tdependantconditions.Add("No");
                    dependantconditions.DataSource = tdependantconditions;
                    dependantconditions.DataBind();


                    List<DropDownList> lblagentsubcategorylist = new List<DropDownList>();
                    var tlblagentsubcategory = nav.CommissionGroup.ToList();
                    foreach (var item in tlblagentsubcategory)
                    {
                        DropDownList itemlist = new DropDownList();
                        itemlist.Code = item.Code;
                        itemlist.Name = item.Description;
                        lblagentsubcategorylist.Add(itemlist);
                    }
                    lblagentsubcategory.DataSource = lblagentsubcategorylist;
                    lblagentsubcategory.DataValueField = "Code";
                    lblagentsubcategory.DataTextField = "Name";
                    lblagentsubcategory.DataBind();
                    lblagentsubcategory.Items.Insert(0, "--Select Agent Sub Category--");



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


                    var tttxtoccupations = nav.Occupations.ToList();
                    List<DropDownList> ttxtoccupationslist = new List<DropDownList>();
                    foreach (var item in tttxtoccupations)
                    {
                        DropDownList itemcodelist = new DropDownList();
                        itemcodelist.Code = item.Code;
                        itemcodelist.Name = item.Name;
                        ttxtoccupationslist.Add(itemcodelist);
                    }
                    ttxtoccupations.DataSource = ttxtoccupationslist;
                    ttxtoccupations.DataValueField = "Code";
                    ttxtoccupations.DataTextField = "Name";
                    ttxtoccupations.DataBind();
                    ttxtoccupations.Items.Insert(0, "--Select Occupation--");


                    List<string> tgrowerapplicanttype = new List<string>();
                    tgrowerapplicanttype.Add("-----Select Grower Type of Applicants-------");
                    tgrowerapplicanttype.Add("KTDA Farmer");
                    tgrowerapplicanttype.Add("Farmer Dependent");
                    growerapplicanttype.DataSource = tgrowerapplicanttype;
                    growerapplicanttype.DataBind();

                    List<string> productbillingcycles = new List<string>();
                    productbillingcycles.Add("-----Select Product Billing Cycle-------");
                    productbillingcycles.Add("Month");
                    invoiceperiod.DataSource = productbillingcycles;
                    invoiceperiod.DataBind();


                    List<string> tmodeofpayments = new List<string>();
                    tmodeofpayments.Add("-----Select Grower Type of Applicants-------");
                    tmodeofpayments.Add("KTDA check Off");
                    tmodeofpayments.Add("KTDA Bonus");
                    tmodeofpayments.Add("Mpesa");
                    tmodeofpayments.Add("Other");
                    tmodeofpayments.Add("Corporate Checkoff");
                    tmodeofpayments.Add("Cheque");
                    tmodeofpayments.Add("Bank Deposit");
                    tmodeofpayments.Add("Cash Payments");
                    tmodeofpayments.Add("Guarantor Form");
                    tmodeofpayments.Add("Green Leaf");
                    tmodeofpayments.Add("KTDA Staff deduction");
                    tmodeofpayments.Add("Insurance Premium Finance");
                    tmodeofpayments.Add("Post Dated Cheque");
                    modeofpayments.DataSource = tmodeofpayments;
                    modeofpayments.DataBind();

                    List<string> txtgend = new List<string>();
                    txtgend.Add("-----Select Gender-------");
                    txtgend.Add("Male");
                    txtgend.Add("Female");
                    lblgender.DataSource = txtgend;
                    lblgender.DataBind();

                    var ApplicationNumber = Convert.ToString(Request.QueryString["requisitionNo"]);
                    if (ApplicationNumber != null)
                    {
                        var Application = nav.ClientApplicationQuery.Where(x => x.No == ApplicationNumber).ToList();
                        foreach (var item in Application)
                        {
                            txtfirstname.Text = item.First_Name;
                            txtMiddleName.Text = item.Middle_Name;
                            txtlastname.Text = item.Last_Name;
                            krapinNumber.Text = item.KRA_PIN_No;
                            txtHudumaNo.Text = item.Huduma_No;
                            customerCategory.Text = item.Customer_Category;
                            customerSubCategory.Text = item.Customer_Sub_Category;
                            applicationTypes.Text = item.Client_Type;
                            growerapplicanttype.Text = item.Type_of_Applicant;
                            growerNumber.Text = item.Grower_No_Client_ID;
                            txtFactoryCode.Text = item.Factory_Code_Branch_Code;
                            ttxtFactoryName.Text = item.Factory_Name_Branch_Name;
                            txtfinancier.Text = item.Financier;
                            idtype.Text = item.ID_Type;
                            txtIdNumber.Text = item.ID_No_Passport_No;
                            lblgender.Text = item.Gender;
                            var dateofbirth = item.Date_of_Birth;
                            // lblcountyCode.Text = item.County;
                            telnumber1.Text = item.Tel_Mobile_No;
                            telnumber2.Text = item.Tel_Mobile_No_2;
                            txtemail.Text = item.E_Mail;
                            txtaddress.Text = item.Address;
                            postcodes.Text = item.Post_Code;
                            lblcity.SelectedValue = item.Post_Code;
                            txtgoogle.Text = item.Google;
                            txttwitter.Text = item.Twitter;
                            txtfcebook.Text = item.Facebook;
                            txtlinkedin.Text = item.LinkedIn;
                            lblpolicyType.Text = item.Policy_Type;
                            lblproduct.Text = item.Product;
                            lblmaritalstatus.Text = item.Marital_Status;
                            lbltitle.Text = item.Title;
                            insurer.Text = item.Insurer;
                            dailyhealthbenefits.Text = item.DHB;
                            modeofpayments.Text = item.Mode_of_Payment;
                            //agentDetail.Text = item.Agent_Detail;
                            lblagentsubcategory.Text = item.Agent_Detail;
                            lblsalesgentcode.Text = item.Agent_Salespersons_Code;
                            txtreferalmobilenumber.Text = item.Refferal_Mobile_Number;
                            txtrefferalname.Text = item.Refferal_Names;


                        }
                    }

                    List<string> ttxtgend = new List<string>();
                    ttxtgend.Add("-----Select Gender-------");
                    ttxtgend.Add("Male");
                    ttxtgend.Add("Female");
                    txtgenders.DataSource = ttxtgend;
                    txtgenders.DataBind();

                    //List<string> ttxtgenders = new List<string>();
                    //ttxtgenders.Add("-----Select Gender-------");
                    //ttxtgenders.Add("Male");
                    //ttxtgenders.Add("Female");
                    //txtgender2.DataSource = ttxtgenders;
                    //txtgender2.DataBind();





                    List<DropDownList> tCountriesOfResidencelist = new List<DropDownList>();
                    var tCountriesOfResidence = nav.Countries.ToList();
                    foreach (var item in tCountriesOfResidence)
                    {
                        DropDownList code = new DropDownList();
                        code.Code = item.Code;
                        code.Name = item.Name;
                        tCountriesOfResidencelist.Add(code);
                    }
                    countyofresidence.DataSource = tCountriesOfResidencelist;
                    countyofresidence.DataValueField = "Code";
                    countyofresidence.DataTextField = "Name";
                    countyofresidence.DataBind();
                    countyofresidence.Items.Insert(0, "--Select Country of Residence--");

                    List<string> identity = new List<string>();
                    identity.Add("-----Select Identity Type-------");
                    identity.Add("ID");
                    identity.Add("Passport");
                    idtype.DataSource = identity;
                    idtype.DataBind();

                    List<string> tlblmaritalstatus = new List<string>();
                    tlblmaritalstatus.Add("-----Select Marital Status-------");
                    tlblmaritalstatus.Add("Married");
                    tlblmaritalstatus.Add("Single");
                    lblmaritalstatus.DataSource = tlblmaritalstatus;
                    lblmaritalstatus.DataBind();

                    var countiesCodes = nav.DimensionValueList.Where(x => x.Dimension_Code == "COUNTIES").ToList();
                    List<DropDownList> countiesCodeslist = new List<DropDownList>();
                    foreach (var item in countiesCodes)
                    {
                        DropDownList code = new DropDownList();
                        code.Code = item.Code;
                        code.Name = item.Name;
                        countiesCodeslist.Add(code);
                    }
                    lblcountyCode.DataSource = countiesCodeslist;
                    lblcountyCode.DataValueField = "Code";
                    lblcountyCode.DataTextField = "Name";
                    lblcountyCode.DataBind();
                    lblcountyCode.Items.Insert(0, "--Select County Codes--");



                    List<string> tagentDetail = new List<string>();
                    tagentDetail.Add("-----Select Agent Detail-------");
                    tagentDetail.Add("Direct Business");
                    tagentDetail.Add("Agent Business");
                    tagentDetail.Add("Refferal Business");
                    agentDetail.DataSource = tagentDetail;
                    agentDetail.DataBind();

                    List<string> tlbldepartments = new List<string>();
                    tlbldepartments.Add("Micro-Insurance");
                    lbldepartments.DataSource = tlbldepartments;
                    lbldepartments.DataBind();

                    List<string> tlblpolicybusinessType = new List<string>();
                    //tlblpolicybusinessType.Add("-----Select Policy Type-------");
                    tlblpolicybusinessType.Add("New");
                    //tlblpolicybusinessType.Add("Existing");
                    //tlblpolicybusinessType.Add("Renewal");
                    //tlblpolicybusinessType.Add("Extension");
                    //tlblpolicybusinessType.Add("Addition");
                    //tlblpolicybusinessType.Add("Adjustment");
                    //tlblpolicybusinessType.Add("Cancellation");
                    membertype.DataSource = tlblpolicybusinessType;
                    membertype.DataBind();

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
                    lbltitle.DataSource = txtrelation;
                    lbltitle.DataBind();

                    financier.Visible = false;
                    displayhealthConditions.Visible = false;
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
            string docNo = Request.QueryString["requisitionNo"].Trim();
            var status = new Config().ObjNav().PromotetoBeneficiary(docNo, tpromoteCode);
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
            string cust_category = customerCategory.SelectedValue.Trim();
            if (cust_category.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tcustomersubcategory = customerSubCategory.SelectedValue.Trim();
            if (tcustomersubcategory.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string applicanttype = applicationTypes.SelectedValue.Trim();
            if (applicanttype.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string countryOfResidence = countyofresidence.SelectedValue.Trim();
            if (countryOfResidence.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            int selectedIndex1 = 1;
            bool thasgrowerNo = false;
            int tgrowerapplicanttype = 0;
            string financier = "";
            string tfactoryCode = "";
            string tfactoryName = "";
            if (hasgrowerNo.Checked == true)
            {
                thasgrowerNo = true;
                tgrowerapplicanttype = growerapplicanttype.SelectedIndex;
                try
                {

                    tfactoryCode = txtFactoryCode.Text.Trim();
                    tfactoryName = ttxtFactoryName.Text.Trim();


                    if (applicationTypes.SelectedValue != "FACTORY STAFF")
                    {
                        if (tgrowerapplicanttype < 1)
                        {
                            flag = true;
                            str = "Please fill all highlighted fields with *(Mandatory Fields)";
                        }
                        else
                        {
                            if (tgrowerapplicanttype == 2)
                            {
                                financier = txtfinancier.Text.Trim();
                                if (financier.Length < 1)
                                {
                                    flag = true;
                                    str = "Please fill all highlighted fields with *(Mandatory Fields)";
                                }

                            }
                            else
                            {
                                financier = "";

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            var ttxtIdNumber = txtIdNumber.Text.Trim();
            if (ttxtIdNumber.Length > 8)
            {
                flag = true;
                str = "Please Enter the Correct ID No/Passport Value,It must be a Whole number between 6 and 8";
            }
            if (ttxtIdNumber.Length < 6)
            {
                flag = true;
                idNumberPassport.InnerText = "Please Enter the Correct ID No/Passport Value,It must be a Whole number between 6 and 8";
            }
            string requisitionNo = "";
            requisitionNo = Request.QueryString["requisitionNo"];
            if (string.IsNullOrEmpty(requisitionNo))
            {
                    try
                    {
                        var status = new Config().ObjNav().FnCheckifIdentityNoExist(ttxtIdNumber);
                        var res = status.Split('*');
                        if (res[0] == "danger")
                        {
                            flag = true;
                            str = "The ID No/Passport Provided Already Exist.Kindly use a different Unique ID No/Passport";
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                
            }

            else
            {
                idNumberPassport.InnerText = "";
            }
            string policyType = "";
            int selectedIndex2 = idtype.SelectedIndex;
            if (selectedIndex2 < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string s = this.txtDOB.Text.Trim();
            if (s.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string id_passport = txtIdNumber.Text.Trim();
            if (id_passport.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            int selectedIndex3 = lblgender.SelectedIndex;
            if (selectedIndex3 < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string pinNo = krapinNumber.Text.Trim();
            if (pinNo.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tgrowerNumber = growerNumber.Text.Trim();
            if (tgrowerNumber.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string countyCode = lblcountyCode.Text.Trim();
            if (countyCode.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string firstName = txtfirstname.Text.Trim();
            if (firstName.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            int selectedIndex4 = lblmaritalstatus.SelectedIndex;
            if (selectedIndex4 < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string middleName = txtMiddleName.Text.Trim();
            string hudumaNo = txtHudumaNo.Text.Trim();
            string lastname = txtlastname.Text.Trim();
            if (lastname.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string occupation = ttxtoccupations.SelectedValue.Trim();
            if (occupation.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            int selectedIndex5 = lbltitle.SelectedIndex;
            if (selectedIndex5 < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            if (flag)
            {
                feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
            }
            else
            {
                try
                {

                    DateTime dateTime = new DateTime();
                    DateTime exact = DateTime.ParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    
                    try
                    {
                       
                        if (string.IsNullOrEmpty(requisitionNo))
                        {
                            requisitionNo = "";
                        }
                    }
                    catch
                    {
                        requisitionNo = "";
                    }
                    string empNo = Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnewClientOnboadingRequests(requisitionNo, empNo, cust_category, tcustomersubcategory, selectedIndex1, policyType, selectedIndex2, id_passport, pinNo, selectedIndex5, firstName, middleName,
                        lastname, countryOfResidence, exact, selectedIndex3, countyCode, selectedIndex4, hudumaNo, applicanttype, occupation, tgrowerapplicanttype, tgrowerNumber, tfactoryCode, tfactoryName, financier, thasgrowerNo);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("KYMIndividualClientApplication.aspx?requisitionNo=" + res[2] + "&&GrowerNumber=" + tgrowerNumber + "&step=2");

                    }
                    else
                    {
                        feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + res[1] + "</div>";

                    }
                }
                catch (Exception ex)
                {
                    feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + ex.Message + "</div>";
                }
            }
        }
        protected void AddConditions_Click(object sender, EventArgs e)
        {
            var ttxtConditionName = txtConditionName.SelectedValue.Trim();
            int trdropdownyesconditions = rdropdownyesconditions.SelectedIndex;
            if (trdropdownyesconditions < 1)
            {
                string str = "Please fill all highlighted fields with *(Mandatory Fields)";
                conditionsfeedback.InnerHtml = "<div class='alert alert-success'>" + str + "</div>";
            }
            string docNo = Request.QueryString["requisitionNo"].Trim();
            var status = new Config().ObjNav().FnAddPrincipalMemberConditions(docNo, ttxtConditionName, trdropdownyesconditions);
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
        protected void ValidateFactoryDetail_Click(object sender, EventArgs e)
        {
            var tgrowerNumber = growerNumber.Text.Trim();
            var FactoryName = "";


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
            var tgrowerapplicanttype = growerapplicanttype.SelectedIndex;
         
                var FactoryCode = new Config().ObjNav().FnGetFactoryCode(tgrowerNumber, tgrowerapplicanttype);
                if (FactoryCode == "")
                {
                    growerdetails.InnerText = "The Grower Number Provided is not valid.It must be a Whole number with 9 Characters";
                }
                else
                {
                    txtFactoryCode.Text = FactoryCode;
                }
                FactoryName = new Config().ObjNav().FnGetFactoryName(tgrowerNumber, tgrowerapplicanttype);
                if (FactoryName == "")
                {
                    growerdetails.InnerText = "The Grower Number Provided is not valid.It must be a Whole number with 9 Characters";
                }

                else
                {
                    ttxtFactoryName.Text = FactoryName;
                    NAV nav = Config.ReturnNav();
                    var tCategoryDetails = nav.KTDAFactories.Where(x => x.Code == FactoryName);
                    foreach (var item in tCategoryDetails)
                    {
                        krapinNumber.Text = item.KRA_PIN;
                    }

                    int tgrowerapplicanttype1 = growerapplicanttype.SelectedIndex;
                    if (tgrowerapplicanttype1 == 2)
                    {
                        List<DropDownList> KTDAFARMERSlist = new List<DropDownList>();
                        string AllCustomers = new Config().ObjNav().FnGetKTDAFarmers(FactoryName);
                        String[] info = AllCustomers.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                        if (info != null)
                        {
                            foreach (var allInfo in info)
                            {
                                String[] arr = allInfo.Split('*');
                                DropDownList code = new DropDownList();
                                code.Code = arr[0];
                                code.Name = arr[0] + " " + arr[1];
                                KTDAFARMERSlist.Add(code);
                            }
                        }
                        txtfinancier.DataSource = KTDAFARMERSlist;
                        txtfinancier.DataValueField = "Code";
                        txtfinancier.DataTextField = "Name";
                        txtfinancier.DataBind();
                        txtfinancier.Items.Insert(0, "--Select Financier--");
                    }
                                   
            }
        }
        protected void ValidateIDNumberDetail_Click(object sender, EventArgs e)
        {
            bool error = false;
            var ttxtIdNumber = txtIdNumber.Text.Trim();
            if (ttxtIdNumber.Length > 8)
            {
                error = true;
                idNumberPassport.InnerText = "Please Enter the Correct ID No/Passport Value,It must be a Whole number between 6 and 8";
            }
            if (ttxtIdNumber.Length < 6)
            {
                error = true;
                idNumberPassport.InnerText = "Please Enter the Correct ID No/Passport Value,It must be a Whole number between 6 and 8";
            }
            if(!error)
            {
                var status = new Config().ObjNav().FnCheckifIdentityNoExist(ttxtIdNumber);
                var res = status.Split('*');
                if (res[0] == "danger")
                {
                    error = true;
                    idNumberPassport.InnerText = "The ID No/Passport Provided Already Exist.Kindly use a different Unique ID No/Passport";
                }
                else
                {
                    idNumberPassport.InnerText = "";
                }
            }
            else
            {
                idNumberPassport.InnerText = "Please Enter the Correct ID No/Passport Value,It must be a Whole number between 6 and 8";
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
                    string docNo = Request.QueryString["requisitionNo"].Trim();
                    string GrowerNumber = Request.QueryString["GrowerNumber"].Trim();
                    var status = new Config().ObjNav().CreateClientBeneficiary(docNo, beneficiary, name, selectedIndex, exact, idNo, Convert.ToDecimal(age), tallocation, ttxtgender2);
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
            string docNo = Request.QueryString["requisitionNo"].Trim();
            string GrowerNumber = Request.QueryString["GrowerNumber"].Trim();
            var status = new Config().ObjNav().ValidateClientBeneficiary(docNo);
            var res = status.Split('*');
            if (res[0] == "success")
            {
                Response.Redirect("KYMIndividualClientApplication.aspx?requisitionNo=" + docNo + "&&GrowerNumber=" + GrowerNumber + "&step=" + 5);
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
        protected void AddDependants_Click(object sender, EventArgs e)
        {
            string ApplicationNumber = Request.QueryString["requisitionNo"].Trim();
            string GrowerNumber = Request.QueryString["GrowerNumber"].Trim();
            ApplicationNumber = ApplicationNumber.Replace('/', '_');
            ApplicationNumber = ApplicationNumber.Replace(':', '_');
            GrowerNumber = GrowerNumber.Replace('/', '_');
            GrowerNumber = GrowerNumber.Replace(':', '_');
            string path1 = Config.FilesLocation() + "Individual Client Underwriting/";
            string rQuisitionNo = Request.QueryString["requisitionNo"];
            string str1 = Convert.ToString(ApplicationNumber) + '_' + Convert.ToString(GrowerNumber); ;
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
                    string filename = dependantCode + "_" + GrowerNumber + "_DependantPhoto_"+name + extension;
                    string fullfileName = folderName + filename;
                    if (!Directory.Exists(folderName))
                    {
                        Directory.CreateDirectory(folderName);
                    }
                    depedantphoto.SaveAs(folderName + filename);
                    Config.navExtender.AddLinkToRecord("Individual Client Underwriting", rQuisitionNo, fullfileName, "");

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
                    string docNo = Request.QueryString["requisitionNo"].Trim();
                    var status = new Config().ObjNav().CreateClientDependants(docNo, dependantCode, name, exact, selectedIndex1, idNo, Convert.ToDecimal(age), tdependant, dHB, Convert.ToDecimal(premium), Imagedepedantphotobytes, ttxtgenders, tdependantconditions);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        if (depedantphoto.HasFile == true)
                        {

                            string extension = System.IO.Path.GetExtension(depedantphoto.FileName);
                            if (extension == ".Bmp" || extension == ".bmp" || extension == ".BMP" || extension == ".jpg" || extension == ".png" || extension == ".Jpeg" || extension == ".jpeg" || extension == ".Png" || extension == ".JPEG" || extension == ".PNG")
                            {
                                string filename = dependantCode + "_" + GrowerNumber + "_DependantPhoto" + extension;
                                var dPhoto = new Config().ObjNav().FnInsertDependentPhoto(ApplicationNumber, filename, dependantCode, GrowerNumber);
                                var res1 = dPhoto.Split('*');
                                if (res1[0] != "success")
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>" + res[1] + "</div>";

                                }
                            }
                        }


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
        protected void ValidateFormUpload(object sender, EventArgs e)
        {

            var tmodeofpayments = modeofpayments.SelectedValue.Trim();
            if (tmodeofpayments == "KTDA check Off")
            {
                generalformcheckoffs.Visible = true;
                generalformgurantor.Visible = false;
                generalformgreenleaf.Visible = false;
                generalformktdastaffdeduction.Visible = false;
            }
            else if (tmodeofpayments == "Corporate Checkoff")
            {
                generalformcheckoffs.Visible = true;
                generalformgurantor.Visible = false;
                generalformgreenleaf.Visible = false;
                generalformktdastaffdeduction.Visible = false;
            }
            else if (tmodeofpayments == "Guarantor Form")
            {
                generalformgurantor.Visible = true;
                generalformcheckoffs.Visible = false;
                generalformgreenleaf.Visible = false;
                generalformktdastaffdeduction.Visible = false;
            }
            else if (tmodeofpayments == "Green Leaf")
            {
                generalformgreenleaf.Visible = true;
                generalformgurantor.Visible = false;
                generalformcheckoffs.Visible = false;
                generalformktdastaffdeduction.Visible = false;
            }
            else if (tmodeofpayments == "KTDA Staff deduction")
            {
                generalformktdastaffdeduction.Visible = true;
                generalformgurantor.Visible = false;
                generalformcheckoffs.Visible = false;
                generalformgreenleaf.Visible = false;
            }
            else
            {
                generalformgurantor.Visible = false;
                generalformcheckoffs.Visible = false;
                generalformgreenleaf.Visible = false;
                generalformktdastaffdeduction.Visible = false;
            }
        }
        protected void Update_Text(object sender, EventArgs e)
        {


            int ttxtrelationship = txtrelationship.SelectedIndex;
            string depedanttype = "";
            if (ttxtrelationship == 1 || ttxtrelationship == 2 || ttxtrelationship == 7)
            {
                ttxtdependanttype.Text = "Adult";
                string docNo = Request.QueryString["requisitionNo"].Trim();
                NAV nav = Config.ReturnNav(); ;
                var ClientDetails = nav.ClientApplicationQuery.Where(x => x.No == docNo);
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
                string docNo = Request.QueryString["requisitionNo"].Trim();
                NAV nav = Config.ReturnNav(); ;
                var ClientDetails = nav.ClientApplicationQuery.Where(x => x.No == docNo);
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
            string docNo = Request.QueryString["requisitionNo"].Trim();
            var Applicant = Session["empNo"].ToString();
            var status = new Config().ObjNav().DeleteClientBeneficiary(docNo, tbeneficiarycodetoRemove);
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
        protected void DeleteCondition_Click(object sender, EventArgs e)
        {
            var tConditioncodetoRemove = ConditioncodetoRemove.Text.Trim();
            string docNo = Request.QueryString["requisitionNo"].Trim();
            var Applicant = Session["empNo"].ToString();
            var status = new Config().ObjNav().RemoveDependantConditions(tConditioncodetoRemove,docNo);
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
        protected void DeleteDependant_Click(object sender, EventArgs e)
        {
            var tremovedependantCode = removedependantCode.Text.Trim();
            string docNo = Request.QueryString["requisitionNo"].Trim();
            var Applicant = Session["empNo"].ToString();
            var status = new Config().ObjNav().DeleteClientDependant(docNo, tremovedependantCode);
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
            string ttxttwitter = txttwitter.Text.Trim();
            //if (ttxttwitter.Length < 1)
            //{
            //    flag = true;
            //    str = "Please Enter a Valid Value for Twitter Account";
            //}
            string ttxtaddress = txtaddress.Text.Trim();
            if (ttxtaddress.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string ttxtlinkedin = txtlinkedin.Text.Trim();
            //if (ttxtlinkedin.Length < 1)
            //{
            //    flag = true;
            //    str = "Please Enter a Valid Value for LinkedIn Account";
            //}
            string txtpostcode = postcodes.SelectedValue.Trim();
            if (txtpostcode.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
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
                    string docNo = Request.QueryString["requisitionNo"].Trim();
                    string GrowerNumber = Request.QueryString["GrowerNumber"].Trim();
                    var Applicant = Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnewClientApplicationsCommunicationDetails(docNo, ttelnumber1, ttelnumber2, txtcity, txtfacebook, ttxtemail, ttxtaddress, txtpostcode, ttxttwitter, ttxtlinkedin, ttxtgoogle);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("KYMIndividualClientApplication.aspx?requisitionNo=" + docNo + "&&GrowerNumber=" + GrowerNumber + "&step=3");

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
            var tlblpolicyType = lblpolicyType.SelectedValue.Trim();
            if (tlblpolicyType.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string product = lblproduct.SelectedValue.Trim();
            if (product.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }


            int selectedIndex2 = agentDetail.SelectedIndex;
            string agentcode = "";
            string referralIdNumber = "";
            string referralName = "";
            string referralMobileNumber = "";
            if (selectedIndex2 == 1)
            {
                selectedIndex2 = agentDetail.SelectedIndex;
                agentcode = lblsalesgentcode.SelectedValue.Trim();
                if (agentcode.Length < 1)
                {
                    flag = true;
                    str = "Please fill all highlighted fields with *(Mandatory Fields)";
                }
            }
            if (selectedIndex2 == 2)
            {
                agentcode = lblsalesgentcode.SelectedValue.Trim();
                if (agentcode.Length < 1)
                {
                    flag = true;
                    str = "Please fill all highlighted fields with *(Mandatory Fields)";
                }
            }
            if (selectedIndex2 == 3)
            {
                referralName = txtrefferalname.Text.Trim();
                if (referralName.Length < 1)
                {
                    flag = true;
                    str = "Please fill all highlighted fields with *(Mandatory Fields)";
                }
                referralMobileNumber = txtreferalmobilenumber.Text.Trim();
                if (referralMobileNumber.Length < 1)
                {
                    flag = true;
                    str = "Please fill all highlighted fields with *(Mandatory Fields)";
                }

            }

            int selectedIndex3 = 1;
            //if (selectedIndex3 < 0)
            //{
            //    flag = true;
            //    str = "Please Enter a Valid  Value for Member Type";
            //}
            int selectedIndex4 = invoiceperiod.SelectedIndex;
            if (selectedIndex4 < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            //if (txtfinancier.Text.Trim().Length < 1)
            //{
            //    flag = true;
            //    str = "Please Enter a Valid  Value for Financier";
            //}
            if (serviceperiod.Text.Trim().Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            if (insurer.Text.Trim().Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            int selectedIndex5 = modeofpayments.SelectedIndex;
            if (selectedIndex5 < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string mpesaNumber = "";
            bool nonrenewable = false;
            int tlblhasbinder = 0;
            int tdepartment = 1;
            var dhb = dailyhealthbenefits.SelectedValue.Trim();
            if (dhb.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            try
            {
                if (flag)
                {
                    policyfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    var documentsmodeofpayments = modeofpayments.SelectedValue.Trim();
                    string ApplicationNumber = Request.QueryString["GrowerNumber"].Trim();
                    ApplicationNumber = ApplicationNumber.Replace('/', '_');
                    ApplicationNumber = ApplicationNumber.Replace(':', '_');
                    string path1 = Config.FilesLocation() + "Individual Client Underwriting/";
                    string rQuisitionNo = Request.QueryString["requisitionNo"];
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
                                    string filename = ApplicationNumber + "_CheckOffForm" + extension;
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
                                    Config.navExtender.AddLinkToRecord("Individual Client Underwriting", rQuisitionNo, fullfileName, "");
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
                                    string filename = ApplicationNumber + "_CheckOffForm" + extension;
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
                                    Config.navExtender.AddLinkToRecord("Individual Client Underwriting", rQuisitionNo, fullfileName, "");
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
                                    string filename = ApplicationNumber + "_GuarantorForm" + extension;
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
                                    Config.navExtender.AddLinkToRecord("Individual Client Underwriting", rQuisitionNo, fullfileName, "");
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
                                    string filename = ApplicationNumber + "_GreenLeaf" + extension;
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
                                    Config.navExtender.AddLinkToRecord("Individual Client Underwriting", rQuisitionNo, fullfileName, "");
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
                                    string filename = ApplicationNumber + "_KTDAStaffDeductionForm" + extension;
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
                                    Config.navExtender.AddLinkToRecord("Individual Client Underwriting", rQuisitionNo, fullfileName, "");
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
                    string docNo = this.Request.QueryString["requisitionNo"].Trim();
                    string GrowerNumber = Request.QueryString["GrowerNumber"].Trim();
                    var Applicant = Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnIndividualupdatePolicyDetails(docNo, tdepartment, tlblpolicyType, product, selectedIndex5, selectedIndex4, selectedIndex3, selectedIndex2, dhb, agentcode, referralIdNumber, referralName, referralMobileNumber, mpesaNumber);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("KYMIndividualClientApplication.aspx?requisitionNo=" + docNo + "&&GrowerNumber=" + GrowerNumber + "&step=4");

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
            NAV nav = Config.ReturnNav();
            string tcustomerCategory = customerCategory.SelectedValue.Trim();
            string tsubcustomerCategory = customerSubCategory.SelectedValue.Trim();
            if (tsubcustomerCategory == "FACTORY STAFF")
            {
                var KTDARelated = nav.KTDARelatedItems.Where(x => x.Customer_Category == tcustomerCategory && x.Code == tsubcustomerCategory && x.Department == "micro-insurance");
                List<DropDownList> KTDARelatedItemsList = new List<DropDownList>();
                foreach (var item in KTDARelated)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Item_Code;
                    code.Name = item.Description;
                    KTDARelatedItemsList.Add(code);
                }
                applicationTypes.DataSource = KTDARelatedItemsList;
                applicationTypes.DataTextField = "Name";
                applicationTypes.DataValueField = "Code";
                applicationTypes.DataBind();
                applicationTypes.Items.Insert(0, "--Select Applicant Type--");
            }
            else
            {

               
                if (tsubcustomerCategory == "SUBSIDIARY STAFF")
                { 
                    growerapplicanttype.Enabled = false;
                }
                else
                {
                    growerapplicanttype.Enabled = true;
                }

                var KTDARelated = nav.KTDARelatedItems.Where(x => x.Customer_Category == tcustomerCategory && x.Code == tsubcustomerCategory && x.Department == "micro-insurance");
                List<DropDownList> KTDARelatedItemsList = new List<DropDownList>();
                foreach (var item in KTDARelated)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Item_Code;
                    code.Name = item.Description;
                    KTDARelatedItemsList.Add(code);
                }
                applicationTypes.DataSource = KTDARelatedItemsList;
                applicationTypes.DataTextField = "Name";
                applicationTypes.DataValueField = "Code";
                applicationTypes.DataBind();
                applicationTypes.Items.Insert(0, "--Select Applicant Type--");
            }
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
            Response.Redirect("KYMIndividualClientApplication.aspx?requisitionNo=" + str + "&&GrowerNumber=" + GrowerNumber + "&step=" + num2);
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
            Response.Redirect("KYMIndividualClientApplication.aspx?requisitionNo=" + str + "&&GrowerNumber=" + GrowerNumber + "&step=" + num2);
        }

        protected void SubmitApplication_Click(object sender, EventArgs e)
        {
            try
            {
                NAV nav = Config.ReturnNav();
                var Requisition = Request.QueryString["requisitionNo"].Trim();
                var Conditions = Config.ReturnNav().ClientApplicationQuery.Where(x => x.No == Requisition).ToList();
                foreach (var item in Conditions)
                {
                    if (item.ScannedCopy == true || item.DepedantPhoto == true)
                    {
                        var step = Convert.ToInt32(Request.QueryString["step"].Trim());
                        var status = new Config().ObjNav().SendIndividualClientApplicationApproval(Requisition);
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
                    else
                    {
                        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The New Client Application Details Could not be Submitted for Approval.Kindly Attach all the Documents before your proceed" + "</div>";

                    }
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

                var tprincipleName = "";
                var tFirstName = "";
                var tlastName = "";
                string ApplicationNumber = Request.QueryString["requisitionNo"].Trim();
                string GrowerNumber = Request.QueryString["GrowerNumber"].Trim();
                ApplicationNumber = ApplicationNumber.Replace('/', '_');
                ApplicationNumber = ApplicationNumber.Replace(':', '_');
                GrowerNumber = GrowerNumber.Replace('/', '_');
                GrowerNumber = GrowerNumber.Replace(':', '_');
                string rQuisitionNo = Request.QueryString["requisitionNo"];
                string path1 = Config.FilesLocation() + "Individual Client Underwriting/";
                string str1 = Convert.ToString(ApplicationNumber) +'_'+ Convert.ToString(GrowerNumber);

                var nav = Config.ReturnNav();
                var applications = nav.ClientApplicationQuery.Where(r => r.No == rQuisitionNo).ToList();
                foreach(var principalname in applications)
                {
                    tFirstName = principalname.First_Name;
                    tlastName = principalname.Last_Name;
                }
                tprincipleName = tFirstName +"_"+ tlastName;


                string folderName = path1 + str1 +"_"+ tprincipleName + "/";
                bool error = false;
                string message = "";
                try
                {

                    if (filetoupload.HasFile)
                    {
                        string extension = System.IO.Path.GetExtension(filetoupload.FileName);
                        if (new Config().IsAllowedExtension(extension))
                        {
                            string filename = GrowerNumber + "_ScannedApplication_" +tprincipleName+ extension;
                            string fullfileName = folderName + filename;
                            if (!Directory.Exists(folderName))
                            {
                                Directory.CreateDirectory(folderName);
                            }
                            //if (File.Exists(folderName + filename))
                            //{
                            //    File.Delete(folderName + filename);
                            //}
                            filetoupload.SaveAs(folderName + filename);
                            Config.navExtender.AddLinkToRecord("Individual Client Underwriting", rQuisitionNo, fullfileName, "");
                            bool scannedcopy = true;
                            bool depedantphoto = false;
                            var Requisition = Request.QueryString["requisitionNo"].Trim();
                            var status = new Config().ObjNav().FnDocumentsValidations(Requisition, scannedcopy, depedantphoto);

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
                            string filename = GrowerNumber + "_OtherDocument_" +tprincipleName+ extension;
                            string fullfileName = folderName + filename;
                            if (!Directory.Exists(folderName))
                            {
                                Directory.CreateDirectory(folderName);
                            }
                            //if (File.Exists(folderName + filename))
                            //{
                            //    File.Delete(folderName + filename);
                            //}
                            guardianshipletter.SaveAs(folderName + filename);
                            Config.navExtender.AddLinkToRecord("Individual Client Underwriting", rQuisitionNo, fullfileName, "");
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
                    if (principalmemberphoto.HasFile == true)
                    {
                        string extension = System.IO.Path.GetExtension(principalmemberphoto.FileName);
                        if (extension == ".jpg" || extension == ".JPEG" || extension == ".png" || extension == ".PNG" || extension == ".jpeg" || extension == ".gif")
                        {
                            string filename = GrowerNumber + "_PrinciplePhoto_" +tprincipleName+ extension;
                            string fullfileName = folderName + filename;
                            if (!Directory.Exists(folderName))
                            {
                                Directory.CreateDirectory(folderName);
                            }
                            //if (File.Exists(folderName + filename))
                            //{
                            //    File.Delete(folderName + filename);
                            //}
                            principalmemberphoto.SaveAs(folderName + filename);
                            Config.navExtender.AddLinkToRecord("Individual Client Underwriting", rQuisitionNo, fullfileName, "");
                            bool scannedcopy = true;
                            bool depedantphoto = true;
                            var Requisition = Request.QueryString["requisitionNo"].Trim();
                            var status = new Config().ObjNav().FnDocumentsValidations(Requisition, scannedcopy, depedantphoto);

                            var dPhoto = new Config().ObjNav().FnInsertPrinciplePhoto(Requisition, filename, GrowerNumber, tprincipleName);
                            var res = dPhoto.Split('*');
                            if (res[0] != "success")
                            {
                                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>" + res[1] + "</div>";

                            }
                        }
                        else
                        {
                            error = true;
                            message += message.Length > 0 ? "<br>" : "";
                            message += "The file extension of the Principal Photo is not allowed,Kindly upload PDF files";
                        }

                    }
                    else
                    {
                        error = true;
                        message += message.Length > 0 ? "<br>" : "";
                        message += "Kindly Upload the Principal Photo before you proceed";
                    }
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
        protected void GetProducts_Onlick(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string tpolicyType = lblpolicyType.SelectedValue.Trim();
            var tpolicyTypequery = nav.Items.Where(x => x.Policy_Type == tpolicyType && x.Insurance_Item_type == "Insurance");
            List<DropDownList> tpolicyTypequeryList = new List<DropDownList>();
            foreach (var item in tpolicyTypequery)
            {
                DropDownList code = new DropDownList();
                code.Code = item.No;
                code.Name = item.Insurer_Name + "- " + item.Description + "- " + item.Policy_Type;
                tpolicyTypequeryList.Add(code);
            }
            lblproduct.DataSource = tpolicyTypequeryList;
            lblproduct.DataTextField = "Name";
            lblproduct.DataValueField = "Code";
            lblproduct.DataBind();
            lblproduct.Items.Insert(0, "--Select Product--");
        }

        protected void GetProductsdetails_Onlick(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string tlblproduct = lblpolicyType.SelectedValue.Trim();
            var productDetails = nav.Items.Where(x => x.Policy_Type == tlblproduct && x.Insurance_Item_type == "Insurance");
            foreach (var item in productDetails)
            {
                insurer.Text = item.Insurer;
                invoiceperiod.Text = item.Invoice_Period;
                serviceperiod.Text = item.Service_Period;
                //txtpolicyno.Text = item.Last_Policy_No_Used;
            }
            string tpoduct = lblproduct.SelectedValue.Trim();
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
        protected void AgentDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tagentDetail = agentDetail.SelectedIndex;
            var tagentnSubCategoryDetail = lblagentsubcategory.SelectedValue.Trim();
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



        // protected void GetgrowerFields_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (hasgrowerNo.Checked == true)
        //    {
        //        dvShowGowerDetails.Visible = true;
        //    }
        //    else
        //    {
        //        dvShowGowerDetails.Visible = false;

        //    }
        //}

        protected void DisplayHealthConditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdropdownyesconditions.SelectedValue == "Yes")
            {
                displayhealthConditions.Visible = true;
            }
            else
            {
                displayhealthConditions.Visible = false;

            }
        }

        protected void GetFinancier_SelectedIndexChanged(object sender, EventArgs e)
        {

            int tgrowerapplicanttype = growerapplicanttype.SelectedIndex;
            if (tgrowerapplicanttype == 2)
            {
                financier.Visible = true;
            }
            else
            {
                financier.Visible = false;

            }
        }
        protected void GetFactoryDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tsubcustomerCategory = customerSubCategory.SelectedValue.Trim();
            NAV nav = Config.ReturnNav();
            var tCategoryDetails = nav.KTDAFactories.Where(x => x.Code == tsubcustomerCategory);
            foreach (var item in tCategoryDetails)
            {
                krapinNumber.Text = item.KRA_PIN;
            }
        }

        protected void SubCategories_Onclick(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string tcustomerCategory = customerCategory.SelectedValue.Trim();
            var tsubcustomerCategory = nav.CustomerSubCategory.Where(x => x.Customer_Category == tcustomerCategory && x.Individual == true);
            List<DropDownList> subcustomerCategorylist = new List<DropDownList>();
            foreach (var item in tsubcustomerCategory)
            {
                DropDownList code = new DropDownList();
                code.Code = item.Code;
                code.Name = item.Description;
                subcustomerCategorylist.Add(code);
            }
            customerSubCategory.DataSource = subcustomerCategorylist;
            customerSubCategory.DataTextField = "Name";
            customerSubCategory.DataValueField = "Code";
            customerSubCategory.DataBind();
            customerSubCategory.Items.Insert(0, "--Select Customer Sub Category--");
        }

        protected void applicationTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tapplicationTypes = applicationTypes.SelectedValue.Trim();

            if (tapplicationTypes == "FACTORY STAFF")
            {
                growerapplicanttype.Enabled = false;
            }
            else
            {
                growerapplicanttype.Enabled = true;
            }
        }
    }
}