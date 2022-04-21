<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="NewAgentOnboarding.aspx.cs" Inherits="MajaniPortal.NewAgentOnboarding" %>

<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
    <%
        int step = 1;
        try
        {
            step = Convert.ToInt32(Request.QueryString["step"]);
            if (step > 3 || step < 1)
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
            General Details
                <span class="pull-right"><i class="fa fa-chevron-left"></i><i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div class="row">
                <div runat="server" id="feedbackdetails"></div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Factory Name</label>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="factorycode"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Agent Category</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="agentcategory" ></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Name</label>
                        <asp:TextBox CssClass="form-control select2" runat="server" ID="txtName" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>ID Number</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtidNumber"></asp:TextBox>
                         <asp:RegularExpressionValidator runat="server" Display="dynamic" ValidationExpression="^([\S\s]{6,8})$" ControlToValidate="txtidNumber" ErrorMessage="Please Enter the Correct ID No/Passport Value,It must be a Whole number between 6 and 8" BackColor="Red" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Mobile Number</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtmobileNumber" TextMode="Number"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" Display="dynamic" ValidationExpression="^([\S\s]{12,12})$" ControlToValidate="txtmobileNumber" ErrorMessage="Please Enter the Correct Mobile Number Value,It must be a Whole number with 12 Characters 2547xxxxxxxx" BackColor="Red" />
                       
                    </div>
                </div>
            </div>
        <div class="panel-footer">
            <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Submit Details" OnClick="SubmitApplications_Click" ID="next" />
            <div class="clearfix"></div>
        </div>
     </div>
    </div>
    <% 
    } 
    %>
    </asp:Content>