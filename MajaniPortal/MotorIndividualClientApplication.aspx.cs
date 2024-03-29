﻿using MajaniPortal.Nav;
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
    public partial class MotorIndividualClientApplication : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NAV nav = Config.ReturnNav();
                try
                {
                    var requisitionNo = Request.QueryString["requisitionNo"].Trim();
                    if (requisitionNo != null)
                    {
                        var productDetails = nav.ClientApplicationQuery.Where(x => x.No == requisitionNo);
                        foreach (var item in productDetails)
                        {
                            totalsvaluesuminsured.Text = Convert.ToString(item.Total_Value_Sum_Insured);
                            totalpremium.Text = Convert.ToString(item.Total_Premiums);
                            totalpremiumspayables.Text = Convert.ToString(item.Total_Premiums_Payable);
                        }
                    }
                    else
                    {

                    }
                }
                catch (Exception)
                {

                }

                List<DropDownList> VendorCategorylist = new List<DropDownList>();
                var VendorCategory = nav.Vendors.Where(r => r.Vendor_Type == "Insurer").ToList();
                foreach (var item in VendorCategory)
                {
                    DropDownList itemlist = new DropDownList();
                    itemlist.Code = item.No;
                    itemlist.Name = item.Name;
                    VendorCategorylist.Add(itemlist);
                }
                txtinsurers.DataSource = VendorCategorylist;
                txtinsurers.DataValueField = "Code";
                txtinsurers.DataTextField = "Name";
                txtinsurers.DataBind();
                txtinsurers.Items.Insert(0, "--Select Insurer Name--");

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

                List<string> rtxtpaymentsoptions = new List<string>();
                rtxtpaymentsoptions.Add("-----Select Payment Options-------");
                rtxtpaymentsoptions.Add("Direct to Majani");
                rtxtpaymentsoptions.Add("Direct to Insurer");
                txtpaymentsoptions.DataSource = rtxtpaymentsoptions;
                txtpaymentsoptions.DataBind();

                var VehicleMake = nav.VehicleMake.ToList();
                List<DropDownList> VehicleMakelist = new List<DropDownList>();
                foreach (var item in VehicleMake)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Code;
                    code.Name = item.Description;
                    VehicleMakelist.Add(code);
                }
                make.DataSource = VehicleMakelist;
                make.DataValueField = "Code";
                make.DataTextField = "Name";
                make.DataBind();
                make.Items.Insert(0, "--Select Make Code--");

                List<string> ttgrowerapplicanttype = new List<string>();
                ttgrowerapplicanttype.Add("-----Select Grower Type of Applicants-------");
                ttgrowerapplicanttype.Add("KTDA Farmer");
                ttgrowerapplicanttype.Add("Farmer Dependent");
                ttgrowerapplicanttype.Add("Factory Staff");
                ttgrowerapplicanttype.Add("NON Tea Individual");
                ttgrowerapplicanttype.Add("NON Tea Corporate");
                growerapplicanttype.DataSource = ttgrowerapplicanttype;
                growerapplicanttype.DataBind();

                var PolicyTypes = Config.ReturnNav().PolicyTypes.Where(x => x.Insurance_Category == "General" && x.Business_Type_SubCategory == "Motor").ToList();
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


                var PolicyList = Config.ReturnNav().PolicyList.Where(c => c.Business_Type == "General").ToList();
                List<DropDownList> AllPolicyList = new List<DropDownList>();
                foreach (var item in PolicyList)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Contract_No;
                    code.Name = item.Contract_No + "_" + item.Name;
                    PolicyTypesList.Add(code);
                }
                serviceContract.DataSource = PolicyTypesList;
                serviceContract.DataTextField = "Name";
                serviceContract.DataValueField = "Code";
                serviceContract.DataBind();
                serviceContract.Items.Insert(0, "--Select Policy No--");


                var KTDAFARMERS = Config.ReturnNav().KTDAFARMERS.Where(x => x.Business_Type == "General").ToList();
                List<DropDownList> KTDAFARMERSlist = new List<DropDownList>();
                foreach (var item in KTDAFARMERS)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Grower_No;
                    code.Name = item.Grower_No + " " + item.Name;
                    KTDAFARMERSlist.Add(code);
                }
                txtfinancier.DataSource = KTDAFARMERSlist;
                txtfinancier.DataValueField = "Code";
                txtfinancier.DataTextField = "Name";
                txtfinancier.DataBind();
                txtfinancier.Items.Insert(0, " ");


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


                var CoverTypes = nav.CoverTypes.ToList();
                List<DropDownList> CoverTypeslist = new List<DropDownList>();
                foreach (var item in CoverTypes)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Cover_Code;
                    code.Name = item.Cover_Description;
                    CoverTypeslist.Add(code);
                }
                covertype.DataSource = CoverTypeslist;
                covertype.DataValueField = "Code";
                covertype.DataTextField = "Name";
                covertype.DataBind();
                covertype.Items.Insert(0, "--Select Cover Type---");

                List<DropDownList> customerSubCategorylist = new List<DropDownList>();
                var tcustomerSubCategory = nav.CustomerSubCategory.ToList();
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


                List<string> lblhasbinders = new List<string>();
                lblhasbinders.Add("Yes");
                lblhasbinders.Add("No");
                lblhasbinder.DataSource = lblhasbinders;
                lblhasbinder.DataBind();

                var ttxtdropdownlist = nav.BodyTypes.ToList();
                List<DropDownList> txtdropdownlistlist = new List<DropDownList>();
                foreach (var item in ttxtdropdownlist)
                {
                    DropDownList itemcodelist = new DropDownList();
                    itemcodelist.Code = item.code;
                    itemcodelist.Name = item.Description;
                    txtdropdownlistlist.Add(itemcodelist);
                }
                txtdropdownlist.DataSource = txtdropdownlistlist;
                txtdropdownlist.DataValueField = "Code";
                txtdropdownlist.DataTextField = "Code";
                txtdropdownlist.DataBind();
                txtdropdownlist.Items.Insert(0, "--Select Body Types--");



                List<string> tgrowerapplicanttype = new List<string>();
                tgrowerapplicanttype.Add("-----Select Grower Type of Applicants-------");
                tgrowerapplicanttype.Add("KTDA Farmer");
                tgrowerapplicanttype.Add("Farmer Dependent");
                tgrowerapplicanttype.Add("Factory Staff");
                tgrowerapplicanttype.Add("NON Tea Individual");
                tgrowerapplicanttype.Add("NON Tea Corporate");
                growerapplicanttype.DataSource = tgrowerapplicanttype;
                growerapplicanttype.DataBind();

                //List<string> productbillingcycles = new List<string>();
                //productbillingcycles.Add("-----Select Product Billing Cycle-------");
                //productbillingcycles.Add("Month");
                //productbillingcycles.Add("Two Months");
                //productbillingcycles.Add("Quarter");
                //productbillingcycles.Add("Half Year");
                //productbillingcycles.Add("Year");
                //productbillingcycles.Add("None");
                //invoiceperiod.DataSource = productbillingcycles;
                //invoiceperiod.DataBind();


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

                List<string> txtgend = new List<string>();
                txtgend.Add("-----Select Gender-------");
                txtgend.Add("Male");
                txtgend.Add("Female");
                lblgender.DataSource = txtgend;
                lblgender.DataBind();

                //List<string> ttxtdependanttype = new List<string>();
                //ttxtdependanttype.Add("-----Select Dependant Type-------");
                //ttxtdependanttype.Add("Adult");
                //ttxtdependanttype.Add("Child");
                //txtdependanttype.DataSource = ttxtdependanttype;
                //txtdependanttype.DataBind();


                List<DropDownList> tCountriesOfResidencelist = new List<DropDownList>();
                var tCountriesOfResidence = nav.Countries.ToList();
                foreach (var item in tCountriesOfResidence)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Code;
                    code.Name = item.Code + " " + item.Name;
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
                agentDetail.DataSource = tagentDetail;
                agentDetail.DataBind();

                List<string> tlbldepartments = new List<string>();
                tlbldepartments.Add("General");
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

                binderfeerate.ReadOnly = true;
                commissionRate.ReadOnly = true;
                dvgrowerdetails.Visible = false;
                dvremarks.Visible = false;
                basicpremium.Visible = false;
                generalformgurantor.Visible = false;
                generalformcheckoffs.Visible = false;
                generalformgreenleaf.Visible = false;
                divlatestevaluationreport.Visible = false;
                generalformktdastaffdeduction.Visible = false;
                filecheques.Visible = false;


                string tapplicationNo = "";
                try
                {
                    tapplicationNo = Convert.ToString(Request.QueryString["requisitionNo"]);
                    var applications = nav.ClientApplicationQuery.Where(r => r.No == tapplicationNo && r.Requestor == Convert.ToString(Session["empNo"])).ToList();
                    if (applications.Count > 0)
                    {
                        foreach (var app in applications)
                        {
                            customerCategory.SelectedValue = app.Customer_Category;
                            customerSubCategory.SelectedValue = app.Customer_Sub_Category;
                            applicationTypes.SelectedValue = app.Applicant_Type;
                            growerapplicanttype.SelectedValue = app.Grower_Type_of_Applicant;
                            growerNumber.Text = app.Grower_No_Client_ID;
                            txtFactoryCode.Text = app.Factory_Code_Branch_Code;
                            ttxtFactoryName.Text = app.Factory_Name_Branch_Name;
                            idtype.SelectedValue = app.ID_Type;
                            txtIdNumber.Text = app.ID_No_Passport_No;
                            lbltitle.SelectedValue = app.Title;
                            txtfirstname.Text = app.First_Name;
                            txtMiddleName.Text = app.Middle_Name;
                            txtlastname.Text = app.Last_Name;
                            lblgender.SelectedValue = app.Gender;

                            ttxtoccupations.SelectedValue = app.Occupation;
                            krapinNumber.Text = app.KRA_PIN_No;
                            lblcountyCode.SelectedValue = app.County_Code;
                            txtresidential.Text = app.Residential_Location;
                            lblmaritalstatus.SelectedValue = app.Marital_Status;
                            txtHudumaNo.Text = app.Huduma_No;
                            countyofresidence.SelectedValue = app.Country_Region_Code;
                            officelocation.Text = app.Office_Location;
                            telnumber1.Text = app.Tel_Mobile_No;
                            telnumber2.Text = app.Tel_Mobile_No_2;
                            txtemail.Text = app.E_Mail;
                            txtaddress.Text = app.Address;
                            postcodes.SelectedValue = app.Post_Code;
                            lblcity.Text = app.City;
                            txtgoogle.Text = app.Google;
                            txttwitter.Text = app.Twitter;
                            txtfcebook.Text = app.Facebook;
                            txtlinkedin.Text = app.LinkedIn;


                        }
                    }



                }
                catch
                {

                }
            }
        }
        protected void Next_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string id_passport = txtIdNumber.Text.Trim();
            string cust_category = customerCategory.SelectedValue.Trim();
            if (cust_category.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), customer category";
            }
            if (customerSubCategory.SelectedValue.Trim().Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), customer sub category";
            }
            string applicanttype = applicationTypes.SelectedValue.Trim();
            if (applicanttype.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), Application Type";
            }
            string countryOfResidence = countyofresidence.SelectedValue.Trim();
            if (countryOfResidence.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), county of residence";
            }
            int selectedIndex1 = 2;
            bool thasgrowerNo = false;
            int tgrowerapplicanttype = 0;
            string financier = "";
            string tfactoryCode = "";
            string tfactoryName = "";
            string tgrowerNumber = "";
            if (hasgrowerNo.Checked == true)
            {
                thasgrowerNo = true;
                tgrowerapplicanttype = growerapplicanttype.SelectedIndex;
                try
                {

                    tfactoryCode = txtFactoryCode.Text.Trim();
                    tfactoryName = ttxtFactoryName.Text.Trim();
                    tgrowerNumber = growerNumber.Text.Trim();
                    if (tgrowerNumber.Length < 1)
                    {
                        flag = true;
                        str = "Please fill all highlighted fields with *(Mandatory Fields), grower number";
                    }
                    if (tgrowerapplicanttype < 1)
                    {
                        flag = true;
                        str = "Please fill all highlighted fields with *(Mandatory Fields), Grower applicant type";
                    }
                    else
                    {
                        if (tgrowerapplicanttype == 2)
                        {
                            financier = txtfinancier.Text.Trim();
                        

                        }
                        else
                        {
                            financier = "";

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (id_passport.Length > 8)
            {
                idNumberPassport.InnerText = "Please Enter the Correct ID No/Passport Value,It must be a Whole number between 6 and 8";
            }
            if (id_passport.Length < 6)
            {
                idNumberPassport.InnerText = "Please Enter the Correct ID No/Passport Value,It must be a Whole number between 6 and 8";

            }
            else
            {
                var status = new Config().ObjNav().FnCheckifIdentityNoExist(id_passport);
                var res = status.Split('*');
                if (res[0] == "danger")
                {
                    flag = true;
                    str = res[1];
                }
                else
                {
                    flag = false;
                    
                }
            }

            string policyType = "";
            int selectedIndex2 = idtype.SelectedIndex;
            if (selectedIndex2 < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields),Id type";
            }
            string s = txtDOB.Text.Trim();
            if (s.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), Date of birth";
            }
           
            if (id_passport.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), Id Number";
            }
            int selectedIndex3 = lblgender.SelectedIndex;
            if (selectedIndex3 < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), Gender";
            }
            string pinNo = krapinNumber.Text.Trim();
            if (pinNo.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), Kra Pin number";
            }

            string countyCode = lblcountyCode.Text.Trim();
            if (countyCode.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), cunty code";
            }
            string firstName = txtfirstname.Text.Trim();
            if (firstName.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), first name";
            }
            int selectedIndex4 = lblmaritalstatus.SelectedIndex;
            if (selectedIndex4 < 1)
            {
                selectedIndex4 = 0;
            }
            string middleName = txtMiddleName.Text.Trim();
            string hudumaNo = txtHudumaNo.Text.Trim();
            string lastname = txtlastname.Text.Trim();
            string ttxtresidential = txtresidential.Text.Trim();
            string tofficelocation = officelocation.Text.Trim();
            if (lastname.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), last name";
            }
            string occupation = ttxtoccupations.SelectedValue.Trim();
            if (occupation.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), occupation";
            }
            int selectedIndex5 = lbltitle.SelectedIndex;
            if (selectedIndex5 < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), title";
            }
            try
            {
                if (flag)
                {
                    feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    DateTime dateTime = new DateTime();
                    DateTime exact = DateTime.ParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    String docNo = "";
                    try
                    {
                        docNo = Request.QueryString["requisitionNo"];
                        docNo = String.IsNullOrEmpty(docNo) ? "" : docNo;
                    }
                    catch (Exception)
                    {
                        docNo = "";
                    }
                 
                    string empNo = Session["empNo"].ToString();
                    //docNo = Convert.ToString(Request.QueryString["requisitionNo"]);
                    var status = new Config().ObjNav().FnewMotorClientOnboadingRequests(docNo, empNo, cust_category, selectedIndex1, policyType, selectedIndex2, id_passport, pinNo, selectedIndex5, firstName, middleName, lastname, countryOfResidence, exact, selectedIndex3, countyCode, selectedIndex4, hudumaNo, applicanttype, occupation, tgrowerapplicanttype, tgrowerNumber, tfactoryCode, tfactoryName, financier, thasgrowerNo, ttxtresidential, tofficelocation);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("MotorIndividualClientApplication.aspx?requisitionNo=" + res[2] + "&step=2");

                    }
                    else
                    {
                        feedbackdetails.InnerHtml = "<div class='alert alert-danger'>The New Client Application Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";

                    }
                }
            }
            catch (Exception ex)
            {
                feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + ex.Message + "</div>";
            }
        }
        protected void SubmitRiskDetails_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
   
      
            string ttonnage = tonnage.Text.Trim();      
            bool nonRenewable = false;
            decimal sumInsured = 0;
            string registrationNo = registrationnumber.Text.Trim();
            if (registrationNo.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), Registration Number";
            }
            string tlicensedToCarry = licensedToCarry.Text.Trim();
            if (tlicensedToCarry.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), Licensed to carry";
            }

            Decimal rate = Convert.ToDecimal(txtrate.Text.Trim());
            if (rate < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), Rate";
            }
            bool tbolnonerenewable = false;
            if (bolnonerenewable.Checked == true)
            {
                tbolnonerenewable = true;
            }
            else
            {
                tbolnonerenewable = false;
            }
            bool tbolvalued = false;
            if (bolvalued.Checked == true)
            {
                tbolvalued = true;
            }
            else
            {
                tbolvalued = false;
            }
            string ttxtprotector = txtprotector.Text.Trim();
            decimal tttxtprotector = 0;
            if (ttxtprotector.Length > 1)
            {
                tttxtprotector = Convert.ToDecimal(ttxtprotector);
            }
            string ttxtbasicpremiums = txtbasicpremiums.Text.Trim();
            decimal basicpremiums = 0;
            if (ttxtbasicpremiums.Length > 1)
            {
                basicpremiums = Convert.ToDecimal(txtbasicpremiums.Text.Trim());
            }
            string tcertificateNo = certificateNo.Text.Trim();
   
            try
            {
                if (flag)
                {
                    risksfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    string docNo = Request.QueryString["requisitionNo"].Trim();                   
                    string ApplicationNumber = docNo;
                    ApplicationNumber = ApplicationNumber.Replace('/', '_');
                    ApplicationNumber = ApplicationNumber.Replace(':', '_');
                    string path1 = Config.FilesLocation() + "New Clients/";
                    string str1 = Convert.ToString(ApplicationNumber);
                    string folderName = path1 + str1 + "/";
                    bool error = false;
                    string message = "";

                    if (evaludationreport.HasFile)
                    {
                        string extension = System.IO.Path.GetExtension(evaludationreport.FileName);
                        //if (new Config().IsAllowedExtension(extension))
                        //{
                        string filename = ApplicationNumber + "_EvaluationReport" + extension;
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                        }
                        if (File.Exists(folderName + filename))
                        {
                            File.Delete(folderName + filename);
                        }
                        evaludationreport.SaveAs(folderName + filename);
                        //}
                    }
                   
                    var status = new Config().ObjNav().FnNewMotorIndividualPolicyRiskDetails(docNo ,tttxtprotector, registrationNo, tbolnonerenewable, rate, tbolvalued, basicpremiums, Convert.ToInt32(tlicensedToCarry));
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        GetTotalValueSumInsured_Onlick();
                        risksfeedbackdetails.InnerHtml = "<div class='alert alert-success'>The Motor Risk Details have been successfully Submitted</div>";
                        registrationnumber.Text = string.Empty;
                        certificateNo.Text = string.Empty;
                        chasisnumber.Text = string.Empty;
                        enginenumber.Text = string.Empty;
                        yearofmanufucture.Text = string.Empty;
                        policystratdate.Text = string.Empty;
                        duration.Text = string.Empty;
                        policiesendDate.Text = string.Empty;
                        tonnage.Text = string.Empty;
                        valuesuminsured.Text = string.Empty;
                        commissionRate.Text = string.Empty;
                        bolnonerenewable.Checked = false;
                        bolvalued.Checked = false;
                        txtprotector.Text = string.Empty;
                    }
                    else
                    {
                        risksfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>The Motor Riks Details Could not be Submitted.Kindly Try Again" + " " + res[1] + "</div>";

                    }
                }
            }
            catch (Exception ex)
            {
                risksfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Riks  Details." + ex.Message + "</div>";
            }
        }
        protected void UploadDocumentsApplication_Click(object sender, EventArgs e)
        {
            try
            {

                string ApplicationNumber = Request.QueryString["requisitionNo"].Trim();
                ApplicationNumber = ApplicationNumber.Replace('/', '_');
                ApplicationNumber = ApplicationNumber.Replace(':', '_');
                string path1 = Config.FilesLocation() + "New Clients/";
                string str1 = Convert.ToString(ApplicationNumber);
                string folderName = path1 + str1 + "/";
                bool error = false;
                string message = "";
                try
                {
                    if (uploadLogbook.HasFile)
                    {
                        string extension = System.IO.Path.GetExtension(uploadLogbook.FileName);
                        //if (new Config().IsAllowedExtension(extension))
                        //{
                        string filename = ApplicationNumber + "_Logbook" + extension;
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                        }
                        if (File.Exists(folderName + filename))
                        {
                            File.Delete(folderName + filename);
                        }
                        uploadLogbook.SaveAs(folderName + filename);
                        Config.navExtender.AddLinkToRecord("Motor Underwriting", ApplicationNumber, filename, "");
                        //}
                        //else
                        //{
                        //    error = true;
                        //    message += message.Length > 0 ? "<br>" : "";
                        //    message += "The file extension of the Logbook is not allowed,Kindly upload Pdf files";
                        //}

                    }
                    else
                    {
                        error = true;
                        message += message.Length > 0 ? "<br>" : "";
                        message += "Kindly Upload the Logbook before you proceed";

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
                    if (uploadIDCertificate.HasFile)
                    {
                        string extension = System.IO.Path.GetExtension(uploadIDCertificate.FileName);
                        //if (new Config().IsAllowedExtension(extension))
                        //{
                        string filename = ApplicationNumber + "_ID_CerticateofIncorporation " + extension;
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                        }
                        if (File.Exists(folderName + filename))
                        {
                            File.Delete(folderName + filename);
                        }
                        uploadIDCertificate.SaveAs(folderName + filename);
                        Config.navExtender.AddLinkToRecord("Motor Underwriting", ApplicationNumber, filename, "");
                        //}
                        //else
                        //{
                        //    error = true;
                        //    message += message.Length > 0 ? "<br>" : "";
                        //    message += "The file extension of the ID or Certificate of Incorporation   is not allowed";
                        //}

                    }
                    else
                    {
                        error = true;
                        message += message.Length > 0 ? "<br>" : "";
                        message += "Kindly Upload the ID or Certificate of Incorporation   before you proceed";
                    }
                }
                catch (Exception ex)
                {
                    error = true;
                    message += message.Length > 0 ? "<br>" : "";
                    message += "Kindly Upload the  ID or Certificate of Incorporation before you proceed" + ex;
                }

                try
                {
                    if (uploadKRAPinCertificate.HasFile == true)
                    {
                        string extension = System.IO.Path.GetExtension(uploadKRAPinCertificate.FileName);
                        //if (new Config().IsAllowedExtension(extension))
                        //{
                        string filename = ApplicationNumber + "_KRACertificate" + extension;
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                        }
                        if (File.Exists(folderName + filename))
                        {
                            File.Delete(folderName + filename);
                        }
                        uploadKRAPinCertificate.SaveAs(folderName + filename);
                        Config.navExtender.AddLinkToRecord("Motor Underwriting", ApplicationNumber, filename, "");
                        //}
                        //else
                        //{
                        //    error = true;
                        //    message += message.Length > 0 ? "<br>" : "";
                        //    message += "The file extension of the KRA Certificate is not allowed,Kindly upload PDF files";
                        //}

                    }
                    else
                    {
                        error = true;
                        message += message.Length > 0 ? "<br>" : "";
                        message += "Kindly Upload the KRA Certificate before you proceed";
                    }
                }
                catch (Exception ex)
                {
                    error = true;
                    message += message.Length > 0 ? "<br>" : "";
                    message += "Kindly Upload the Birth/Death certificate before you proceed" + ex;

                }
                try
                {
                    if (uploadApplicationForm.HasFile)
                    {
                        string extension = System.IO.Path.GetExtension(uploadApplicationForm.FileName);
                        //if (extension == ".pdf" || extension == ".PDF" || extension == ".Pdf")
                        //{
                        string filename = ApplicationNumber + "_ApplicationProposalForm " + extension;
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                        }
                        if (File.Exists(folderName + filename))
                        {
                            File.Delete(folderName + filename);
                        }
                        uploadApplicationForm.SaveAs(folderName + filename);
                        Config.navExtender.AddLinkToRecord("Motor Underwriting", ApplicationNumber, filename, "");
                        //}
                        //else
                        //{
                        //    error = true;
                        //    message += message.Length > 0 ? "<br>" : "";
                        //    message += "The file extension of the Application/Proposal Form  is not allowed";
                        //}

                    }
                    else
                    {
                        error = true;
                        message += message.Length > 0 ? "<br>" : "";
                        message += "Kindly Upload the Application/Proposal Form  before you proceed";
                    }

                }
                catch (Exception ex)
                {
                    error = true;
                    message += message.Length > 0 ? "<br>" : "";
                    message += "Kindly Upload the  Application/Proposal Form before you proceed" + ex;
                }
                try
                {
                    if (otherdocuments.HasFile)
                    {
                        string extension = System.IO.Path.GetExtension(otherdocuments.FileName);
                        //if (extension == ".pdf" || extension == ".PDF" || extension == ".Pdf")
                        //{
                        string filename = ApplicationNumber + "_otherdocuments" + extension;
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                        }
                        if (File.Exists(folderName + filename))
                        {
                            File.Delete(folderName + filename);
                        }
                        otherdocuments.SaveAs(folderName + filename);
                        Config.navExtender.AddLinkToRecord("Motor Underwriting", ApplicationNumber, filename, "");
                    }

                }
                catch (Exception ex)
                {
                    error = true;
                    message += message.Length > 0 ? "<br>" : "";
                    message += "Kindly Upload the  otherdocuments before you proceed" + ex;
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
        protected void SubmitCommunicationDetails_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string ttelnumber1 = telnumber1.Text.Trim();
            if (ttelnumber1.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields),Telephone Number 1";
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
            if (ttxtemail.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), Email Address";
            }
            string ttxttwitter = txttwitter.Text.Trim();
            //if (ttxttwitter.Length < 1)
            //{
            //    flag = true;
            //    str = "Please Enter a Valid Value for Twitter Account";
            //}
            string tpostcodes = postcodes.SelectedValue.Trim();
            if (tpostcodes.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), postCode";
            }
            string ttxtaddress = txtaddress.Text.Trim();
            if (ttxtaddress.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), Address";
            }
            string ttxtlinkedin = txtlinkedin.Text.Trim();
            //if (ttxtlinkedin.Length < 1)
            //{
            //    flag = true;
            //    str = "Please Enter a Valid Value for LinkedIn Account";
            //}
            string ttxtgoogle = txtgoogle.Text.Trim();
            //if (ttxtgoogle.Length < 1)
            //{
            //    flag = true;
            //    str = "Please Enter a Valid Value for Google Account";
            //}
            string tlblcity = lblcity.SelectedValue.Trim();

            try
            {
                if (flag)
                {
                    communicationfeedbackDetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    string docNo = Request.QueryString["requisitionNo"].Trim();
                    var Applicant = Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnewClientApplicationsCommunicationDetails(docNo, ttelnumber1, ttelnumber2, tlblcity, txtfacebook, ttxtemail, ttxtaddress, tpostcodes, ttxttwitter, ttxtlinkedin, ttxtgoogle);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("MotorIndividualClientApplication.aspx?requisitionNo=" + docNo + "&step=3");

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


        protected void UpdateRiskDetails_Click(object sender, EventArgs e)
        {
            string tserviceContract = serviceContract.SelectedValue;
            if (tserviceContract != string.Empty)
            {
                NAV nav = Config.ReturnNav(); ;
                var ClientDetails = nav.MotorRisksDetails.Where(x => x.Contract_No == tserviceContract);
                List<DropDownList> policylist = new List<DropDownList>();
                foreach (var item in ClientDetails)
                {
                    DropDownList itemlist = new DropDownList();
                    itemlist.Code = item.Code;
                    itemlist.Name = item.Registration_No;
                    policylist.Add(itemlist);
                }
                riskNumber.DataSource = policylist;
                riskNumber.DataValueField = "Code";
                riskNumber.DataTextField = "Name";
                riskNumber.DataBind();
                riskNumber.Items.Insert(0, "--Select Risk Code--");
            }
            TransferSCPanel.Update();

        }
        protected void SubmitPolicyDetails_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            var tlblpolicyType = lblpolicyType.SelectedValue.Trim();
            if (tlblpolicyType.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), policy Type";
            }

            string product = lblproduct.SelectedValue.Trim();
            if (product.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), product";
            }


            int selectedIndex2 = agentDetail.SelectedIndex;
            string agentcode = "";
            string referralIdNumber = "";
            string referralName = txtrefferalname.Text.Trim();
            string referralMobileNumber = "";
            if (selectedIndex2 == 1)
            {
                selectedIndex2 = agentDetail.SelectedIndex;
                agentcode = salesgentcode.SelectedValue.Trim();
                if (agentcode.Length < 1)
                {
                    flag = true;
                    str = "Please fill all highlighted fields with *(Mandatory Fields),  agent code";
                }
            }
            if (selectedIndex2 == 2)
            {
                agentcode = salesgentcode.SelectedValue.Trim();
                if (agentcode.Length < 1)
                {
                    flag = true;
                    str = "Please fill all highlighted fields with *(Mandatory Fields),agent code";
                }
            }
            var tpaidamount = paidamount.Text.Trim();
            if (tpaidamount.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), amount Paid";
            }
            DateTime alldatepaid = DateTime.Now;
            var tdatepaid = datepaid.Text.Trim();
            if (tdatepaid.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), Date Paid";
            }
            else
            {
                alldatepaid = DateTime.ParseExact(tdatepaid, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            DateTime ttpolicystartDate = DateTime.Now;
            var tpolicystartDate = policystartDate.Text.Trim();
            if (tpolicystartDate.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), policy start date";
            }
            else
            {
                ttpolicystartDate = DateTime.ParseExact(tpolicystartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            referralMobileNumber = txtreferalmobilenumber.Text.Trim();
            //if (referralMobileNumber.Length < 1)
            //{
            //    flag = true;
            //    str = "Please fill all highlighted fields with *(Mandatory Fields)";
            //}

            int tmembertype = membertype.SelectedIndex;
            //if (selectedIndex3 < 0)
            //{
            //    flag = true;
            //    str = "Please Enter a Valid  Value for Member Type";
            //}
            int tinvoiceperiod = 0;
            //if (tinvoiceperiod < 1)
            //{
            //    flag = true;
            //    str = "Please fill all highlighted fields with *(Mandatory Fields)";
            //}
            var ttxtfinancier = txtfinancier.SelectedValue.Trim();
            //if (ttxtfinancier.Length < 1)
            //{
            //    flag = true;
            //    str = "Please fill all highlighted fields with *(Mandatory Fields)";
            //}
            var tserviceperiod = serviceperiod.Text.Trim();
            if (tserviceperiod.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), service period";
            }
            var ttxtinsurers = txtinsurers.SelectedValue.Trim();
            if (ttxtinsurers.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), insurer";
            }
            int tmodeofpayments = modeofpayments.SelectedIndex;
            if (tmodeofpayments < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), mode of payment";
            }
            int ttxtpaymentsoptions = txtpaymentsoptions.SelectedIndex;
            if (ttxtpaymentsoptions < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), Payment Option";
            }
            int tagentDetail = agentDetail.SelectedIndex;
            if (tagentDetail < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), Agent Details";
            }
            var tpaymentreferenceccode = paymentreferenceccode.Text.Trim();
            if (tpaymentreferenceccode.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), Payment Reference Code";
            }
            bool tnonrenewable = false;
            if (nonrenewable.Checked == true)
            {
                tnonrenewable = true;
            }
            else
            {
                tnonrenewable = false;
            }
            int tlblhasbinder = lblhasbinder.SelectedIndex;
            string ttbinderfeerate = binderfeerate.Text.Trim();
            decimal tbinderfeerate = 0;
            if (ttbinderfeerate.Length > 1)
            {
                tbinderfeerate = Convert.ToDecimal(ttbinderfeerate);
            }
            string ttcommissionRate = commissionRate.Text.Trim();
            decimal tcommissionRate = 0;
            if (ttcommissionRate.Length > 1)
            {
                tcommissionRate = Convert.ToDecimal(ttcommissionRate);
            }

            int tdepartment = lbldepartments.SelectedIndex;
            if (tdepartment < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), departments";
            }
            string dhb = "";

            if (ttcommissionRate.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), Commission Rate";
            }
            string Dbinderfeerate = binderfeerate.Text.Trim();
           
            if (Dbinderfeerate.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), Binder Fee Rate";
            }
            else
            {
                tbinderfeerate = Convert.ToDecimal(Dbinderfeerate);
                    
                    }
            string tbinderCodes = binderCodes.Text.Trim();
            if (tbinderCodes.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), Binder Codes";
            }
            string tpolicyNumber = policyNumber.Text.Trim();
            if (tpolicyNumber.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields), Policy Number";
            }
            string tpremiumsratings = premiumsratings.Text.Trim();
            decimal ttpremiumsratings = 0;
            if (tpremiumsratings.Length > 1)
            {
                ttpremiumsratings = Convert.ToDecimal(tpremiumsratings);
            }
            else
            {
                ttpremiumsratings = 0;
            }
            string ttxtremarks = "";
            if (tlblhasbinder == 1)
            {
                ttxtremarks = txtremarks.Text.Trim();
                if (ttxtremarks.Length < 1)
                {
                    flag = true;
                    str = "Please fill all highlighted fields with *(Mandatory Fields), Remarks";
                }
            }
            else
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
                var documentsmodeofpayments = modeofpayments.SelectedValue.Trim();
                string ApplicationNumber = Request.QueryString["requisitionNo"].Trim();
                ApplicationNumber = ApplicationNumber.Replace('/', '_');
                ApplicationNumber = ApplicationNumber.Replace(':', '_');
                string path1 = Config.FilesLocation() + "New Clients/";
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
                                if (!Directory.Exists(folderName))
                                {
                                    Directory.CreateDirectory(folderName);
                                }
                                if (File.Exists(folderName + filename))
                                {
                                    File.Delete(folderName + filename);
                                }
                                checkoffform.SaveAs(folderName + filename);
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
                else if (documentsmodeofpayments == "chequeform")
                {
                    try
                    {
                        if (checkoffform.HasFile)
                        {
                            string extension = System.IO.Path.GetExtension(checkoffform.FileName);
                            if (new Config().IsAllowedExtension(extension))
                            {
                                string filename = ApplicationNumber + "_Cheque" + extension;
                                if (!Directory.Exists(folderName))
                                {
                                    Directory.CreateDirectory(folderName);
                                }
                                if (File.Exists(folderName + filename))
                                {
                                    File.Delete(folderName + filename);
                                }
                                checkoffform.SaveAs(folderName + filename);
                            }
                            else
                            {
                                error = true;
                                message += message.Length > 0 ? "<br>" : "";
                                message += "The file extension of the Cheque is not allowed,Kindly upload Pdf files";
                            }

                        }
                        else
                        {
                            error = true;
                            message += message.Length > 0 ? "<br>" : "";
                            message += "Kindly Upload the Cheque before you proceed";

                        }
                    }
                    catch (Exception ex)
                    {
                        error = true;
                        message += message.Length > 0 ? "<br>" : "";
                        message += "Kindly Upload the Cheque before you proceed" + ex;
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
                                if (!Directory.Exists(folderName))
                                {
                                    Directory.CreateDirectory(folderName);
                                }
                                if (File.Exists(folderName + filename))
                                {
                                    File.Delete(folderName + filename);
                                }
                                checkoffform.SaveAs(folderName + filename);
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
                                if (!Directory.Exists(folderName))
                                {
                                    Directory.CreateDirectory(folderName);
                                }
                                if (File.Exists(folderName + filename))
                                {
                                    File.Delete(folderName + filename);
                                }
                                guarantorform.SaveAs(folderName + filename);
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
                                if (!Directory.Exists(folderName))
                                {
                                    Directory.CreateDirectory(folderName);
                                }
                                if (File.Exists(folderName + filename))
                                {
                                    File.Delete(folderName + filename);
                                }
                                checkoffform.SaveAs(folderName + filename);
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
                                if (!Directory.Exists(folderName))
                                {
                                    Directory.CreateDirectory(folderName);
                                }
                                if (File.Exists(folderName + filename))
                                {
                                    File.Delete(folderName + filename);
                                }
                                ktdastafform.SaveAs(folderName + filename);
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
                var Applicant = Session["empNo"].ToString();
                var status = new Config().ObjNav().FnIndividualMotorupdatePolicyDetails(docNo, tdepartment, tlblpolicyType, product, tmodeofpayments, ttxtfinancier, tinvoiceperiod, tmembertype, tagentDetail, agentcode, referralIdNumber, referralName, referralMobileNumber, tnonrenewable, tlblhasbinder, tbinderfeerate, tcommissionRate, Convert.ToDecimal(tpaidamount), alldatepaid, tpaymentreferenceccode, ttpolicystartDate, ttxtpaymentsoptions, ttxtremarks, tbinderCodes, tpolicyNumber, ttpremiumsratings);
                var res = status.Split('*');
                if (res[0] == "success")
                {
                    Response.Redirect("MotorIndividualClientApplication.aspx?requisitionNo=" + docNo + "&step=4");

                }
                else
                {
                    policyfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>The New Client Application Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";

                }
            }
            catch (Exception ex)
            {
                policyfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
            }
        }
        protected void SubmitApplication_Click(object sender, EventArgs e)
        {
            try
            {
                var step = Convert.ToInt32(Request.QueryString["step"].Trim());
                var Requisition = Request.QueryString["requisitionNo"].Trim();
                var status = new Config().ObjNav().SendIndividualClientApplicationApproval(Requisition);
                var res = status.Split('*');
                if (res[0] == "success")
                {
                    Response.Redirect("GeneralOpenClientApplications.aspx");
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
        protected void ValidateCoverType_Click(object sender, EventArgs e)
        {
            var tcovertype = covertype.SelectedValue.Trim();
            if (tcovertype == "COMPREHENSIVE COVERAGE")
            {
                basicpremium.Visible = false;
                valuesuminsured.ReadOnly = false;
            }

            else
            {
                basicpremium.Visible = true;
                valuesuminsured.ReadOnly = true;
                txtprotector.ReadOnly = true;
            }
        }
        protected void ValidateMake_Text(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav(); ;
            var tmake = make.SelectedValue.Trim();
            var carmodels = nav.VehicleModel.Where(x => x.Make_Code == tmake).ToList();
            List<DropDownList> VehicleModellist = new List<DropDownList>();
            foreach (var item in carmodels)
            {
                DropDownList code = new DropDownList();
                code.Code = item.Model_Code;
                code.Name = item.Description;
                VehicleModellist.Add(code);
            }
            model.DataSource = VehicleModellist;
            model.DataValueField = "Code";
            model.DataTextField = "Name";
            model.DataBind();
            model.Items.Insert(0, "--Select Model Code--");
            GetVehicleTypes_Onlick();
        }
        protected void Applications_SelectedIndexChanged(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string tcustomerCategory = customerCategory.SelectedValue.Trim();
            string tsubcustomerCategory = customerSubCategory.SelectedValue.Trim();
            var KTDARelated = nav.KTDARelatedItems.Where(x => x.Customer_Category == tcustomerCategory && x.Code == tsubcustomerCategory);
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
        protected void ValidateFormUpload(object sender, EventArgs e)
        {
            var tmodeofpayments = modeofpayments.SelectedValue.Trim();
            if (tmodeofpayments == "KTDA check Off")
            {
                generalformcheckoffs.Visible = true;
                generalformgurantor.Visible = false;
                generalformgreenleaf.Visible = false;
                generalformktdastaffdeduction.Visible = false;
                filecheques.Visible = false;
            }
            else if (tmodeofpayments == "Corporate Checkoff")
            {
                generalformcheckoffs.Visible = true;
                generalformgurantor.Visible = false;
                generalformgreenleaf.Visible = false;
                generalformktdastaffdeduction.Visible = false;
                filecheques.Visible = false;
            }
            else if (tmodeofpayments == "Guarantor Form")
            {
                generalformgurantor.Visible = true;
                generalformcheckoffs.Visible = false;
                generalformgreenleaf.Visible = false;
                generalformktdastaffdeduction.Visible = false;
                filecheques.Visible = false;
            }
            else if (tmodeofpayments == "Green Leaf")
            {
                generalformgreenleaf.Visible = true;
                generalformgurantor.Visible = false;
                generalformcheckoffs.Visible = false;
                generalformktdastaffdeduction.Visible = false;
                filecheques.Visible = false;
            }
            else if (tmodeofpayments == "KTDA Staff deduction")
            {
                generalformktdastaffdeduction.Visible = true;
                generalformgurantor.Visible = false;
                generalformcheckoffs.Visible = false;
                generalformgreenleaf.Visible = false;
                filecheques.Visible = false;
            }
            else if (tmodeofpayments == "Cheque")
            {
                filecheques.Visible = true;
                generalformktdastaffdeduction.Visible = false;
                generalformgurantor.Visible = false;
                generalformcheckoffs.Visible = false;
                generalformgreenleaf.Visible = false;
            }
            else
            {
                filecheques.Visible = false;
                generalformgurantor.Visible = false;
                generalformcheckoffs.Visible = false;
                generalformgreenleaf.Visible = false;
                generalformktdastaffdeduction.Visible = false;
            }
        }
        protected void ValidateYearofManufacture_Click(object sender, EventArgs e)
        {
            var tcovertype = covertype.SelectedValue.Trim();
            NAV nav = Config.ReturnNav();
            var thasBinder = "";
            string RequsitionNumber = Request.QueryString["requisitionNo"].Trim();
            var tbinder = nav.ClientApplicationQuery.Where(x => x.No == RequsitionNumber);
            foreach (var item in tbinder)
            {
                thasBinder = item.Has_Binder;
            }
            if (thasBinder == "Yes")
            {
                if (tcovertype == "COMPREHENSIVE COVERAGE")
                {
                    int CurrentYear = Convert.ToInt32(DateTime.Now.Year);
                    int tyearofmanufucture = Convert.ToInt32(yearofmanufucture.Text.Trim());
                    var UserAgeLimit = CurrentYear - tyearofmanufucture;
                    int AgeLimit = 0;
                    var Application = nav.ClientApplicationQuery.Where(x => x.No == RequsitionNumber).ToList();
                    foreach (var item in Application)
                    {
                        var BinderDetails = nav.Binders.Where(x => x.Product_Code == item.Product).ToList();

                        foreach (var binder in BinderDetails)
                        {
                            AgeLimit = Convert.ToInt32(binder.Age_Limit);
                        }
                    }
                    if (UserAgeLimit > AgeLimit)
                    {
                        divlatestevaluationreport.Visible = true;
                        txtyearofmanaufucturedetails.InnerText = "You are only allowed to insure Vehicles less than " + AgeLimit + "to proceed attach an evaluation report.";
                    }
                    else
                    {
                        divlatestevaluationreport.Visible = false;
                        txtyearofmanaufucturedetails.InnerText = "";
                    }
                }
                else
                {

                }
            }
        }
        protected void ValidateValueInsured_Click(object sender, EventArgs e)
        {
            var tcovertype = covertype.SelectedValue.Trim();
            NAV nav = Config.ReturnNav();
            var thasBinder = "";
            string RequsitionNumber = Request.QueryString["requisitionNo"].Trim();
            var tbinder = nav.ClientApplicationQuery.Where(x => x.No == RequsitionNumber);
            foreach (var item in tbinder)
            {
                thasBinder = item.Has_Binder;
            }
            if (thasBinder == "Yes")
            {
                if (tcovertype == "COMPREHENSIVE COVERAGE")
                {
                    decimal tvaluesuminsured = Convert.ToDecimal(valuesuminsured.Text.Trim());
                    decimal ValueInsured = 0;
                    var Application = nav.ClientApplicationQuery.Where(x => x.No == RequsitionNumber).ToList();
                    foreach (var item in Application)
                    {
                        var BinderDetails = nav.Binders.Where(x => x.Product_Code == item.Product).ToList();

                        foreach (var binder in BinderDetails)
                        {
                            ValueInsured = Convert.ToDecimal(binder.Minimum_Value);
                            txtrate.Text = Convert.ToString(binder.Premium_Rating);
                            txtprotector.Text = Convert.ToString((ValueInsured * Convert.ToDecimal(binder.Excess_Rate)) / 100);
                        }
                    }
                    if (tvaluesuminsured >= ValueInsured)
                    {
                        txtvalueinsureddetails.InnerText = "";
                    }
                    else
                    {
                        txtvalueinsureddetails.InnerText = "Minimum Sum Insured Should be " + ValueInsured;


                    }
                    string str = "";
                    bool flag = false;
                    string registrationNo = registrationnumber.Text.Trim();
                    if (registrationNo.Length < 1)
                    {
                        flag = true;
                        str = "Please fill all highlighted fields with *(Mandatory Fields), Registration Number";
                    }
                    string tmake = make.SelectedValue.Trim();
                    if (tmake.Length < 1)
                    {
                        flag = true;
                        str = "Please fill all highlighted fields with *(Mandatory Fields), Make";
                    }
                    string tmodel = model.SelectedValue.Trim();
                    if (tmodel.Length < 1)
                    {
                        flag = true;
                        str = "Please fill all highlighted fields with *(Mandatory Fields), Model";
                    }
                    string tvehicletype = vehicletype.SelectedValue.Trim();
                    if (tvehicletype.Length < 1)
                    {
                        flag = true;
                        str = "Please fill all highlighted fields with *(Mandatory Fields), Vehicle type";
                    }

                    if (tcovertype.Length < 1)
                    {
                        flag = true;
                        str = "Please fill all highlighted fields with *(Mandatory Fields), cover type";
                    }
                    string cc = this.cc.Text.Trim();
                    if (cc.Length < 1)
                    {
                        flag = true;
                        str = "Please fill all highlighted fields with *(Mandatory Fields), cc";
                    }
                    string chasisNo = chasisnumber.Text.Trim();
                    if (chasisNo.Length < 1)
                    {
                        flag = true;
                        str = "Please fill all highlighted fields with *(Mandatory Fields), Chasis Number";
                    }
                    string engineNo = enginenumber.Text.Trim();
                    if (engineNo.Length < 1)
                    {
                        flag = true;
                        str = "Please fill all highlighted fields with *(Mandatory Fields), Engine Number";
                    }
                    string yearofManufucture = yearofmanufucture.Text.Trim();
                    if (yearofManufucture.Length < 1)
                    {
                        flag = true;
                        str = "Please fill all highlighted fields with *(Mandatory Fields), Year of Manufacture";
                    }
                    string bodyType = txtdropdownlist.SelectedValue.Trim();
                    if (bodyType.Length < 1)
                    {
                        flag = true;
                        str = "Please fill all highlighted fields with *(Mandatory Fields), Body Type";
                    }
                    string s = policystratdate.Text.Trim();
                    if (s.Length < 1)
                    {
                        flag = true;
                        str = "Please fill all highlighted fields with *(Mandatory Fields), policy start Date";
                    }
                    DateTime dateTime = new DateTime();
                    DateTime exact = DateTime.ParseExact(s, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    string tduration = duration.Text.Trim();
                    if (tduration.Length < 1)
                    {
                        flag = true;
                        str = "Please fill all highlighted fields with *(Mandatory Fields), Duration";
                    }
                    string ttonnage = tonnage.Text.Trim();

                    decimal sumInsured = 0;
                    string tsumInsured = valuesuminsured.Text.Trim();
                    if (tsumInsured.Length > 1)
                    {
                        sumInsured = Convert.ToDecimal(valuesuminsured.Text.Trim());
                    }

                    string tcertificateNo = certificateNo.Text.Trim();
                    if (tcertificateNo.Length < 1)
                    {
                        flag = true;
                        str = "Please fill all highlighted fields with *(Mandatory Fields), certificate Number";
                    }
                    try
                    {
                        if (flag)
                        {
                            risksfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                        }
                        else
                        {
                            string docNo = Request.QueryString["requisitionNo"].Trim();
                            string empNo = Session["empNo"].ToString();

                            string AllCustomers = new Config().ObjNav().FnGetRisk(empNo, docNo, registrationNo, tmake, tmodel, tvehicletype, tcovertype, cc, chasisNo, engineNo, yearofManufucture, bodyType,
                            exact, tduration, Convert.ToDecimal(ttonnage), tcertificateNo, sumInsured);

                            String[] info = AllCustomers.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                            if (info != null)
                            {
                                foreach (var allInfo in info)
                                {
                                    String[] arr = allInfo.Split('*');
                                    txtrate.Text = arr[0];

                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {


                    txtvalueinsureddetails.InnerText = "";
                }
            }
            else
            {
                txtvalueinsureddetails.InnerText = "";

            }
        }
        protected void validateEndDate_Click(object sender, EventArgs e)
        {
            string RequsitionNumber = Request.QueryString["requisitionNo"].Trim();
            var PolicyStartDate = policystratdate.Text.Trim();
            DateTime tPolicyStartDate = DateTime.ParseExact(PolicyStartDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            int tduration = (Convert.ToInt32(duration.Text.Trim()) - 1);
            DateTime tPolicyEndDate = tPolicyStartDate.AddDays(tduration);
            policiesendDate.Text = Convert.ToDateTime(tPolicyEndDate).ToString("dd-MM-yyyy");

        }
        protected void ValidateRates_Click(object sender, EventArgs e)
        {
            string RequsitionNumber = Request.QueryString["requisitionNo"].Trim();
            NAV nav = Config.ReturnNav(); ;
            var Application = nav.ClientApplicationQuery.Where(x => x.No == RequsitionNumber).ToList();
            foreach (var item in Application)
            {
                if (item.Has_Binder == "Yes")
                {
                    var BinderDetails = nav.Binders.Where(x => x.Product_Code == item.Product).ToList();
                    foreach (var binder in BinderDetails)
                    {
                        txtrate.Text = Convert.ToString(binder.Premium_Rating);
                    }
                }
                else
                {
                    txtrate.Text = Convert.ToString(item.Premium_Rating);
                }

                policystratdate.Text = Convert.ToDateTime(item.Policy_start_date).ToString("dd-MM-yyyy");
            }
        }

        protected void GetBasicPremum_Click(object sender, EventArgs e)
        {
            var tcovertype = covertype.SelectedValue.Trim();
            if (tcovertype != "COMPREHENSIVE COVERAGE")
            {
                string RequsitionNumber = Request.QueryString["requisitionNo"].Trim();
                decimal tTonnage = Convert.ToDecimal(tonnage.Text.Trim());
                decimal status = new Config().ObjNav().FnGetBasicPremium(RequsitionNumber, tcovertype, tTonnage);
                if (status > 0)
                {
                    txtbasicpremiums.Text = Convert.ToString(status);
                }
                else
                {
                    risksfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>The Basic Premium Amount could not be found.Kindly try Again" + "</div>";

                }
            }
        }
        protected void ValuedClicked_Changed(object sender, EventArgs e)
        {
            if (bolvalued.Checked == true)
            {
                divlatestevaluationreport.Visible = true;
            }
            else
            {
                divlatestevaluationreport.Visible = false;
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
            lblcity.DataSource = allpostcodes;
            lblcity.DataTextField = "City";
            lblcity.DataValueField = "City";
            lblcity.DataBind();
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
            Response.Redirect("MotorIndividualClientApplication.aspx?requisitionNo=" + str + "&step=" + num2);
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
            Response.Redirect("MotorIndividualClientApplication.aspx?requisitionNo=" + str + "&step=" + num2);
        }

        protected void GetPolicyEndDates_Click(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            DateTime myPolicystartDate = new DateTime();
            string tpolicystartDate = policystartDate.Text.Trim();
            try
            {
                myPolicystartDate = DateTime.ParseExact(tpolicystartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string tserviceperiod = serviceperiod.Text.Trim();
            var status = new Config().ObjNav().FnGetPolicyEndDate(myPolicystartDate, tserviceperiod);
            policyenddate.Text = Convert.ToDateTime(status).ToString("dd/MM/yyyy");
            DateTime myPolicyenddatee = new DateTime();
            string tpolicyenddate = policyenddate.Text.Trim();
            try
            {
                myPolicyenddatee = DateTime.ParseExact(tpolicyenddate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            var statusCalender = new Config().ObjNav().FnGetPolicyCalenderDays(myPolicystartDate, myPolicyenddatee);
            txtcalenderDays.Text = Convert.ToString(statusCalender);
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
                code.Name = item.Description + "- " + item.Policy_Type;
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
            string tproduct = lblproduct.SelectedValue.Trim();
            var productDetails = nav.Items.Where(x => x.Policy_Type == tlblproduct && x.Insurance_Item_type == "Insurance");
            foreach (var item in productDetails)
            {
                //insurer.Text = item.Insurer;
                serviceperiod.Text = item.Service_Period;


                var BinderDetails = nav.Binders.Where(x => x.Product_Code == tproduct).ToList();
                foreach (var binder in BinderDetails)
                {
                    binderCodes.Text = binder.Code;
                    int PolicyNumberUser = Convert.ToInt32(binder.Last_No_Used) + 1;
                    policyNumber.Text = binder.Code + "/" + "00" + PolicyNumberUser;
                    premiumsratings.Text = Convert.ToString(binder.Premium_Rating);
                    binderfeerate.Text = Convert.ToString(binder.Binder_Fee_Rate);
                    commissionRate.Text = Convert.ToString(binder.Commission_Rate);
                }
                if (item.Has_Binder == "Yes")
                {
                    lblhasbinder.SelectedIndex = 0;
                }
                else
                {
                    lblhasbinder.SelectedIndex = 1;
                }
               // GetBinderRates_Onlick();
            }
        }
        protected void GetVehicleTypes_Onlick()
        {

            var requisitionNo = Request.QueryString["requisitionNo"].Trim();
            NAV nav = Config.ReturnNav();
            var productDetails = nav.ClientApplicationQuery.Where(x => x.No == requisitionNo);
            foreach (var item in productDetails)
            {
                var tvehicletype = nav.DisplaySheetItems.Where(r => r.Policy_Type == item.Policy_Type).ToList();
                List<DropDownList> vehicletypelist = new List<DropDownList>();
                foreach (var vehicleitem in tvehicletype)
                {
                    DropDownList code = new DropDownList();
                    code.Code = vehicleitem.Code;
                    code.Name = vehicleitem.Item_Description;
                    vehicletypelist.Add(code);
                }
                vehicletype.DataSource = vehicletypelist;
                vehicletype.DataValueField = "Code";
                vehicletype.DataTextField = "Name";
                vehicletype.DataBind();
                vehicletype.Items.Insert(0, "--Select Vehicle Code--");
            }
        }

        protected void GetTotalValueSumInsured_Onlick()
        {
            NAV nav = Config.ReturnNav();
            var requisitionNo = Request.QueryString["requisitionNo"].Trim();
            var productDetails = nav.ClientApplicationQuery.Where(x => x.No == requisitionNo);
            foreach (var item in productDetails)
            {
                totalsvaluesuminsured.Text = Convert.ToString(item.Total_Value_Sum_Insured);
                totalpremium.Text = Convert.ToString(item.Total_Premiums);
                totalpremiumspayables.Text = Convert.ToString(item.Total_Premiums_Payable);
            }
        }
        protected void GetBinderRates_Onlick()
        {
            NAV nav = Config.ReturnNav();
            string tlblproduct = lblproduct.SelectedValue.Trim();
            var productDetails = nav.ClientApplicationQuery.Where(x => x.Product == tlblproduct).ToList();
            foreach (var item in productDetails)
            {
                serviceperiod.Text = item.Service_Period;
                binderfeerate.Text = Convert.ToString(item.Binder_Fee_Rate);
                commissionRate.Text = Convert.ToString(item.Commission_Rate);
            }
        }
        //string tpoduct = lblproduct.SelectedValue.Trim();
        //var MedicalSchedule = nav.MedicalSchedule.Where(x => x.Product_Code == tpoduct && x.Premium_TB_Options == "ADULT").ToList();
        //List<DropDownList> MedicalSchedulelist = new List<DropDownList>();
        //foreach (var item in MedicalSchedule)
        //{
        //    DropDownList code = new DropDownList();
        //    code.Code = item.Benefit_Limit;
        //    code.Name = item.Benefit_Limit;
        //    MedicalSchedulelist.Add(code);
        //}
        //dailyhealthbenefits.DataSource = MedicalSchedulelist;
        //dailyhealthbenefits.DataValueField = "Code";
        //dailyhealthbenefits.DataTextField = "Name";
        //dailyhealthbenefits.DataBind();
        //dailyhealthbenefits.Items.Insert(0, "--Select DHB--");

        protected void GetVendorProducts_Onlick(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string tlblpolicyType = lblpolicyType.SelectedValue.Trim();
            string ttxtinsurers = txtinsurers.SelectedValue.Trim();
            var productDetails = nav.Items.Where(x => x.Insurer == ttxtinsurers && x.Insurance_Item_type == "Insurance" && x.Policy_Type == tlblpolicyType);
            List<DropDownList> tProductsList = new List<DropDownList>();
            foreach (var item in productDetails)
            {
                DropDownList code = new DropDownList();
                code.Code = item.No;
                code.Name = item.Description + "- " + item.Policy_Type;
                tProductsList.Add(code);
            }
            lblproduct.DataSource = tProductsList;
            lblproduct.DataTextField = "Name";
            lblproduct.DataValueField = "Code";
            lblproduct.DataBind();
            lblproduct.Items.Insert(0, "--Select Product--");
            //string tpoduct = lblproduct.SelectedValue.Trim();
            //var MedicalSchedule = nav.MedicalSchedule.Where(x => x.Product_Code == tpoduct && x.Premium_TB_Options == "ADULT").ToList();
            //List<DropDownList> MedicalSchedulelist = new List<DropDownList>();
            //foreach (var item in MedicalSchedule)
            //{
            //    DropDownList code = new DropDownList();
            //    code.Code = item.Benefit_Limit;
            //    code.Name = item.Benefit_Limit;
            //    MedicalSchedulelist.Add(code);
            //}
            //dailyhealthbenefits.DataSource = MedicalSchedulelist;
            //dailyhealthbenefits.DataValueField = "Code";
            //dailyhealthbenefits.DataTextField = "Name";
            //dailyhealthbenefits.DataBind();
            //dailyhealthbenefits.Items.Insert(0, "--Select DHB--");
        }
        protected void AgentDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tagentDetail = agentDetail.SelectedIndex;
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
            int tagentDetail = agentDetail.SelectedIndex;
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

        protected void SubmitTransfer_Click(object sender, EventArgs e)
        {
            string tserviceContract = serviceContract.SelectedValue.Trim();
            string triskNumber = riskNumber.SelectedValue.Trim();
            var requisitionNo = Request.QueryString["requisitionNo"].Trim();
            var status = new Config().ObjNav().FnTransferRiskDetails(requisitionNo, tserviceContract, triskNumber);
            var res = status.Split('*');
            if (res[0] == "success")
            {
                risksfeedbackdetails.InnerHtml = "<div class='alert alert-success'>The Risk Details has been successfully transfered" + "</div>";
            }
            else
            {
                risksfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + res[1] + "</div>";

            }
        }
        protected void ValidateHasBinderDetails_Click(object sender, EventArgs e)
        {
            string tlblhasbinder = lblhasbinder.SelectedValue.Trim();
            if (tlblhasbinder == "Yes")
            {
                dvremarks.Visible = false;
                binderfeerate.ReadOnly = true;
                commissionRate.ReadOnly = true;
            }
            else
            {
                dvremarks.Visible = true;
                policyNumber.ReadOnly = false;
                binderCodes.ReadOnly = false;
                binderfeerate.ReadOnly = true;
                commissionRate.ReadOnly = true;
                policyNumber.Text = "";
                binderCodes.Text = "";
                premiumsratings.Text = "";

            }
        }
        protected void HasGrowerNumber_Selected(object sender, EventArgs e)
        {
            bool thasgrowerNo = hasgrowerNo.Checked;
            if (thasgrowerNo == true)
            {
                dvgrowerdetails.Visible = true;
            }
            else
            {
                dvgrowerdetails.Visible = false;
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
        protected void DeleteRiskDetails_Click(object sender, EventArgs e)
        {
            var tRisktoRemove = RisktoRemove.Text.Trim();
            string docNo = Request.QueryString["requisitionNo"].Trim();
            var Applicant = Session["empNo"].ToString();
            var status = new Config().ObjNav().DeleteClientRiskDetails(docNo, tRisktoRemove);
            var res = status.Split('*');
            if (res[0] == "success")
            {
                GetTotalValueSumInsured_Onlick();
                risksfeedbackdetails.InnerHtml = "<div class='alert alert-success'>" + res[1] + "</div>";

            }
            else
            {
                risksfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + res[1] + "</div>";

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
                var tgrowerapplicanttype = growerapplicanttype.SelectedIndex;
                var FactoryCode = new Config().ObjNav().FnGetFactoryCode(tgrowerNumber, tgrowerapplicanttype);
                if (FactoryCode == "")
                {
                    growerdetails.InnerText = "The Grower Number Provided is not valid";
                }
                else
                {
                    txtFactoryCode.Text = FactoryCode;
                    growerdetails.Visible = false;
                }
                var FactoryName = new Config().ObjNav().FnGetFactoryName(tgrowerNumber, tgrowerapplicanttype);
                if (FactoryName == "")
                {
                    growerdetails.InnerText = "The Grower Number Provided is not valid";
                }
                else
                {
                    ttxtFactoryName.Text = FactoryName;
                    growerdetails.Visible = false;
                }


            }
        }

        protected void ValidateIDNumberDetail_Click(object sender, EventArgs e)
        {
            var ttxtIdNumber = txtIdNumber.Text.Trim();
            if (ttxtIdNumber.Length > 8)
            {
                idNumberPassport.InnerText = "Please Enter the Correct ID No/Passport Value,It must be a Whole number between 6 and 8";
            }
            if (ttxtIdNumber.Length < 6)
            {
                idNumberPassport.InnerText = "Please Enter the Correct ID No/Passport Value,It must be a Whole number between 6 and 8";

            }
            else
            {
                var status = new Config().ObjNav().FnCheckifIdentityNoExist(ttxtIdNumber);
                var res = status.Split('*');
                if (res[0] == "danger")
                {
                    idNumberPassport.InnerText = "The ID No/Passport Provided Already Exist.Kindly use a different Unique ID No/Passport";
                }
                else
                {
                    idNumberPassport.InnerText = "";
                }
            }
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