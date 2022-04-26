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
    public partial class AgricultureCorporatePolicyAmmendments : System.Web.UI.Page
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
                    modeofpaymentss.DataSource = tmodeofpayments;
                    modeofpaymentss.DataBind();

                    List<string> tlblpolicybusinessType = new List<string>();
                    tlblpolicybusinessType.Add("Existing");
                    membertypes.DataSource = tlblpolicybusinessType;
                    membertypes.DataBind();

           

   

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


                    var ttNatureofBusiness = nav.NatureofBusiness.ToList();
                    List<DropDownList> ttNatureofBusinesslist = new List<DropDownList>();
                    foreach (var item in ttNatureofBusiness)
                    {
                        DropDownList itemcodelist = new DropDownList();
                        itemcodelist.Code = item.Code;
                        itemcodelist.Name = item.Name;
                        ttNatureofBusinesslist.Add(itemcodelist);
                    }


                    List<string> productbillingcycles = new List<string>();
                    productbillingcycles.Add("-----Select Product Billing Cycle-------");
                    productbillingcycles.Add("Month");
                    invoiceperiod.DataSource = productbillingcycles;
                    invoiceperiod.DataBind();

             

                    var ApplicationNumber = Convert.ToString(Request.QueryString["ContractNo"]);
                    if (ApplicationNumber != null)
                    {
                        var Application = nav.ServiceContracts.Where(x => x.Contract_No == ApplicationNumber).ToList();
                        foreach (var item in Application)
                        {
                            var CustomerInfor = nav.Customer.Where(x => x.No == item.Customer_No).ToList();
                            foreach (var itemCustomer in CustomerInfor)
                            {
                                customerCategorydetails.Text = item.Customer_Category;
                                subcustomerCategordetail.Text = item.Customer_Sub_Category;
                                applicanttypes.Text = item.Applicant_Type;
                                growerNumber.Text = item.Grower_No_Client_ID;
                                txtFactoryCode.Text = item.Factory_Code_Branch_Code;
                                ttxtFactoryName.Text = item.Factory_Name_Branch_Name;
                                growerapplicanttypes.Text = itemCustomer.Grower_Type_of_Applicant;
                                txtcompanyname.Text = itemCustomer.Company_Name;
                                countryresidences.Text = itemCustomer.Nationality;
                                lblcountiess.Text = item.County;
                                telnumber1.Text = item.Tel_Mobile_No;
                                telnumber2.Text = itemCustomer.Tel_Mobile_No_2;
                                txtaddress.Text = item.Address;
                                tnatureofbusinessess.Text = item.Nature_of_Business_Sector;
                                certificateofincpoperation.Text = itemCustomer.Cert_of_Incorporation_No;
                                officelocation.Text = itemCustomer.Office_Location;
                                txtbuilding.Text = itemCustomer.Building;
                                bankaccountNumber.Text = itemCustomer.Bank_A_C_No;
                                bankaccountname.Text = itemCustomer.Bank_Name;
                                krapinnumber.Text = item.KRA_Pin_No;
                                txtgoogle.Text = itemCustomer.Google;
                                txttwitter.Text = itemCustomer.Twitter;
                                txtfcebook.Text = itemCustomer.Facebook;
                                txtlinkedin.Text = itemCustomer.LinkedIn;
                                lblproduct.Text = item.Product;
                                insurer.Text = item.Insurer;
                                serviceperiod.Text = item.Service_Period;
                                lbldepartmentdetails.Text = item.Business_Type;
                                lblpolicyTypedetails.Text = item.Policy_Type;
                                lblproduct.Text = item.Product;
                                insurer.Text = item.Insurer;
                                serviceperiod.Text = item.Service_Period;
                                dailyhealthbenefits.SelectedValue = item.DHB;
                            }
                        }
                        string tpoduct = lblproduct.Text.Trim();
                        var MedicalSchedule = nav.MedicalSchedule.Where(x => x.Product_Code == tpoduct && x.Premium_TB_Options == "ADULT").ToList();
                        List<DropDownList> MedicalSchedulelist = new List<DropDownList>();
                        foreach (var item in MedicalSchedule)
                        {
                            DropDownList code = new DropDownList();
                            code.Code = item.Benefit_Limit;
                            code.Name = item.Benefit_Limit;
                            MedicalSchedulelist.Add(code);
                        }
                        dailyhealthbenefits.DataSource = MedicalSchedulelist;
                        dailyhealthbenefits.DataValueField = "Code";
                        dailyhealthbenefits.DataTextField = "Name";
                        dailyhealthbenefits.DataBind();
                        dailyhealthbenefits.Items.Insert(0, "--Select DHB--");
                    }

                    hasgrowerNo.Checked = true;
                    growerdetails.Visible = true;

                    List<string> tdependantconditions = new List<string>();
           

                    List<string> tagentDetail = new List<string>();
                    tagentDetail.Add("-----Select Agent Detail-------");
                    tagentDetail.Add("Direct Business");
                    tagentDetail.Add("Agent Business");
                    tagentDetail.Add("Refferal Business");
                    agentDetail.DataSource = tagentDetail;
                    agentDetail.DataBind();

                    financier.Visible = false;

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
                        Response.Redirect("AgricultureCorporatePolicyAmmendments.aspx?ContractNo=" + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + res[2] + "&step=2");

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
        protected void SubmitCommunicationDetails_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string docNo = Request.QueryString["ContractNo"].Trim();            
            string CustomerNo = Request.QueryString["CustomerNo"].Trim();
            string QuoteNo = Request.QueryString["QuoteNo"].Trim();

            string ttelnumber2 = telnumber2.Text.Trim();
            string txtfacebook = txtfcebook.Text.Trim();
            string ttxtemail = txtemail.Text.Trim();
            string ttxttwitter = txttwitter.Text.Trim();
            string ttxtaddress = txtaddress.Text.Trim();
            string ttxtlinkedin = txtlinkedin.Text.Trim();
            string ttxtgoogle = txtgoogle.Text.Trim();
            try
            {
                if (flag)
                {
                    communicationfeedbackDetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                }
                else
                {
                    Response.Redirect("AgricultureCorporatePolicyAmmendments.aspx?ContractNo=" +    docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=3");

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
            Response.Redirect("AgricultureCorporatePolicyAmmendments.aspx?requisitionNo=" + str +  "&step=" + num2);
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
        protected void SubmitPolicyDetails_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            var dhb = dailyhealthbenefits.SelectedValue.Trim();
            int tmodeofpaymentss = modeofpaymentss.SelectedIndex;
            if (tmodeofpaymentss < 1)
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
            string tlblagentsubcategorydetail = lblagentsubcategorydetail.SelectedValue.Trim();
            if (tlblagentsubcategorydetail.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tlblsalesgentcode = lblsalesgentcode.SelectedValue.Trim();
            if (tlblsalesgentcode.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tttxtreferalmobilenumber = txtreferalmobilenumber.Text.Trim();
            int ttxtreferalmobilenumber = 0;
            if (tttxtreferalmobilenumber.Length > 1)
            {
                ttxtreferalmobilenumber = Convert.ToInt32(tttxtreferalmobilenumber);
            }
            string ttxtrefferalname = txtrefferalname.Text.Trim();
            try
            {
                if (flag)
                {
                    policyfeedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    string docNo = Request.QueryString["ContractNo"].Trim();
                    string GrowerNo = Request.QueryString["GrowerNo"].Trim();
                    string CustomerNo = Request.QueryString["CustomerNo"].Trim();
                    string QuoteNo = Request.QueryString["QuoteNo"].Trim();
                    var Applicant = Session["empNo"].ToString();
                    var status = new Config().ObjNav().FnPolicyAmmendmentsUpdates(QuoteNo, dhb, tmodeofpaymentss, tagentDetail, tlblagentsubcategorydetail, tlblsalesgentcode, ttxtrefferalname, ttxtreferalmobilenumber);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        Response.Redirect("AgricultureCorporatePolicyAmmendments.aspx?ContractNo=" + docNo + "&&CustomerNo=" + CustomerNo + "&&QuoteNo=" + QuoteNo + "&step=4");

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
        protected void nextBtn_Click(object sender, EventArgs e)
        {

            string docNo = Request.QueryString["requisitionNo"];
            string tproduct = Request.QueryString["product"];
            Response.Redirect("AgricultureCorporatePolicyAmmendments.aspx?requisitionNo=" + docNo + "&product=" + tproduct);
        }
        protected void backtostep3_Click(object sender, EventArgs e)
        {
            string docNo = Request.QueryString["requisitionNo"];
            string tproduct = Request.QueryString["product"];
            Response.Redirect("AgricultureIndividualClientApplication.aspx?requisitionNo=" + docNo + "&step=3" + "&product=" + tproduct);
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


    }
}