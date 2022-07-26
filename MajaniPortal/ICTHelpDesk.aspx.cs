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
    public partial class ICTHelpDesk : System.Web.UI.Page
    {
       

         protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getCategories();
            }

        }

        protected void addICTHelpDeskRequest_Click(object sender, EventArgs e)
        {
            try
            {
               
                String filesFolder = ConfigurationManager.AppSettings["FilesLocationHrPortal"] + "HELPDESK/";
                Boolean error = false;
                string message = "";
                string ictCategories = category.SelectedValue.Trim();
                string desc = Description.Text.ToString();
                if (string.IsNullOrEmpty(desc))
                {
                    error = true;
                    message = "Please enter description ";

                }
                if (error)
                {
                    ictFeedback.InnerHtml = "<div class='alert alert-danger'> '" + message + "'<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                }
                else
                {
                    




                    string empNo = Session["employeeNo"].ToString();
                    var status = new Config().ObjNav().CreateIctRequest(empNo, desc, ictCategories);
                    string[] info = status.Split('*');
                    if (info[0] == "success")
                    {

                        if (document.HasFile)
                        {
                            try
                            {
                                if (Directory.Exists(filesFolder))
                                {
                                    String extension = System.IO.Path.GetExtension(document.FileName);
                                    if (new Config().IsAllowedExtension(extension))
                                    {
                                        String imprestNo = info[2];
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
                                        catch (Exception)
                                        {
                                            createDirectory = false;
                                            ictFeedback.InnerHtml =
                                                                            "<div class='alert alert-danger'>We could not create a directory for your documents. Please try again" +
                                                                            "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                                        }
                                        if (createDirectory)
                                        {
                                            string filename = documentDirectory + document.FileName;
                                            if (File.Exists(filename))
                                            {
                                                ictFeedback.InnerHtml =
                                                                                   "<div class='alert alert-danger'>A document with the given name already exists. Please delete it before uploading the new document or rename the new document<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                                            }
                                            else
                                            {
                                                document.SaveAs(filename);
                                                if (File.Exists(filename))
                                                {

                                                    Config.navExtender.AddLinkToRecord("ICT HelpdeskAllocation", imprestNo, filename, "");

                                                    ictFeedback.InnerHtml =
                                                        "<div class='alert alert-success'>The document was successfully uploaded. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                                                }
                                                else
                                                {
                                                    ictFeedback.InnerHtml =
                                                        "<div class='alert alert-danger'>The document could not be uploaded. Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ictFeedback.InnerHtml = "<div class='alert alert-danger'>The document's file extension is not allowed. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                                    }

                                }
                                else
                                {
                                    ictFeedback.InnerHtml = "<div class='alert alert-danger'>The document's root folder defined does not exist in the server. Please contact support. <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                                }

                            }
                            catch (Exception ex)
                            {
                                ictFeedback.InnerHtml = "<div class='alert alert-danger'>The document could not be uploaded. Please try again <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                            }
                        }
                        else
                        {
                            ictFeedback.InnerHtml = "<div class='alert alert-danger'>Please select the document to upload. (or the document is empty) <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";


                        }



                        ictFeedback.InnerHtml = "<div class='alert alert-success'> '" + info[1] + "' <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                        "setTimeout(function() { window.location.replace('Default.aspx') }, 5000);", true);
                    }
                    else
                    {
                        ictFeedback.InnerHtml = "<div class='alert alert-danger'> '" + info[1] + "' <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                    }
                }
            }
            catch (Exception m)
            {
                ictFeedback.InnerHtml = "<div class='alert alert-danger'> '" + m.Message + "'<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
            }
        }

        public void getCategories()
        {
            var nav = Config.ReturnNav();
            var categories = nav.ICTHelpDeskCategory.ToList();
            category.DataSource = categories;
            category.DataValueField = "Code";
            category.DataTextField = "Description";
            category.DataBind();

        }
    }
}