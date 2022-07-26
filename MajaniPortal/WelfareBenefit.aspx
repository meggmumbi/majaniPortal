<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WelfareBenefit.aspx.cs" Inherits="MajaniPortal.WelfareBenefit" %>
<%@ Import Namespace="MajaniPortal" %>
<%@ Import Namespace="System.IO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">
     <%
        int step = 1;
        try
        {
            step = Convert.ToInt32(Request.QueryString["step"]);
            if (step>2||step<1)
            {
               step = 1;  
            }
        }
        catch (Exception)
        { step = 1;
        }
        if (step == 1)
        {
           %>
    <div class="panel panel-primary">
        <div class="panel-heading">
             Welfare Benefit General Details
            <span class="pull-right"><i class="fa fa-chevron-left"></i> Step 1 of 2 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="panel-body">
            <div runat="server" id="membershipFeedback"></div>
            <div class="col-md-6 col-lg-6">
                <div class="form-group">
                    <label class="control-label">Employee No.</label>
                    <asp:Label runat="server" class="form-control" readonly="true"> <%=Session["employeeNo"] %></asp:Label>
                </div>
                <div class="form-group">
                    <label class="control-label">Employee No.</label>
                    <asp:Label runat="server" class="form-control" readonly="true"> <%=Session["name"] %></asp:Label>
                </div>
                <div class="form-group">
                    <strong>Description:</strong>
                    <asp:Textbox runat="server" CssClass="form-control" ID="description" TextMode="MultiLine" placeholder="Description"/>
                </div>
            </div>
            <div class="col-md-6 col-lg-6">
                <div class="form-group">
                    <strong>Welfare Description:</strong>
                    <asp:DropDownList runat="server" CssClass="form-control select2" ID="welfarecode" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="welfarecode_SelectedIndexChanged">
                        <asp:ListItem>--Select--</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <strong>Welfare Category:</strong>
                    <asp:Textbox runat="server" CssClass="form-control" ID="welfarecategory" ReadOnly="true"/>
                </div>
                <div class="form-group">
                    <strong>Benefit Allocation:</strong>
                    <asp:Textbox runat="server" CssClass="form-control" ID="benefitallocation"  ReadOnly="true"/>
                </div>
            </div>
         </div>
       <div class="panel-heading">
             Added Welfare Benefit
        </div>
        <div class="panel-body">
            <table  id="example1" class="table table-bordered table-striped">
                <thead>
                <tr>
                    <th>Welfare No.</th>
                    <th>Description</th>
                    <th>Welfare Description</th>
                    <th>Benefit Allocation</th>
                    <th>Date Created</th>
                </tr>
                </thead>
                <tbody>
                <%
                    var nav =  Config.ReturnNav();
                    String employeeNo = Convert.ToString(Session["employeeNo"]);
                    var benefit = nav.HrWelfareHeader.Where(x =>  x.Raised_By == Session["employeeNo"].ToString() && x.Status == "Open").ToList();
                    foreach (var member in benefit)
                    {
                        %>
                    <tr>
                        <td><%=member.Welfare_No %></td>                         
                        <td><%=member.Welfare_Description %></td>  
                        <td><%=member.Welfare_Description %></td> 
                        <td><%=member.Benefit_Allocation %></td>                           
                        <td><%= Convert.ToDateTime(member.Created_On).ToString("d/MM/yyyy")%></td>                 
                    </tr>
                            <%
                    }
                     %>
                </tbody>
            </table>
         </div>
            <div class="form-group">
                <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" ID="Next" OnClick="Next_Click"/>
                <div class="clearfix"></div>
            </div>      
    </div>
<% 
    }else if (step==2){
        %>
    <div class="panel panel-primary">
        <div class="panel-heading">
             Welfare Benefit Documents
            <span class="pull-right"><i class="fa fa-chevron-left"></i> Step 2 of 2 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="panel-body">
            <div runat="server" id="docsfeedback"></div>
            <table  id="example2" class="table table-bordered table-striped">
                <thead>
                <tr>
                    <th>Benefit Description</th>
                    <th>Attachment Description</th>
                    <th>Attachment Type</th>
                </tr>
                </thead>
                <tbody>
                <%
                    var nav =  Config.ReturnNav();
                    String employeeNo = Convert.ToString(Session["employeeNo"]);
                    var benefit = nav.BenefitsAttachments.ToList();
                    foreach (var member in benefit)
                    {
                        %>
                    <tr>
                        <td><%=member.Benefit_Description %></td>                         
                        <td><%=member.Attachment_Description %></td>                         
                        <td><%=member.Attachment_Type %></td>                 
                    </tr>
                            <%
                    }
                     %>
                </tbody>
            </table>
        </div>
    </div>
        <div class="panel panel-primary">
        <div class="panel-heading">Kindly Attach the Documents specified above
        </div>
        <div class="panel-body">
            <div runat="server" id="documentsfeedback"></div>
           <div class="row">
               <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                   <div class="form-group">
                       <strong>Select file to upload:</strong>
                       <asp:FileUpload runat="server" ID="document" CssClass="form-control" style="padding-top: 0px;"/>
                   </div>
               </div>
               <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                   <div class="form-group">
                       <br/>
                       <asp:Button runat="server" CssClass="btn btn-success" Text="Upload Document" ID="uploadDocument" OnClick="uploadDocument_Click"/>
                   </div>
               </div>
           </div>
           <table class="table table-bordered table-striped">
               <thead>
               <tr>
                   <th>Document Title</th>
                   <th>Download</th>
                   <th>Delete</th>
               </tr>
               </thead>
               <tbody >
               <%
                   try
                   {
                       String fileFolderApplication = ConfigurationManager.AppSettings["FileFolderApplication"];
                           String filesFolder = ConfigurationManager.AppSettings["FilesLocation"] + "Request Welfare  Benefit/";
                         String imprestNo = Request.QueryString["benefitNo"];
                            imprestNo = imprestNo.Replace('/', '_');
                            imprestNo = imprestNo.Replace(':', '_');
                            String documentDirectory = filesFolder + imprestNo+"/";
                            if (Directory.Exists(documentDirectory))
                            {
                                foreach (String file in Directory.GetFiles(documentDirectory, "*.*", SearchOption.AllDirectories))
                                {
                                    String url = documentDirectory;
                               %>
                   <tr>
                       <td><% =file.Replace(documentDirectory, "") %> 
                      
                       </td>
                       <td><a href="<%=fileFolderApplication %>\Request Welfare  Benefit\<% =imprestNo+"\\"+file.Replace(documentDirectory, "") %>" class="btn btn-success" download>Download</a></td>
                       <td><label class="btn btn-danger" onclick="deleteFile('<%=file.Replace(documentDirectory, "")%>');"><i class="fa fa-trash-o"></i> Delete</label></td>
                   </tr>
                   <%
                                }
                            }
                   }
                   catch (Exception)
                   {
                       
                   }%>
               </tbody>
           </table>
        </div>
        <div class="panel-footer">
             <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" ID="Previous" OnClick="Previous_Click"/>
            <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Send For Approval" ID="sendapproval" OnClick="sendapproval_Click"/>
            <div class="clearfix"></div>
        </div>
        </div>
    <%
    }
        %>

<script>  
    function deleteFile(fileName) {
        document.getElementById("filetoDeleteName").innerText = fileName;
        document.getElementById("ContentPlaceHolder1_fileName").value = fileName;
        $("#deleteFileModal").modal(); 
    }
</script> 

<div id="deleteFileModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Confirm Deleting File</h4>
      </div>
      <div class="modal-body">
        <p>Are you sure you want to delete the file <strong id="filetoDeleteName"></strong> ?</p>
          <asp:TextBox runat="server" ID="fileName" type="hidden"/>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
          <asp:Button runat="server" CssClass="btn btn-danger" Text="Delete File" OnClick="Unnamed_Click"/>
      </div>
    </div>

  </div>
</div>

</asp:Content>
