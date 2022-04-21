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
    public partial class KYMWithdrawalForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NAV nav = Config.ReturnNav();
                List<DropDownList> customerslist = new List<DropDownList>();
                //var customers = nav.Customer.ToList();
                //foreach (var item in customers)
                //{
                //    DropDownList itemlist = new DropDownList();
                //    itemlist.Code = item.No;
                //    itemlist.Name = item.Name;
                //    customerslist.Add(itemlist);
                //}

                var Profle = Convert.ToString(Session["Profile"]);
                var empNo = Session["empNo"].ToString();
                string profileType = "";
                string profileCode = "";

                var employee = nav.Employees.Where(x => x.No == empNo).ToList();
                foreach (var user in employee)
                {
                    if (Profle == "Region")
                    {
                        profileType = "Region";
                        profileCode = user.Region_Code;
                    }
                    if (Profle == " Zone")
                    {
                        profileType = "Zone";
                        profileCode = user.Zone_Code;
                    }
                    if (Profle == " Factory")
                    {
                        profileType = "Factory";
                        profileCode = user.Factory_name;
                    }
                    if (Profle == "Branch")
                    {
                        profileType = "Branch";
                        profileCode = user.Global_Dimension_2_Code;
                    }
                }

                string AllCustomers = new Config().ObjNav().FnCustomerList(profileCode, profileType);
                String[] info = AllCustomers.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                if (info != null)
                {
                    foreach (var allInfo in info)
                    {
                        String[] arr = allInfo.Split('*');
                        DropDownList itemlist = new DropDownList();
                        itemlist.Code = arr[0];
                        itemlist.Name = arr[1];
                        customerslist.Add(itemlist);
                    }
                }



                customernumbers.DataSource = customerslist;
                customernumbers.DataValueField = "Code";
                customernumbers.DataTextField = "Name";
                customernumbers.DataBind();
                customernumbers.Items.Insert(0, "--Select Customer Name--");


                List<string> tstatusammendment = new List<string>();
                tstatusammendment.Add("-----Select Status Ammendment-------");
                tstatusammendment.Add("Lapse");
                tstatusammendment.Add("Expire");
                tstatusammendment.Add("Cancel");
                statusammendment.DataSource = tstatusammendment;
                statusammendment.DataBind();

                List<string> tstatusammendmentreason = new List<string>();
                tstatusammendmentreason.Add("-----Select Status Ammendment  Reason-------");
                tstatusammendmentreason.Add("Lapse");
                tstatusammendmentreason.Add("Expire");
                tstatusammendmentreason.Add("Cancel");
                statusammendmentreason.DataSource = tstatusammendmentreason;
                statusammendmentreason.DataBind();


            }

        }
        protected void GetCustomerDetails_Click(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string tcustomerNumber = customernumbers.SelectedValue.Trim();
            var customers = nav.Customer.Where(c => c.No == tcustomerNumber).ToList();
            foreach (var item in customers)
            {
                firstname.Text = item.First_Name;
                lastname.Text = item.Last_Name;
                middlename.Text = item.Middle_Name;
                idnumber.Text = item.ID_No_Passport_No;
                growerno.Text = item.Grower_No_Client_ID;
                factorycode.Text = item.Factory_Code_Branch_Code;
                factoryname.Text = item.Factory_Name_Branch_Name;
                corporatename.Text = item.Corporate_Company_Name;

            }

            var policydetails = nav.PolicyList.Where(c => c.Customer_No == tcustomerNumber && c.Business_Type == "Micro-Insurance").ToList();
            List<DropDownList> policydetailslist = new List<DropDownList>();
            foreach (var item in policydetails)
            {
                DropDownList code = new DropDownList();
                code.Code = item.Contract_No;
                code.Name = item.Name;
                policydetailslist.Add(code);
            }
            policynumber.DataSource = policydetails;
            policynumber.DataValueField = "Contract_No";
            policynumber.DataTextField = "Name";
            policynumber.DataBind();
            policynumber.Items.Insert(0, "--Select Policy No--");
        }

        protected void GetContractDetails_Click(object sender, EventArgs e)
        {
            NAV nav = Config.ReturnNav();
            string tpolicynumber = policynumber.SelectedValue.Trim();
            var policydetails = nav.PolicyList.Where(c => c.Contract_No == tpolicynumber && c.Business_Type == "Micro-Insurance").ToList();
            foreach (var item in policydetails)
            {
                statusamendment.Text = item.Product;

            }
        }
        protected void SubmitWithrawals(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string tcustomerNumber = customernumbers.SelectedValue.Trim();
            if (tcustomerNumber.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tpolicynumber = policynumber.SelectedValue.Trim();
            if (tpolicynumber.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            string tdateofwithdrawal = dateofwithdrawal.Text.Trim();
            if (tdateofwithdrawal.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            int tstatusammendment = statusammendment.SelectedIndex;
            if (tstatusammendment < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            int tstatusammendmentreason = statusammendmentreason.SelectedIndex;
            if (tstatusammendmentreason < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mandatory Fields)";
            }
            if (flag)
            {
                feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
            }
            else
            {
                DateTime withdrawaldate = DateTime.ParseExact(tdateofwithdrawal, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var status = new Config().ObjNav().FnKYMWithdrawal(tcustomerNumber, tpolicynumber, withdrawaldate, tstatusammendment, tstatusammendmentreason);
                var res = status.Split('*');
                if (res[0] == "success")
                {
                    Response.Redirect("KYMWithdrawalForm.aspx?requisitionNo=" + res[2] + "&step=2");
                    feedbackdetails.InnerHtml = "<div class='alert alert-success'>The Withdrawal Application Details was successfully submitted" + "</div>";

                }
                else
                {
                    feedbackdetails.InnerHtml = "<div class='alert alert-danger'>The Withdrawal Application Details Could not be Submitted.Kindly Try Again" + res[1] + "</div>";

                }
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
            Response.Redirect("KYMWithdrawalForm.aspx?requisitionNo=" + str + "&step=" + num2);
        }
        protected void SubmitApplication_Click(object sender, EventArgs e)
        {
            try
            {
                var step = Convert.ToInt32(Request.QueryString["step"].Trim());
                var Requisition = Request.QueryString["requisitionNo"].Trim();
                Response.Redirect("Default.aspx");
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

                string ApplicationNumber = Request.QueryString["requisitionNo"].Trim();
                ApplicationNumber = ApplicationNumber.Replace('/', '_');
                ApplicationNumber = ApplicationNumber.Replace(':', '_');
                string path1 = Config.FilesLocation() + "Withdrawals/";
                string str1 = Convert.ToString(ApplicationNumber);
                string folderName = path1 + str1 + "/";
                bool error = false;
                string message = "";
                try
                {
                    if (uploadwithdrawaletter.HasFile)
                    {
                        string extension = System.IO.Path.GetExtension(uploadwithdrawaletter.FileName);
                        //if (new Config().IsAllowedExtension(extension))
                        //{
                        string filename = ApplicationNumber + "_Withdrawal Letter" + extension;
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                        }
                        if (File.Exists(folderName + filename))
                        {
                            File.Delete(folderName + filename);
                        }
                        uploadwithdrawaletter.SaveAs(folderName + filename);
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
                        message += "Kindly Upload the Withdrawal Letter before you proceed";

                    }
                }
                catch (Exception ex)
                {
                    error = true;
                    message += message.Length > 0 ? "<br>" : "";
                    message += "Kindly Upload the Withdrawal Letter before you proceed" + ex;
                }
                try
                {
                    if (uploadother.HasFile)
                    {
                        string extension = System.IO.Path.GetExtension(uploadother.FileName);
                        //if (new Config().IsAllowedExtension(extension))
                        //{
                        string filename = ApplicationNumber + "_Other Document" + extension;
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                        }
                        if (File.Exists(folderName + filename))
                        {
                            File.Delete(folderName + filename);
                        }
                        uploadother.SaveAs(folderName + filename);
                        //}
                        //else
                        //{
                        //    error = true;
                        //    message += message.Length > 0 ? "<br>" : "";
                        //    message += "The file extension of the ID or Certificate of Incorporation   is not allowed";
                        //}

                    }
                    //else
                    //{
                    //    error = true;
                    //    message += message.Length > 0 ? "<br>" : "";
                    //    message += "Kindly Upload the ID or Certificate of Incorporation   before you proceed";
                    //}
                }
                catch (Exception ex)
                {
                    error = true;
                    message += message.Length > 0 ? "<br>" : "";
                    message += "Kindly Upload Other Documents before you proceed" + ex;
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
    }
}

