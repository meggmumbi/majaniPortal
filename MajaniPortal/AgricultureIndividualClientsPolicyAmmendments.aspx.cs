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
    public partial class AgricultureIndividualClientsPolicyAmmendments : System.Web.UI.Page
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


                    //Load Financiers

                    hasgrowerNo.Checked = true;

                    //var Conditions = Config.ReturnNav().PreExistingConditions.ToList();
                    //List<DropDownList> Conditionslist = new List<DropDownList>();
                    //foreach (var item in Conditions)
                    //{
                    //    DropDownList code = new DropDownList();
                    //    code.Code = item.code;
                    //    code.Name = item.Description;
                    //    Conditionslist.Add(code);
                    //}
                    //txtConditionName.DataSource = Conditionslist;
                    //txtConditionName.DataValueField = "Code";
                    //txtConditionName.DataTextField = "Name";
                    //txtConditionName.DataBind();
                    //txtConditionName.Items.Insert(0, "--Select Pre Existing Conditions--");



                    List<string> tlblpolicybusinessType = new List<string>();
                    tlblpolicybusinessType.Add("Existing");
           

                    List<DropDownList> lblagentsubcategorylist = new List<DropDownList>();
                    var tlblagentsubcategory = nav.CommissionGroup.ToList();
                    foreach (var item in tlblagentsubcategory)
                    {
                        DropDownList itemlist = new DropDownList();
                        itemlist.Code = item.Code;
                        itemlist.Name = item.Description;
                        lblagentsubcategorylist.Add(itemlist);
                    }
                   

                   

                    List<string> tmodeofpayments = new List<string>();
                    tmodeofpayments.Add("-----Select Grower Type of Applicants-------");
                    tmodeofpayments.Add("KTDA check Off");
                    tmodeofpayments.Add("KTDA Bonus");
                    tmodeofpayments.Add("Mpesa");
                    tmodeofpayments.Add("Other");
                    tmodeofpayments.Add("Corporate Checkoff");
                    tmodeofpayments.Add("Cheque");
                    tmodeofpayments.Add("Bank Deposit");
                    tmodeofpayments.Add("Cheque");
                    tmodeofpayments.Add("Cash Payments");
                    tmodeofpayments.Add("Guarantor Form");
                    tmodeofpayments.Add("Green Leaf");
                    modeofpayments.DataSource = tmodeofpayments;
                    modeofpayments.DataBind();

                   

                    List<string> tagentDetail = new List<string>();
                    tagentDetail.Add("-----Select Agent Detail-------");
                    tagentDetail.Add("Direct Business");
                    tagentDetail.Add("Agent Business");
                    tagentDetail.Add("Refferal Business");
                    agentDetail.DataSource = tagentDetail;
                    agentDetail.DataBind();


                    var livestockDrop = nav.DisplaySheetItems.Where(r => r.Policy_Type == "AGRICULTURAL INSURANCE");
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






                    var ApplicationNumber = Convert.ToString(Request.QueryString["ContractNo"]);
                    if (ApplicationNumber != null)
                    {
                        var Application = nav.ServiceContracts.Where(x => x.Contract_No == ApplicationNumber).ToList();
                        foreach (var item in Application)
                        {
                            var CustomerInfor = nav.Customer.Where(x => x.No == item.Customer_No).ToList();
                            foreach (var itemCustomer in CustomerInfor)
                            {
                                txtfirstname.Text = item.First_Name;
                                customerCategorys.Text = item.Customer_Category;
                                customerSubCategorys.Text = item.Customer_Sub_Category;
                                applicationTypesdetails.Text = item.Applicant_Type;
                                txtMiddleName.Text = item.Middle_Name;
                                txtlastname.Text = item.Last_Name;
                                txtHudumaNo.Text = item.Huduma_No;
                                growerNumber.Text = item.Grower_No_Client_ID;
                                txtFactoryCode.Text = item.Factory_Code_Branch_Code;
                                ttxtFactoryName.Text = item.Factory_Name_Branch_Name;
                                idtype.Text = itemCustomer.ID_Type;
                                txtIdNumber.Text = itemCustomer.ID_No_Passport_No;
                                growerapplicanttypedetails.Text = itemCustomer.Grower_Type_of_Applicant;
                                lblgender.Text = item.Gender;
                                lbltitle.Text = item.Title;
                                countyofresidence.Text = item.Country_Region_Code;
                                lblcountyCode.Text = item.County;
                                krapinNumber.Text = item.KRA_Pin_No;
                                ttxtoccupations.Text = item.Occupation;
                                txtDOB.Text = Convert.ToDateTime(item.Date_of_Birth).ToString("MM/dd/yyyy");
                                telnumber1.Text = item.Tel_Mobile_No;
                                telnumber2.Text = itemCustomer.Tel_Mobile_No_2;
                                txtaddress.Text = item.Address;
                                postcodesdetails.Text = item.Post_Code;
                                lblcities.Text = item.City;
                                txtgoogle.Text = itemCustomer.Google;
                                txttwitter.Text = itemCustomer.Twitter;
                                txtfcebook.Text = itemCustomer.Facebook;
                                txtlinkedin.Text = itemCustomer.LinkedIn;
                                lblmaritalstatus.Text = item.Marital_Status;
                                lbltitle.Text = item.Title;
                                membertypes.Text = item.Policy_Business_Type;
                                lblproducts.Text = item.Product;
                                insurer.Text = item.Insurer;
                                serviceperiod.Text = item.Service_Period;                                
                               
                            }





                        }
                        string tpoduct = lblproducts.Text.Trim();
                        var MedicalSchedule = nav.MedicalSchedule.Where(x => x.Product_Code == tpoduct && x.Premium_TB_Options == "ADULT").ToList();
                        List<DropDownList> MedicalSchedulelist = new List<DropDownList>();
                        foreach (var item in MedicalSchedule)
                        {
                            DropDownList code = new DropDownList();
                            code.Code = item.Benefit_Limit;
                            code.Name = item.Benefit_Limit;
                            MedicalSchedulelist.Add(code);
                        }
                       
                    }

                    
                  

                    financier.Visible = false;
                    growerdetails.Visible = true;
                   
                }
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
                    var status = new Config().ObjNav().FnNewPolicyAmmendmentsIndAgric(docNo);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("AgricultureIndividualClientsPolicyAmmendments.aspx?ContractNo="  + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + res[2] + "&step=2");

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
        protected void previousstep_Click(object sender, EventArgs e)
        {
            int num1;
            string str;
            string GrowerNumber = Request.QueryString["GrowerNo"].Trim();
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
            Response.Redirect("AgricultureIndividualClientsPolicyAmmendments.aspx?requisitionNo=" + str  + "&step=" + num2);
        }
        protected void SubmitCommunicationDetails_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string docNo = Request.QueryString["ContractNo"].Trim();
            
            string CustomerNo = Request.QueryString["CustomerNo"].Trim();
            string QuoteNo = Request.QueryString["QuoteNo"].Trim();

            //string ttelnumber1 = telnumber1.Text.Trim();
            //if (ttelnumber1.Length < 1)
            //{
            //    flag = true;
            //    str = "Please fill all highlighted fields with *(Mandatory Fields)";
            //}

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
            //if (ttxtaddress.Length < 1)
            //{
            //    flag = true;
            //    str = "Please fill all highlighted fields with *(Mandatory Fields)";
            //}
            string ttxtlinkedin = txtlinkedin.Text.Trim();

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
                    Response.Redirect("AgricultureIndividualClientsPolicyAmmendments.aspx?ContractNo="  + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=3");

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
            decimal tpremiumrating = 0;
            string tgrowerNumber = "";

            int hasbinder = Convert.ToInt32(hasBinder.SelectedValue);
            if (hasbinder == 1)
            {
                tpremiumrating = Convert.ToDecimal(premiumrating.Text.Trim());
            }

            string product = lblproducts.Text.Trim();
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
                    string ApplicationNumber = Request.QueryString["QuoteNo"].Trim();
                    ApplicationNumber = ApplicationNumber.Replace('/', '_');
                    ApplicationNumber = ApplicationNumber.Replace(':', '_');
                    string path1 = Config.FilesLocation() + "Agriculture Underwriting/";
                    string rQuisitionNo = Request.QueryString["QuoteNo"];
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



                    string docNo = this.Request.QueryString["QuoteNo"].Trim();
                    string tContractNo = Request.QueryString["ContractNo"].Trim();
                    var Applicant = Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnIndividualupdateAgriculturePolicyDetails(docNo, "", product, tmodepayment, tAgentDetail, tpaymentRefCode, agentcode,
                         tPolicyStartDate, tpymentOpt, tpremiumrating, tinsurer, hasbinder, tgrowerapplicanttype, tgrowerNumber, tfactoryCode, tfactoryName, thasgrowerNo);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("AgricultureIndividualClientsPolicyAmmendments.aspx?QuoteNo=" + docNo + "&&step=4" + "&&product=" + product+ "&&ContractNo="+ tContractNo);

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
        protected void SubmitApplication_Click(object sender, EventArgs e)
        {
            try
            {
                var step = Convert.ToInt32(Request.QueryString["step"].Trim());
                var Requisition = Request.QueryString["QuoteNo"].Trim();
                var status = new Config().ObjNav().SendIndividualKYMPolicyAmmendmentApproval(Requisition);
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
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void UploadDocumentsApplication_Click(object sender, EventArgs e)
        {
            try
            {

                
                string ApplicationNumber = Request.QueryString["QuoteNo"].Trim();
                //string GrowerNumber = Request.QueryString["GrowerNumber"].Trim();
                ApplicationNumber = ApplicationNumber.Replace('/', '_');
                ApplicationNumber = ApplicationNumber.Replace(':', '_');

                string rQuisitionNo = Request.QueryString["QuoteNo"];
                string path1 = Config.FilesLocation() + "Agriculture Amendments/";
                string str1 = Convert.ToString(ApplicationNumber);

                

                string folderName = path1 + str1 + "/";
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
                            
                            filetoupload.SaveAs(folderName + filename);
                            Config.navExtender.AddLinkToRecord("Agriculture Policy Amendment", rQuisitionNo, fullfileName, "");
                          

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
                            string filename = "OtherDocument " + extension;
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
                            Config.navExtender.AddLinkToRecord("Agriculture Policy Amendment", rQuisitionNo, fullfileName, "");
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
                            string filename = "idpassport " + extension;
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
                            Config.navExtender.AddLinkToRecord("Agriculture Policy Amendment", rQuisitionNo, fullfileName, "");
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
                    message += "Kindly Upload the document before you proceed" + ex;

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
                    
                }
            }
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
        protected void GetProductsdetails_Onlick(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();

            var productDetails = nav.Items.Where(x => x.Policy_Type == "AGRICULTURAL INSURANCE" && x.Insurance_Item_type == "Insurance" && x.No == lblproducts.Text);
            foreach (var item in productDetails)
            {
                insurer.Text = item.Insurer;
                serviceperiod.Text = item.Service_Period;
                //txtpolicyno.Text = item.Last_Policy_No_Used;
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
                string tAge = age.Text;
                string tmilkProd = milkProd.Text.Trim();
                decimal tvalueInsured = Convert.ToDecimal(valueInsured.Text);
                string docNo = Request.QueryString["QuoteNo"];
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
                if (tAge.Length < 1)
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
                    String status = new Config().ObjNav().FnInsterAgricultureDetailsAmmend(docNo, tNameOfAnimal, tlivestock, tearTag, tAnimalbreed, tlivestocksex, tAge, tmilkProd, tvalueInsured, tproduct);
                    String[] info = status.Split('*');
                    if (info[0] == "success")
                    {
                        var nav = Config.ReturnNav();
                        var Application = nav.SalesHeader.Where(x => x.No == docNo).ToList();
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
        protected void nextBtn_Click(object sender, EventArgs e)
        {

            string docNo = Request.QueryString["QuoteNo"];
            string tproduct = Request.QueryString["product"];
            Response.Redirect("AgricultureIndividualClientsPolicyAmmendments.aspx?QuoteNo=" + docNo + "&step=5"+ "&product=" + tproduct);
        }
        protected void backtostep3_Click(object sender, EventArgs e)
        {
            string docNo = Request.QueryString["QuoteNo"];
            string tproduct = Request.QueryString["product"];
            Response.Redirect("AgricultureIndividualClientsPolicyAmmendments.aspx?QuoteNo=" + docNo + "&step=3" + "&product=" + tproduct);
        }

        protected void delit_Click(object sender, EventArgs e)
        {
            var tConditioncodetoRemove = removedependantCode.Text.Trim();
            string docNo = Request.QueryString["QuoteNo"].Trim();
            var Applicant = Session["empNo"].ToString();
            var status = new Config().ObjNav().FnRemoveRiskAmend(tConditioncodetoRemove, docNo);
            var res = status.Split('*');
            if (res[0] == "success")
            {
                physicalLocations.InnerHtml = "<div class='alert alert-success'>" + res[1] + "</div>";

            }
            else
            {
                physicalLocations.InnerHtml = "<div class='alert alert-danger'>" + res[1] + "</div>";

            }
        }
    }
}