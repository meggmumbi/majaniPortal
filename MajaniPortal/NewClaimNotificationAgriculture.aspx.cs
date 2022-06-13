using MajaniPortal.Nav;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class NewClaimNotificationAgriculture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                NAV nav = Config.ReturnNav();
                List<string> claimagainst = new List<string>();
             
                //LoadCustomerPolcies
                PolicyDetails_OnClick();

                List<string> teventtypes = new List<string>();
                teventtypes.Add("-----Select Event Type--------");
                teventtypes.Add("Normal");
                teventtypes.Add("Accidental");
                teventtypes.Add("Suicide");
                eventtypes.DataSource = teventtypes;
                eventtypes.DataBind();

                List<string> teventtypes1 = new List<string>();
                teventtypes1.Add("-----Select Event Type--------");
                teventtypes1.Add("Normal");
                teventtypes1.Add("Accidental");
                teventtypes1.Add("Suicide");
                eventtypes1.DataSource = teventtypes1;
                eventtypes1.DataBind();

                string tpolicyNo = Request.QueryString["ContractNo"].Trim();
                var workTypes = nav.policyRiskDetailsGen.Where(x => x.Contract_No == tpolicyNo).ToList();
                riskCode.DataSource = workTypes;
                riskCode.DataValueField = "Code";
                riskCode.DataTextField = "Name_of_Animal";
                riskCode.DataBind();
                riskCode.Items.Insert(0, new ListItem("--select--", ""));
                
                List<DropDownList> AllHospitallist = new List<DropDownList>();
                var AllHospital = nav.HospitalDetails.ToList();
                foreach (var item in AllHospital)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Code;
                    code.Name = item.Hospital_Name;
                    AllHospitallist.Add(code);
                }
                hospital.DataSource = AllHospitallist;
                hospital.DataValueField = "Code";
                hospital.DataTextField = "Name";
                hospital.DataBind();
                hospital.Items.Insert(0, "--Select Hospital Name--");

                string custNumber = Request.QueryString["CustomerNo"].Trim();
                var CustomeryQuery = nav.Customer.Where(x => x.No == custNumber).ToList();
                foreach (var item in CustomeryQuery)
                {
                    txtnames.Text = item.Name;
                    lblselectedcustomers.Text = custNumber;
                }
            }
        }
        protected void SubmitApplication_Click(object sender, EventArgs e)
        {

            string str = "";
            bool flag = false;

            string custNo = Request.QueryString["CustomerNo"].Trim();
            string tpolicyNo = Request.QueryString["ContractNo"].Trim();
           
            string tPatientName = PatientName.Text.Trim();
            string pTime = occTime.Text.Trim();
            string TdatePurchased = datePurch.Text.Trim();
            decimal tpricePaid = Convert.ToDecimal(pricePaid.Text.Trim());
            string TriskCode = riskCode.SelectedValue.Trim();

            if (tpolicyNo.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Policy No";
            }
            if (pTime.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Time of Accident";
            }
            if (tpricePaid < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Price Paid";
            }
            if (TriskCode.Length < 1)
            {
                flag = true;
                str = "Please select a Valid  Value for risk Code";
            }


            string s = occDate.Text.Trim();
            if (s.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Date of Accident";
            }
                 
            if (TdatePurchased.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Date of Purchase";
            }
           
            string placeOfOccurence = placeOfOccurences.Text.Trim();
            if (placeOfOccurence.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Place of Occurrences";
            }
         
            
            string docNo = "";
            try
            {
           if (flag)
                {
                    feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    

                    string requestor = this.Session["empNo"].ToString();
                    string status = new Config().ObjNav().FncreateClaimNotificationAgri(docNo, custNo, requestor, tpolicyNo,  placeOfOccurence, tPatientName,Convert.ToDateTime(s),Convert.ToDateTime(pTime), Convert.ToDateTime(TdatePurchased), tpricePaid,TriskCode);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("NewClaimNotificationAgriculture.aspx?requisitionNo=" + res[2] + "&&ContractNo=" + tpolicyNo  + "&&CustomerNo=" + custNo + "&step=2");

                    }
                    else
                    {
                        feedbackdetails.InnerHtml = "<div class='alert alert-danger'>The New Claim Notification Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";

                    }
                }
            }
            catch (Exception ex)
            {
                feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + ex.Message + "</div>";
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string selectedServices(List<Targets> targetNumber)
        {

            HtmlGenericControl NewControl = new HtmlGenericControl();
            var results = (dynamic)null;
            int category = 0;
            string part = "";

            try
            {
                if (targetNumber == null)
                {
                    targetNumber = new List<Targets>();
                }
                NewControl.ID = "feedback";

                foreach (Targets target in targetNumber)
                {

                    string InitiativeNumber = target.TargetNumber;
                 
                    var status = new Config().ObjNav().FnInsertResponses(target.ApplicationNo, target.TargetNumber, target.comment);
                    string[] info = status.Split('*');
                    if (info[0] == "success")
                    {
                        NewControl.ID = "feedback";
                        NewControl.InnerHtml = "<div class='alert alert-" + info[0] + "'>" + info[1] + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                        results = info[0];
                    }
                    else if (info[0] == "danger")
                    {

                        NewControl.ID = "feedback";
                        NewControl.InnerHtml = "<div class='alert alert-" + info[0] + "'>" + info[1] + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                        results = info[1];

                    }
                    
                }

            }
            catch (Exception ex)
            {
                results = ex.Message;
            }
            return results;
        }
        protected void nextstep_Click(object sender, EventArgs e)
        {
            int num1;
            string str;
            string custNo = "";
            string tpolicyNo = "";
            string GrowerNo = "";
            string trequisitionNo = "";
            string tClaimType = "";
            try
            {
                num1 = Convert.ToInt32(Request.QueryString["step"].Trim());
                tpolicyNo = Request.QueryString["ContractNo"].Trim();
                GrowerNo = Request.QueryString["GrowerNo"].Trim();
                trequisitionNo = Request.QueryString["requisitionNo"].Trim();
                tClaimType = Request.QueryString["ClaimType"].Trim();

            }
            catch (Exception ex)
            {
                num1 = 0;
                str = "";
            }
            int num2 = num1 + 1;
            Response.Redirect("NewClaimNotification.aspx?requisitionNo=" + trequisitionNo + "&&GrowerNo=" + GrowerNo + "&&ContractNo=" + tpolicyNo + "&&ClaimType=" + tClaimType + "&&CustomerNo=" + custNo + "&step=" + num2);
        }

        protected void previousstep_Click(object sender, EventArgs e)
        {
            int num1;
            string str;
            string custNo = "";
            string tpolicyNo = "";
            string GrowerNo = "";
            string trequisitionNo = "";
            string tClaimType = "";
            try
            {
                num1 = Convert.ToInt32(Request.QueryString["step"].Trim());
                custNo = Request.QueryString["CustomerNo"].Trim();
                tpolicyNo = Request.QueryString["ContractNo"].Trim();
                GrowerNo = Request.QueryString["GrowerNo"].Trim();
                trequisitionNo = Request.QueryString["requisitionNo"].Trim();
                tClaimType = Request.QueryString["ClaimType"].Trim();

            }
            catch (Exception ex)
            {
                num1 = 0;
                str = "";
            }
            int num2 = num1 - 1;
            Response.Redirect("NewClaimNotification.aspx?requisitionNo=" + trequisitionNo  + "&&ContractNo=" + tpolicyNo +  "&&CustomerNo=" + custNo + "&step=2");
        }
        protected void SubmitValidations_Click(object sender, EventArgs e)
        {

            string str = "";
            bool flag = false;
            string custNo = Request.QueryString["CustomerNo"].Trim();
            string tpolicyNo = Request.QueryString["ContractNo"].Trim();
            string GrowerNo = Request.QueryString["GrowerNo"].Trim();
            int ttClaimType = Convert.ToInt32(Request.QueryString["ClaimType"]);

            if (ttClaimType == 1)
            {
                string tPatientName = PatientName.Text.Trim();
                int tReimbursementType = Convert.ToInt32(reimbursementType.SelectedValue.Trim());
                decimal tsurgeryBenefit = Convert.ToDecimal(SurgeryBenefit.Text.Trim());
                DateTime DateofDeath = DateTime.MinValue;
                var BurialPermitNo = "";
                int teventtypes = eventtypes.SelectedIndex;
                if (teventtypes < 1)
                {
                    flag = true;
                    str = "Please Enter a Event Types";
                }
                if (string.IsNullOrEmpty(tPatientName))
                {
                    flag = true;
                    str = "Please Enter the patient Name";
                }
                if (tReimbursementType < 1)
                {
                    flag = true;
                    str = "Please select Re-imbursement Type";
                }
                string thospital = hospital.SelectedValue.Trim();
                if (thospital.Length < 1)
                {
                    flag = true;
                    str = "Please Enter a Valid  Value for Hospital";
                }
                string tdateofdischarge = dateofdischarge.Text.Trim();
                if (tdateofdischarge.Length < 1)
                {
                    flag = true;
                    str = "Please Enter a Valid  Value for Date of Discharge";
                }
                string tdateofAdmission = dateofAdmission.Text.Trim();
                if (tdateofAdmission.Length < 1)
                {
                    flag = true;
                    str = "Please Enter a Valid  Value for Date of Admission";
                }
                string tinvoiceNo = invoiceNo.Text.Trim();
                if (tinvoiceNo.Length < 1)
                {
                    flag = true;
                    str = "Please Enter a Valid  Value for Invoice";
                }
                decimal tinvoiceAmount = Convert.ToDecimal(invoiceAmount.Text.Trim());
                if (tinvoiceAmount < 1)
                {
                    flag = true;
                    str = "Please Enter a Valid  Value for Invoice Amount";
                }
                if (tsurgeryBenefit < 1)
                {
                    flag = true;
                    str = "Please Enter the surgery benefit amount";
                }

                DateTime dateTime = new DateTime();
                DateTime ttdateofdischarge = DateTime.ParseExact(tdateofdischarge, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime ttdateofAdmission = DateTime.ParseExact(tdateofAdmission, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                try
                {
                    if (flag)
                    {
                        verificationdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    }
                    else
                    {
                        string requestor = Session["empNo"].ToString();
                        string trequisitionNo = Request.QueryString["requisitionNo"].Trim();
                        string tcontractNo = Request.QueryString["ContractNo"].Trim();
                        string status = new Config().ObjNav().FnCreateClaimValidation(trequisitionNo, teventtypes, thospital, ttdateofdischarge, tinvoiceNo, tinvoiceAmount, ttdateofAdmission, BurialPermitNo, DateofDeath, 0, tReimbursementType, tsurgeryBenefit, tPatientName, "");
                        var res = status.Split('*');
                        if (res[0] == "success")
                        {
                            Response.Redirect("NewClaimNotification.aspx?requisitionNo=" + res[2] + "&&GrowerNo=" + GrowerNo + "&&ContractNo=" + tpolicyNo + "&&ClaimType=" + ttClaimType + "&&CustomerNo=" + custNo + "&step=3");

                        }
                        else
                        {
                            verificationdetails.InnerHtml = "<div class='alert alert-danger'>The New Claim Notification Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";

                        }
                    }
                }
                catch (Exception ex)
                {
                    verificationdetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
                }
            }
            if (ttClaimType == 2)
            {
                string tdeceasedName = deceasedName.Text.Trim();
                int teventtypes1 = eventtypes1.SelectedIndex;
                if (teventtypes1 < 1)
                {
                    flag = true;
                    str = "Please Enter a Event Types";
                }

                string tburiapermitNo = buriapermitNo.Text.Trim();
                if (tburiapermitNo.Length < 1)
                {
                    flag = true;
                    str = "Please Enter a Valid  Value for Burial Permit";
                }
                string ttxtDateofDeath = txtDateofDate.Text.Trim();
                if (ttxtDateofDeath.Length < 1)
                {
                    flag = true;
                    str = "Please Enter a Valid  Value for Date of Death";
                }
                if (string.IsNullOrEmpty(tdeceasedName))
                {
                    flag = true;
                    str = "Please Enter the Name of the deceased";
                }
                string thospital = "";
                //if (thospital.Length < 1)
                //{
                //    flag = true;
                //    str = "Please Enter a Valid  Value for Hospital";
                //}
                string tdateofdischarge = dateofdischarge.Text.Trim();
                //if (tdateofdischarge.Length < 1)
                //{
                //    flag = true;
                //    str = "Please Enter a Valid  Value for Date of Discharge";
                //}
                string tdateofAdmission = dateofAdmission.Text.Trim();
                //if (tdateofAdmission.Length < 1)
                //{
                //    flag = true;
                //    str = "Please Enter a Valid  Value for Date of Admission";
                //}
                string tinvoiceNo = invoiceNo.Text.Trim();
                //if (tinvoiceNo.Length < 1)
                //{
                //    flag = true;
                //    str = "Please Enter a Valid  Value for Invoice";
                //}
                decimal tinvoiceAmount = 0;
                //if (tinvoiceAmount < 1)
                //{
                //    flag = true;
                //    str = "Please Enter a Valid  Value for Invoice Amount";
                //}

                string tpaymenttype = paymenttype.SelectedValue;
                if (tpaymenttype == "--Select--")
                {
                    flag = true;
                    str = "Please select payment type";
                }

                DateTime dateTime = new DateTime();
                DateTime ttdateofdischarge = DateTime.MinValue;
                DateTime ttdateofAdmission = DateTime.MinValue;
                DateTime tttxtDateofDeath = DateTime.ParseExact(ttxtDateofDeath, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                try
                {
                    if (flag)
                    {
                        verificationdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    }
                    else
                    {
                        string requestor = Session["empNo"].ToString();
                        string trequisitionNo = Request.QueryString["requisitionNo"].Trim();
                        string tcontractNo = Request.QueryString["ContractNo"].Trim();
                        string status = new Config().ObjNav().FnCreateClaimValidation(trequisitionNo, teventtypes1, thospital, ttdateofdischarge, tinvoiceNo, tinvoiceAmount, ttdateofAdmission, tburiapermitNo, tttxtDateofDeath, Convert.ToInt32(tpaymenttype), 0, 0, "", tdeceasedName);
                        var res = status.Split('*');
                        if (res[0] == "success")
                        {
                            Response.Redirect("NewClaimNotification.aspx?requisitionNo=" + res[2] + "&&GrowerNo=" + GrowerNo + "&&ContractNo=" + tpolicyNo + "&&ClaimType=" + ttClaimType + "&&CustomerNo=" + custNo + "&step=3");

                        }
                        else
                        {
                            verificationdetails.InnerHtml = "<div class='alert alert-danger'>The New Claim Notification Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";

                        }
                    }
                }
                catch (Exception ex)
                {
                    verificationdetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
                }
            }
        }
        protected void PolicyDetails_OnClick()
        {
            NAV nav = Config.ReturnNav();
            string tlblcustomers = Request.QueryString["ContractNo"].Trim();
            var ServiceContractsPolicy = nav.ServiceContracts.Where(x => x.Contract_Insurance_Type == "Insurance" && x.Contract_No == tlblcustomers).ToList();
            lblpolicynumber.DataSource = ServiceContractsPolicy;
            lblpolicynumber.DataValueField = "Policy_No";
            lblpolicynumber.DataTextField = "Policy_No";
            lblpolicynumber.DataBind();
        }

        protected void DependantsDetails_OnClick(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string tlblcustomers = Request.QueryString["CustomerNo"].Trim();
            string ttlblpolicynumber = lblpolicynumber.SelectedValue.Trim();
            List<DropDownList> Dependenantslist = new List<DropDownList>();
            var policydependants = nav.ActualPolicyDependants.Where(x => x.Client_No == tlblcustomers).ToList();
            foreach (var item in policydependants)
            {
                DropDownList code = new DropDownList();
                code.Code = item.Dependant_Code;
                code.Name = item.Name;
                Dependenantslist.Add(code);
            }
          
        }

        protected void upload_Click(object sender, EventArgs e)
        {
            string path1 = ConfigurationManager.AppSettings["FilesLocation"] + "Claims Notification Card-Agri/";

          
            string str1 = Request.QueryString["requisitionNo"].Trim().Replace('/', '_').Replace(':', '_');
            string rQuisitionNo = Request.QueryString["requisitionNo"];
            string path2 = path1 + str1 + "_" + "/";
          
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
                                    string str3 = path2  + "_vetDocuments_" + str2;
                                    string fullfileName = str3;
                                    string str4 = str3;
                                    filetoupload.SaveAs(str3);
                                    Config.navExtender.AddLinkToRecord("Claims Notification Card-Agri", rQuisitionNo, fullfileName, "");
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
                                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents folder defined does not exist in the server. Please contact support. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
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

                if (otherdocuments.HasFile)
                {
                    try
                    {
                        if (Directory.Exists(path1))
                        {
                            Path.GetExtension(otherdocuments.FileName);
                            string extension = Path.GetExtension(otherdocuments.FileName);
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
                                    string str2 = otherdocuments.FileName.Replace(':', '_');
                                    string str3 = path2  + "_OtherDocuments" + str2;
                                    string fullfileName = str3;
                                    string str4 = str3;
                                    otherdocuments.SaveAs(str3);
                                    Config.navExtender.AddLinkToRecord("Claims Notification Card-Agri", rQuisitionNo, fullfileName, "");
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
                                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents folder defined does not exist in the server. Please contact support. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
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
        }

 
         
        protected void ValidateNumberOfDays_Click(object sender, EventArgs e)
        {
            string tdateofdischarge = dateofdischarge.Text.Trim();
            string tdateofAdmission = dateofAdmission.Text.Trim();
            DateTime ttdateofdischarge = DateTime.ParseExact(tdateofdischarge, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime ttdateofAdmission = DateTime.ParseExact(tdateofAdmission, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            int NumberofDays = (ttdateofdischarge - ttdateofAdmission).Days;
            noOfDays.Text = Convert.ToString(NumberofDays);
        }
        protected void Sendforvalidations_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            try
            {
                if (flag)
                {
                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    string docNo = Request.QueryString["requisitionNo"].Trim();
                    var status = new Config().ObjNav().PushAgricultureClaimNotificationForValidation(docNo);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        documentsfeedback.InnerHtml = "<div class='alert alert-success'>" + res[1] + "</div>";
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                        "setTimeout(function() { window.location.replace('Default.aspx') }, 5000);", true);
                    }
                    else
                    {
                        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The New Claim Notification Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";

                    }
                }
            }
            catch (Exception ex)
            {
                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
            }
        }

        protected void riskCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var nav = Config.ReturnNav();
            string tpolicyNo = Request.QueryString["ContractNo"].Trim();
            var workTypes = nav.policyRiskDetailsGen.Where(x => x.Contract_No == tpolicyNo && x.Code== riskCode.SelectedValue).ToList();
            foreach(var animal in workTypes)
            {
                milkProd.Text = animal.Milk_Production_Per_Day;
                ageYrs.Text = Convert.ToString( animal.Age_In_Years);
                sumIns.Text = Convert.ToString(animal.Value_Sum_Insured);

            }

        }

        protected void backToPhysical_Click(object sender, EventArgs e)
        {
            string requisitionNo = Request.QueryString["requisitionNo"];
            string ContractNo = Request.QueryString["ContractNo"];
            string CustomerNo = Request.QueryString["CustomerNo"];
            Response.Redirect("NewClaimNotificationAgriculture.aspx?requisitionNo=" + requisitionNo + "&&ContractNo=" + ContractNo + "&&CustomerNo=" + CustomerNo + "&step=1");
        }


        protected void nextAttach_Click(object sender, EventArgs e)
        {
            string requisitionNo = Request.QueryString["requisitionNo"];
            string ContractNo = Request.QueryString["ContractNo"];
            string CustomerNo = Request.QueryString["CustomerNo"];
            Response.Redirect("NewClaimNotificationAgriculture.aspx?requisitionNo=" + requisitionNo + "&&ContractNo=" + ContractNo + "&&CustomerNo=" + CustomerNo + "&step=4");
        }
    }
}