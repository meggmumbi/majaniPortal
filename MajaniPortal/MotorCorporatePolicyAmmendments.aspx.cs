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
    public partial class MotorCorporatePolicyAmmendments : System.Web.UI.Page
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
                tmodeofpayments.Add("-----Select Mode of Payments-------");
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
                txtmodeofpayments.DataSource = tmodeofpayments;
                txtmodeofpayments.DataBind();

                List<string> tagentDetail = new List<string>();
                tagentDetail.Add("-----Select Agent Detail-------");
                tagentDetail.Add("Direct Business");
                tagentDetail.Add("Agent Business");
                tagentDetail.Add("Refferal Business");
                agentDetail.DataSource = tagentDetail;
                agentDetail.DataBind();

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
                var ApplicationNumber = Convert.ToString(Request.QueryString["ContractNo"]);
                if (ApplicationNumber != null)
                {
                    var Application = nav.ServiceContracts.Where(x => x.Contract_No == ApplicationNumber).ToList();
                    foreach (var item in Application)
                    {
                        var CustomerInfor = nav.Customer.Where(x => x.No == item.Customer_No).ToList();
                        foreach (var itemCustomer in CustomerInfor)
                        {
                            customerCategory.Text = item.Customer_Category;
                            subcustomerCategory.Text = item.Customer_Sub_Category;
                            applicanttype.Text = item.Applicant_Type;
                            growerNumber.Text = item.Grower_No_Client_ID;
                            txtFactoryCode.Text = item.Factory_Code_Branch_Code;
                            ttxtFactoryName.Text = item.Factory_Name_Branch_Name;
                            growerNumber.Text = item.Grower_No_Client_ID;
                            growerapplicanttype.Text = itemCustomer.Grower_Type_of_Applicant;
                            telnumber1.Text = item.Tel_Mobile_No;
                            telnumber2.Text = itemCustomer.Tel_Mobile_No_2;
                            txtaddress.Text = item.Address;
                            postcodes.Text = item.Post_Code;
                            lblcity.Text = item.City;
                            countryresidence.Text = itemCustomer.Nationality;
                            lblcounties.Text = itemCustomer.County;
                            certificateofincpoperation.Text = itemCustomer.Cert_of_Incorporation_No;
                            krapinnumber.Text = item.KRA_Pin_No;
                            tnatureofbusinesses.Text = item.Nature_of_Business_Sector;
                            officelocation.Text = itemCustomer.Office_Location;
                            txtbuilding.Text = itemCustomer.Building;
                            txtresidential.Text = itemCustomer.Residential_Location;
                            txtcompanyname.Text = itemCustomer.Corporate_Company_Name;
                            txtgoogle.Text = itemCustomer.Google;
                            txttwitter.Text = itemCustomer.Twitter;
                            txtfcebook.Text = itemCustomer.Facebook;
                            txtlinkedin.Text = itemCustomer.LinkedIn;
                            lbldepartments.Text = item.Business_Type;
                            lblpolicyType.Text = item.Policy_Type;
                            lblproduct.Text = item.Product;
                            txtinsurers.Text = item.Insurer;
                            serviceperiod.Text = item.Service_Period;
                            binderCodes.Text = item.Binder_Code;
                            policyNumber.Text = item.Policy_No;
                            policystartDate.Text = Convert.ToString(item.Policy_Start_Date);
                            policyenddate.Text = Convert.ToString(item.Policy_End_Date);
                            txtcalenderDays.Text = Convert.ToString(item.Days);
                            nonrenewable.Text = Convert.ToString(item.Non_Renewable);
                            binderfeerate.Text = Convert.ToString(item.Binder_Fee_Rate);
                            commissionRate.Text = Convert.ToString(item.Commission_Rate);
                            modeofpayments.Text = Convert.ToString(item.Mode_of_Payment);
                            paymentreferenceccode.Text = Convert.ToString(item.Payment_Code);
                            txtfinancier.Text = Convert.ToString(item.Financier);
                            lblhasbinder.Text = Convert.ToString(item.Has_Binder);
                            premiumsratings.Text = Convert.ToString(item.Premium_Rating);
                            membertype.Text = Convert.ToString(item.Policy_Business_Type);
                            agentDetail.Text = Convert.ToString(item.Agent_Detail);

                        }


                    }
                }

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

                dvgrowerdetails.Visible = false;
                basicpremium.Visible = false;
                generalformgurantor.Visible = false;
                generalformcheckoffs.Visible = false;
                generalformgreenleaf.Visible = false;
                generalformktdastaffdeduction.Visible = false;
                divlatestevaluationreport.Visible = false;
            }
        }
        protected void Next_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string docNo = Request.QueryString["ContractNo"].Trim();
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
                    var status = new Config().ObjNav().FnNewMotorPolicyAmmendments(docNo);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("MotorCorporatePolicyAmmendments.aspx?ContractNo=" + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + res[2] + "&step=2");

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
        protected void SubmitRiskDetails_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string registrationNo = registrationnumber.Text.Trim();
            if (registrationNo.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tmake = make.SelectedValue.Trim();
            if (tmake.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tmodel = model.SelectedValue.Trim();
            if (tmodel.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tvehicletype = vehicletype.SelectedValue.Trim();
            if (tvehicletype.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tcovertype = covertype.SelectedValue.Trim();
            if (tcovertype.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string ttxtbasicpremiums = txtbasicpremiums.Text.Trim();
            decimal tttxtbasicpremiums = 0;
            if (tcovertype == "COMPREHENSIVE COVERAGE")
            {
                tttxtbasicpremiums = 0;
            }
            else
            {
                if (ttxtbasicpremiums.Length < 1)
                {
                    flag = true;
                    str = "Please fill in the Basic Premium";
                }
                else
                {
                    tttxtbasicpremiums = Convert.ToDecimal(txtbasicpremiums.Text.Trim());
                }
            }
            string tcc = cc.Text.Trim();
            if (tcc.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string chasisNo = chasisnumber.Text.Trim();
            if (chasisNo.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string engineNo = enginenumber.Text.Trim();
            if (engineNo.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string yearofManufucture = yearofmanufucture.Text.Trim();
            if (yearofManufucture.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string bodyType = txtdropdownlist.SelectedValue.Trim();
            if (bodyType.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string s = policystratdate.Text.Trim();
            if (s.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            DateTime dateTime = new DateTime();
            DateTime exact = DateTime.ParseExact(s, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            string tduration = duration.Text.Trim();
            if (tduration.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string ttonnage = tonnage.Text.Trim();
            bool nonRenewable = false;
            string sums = valuesuminsured.Text.Trim();
            Decimal sumInsured = 0;
            if (sums.Length > 1)
            {
                sumInsured = Convert.ToDecimal(sums);
            }
            else
            {
                sumInsured = 0;
            }
            Decimal rate = Convert.ToDecimal(txtrate.Text.Trim());
            if (rate < 1M)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
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
            Decimal protector = 0;
            if (ttxtprotector.Length > 1)
            {
                protector = Convert.ToDecimal(ttxtprotector);
            }
            else
            {
                protector = 0;
            }

            string tcertificateNo = certificateNo.Text.Trim();
            if (tcertificateNo.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            try
            {
                if (flag)
                {
                    risksfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    string docNo = Request.QueryString["QuoteNo"].Trim();
                    string ApplicationNumber = docNo;
                    ApplicationNumber = ApplicationNumber.Replace('/', '_');
                    ApplicationNumber = ApplicationNumber.Replace(':', '_');
                    string path1 = Config.FilesLocation() + "New Clients/";
                    string str1 = Convert.ToString(ApplicationNumber);
                    string folderName = path1 + str1 + "/";
                    if (evaludationreport.HasFile)
                    {
                        string extension = System.IO.Path.GetExtension(evaludationreport.FileName);
                        if (new Config().IsAllowedExtension(extension))
                        {
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
                        }
                    }
                    string empNo = Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnNewQuoteMotorIndividualPolicyRiskDetails(empNo, docNo, "", registrationNo, tmake, tmodel, tvehicletype, tcovertype, tcc, chasisNo, engineNo, yearofManufucture, bodyType, exact, tduration, tbolnonerenewable,Convert.ToDecimal(ttonnage), tcertificateNo, sumInsured, rate, tbolvalued, tttxtbasicpremiums, protector);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        GetTotalValueSumInsured_Onlick();
                        risksfeedbackdetails.InnerHtml = "<div class='alert alert-success'>The Motor Risk Details have been successfully Submitted</div>";

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

                string ApplicationNumber = Request.QueryString["QuoteNo"].Trim();
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
                        if (new Config().IsAllowedExtension(extension))
                        {
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
                        }
                        else
                        {
                            error = true;
                            message += message.Length > 0 ? "<br>" : "";
                            message += "The file extension of the Logbook is not allowed,Kindly upload Pdf files";
                        }

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
                    if (uploadApplicationForm.HasFile)
                    {
                        string extension = System.IO.Path.GetExtension(uploadApplicationForm.FileName);
                        if (new Config().IsAllowedExtension(extension))
                        {
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
                        }
                        else
                        {
                            error = true;
                            message += message.Length > 0 ? "<br>" : "";
                            message += "The file extension of the Application/Proposal Form  is not allowed";
                        }

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
        protected void SubmitCommunicationDetails_Click(object sender, EventArgs e)
        {

            try
            {

                string docNo = Request.QueryString["ContractNo"].Trim();
                string CustomerNo = Request.QueryString["CustomerNo"].Trim();
                string QuoteNo = Request.QueryString["QuoteNo"].Trim();
                Response.Redirect("MotorCorporatePolicyAmmendments.aspx?ContractNo=" + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=3");


            }
            catch (Exception ex)
            {
                communicationfeedbackDetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
            }
        }



        protected void SubmitPolicyDetails_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            int tagentDetail = Convert.ToInt32(agentDetail.SelectedIndex);
            if (tagentDetail < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            var tlblagentsubcategorydetail = lblagentsubcategorydetail.SelectedValue.Trim();
            if (tlblagentsubcategorydetail.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }


            var tlblsalesgentcode = lblsalesgentcode.SelectedValue.Trim();
            if (tlblsalesgentcode.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            var ttxtrefferalname = txtrefferalname.Text.Trim();
            //if (ttxtrefferalname.Length < 1)
            //{
            //    flag = true;
            //    str = "Please fill all highlighted fields with *(Mandatory Fields)";
            //}
            int ttxtreferalmobilenumber = 0;
            string tttxtreferalmobilenumber = txtreferalmobilenumber.Text.Trim();
            if (tttxtreferalmobilenumber.Length > 1)
            {
                ttxtreferalmobilenumber = Convert.ToInt32(tttxtreferalmobilenumber);
            }
            try
            {
                var documentsmodeofpayments = txtmodeofpayments.SelectedValue.Trim();
                string ApplicationNumber = Request.QueryString["QuoteNo"].Trim();
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
                string docNo = Request.QueryString["ContractNo"].Trim();
                string CustomerNo = Request.QueryString["CustomerNo"].Trim();
                string QuoteNo = Request.QueryString["QuoteNo"].Trim();
                var Applicant = Session["empNo"].ToString();
                var status = new Config().ObjNav().FnMotorPolicyAmmendmentsUpdates(QuoteNo, tagentDetail, tlblagentsubcategorydetail, tlblsalesgentcode, ttxtrefferalname, ttxtreferalmobilenumber);
                var res = status.Split('*');
                if (res[0] == "success")
                {
                    Response.Redirect("MotorCorporatePolicyAmmendments.aspx?ContractNo=" + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=4");

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
                var Requisition = Request.QueryString["QuoteNo"].Trim();
                var status = new Config().ObjNav().SendMotorAmmendmentIndividualClientApplicationApproval(Requisition);
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
        protected void ValidateFormUpload(object sender, EventArgs e)
        {

            var tmodeofpayments = txtmodeofpayments.SelectedValue.Trim();
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

        }
        protected void ValidateYearofManufacture_Click(object sender, EventArgs e)
        {
            var tcovertype = covertype.SelectedValue.Trim();
            NAV nav = Config.ReturnNav();
            var thasBinder = "";
            string RequsitionNumber = Request.QueryString["QuoteNo"].Trim();
            var tbinder = nav.SalesHeader.Where(x => x.No == RequsitionNumber);
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
                    var Application = nav.SalesHeader.Where(x => x.No == RequsitionNumber).ToList();
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
            string RequsitionNumber = Request.QueryString["QuoteNo"].Trim();
            var tbinder = nav.SalesHeader.Where(x => x.No == RequsitionNumber);
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
                    var Application = nav.SalesHeader.Where(x => x.No == RequsitionNumber).ToList();
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
                }
                else
                {

                }
            }
        }
        protected void validateEndDate_Click(object sender, EventArgs e)
        {
            // string RequsitionNumber = Request.QueryString["QuoteNo"].Trim();
            var PolicyStartDate = policystratdate.Text.Trim();
            DateTime tPolicyStartDate = DateTime.ParseExact(PolicyStartDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            int tduration = (Convert.ToInt32(duration.Text.Trim()) - 1);
            DateTime tPolicyEndDate = tPolicyStartDate.AddDays(tduration);
            policiesendDate.Text = Convert.ToDateTime(tPolicyEndDate).ToString("dd-MM-yyyy");

        }
        protected void ValidateCoverType_Click(object sender, EventArgs e)
        {
            var tcovertype = covertype.SelectedValue.Trim();
            if (tcovertype == "COMPREHENSIVE COVERAGE")
            {
                basicpremium.Visible = false;
            }
            else
            {
                basicpremium.Visible = true;
            }
        }


        protected void ValidateRates_Click(object sender, EventArgs e)
        {
            string RequsitionNumber = Request.QueryString["QuoteNo"].Trim();
            NAV nav = Config.ReturnNav(); ;
            var Application = nav.SalesHeader.Where(x => x.No == RequsitionNumber).ToList();
            foreach (var item in Application)
            {
                var BinderDetails = nav.Binders.Where(x => x.Product_Code == item.Product).ToList();
                foreach (var binder in BinderDetails)
                {
                    txtrate.Text = Convert.ToString(binder.Premium_Rating);
                }
                policystratdate.Text = Convert.ToDateTime(item.Policy_Start_Date).ToString("dd-MM-yyyy");
            }
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
            Response.Redirect("MotorCorporatePolicyAmmendments.aspx?ContractNo=" + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=" + num2);

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
            Response.Redirect("MotorCorporatePolicyAmmendments.aspx?ContractNo=" + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=" + num2);
        }

        protected void GetPolicyEndDates_Click(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            DateTime myPolicystartDate = new DateTime();
            string tpolicystartDate = policystartDate.Text.Trim();
            try
            {
                myPolicystartDate = DateTime.ParseExact(tpolicystartDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string tserviceperiod = serviceperiod.Text.Trim();
            var status = new Config().ObjNav().FnGetPolicyEndDate(myPolicystartDate, tserviceperiod);
            policyenddate.Text = Convert.ToDateTime(status).ToString("MM/dd/yyyy");
            DateTime myPolicyenddatee = new DateTime();
            string tpolicyenddate = policyenddate.Text.Trim();
            try
            {
                myPolicyenddatee = DateTime.ParseExact(tpolicyenddate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
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
        }
        protected void GetProductsdetails_Onlick(object sender, EventArgs e)
        {
        }
        protected void GetVehicleTypes_Onlick()
        {

            var requisitionNo = Request.QueryString["QuoteNo"].Trim();
            NAV nav = Config.ReturnNav();
            var productDetails = nav.SalesHeader.Where(x => x.No == requisitionNo);
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
            var requisitionNo = Request.QueryString["QuoteNo"].Trim();
            var productDetails = nav.SalesHeader.Where(x => x.No == requisitionNo);
            foreach (var item in productDetails)
            {
                totalsvaluesuminsured.Text = Convert.ToString(item.Total_Value_Sum_Insured);
                totalpremium.Text = Convert.ToString(item.Total_Premiums);
                totalpremiumspayables.Text = "";
            }
        }
        protected void GetBinderRates_Onlick()
        {
        }
        protected void GetVendorProducts_Onlick(object sender, EventArgs e)
        {

        }
        protected void SalesAgendCodes_SelectedIndexChanged()
        {
        }

        protected void ValidateHasBinderDetails_Click(object sender, EventArgs e)
        {

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

        protected void DeactivateRiskDetails_Click(object sender, EventArgs e)
        {
            var tRisktoRemove = RisktoRemove.Text.Trim();
            string docNo = Request.QueryString["QuoteNo"].Trim();
            var Applicant = Session["empNo"].ToString();
            var status = new Config().ObjNav().DeactivateQuoteRiskDetails(docNo, tRisktoRemove);
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