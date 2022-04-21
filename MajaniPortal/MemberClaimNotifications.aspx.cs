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
    public partial class MemberClaimNotifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
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
                lblcustomers.DataSource = list;
                lblcustomers.DataValueField = "Code";
                lblcustomers.DataTextField = "Name";
                lblcustomers.DataBind();
                lblcustomers.Items.Insert(0, "--Select Customer--");


                List<string> lblclaimagainsts = new List<string>();
                lblclaimagainsts.Add("-----Select Claim Against-------");
                lblclaimagainsts.Add("Principal");
                lblclaimagainsts.Add("Dependant");
                lblclaimagainst.DataSource = lblclaimagainsts;
                lblclaimagainst.DataBind();

                List<string> lblclaimcategorys = new List<string>();
                lblclaimcategorys.Add("-----Select Claim Category-------");
                lblclaimcategorys.Add("Medical");
                lblclaimcategorys.Add("Death");
                lblclaimcategory.DataSource = lblclaimcategorys;
                lblclaimcategory.DataBind();

                List<string> lblplaceofOccurrence = new List<string>();
                lblplaceofOccurrence.Add("-----Select Place of Occurrences-------");
                lblplaceofOccurrence.Add("Hospital");
                lblplaceofOccurrence.Add("Home");
                lblplaceofOccurrence.Add("Other");
                lblplaceofOccurrences.DataSource = lblplaceofOccurrence;
                lblplaceofOccurrences.DataBind();

                var CustomerCategoryQuery = nav.CustomerCategory.ToList();
                List<DropDownList> CustomerCategoryQuerylist = new List<DropDownList>();
                foreach (var item in CustomerCategoryQuery)
                {
                    DropDownList code = new DropDownList();
                    code.Code = item.Code;
                    code.Name = item.Description;
                    list.Add(code);
                }
                customercategory.DataSource = CustomerCategoryQuerylist;
                customercategory.DataValueField = "Code";
                customercategory.DataTextField = "Name";
                customercategory.DataBind();
                customercategory.Items.Insert(0, "--Select Customer Category Code--");
            }
        }

        protected void SubmitApplication_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string custNo = lblcustomers.SelectedValue.Trim();
            if (custNo.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Customers";
            }
            string policyNo = lblpolicynumber.SelectedValue.Trim();
            if (policyNo.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Policy No";
            }
            int selectedIndex1 = lblclaimagainst.SelectedIndex;
            if (selectedIndex1 < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Claim Against";
            }
            string dependantNo = lbldependantNumber.Text.Trim();
            if (dependantNo.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Dependent No.";
            }
            int selectedIndex2 = lblclaimcategory.SelectedIndex;
            if (selectedIndex2 < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Claim Category";
            }
            string s = dateofaccident.Text.Trim();
            if (s.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Date of Accident";
            }
            DateTime dateTime = new DateTime();
            DateTime exact = DateTime.ParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture);
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
            string customerCategory = customercategory.Text.Trim();
            if (customerCategory.Length < 1)
            {
                flag = true;
                str = "Please Enter a Valid  Value for Customer Category";
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
                    var status = new Config().ObjNav().FncreateClaimNotification(docNo, custNo, requestor, policyNo, selectedIndex1, dependantNo, selectedIndex2, placeOfOccurence, customerCategory,"",0);
                    var res = status.Split('*');
                    if (res[0] == "success")
                        Response.Redirect("NewClaimNotification.aspx?requisitionNo=" + res[2] + "&step=2");
                    else
                        feedbackdetails.InnerHtml = "<div class='alert alert-danger'>The New Claim Notification Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";
                }
            }
            catch (Exception ex)
            {
                feedbackdetails.InnerHtml = "<div class='alert alert-danger'>We experienced an error while adding the Applications. Kindly Fill in all the Client Applications Details." + ex.Message + "</div>";
            }
        }

        protected void PolicyDetails_OnClick(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string tlblcustomers = lblcustomers.SelectedValue.Trim();
            lblpolicynumber.DataSource = nav.ServiceContracts.Where(x => x.Contract_Insurance_Type == "Insurance" && x.Customer_No == tlblcustomers).ToList();
            lblpolicynumber.DataTextField = "Contract_No";
            lblpolicynumber.DataValueField = "Contract_No";
            lblpolicynumber.DataBind();
        }

        protected void DependantsDetails_OnClick(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string tlblcustomers = lblcustomers.SelectedValue.Trim();
            lbldependantNumber.DataSource = nav.ActualPolicyDependants.Where(x => x.Client_No == tlblcustomers).ToList();
            lbldependantNumber.DataTextField = "Name";
            lbldependantNumber.DataValueField = "Dependant_Code";
            lbldependantNumber.DataBind();
        }

        protected void upload_Click(object sender, EventArgs e)
        {
            string path1 = ConfigurationManager.AppSettings["FilesLocation"] + "Existing Policy/";
            string str1 = Request.QueryString["requisitionNo"].Trim().Replace('/', '_').Replace(':', '_');
            string path2 = path1 + str1 + "/";
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
                                string str3 = path2 + str2;
                                string str4 = str3;
                                filetoupload.SaveAs(str3);
                                if (File.Exists(str3))
                                    documentsfeedback.InnerHtml = "<div class='alert alert-success'>The Documents was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                                else
                                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document could not be uploaded. " + str4 + " Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                            }
                            else
                                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Document  file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                        }
                        else
                            documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents folder defined does not exist in the server. Please contact support. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    }
                    else
                        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again Later<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                catch (Exception ex)
                {
                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The Documents could not be uploaded. Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
            }
            else
                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>Please select the documents to upload. Both are required <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
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
                    string docNo = this.Request.QueryString["requisitionNo"].Trim();
                    var status = new Config().ObjNav().PushClaimNotificationForValidation(docNo);
                    var res = status.Split('*');
                    if (res[0] == "success")
                        documentsfeedback.InnerHtml = "<div class='alert alert-success'>The New Claim Notification Details Was Successfully Sent for Validations</div>";
                    else
                        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The New Claim Notification Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";
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
            Response.Redirect("NewClaimNotification.aspx?requisitionNo=" + str + "&step=" + num2);
        }

        protected void previousstep_Click(object sender, EventArgs e)
        {
            int num1;
            string str;
            try
            {
                num1 = Convert.ToInt32(this.Request.QueryString["step"].Trim());
                str = Request.QueryString["requisitionNo"].Trim();
            }
            catch (Exception ex)
            {
                num1 = 0;
                str = "";
            }
            int num2 = num1 - 1;
            Response.Redirect("NewClaimNotification.aspx?requisitionNo=" + str + "&step=" + num2);
        }
    }
}
