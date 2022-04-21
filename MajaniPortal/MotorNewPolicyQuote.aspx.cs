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
    public partial class MotorNewPolicyQuote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NAV nav = Config.ReturnNav();
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

                
                 List<DropDownList> VendorCategorylist = new List<DropDownList>();
                var VendorCategory = nav.Vendors.Where(r => r.Vendor_Type == "Insurer").ToList();
                foreach (var item in VendorCategory)
                {
                    DropDownList itemlist = new DropDownList();
                    itemlist.Code = item.No;
                    itemlist.Name = item.Name;
                    VendorCategorylist.Add(itemlist);
                }
                txtinsurer.DataSource = VendorCategorylist;
                txtinsurer.DataValueField = "Code";
                txtinsurer.DataTextField = "Name";
                txtinsurer.DataBind();
                txtinsurer.Items.Insert(0, "--Select Insurer Name--");
                
               var policyTypes = nav.PolicyTypes.Where(x => x.Business_Type == "General" &&x.Business_Type_SubCategory=="Motor").ToList();
                List<DropDownList> policyTypeslist = new List<DropDownList>();
                foreach (var item in policyTypes)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Policy_Type_Code;
                    code.Name = item.Policy_Type_Decription;
                    policyTypeslist.Add(code);
                }
                lblpolicytypes.DataSource = policyTypeslist;
                lblpolicytypes.DataValueField = "Code";
                lblpolicytypes.DataTextField = "Name";
                lblpolicytypes.DataBind();
                lblpolicytypes.Items.Insert(0, "--Select Policy--");


                var typeofapplicationsQuery = nav.Items.Where(x =>x.Insurance_Item_type == "Insurance");
                List<DropDownList> typeofapplicationsQuerylist = new List<DropDownList>();
                foreach (var item in typeofapplicationsQuery)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.No;
                    code.Name = item.Description;
                    typeofapplicationsQuerylist.Add(code);
                }
                typeofapplications.DataSource = typeofapplicationsQuerylist;
                typeofapplications.DataValueField = "Code";
                typeofapplications.DataTextField = "Name";
                typeofapplications.DataBind();
                typeofapplications.Items.Insert(0, "--Select Type of Application--");

                List<string> modeofpayment = new List<string>();
                modeofpayment.Add("-----Select Mode of Payments-------");
                modeofpayment.Add("KTDA check Off");
                modeofpayment.Add("KTDA Bonus");
                modeofpayment.Add("Mpesa");
                modeofpayment.Add("Other");
                modeofpayment.Add("Corporate Checkoff");
                lblmodeofpayments.DataSource = modeofpayment;
                lblmodeofpayments.DataBind();

                List<string> productbillingcycles = new List<string>();
                productbillingcycles.Add("-----Select Product Billing Cycle-------");
                productbillingcycles.Add("Month");
                productbillingcycles.Add("Two Months");
                productbillingcycles.Add("Quarter");
                productbillingcycles.Add("Half Year");
                productbillingcycles.Add("Year");
                productbillingcycles.Add("None");
                lblproductbillingCycle.DataSource = productbillingcycles;
                lblproductbillingCycle.DataBind();

                List<string> membertype = new List<string>();
                membertype.Add("-----Select Member Type-------");
                membertype.Add("New");
                membertype.Add("Existing");
                lblmembertype.DataSource = membertype;
                lblmembertype.DataBind();

                List<string> agentdetail = new List<string>();
                agentdetail.Add("-----Select Agent Details-------");
                agentdetail.Add("Direct Business");
                agentdetail.Add("Agent Business");
                agentdetail.Add("Referral Business");
                lblagentDetails.DataSource = agentdetail;
                lblagentDetails.DataBind();

                var Salesperson = nav.Salespeople_Purchasers.ToList();
                List<DropDownList> Salespersonslist = new List<DropDownList>();
                foreach (var item in Salesperson)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Code;
                    code.Name = item.Name;
                    Salespersonslist.Add(code);
                }
                lblagentCode.DataSource = Salespersonslist;
                lblagentCode.DataValueField = "Code";
                lblagentCode.DataTextField = "Name";
                lblagentCode.DataBind();
                lblagentCode.Items.Insert(0, "--Select Agent SalesPerson Code--");

                var KTDAFARMERS = Config.ReturnNav().KTDAFARMERS.Where(x => x.Business_Type == "General").ToList();
                List<DropDownList> KTDAFARMERSlist = new List<DropDownList>();
                foreach (var item in KTDAFARMERS)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Grower_No;
                    code.Name = item.Name;
                    KTDAFARMERSlist.Add(code);
                }
                lblfanancier.DataSource = KTDAFARMERSlist;
                lblfanancier.DataValueField = "Code";
                lblfanancier.DataTextField = "Name";
                lblfanancier.DataBind();
                lblfanancier.Items.Insert(0, "--Select Financier Code--");


                List<string> lblpolicybusinessType = new List<string>();
                lblpolicybusinessType.Add("-----Select Product Billing Cycle-------");
                lblpolicybusinessType.Add("New");
                lblpolicybusinessType.Add("Existing");
                lblpolicybusinessType.Add("Renewal");
                lblpolicybusinessType.Add("Extension");
                lblpolicybusinessType.Add("Addition");
                lblpolicybusinessType.Add("Adjustment");
                lblpolicybusinessType.Add("Cancellation");
                lblpolicybusinessTypes.DataSource = lblpolicybusinessType;
                lblpolicybusinessTypes.DataBind();

                var PolicyTypes = nav.PolicyTypes.Where(x => x.Business_Type == "General" &&x.Business_Type_SubCategory=="Motor").ToList();
                List<DropDownList> PolicyTypeslist = new List<DropDownList>();
                foreach (var item in PolicyTypes)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Policy_Type_Code;
                    code.Name = item.Policy_Type_Decription;
                    PolicyTypeslist.Add(code);
                }
                lblpolicytypes.DataSource = PolicyTypeslist;
                lblpolicytypes.DataValueField = "Code";
                lblpolicytypes.DataTextField = "Name";
                lblpolicytypes.DataBind();
                lblpolicytypes.Items.Insert(0, "--Select Policy Type--");

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

                var VehicleModel = nav.VehicleModel.ToList();
                List<DropDownList> VehicleModellist = new List<DropDownList>();
                foreach (var item in VehicleModel)
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

                var BodyTypes = nav.BodyTypes.ToList();
                List<DropDownList> BodyTypeslist = new List<DropDownList>();
                foreach (var item in BodyTypes)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.code;
                    code.Name = item.Description;
                    BodyTypeslist.Add(code);
                }
                vehicletype.DataSource = BodyTypeslist;
                vehicletype.DataValueField = "Code";
                vehicletype.DataTextField = "Name";
                vehicletype.DataBind();
                vehicletype.Items.Insert(0, "--Select Vehicle Code--");

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
            }
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string policyholderNo = policyHolder.SelectedValue.Trim();
            if (policyholderNo.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Policy Holder";
            }
            string policyType = lblpolicytypes.SelectedValue.Trim();
            if (policyType.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Policy Type";
            }
            string typeofApplication = typeofapplications.Text.Trim();
            if (typeofApplication.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Policy Type";
            }
            int selectedIndex1 = lblmodeofpayments.SelectedIndex;
            if (selectedIndex1 < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Mode of Payments";
            }
            int selectedIndex2 = lblproductbillingCycle.SelectedIndex;
            if (selectedIndex2 < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Product Billing Cycle";
            }
            int selectedIndex3 = lblmembertype.SelectedIndex;
            if (selectedIndex3 < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Member Type";
            }
            string agentcode = lblagentCode.SelectedValue.Trim();
            if (agentcode.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Agent Code";
            }
            int selectedIndex4 = lblagentDetails.SelectedIndex;
            if (selectedIndex4 < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Agent Details";
            }
            string financier = lblfanancier.Text.Trim();
            if (financier.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Financier";
            }
            if (policynumbers.Text.Trim().Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Policy Number";
            }
            if (policystartdate.Text.Trim().Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Policy Start Date";
            }
            if (paymentreference.Text.Trim().Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Payment Referrence";
            }
            if (lblpolicybusinessTypes.Text.Trim().Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Business Type";
            }
            try
            {
                if (flag)
                {
                    feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    string empNo = Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnExistingMotorUnderWritingDetails(empNo, policyholderNo, policyType, typeofApplication, selectedIndex1, selectedIndex2, selectedIndex3, selectedIndex4, agentcode, financier);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("MotorNewPolicyQuote.aspx?requisitionNo=" + res[2] + "&step=2");

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
        protected void GetVendorProducts_Onlick(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string tlblpolicyType = lblpolicytypes.SelectedValue.Trim();
            string ttxtinsurers = txtinsurer.SelectedValue.Trim();
            var productDetails = nav.Items.Where(x => x.Insurer == ttxtinsurers && x.Insurance_Item_type == "Insurance" && x.Policy_Type == tlblpolicyType);
            List<DropDownList> tProductsList = new List<DropDownList>();
            foreach (var item in productDetails)
            {
                DropDownList code = new DropDownList();
                code.Code = item.No;
                code.Name = item.Description + "- " + item.Policy_Type;
                tProductsList.Add(code);
            }
            typeofapplications.DataSource = tProductsList;
            typeofapplications.DataTextField = "Name";
            typeofapplications.DataValueField = "Code";
            typeofapplications.DataBind();
            typeofapplications.Items.Insert(0, "--Select Product--");
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
            this.Response.Redirect("MotorNewPolicyQuote.aspx?requisitionNo=" + str + "&step=" + (object)num2);
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
            Response.Redirect("MotorNewPolicyQuote.aspx?requisitionNo=" + str + "&step=" + num2);
        }

        protected void SubmitRiskDetails_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string registrationNo = registrationnumber.Text.Trim();
            if (registrationNo.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Registration No.";
            }
            string tmake = make.SelectedValue.Trim();
            if (tmake.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Make";
            }
            string tmodel = model.SelectedValue.Trim();
            if (tmodel.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Model";
            }
            string tvehicletype = vehicletype.SelectedValue.Trim();
            if (tvehicletype.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Vehicle Type";
            }
            string tcovertype = covertype.SelectedValue.Trim();
            if (tcovertype.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Cover Type";
            }
            string cc = this.cc.Text.Trim();
            if (cc.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for CC";
            }
            string chasisNo = chasisnumber.Text.Trim();
            if (chasisNo.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Chasis Number";
            }
            string engineNo = this.enginenumber.Text.Trim();
            if (engineNo.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Engine Number";
            }
            string yearofManufucture = yearofmanufucture.Text.Trim();
            if (yearofManufucture.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Year of Manufucturer";
            }
            string bodyType = bodytype.Text.Trim();
            if (bodyType.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Body Type";
            }
            string s = policystratdate.Text.Trim();
            if (s.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Policy Start Date";
            }
            DateTime dateTime = new DateTime();
            DateTime exact = DateTime.ParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string tduration = duration.Text.Trim();
            if (tduration.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Duration";
            }
            string ttonnage = tonnage.Text.Trim();
            if (ttonnage.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Tonnage";
            }
            bool nonRenewable = false;
            Decimal sumInsured = Convert.ToDecimal(valuesuminsured.Text.Trim());
            if (sumInsured < 1M)
            {
                flag = true;
                str = "Please Enter a Valid Value for Sum Insured";
            }
            Decimal rate = Convert.ToDecimal(txtrate.Text.Trim());
            if (rate < 1M)
            {
                flag = true;
                str = "Please Enter a Valid Value for Rate";
            }
            string tcertificateNo = certificateNo.Text.Trim();
            if (tcertificateNo.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid Value for Certificate Number";
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
                    var status = new Config().ObjNav().FnNewMotorPolicyRieskDetails(empNo, docNo, "", registrationNo, tmake, tmodel, tvehicletype, tcovertype, cc, chasisNo, engineNo, yearofManufucture, bodyType, exact, tduration, nonRenewable,Convert.ToDecimal(ttonnage), tcertificateNo, sumInsured, rate);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
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
                            string filename = "Logbook" + extension;
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
                            string filename = "IDBirthCertificate " + extension;
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
                            string filename = "KRACertificate" + extension;
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
                            string filename = "ApplicationProposalForm " + extension;
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
            SCPanel.Update();

        }

        protected void Products_Onclick(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string ttxtpolicytype = lblpolicytypes.SelectedValue.Trim();
            typeofapplications.DataSource = (object)nav.Items.Where(x => x.Policy_Type == ttxtpolicytype && x.Insurance_Item_type == "Insurance").ToList();
            typeofapplications.DataTextField = "Description";
            typeofapplications.DataValueField = "No";
            typeofapplications.DataBind();
        }

       
    }
}
