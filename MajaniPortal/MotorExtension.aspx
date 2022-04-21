<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MotorExtension.aspx.cs" Inherits="MajaniPortal.MotorExtension" %>

<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
    <%
        int step = 1;
        try
        {
            step = Convert.ToInt32(Request.QueryString["step"]);
            if (step > 5 || step < 1)
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
            Motor Extension General Details
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 1 of 3 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div class="row">
                <div runat="server" id="feedbackdetails"></div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Customer No</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control select2 " runat="server" ID="customerNo" Placeholder="Select Customer No"  OnSelectedIndexChanged="Contracts_Onclick" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Contract No</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="contractNo" Placeholder="Select Contract No" OnSelectedIndexChanged="PolicyDetails_Onclick" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Corporate Company Name</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control select2" runat="server" ID="corporateName" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Policy No</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="policyNo" ReadOnly="true"></asp:TextBox>

                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>First Name</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="firstName" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Middle Name</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="middleName" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6" runat="server" id="Div1">
                    <div class="form-group">
                        <label>LastName</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control upper-case" runat="server" ID="lastname" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6" runat="server" id="Div2">
                    <div class="form-group">
                        <label>ID No/Passport No</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control upper-case" runat="server" ID="idNumber" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Payment Amount</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control " runat="server" ID="paymentamount" TextMode="Number"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Payment Reference Code</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control " runat="server" ID="paymentreferenceCode"></asp:TextBox>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Date Paid </label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="datepaid" TextMode="Date"></asp:TextBox>
                    </div>
                </div>

            </div>
        </div>
       <div class="panel-footer">
        <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" OnClick="Next_Click" ID="Button1" />
        <div class="clearfix"></div>
        </div>
    </div>
    <% 
        }
        else if (step == 2)
        {
    %>
    <div class="panel panel-primary">
        <div class="panel-heading">
            Vehicle Details
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 2 of 2<i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="communicationfeedbackDetails"></div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Risk Code</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="txtriskCode" OnSelectedIndexChanged="RiskDetails_Onclick" AutoPostBack="true" ></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Registration No. </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtRegistration" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Make </label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtMake" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Model </label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtModel" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Certificate Start Date</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" TextMode="Date" ID="certificateStartDate"></asp:TextBox>
                    </div>
                </div>
                
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Certificate Period(In Days)</label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control select2" runat="server" ID="certificateperiod" TextMode="Number" OnTextChanged="validateEndDate_Click" AutoPostBack="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Certificate End Date</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="certificateendDate" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-footer">
            <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" ID="previous1" />
            <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Initiate Extension" OnClick="InitiateExtension_Click" ID="initiateExtension" />
            <div class="clearfix"></div>
        </div>
    </div>
    <%} %>
</asp:Content>
