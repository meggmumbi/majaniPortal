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
    public partial class MotorClaimNotifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NAV nav = Config.ReturnNav();
                //List<string> claimagainst = new List<string>();
                //claimagainst.Add("-----Select Claim Against-------");
                //claimagainst.Add("Principal");
                //claimagainst.Add("Dependant");
                //lblclaimagainst.DataSource = claimagainst;
                //lblclaimagainst.DataBind();
                //LoadCustomerPolcies
                PolicyDetails_OnClick();





                //List<string> placeofooccuremce = new List<string>();
                //placeofooccuremce.Add("-----Select Place of Occurrences--------");
                //placeofooccuremce.Add("Hospital");
                //placeofooccuremce.Add("Home");
                //placeofooccuremce.Add("Other");
                //lblplaceofOccurrences.DataSource = placeofooccuremce;
                //lblplaceofOccurrences.DataBind();



                //List<DropDownList> CustomerCategoryQurylist = new List<DropDownList>();
                //var CustomerCategoryQury = nav.CustomerCategory.ToList();
                //foreach (var item in CustomerCategoryQury)
                //{
                //    DropDownList code = new DropDownList();
                //    code.Code = item.Code;
                //    code.Name = item.Description;
                //    CustomerCategoryQurylist.Add(code);
                //}
                //customercategory.DataSource = CustomerCategoryQurylist;
                //customercategory.DataValueField = "Code";
                //customercategory.DataTextField = "Name";
                //customercategory.DataBind();
                //customercategory.Items.Insert(0, "--Select Customer Category--");

                string custNumber = Request.QueryString["CustomerNo"].Trim();
                string ContractNo = Request.QueryString["ContractNo"].Trim();
                var CustomeryQuery = nav.Customer.Where(x => x.No == custNumber).ToList();
                foreach (var item in CustomeryQuery)
                {
                    txtnames.Text = item.Name;
                    lblselectedcustomers.Text = custNumber;
                    txtemailaddress.Text = item.E_Mail;
                    dateofreporting.Text = Convert.ToString(DateTime.Today);
                    idpassportnumber.Text = item.ID_No_Passport_No;
                    claimanttelnumber.Text = item.Tel_Mobile_No;

                }
                var Risks = nav.MotorRisksDetails.Where(s => s.Contract_No == ContractNo).ToList();
                List<DropDownList> MotorRisksDetailslist = new List<DropDownList>();
                foreach (var item in Risks)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Code;
                    code.Name = item.Registration_No;
                    MotorRisksDetailslist.Add(code);
                }
                riskcodes.DataSource = MotorRisksDetailslist;
                riskcodes.DataValueField = "Code";
                riskcodes.DataTextField = "Name";
                riskcodes.DataBind();
                riskcodes.Items.Insert(0, "--Select Registration No--");
            }
        }
        protected void ValidateMake_Text(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav(); ;
            var tregistrationNumbers = riskcodes.SelectedValue.Trim();
            var Risks = nav.MotorRisksDetails.Where(s => s.Code == tregistrationNumbers).ToList();
            foreach (var item in Risks)
            {
                makes.Text = item.Make;
                models.Text = item.Model;
                yearofmanufucture.Text = item.Year_of_manufacture;
                ccnumber.Text = item.CC;
                registrationNumbers.Text = item.Registration_No;
            }
        }
        protected void SubmitApplication_Click(object sender, EventArgs e)
        {

            string str = "";
            bool flag = false;
            string thousenumber = housenumber.Text.Trim();
            //if (thousenumber.Length < 1)
            //{
            //    flag = true;
            //    str = "Please Enter a Valid  Value for House No";
            //}
            string tmobileNumber = mobileNumber.Text.Trim();
            if (tmobileNumber.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Mobile No.";
            }
            string tplaceofaccident = placeofaccident.Text.Trim();
            if (tplaceofaccident.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Place of Occurence";
            }
            string tdateofaccident = dateofaccident.Text.Trim();
            if (tdateofaccident.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Date of Accident";
            }
            try
            {
                if (flag)
                {
                    feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    DateTime ttdateofaccident = DateTime.ParseExact(tdateofaccident, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    string custNo = Request.QueryString["CustomerNo"].Trim();
                    string tpolicyNo = Request.QueryString["ContractNo"].Trim();
                    string docNo = "";
                    string requestor = this.Session["empNo"].ToString();
                    string status = new Config().ObjNav().FnCreateMotorClaimNotification(docNo, tpolicyNo, custNo, requestor, thousenumber, tplaceofaccident, tmobileNumber, ttdateofaccident);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("MotorClaimNotifications.aspx?requisitionNo=" + res[2] + "&&ContractNo=" + tpolicyNo + "&&CustomerNo=" + custNo + "&step=2");

                    }
                    else
                    {
                        feedbackdetails.InnerHtml = "<div class='alert alert-danger'>The New Claim Notification Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";

                    }
                }
            }
            catch (Exception ex)
            {
                feedbackdetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
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
                trequisitionNo = Request.QueryString["requisitionNo"].Trim();
                tClaimType = Request.QueryString["ClaimType"].Trim();

            }
            catch (Exception ex)
            {
                num1 = 0;
                str = "";
            }
            int num2 = num1 + 1;
            Response.Redirect("MotorClaimNotifications.aspx?requisitionNo=" + trequisitionNo + "&&GrowerNo=" + GrowerNo + "&&ContractNo=" + tpolicyNo + "&&ClaimType=" + tClaimType + "&&CustomerNo=" + custNo + "&step=" + num2);
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
            Response.Redirect("MotorClaimNotifications.aspx?requisitionNo=" + trequisitionNo + "&&GrowerNo=" + GrowerNo + "&&ContractNo=" + tpolicyNo + "&&ClaimType=" + tClaimType + "&&CustomerNo=" + custNo + "&step=" + num2);
        }
        protected void SubmitValidations_Click(object sender, EventArgs e)
        {

            string str = "";
            bool flag = false;
            string custNo = Request.QueryString["CustomerNo"].Trim();
            string tpolicyNo = Request.QueryString["ContractNo"].Trim();
            string tregistrationNumber = registrationNumbers.Text.Trim();
            if (tregistrationNumber.Length < 1)
            {
                flag = true;
                str = "Please Enter a valid value for Registration No ";
            }
            string triskcodes = riskcodes.SelectedValue.Trim();
            if (triskcodes.Length < 1)
            {
                flag = true;
                str = "Please Enter a valid value for Risk Code ";
            }
            string tyearofmanufacture = yearofmanufucture.Text.Trim();
            if (tyearofmanufacture.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Year of Manufucture";
            }
            string tccnumber = ccnumber.Text.Trim();
            if (tccnumber.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for CC";
            }
            string ttrailernumber = trailernumber.Text.Trim();
            //if (ttrailernumber.Length < 1)
            //{
            //    flag = true;
            //    str = "Please Enter a Valid  Value for Trailer Registration No";
            //}
            string tcarryingcapacity = carryingcapacity.Text.Trim();
            //if (tcarryingcapacity.Length < 1)
            //{
            //    flag = true;
            //    str = "Please Enter a Valid  Value for Trailer Registration No";
            //}
            string tnameofwner = nameofwner.Text.Trim();
            //if (tnameofwner.Length < 1)
            //{
            //    flag = true;
            //    str = "Please Enter a Valid  Value for Name of Owner";
            //}
            string taddressofowner = addressofowner.Text.Trim();
            //if (taddressofowner.Length < 1)
            //{
            //    flag = true;
            //    str = "Please Enter a Valid  Value for Address of Owner";
            //}

            try
            {
                if (flag)
                {
                    feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    string requestor = Session["empNo"].ToString();
                    string trequisitionNo = Request.QueryString["requisitionNo"].Trim();
                    string status = new Config().ObjNav().FnCreateClaimMotorValidation(trequisitionNo, triskcodes, tregistrationNumber, "", "", tyearofmanufacture, tccnumber, ttrailernumber, tcarryingcapacity, tnameofwner, taddressofowner);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("MotorClaimNotifications.aspx?requisitionNo=" + res[2] + "&&ContractNo=" + tpolicyNo + "&&CustomerNo=" + custNo + "&step=3");

                    }
                    else
                    {
                        feedbackdetails.InnerHtml = "<div class='alert alert-danger'>The New Claim Notification Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";

                    }
                }
            }
            catch (Exception ex)
            {
                feedbackdetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
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

        }

        protected void upload_Click(object sender, EventArgs e)
        {
            string path1 = ConfigurationManager.AppSettings["FilesLocation"] + "Existing Policy/";
            string GrowerNo = Request.QueryString["CustomerNo"].Trim();
            string str1 = Request.QueryString["requisitionNo"].Trim().Replace('/', '_').Replace(':', '_');
            string path2 = path1 + str1 + "/";
            if (claimformupload.HasFile)
            {
                try
                {
                    if (Directory.Exists(path1))
                    {
                        Path.GetExtension(claimformupload.FileName);
                        string extension = Path.GetExtension(claimformupload.FileName);
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
                            //if (new Config().IsAllowedExtension(extension))
                            //{
                                string str2 = claimformupload.FileName.Replace(':', '_');
                                string str3 = path2 + GrowerNo + "_Claim Form_" + str2;
                                string str4 = str3;
                                claimformupload.SaveAs(str3);
                                if (File.Exists(str3))
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                                }
                                else
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                                }
                            //}
                            //else
                            //{
                            //    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                            //}
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

            if (policeabstract.HasFile)
            {
                try
                {
                    if (Directory.Exists(path1))
                    {
                        Path.GetExtension(policeabstract.FileName);
                        string extension = Path.GetExtension(policeabstract.FileName);
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
                            //if (new Config().IsAllowedExtension(extension))
                            //{
                                string str2 = policeabstract.FileName.Replace(':', '_');
                                string str3 = path2 + GrowerNo + "_Police Abstract_" + str2;
                                string str4 = str3;
                                policeabstract.SaveAs(str3);
                                if (File.Exists(str3))
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                                }
                                else
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                                }
                            //}
                            //else
                            //{
                            //    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                            //}
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
            if (loogbook.HasFile)
            {
                try
                {
                    if (Directory.Exists(path1))
                    {
                        Path.GetExtension(loogbook.FileName);
                        string extension = Path.GetExtension(loogbook.FileName);
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
                            //if (new Config().IsAllowedExtension(extension))
                            //{
                                string str2 = loogbook.FileName.Replace(':', '_');
                                string str3 = path2 + GrowerNo + "_LogBook_" + str2;
                                string str4 = str3;
                                loogbook.SaveAs(str3);
                                if (File.Exists(str3))
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                                }
                                else
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                                }
                            //}
                            //else
                            //{
                            //    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                            //}
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
            if (drivingLicense.HasFile)
            {
                try
                {
                    if (Directory.Exists(path1))
                    {
                        Path.GetExtension(drivingLicense.FileName);
                        string extension = Path.GetExtension(drivingLicense.FileName);
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
                            //if (new Config().IsAllowedExtension(extension))
                            //{
                                string str2 = drivingLicense.FileName.Replace(':', '_');
                                string str3 = path2 + GrowerNo + "_Driving License_" + str2;
                                string str4 = str3;
                                drivingLicense.SaveAs(str3);
                                if (File.Exists(str3))
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                                }
                                else
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                                }
                            //}
                            //else
                            //{
                            //    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                            //}
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
            if (detailedstatement.HasFile)
            {
                try
                {
                    if (Directory.Exists(path1))
                    {
                        Path.GetExtension(detailedstatement.FileName);
                        string extension = Path.GetExtension(detailedstatement.FileName);
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
                            //if (new Config().IsAllowedExtension(extension))
                            //{
                                string str2 = detailedstatement.FileName.Replace(':', '_');
                                string str3 = path2 + GrowerNo + "_Detailed Statement of accident Occurrence_" + str2;
                                string str4 = str3;
                                detailedstatement.SaveAs(str3);
                                if (File.Exists(str3))
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                                }
                                else
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                                }
                            //}
                            //else
                            //{
                            //    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                            //}
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
            else
            {
                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>Please select the documents to upload. Both are required <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

            }
            if (IDkraPin.HasFile)
            {
                try
                {
                    if (Directory.Exists(path1))
                    {
                        Path.GetExtension(IDkraPin.FileName);
                        string extension = Path.GetExtension(IDkraPin.FileName);
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
                            //if (new Config().IsAllowedExtension(extension))
                            //{
                                string str2 = IDkraPin.FileName.Replace(':', '_');
                                string str3 = path2 + GrowerNo + "_ID & KRA Pin_" + str2;
                                string str4 = str3;
                                IDkraPin.SaveAs(str3);
                                if (File.Exists(str3))
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                                }
                                else
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                                }
                            //}
                            //else
                            //{
                            //    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                            //}
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
            else
            {
                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>Please select the documents to upload. Both are required <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

            }
            if (inspectionreport.HasFile)
            {
                try
                {
                    if (Directory.Exists(path1))
                    {
                        Path.GetExtension(inspectionreport.FileName);
                        string extension = Path.GetExtension(inspectionreport.FileName);
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
                            //if (new Config().IsAllowedExtension(extension))
                            //{
                                string str2 = inspectionreport.FileName.Replace(':', '_');
                                string str3 = path2 + GrowerNo + "_Inspection Report_" + str2;
                                string str4 = str3;
                                inspectionreport.SaveAs(str3);
                                if (File.Exists(str3))
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                                }
                                else
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                                }
                            //}
                            //else
                            //{
                            //    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                            //}
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
            else
            {
                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>Please select the documents to upload. Both are required <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

            }
            if (towingreceipt.HasFile)
            {
                try
                {
                    if (Directory.Exists(path1))
                    {
                        Path.GetExtension(towingreceipt.FileName);
                        string extension = Path.GetExtension(towingreceipt.FileName);
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
                            //if (new Config().IsAllowedExtension(extension))
                            //{
                                string str2 = towingreceipt.FileName.Replace(':', '_');
                                string str3 = path2 + GrowerNo + "_Towing receipts_" + str2;
                                string str4 = str3;
                                towingreceipt.SaveAs(str3);
                                if (File.Exists(str3))
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                                }
                                else
                                {
                                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                                }
                            //}
                            //else
                            //{
                            //    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                            //}
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
            else
            {
                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>Please select the documents to upload. Both are required <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

            }
        }
       
        protected void Sendforvalidations_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            try
            {
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                feedbackdetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
            }
        }
    }
}
