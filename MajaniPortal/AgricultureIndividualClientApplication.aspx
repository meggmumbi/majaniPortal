<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgricultureIndividualClientApplication.aspx.cs" Inherits="MajaniPortal.AgricultureIndividualClientApplication" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">
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
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 1 of 4<i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div class="row">
                <div runat="server" id="feedbackdetails"></div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Customer Category</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="customerCategory" Placeholder="Select Customer Category" OnSelectedIndexChanged="SubCategories_Onclick" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Customer SubCategory</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="customerSubCategory" Placeholder="Select Customer SubCategory" OnSelectedIndexChanged="Applications_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    </div>
                </div>

                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Applicant Type</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control 2" runat="server" ID="applicationTypes" OnSelectedIndexChanged="applicationTypes_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>



                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Id Type</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="idtype" Placeholder="Select Departments"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>ID No/Passport</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtIdNumber" TextMode="Number" MinLength="6" MaxLength="8"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" Display="dynamic" ValidationExpression="^([\S\s]{6,8})$" ControlToValidate="txtIdNumber" ErrorMessage="Please Enter the Correct ID No/Passport Value,It must be a Whole number between 6 and 8" BackColor="Red" />
                        <span class="error" id="idNumberPassport" runat="server" style="background-color: red"></span>
                    </div>
                </div>


                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Title </label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lbltitle" Placeholder="Select County"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>First name </label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtfirstname"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Middle name </label>
                            <span class="text-danger" style="font-size: 25px"></span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtMiddleName"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Last name </label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtlastname"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Gender</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblgender" Placeholder="Select Departments"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Date Of Birth</label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control datepicker" runat="server" ID="txtDOB" TextMode="Date" AutoPostBack="true" OnTextChanged="PrincipalValidateDate_Text"></asp:TextBox>
                        <span class="error" id="datevalidator" runat="server" style="background-color: red"></span>
                       

                    </div>
                </div>

                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Occupation</label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control 2" runat="server" ID="ttxtoccupations"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>KRA Pin No</label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="krapinNumber" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>County Code</label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control 2" runat="server" ID="lblcountyCode"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Marital status </label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control 2" runat="server" ID="lblmaritalstatus" Placeholder="Select Marital Status"></asp:DropDownList>
                    </div>
                </div>


                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Country Of Residence</label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control 2" runat="server" ID="countyofresidence" data-live-search="true" Placeholder="Select County of Residence"></asp:DropDownList>
                    </div>
                </div>

                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Residential Location </label>
                           <span class="text-danger" style="font-size: 25px"></span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="ResidentialLocat"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Office Location</label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="OfficeLocat"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Source of Income</label>
                        <span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="sourceIncome">
                            <asp:ListItem Value="0">-- Select Source of Income --</asp:ListItem>
                            <asp:ListItem Value="1">Winnings</asp:ListItem>
                            <asp:ListItem Value="2">Savings</asp:ListItem>
                            <asp:ListItem Value="3">Rent</asp:ListItem>
                            <asp:ListItem Value="4">Legal Settlement</asp:ListItem>
                            <asp:ListItem Value="5">Royalties</asp:ListItem>
                            <asp:ListItem Value="6">Employment</asp:ListItem>
                            <asp:ListItem Value="7">Inheritance</asp:ListItem>
                            <asp:ListItem Value="8">Business Proceeds</asp:ListItem>
                            <asp:ListItem Value="9">Sale of Investment</asp:ListItem>
                            <asp:ListItem Value="10">Pension</asp:ListItem>
                            <asp:ListItem Value="11">Donation</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Mpesa Number</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="mpesaNo"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Huduma No</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtHudumaNo"></asp:TextBox>
                    </div>
                </div>
                
                <div class="col-md-6 col-lg-6" style="display:none">
                    <div class="form-group">
                        <label>Source of Wealth</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="wealthSource" Placeholder="Select Source of Wealth">
                            <asp:ListItem Value="0">-- Select Source of Wealth --</asp:ListItem>
                            <asp:ListItem Value="1">Salary</asp:ListItem>
                            <asp:ListItem Value="2">Businesss Proceed</asp:ListItem>
                            <asp:ListItem Value="3">Pension</asp:ListItem>
                            <asp:ListItem Value="4">Rent</asp:ListItem>
                            <asp:ListItem Value="5">Non-Income Generating Dependent</asp:ListItem>
                        </asp:DropDownList>
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
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 2 of 4 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
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
                        <label>Email </label>
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
            <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" OnClick="previousstep_Click" />
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
            Policy Details <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 3 of 4 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="policyfeedbackdetails"></div>
            <div class="row">   
                  <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Has Grower No.?</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:CheckBox CssClass="form-control" runat="server" ID="hasgrowerNo" OnCheckedChanged="hasgrowerNo_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
                    </div>
                </div>
                <div id="growerId" runat="server" visible="false">
                  <div class="col-md-6 col-lg-6">
                        <div class="form-group">
                            <label>Grower Type of Applicant</label><span class="text-danger" style="font-size:25px">*</span>
                            <asp:DropDownList CssClass="form-control" runat="server" ID="growerapplicanttype"></asp:DropDownList>
                        </div>
                    </div> 
                    <div class="col-md-6 col-lg-6">
                        <div class="form-group">
                            <label>Grower No./Client ID</label><span class="text-danger" style="font-size:25px">*</span>
                            <asp:TextBox CssClass="form-control" runat="server" ID="growerNumber" OnTextChanged="ValidateFactoryDetail_Click" AutoPostBack="true" MaxLength="9"></asp:TextBox>
                           <asp:RegularExpressionValidator runat="server" Display="dynamic" ValidationExpression="^([\S\s]{9,9})$" ControlToValidate="growerNumber" ErrorMessage="Please Enter the CorrectGrower No Value,It must be a Whole number with 9 Characters" BackColor="Red" />
                             <span class="error" id="growerdetails" runat="server" style="background-color: red"></span>
                        </div>
                    </div>
                      <div class="col-md-6 col-lg-6" runat="server" id="Div1">
                        <div class="form-group">
                            <label>Factory Code</label><span class="text-danger" style="font-size:25px">*</span>
                            <asp:TextBox CssClass="form-control" runat="server" ID="txtFactoryCode" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
               
                              
                     <div class="col-md-6 col-lg-6" runat="server" id="Div2">
                        <div class="form-group">
                            <label>Factory Name</label><span class="text-danger" style="font-size:25px">*</span>
                            <asp:TextBox CssClass="form-control" runat="server" ID="ttxtFactoryName" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>                  
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Sub County</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="subcounty"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6" runat="server" id="Div4">
                    <div class="form-group">
                        <label>Ward</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control select2" runat="server" ID="ward"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Nearest School</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="NearSchool"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Product </label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="lblproduct" OnSelectedIndexChanged="GetProductsdetails_Onlick" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Insurer </label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:TextBox CssClass="form-control select2" runat="server" ID="insurer" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Has Binder?</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="hasBinder" OnSelectedIndexChanged="hasBinder_SelectedIndexChanged" AutoPostBack="true" Placeholder="Select Source of Wealth">
                            <asp:ListItem Value="0">Yes</asp:ListItem>
                            <asp:ListItem Value="1">No</asp:ListItem>
                        </asp:DropDownList>
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
                        <label>Policy Business Type</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="membertype" Placeholder="Select Product" readOnly="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Payment Options</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="paymentOptions" Placeholder="Select Source of Wealth">
                            <asp:ListItem Value="0">-- Select Payment Options --</asp:ListItem>
                            <asp:ListItem Value="1">Direct to Majani</asp:ListItem>
                            <asp:ListItem Value="2">Direct to Insurer</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        
            <div class="row">            
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Policy Start Date</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control datepicker" runat="server" ID="policyStartDate" TextMode="Date"></asp:TextBox>
                         <asp:RequiredFieldValidator Display="dynamic"  ID="RequiredFieldValidator18"  runat="server" ControlToValidate="policyStartDate"  ErrorMessage="Policy Start Date:, it cannot be empty!" ForeColor="Red" />
                    </div>
                </div>
                 <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Agent Detail</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="agentDetail" Placeholder="Select Product" OnSelectedIndexChanged="AgentDetails_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <asp:Label ID="agentsalespersoncode" runat="server"><b>Agent Sales Person Code</b></asp:Label><span class="text-danger" style="font-size: 25px">*</span>
                    <div class="form-group">
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="lblsalesgentcode"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Mode of Payment</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="modeofpayments" OnSelectedIndexChanged="modeofpayments_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Payment Reference Code</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="paymentRefCode"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6" runat="server" id="financier">
                    <div class="form-group">
                        <label>Financier</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="txtfinancier"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="row">
                <div runat="server" id="generalformcheckoffs" visible="false">
                    <div class="col-md-6 col-lg-6">
                        <div class="form-group">
                            <label>Upload Check Off Form</label><span class="text-danger" style="font-size: 25px">*</span>
                            <asp:FileUpload runat="server" CssClass="form-control" ID="checkoffform" />
                        </div>
                    </div>
                </div>
                <div runat="server" id="premRating" visible="false">
                    <div class="col-md-6 col-lg-6">
                        <div class="form-group">
                            <label>Premium Rating</label><span class="text-danger" style="font-size: 25px">*</span>
                            <asp:TextBox CssClass="form-control" runat="server" ID="premiumrating"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
        <div class="panel-footer">
            <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" OnClick="previousstep_Click" />
           <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" OnClick="SubmitPolicyDetails_Click" ID="application" />
            <div class="clearfix"></div>
        </div>
    </div>
       <% 
        }
        else if (step == 4)
        {
    %>


    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb float-sm-right">
                <li class="breadcrumb-item"><a href="Home.aspx">Dashboard</a></li>
                <li class="breadcrumb-item active">Agriculture Risk Details</li>
            </ol>
        </div>
    </div>
    <div class="panel panel-primary">
        <div class="panel-heading">
            Agriculture Risk Details
            <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 4 of 5 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="panel-body">
            <div runat="server" id="physicalLocations"></div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <strong>Name of Animal<span class="text-danger">*</span></strong>
                        <asp:TextBox runat="server" ID="NameOfAnimal" CssClass="form-control" />
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <strong>Livestock: </strong><span class="asterisk" style="color: red">*</span>
                        <asp:DropDownList runat="server" ID="livestock" CssClass="form-control" />
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <strong>Ear Tag Number:</strong> <span class="asterisk" style="color: red">*</span>
                        <asp:TextBox runat="server" ID="earTag" CssClass="form-control" />
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <strong>Breed:</strong> <span class="asterisk" style="color: red">*</span>
                        <asp:DropDownList runat="server" ID="Animalbreed" CssClass="form-control" />
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <strong>Sex of the animal </strong><span class="text-danger">*</span>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="livestocksex">
                            <asp:ListItem Value="0">-- Select Sex --</asp:ListItem>
                            <asp:ListItem Value="1">Male</asp:ListItem>
                            <asp:ListItem Value="2">Female</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <strong>Age in Years: </strong><span class="asterisk" style="color: red">*</span>
                        <asp:TextBox runat="server" ID="age" CssClass="form-control" />
                    </div>
                </div>

                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <strong>Milk Production Per day: </strong><span class="asterisk" style="color: red">*</span>
                        <asp:TextBox runat="server" ID="milkProd" CssClass="form-control" />
                    </div>
                </div>

                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <strong>Value Sum Insured: </strong><span class="asterisk" style="color: red">*</span>
                        <asp:TextBox runat="server" ID="valueInsured" TextMode="Number" CssClass="form-control" />
                    </div>
                </div>
            </div>
        </div>
    </div>
       <div class="row" style="align-content:center">
                <asp:Button runat="server" CssClass="btn btn-success center-block" Text="Save Details" ID="saveDetails" OnClick="saveDetails_Click"/>
            </div>


   <div class="panel-heading">
         Agriculture Risk Details
        </div>
    <div class="panel-body">
        <div runat="server" id="Div3"></div>
        <div class="table-responsive">
            <div id="Hrit" runat="server" visible="true">
            <table id="example1" class="table table-striped table-bordered">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Code</th>
                        <th>Name of Animal</th>
                        <th>Breed</th>
                        <th>Value/Sum Insured</th>
                        <th>Rate</th>
                        <th>Valuation Amount</th>
                        <th>Premium</th>
                        <th>Total Line Premiums</th>
                        <th>Remove</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                         var nav = Config.ReturnNav();
                        string docNo = Request.QueryString["requisitionNo"];
                         string tproduct = Request.QueryString["product"];
                        var data = nav.AgricultureRiskDetails.Where(x => x.Client_App_No == docNo && x.Product==tproduct && x.Policy_Type=="AGRICULTURAL INSURANCE").ToList();
                        int counter = 0;
                        if (data.Count > 0)
                        {
                            nextBtn.Visible = true;
                            foreach (var item in data)
                            {
                                counter++;
                    %>
                    <tr>
                        <td><%=counter %></td>
                          <td><% =item.Code%></td>
                        <td><% =item.Name_of_Animal%></td>
                        <td><% =item.Breed %></td>
                        <td><% =item.Value_Sum_Insured %></td>
                        <td><% =item.Rate %></td>
                        <td><% =item.Valuation_Amount %></td>
                        <td><% =item.Premium %></td>      
                         <td><% =item.Total_Line_Premiums %></td>                    
                        <td>
                              <label class="btn btn-danger" onclick="removeRisk('<%=item.Name_of_Animal %>','<%=item.Code %>');"><i class="fa fa-trash-o"></i> Remove</label></td>
                           
                        <%
                                }
                            }
                        %>
                    </tr>
                </tbody>
            </table>
                </div>
              <div id="uap" runat="server" visible="false">
            <table id="example4" class="table table-striped table-bordered">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Code</th>
                        <th>Name of Animal</th>
                        <th>Breed</th>
                        <th>Value/Sum Insured</th>
                        <th>Rate</th>                       
                        <th>Premium</th>
                        <th>Total Line Premiums</th>
                        <th>Remove</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                         var nav = Config.ReturnNav();
                        string docNo = Request.QueryString["requisitionNo"];
                         string tproduct = Request.QueryString["product"];
                        var data = nav.AgricultureRiskDetails.Where(x => x.Client_App_No == docNo && x.Product==tproduct && x.Policy_Type=="AGRICULTURAL INSURANCE").ToList();
                        int counter = 0;
                        if (data.Count > 0)
                        {
                            nextBtn.Visible = true;
                            foreach (var item in data)
                            {
                                counter++;
                    %>
                    <tr>
                        <td><%=counter %></td>
                          <td><% =item.Code%></td>
                        <td><% =item.Name_of_Animal%></td>
                        <td><% =item.Breed %></td>
                        <td><% =item.Value_Sum_Insured %></td>
                        <td><% =item.Rate %></td>                     
                        <td><% =item.Premium %></td>      
                         <td><% =item.Total_Line_Premiums %></td>                    
                        <td>
                              <label class="btn btn-danger" onclick="removeRisk('<%=item.Name_of_Animal %>','<%=item.Code %>');"><i class="fa fa-trash-o"></i> Remove</label></td>
                           
                        <%
                                }
                            }
                        %>
                    </tr>
                </tbody>
            </table>
                </div>
        </div>
        <div class="row">
            <div class="col-md-6 col-lg-6">
                <div class="form-group">
                    <label>Total Premiums</label><span class="text-danger" style="font-size: 25px">*</span>
                    <asp:TextBox CssClass="form-control" runat="server" ID="totalPremiums" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
     
        <div class="col-md-6 col-lg-6">
            <div class="form-group">
                <label>Total Premiums Payable</label><span class="text-danger" style="font-size: 25px">*</span>
                <asp:TextBox CssClass="form-control" runat="server" ID="premPayable" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        </div>
        <div runat="server" id="evalAm" visible="true">
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Evaluation Amount Total</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="evalAmount" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel-footer">
        <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" OnClick="nextBtn_Click" CausesValidation="false" ID="nextBtn" />
        <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" ID="backtostep3" CausesValidation="false" OnClick="backtostep3_Click" />
        <div class="clearfix"></div>
    </div>


    <% 
        }
        else if (step == 5)
        {
    %>
      <div class="panel panel-primary">
        <div class="panel-heading">
            Upload Supporting Documents
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 4 of 4 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="documentsfeedback"></div>
            <div class="form-group">
                <strong>Proposal Form:<i>(Please Upload Pdf files)</i></strong><span class="text-danger" style="font-size:25px">*</span>
                <asp:FileUpload runat="server" CssClass="form-control" ID="filetoupload" />
            </div>
            <br />
            <div class="form-group">
                <strong>ID/Passport:<i>(Please Upload pdf)</i></strong><span class="text-danger" style="font-size:25px">*</span>
                <asp:FileUpload runat="server" CssClass="form-control" ID="principalmemberphoto" />
            </div>
            <br />               
            <div class="form-group">
                <strong>Upload KRA PIN Certificate:</strong><span class="text-danger" style="font-size:25px">*</span>
                <asp:FileUpload runat="server" CssClass="form-control" ID="uploadKRAPinCertificate" />
            </div>
            <br />
            <div class="form-group">
                <strong>Other:<i>(Please Upload Pdf files)</i></strong>
                <asp:FileUpload runat="server" CssClass="form-control" ID="guardianshipletter" />
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
                             var tprincipleName = "";
                            var tFirstName = "";
                            var tlastName = "";
                            //string GrowerNumber = Request.QueryString["requisitionNo"].Trim();
                           
                            String filesFolder = ConfigurationManager.AppSettings["FilesLocation"] + "Agriculture Underwriting/";
                            String ApplicantionNo = Request.QueryString["requisitionNo"].Trim();
                            string str1 = Convert.ToString(ApplicantionNo);
                            ApplicantionNo = ApplicantionNo.Replace('/', '_');
                            ApplicantionNo = ApplicantionNo.Replace(':', '_');
                            var nav = Config.ReturnNav();
                            var applications = nav.ClientApplicationQuery.Where(r => r.No == ApplicantionNo).ToList();
                            foreach(var principalname in applications)
                            {
                                tFirstName = principalname.First_Name;
                                tlastName = principalname.Last_Name;
                            }
                            tprincipleName = tFirstName + "_"+tlastName;

                            String documentDirectory = filesFolder +  str1 +"_" + tprincipleName+ "/";
                            if (Directory.Exists(documentDirectory))
                            {
                                subMitApplication.Visible = true;


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
               <asp:Button runat="server" CssClass="btn btn-success pull-right" ID="subMitApplication" Text="Submit Application" OnClick="SubmitApplication_Click" Visible="false"/>
                <div class="clearfix"></div>
            </div>

        </div>
    </div>
    <%} %>

      <script src="bower_components/jquery/dist/jquery.min.js"></script>
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

    <script type="text/javascript">
        function PromoteSelectedDependant(dependantNumber) {
            document.getElementById("dependantToPromote").innerText = dependantNumber;
            document.getElementById("MainBody_promoteCode").value = dependantNumber;
            $("#PromoteModal").modal();
        }
    </script>
    <script type="text/javascript">
        function removeBeneficiary(BeneficairyNumber) {
            document.getElementById("beneficiaryToDelete").innerText = BeneficairyNumber;
            document.getElementById("MainBody_beneficiarycodetoRemove").value = BeneficairyNumber;
            $("#deleteBeneficiaryModal").modal();
        }
    </script>
      <script type="text/javascript">
          function removeCondition(ConditionCode) {
              document.getElementById("ConditionToDelete").innerText = ConditionCode;
              document.getElementById("MainBody_ConditioncodetoRemove").value = ConditionCode;
              $("#deleteConditionModal").modal();
          }
    </script>
          <script type="text/javascript">
              function removeRisk(riskName,riskCode) {
              document.getElementById("RiskToDelete").innerText = riskName;
              document.getElementById("MainBody_RisktoRemove").value = riskCode;
              $("#deleteRiskModal").modal();
          }
    </script>
    <script type="text/javascript">
        function removeDependant(dependantNumber) {
            document.getElementById("depedantToDelete").innerText = dependantNumber;
            document.getElementById("MainBody_removedependantCode").value = dependantNumber;
            $("#deleteDependantModal").modal();
        }
    </script>
    <script type="text/javascript">
        function editDependant(Dependant_Code, Name, Relationship, Date_Of_Birth, ID_No, Age, Depandant_Type) {
            document.getElementById('MainBody_txtdependantcodes').value = Dependant_Code;
            document.getElementById('MainBody_txtname').value = Name;
            document.getElementById('MainBody_txtdependantcodes').value = Dependant_Code;
            $('#MainBody_txtdateob').val(Date_Of_Birth).datepicker("update");
            document.getElementById('MainBody_lblIdNumber').value = ID_No;
            document.getElementById('MainBody_txtage').value = Age;
            if (Depandant_Type == "Spouse") {
                document.getElementById("MainBody_ttxtdependanttype").value = 1
            } else if (Depandant_Type == "Daughter") {
                document.getElementById("MainBody_ttxtdependanttype").value = 4;
            } else {
                document.getElementById("MainBody_ttxtdependanttype").value = 5;
            }
            $('#dependants').modal('show');
        }
    </script>
    <script type="text/javascript">
        function editBeneficiary(code, Name, Relationship, Date_Of_Birth, ID_No, Age, Allocation) {
            document.getElementById('MainBody_txtbeneficiary').value = code;
            document.getElementById('MainBody_txtnames').value = Name;
            document.getElementById('MainBody_bentxtrelationships').value = Relationship;
            $('#MainBody_txtdobs').val(Date_Of_Birth).datepicker("update");
            document.getElementById('MainBody_txtidnumbers').value = ID_No;
            document.getElementById('MainBody_txtages').value = Age;
            //document.getElementById('MainBody_txtgender2').value = Depandant_Type;
            document.getElementById('MainBody_txtallocation').value = Allocation;
            $('#beneficiaries').modal('show');
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
        function checkDate() {
            var enteredDate = document.getElementById('<%=txtDOB.ClientID%>').value;
            var dateValues = enteredDate.split("/");
            var dateToCheck = new Date(dateValues[2], dateValues[1] - 1, dateValues[0]);
            var today = new Date();
            var dateValid = new Date(today.getFullYear() - 18, today.getMonth() - 1, today.getDate());
            if (dateToCheck < dateValid) {
                //args.IsValid = false;
            }
            else {
                // args.IsValid = true;
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
             <div id="deleteRiskModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Confirm Removing Risk</h4>
                    </div>
                    <div class="modal-body">
                        <p>Are you sure you want to remove Risk <strong id="RiskToDelete"></strong>?</p>
                        <asp:TextBox runat="server" ID="RisktoRemove" type="hidden" />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                        <asp:Button runat="server" CssClass="btn btn-danger" Text="Remove Risk" OnClick="DeleteCondition_Click" />
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
