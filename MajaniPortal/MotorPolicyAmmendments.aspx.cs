using MajaniPortal.Nav;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class MotorPolicyAmmendments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NAV nav = Config.ReturnNav();
                List<DropDownList> Policylist = new List<DropDownList>();
                var AllPolicylist = nav.ServiceContracts.ToList();
                foreach (var item in AllPolicylist)
                {
                    DropDownList itemlist = new DropDownList();
                    itemlist.Code = item.Contract_No;
                    itemlist.Name = item.Customer_No+"_"+item.Bill_to_Name;
                    Policylist.Add(itemlist);
                }
                txtdropdownPolicy.DataSource = Policylist;
                txtdropdownPolicy.DataValueField = "Code";
                txtdropdownPolicy.DataTextField = "Name";
                txtdropdownPolicy.DataBind();
                txtdropdownPolicy.Items.Insert(0, "--Select Policy No--");
            }
        }
        protected void Next_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string ttxtdropdownPolicy = txtdropdownPolicy.SelectedValue.Trim();
            try
            {
                //if (flag)
                //{
                //    feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //}
                //else
                //{
                //    string empNo = Session["empNo"].ToString();
                //    var status = new Config().ObjNav().FnewClientOnboadingRequests(docNo, empNo, cust_category, selectedIndex1, policyType, 0, id_passport, pinNo, selectedIndex5, firstName, middleName, lastname, countryOfResidence, exact, 0, countyCode, 0, hudumaNo, applicanttype, occupation, tgrowerapplicanttype, tgrowerNumber, tfactoryCode, tfactoryName, financier, thasgrowerNo);
                //    var res = status.Split('*');
                //    if (res[0] == "success")
                //    {
                //        Response.Redirect("MotorPolicyAmmendments.aspx?requisitionNo=" + ttxtdropdownPolicy+ "&step=2");

                //    }
                //    else
                //    {
                //        feedbackdetails.InnerHtml = "<div class='alert alert-danger'>The New Client Application Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";

                //    }
                //}
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
            string engineNo = this.enginenumber.Text.Trim();
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
            DateTime exact = DateTime.ParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string tduration = duration.Text.Trim();
            if (tduration.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string ttonnage = tonnage.Text.Trim();
            if (ttonnage.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            bool nonRenewable = false;
            Decimal sumInsured = Convert.ToDecimal(valuesuminsured.Text.Trim());
            if (sumInsured < 1M)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
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
            if (ttxtprotector.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tcertificateNo = certificateNo.Text.Trim();
            if (tcertificateNo.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            //string ttxtprotector = txtprotector.Text.Trim();
            decimal tttxtprotector = 0;
            //if (ttxtprotector.Length > 1)
            //{
            //    tttxtprotector = 0;
            //}
            string ttxtbasicpremiums = txtbasicpremiums.Text.Trim();
            decimal basicpremiums = 0;
            if (ttxtbasicpremiums.Length < 1)
            {
                basicpremiums = Convert.ToDecimal(txtbasicpremiums.Text.Trim());
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
                    var status = new Config().ObjNav().FnNewMotorIndividualPolicyRiskDetails(empNo, docNo, tttxtprotector, registrationNo, tmake, tmodel, tvehicletype, tcovertype, cc, chasisNo, engineNo, yearofManufucture, bodyType, exact, tduration, tbolnonerenewable,Convert.ToDecimal(ttonnage), tcertificateNo, sumInsured, rate, tbolvalued, basicpremiums);
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
        protected void GetBasicPremum_Click(object sender, EventArgs e)
        {
            string RequsitionNumber = Request.QueryString["requisitionNo"].Trim();
            decimal tTonnage = Convert.ToDecimal(tonnage.Text.Trim());
            string tcovertype = covertype.Text.Trim();
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
                        if (extension == ".pdf" || extension == ".PDF" || extension == ".Pdf")
                        {
                            string filename = "_Logbook" + extension;
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
                    if (uploadIDCertificate.HasFile)
                    {
                        string extension = System.IO.Path.GetExtension(uploadIDCertificate.FileName);
                        if (new Config().IsAllowedExtension(extension))
                        {
                            string filename = "_IDBirthCertificate " + extension;
                            if (!Directory.Exists(folderName))
                            {
                                Directory.CreateDirectory(folderName);
                            }
                            if (File.Exists(folderName + filename))
                            {
                                File.Delete(folderName + filename);
                            }
                            uploadIDCertificate.SaveAs(folderName + filename);
                        }
                        else
                        {
                            error = true;
                            message += message.Length > 0 ? "<br>" : "";
                            message += "The file extension of the ID or Certificate of Incorporation   is not allowed";
                        }

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
                        if (extension == ".pdf" || extension == ".PDF" || extension == ".Pdf")
                        {
                            string filename = "_KRACertificate" + extension;
                            if (!Directory.Exists(folderName))
                            {
                                Directory.CreateDirectory(folderName);
                            }
                            if (File.Exists(folderName + filename))
                            {
                                File.Delete(folderName + filename);
                            }
                            uploadKRAPinCertificate.SaveAs(folderName + filename);
                        }
                        else
                        {
                            error = true;
                            message += message.Length > 0 ? "<br>" : "";
                            message += "The file extension of the KRA Certificate is not allowed,Kindly upload PDF files";
                        }

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
                        if (new Config().IsAllowedExtension(extension))
                        {
                            string filename = "_ApplicationProposalForm " + extension;
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
            if (ttxtemail.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
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
            string referralIdNumber = txtreferralidnumber.Text.Trim();
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
            var ttxtfinancier = txtfinancier.Text.Trim();
            if (ttxtfinancier.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
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
            int tlblhasbinder = 0;
            decimal tbinderfeerate = 0;
            decimal tcommissionRate = 0;
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
            try
            {
                if (flag)
                {
                    policyfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                string docNo = this.Request.QueryString["requisitionNo"].Trim();
                var Applicant = Session["empNo"].ToString();
                var status = new Config().ObjNav().FnIndividualMotorupdatePolicyAmmendmentDetails(docNo, tdepartment, tlblpolicyType, product, tmodeofpayments, ttxtfinancier, tinvoiceperiod, tmembertype, tagentDetail, agentcode, referralIdNumber, referralName, referralMobileNumber, tnonrenewable, tlblhasbinder, tbinderfeerate, tcommissionRate, Convert.ToDecimal(tpaidamount), alldatepaid, tpaymentreferenceccode, ttpolicystartDate, ttxtpaymentsoptions,"");
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
                var status = new Config().ObjNav().SendIndividualMotorAmmendmentApproval(Requisition);
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
            if (tcovertype == "COMPREHENSIVE COVERAGE")
            {
                string RequsitionNumber = Request.QueryString["requisitionNo"].Trim();
                int CurrentYear = Convert.ToInt32(DateTime.Now.Year);
                int tyearofmanufucture = Convert.ToInt32(yearofmanufucture.Text.Trim());
                var UserAgeLimit = CurrentYear - tyearofmanufucture;
                int AgeLimit = 0;
                NAV nav = Config.ReturnNav(); ;
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
                    txtyearofmanaufucturedetails.InnerText = "You are only allowed to insure Vehicles less than " + AgeLimit;
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

        protected void ValidateValueInsured_Click(object sender, EventArgs e)
        {
            var tcovertype = covertype.SelectedValue.Trim();
            if (tcovertype == "COMPREHENSIVE COVERAGE")
            {
                string RequsitionNumber = Request.QueryString["requisitionNo"].Trim();
                decimal tvaluesuminsured = Convert.ToDecimal(valuesuminsured.Text.Trim());
                decimal ValueInsured = 0;
                NAV nav = Config.ReturnNav(); ;
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
            }
            else
            {

            }
        }
        protected void validateEndDate_Click(object sender, EventArgs e)
        {
            string RequsitionNumber = Request.QueryString["requisitionNo"].Trim();
            var PolicyStartDate = policystratdate.Text.Trim();
            DateTime tPolicyStartDate = DateTime.ParseExact(PolicyStartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
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
                var BinderDetails = nav.Binders.Where(x => x.Product_Code == item.Product).ToList();
                foreach (var binder in BinderDetails)
                {
                    txtrate.Text = Convert.ToString(binder.Premium_Rating);
                }
                policystratdate.Text = Convert.ToDateTime(item.Policy_start_date).ToString("yyyy-MM-dd");
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
            var productDetails = nav.Items.Where(x => x.Policy_Type == tlblproduct && x.Insurance_Item_type == "Insurance");
            foreach (var item in productDetails)
            {
                //insurer.Text = item.Insurer;
                serviceperiod.Text = item.Service_Period;
                binderCodes.Text = item.Binder_Code;
                int PolicyNumberUser = Convert.ToInt32(item.Last_Policy_No_Used) + 1;
                policyNumber.Text = item.Binder_Code + "/" + "00" + PolicyNumberUser;
                if (item.Has_Binder == "Yes")
                {
                    lblhasbinder.SelectedIndex = 1;
                }
                else
                {
                    lblhasbinder.SelectedIndex = 2;
                }
                GetBinderRates_Onlick();
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
        
       protected void ValidateAllPolicyDetails_Click(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            var PolicyNo = txtdropdownPolicy.Text.Trim();
            var productDetails = nav.ServiceContracts.Where(x => x.Contract_No == PolicyNo);
            foreach (var item in productDetails)
            {
                customerCategories.Text =item.Customer_Category;
                applicationTypes.Text = item.Type_of_Applicant;
                txtIdNumber.Text = item.ID_Number;
                lbltitle.Text = item.Title;
                txtfirstname.Text = item.First_Name;
                txtMiddleName.Text = item.Middle_Name;
                txtlastname.Text = item.Last_Name;
                lblgender.Text = item.Gender;
                txtDOB.Text = Convert.ToString(item.Date_of_Birth);
                ttxtoccupations.Text = item.Occupation;
                krapinNumber.Text = item.KRA_Pin_No;
                lblcountyCode.Text = item.Bill_to_County;
                lblmaritalstatus.Text = item.Marital_Status;
                txtHudumaNo.Text = item.Huduma_No;
                countyofresidence.Text = item.Bill_to_Country_Region_Code;

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
            var productDetails = nav.ClientApplicationQuery.Where(x => x.Product == tlblproduct);
            foreach (var item in productDetails)
            {
                serviceperiod.Text = item.Service_Period;
                binderfeerate.Text = Convert.ToString(item.Binder_Fee_Rate);
                commissionRate.Text = Convert.ToString(item.Commission_Rate);
                premiumsratings.Text = Convert.ToString(item.Premium_Rating);
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

        protected void ValidateHasBinderDetails_Click(object sender, EventArgs e)
        {
            string tlblhasbinder = lblhasbinder.SelectedValue.Trim();
            if (tlblhasbinder == "Yes")
            {

                binderfeerate.Text = "";
                commissionRate.Text = "";
            }
            else
            {
                policyNumber.ReadOnly = false;
                binderCodes.ReadOnly = false;
                binderfeerate.Text = "";
                commissionRate.Text = "";
                policyNumber.Text = "";
                binderCodes.Text = "";
                premiumsratings.Text = "";

            }
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