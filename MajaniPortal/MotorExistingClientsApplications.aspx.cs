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
    public partial class MotorExistingClientsApplications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                NAV nav = Config.ReturnNav();
                try
                {
                    int tstep = 1;
                    {
                        tstep = Convert.ToInt32(Request.QueryString["step"].Trim());
                    }
                    if (tstep == 2)
                    {
                        ValidateCommunication_Onclick();
                    }
                    if (tstep == 4)
                    {
                        GetTotalValueSumInsured_Onlick();
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


                var customers = nav.Customer.ToList();
                List<DropDownList> list = new List<DropDownList>();
                foreach (var item in customers)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.No;
                    code.Name = item.No + " " + item.Name;
                    list.Add(code);
                }
                policyHolder.DataSource = list;
                policyHolder.DataValueField = "Code";
                policyHolder.DataTextField = "Name";
                policyHolder.DataBind();
                policyHolder.Items.Insert(0, "--Select Policy Holder No--");


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
                tmodeofpayments.Add("Insurance Premium Finance");
                tmodeofpayments.Add("Post Dated Cheque");
                modeofpayments.DataSource = tmodeofpayments;
                modeofpayments.DataBind();

                List<DropDownList> tCountriesOfResidencelist = new List<DropDownList>();
                var tCountriesOfResidence = nav.Countries.ToList();
                foreach (var item in tCountriesOfResidence)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Code;
                    code.Name = item.Code + " " + item.Name;
                    tCountriesOfResidencelist.Add(code);
                }

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


                binderfeerate.ReadOnly = true;
                commissionRate.ReadOnly = true;
                basicpremium.Visible = false;
                dvremarks.Visible = false;
                generalformgurantor.Visible = false;
                generalformcheckoffs.Visible = false;
                generalformgreenleaf.Visible = false;
                generalformktdastaffdeduction.Visible = false;
                divlatestevaluationreport.Visible = false;
                filecheques.Visible = false;
            }
        }
        protected void Next_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string CustomerNo = policyHolder.SelectedValue.Trim();
            Session["Customer"] = CustomerNo;
            try
            {
                if (flag)
                {
                    feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    string empNo = Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnNewMotorPolicyExistingBusiness(CustomerNo);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("MotorExistingClientsApplications.aspx?CustomerNo=" + CustomerNo + "&&QuoteNo=" + res[2] + "&step=2");

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
            string cc = this.cc.Text.Trim();
            if (cc.Length < 1)
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
            string ttxtbasicpremiums = txtbasicpremiums.Text.Trim();
            decimal basicpremium = 0;
            if (ttxtbasicpremiums.Length > 1)
            {
                basicpremium =Convert.ToDecimal(ttxtbasicpremiums);
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
            //if (ttonnage.Length < 1)
            //{
            //    flag = true;
            //    str = "Please fill all highlighted fields with *(Mandatory Fields)";
            //}
            bool nonRenewable = false;
            string tsumInsured = valuesuminsured.Text.Trim();
            decimal ttsumInsured = 0;
            if (tsumInsured.Length > 1)
            {
                ttsumInsured = Convert.ToDecimal(tsumInsured);
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
            decimal excessprotectors = 0;
            if (ttxtprotector.Length > 1)
            {
                excessprotectors = Convert.ToDecimal(ttxtprotector);
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
                    string empNo = Session["empNo"].ToString();
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
                    var status = new Config().ObjNav().FnNewQuoteMotorExistingIndividualPolicyRiskDetails(empNo, docNo, "", registrationNo, tmake, tmodel, tvehicletype, tcovertype, cc, chasisNo, engineNo, yearofManufucture, bodyType, exact, tduration, tbolnonerenewable,Convert.ToDecimal(ttonnage), tcertificateNo, ttsumInsured, rate, tbolvalued, basicpremium,excessprotectors);
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

                string ApplicationNumber = Request.QueryString["QuoteNo"].Trim();
                ApplicationNumber = ApplicationNumber.Replace('/', '_');
                ApplicationNumber = ApplicationNumber.Replace(':', '_');
                string path1 = ConfigurationManager.AppSettings["FilesLocation"] + "New Clients/";
                string str1 = Convert.ToString(ApplicationNumber);
                string folderName = path1 + str1 + "/";
                bool error = false;
                string message = "";
                try
                {
                    if (uploadLogbook.HasFile)
                    {
                        string extension = System.IO.Path.GetExtension(uploadLogbook.FileName);
                        //if (extension == ".pdf" || extension == ".PDF" || extension == ".Pdf")
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
                        //if (extension == ".pdf" || extension == ".PDF" || extension == ".Pdf")
                        //{
                            string filename = ApplicationNumber + "_IDBirthCertificate " + extension;
                            if (!Directory.Exists(folderName))
                            {
                                Directory.CreateDirectory(folderName);
                            }
                            if (File.Exists(folderName + filename))
                            {
                                File.Delete(folderName + filename);
                            }
                            uploadIDCertificate.SaveAs(folderName + filename);
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
                        //if (extension == ".pdf" || extension == ".PDF" || extension == ".Pdf")
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

            try
            {
                string CustomerNo = Request.QueryString["CustomerNo"].Trim();
                string QuoteNo = Request.QueryString["QuoteNo"].Trim();
                Response.Redirect("MotorExistingClientsApplications.aspx?CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=3");


            }
            catch (Exception ex)
            {
                communicationfeedbackDetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
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
                generalformktdastaffdeduction.Visible = false;
                generalformgurantor.Visible = false;
                generalformcheckoffs.Visible = false;
                generalformgreenleaf.Visible = false;
                filecheques.Visible = true;
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
            string referralName = txtrefferalname.Text.Trim();
            string referralMobileNumber = "";
            if (selectedIndex2 == 1)
            {
                selectedIndex2 = agentDetail.SelectedIndex;
                agentcode = salesgentcode.SelectedValue.Trim();
                if (agentcode.Length < 1)
                {
                    flag = true;
                    str = "Please fill all highlighted fields with *(Mandatory Fields)";
                }
            }
            if (selectedIndex2 == 2)
            {
                agentcode = salesgentcode.SelectedValue.Trim();
                if (agentcode.Length < 1)
                {
                    flag = true;
                    str = "Please fill all highlighted fields with *(Mandatory Fields)";
                }
            }
            var tpaidamount = paidamount.Text.Trim();
            if (tpaidamount.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            DateTime alldatepaid = DateTime.Now;
            var tdatepaid = datepaid.Text.Trim();
            if (tdatepaid.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
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
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            else
            {
                ttpolicystartDate = DateTime.ParseExact(tpolicystartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            referralMobileNumber = txtreferalmobilenumber.Text.Trim();
            int tmembertype = membertype.SelectedIndex;
            int tinvoiceperiod = 0;
            var ttxtfinancier = txtfinancier.SelectedValue.Trim();
            var tserviceperiod = serviceperiod.Text.Trim();
            if (tserviceperiod.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            var ttxtinsurers = txtinsurers.SelectedValue.Trim();
            if (ttxtinsurers.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            int tmodeofpayments = modeofpayments.SelectedIndex;
            if (tmodeofpayments < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            int ttxtpaymentsoptions = txtpaymentsoptions.SelectedIndex;
            if (ttxtpaymentsoptions < 1)
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
            var tpaymentreferenceccode = paymentreferenceccode.Text.Trim();
            if (tpaymentreferenceccode.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
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
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string dhb = "";
            tcommissionRate = Convert.ToDecimal(commissionRate.Text.Trim());
            if (tcommissionRate < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            tbinderfeerate = Convert.ToDecimal(binderfeerate.Text.Trim());
            if (tbinderfeerate < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tbinderCodes = binderCodes.Text.Trim();
            if (tbinderCodes.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tpolicyNumber = policyNumber.Text.Trim();
            if (tpolicyNumber.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tpremiumsratings = premiumsratings.Text.Trim();
            decimal ttpremiumsratings = 0;
            if (tpremiumsratings.Length > 1)
            {
                ttpremiumsratings = Convert.ToDecimal(tpremiumsratings);
            }
            string ttxtremarks = txtremarks.Text.Trim();
            try
            {
                
                if (flag)
                {
                    policyfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                var documentsmodeofpayments = modeofpayments.SelectedValue.Trim();
                string ApplicationNumber = Request.QueryString["QuoteNo"].Trim();
                ApplicationNumber = ApplicationNumber.Replace('/', '_');
                ApplicationNumber = ApplicationNumber.Replace(':', '_');
                string path1 = ConfigurationManager.AppSettings["FilesLocation"] + "New Clients/";
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
                string CustomerNo = Request.QueryString["CustomerNo"].Trim();
                string QuoteNo = Request.QueryString["QuoteNo"].Trim();
                var Applicant = Session["empNo"].ToString();
                var status = new Config().ObjNav().FnIndividualMotorupdatePolicyExistingDetails(QuoteNo, tlblpolicyType, product, tmodeofpayments, ttxtfinancier, tinvoiceperiod, tmembertype, tagentDetail, agentcode, referralIdNumber, referralName, referralMobileNumber, tnonrenewable, tlblhasbinder, tbinderfeerate, tcommissionRate, Convert.ToDecimal(tpaidamount), alldatepaid, tpaymentreferenceccode, ttpolicystartDate, ttxtpaymentsoptions, tpolicyNumber, ttpremiumsratings, ttxtremarks, tbinderCodes);
                var res = status.Split('*');
                if (res[0] == "success")
                {
                    Response.Redirect("MotorExistingClientsApplications.aspx?CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=4");

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
            var status = new Config().ObjNav().SendIndividualMotorAmmendmentApproval(Requisition);
            var res = status.Split('*');
            if (res[0] == "success")
            {
                Response.Redirect("GeneralOpenClientApplications.aspx");
            }
            else
            {
                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Existing Client Application Details Could not be Submitted for Approval" + res[1] + "</div>";

            }
        }
        catch (Exception ex)
        {
                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Existing Client Application Details Could not be Submitted for Approval" + ex.Message + "</div>";
        }
    }
        protected void GetBasicPremum_Click(object sender, EventArgs e)
        {
            var tcovertype = covertype.SelectedValue.Trim();
            if (tcovertype != "COMPREHENSIVE COVERAGE")
            {
                string RequsitionNumber = Request.QueryString["QuoteNo"].Trim();
                decimal tTonnage = Convert.ToDecimal(tonnage.Text.Trim());
                decimal status = new Config().ObjNav().FnGetBasicPremiumQuotes(RequsitionNumber, tcovertype, tTonnage);
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
        var RequsitionNumber = Request.QueryString["QuoteNo"].Trim();
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
            valuesuminsured.ReadOnly = false;
        }
        else
        {
            basicpremium.Visible = true;
           valuesuminsured.ReadOnly = true;
        }
    }
    protected void ValidateRates_Click(object sender, EventArgs e)
    {
        string RequsitionNumber = Request.QueryString["QuoteNo"].Trim();
        NAV nav = Config.ReturnNav(); ;
        var Application = nav.SalesHeader.Where(x => x.No == RequsitionNumber).ToList();
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

            policystratdate.Text = Convert.ToDateTime(item.Policy_Start_Date).ToString("dd-MM-yyyy");
        }
    }
    protected void nextstep_Click(object sender, EventArgs e)
    {
        int num1;
        string str;
        string CustomerNo = "";
        string QuoteNo = "";
        try
        {
            CustomerNo = Request.QueryString["CustomerNo"].Trim();
            QuoteNo = Request.QueryString["QuoteNo"].Trim();
            num1 = Convert.ToInt32(Request.QueryString["step"].Trim());


        }
        catch (Exception ex)
        {
            num1 = 0;
            str = "";
        }
        int num2 = num1 + 1;
        Response.Redirect("MotorExistingClientsApplications.aspx?CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=" + num2);
    }

    protected void previousstep_Click(object sender, EventArgs e)
    {
        int num1;
        string str;
        string CustomerNo = "";
        string QuoteNo = "";
        try
        {
            CustomerNo = Request.QueryString["CustomerNo"].Trim();
            QuoteNo = Request.QueryString["QuoteNo"].Trim();
            num1 = Convert.ToInt32(Request.QueryString["step"].Trim());


        }
        catch (Exception ex)
        {
            num1 = 0;
            str = "";
        }
        int num2 = num1 - 1;
        Response.Redirect("MotorExistingClientsApplications.aspx?CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=" + num2);
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
    protected void ValidateHasBinderDetails_Click(object sender, EventArgs e)
    {
        string tlblhasbinder = lblhasbinder.SelectedValue.Trim();
        if (tlblhasbinder == "Yes")
        {
            dvremarks.Visible = false;
            binderfeerate.ReadOnly =true;
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
    protected void GetProductsdetails_Onlick(object sender, EventArgs e)
    {
        NAV nav = Config.ReturnNav();
        string tlblproduct = lblpolicyType.SelectedValue.Trim();
        var tproduct = lblproduct.SelectedValue.Trim();
        var productDetails = nav.Items.Where(x => x.Policy_Type == tlblproduct && x.Insurance_Item_type == "Insurance");
        foreach (var item in productDetails)
        {
            //insurer.Text = item.Insurer;
            serviceperiod.Text = item.Service_Period;
            var BinderDetails = nav.Binders.Where(x => x.Product_Code == tproduct).ToList();
            foreach (var binder in BinderDetails)
            {
                premiumsratings.Text = Convert.ToString(binder.Premium_Rating);
                int PolicyNumberUser = Convert.ToInt32(binder.Last_No_Used) + 1;
                policyNumber.Text = binder.Code + "/" + "00" + PolicyNumberUser;
                binderCodes.Text = binder.Code;
            }
            if (item.Has_Binder == "Yes")
            {
                lblhasbinder.SelectedIndex = 0;
            }
            else
            {
                lblhasbinder.SelectedIndex = 1;
            }
            GetBinderRates_Onlick();
        }
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
        NAV nav = Config.ReturnNav();
        string tlblproduct = lblproduct.SelectedValue.Trim();
        var productDetails = nav.ClientApplicationQuery.Where(x => x.Product == tlblproduct);
        foreach (var item in productDetails)
        {
            serviceperiod.Text = item.Service_Period;
            binderfeerate.Text = Convert.ToString(item.Binder_Fee_Rate);
            commissionRate.Text = Convert.ToString(item.Commission_Rate);
            premiumsratings.Text = Convert.ToString(item.Premium_Rating);
        }
    }
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
    }
    protected void AgentDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        int tagentDetail = agentDetail.SelectedIndex;
        string agentdetaildescription = "";
        if (tagentDetail == 1)
        {
            agentdetaildescription = "Direct Business";
            SalesAgendCodes_SelectedIndexChanged();
        }
        if (tagentDetail == 2)
        {
            agentdetaildescription = "Agent Business";
            SalesAgendCodes_SelectedIndexChanged();
        }
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

    protected void ValidateCustomerDetails_Onclick(object sender, EventArgs e)
    {
        NAV nav = Config.ReturnNav();
        var ApplicationNumber = policyHolder.SelectedValue.Trim();
        var CustomerInfor = nav.Customer.Where(x => x.No == ApplicationNumber).ToList();
        foreach (var item in CustomerInfor)
        {
            txtfirstname.Text = item.First_Name;
            customerCategory.Text = item.Customer_Category;
            customerSubCategory.Text = item.Customer_Sub_Category;
            applicationTypes.Text = item.Applicant_Type;
            txtMiddleName.Text = item.Middle_Name;
            txtlastname.Text = item.Last_Name;
            txtHudumaNo.Text = item.Huduma_No;
            growerNumber.Text = item.Grower_No_Client_ID;
            txtFactoryCode.Text = item.Factory_Code_Branch_Code;
            ttxtFactoryName.Text = item.Factory_Name_Branch_Name;
            idtype.Text = item.ID_Type;
            txtIdNumber.Text = item.ID_No_Passport_No;
            growerapplicanttype.Text = item.Grower_Type_of_Applicant;
            lblgender.Text = item.Gender;
            lbltitle.Text = item.Title;
            lblcountyCode.Text = item.County;
            ttxtoccupations.Text = item.Occupation;
            telnumber1.Text = item.Tel_Mobile_No;
            telnumber2.Text = item.Tel_Mobile_No_2;
            txtaddress.Text = item.Address;
            postcodes.Text = item.Post_Code;
            txtemail.Text = item.E_Mail;
            lblcity.Text = item.City;
            txtaddress.Text = item.Address;
            txtgoogle.Text = item.Google;
            txttwitter.Text = item.Twitter;
            txtfcebook.Text = item.Facebook;
            txtlinkedin.Text = item.LinkedIn;
            lblmaritalstatus.Text = item.Marital_Status;
            lbltitle.Text = item.Title;
            txtDOB.Text = Convert.ToString(item.Date_of_Birth);
            krapinNumber.Text = Convert.ToString(item.PIN_No);
            countyofresidence.Text = Convert.ToString(item.Nationality);
        }
    }
    public void ValidateCommunication_Onclick()
    {
        NAV nav = Config.ReturnNav();
        var CustomerNumber = Request.QueryString["CustomerNo"].Trim();
        var CustomerInfor = nav.Customer.Where(x => x.No == CustomerNumber).ToList();
        foreach (var item in CustomerInfor)
        {
            telnumber1.Text = item.Tel_Mobile_No;
            telnumber2.Text = item.Tel_Mobile_No_2;
            txtaddress.Text = item.Address;
            postcodes.Text = item.Post_Code;
            txtemail.Text = item.E_Mail;
            lblcity.Text = item.City;
            txtgoogle.Text = item.Google;
            txttwitter.Text = item.Twitter;
            txtfcebook.Text = item.Facebook;
            txtlinkedin.Text = item.LinkedIn;
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
        protected void DeleteRiskDetails_Click(object sender, EventArgs e)
    {
        var tRisktoRemove = RisktoRemove.Text.Trim();
        string docNo = Request.QueryString["QuoteNo"].Trim();
        var Applicant = Session["empNo"].ToString();
        var status = new Config().ObjNav().DeleteQuoteRiskDetails(docNo, tRisktoRemove);
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