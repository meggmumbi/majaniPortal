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
    public partial class AgricultureIndividualClientApplication : System.Web.UI.Page
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
                   

              

                    var Conditions = Config.ReturnNav().PreExistingConditions.ToList();
                    List<DropDownList> Conditionslist = new List<DropDownList>();
                    foreach (var item in Conditions)
                    {
                        DropDownList code = new DropDownList();
                        code.Code = item.code;
                        code.Name = item.Description;
                        Conditionslist.Add(code);
                    }
                  

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

                    var livestockDrop = nav.DisplaySheetItems.Where(r=>r.Policy_Type== "AGRICULTURAL INSURANCE");
                    livestock.DataSource = livestockDrop;
                    livestock.DataTextField = "Item_Description";
                    livestock.DataValueField = "Code";
                    livestock.DataBind();
                    livestock.Items.Insert(0, new ListItem("--select--", ""));

                    var breedDrop = nav.breeds.ToList();
                    Animalbreed.DataSource = breedDrop;
                    Animalbreed.DataTextField = "Description";
                    Animalbreed.DataValueField = "Code";
                    Animalbreed.DataBind();
                    Animalbreed.Items.Insert(0, new ListItem("--select--", ""));

                    List<string> tgrowerapplicanttype = new List<string>();
                    tgrowerapplicanttype.Add("-----Select Grower Type of Applicants-------");
                    tgrowerapplicanttype.Add("KTDA Farmer");
                    tgrowerapplicanttype.Add("Farmer Dependent");
                    growerapplicanttype.DataSource = tgrowerapplicanttype;
                    growerapplicanttype.DataBind();


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

                    

                    var tpolicyTypequery = nav.Items.Where(x => x.Policy_Type == "AGRICULTURAL INSURANCE" && x.Insurance_Item_type == "Insurance");
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
                           
                            lblproduct.Text = item.Product;
                            lblmaritalstatus.Text = item.Marital_Status;
                            lbltitle.Text = item.Title;
                            insurer.Text = item.Insurer;
                           
                            modeofpayments.Text = item.Mode_of_Payment;
                            //agentDetail.Text = item.Agent_Detail;
                          
                            lblsalesgentcode.Text = item.Agent_Salespersons_Code;

                            totalPremiums.Text = Convert.ToString(item.Total_Premiums);
                            evalAmount.Text = Convert.ToString(item.Evaluation_Amount_Total);
                            premPayable.Text= Convert.ToString(item.Total_Premiums_Payable);



                        }
                    }


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

                   
                }
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

            var tResidentialLocation = ResidentialLocat.Text.Trim();           
            if (tResidentialLocation.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            var tOfficeLocation = OfficeLocat.Text.Trim();
            if (tOfficeLocation.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            var tMpesaNo = mpesaNo.Text.Trim();
            if (tMpesaNo.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            int twealthSource = Convert.ToInt32(wealthSource.SelectedValue.Trim());
            if (twealthSource == 0)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            int tincomeSource = Convert.ToInt32(sourceIncome.SelectedValue.Trim());
            if (tincomeSource == 0)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
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
                    var status = new Config().ObjNav().FnewAgricultureOnboadingRequests(requisitionNo, empNo, cust_category, tcustomersubcategory, selectedIndex2, id_passport, pinNo, selectedIndex5, firstName, middleName, lastname, 
                        countryOfResidence, exact, selectedIndex3, countyCode, selectedIndex4, hudumaNo, applicanttype, occupation,tResidentialLocation,tOfficeLocation,twealthSource,tincomeSource,tMpesaNo);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("AgricultureIndividualClientApplication.aspx?requisitionNo=" + res[2] +  "&step=2");

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
                    var Applicant = Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnewClientApplicationsCommunicationDetails(docNo, ttelnumber1, ttelnumber2, txtcity, txtfacebook, ttxtemail, ttxtaddress, txtpostcode, ttxttwitter, ttxtlinkedin, ttxtgoogle);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("AgricultureIndividualClientApplication.aspx?requisitionNo=" + docNo + "&step=3");

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
            Response.Redirect("AgricultureIndividualClientApplication.aspx?requisitionNo=" + str + "&step=" + num2);
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
        protected void Applications_SelectedIndexChanged(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string tcustomerCategory = customerCategory.SelectedValue.Trim();
            string tsubcustomerCategory = customerSubCategory.SelectedValue.Trim();
            if (tsubcustomerCategory == "FACTORY STAFF")
            {
                var KTDARelated = nav.KTDARelatedItems.Where(x => x.Customer_Category == tcustomerCategory && x.Code == tsubcustomerCategory && x.Department == "general");
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

                var KTDARelated = nav.KTDARelatedItems.Where(x => x.Customer_Category == tcustomerCategory && x.Code == tsubcustomerCategory && x.Department == "general");
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
                datevalidator.InnerText = "The age cannot be less than 18 years";
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
        protected void GetProducts_Onlick(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
           
            var tpolicyTypequery = nav.Items.Where(x => x.Policy_Type == "AGRICULTURAL INSURANCE" && x.Insurance_Item_type == "Insurance");
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
            
            var productDetails = nav.Items.Where(x => x.Policy_Type == "AGRICULTURAL INSURANCE" && x.Insurance_Item_type == "Insurance" && x.No== lblproduct.SelectedValue);
            foreach (var item in productDetails)
            {
                insurer.Text = item.Insurer;               
                serviceperiod.Text = item.Service_Period;
                //txtpolicyno.Text = item.Last_Policy_No_Used;
            }
   
        }
        protected void AgentDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tagentDetail = agentDetail.SelectedIndex;
          
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
                var Salesperson = nav.Salespeople_Purchasers.ToList();
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
                var Salesperson = nav.Salespeople_Purchasers.ToList();
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
        

        protected void applicationTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            if (applicationTypes.SelectedValue == "FACTORY")
            {
                var KTDARelatedItems = nav.KTDARelatedItems.Where(r => r.Item_Code == applicationTypes.SelectedValue);
            foreach(var item in KTDARelatedItems)
            {
                krapinNumber.Text = item.KRA_PIN;
            }
            }
            else
            {
                krapinNumber.ReadOnly = false;
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
            var FactoryName = new Config().ObjNav().FnGetFactoryName(tgrowerNumber, tgrowerapplicanttype);
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

        protected void binderCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            premRating.Visible = true;
        }
        protected void SubmitPolicyDetails_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            decimal tpremiumrating=0;
            string tgrowerNumber = "";

            int hasbinder = Convert.ToInt32(hasBinder.SelectedValue);
            if (hasbinder == 1)
            {
                 tpremiumrating = Convert.ToDecimal(premiumrating.Text.Trim());
            }

            string product = lblproduct.SelectedValue.Trim();
            if (product.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }

            int tpymentOpt = Convert.ToInt32(paymentOptions.SelectedValue.Trim());
            if (tpymentOpt == 0)
            {
                flag = true;
                str = "Please select payment option";
            }
          
          
            DateTime tPolicyStartDate = Convert.ToDateTime(policyStartDate.Text.Trim());
            int tAgentDetail = agentDetail.SelectedIndex;
            string agentcode = "";
          
            if (tAgentDetail == 1)
            {
                tAgentDetail = agentDetail.SelectedIndex;
                agentcode = lblsalesgentcode.SelectedValue.Trim();
                if (agentcode.Length < 1)
                {
                    flag = true;
                    str = "Please fill all highlighted fields with *(Mandatory Fields)";
                }
            }
            if (tAgentDetail == 2)
            {
                agentcode = lblsalesgentcode.SelectedValue.Trim();
                if (agentcode.Length < 1)
                {
                    flag = true;
                    str = "Please fill all highlighted fields with *(Mandatory Fields)";
                }
            }
            
            
            if (serviceperiod.Text.Trim().Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }




            string tinsurer = insurer.Text.Trim();
            if (tinsurer.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tpaymentRefCode = paymentRefCode.Text.Trim();
            
            if (tpaymentRefCode.Length < 1)
            {
                flag = true;
                str = "Please enter your payment reference Code";
            }
            string ttxtfinancier = txtfinancier.SelectedValue.Trim();
         
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
                    if (tgrowerapplicanttype < 1)
                    {
                        flag = true;
                        str = "Please fill all highlighted fields with *(Mandatory Fields)";
                    }
                     tgrowerNumber = growerNumber.Text.Trim();
                    if (tgrowerNumber.Length < 1)
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
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            
            int tmodepayment = modeofpayments.SelectedIndex;
            if (tmodepayment < 1)
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
                    string ApplicationNumber = Request.QueryString["requisitionNo"].Trim();
                    ApplicationNumber = ApplicationNumber.Replace('/', '_');
                    ApplicationNumber = ApplicationNumber.Replace(':', '_');
                    string path1 = Config.FilesLocation() + "Agriculture Underwriting/";
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



                    string docNo = this.Request.QueryString["requisitionNo"].Trim();                    
                    var Applicant = Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnIndividualupdateAgriculturePolicyDetails(docNo, ttxtfinancier, product, tmodepayment, tAgentDetail, tpaymentRefCode, agentcode,
                         tPolicyStartDate, tpymentOpt, tpremiumrating, tinsurer, hasbinder, tgrowerapplicanttype, tgrowerNumber, tfactoryCode, tfactoryName, thasgrowerNo);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("AgricultureIndividualClientApplication.aspx?requisitionNo=" + docNo +  "&step=4" + "&product=" +product);

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

        protected void hasBinder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hasBinder.SelectedValue == "1")
            {
                premRating.Visible = true;
            }
            else
            {
                premRating.Visible = false;
            }
        }

        protected void modeofpayments_SelectedIndexChanged(object sender, EventArgs e)
        {
  

            var tmodeofpayments = modeofpayments.SelectedValue.Trim();
            if (tmodeofpayments == "KTDA check Off")
            {
                generalformcheckoffs.Visible = true;
               
            }
            else if (tmodeofpayments == "KTDA Bonus")
            {
                generalformcheckoffs.Visible = true;
                
            }
            
    }

        protected void saveDetails_Click(object sender, EventArgs e)
        {
            try
            {
                bool error = false;
                string msg = "";


                string tlivestock = livestock.SelectedValue;
                string tNameOfAnimal = NameOfAnimal.Text.Trim();
                string tearTag = earTag.Text.Trim();
                string tAnimalbreed = Animalbreed.SelectedValue.Trim();
                int tlivestocksex = Convert.ToInt32(livestocksex.SelectedValue.Trim());
                Decimal tAge = Convert.ToDecimal(age.Text);
                string tmilkProd = milkProd.Text.Trim();
                decimal tvalueInsured = Convert.ToDecimal(valueInsured.Text);
                string docNo = Request.QueryString["requisitionNo"];
                if (tNameOfAnimal.Length < 1)
                {
                    error = true;
                    msg = "Please enter Name of livestock";
                }
                if (tlivestock.Length < 1)
                {
                    error = true;
                    msg = "Please select livestock";
                }
                if (tearTag.Length < 1)
                {
                    error = true;
                    msg = "Please enter ear tag";
                }
                if (tAnimalbreed.Length < 1)
                {
                    error = true;
                    msg = "Please select breed";
                }
                if (tAge == 0)
                {
                    error = true;
                    msg = "Please enter age";
                }
                if (tmilkProd.Length < 1)
                {
                    error = true;
                    msg = "Please enter milk production per day";
                }
                if (tvalueInsured < 1)
                {
                    error = true;
                    msg = "Please enter value/sum insured";
                }
                if (error)
                {
                    physicalLocations.InnerHtml = "<div class='alert alert-danger'>" + msg + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    string tproduct = Request.QueryString["product"];
                    String status = new Config().ObjNav().FnInsterAgricultureDetails(docNo, tNameOfAnimal, tlivestock, tearTag, tAnimalbreed, tlivestocksex, tAge, tmilkProd, tvalueInsured, tproduct);
                    String[] info = status.Split('*');
                    if (info[0] == "success")
                    {
                        var nav = Config.ReturnNav();
                        var Application = nav.ClientApplicationQuery.Where(x => x.No == docNo).ToList();
                        foreach (var item in Application)
                        {
                            totalPremiums.Text = Convert.ToString(item.Total_Premiums);
                            evalAmount.Text = Convert.ToString(item.Evaluation_Amount_Total);
                            premPayable.Text = Convert.ToString(item.Total_Premiums_Payable);
                        }

                        livestock.SelectedValue = "";
                        NameOfAnimal.Text = "";
                        earTag.Text = "";
                        Animalbreed.SelectedValue = "";
                        livestocksex.SelectedValue = "";
                        age.Text = "";
                        milkProd.Text = "";
                        valueInsured.Text = "";
                        physicalLocations.InnerHtml = "<div class='alert alert-success'>" + info[1] + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    }
                    else
                    {
                        physicalLocations.InnerHtml = "<div class='alert alert-danger'>" + info[1] + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    }
                }
            }
            catch (Exception m)
            {
                physicalLocations.InnerHtml = "<div class='alert alert-danger'>" + m.Message + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
            }
        }


        protected void backtostep3_Click(object sender, EventArgs e)
        {
            string docNo = Request.QueryString["requisitionNo"];
            string tproduct = Request.QueryString["product"];
            Response.Redirect("AgricultureIndividualClientApplication.aspx?requisitionNo=" + docNo + "&step=3" + "&product=" + tproduct);
        }

        protected void nextBtn_Click(object sender, EventArgs e)
        {
            
            string docNo = Request.QueryString["requisitionNo"];
            string tproduct = Request.QueryString["product"];
            Response.Redirect("RiskNoteProforma.aspx?requisitionNo=" + docNo  + "&product=" + tproduct);
        }

        protected void hasgrowerNo_CheckedChanged(object sender, EventArgs e)
        {
            if (hasgrowerNo.Checked)
            {
                growerId.Visible = true;
            }
            else
            {
                growerId.Visible = false;

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
                //string GrowerNumber = Request.QueryString["GrowerNumber"].Trim();
                ApplicationNumber = ApplicationNumber.Replace('/', '_');
                ApplicationNumber = ApplicationNumber.Replace(':', '_');
              
                string rQuisitionNo = Request.QueryString["requisitionNo"];
                string path1 = Config.FilesLocation() + "Agriculture Underwriting/";
                string str1 = Convert.ToString(ApplicationNumber);

                var nav = Config.ReturnNav();
                var applications = nav.ClientApplicationQuery.Where(r => r.No == rQuisitionNo).ToList();
                foreach (var principalname in applications)
                {
                    tFirstName = principalname.First_Name;
                    tlastName = principalname.Last_Name;
                }
                tprincipleName = tFirstName + "_" + tlastName;


                string folderName = path1 + str1 + "_" + tprincipleName + "/";
                bool error = false;
                string message = "";
                try
                {

                    if (filetoupload.HasFile)
                    {
                        string extension = System.IO.Path.GetExtension(filetoupload.FileName);
                        if (new Config().IsAllowedExtension(extension))
                        {
                            string filename = "ProposalForm" + extension;
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
                            Config.navExtender.AddLinkToRecord("Agriculture Ind Underwriting", rQuisitionNo, fullfileName, "");                            
                            //var Requisition = Request.QueryString["requisitionNo"].Trim();
                            //var status = new Config().ObjNav().FnDocumentsValidations(Requisition, scannedcopy, depedantphoto);

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
                            string filename =  "OtherDocument " + extension;
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
                            Config.navExtender.AddLinkToRecord("Agriculture Ind Underwriting", rQuisitionNo, fullfileName, "");
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
                        string extension = System.IO.Path.GetExtension(guardianshipletter.FileName);
                        if (new Config().IsAllowedExtension(extension))
                        {
                            string filename = "VetEvaluationReport " + extension;
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
                            Config.navExtender.AddLinkToRecord("Agriculture Ind Underwriting", rQuisitionNo, fullfileName, "");
                        }
                        else
                        {
                            error = true;
                            message += message.Length > 0 ? "<br>" : "";
                            message += "The file extension of the Vet Evaluation Report is not allowed";
                        }                   
                    

                    }
                
                }
                catch (Exception ex)
                {
                    error = true;
                    message += message.Length > 0 ? "<br>" : "";
                    message += "Kindly Upload the Vet Evaluation Report before you proceed" + ex;

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
        protected void SubmitApplication_Click(object sender, EventArgs e)
        {
            try
            {
                NAV nav = Config.ReturnNav();
                var Requisition = Request.QueryString["requisitionNo"].Trim();
                var Conditions = Config.ReturnNav().ClientApplicationQuery.Where(x => x.No == Requisition).ToList();
               
                        var step = Convert.ToInt32(Request.QueryString["step"].Trim());
                        var status = new Config().ObjNav().SendIndividualAgricultureApplicationApproval(Requisition);
                        var res = status.Split('*');
                        if (res[0] == "success")
                        {
                            Response.Redirect("AgricultureOpenApplications.aspx");
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

    }
}