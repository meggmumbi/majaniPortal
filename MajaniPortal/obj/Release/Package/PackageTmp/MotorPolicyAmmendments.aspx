﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MotorPolicyAmmendments.aspx.cs" Inherits="MajaniPortal.MotorPolicyAmmendments" %>

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
            Client General Details
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 1 of 3 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div class="row">
                <div runat="server" id="feedbackdetails"></div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Policy No</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="txtdropdownPolicy" OnSelectedIndexChanged="ValidateAllPolicyDetails_Click"  AutoPostBack="true" ></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Customer Category</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control " runat="server" ID="customerCategories" ReadOnly="true" ></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Applicant Type</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control select2" runat="server" ID="applicationTypes" ReadOnly="true" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Has Grower No.?</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="hasgrowerNos" ReadOnly="true"></asp:TextBox>

                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Id Type</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control " runat="server" ID="idtype" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>ID No/Passport</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtIdNumber" TextMode="Number"  MaxLength="8" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" Display="dynamic" ValidationExpression="^([\S\s]{6,8})$" ControlToValidate="txtIdNumber" ErrorMessage="Please Enter the Correct ID No/Passport Value,It must be a Whole number between 6 and 8" BackColor="Red" />
                        <span class="error" id="idNumberPassport" runat="server" style="background-color: red"></span>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Title </label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="lbltitle" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>First name </label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control text-transform:uppercase" runat="server" ID="txtfirstname" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Middle name </label>
                        <asp:TextBox CssClass="form-control upper-case" runat="server" ID="txtMiddleName" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Last name </label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control upper-case" runat="server" ID="txtlastname" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Gender</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="lblgender" ReadOnly="true" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Date Of Birth</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:TextBox CssClass="form-control datepicker" runat="server" ID="txtDOB" ReadOnly="true"  ></asp:TextBox>
                        <span class="error" id="datevalidator" runat="server" style="background-color: red"></span>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" EnableClientScript="true" ErrorMessage="The age is below 18 Years. This is not allowed for Applicants below 18 Years" ClientValidationFunction="checkDate" ControlToValidate="txtDOB" BackColor="Red"></asp:CustomValidator>
                        
                    </div>
                </div>        
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Occupation</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control select2" runat="server" ID="ttxtoccupations" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>KRA Pin No</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="krapinNumber" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" Display="dynamic" ValidationExpression="^([\S\s]{11,11})$" ControlToValidate="krapinNumber" ErrorMessage="Please Enter the Correct KRA Pin Number Value,It must be a Whole number with 11 Characters" BackColor="Red" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>County Code</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control select2" runat="server" ID="lblcountyCode" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Marital status </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="lblmaritalstatus" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Huduma No</label>
                        <asp:TextBox CssClass="form-control upper-case" runat="server" ID="txtHudumaNo" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Country Of Residence</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control select2" runat="server" ID="countyofresidence" data-live-search="true" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-footer">
            <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" OnClick="Next_Click" ID="next" />
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
            Contact and Communication Detail
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 2 of 5 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
           <div class="box-body">
            <div runat="server" id="communicationfeedbackDetails"></div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Tel/Mobile No. </label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="telnumber1" TextMode="Number"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" Display="dynamic" ValidationExpression="^([\S\s]{12,12})$" ControlToValidate="telnumber1" ErrorMessage="Please Enter the Correct Mobile Number Value,It must be a Whole number with 12 Characters 2547xxxxxxxx" BackColor="Red" />
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Tel/Mobile No2. </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="telnumber2" TextMode="Number"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" Display="dynamic" ValidationExpression="^([\S\s]{12,12})$" ControlToValidate="telnumber2" ErrorMessage="Please Enter the Correct Mobile Number Value,It must be a Whole number with 12 Characters 2547xxxxxxxx" BackColor="Red" />

                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Email </label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtemail"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Address </label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtaddress" TextMode="Number"></asp:TextBox>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Postal Code </label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="postcodes" Placeholder="Select Departments" OnSelectedIndexChanged="PostCodes_OnClick" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>City</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblcity" Placeholder="Select City" required="true" readOnly="true"></asp:DropDownList>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Google+</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtgoogle"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Twitter</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txttwitter"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Facebook</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtfcebook"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>LinkedIn</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtlinkedin"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-footer">
            <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" OnClick="previousstep_Click" ID="previous1" />
            <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" OnClick="SubmitCommunicationDetails_Click" ID="communicationDetails" />
            <div class="clearfix"></div>
        </div>
    </div>
    <% 
        }
        else if (step == 3)
        {

    %>

    <div class="panel panel-primary">
        <div class="panel-heading">
            Policy Details <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 3 of 5 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="policyfeedbackdetails"></div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Department</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lbldepartments" Placeholder="Select Departments"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Policy Type</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblpolicyType" Placeholder="Select Customer SubCategory" OnSelectedIndexChanged="GetProducts_Onlick" AutoPostBack="True"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Insurer </label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="txtinsurers" OnSelectedIndexChanged="GetVendorProducts_Onlick" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Product </label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblproduct" OnSelectedIndexChanged="GetProductsdetails_Onlick" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label runat="server"><b>Has Binder</b></asp:Label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblhasbinder"  OnSelectedIndexChanged="ValidateHasBinderDetails_Click" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Service Period</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="serviceperiod" ReadOnly="true"></asp:TextBox>
                    </div>
                </div> 
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label runat="server"><b>Binder Code</b></asp:Label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="binderCodes" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Policy No</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="policyNumber" ReadOnly="true"></asp:TextBox>
                    </div>
                </div> 
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label runat="server"><b>Policy Start Date</b></asp:Label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="policystartDate" TextMode="Date" OnTextChanged="GetPolicyEndDates_Click" AutoPostBack="true" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Policy End Date</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control " runat="server" ID="policyenddate" ReadOnly="true"></asp:TextBox>
                    </div>
                </div> 
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label runat="server"><b>Calendar Days</b></asp:Label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtcalenderDays" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label runat="server"><b>Non-Renewable</b></asp:Label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:CheckBox CssClass="form-control" runat="server" ID="nonrenewable"></asp:CheckBox>
                    </div>
                </div>                
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Paid Amount</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="paidamount"  ></asp:TextBox>
                    </div>
                </div> 
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                      <label>Date Paid </label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="datepaid" TextMode="Date"></asp:TextBox>
                    </div>
                </div>               
            </div>
            <div class="row">                         
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label runat="server"><b>Binder Fee Rate</b></asp:Label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="binderfeerate" ></asp:TextBox>
                    </div>
                </div>                 
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label runat="server"><b>Commission Rate</b></asp:Label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="commissionRate" ></asp:TextBox>
                    </div>
                </div>     
             </div>
            <div class="row">  
                                           
                 <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Premium Rating</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="premiumsratings"></asp:TextBox>
                    </div>
                </div>                 
               <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Policy Business Type</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="membertype" Placeholder="Select Product" readOnly="true"></asp:DropDownList>
                    </div>
                </div>                                     
                                 
            </div>
            <div class="row">   
                  <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Mode of Payment</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="modeofpayments" Placeholder="Select Product"></asp:DropDownList>
                    </div>
                </div> 
                 <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label runat="server"><b>Payment Referrence Code</b></asp:Label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="paymentreferenceccode"></asp:TextBox>
                    </div>
                </div>  
            </div>
            <div class="row">                            
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Financier</label>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="txtfinancier" ></asp:DropDownList>
                    </div>
                </div>  
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Agent Detail</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="agentDetail" Placeholder="Select Product" OnSelectedIndexChanged="AgentDetails_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>                         
            </div>
            <div class="row">    
                   <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="agentsalespersoncode" runat="server"><b>Agent Sales Person Code</b></asp:Label>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="salesgentcode" Placeholder="Select Product"></asp:DropDownList>
                    </div>
                </div>                      
                 <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server"><b>Payment Option</b></asp:Label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="txtpaymentsoptions"></asp:DropDownList>
                    </div>
                </div> 
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="referralname" runat="server"><b>Referral Name</b></asp:Label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtrefferalname"></asp:TextBox>
                    </div>
                </div> 
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="referalmobilenumber" runat="server"><b>Referral Mobile Number</b></asp:Label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtreferalmobilenumber"></asp:TextBox>
                    </div>
              </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server"><b>Referral ID Number</b></asp:Label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtreferralidnumber"></asp:TextBox>
                    </div>
              </div>
            </div>
        </div>
    </div>
   
    <div class="panel-footer">
        <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" OnClick="previousstep_Click" ID="previous2" />
        <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" OnClick="SubmitPolicyDetails_Click" ID="application" />
        <div class="clearfix"></div>
    </div>

    <% 
        }
        else if (step == 4)
        {
    %>
    <div class="panel panel-primary">
        <div class="panel-heading">
            Risk Details
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 2 of 4 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
             <div runat="server" id="risksfeedbackdetails"></div>
           <div class="modal-body">
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Registration No</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="registrationnumber" OnTextChanged="ValidateRates_Click" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Certificate No.</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="certificateNo"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Make</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="make" Placeholder="Select Policy Holder No" AutoPostBack="true" OnTextChanged="ValidateMake_Text"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Model</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="model" Placeholder="Select Policy Holder No"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Vehicle Type</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="vehicletype" Placeholder="Select Policy Holder No"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Cover Type</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="covertype" Placeholder="Select Policy Holder No"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>CC</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="cc"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Chasis No</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="chasisnumber"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Engine No</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="enginenumber"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Year of Manufucture</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="yearofmanufucture" TextMode="Number" OnTextChanged="ValidateYearofManufacture_Click" AutoPostBack="true"></asp:TextBox>
                                         <span class="error" id="txtyearofmanaufucturedetails" runat="server" style="background-color: red"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Body Types</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="txtdropdownlist"></asp:DropDownList>
                                    </div>
                                </div>
                                 <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Policy Start Date</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="policystratdate" ReadOnly="true"  ></asp:TextBox>
                                    </div>
                                </div>
                               
                            </div>
                            <div class="row">
                                
                                 <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Duration<i>(In Days)</i></label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="duration" TextMode="Number" OnTextChanged="validateEndDate_Click" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Policy End Date</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="policiesendDate" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                               
                            </div>
                            <div class="row">
                                
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Tonnage</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="tonnage" OnTextChanged="GetBasicPremum_Click" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Value/Sum Insured</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="valuesuminsured" OnTextChanged="ValidateValueInsured_Click" AutoPostBack="true"></asp:TextBox>
                                        <span class="error" id="txtvalueinsureddetails" runat="server" style="background-color: red"></span>
                                    </div>
                                </div>
                            </div>
                           <div class="row">                               
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Rate</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtrate"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Non-Renewable</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:CheckBox CssClass="form-control" runat="server" ID="bolnonerenewable"></asp:CheckBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Valued</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:CheckBox CssClass="form-control" runat="server" ID="bolvalued"></asp:CheckBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Excess Protector</label><span class="text-danger" style="font-size: 25px">*</span>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtprotector"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                             <div runat="server" id="basicpremium">
                               <div class="row">
                                <div class="col-md-6 col-lg-6">
                                <div class="form-group">
                                    <label>Basic Premium</label>
                                    <asp:TextBox CssClass="form-control" runat="server" ID="txtbasicpremiums" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                          </div>
                       </div>
                        </div>
                    <div class="form-group">
                  <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Add Risk Details" OnClick="SubmitRiskDetails_Click" ID="Button3" />
                   <div class="clearfix"></div>
               </div>
            <br />
            <br />
            <div class="box-body">
                <table id="example2" class="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <th>Registration No</th>
                            <th>Make</th>
                            <th>Model</th>
                            <th>Cover Type </th>
                            <th>Premium</th>
                            <th>Total Line Premium</th>
                            <th>Optional Benefits</th>
                            <th>Remove</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%
                            var nav = Config.ReturnNav();
                            var requisitionNo = Request.QueryString["requisitionNo"].Trim();
                            var applications = nav.PolicyRiskDetails.Where(r => r.Client_App_No == requisitionNo);
                            foreach (var application in applications)
                            {
                        %>
                        <tr>
                            <td><%= application.Registration_No %></td>
                            <td><%= application.Make %></td>
                            <td><%= application.Model %></td>
                            <td><%= application.Cover_Type %></td>
                            <td><%= application.Premium %></td>
                            <td><%= application.Total_Line_Premiums %></td>
                           <td>
                            <label class="btn btn-success"><a href="MotorIndividualOptionalBenefits.aspx?requisitionNo=<%=requisitionNo%>&&Code=<%=application.Code%>&step=<%=step%>"</a><i class="fa fa-share"></i>Optional Benefit</label>                    
                           </td>
                             <td>
                             <label class="btn btn-danger" onclick="removeRisk('<%=application.Registration_No %>');"><i class="fa fa-trash"></i>Remove</label>
                           </td>
                        </tr>
                        <%
                            }
                        %>
                    </tbody>
                </table>
                <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                       <label>Total Value/Sum Insured</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="totalsvaluesuminsured" ReadOnly="true"></asp:TextBox>
                    </div>
                   </div>
                  <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                       <label>Total Premium</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="totalpremium" ReadOnly="true"></asp:TextBox>
                    </div>
                  </div>
                  <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                       <label>Total Premiums Payables</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="totalpremiumspayables" ReadOnly="true"></asp:TextBox>
                    </div>
                 </div>
            </div>
            </div>
        </div>
        <div class="panel-footer">
            <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" OnClick="previousstep_Click" ID="prevous4" />
            <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" OnClick="nextstep_Click" ID="Button2" />
            <div class="clearfix"></div>
        </div>
    </div>
     <div id="deleteRiskModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Confirm Removing Risk Details</h4>
                    </div>
                    <div class="modal-body">
                        <p>Are you sure you want to removing the Risk Details <strong id="RiskToDelete"></strong>?</p>
                        <asp:TextBox runat="server" ID="RisktoRemove" type="hidden" />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                        <asp:Button runat="server" CssClass="btn btn-danger" Text="Remove Risk" OnClick="DeleteRiskDetails_Click" />
                    </div>
                </div>
            </div>
        </div>
    <%             
        }
        else if (step == 5)
        {
    %>
    <div class="panel panel-primary">
        <div class="panel-heading">
            Upload Supporting Documents
           <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 5 of 5 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="documentsfeedback"></div>
            <div class="form-group">
                <strong>Upload Logbook:<i>(Please Upload Pdf files)</i></strong><span class="text-danger" style="font-size:25px">*</span>
                <asp:FileUpload runat="server" CssClass="form-control" ID="uploadLogbook" />
            </div>
            <br />
            <div class="form-group">
                <strong>Upload ID or Certificate of Incorporation (for Corporates):<i>(Please Upload Pdf files)</i></strong><span class="text-danger" style="font-size:25px">*</span>
                <asp:FileUpload runat="server" CssClass="form-control" ID="uploadIDCertificate" />
            </div>
            <br />
            <div class="form-group">
                <strong>Upload KRA PIN Certificate:<i>(Please Upload Pdf files)</i></strong><span class="text-danger" style="font-size:25px">*</span>
                <asp:FileUpload runat="server" CssClass="form-control" ID="uploadKRAPinCertificate" />
            </div>
            <br />
            <div class="form-group">
                <strong>Upload Application/Proposal Form:<i>(Please Upload Pdf files)</i></strong><span class="text-danger" style="font-size:25px">*</span>
                <asp:FileUpload runat="server" CssClass="form-control" ID="uploadApplicationForm" />
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

                            String filesFolder = ConfigurationManager.AppSettings["FilesLocation"] + "New Clients/";
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
    <%} %>
    <div id="editOptionalBenefitModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Update Optional Benefit</h4>
                </div>
                <div class="modal-body">
                    <asp:TextBox runat="server" ID="txtrisknumber" type="hidden" />
                    <div class="row">
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>PLL:</strong>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtpll" TextMode="Number" ClientIDMode="static" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>WindScreen:</strong>
                                <asp:TextBox runat="server" CssClass="form-control " ID="txtwindscreen" TextMode="Number" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Radio Cassette:</strong>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtradiocassette" TextMode="Number" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Carriers Liability:</strong>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtcarriersliability" TextMode="Number" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Political Violence and Terrorism:</strong>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtpolitical" TextMode="Number" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Execess Protector:</strong>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtexecess" TextMode="Number" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Road Rescue Services:</strong>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtroadrescueservice" TextMode="Number" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Wiba Cover:</strong>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtwibacover" TextMode="Number" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Fidelity Guarantee:</strong>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtfidelityguarantee" TextMode="Number" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Total Line Premiums:</strong>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txttotallinepremium" TextMode="Number" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                    <asp:Button runat="server" CssClass="btn btn-success" Text="Update Optional Benefit" />
                </div>
            </div>

        </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script type="text/javascript">
        function ValidateDOB() {
            var lblError = document.getElementById("lblError");
            //Get the date from the TextBox.
            var dateString = document.getElementById("txtdateob").value;
            var regex = /(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$/;
            //Check whether valid dd/MM/yyyy Date Format.
            if (regex.test(dateString)) {
                var parts = dateString.split("/");
                var dtDOB = new Date(parts[1] + "/" + parts[0] + "/" + parts[2]);
                var dtCurrent = new Date();
                lblError.innerHTML = "Eligibility 18 years ONLY."
                if (dtCurrent.getFullYear() - dtDOB.getFullYear() < 18) {
                    return false;
                }
                if (dtCurrent.getFullYear() - dtDOB.getFullYear() == 18) {
                    //CD: 11/06/2018 and DB: 15/07/2000. Will turned 18 on 15/07/2018.
                    if (dtCurrent.getMonth() < dtDOB.getMonth()) {
                        return false;
                    }
                    if (dtCurrent.getMonth() == dtDOB.getMonth()) {
                        //CD: 11/06/2018 and DB: 15/06/2000. Will turned 18 on 15/06/2018.
                        if (dtCurrent.getDate() < dtDOB.getDate()) {
                            return false;
                        }
                    }
                }
                lblError.innerHTML = "";
                return true;
            } else {
                lblError.innerHTML = "Enter date in dd/MM/yyyy format ONLY."
                return false;
            }
        }
    </script>
     <script type="text/javascript">
         function removeRisk(RegistrationNumber) {
             document.getElementById("RiskToDelete").innerText = RegistrationNumber;
             document.getElementById("MainBody_RisktoRemove").value = RegistrationNumber;
             $("#deleteRiskModal").modal();
         }
    </script>
    <script type="text/javascript">
        function checkDate() {
            var enteredDate = document.getElementById('<%=txtDOB.ClientID%>').value;
            var dateValues = enteredDate.split("/");
            var dateToCheck = new Date(dateValues[2], dateValues[1] - 1, dateValues[0]);
            var today = new Date();
            var dateValid = new Date(today.getFullYear() - 18, today.getMonth() - 1, today.getDate());
            if (dateToCheck < dateValid) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }
    </script>
    <script>
        function editOptionalBenefit(rirskNumber) {
            //document.getElementById("MainContent_txtpll").value = rirskNumber;
            //document.getElementById("MainContent_txtpll").value = rirskNumber
            $("#editOptionalBenefitModal").modal();
        }
    </script>
    <script type="text/javascript">
        function ShowGrower(hasgrowerNo) {
            var dvGrower = document.getElementById("dvShowGowerDetails");
            dvGrower.style.display = hasgrowerNo.checked ? "block" : "none";
            if (hasgrowerNo.checked == true) {
                dvGrower.style.display = "block";
            } else {
                dvGrower.style.display = "none";
            }
        }
    </script>
</asp:Content>
