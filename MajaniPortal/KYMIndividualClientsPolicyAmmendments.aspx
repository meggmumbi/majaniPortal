<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="KYMIndividualClientsPolicyAmmendments.aspx.cs" Inherits="MajaniPortal.KYMIndividualClientsPolicyAmmendments" %>

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
                        <label>Customer Category</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="customerCategorys" ReadOnly="true" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Customer SubCategory</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="customerSubCategorys" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Applicant Type</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:TextBox CssClass="form-control select2" runat="server" ID="applicationTypesdetails" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                   <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Has Grower No.?</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:CheckBox CssClass="form-control" runat="server" ID="hasgrowerNo" ReadOnly="true"></asp:CheckBox>
                    </div>
                </div>
            </div>
                <div class="row">
                    <div class="col-md-6 col-lg-6">
                        <div class="form-group">
                            <label>Grower Type of Applicant</label><span class="text-danger" style="font-size:25px">*</span>
                            <asp:TextBox CssClass="form-control" runat="server" ID="growerapplicanttypedetails" ReadOnly="true" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6">
                        <div class="form-group">
                            <label>Grower No./Client ID</label><span class="text-danger" style="font-size:25px">*</span>
                            <asp:TextBox CssClass="form-control" runat="server" ID="growerNumber"  MaxLength="9" ReadOnly="true"></asp:TextBox>
                             <span class="error" id="growerdetails" runat="server" style="background-color: red"></span>
                        </div>
                    </div>
                </div>
                <div class="row">
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
                <div class="row">
                    <div class="col-md-6 col-lg-6" runat="server" id="financier">
                        <div class="form-group">
                            <label>Financier</label><span class="text-danger" style="font-size:25px">*</span>
                            <asp:TextBox CssClass="form-control" runat="server" ID="txtfinanciers" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Id Type</label><span class="text-danger" style="font-size:25px">*</span>
                          <asp:DropDownList CssClass="form-control" runat="server" ID="idtypes" Placeholder="Select Departments"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>ID No/Passport</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtIdNumber"></asp:TextBox></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" Display="dynamic" ValidationExpression="^([\S\s]{6,8})$" ControlToValidate="txtIdNumber" ErrorMessage="Please Enter the Correct ID No/Passport Value,It must be a Whole number between 6 and 8" BackColor="Red" />
                     <span class="error" id="idNumberPassport" runat="server" style="background-color: red"></span>
                    </div>
                </div>
               
            </div>
            <div class="row">
                 <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Title </label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:DropdownList CssClass="form-control" runat="server" ID="lbltitles"></asp:DropdownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>First name </label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtfirstname" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>               
            </div>
            <div class="row">
                 <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Middle name </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtMiddleName" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Last name </label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtlastname" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Gender</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:DropdownList CssClass="form-control" runat="server" ID="lblgenders"></asp:DropdownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Date Of Birth</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:TextBox CssClass="form-control datepicker" TextMode="Date" runat="server" ID="txtDOB" ></asp:TextBox>
                        <span class="error" id="datevalidator" runat="server" style="background-color: red"></span>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" EnableClientScript="true" ErrorMessage="The age is below 18 Years. This is not allowed for Applicants below 18 Years" ClientValidationFunction="checkDate" ControlToValidate="txtDOB" BackColor="Red"></asp:CustomValidator>
                        
                    </div>
                </div>                
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Occupation</label><span class="text-danger" style="font-size:25px">*</span>
                         <asp:DropdownList CssClass="form-control" runat="server" ID="ttxtoccupation" ></asp:DropdownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>KRA Pin No</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="krapinNumber" ReadOnly="true"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" Display="dynamic" ValidationExpression="^([\S\s]{11,11})$" ControlToValidate="krapinNumber" ErrorMessage="Please Enter the Correct KRA Pin Number Value,It must be a Whole number with 11 Characters" BackColor="Red" />
                    </div>
                </div>                
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>County Code</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:DropdownList CssClass="form-control select2" runat="server" ID="lblcountyCodes" ></asp:DropdownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Marital status </label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:DropdownList CssClass="form-control" runat="server" ID="lblmaritalstatuss"></asp:DropdownList>
                    </div>
                </div>                
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Huduma No</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtHudumaNo" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Country Of Residence</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:TextBox CssClass="form-control select2" runat="server" ID="countyofresidence" ReadOnly="true"></asp:TextBox>
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
                        <asp:TextBox CssClass="form-control" runat="server" ID="telnumber1" TextMode="Number" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Tel/Mobile No2. </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="telnumber2" TextMode="Number" ReadOnly="true"></asp:TextBox>

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
                        <label>Postal Code </label><span class="text-danger" style="font-size:25px" >*</span>
                        <asp:DropdownList CssClass="form-control select2" runat="server" ID="postcodes" OnSelectedIndexChanged="PostCodes_OnClick" AutoPostBack="true" />
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>City</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblcity"  required="true" readOnly="true"></asp:DropDownList>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Google+</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtgoogle" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Twitter</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txttwitter" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Facebook</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtfcebook" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>LinkedIn</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtlinkedin" ReadOnly="true"></asp:TextBox>
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
            Policy Details <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 3 of 5 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="policyfeedbackdetails"></div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Department</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="lbldepartmentdetails" ReadOnly="true" ></asp:TextBox>
                    </div>
                </div>             
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Policy Type</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="lblpolicyTypedetails"  ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Product </label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:TextBox CssClass="form-control select2" runat="server" ID="lblproduct" ReadOnly="true"></asp:TextBox>
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
                        <label>Service Period</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="serviceperiod" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                 <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Policy Business Type</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="membertypes" ></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">    
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Mode of Payment</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="modeofpaymentss"  OnSelectedIndexChanged="ValidateFormUpload" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div> 
                 <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label runat="server" ID="lbldhb"><b>DHB</b></asp:Label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="dailyhealthbenefits"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">   
                  <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Invoice Period</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="invoiceperiod" ></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Agent Detail</label><span class="text-danger" style="font-size:25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="agentDetail"></asp:DropDownList>
                    </div>
                </div>
            </div>
           
            <div class="row">  
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="agentsubcategory" runat="server"><b>Agent SubCategory</b></asp:Label><span class="text-danger" style="font-size:25px">*</span>
                      <asp:DropDownList CssClass="form-control select2" runat="server" ID="lblagentsubcategorydetail"  OnSelectedIndexChanged="AgentDetails_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>  
                    </div>
                </div>                
                <div class="col-md-6 col-lg-6">
                    <asp:Label ID="agentsalespersoncode" runat="server"><b>Agent Sales Person Code</b></asp:Label><span class="text-danger" style="font-size:25px">*</span>
                    <div class="form-group">  
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="lblsalesgentcode" ></asp:DropDownList>  
                    </div>
                </div>       
                </div>
                      <div runat="server" id="generalformgurantor">
                <div class="row">
                    <div class="col-md-12 col-lg-12">
                        <div class="form-group">
                            <label>Upload Guarantor Form</label><span class="text-danger" style="font-size: 25px">*</span>
                            <asp:FileUpload runat="server" CssClass="form-control" ID="guarantorform" />
                        </div>
                    </div>
                </div>
            </div>
              <div runat="server" id="generalformcheckoffs">
                <div class="row">
                    <div class="col-md-12 col-lg-12">
                        <div class="form-group">
                            <label>Upload Check Off Form</label><span class="text-danger" style="font-size: 25px">*</span>
                            <asp:FileUpload runat="server" CssClass="form-control" ID="checkoffform" />
                        </div>
                    </div>
                </div>
            </div>
            <div runat="server" id="generalformgreenleaf">
                <div class="row">
                    <div class="col-md-12 col-lg-12">
                        <div class="form-group">
                            <label>Upload Green-Leaf Form</label><span class="text-danger" style="font-size: 25px">*</span>
                            <asp:FileUpload runat="server" CssClass="form-control" ID="greenleafform" />
                        </div>
                    </div>
                </div>
            </div>
            <div runat="server" id="generalformktdastaffdeduction">
                <div class="row">
                    <div class="col-md-12 col-lg-12">
                        <div class="form-group">
                            <label>Upload KTDA Staff Deduction Form</label><span class="text-danger" style="font-size: 25px">*</span>
                            <asp:FileUpload runat="server" CssClass="form-control" ID="ktdastafform" />
                        </div>
                    </div>
                </div>
            </div>     
            <div class="row"> 
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="referalmobilenumber" runat="server"><b>Referral Mobile Number</b></asp:Label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtreferalmobilenumber" TextMode="Number"  ></asp:TextBox>
                    </div>
                </div>                
               <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="referralname" runat="server"><b>Referral Name</b></asp:Label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtrefferalname"></asp:TextBox>
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
    <asp:ScriptManager ID="SCManager" runat="server" />
       <div class="panel panel-primary">
        <div class="panel-heading">
            Dependants Details
          <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 4 of 5 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="txtdependantsfeedbackdetails"></div>
            <div class="panel-body pull-right">
                <label class="btn btn-success" data-toggle="modal" data-target="#dependants"><i class="fa fa-plus fa-fw"></i>Add Dependants</label>
            </div>         
            <table id="example1" class="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th>Dependant Code</th>
                        <th>Name</th>
                        <th>Relationship</th>
                        <th>DOB</th>
                        <th>ID No</th>
                        <th>Age</th>
                        <th>Dependant Type</th>
                        <th>Photo</th>
                        <th>Promote</th>
                        <th>Remove</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                    var nav = Config.ReturnNav();
                    var requisitionNo = Request.QueryString["QuoteNo"].Trim();
                    string GrowerNumber = Request.QueryString["GrowerNo"].Trim();
                    var applications = nav.PolicyDependants.Where(r => r.Policy_Qoute_No == requisitionNo);
                    foreach (var application in applications)
                    {
                         
                       %>
                    <tr>
                       <td><%= application.Dependant_Code %></td>
                        <td><%= application.Name %></td>
                        <td><%= application.Relationship %></td>
                        <td><%= application.Date_Of_Birth %></td>
                        <td><%= application.ID_No %></td>
                        <td><%= application.Age %></td>
                        <td><%= application.Depandant_Type %></td>
                         <td> </td>
                        <td>
                            <label class="btn btn-success" onclick="PromoteSelectedDependant('<%=application.Dependant_Code %>')"><i class="fa fa-plus"></i>Promote</label>
                        </td>
                        <td>
                            <label class="btn btn-danger" onclick="removeDependant('<%=application.Dependant_Code %>');"><i class="fa fa-trash"></i>Remove</label></td>

                    </tr>
                    <%
                        }
                    %>
                </tbody>
            </table>
        </div>
        <div id="PromoteModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Confirm Promoting Dependant</h4>
                    </div>
                    <div class="modal-body">
                        <p>Are you sure you want to Promote Dependant <strong id="dependantToPromote"></strong>?</p>
                        <asp:TextBox runat="server" ID="promoteCode" type="hidden" />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                        <asp:Button runat="server" CssClass="btn btn-success" Text="Promote Dependant" OnClick="PromoteDepedant_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div id="deleteDependantModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Confirm Removing Dependant</h4>
                    </div>
                    <div class="modal-body">
                        <p>Are you sure you want to removing the Dependant <strong id="depedantToDelete"></strong>?</p>
                        <asp:TextBox runat="server" ID="removedependantCode" type="hidden" />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                        <asp:Button runat="server" CssClass="btn btn-danger" Text="Delete Dependant" OnClick="DeleteDependant_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-primary">
        <div class="panel-heading">
            Beneficiaries Details
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 4 of 5 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>

        <div class="panel-body pull-right">
            <label class="btn btn-success" data-toggle="modal" data-target="#beneficiaries"><i class="fa fa-plus fa-fw"></i>Add Beneficiaries</label>
        </div>
        <br />     
        <div class="box-body">
             <div runat="server" id="benefeciariesfeedback"></div>
            <table id="example2" class="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th>Beneficiary</th>
                        <th>Name</th>
                        <th>Relationship</th>
                        <th>DOB</th>
                        <th>ID No</th>
                        <th>Age</th>
                        <th>Allocation</th>
                        <th>Remove</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                        var requisitionNo1 = Request.QueryString["QuoteNo"].Trim();
                        var applications1 = nav.PolicyBeneficiaries.Where(r => r.Policy_Qoute_No == requisitionNo);
                        foreach (var application in applications1)
                        {
                    %>
                    <tr>
                        <td><% =application.Beneficiary%></td> 
                        <td><%= application.Name %></td>
                        <td><%= application.Relationship %></td>
                        <td><%= application.Date_Of_Birth %></td>
                        <td><%= application.ID_No %></td>
                        <td><%= application.Age %></td>
                        <td><%= application.Allocation %></td>
                        <td>
                            <label class="btn btn-danger" onclick="removeBeneficiary('<%=application.Beneficiary %>');"><i class="fa fa-trash"></i>Remove</label></td>
                    </tr>
                    <%
                        }
                    %>
                </tbody>
            </table>
        </div>
        <div class="panel-footer">
            <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" OnClick="previousstep_Click" />
            <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" OnClick="VadlidateBeneficiary_Click" ID="Button1" />
            <div class="clearfix"></div>
        </div>
        <div id="deleteBeneficiaryModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Confirm Removing Beneficiary</h4>
                    </div>
                    <div class="modal-body">
                        <p>Are you sure you want to removing the Beneficiary <strong id="beneficiaryToDelete"></strong>?</p>
                        <asp:TextBox runat="server" ID="beneficiarycodetoRemove" type="hidden" />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                        <asp:Button runat="server" CssClass="btn btn-danger" Text="Remove Beneficiary" OnClick="DeleteBeneficiary_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div id="beneficiaries" class="modal fade" role="dialog">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Add Beneficiaries Details</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-6 col-lg-6">
                                <div class="form-group">
                                    <strong>Beneficiary:</strong><span class="text-danger" style="font-size:25px">*</span>
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="Beneficiary" ID="txtbeneficiary" />
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6">
                                <div class="form-group">
                                    <strong>Name:</strong><span class="text-danger" style="font-size:25px">*</span>
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="Name" ID="txtnames" />
                                </div>
                            </div>
                        </div>
                        <asp:UpdatePanel ID="SCPanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-6 col-lg-6">
                                        <div class="form-group">
                                            <strong>Relationship:</strong><span class="text-danger" style="font-size:25px">*</span>
                                            <asp:DropDownList runat="server" CssClass="form-control" ID="bentxtrelationships" />
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-lg-6">
                                        <div class="form-group">
                                            <strong>Date Of Birth:</strong><span class="text-danger" style="font-size:25px">*</span>
                                            <asp:TextBox runat="server" CssClass="form-control bootstrapdatepicker" placeholder="Date of Birth" ID="txtdobs" TextMode="Date" AutoPostBack="true" OnTextChanged="ValidateAge_Text" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 col-lg-6">
                                        <div class="form-group">
                                            <strong>Id number:</strong><span class="text-danger" style="font-size:25px">*</span>
                                            <asp:TextBox runat="server" CssClass="form-control" placeholder="ID Number" ID="txtidnumbers" />
                                            <asp:RegularExpressionValidator runat="server" Display="dynamic" ValidationExpression="^([\S\s]{6,8})$" ControlToValidate="txtidnumbers" ErrorMessage="Please Enter the Correct ID No/Passport Value,It must be a Whole number between 6 and 8" BackColor="Red" />
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-lg-6">
                                        <div class="form-group">
                                            <strong>Age:</strong><span class="text-danger" style="font-size:25px">*</span>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtages" TextMode="Number" placeholder="Age" />
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="row">
                            <div class="col-md-6 col-lg-6">
                                <div class="form-group">
                                    <strong>Allocation:</strong>
                                    <asp:TextBox runat="server" CssClass="form-control " placeholder="Allocation" ID="txtallocation" TextMode="Number" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" CssClass="btn btn-success" Text="Add Beneficiaries" OnClick="AddBeneficaries_Click" />
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="dependants" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Dependant Details</h4>
                </div>
                <asp:UpdatePanel ID="SCPanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <strong>Dependant Code:</strong><span class="text-danger" style="font-size:25px">*</span>
                                        <asp:TextBox runat="server" CssClass="form-control" placeholder="Dependant Code." ID="txtdependantcodes"  />
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <strong>Name:</strong><span class="text-danger" style="font-size:25px">*</span>
                                        <asp:TextBox runat="server" CssClass="form-control" placeholder="Name" ID="txtname" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <strong>Relationship:</strong><span class="text-danger" style="font-size:25px">*</span>
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="txtrelationship" AutoPostBack="true" OnTextChanged="Update_Text"  />
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <strong>Date Of Birth:</strong><span class="text-danger" style="font-size:25px">*</span>
                                        <asp:TextBox runat="server" CssClass="form-control datepicker" placeholder="Date of Birth" ID="txtdateob" TextMode="Date" AutoPostBack="true" OnTextChanged="ValidateDate_Text"  />
                                        <span class="error" id="lblError" runat="server" style="background-color: red"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <strong>Id number:</strong><span class="text-danger" style="font-size:25px">*</span>
                                        <asp:TextBox runat="server" CssClass="form-control" placeholder="ID Number" ID="lblIdNumber" />
                                        <asp:RegularExpressionValidator runat="server" Display="dynamic" ValidationExpression="^([\S\s]{6,8})$" ControlToValidate="lblIdNumber" ErrorMessage="Please Enter the Correct ID No/Passport Value,It must be a Whole number between 6 and 8" BackColor="Red" />
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <strong>Age:</strong><span class="text-danger" style="font-size:25px">*</span>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtage" TextMode="Number" placeholder="Age" ReadOnly="true"  />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <strong>Gender:</strong><span class="text-danger" style="font-size:25px">*</span>
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="txtgenders" />
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <strong>Dependant Type:</strong><span class="text-danger" style="font-size:25px">*</span>
                                        <asp:TextBox ID="ttxtdependanttype" runat="server" CssClass="form-control" ReadOnly="True" ></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <strong>DHB:</strong><span class="text-danger" style="font-size:25px">*</span>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="dhb" ReadOnly="true" ></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <strong>DHB Premium:</strong><span class="text-danger" style="font-size:25px">*</span>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="dhbpremium" ReadOnly="true" ></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <strong>Upload Dependant Photo:</strong>
                                        <asp:FileUpload ID="depedantphoto" runat="server" CssClass="form-control" />
                                    </div>
                                </div>
                                  <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                     <p><b>Have you ever suffered from a serious health condition?<span class="text-danger" style="font-size:25px">*</span></b></p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<asp:DropDownList  runat="server" ID="dependantconditions"></asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" CssClass="btn btn-success" Text="Save Dependant" OnClick="AddDependants_Click" />
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
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
                <strong>Scanned application:<i>(Please Upload Pdf files)</i></strong><span class="text-danger" style="font-size:25px">*</span>
                <asp:FileUpload runat="server" CssClass="form-control" ID="filetoupload" />
            </div>
          <%--  <br />
            <div class="form-group">
                <strong>Principal Member Photo:<i>(Please Upload Png/jpg files)</i></strong><span class="text-danger" style="font-size:25px">*</span>
                <asp:FileUpload runat="server" CssClass="form-control" ID="principalmemberphoto" />
            </div>
            <br />--%>
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

                            String filesFolder = ConfigurationManager.AppSettings["FilesLocation"] + "MicroInsurance Amendement/";
                            String ApplicantionNo = Request.QueryString["ContractNo"].Trim();
                            ApplicantionNo = ApplicantionNo.Replace('/', '_');
                            ApplicantionNo = ApplicantionNo.Replace(':', '_');
                            String documentDirectory = filesFolder + ApplicantionNo + "/";
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
                <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Submit Application" OnClick="SubmitApplication_Click" />
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
