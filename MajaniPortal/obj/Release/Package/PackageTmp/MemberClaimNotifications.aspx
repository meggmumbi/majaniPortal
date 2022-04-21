<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberClaimNotifications.aspx.cs" Inherits="MajaniPortal.MemberClaimNotifications" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
  <%
      int step = 1;
      try
      {
          step = Convert.ToInt32(Request.QueryString["step"]);
          if (step > 2 || step < 1)
          {
              step = 1;
          }
      }
      catch (Exception)
      {
          step = 1;
      }
      if (step == 1)
      {
    %>
    <div class="panel panel-primary">
        <div class="panel-heading">
            Claim General Details
            <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 1 of 2<i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="feedbackdetails"></div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Customer No.</label>
                       <asp:DropdownList CssClass="form-control" runat="server" ID="lblcustomers" Placeholder="Select Customers" OnSelectedIndexChanged="PolicyDetails_OnClick" AutoPostBack="true" ></asp:DropdownList>
                    </div>
                    <div class="form-group">
                        <label>Policy No.</label>
                       <asp:DropdownList CssClass="form-control" runat="server" ID="lblpolicynumber" Placeholder="Select Customers" ></asp:DropdownList>

                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Claim  Against</label>
                       <asp:DropdownList CssClass="form-control" runat="server" ID="lblclaimagainst" Placeholder="Select Claim Against" OnSelectedIndexChanged="DependantsDetails_OnClick" AutoPostBack="true"></asp:DropdownList>
                    </div>
                    <div class="form-group">
                        <label>Dependant No</label>
                       <asp:DropdownList CssClass="form-control" runat="server" ID="lbldependantNumber" Placeholder="Select Customers"  ></asp:DropdownList>

                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Claim Category</label>
                      <asp:DropdownList CssClass="form-control" runat="server" ID="lblclaimcategory" Placeholder="Select Claim Category" ></asp:DropdownList>
                    </div>
                    <div class="form-group">
                        <label>Date Of Accident/Death/Loss</label>
                        <asp:TextBox CssClass="form-control"  runat="server" ID="dateofaccident"  TextMode="Date"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Place of Occurence Types</label>
                         <asp:DropdownList CssClass="form-control" runat="server" ID="lblplaceofOccurrences" Placeholder="Select Place of Occurrences" ></asp:DropdownList>
                    </div>
                    <div class="form-group">
                        <label>Place Of Occurence</label>
                      <asp:TextBox CssClass="form-control"  runat="server" ID="placeofoccurrences" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Customer Category</label>
                         <asp:DropdownList CssClass="form-control" runat="server" ID="customercategory" Placeholder="Select Customer Category" ></asp:DropdownList>
                    </div>

                </div>
            </div>
           <div class="panel-footer">
            <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" OnClick="SubmitApplication_Click" ID="submitapplication" />
            <div class="clearfix"></div>
        </div>
        </div>
    </div>
     <% 
        }
        else if (step == 2)
        {
    %>
      <div class="panel panel-primary">
        <div class="panel-heading">
            Upload Supporting Documents
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 2 of 2 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="documentsfeedback"></div>
                <div class="form-group">
                    <strong>Upload Supporting Documents:</strong>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="filetoupload" />
                </div>
            <div class="panel-footer">
                <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Upload" ID="uploaddocuments" OnClick="upload_Click" />
                <div class="clearfix"></div>
            </div>
            <table class="table table-bordered table-striped" id="example2">
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

                            String filesFolder = ConfigurationManager.AppSettings["FilesLocation"] + "Existing Policy/";
                            String PolicyNo = Request.QueryString["requisitionNo"].Trim();
                            PolicyNo = PolicyNo.Replace('/', '_');
                            PolicyNo = PolicyNo.Replace(':', '_');
                            String documentDirectory = filesFolder + PolicyNo + "/";
                            if (Directory.Exists(documentDirectory))
                            {
                                foreach (String file in Directory.GetFiles(documentDirectory, "*.*", SearchOption.AllDirectories))
                                {
                                    String url = documentDirectory;
                    %>
                    <tr>
                        <td><% =file.Replace(documentDirectory, "") %></td>
                        <td>
                            <label class="btn btn-success" onclick="downloadFile('<%=file.Replace(documentDirectory, "")%>');"><i class="fa fa-download">Download</label></td>
                        <td>
                            <label class="btn btn-danger" onclick="deleteFile('<%=file.Replace(documentDirectory, "")%>');"><i class="fa fa-trash-o"></i>Delete</label></td>
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
            <div class="panel-footer">
                <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" OnClick="previousstep_Click" />
                  <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Send Claim for Validations" OnClick="Sendforvalidations_Click" ID="validations" />
                <div class="clearfix"></div>
            </div>

        </div>
    </div>
    <%} %>
</asp:Content>
