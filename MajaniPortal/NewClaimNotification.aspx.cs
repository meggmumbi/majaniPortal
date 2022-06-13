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
    public partial class NewClaimNotification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NAV nav = Config.ReturnNav();
                List<string> claimagainst = new List<string>();
                claimagainst.Add("-----Select Claim Against-------");
                claimagainst.Add("Principal");
                claimagainst.Add("Dependant");
                lblclaimagainst.DataSource = claimagainst;
                lblclaimagainst.DataBind();
                //LoadCustomerPolcies
                PolicyDetails_OnClick();

                List<string> claimacategory = new List<string>();
                claimacategory.Add("-----Select Claim Category-------");
                claimacategory.Add("Medical");
                claimacategory.Add("Death");
                lblclaimcategory.DataSource = claimacategory;
                lblclaimcategory.DataBind();

                List<string> placeofooccuremce = new List<string>();
                placeofooccuremce.Add("-----Select Place of Occurrences--------");
                placeofooccuremce.Add("Hospital");
                placeofooccuremce.Add("Home");
                placeofooccuremce.Add("Other");
                lblplaceofOccurrences.DataSource = placeofooccuremce;
                lblplaceofOccurrences.DataBind();

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
                
                //var AllHospital = nav.HospitalDetails.ToList();
                //hospital.DataSource = AllHospital;
                //hospital.DataValueField = "Code";
                //hospital.DataTextField = "Hospital_Name";
                //hospital.DataBind();


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
            string GrowerNo = Request.QueryString["GrowerNo"].Trim();
            string tPatientName = PatientName.Text.Trim();
            decimal tClaimAmount = 0;
            if (string.IsNullOrEmpty(claimAmount.Text.Trim()))
            {
                tClaimAmount = 0;

            }
            else
            {
                tClaimAmount= Convert.ToInt32(claimAmount.Text.Trim());
            }


               
            if (tpolicyNo.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Policy No";
            }
            int tlblclaimagainst = lblclaimagainst.SelectedIndex;
            if (tlblclaimagainst < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Claim Against";
            }
            string dependantNo = tlbldependantNumber.Text.Trim();
            if (dependantNo == "--Select Dependant No--")
            {
                dependantNo = "";
            }
            int tlblclaimcategory = lblclaimcategory.SelectedIndex;
            if (tlblclaimcategory < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Claim Category";
            }
      
            if (tClaimAmount < 1)
            {
                flag = true;
                str = "Please Enter the claim amount";
            }
            //string s = dateofaccident.Text.Trim();
            //if (s.Length < 1)
            //{
            //    flag = true;
            //    str = "Please Enter a Valid  Value for Date of Accident";
            //}
            //DateTime ndateTime = new DateTime();
            //DateTime ndateTime = DateTime.ParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            //try
            //{
            //    ndateTime = DateTime.ParseExact(s, "d/M/yyyy", CultureInfo.InvariantCulture);
            //}
            //catch (Exception)
            //{
            //    flag = true;
            //    str += str.Length > 0 ? "<br/>" : "";
            //    str += "Please Enter a Valid  Value for Date of Accident";
            //}
            string placeOfOccurence = lblplaceofOccurrences.Text.Trim();
            if (placeOfOccurence.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Place of Occurrences";
            }
            if (placeofoccurrences.Text.Trim().Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Place of Occurrences";
            }
            string customerCategory ="";
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
                    string status = new Config().ObjNav().FncreateClaimNotification(docNo, custNo, requestor, tpolicyNo, tlblclaimagainst, dependantNo, tlblclaimcategory, placeOfOccurence, customerCategory,tPatientName,tClaimAmount);
                    var res=status.Split('*');
                    if (res[0] == "success")
                    {
                       Response.Redirect("NewClaimNotification.aspx?requisitionNo=" + res[2] + "&&GrowerNo=" + GrowerNo + "&&ContractNo=" +tpolicyNo +"&&ClaimType="+ tlblclaimcategory + "&&CustomerNo="+ custNo + "&step=2");

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
            Response.Redirect("NewClaimNotification.aspx?requisitionNo=" + trequisitionNo + "&&GrowerNo=" + GrowerNo + "&&ContractNo=" + tpolicyNo + "&&ClaimType="+ tClaimType + "&&CustomerNo=" + custNo + "&step="+ num2);
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
            Response.Redirect("NewClaimNotification.aspx?requisitionNo=" + trequisitionNo + "&&GrowerNo=" + GrowerNo + "&&ContractNo=" + tpolicyNo + "&&ClaimType=" + tClaimType + "&&CustomerNo=" + custNo + "&step=" + num2);
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
                DateTime DateofDeath= DateTime.MinValue;
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
                        string status = new Config().ObjNav().FnCreateClaimValidation(trequisitionNo, teventtypes, thospital, ttdateofdischarge, tinvoiceNo, tinvoiceAmount, ttdateofAdmission,BurialPermitNo, DateofDeath, 0,tReimbursementType,tsurgeryBenefit,tPatientName,"");
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
                        string status = new Config().ObjNav().FnCreateClaimValidation(trequisitionNo, teventtypes1, thospital, ttdateofdischarge, tinvoiceNo, tinvoiceAmount, ttdateofAdmission, tburiapermitNo, tttxtDateofDeath, Convert.ToInt32(tpaymenttype),0,0,"",tdeceasedName);
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
            var ServiceContractsPolicy= nav.ServiceContracts.Where(x => x.Contract_Insurance_Type == "Insurance" && x.Contract_No == tlblcustomers).ToList();           
            lblpolicynumber.DataSource = ServiceContractsPolicy;
            lblpolicynumber.DataValueField = "Policy_No";
            lblpolicynumber.DataTextField = "Policy_No";
            lblpolicynumber.DataBind();
        }

        protected void DependantsDetails_OnClick(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string tlblcustomers =Request.QueryString["CustomerNo"].Trim();
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
            tlbldependantNumber.DataSource = Dependenantslist;
            tlbldependantNumber.DataValueField = "Code";
            tlbldependantNumber.DataTextField = "Name";
            tlbldependantNumber.DataBind();
            tlbldependantNumber.Items.Insert(0, "--Select Dependant No--");
        }

        protected void upload_Click(object sender, EventArgs e)
        {
            string path1 = ConfigurationManager.AppSettings["FilesLocation"] + "Claims Verification Card/";
            string GrowerNo = Request.QueryString["GrowerNo"].Trim();
            int ClaimType = Convert.ToInt32(Request.QueryString["ClaimType"].Trim());
            string str1 = Request.QueryString["requisitionNo"].Trim().Replace('/', '_').Replace(':', '_');
            string rQuisitionNo = Request.QueryString["requisitionNo"];
            string path2 = path1 + str1 +"_"+ GrowerNo + "/";
            if (ClaimType == 1)
            {
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
                                    string str3 = path2 + GrowerNo + "_MedicalDocuments_" + str2;
                                    string fullfileName = str3;
                                    string str4 = str3;
                                    filetoupload.SaveAs(str3);
                                    Config.navExtender.AddLinkToRecord("Claims Verification Card", rQuisitionNo, fullfileName, "");
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
                //if (hospitalinvoice.HasFile)
                //{
                //    try
                //    {
                //        if (Directory.Exists(path1))
                //        {
                //            Path.GetExtension(hospitalinvoice.FileName);
                //            string extension = Path.GetExtension(hospitalinvoice.FileName);
                //            bool flag = true;
                //            try
                //            {
                //                if (!Directory.Exists(path2))
                //                    Directory.CreateDirectory(path2);
                //            }
                //            catch (Exception ex)
                //            {
                //                flag = false;
                //                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //            }
                //            if (flag)
                //            {
                //                if (new Config().IsAllowedExtension(extension))
                //                {
                //                    string str2 = hospitalinvoice.FileName.Replace(':', '_');
                //                    string str3 = path2 + GrowerNo + "_HospitalInvoice" + str2;
                //                    string fullfileName = str3;
                //                    string str4 = str3;
                //                    hospitalinvoice.SaveAs(str3);
                //                    Config.navExtender.AddLinkToRecord("Claims Verification Card", rQuisitionNo, fullfileName, "");
                //                    if (File.Exists(str3))
                //                    {
                //                        documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                //                    }
                //                    else
                //                    {
                //                        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //                    }
                //                }
                //                else
                //                {
                //                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //                }
                //            }
                //            else
                //                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents folder defined does not exist in the server. Please contact support. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //        }
                //        else
                //        {
                //            documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again Later<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents could not be uploaded. Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //    }
                //}
                //if (receipts.HasFile)
                //{
                //    try
                //    {
                //        if (Directory.Exists(path1))
                //        {
                //            Path.GetExtension(receipts.FileName);
                //            string extension = Path.GetExtension(receipts.FileName);
                //            bool flag = true;
                //            try
                //            {
                //                if (!Directory.Exists(path2))
                //                    Directory.CreateDirectory(path2);
                //            }
                //            catch (Exception ex)
                //            {
                //                flag = false;
                //                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //            }
                //            if (flag)
                //            {
                //                if (new Config().IsAllowedExtension(extension))
                //                {
                //                    string str2 = receipts.FileName.Replace(':', '_');
                //                    string str3 = path2 + GrowerNo + "_Receipts" + str2;
                //                    string fullfileName = str3;
                //                    string str4 = str3;
                //                    receipts.SaveAs(str3);
                //                    Config.navExtender.AddLinkToRecord("Claims Verification Card", rQuisitionNo, fullfileName, "");
                //                    if (File.Exists(str3))
                //                    {
                //                        documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                //                    }
                //                    else
                //                    {
                //                        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //                    }
                //                }
                //                else
                //                {
                //                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //                }
                //            }
                //            else
                //                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents folder defined does not exist in the server. Please contact support. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //        }
                //        else
                //        {
                //            documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again Later<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents could not be uploaded. Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //    }
                //}
                //if (payments.HasFile)
                //{
                //    try
                //    {
                //        if (Directory.Exists(path1))
                //        {
                //            Path.GetExtension(payments.FileName);
                //            string extension = Path.GetExtension(payments.FileName);
                //            bool flag = true;
                //            try
                //            {
                //                if (!Directory.Exists(path2))
                //                    Directory.CreateDirectory(path2);
                //            }
                //            catch (Exception ex)
                //            {
                //                flag = false;
                //                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //            }
                //            if (flag)
                //            {
                //                if (new Config().IsAllowedExtension(extension))
                //                {
                //                    string str2 = payments.FileName.Replace(':', '_');
                //                    string str3 = path2 + GrowerNo + "_payments" + str2;
                //                    string fullfileName = str3;
                //                    string str4 = str3;
                //                    payments.SaveAs(str3);
                //                    Config.navExtender.AddLinkToRecord("Claims Verification Card", rQuisitionNo, fullfileName, "");
                //                    if (File.Exists(str3))
                //                    {
                //                        documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                //                    }
                //                    else
                //                    {
                //                        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //                    }
                //                }
                //                else
                //                {
                //                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //                }
                //            }
                //            else
                //                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents folder defined does not exist in the server. Please contact support. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //        }
                //        else
                //        {
                //            documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again Later<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents could not be uploaded. Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //    }
                //}
                //if (claimsidcopy.HasFile)
                //{
                //    try
                //    {
                //        if (Directory.Exists(path1))
                //        {
                //            Path.GetExtension(claimsidcopy.FileName);
                //            string extension = Path.GetExtension(claimsidcopy.FileName);
                //            bool flag = true;
                //            try
                //            {
                //                if (!Directory.Exists(path2))
                //                    Directory.CreateDirectory(path2);
                //            }
                //            catch (Exception ex)
                //            {
                //                flag = false;
                //                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //            }
                //            if (flag)
                //            {
                //                if (new Config().IsAllowedExtension(extension))
                //                {
                //                    string str2 = claimsidcopy.FileName.Replace(':', '_');
                //                    string str3 = path2 + GrowerNo + "_ClaimantsIDCopy" + str2;
                //                    string fullfileName = str3;
                //                    string str4 = str3;
                //                    claimsidcopy.SaveAs(str3);
                //                    Config.navExtender.AddLinkToRecord("Claims Verification Card", rQuisitionNo, fullfileName, "");
                //                    if (File.Exists(str3))
                //                    {
                //                        documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                //                    }
                //                    else
                //                    {
                //                        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //                    }
                //                }
                //                else
                //                {
                //                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //                }
                //            }
                //            else
                //                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents folder defined does not exist in the server. Please contact support. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //        }
                //        else
                //        {
                //            documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again Later<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents could not be uploaded. Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                //    }
                //}
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
                                    string str3 = path2 + GrowerNo + "_OtherDocuments" + str2;
                                    string fullfileName = str3;
                                    string str4 = str3;
                                    otherdocuments.SaveAs(str3);
                                    Config.navExtender.AddLinkToRecord("Claims Verification Card", rQuisitionNo, fullfileName, "");
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
            //Claim Other Type
            if (ClaimType == 2)
            {
                
                    if (burialpermit.HasFile)
                    {
                        try
                        {
                            if (Directory.Exists(path1))
                            {
                                Path.GetExtension(burialpermit.FileName);
                                string extension = Path.GetExtension(burialpermit.FileName);
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
                                        string str2 = burialpermit.FileName.Replace(':', '_');
                                        string str3 = path2 + GrowerNo + "_DeathDocuemnts_" + str2;
                                        string fullfileName = str3;
                                        string str4 = str3;
                                        burialpermit.SaveAs(str3);
                                        Config.navExtender.AddLinkToRecord("Claims Verification Card", rQuisitionNo, fullfileName, "");
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
                    //if (claimform.HasFile)
                    //{
                    //    try
                    //    {
                    //        if (Directory.Exists(path1))
                    //        {
                    //            Path.GetExtension(claimform.FileName);
                    //            string extension = Path.GetExtension(claimform.FileName);
                    //            bool flag = true;
                    //            try
                    //            {
                    //                if (!Directory.Exists(path2))
                    //                    Directory.CreateDirectory(path2);
                    //            }
                    //            catch (Exception ex)
                    //            {
                    //                flag = false;
                    //                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //            }
                    //            if (flag)
                    //            {
                    //                if (new Config().IsAllowedExtension(extension))
                    //                {
                    //                    string str2 = claimform.FileName.Replace(':', '_');
                    //                    string str3 = path2 + GrowerNo + "_ClaimForm" + str2;
                    //                    string fullfileName = str3;
                    //                    string str4 = str3;
                    //                    claimform.SaveAs(str3);
                    //                    Config.navExtender.AddLinkToRecord("Claims Verification Card", rQuisitionNo, fullfileName, "");
                    //                    if (File.Exists(str3))
                    //                    {
                    //                        documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                    //                    }
                    //                    else
                    //                    {
                    //                        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //                }
                    //            }
                    //            else
                    //                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents folder defined does not exist in the server. Please contact support. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //        }
                    //        else
                    //        {
                    //            documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again Later<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents could not be uploaded. Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //    }
                    //}
                    //if (growerpayslip.HasFile)
                    //{
                    //    try
                    //    {
                    //        if (Directory.Exists(path1))
                    //        {
                    //            Path.GetExtension(growerpayslip.FileName);
                    //            string extension = Path.GetExtension(growerpayslip.FileName);
                    //            bool flag = true;
                    //            try
                    //            {
                    //                if (!Directory.Exists(path2))
                    //                    Directory.CreateDirectory(path2);
                    //            }
                    //            catch (Exception ex)
                    //            {
                    //                flag = false;
                    //                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //            }
                    //            if (flag)
                    //            {
                    //                if (new Config().IsAllowedExtension(extension))
                    //                {
                    //                    string str2 = growerpayslip.FileName.Replace(':', '_');
                    //                    string str3 = path2 + GrowerNo + "_GrowerPayslip" + str2;
                    //                string fullfileName = path2 + str3;
                    //                string str4 = str3;
                    //                    growerpayslip.SaveAs(str3);
                    //                Config.navExtender.AddLinkToRecord("Claims Verification Card", rQuisitionNo, fullfileName, "");
                    //                if (File.Exists(str3))
                    //                    {
                    //                        documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                    //                    }
                    //                    else
                    //                    {
                    //                        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //                }
                    //            }
                    //            else
                    //                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents folder defined does not exist in the server. Please contact support. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //        }
                    //        else
                    //        {
                    //            documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again Later<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents could not be uploaded. Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //    }
                    //}
                    //if (deceasedslip.HasFile)
                    //{
                    //    try
                    //    {
                    //        if (Directory.Exists(path1))
                    //        {
                    //            Path.GetExtension(deceasedslip.FileName);
                    //            string extension = Path.GetExtension(deceasedslip.FileName);
                    //            bool flag = true;
                    //            try
                    //            {
                    //                if (!Directory.Exists(path2))
                    //                    Directory.CreateDirectory(path2);
                    //            }
                    //            catch (Exception ex)
                    //            {
                    //                flag = false;
                    //                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //            }
                    //            if (flag)
                    //            {
                    //                if (new Config().IsAllowedExtension(extension))
                    //                {
                    //                    string str2 = deceasedslip.FileName.Replace(':', '_');
                    //                    string str3 = path2 + GrowerNo + "_DeceasedSlip" + str2;
                    //                string fullfileName = str3;
                    //                string str4 = str3;
                    //                     deceasedslip.SaveAs(str3);
                    //                Config.navExtender.AddLinkToRecord("Claims Verification Card", rQuisitionNo, fullfileName, "");
                    //                if (File.Exists(str3))
                    //                    {
                    //                        documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                    //                    }
                    //                    else
                    //                    {
                    //                        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //                }
                    //            }
                    //            else
                    //                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents folder defined does not exist in the server. Please contact support. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //        }
                    //        else
                    //        {
                    //            documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again Later<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents could not be uploaded. Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //    }
                    //}
                    //if (beneficiaryid.HasFile)
                    //{
                    //    try
                    //    {
                    //        if (Directory.Exists(path1))
                    //        {
                    //            Path.GetExtension(beneficiaryid.FileName);
                    //            string extension = Path.GetExtension(beneficiaryid.FileName);
                    //            bool flag = true;
                    //            try
                    //            {
                    //                if (!Directory.Exists(path2))
                    //                    Directory.CreateDirectory(path2);
                    //            }
                    //            catch (Exception ex)
                    //            {
                    //                flag = false;
                    //                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //            }
                    //            if (flag)
                    //            {
                    //                if (new Config().IsAllowedExtension(extension))
                    //                {
                    //                    string str2 = beneficiaryid.FileName.Replace(':', '_');
                    //                    string str3 = path2 + GrowerNo + "_BeneficiaryId" + str2;
                    //                string fullfileName = str3;
                    //                string str4 = str3;
                    //                beneficiaryid.SaveAs(str3);
                    //                Config.navExtender.AddLinkToRecord("Claims Verification Card", rQuisitionNo, fullfileName, "");
                    //                if (File.Exists(str3))
                    //                    {
                    //                        documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                    //                    }
                    //                    else
                    //                    {
                    //                        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //                }
                    //            }
                    //            else
                    //                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents folder defined does not exist in the server. Please contact support. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //        }
                    //        else
                    //        {
                    //            documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again Later<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents could not be uploaded. Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //    }
                    //}
                    if (deathotherdocument.HasFile)
                   {
                        try
                        {
                            if (Directory.Exists(path1))
                            {
                                Path.GetExtension(deathotherdocument.FileName);
                                string extension = Path.GetExtension(deathotherdocument.FileName);
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
                                        string str2 = deathotherdocument.FileName.Replace(':', '_');
                                        string str3 = path2 + GrowerNo + "_DeathotherDocuments" + str2;
                                    string fullfileName = str3;
                                    string str4 = str3;
                                    deathotherdocument.SaveAs(str3);
                                    Config.navExtender.AddLinkToRecord("Claims Verification Card", rQuisitionNo, fullfileName, "");
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
        }
        protected void ValidateNumberOfDays_Click(object sender, EventArgs e)
        {
            string tdateofdischarge = dateofdischarge.Text.Trim();
            string tdateofAdmission = dateofAdmission.Text.Trim();
            DateTime ttdateofdischarge = DateTime.ParseExact(tdateofdischarge, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime ttdateofAdmission = DateTime.ParseExact(tdateofAdmission, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            int NumberofDays = (ttdateofdischarge - ttdateofAdmission).Days;
            noOfDays.Text =Convert.ToString(NumberofDays);
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
                    var status = new Config().ObjNav().PushClaimNotificationForValidation(docNo);
                    var res =status.Split('*');
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
    }
}
