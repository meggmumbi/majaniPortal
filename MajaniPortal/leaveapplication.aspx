﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="leaveapplication.aspx.cs" Inherits="MajaniPortal.leaveapplication" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">
      <%
        int step = 1;
        try
        {
            step = Convert.ToInt32(Request.QueryString["step"].Trim());
            if (step>2||step<1)
            {
                step = 1;
            }
        }
        catch (Exception)
        {
            step = 1;
        }
        if (step==1)
        {
           %>
     <div class="panel panel-primary">
        <div class="panel-heading">Leave Application
             <span class="pull-right"><i class="fa fa-chevron-left"></i> Step 1 of 2 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
         <div class="panel-body">
                <div runat="server" id="feedback"></div>
                <div class="form-group">
                   <label class="span2" >Leave Type</label>
                     <asp:DropDownList runat="server" ID="leaveType" AppendDataBoundItems="true" CssClass="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="leaveType_SelectedIndexChanged" >
                         <asp:ListItem Text="--- Select Leave Type ----" Value=" " />
                      </asp:DropDownList>
               </div>
              <div runat="server" class="form-group" visible="false" id="annualtype" >
                   <label class="span2">Annual Leave Type</label>
                   <asp:DropDownList ID="annualLeaveType" runat="server"   CssClass="form-control select2" 
                    AutoPostBack="false" >
                      <asp:ListItem>--Select Annual Leave Type--</asp:ListItem>
                      <asp:ListItem Value="0">Annual Leave</asp:ListItem>
                      <asp:ListItem Value="1">Emergency Leave</asp:ListItem>
                       </asp:DropDownList>
                </div>
                 <div class="form-group">
                   <label class="span2">Days Applied</label>
                   <asp:Textbox runat="server" ID="daysApplied" CssClass="form-control span3" type ="number"/>
               </div>
               
                 <div class="form-group">
                   <label class="span2">Start Date</label>
                   <asp:Textbox runat="server" ID="leaveStartDate" CssClass="form-control span3"/>
               </div>
             <%--
                <div class="form-group">
                   <label class="span2" >Reliver</label>
                   <asp:DropDownList runat="server" ID="reliver" AppendDataBoundItems="true" CssClass="form-control select2" AutoPostBack="true" >
                       <asp:ListItem Text="--- Select ----" Value=" " />
                   </asp:DropDownList>
               </div>  --%>
               
               <strong> More Leave Details</strong> <i>(Optional)</i>
                <hr/>
                
                  <div class="form-group">
                   <label class="span2">Phone Number</label>
                   <asp:Textbox runat="server" ID="phoneNumber" CssClass="form-control span3"/>
               </div>
                  <div class="form-group">
                   <label class="span2">Email Address</label>
                   <asp:Textbox runat="server" ID="emailAddress" CssClass="form-control span3"/>
               </div>
                 <%-- <div class="form-group">
                   <label class="span2">Details of Exam</label>
                      <asp:Label ID="examDet" runat="server" Text="Details of Exam"></asp:Label>
                   <asp:Textbox runat="server" ID="examDetails" CssClass="form-control span3" TextMode="MultiLine"/>
               </div>
                  <div class="form-group">
                   <label class="span2">Date of Exam</label>
                      <asp:Label ID="examDate" runat="server" Text="Date of Exam"></asp:Label>
                   <asp:Textbox runat="server" ID="dateOfExam" CssClass="form-control span3"/>
               </div>
                  <div class="form-group">
                  <label class="span2">Number of Previous Attempts</label>
                      <asp:Label ID="prevAttempts" runat="server" Text="Number of Previous Attempts"></asp:Label>
                   <asp:Textbox runat="server" ID="previousAttempts" CssClass="form-control span3" type="number"/>
               </div>
                 --%>

           
     
         </div>
         <div class="panel-footer">
             <asp:Button runat="server" ID="apply" CssClass="btn btn-success pull-right" Text="Next" OnClick="apply_Click" />
             <div class="clearfix"></div>
         </div>
    </div>
    <% 
        }else if (step==2){
              %>
    <div class="panel panel-primary">
        <div class="panel-heading">Supporting Documents
              <span class="pull-right"><i class="fa fa-chevron-left"></i> Step 2 of 2 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="panel-body">
            <div runat="server" id="documentsfeedback"></div>
            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                <div class="form-group">
                   <label class="span2">Return Date</label>
                   <asp:Textbox runat="server" ID="returnDate" CssClass="form-control span3" ReadOnly="true"/>
               </div>
                    </div>
            </div>
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
               <tbody>
               <%
                   try
                   {
                       String fileFolderApplication = ConfigurationManager.AppSettings["FileFolderApplication"];
                           String filesFolder = ConfigurationManager.AppSettings["FilesLocation"] + "Leave Application Card/";
                         String imprestNo = Request.QueryString["leaveNo"];
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
                       <td><% =file.Replace(documentDirectory, "") %></td>
                      
                       <td><a href="<%=fileFolderApplication %>\Leave Application\<% =imprestNo+"\\"+file.Replace(documentDirectory, "") %>" class="btn btn-success" download>Download</a></td>
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
             <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" OnClick="Unnamed10_Click" />
            <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Send Approval Request" OnClick="sendApproval_Click" ID="sendApproval"/>
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
          <asp:Button runat="server" CssClass="btn btn-danger" Text="Delete File" OnClick="deleteFile_Click"/>
      </div>
    </div>

  </div>
</div>
</asp:Content>
