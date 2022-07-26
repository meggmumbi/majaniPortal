using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class WelfareBenefit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                getWelfareDesc();
            }
        }

        public void getWelfareDesc()
        {
            var nav =  Config.ReturnNav();
            var benefits = nav.BenefitsMatrixCategory.ToList();
            List<Employee> allJobs = new List<Employee>();
            foreach (var myJob in benefits)
            {
                Employee employee = new Employee();
                employee.EmployeeNo = myJob.Benefit_Type;
                employee.EmployeeName = myJob.Benefit_Description + " - " + myJob.Beneficiary_Category;
                allJobs.Add(employee);
            }
            welfarecode.DataSource = allJobs;
            welfarecode.DataValueField = "EmployeeNo";
            welfarecode.DataTextField = "EmployeeName";
            welfarecode.DataBind();

        }

        protected void Next_Click(object sender, EventArgs e)
        {
            string benefitNo = Convert.ToString(Session["benefitNo"]);
            Response.Redirect("WelfareBenefit.aspx?step=2&&benefitNo=" + benefitNo);
        }

        protected void uploadDocument_Click(object sender, EventArgs e)
        {

            String filesFolder = ConfigurationManager.AppSettings["FilesLocationHrPortal"] + "Request Welfare  Benefit/";
            //String filesFolder = ConfigurationManager.AppSettings["FilesLocation"] + "Staff Claim/";

            if (document.HasFile)
            {
                try
                {
                    if (Directory.Exists(filesFolder))
                    {
                        String extension = System.IO.Path.GetExtension(document.FileName);
                        if (new Config().IsAllowedExtension(extension))
                        {
                            String imprestNo = Request.QueryString["benefitNo"];
                            string imprest = imprestNo;
                            imprestNo = imprestNo.Replace('/', '_');
                            imprestNo = imprestNo.Replace(':', '_');
                            String documentDirectory = filesFolder + imprestNo + "/";
                            Boolean createDirectory = true;
                            try
                            {
                                if (!Directory.Exists(documentDirectory))
                                {
                                    Directory.CreateDirectory(documentDirectory);
                                }
                            }
                            catch (Exception ex)
                            {
                                createDirectory = false;
                                documentsfeedback.InnerHtml =
                                                                "<div class='alert alert-danger'>'" + ex.Message + "'. Please try again" +
                                                                "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                                //We could not create a directory for your documents
                            }
                            if (createDirectory)
                            {
                                string filename = documentDirectory + document.FileName;
                                if (File.Exists(filename))
                                {
                                    documentsfeedback.InnerHtml =
                                            "<div class='alert alert-danger'>A document with the given name already exists. Please delete it before uploading the new document or rename the new document<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                                }
                                else
                                {
                                    document.SaveAs(filename);
                                    if (File.Exists(filename))
                                    {

                                        //Config.navExtender.AddLinkToRecord("Imprest Memo", imprestNo, filename, "");
                                        Config.navExtender.AddLinkToRecord("Request Welfare  Benefit", imprest, filename, "");
                                        documentsfeedback.InnerHtml =
                                        "<div class='alert alert-success'>The document was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                                    }
                                    else
                                    {
                                        documentsfeedback.InnerHtml =
                                            "<div class='alert alert-danger'>The document could not be uploaded. Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                                    }
                                }
                            }
                        }
                        else
                        {
                            documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The document's file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                        }

                    }
                    else
                    {
                        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The document's root folder defined does not exist in the server. Please contact support. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    }

                }
                catch (Exception ex)
                {
                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>'" + ex.Message + "'. Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    //The document could not be uploaded
                }
            }
            else
            {
                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>Please select the document to upload. (or the document is empty) <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";


            }

        }

        protected void Previous_Click(object sender, EventArgs e)
        {
            Response.Redirect("WelfareBenefit.aspx");
        }

        protected void sendapproval_Click(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            try
            {
                String tFileName = fileName.Text.Trim();
                String filesFolder = ConfigurationManager.AppSettings["FilesLocation"] + "Request Welfare  Benefit/";
                String imprestNo = Request.QueryString["benefitNo"];
                imprestNo = imprestNo.Replace('/', '_');
                imprestNo = imprestNo.Replace(':', '_');
                String documentDirectory = filesFolder + imprestNo + "/";
                String myFile = documentDirectory + tFileName;
                if (File.Exists(myFile))
                {
                    File.Delete(myFile);
                    if (File.Exists(myFile))
                    {
                        documentsfeedback.InnerHtml = "<div class='alert alert-danger'>The file could not be deleted <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    }
                    else
                    {
                        documentsfeedback.InnerHtml = "<div class='alert alert-success'>The file was successfully deleted <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    }
                }
                else
                {
                    documentsfeedback.InnerHtml = "<div class='alert alert-danger'>A file with the given name does not exist in the server <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }



            }
            catch (Exception m)
            {
                documentsfeedback.InnerHtml = "<div class='alert alert-danger'>" + m.Message + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

            }

        }

        protected void welfarecode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Boolean error = false;
                string message = "";
                String WelfareCode = welfarecode.SelectedValue;
                String Description = description.Text.Trim();
                int tWelfareCode = 0;
                try
                {
                    tWelfareCode = Convert.ToInt32(WelfareCode);
                }
                catch (Exception)
                {
                    error = true;
                    message = "Please select welfare code";
                }
                if (error == true)
                {
                    membershipFeedback.InnerHtml = "<div class='alert alert-danger'> '" + message + "'<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                }
                else
                {
                    try
                    {
                        string empNo = Session["employeeNo"].ToString();
                        string benefitNo = "";
                        var status = new Config().ObjNav().RequestWelfareBenefit(benefitNo, empNo, tWelfareCode, Description);

                        string[] info = status.Split('*');
                        if (info[0] == "success")
                        {
                            Session["benefitNo"] = info[2];
                            welfarecategory.Text = info[3];
                            benefitallocation.Text = info[4];

                            membershipFeedback.InnerHtml = "<div class='alert alert-success'>" + info[1] + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                        }
                        else
                        {
                            membershipFeedback.InnerHtml = "<div class='alert alert-danger'>" + info[1] + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                        }
                    }
                    catch (Exception ex)
                    {

                        membershipFeedback.InnerHtml = "<div class='alert alert-danger'> '" + ex.Message + "'<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    }
                }
            }
            catch (Exception m)
            {
                membershipFeedback.InnerHtml = "<div class='alert alert-danger'> '" + m.Message + "'<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
            }
        }
    }
}