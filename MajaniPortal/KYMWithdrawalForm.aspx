<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="KYMWithdrawalForm.aspx.cs" Inherits="MajaniPortal.KYMWithdrawalForm" %>

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
            KYM Withdrawal Form Details
          <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 1 of 1 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="feedbackdetails"></div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Customer No</label>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="customernumbers" Placeholder="Select Customer" OnSelectedIndexChanged="GetCustomerDetails_Click" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Insurance Policy No</label>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="policynumber" Placeholder="Select Policy No" OnSelectedIndexChanged="GetContractDetails_Click" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Corporate Company Name</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="corporatename" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Date of Withdrawal</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="dateofwithdrawal" TextMode="Date"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Type of Application</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="statusamendment" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>First Name</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="firstname" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Middle Name</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="middlename" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Last Name</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="lastname" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>ID No/Passport No</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="idnumber" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Grower No/Client ID</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="growerno" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Factory Code/Branch Code</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="factorycode" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Factory Name /Branch Name</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="factoryname" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Status Ammendment</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="statusammendment"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Status Ammendment Reason</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="statusammendmentreason"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="panel-footer">
                <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" OnClick="SubmitWithrawals" />
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
                <strong>Upload Withdrawal Letter:</strong><span class="text-danger" style="font-size: 25px">*</span>
                <asp:FileUpload runat="server" CssClass="form-control" ID="uploadwithdrawaletter" />
            </div>
            <br />
            <div class="form-group">
                <strong>Upload Other :</strong><span class="text-danger" style="font-size: 25px">*</span>
                <asp:FileUpload runat="server" CssClass="form-control" ID="uploadother" />
            </div>
            <br />
            <div class="panel-footer">
                <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Upload" ID="uploaddocuments" OnClick="UploadDocumentsApplication_Click" />
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

                            String filesFolder = ConfigurationManager.AppSettings["FilesLocation"] + "Withdrawals/";
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

                        }
                    %>
                </tbody>
            </table>
            <div class="panel-footer">
                <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" OnClick="previousstep_Click" />
                <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Submit Application" OnClick="SubmitApplication_Click" />
                <div class="clearfix"></div>
            </div>

        </div>
    </div>

    <% } %>
</asp:Content>
