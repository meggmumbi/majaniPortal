<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewClaimNotificationAgriculture.aspx.cs" Inherits="MajaniPortal.NewClaimNotificationAgriculture" %>
<%@ Import Namespace="MajaniPortal" %>
<%@ Import Namespace="System.IO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">

      <%
        int step = 1;
        int ClaimType = 1;
        try
        {
            
            step = Convert.ToInt32(Request.QueryString["step"]);
            ClaimType = Convert.ToInt32(Request.QueryString["ClaimType"]);
            if (step > 4 || step < 1)
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
            <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 1 of 3<i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="feedbackdetails"></div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Customer No.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="lblselectedcustomers" ReadOnly="true"></asp:TextBox>
                    </div>
                    </div>
                     <div class="col-md-6">
                    <div class="form-group">
                        <label>Name.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtnames" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Policy No.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblpolicynumber"></asp:DropDownList>
                    </div>                 
                </div>     
                    <div class="col-md-6">
                    <div class="form-group">
                        <label>Date Of Accident/Loss/Death</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="occDate" TextMode="Date"></asp:TextBox>
                    </div>                 
                </div> 
                     <div class="col-md-6">
                    <div class="form-group">
                        <label>Time Of Accident/Loss/Death</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="occTime" TextMode="Time"></asp:TextBox>
                    </div>                 
                </div>   
                         
                <div class="col-md-6">                
                    <div class="form-group">
                        <label>Place of Occurence Types</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="placeOfOccurences"></asp:TextBox>
                    </div>
                </div>
                     <div class="col-md-6">
                    <div class="form-group">
                        <label>Risk Code</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="riskCode" OnSelectedIndexChanged="riskCode_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>                 
                </div> 
                     <div class="col-md-6">                
                    <div class="form-group">
                        <label>Milk Production Per Day</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="milkProd" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                     <div class="col-md-6">                
                    <div class="form-group">
                        <label>Age In years</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="ageYrs" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                     <div class="col-md-6">                
                    <div class="form-group">
                        <label>Sum Insured</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="sumIns" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                     <div class="col-md-6">                
                    <div class="form-group">
                        <label>Date Purchased</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="datePurch" TextMode="Date"></asp:TextBox>
                    </div>
                </div>
                 <div class="col-md-6">                
                    <div class="form-group">
                        <label>Price Paid</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="pricePaid" TextMode="Number"></asp:TextBox>
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

      <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb float-sm-right">
                <li class="breadcrumb-item"><a href="Home.aspx">Dashboard</a></li>
                <li class="breadcrumb-item active">Claim Questions Response</li>
            </ol>
        </div>
    </div>
    <div class="panel panel-primary">
        <div class="panel-heading">
             Questions <i><strong>(Please provide response for the following questions)</strong></i>
            <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 2 of 4 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
      <div class="panel-body">
            <div runat="server" id="studentsServices"></div>
             
             
                <div class="row" style="justify-content:center">
                <input type="hidden" value="<% =Request.QueryString["requisitionNo"] %>" id="txtAppNo" />
                <div class="col-md-12">
                <div class="table-responsive">
                    <table class="table table-bordered table-striped tblselectedServices" id="example8">
                        <thead>
                            <tr>

                               
                                <th>#</th>
                                <th>Question Code</th>
                                <th>Category</th>
                                <th>Description</th>
                                <th>Response</th>
                              
                            </tr>
                        </thead>
                        <tbody>

                            <% 
                                var nav = Config.ReturnNav();
                                string docNo = Request.QueryString["requisitionNo"].Trim();
                                var Activities = nav.claimQnResponse.Where(r=>r.Claim_No==docNo).ToList();
                              
                                    foreach (var activity in Activities)
                                    {
                            %>
                            <tr>
                               
                                 <td><input type="checkbox" id="servicesSelected" name="servicesSelected" class="checkboxes" value="<% =activity.Question_ID %>" /></td>
                                <td><%=activity.Question_ID %></td>
                                <td><%=activity.Category_Description %></td>
                              <td><%=activity.Question_Description %></td>
                              <td><input type="text" class="form-control" autocomplete="off" id="comment" /></td>                             

                                <%}
                                     %>
                            </tr>
                        </tbody>
                    </table>
                </div>
                    </div>
                

             
            </div>
         
                 <div class="col-md-12 col-lg-12">                    
                    <input type="button" id="btn_apply_SubmitServices" class="btn btn-success center-block btn_apply_SubmitServices" name="btn_apply_SubmitServices" value="Submit Responses" />
                </div>

        </div>
        </div>


    <div class="panel-heading">
        Responses
    </div>
    <div class="panel-body">
        <div class="table-responsive">
            <table id="example4" class="table table-striped table-bordered">
                <thead>
                    <tr>

                        <th>Question Code</th>
                        <th>Category</th>
                        <th>Question Description</th>
                        <th>Response</th>

                    </tr>
                </thead>
                <tbody>
                    <%

                        string docNos = Request.QueryString["requisitionNo"].Trim();
                        var data = nav.claimQnResponse.Where(r => r.Claim_No == docNos && r.Description != "").ToList();
                        if (data.Count > 0)
                        {
                            nextAttach.Visible = true;
                            foreach (var item in data)
                            {

                    %>
                    <tr>

                        <td><% =item.Question_ID%></td>
                        <td><% =item.Category_Description%></td>
                        <td><% =item.Question_Description %></td>
                        <td><% =item.Description %></td>
                        <td>
                            <label class="btn btn-danger" onclick="removeFacilities('<%=item.Question_ID %>','<%=item.Description %>');"><i class="fa fa-trash-o"></i>Remove</label></td>
                        <%
                            }
                        }
                        %>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div class="panel-footer">        
      
        <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" ID="backToPhysical"  OnClick="backToPhysical_Click" />
       
        <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" OnClick="nextAttach_Click" id="nextAttach" Visible="false"/>
        <div class="clearfix"></div>
    </div>

        <%
            }

   
        else if (step == 3)
        {
    %>
    <div class="panel panel-primary">
        <div class="panel-heading">
            Claim Verifications
            <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 2 of 3<i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="verificationdetails"></div>
            <%
                if (ClaimType == 1)
                {
            %>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Event Type.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="eventtypes"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Patient Name.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="PatientName"></asp:TextBox>
                    </div>

                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Hospital.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="hospital"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Date of Admission</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="dateofAdmission" TextMode="Date"></asp:TextBox>
                    </div>

                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Date of Discharge</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="dateofdischarge" TextMode="Date" OnTextChanged="ValidateNumberOfDays_Click" AutoPostBack="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Re-imbursement Type</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="reimbursementType" AppendDataBoundItems="true">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Medical Soft</asp:ListItem>
                            <asp:ListItem Value="2">Medical MIB</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>No of Days(Occurence Place)</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="noOfDays" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Surgery Benefit</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="SurgeryBenefit" TextMode="Number"></asp:TextBox>
                    </div>


                </div>


                <div class="col-md-6">
                    <div class="form-group">
                        <label>Invoice No.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="invoiceNo"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Invoice Amount</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="invoiceAmount" TextMode="Number"></asp:TextBox>
                    </div>

                </div>
            </div>
        <%}
            else
            {
        %>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Event Type.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="eventtypes1"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Date of Death</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtDateofDate" TextMode="Date"></asp:TextBox>
                    </div>

                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label>Deceased Name.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="deceasedName"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>Burial Permit No</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="buriapermitNo"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Payment Type.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="paymenttype" AppendDataBoundItems="true">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Death Soft</asp:ListItem>
                            <asp:ListItem Value="2">Death MIB</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        <%} %>
        <div class="panel-footer">
            <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" OnClick="previousstep_Click" />
            <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" OnClick="SubmitValidations_Click" />
            <div class="clearfix"></div>
        </div>
    </div>
    </div>
    <% 
        }
        else if (step == 4)
        {
    %>
    <div class="panel panel-primary">
        <div class="panel-heading">
            Upload Supporting Documents
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 3 of 3 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="documentsfeedback"></div>
       <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <strong>Vet Valuation:</strong><span class="text-danger" style="font-size: 25px">*</span>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="filetoupload" />
                </div>
                </div>

           </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <strong>Other Document:</strong>
                        <asp:FileUpload runat="server" CssClass="form-control" ID="otherdocuments" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel-footer">
                        <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Upload" ID="uploaddocuments" OnClick="upload_Click" />
                        <div class="clearfix"></div>
                    </div>
                </div>
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

                            String filesFolder = ConfigurationManager.AppSettings["FilesLocation"] + "Claims Notification Card-Agri/";
                            String PolicyNo = Request.QueryString["requisitionNo"].Trim();
                            PolicyNo = PolicyNo.Replace('/', '_');
                            PolicyNo = PolicyNo.Replace(':', '_');
                         
                            String documentDirectory = filesFolder + PolicyNo + "_" + "/";
                            if (Directory.Exists(documentDirectory))
                            {
                                validations.Visible = true;

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
                <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Send Claim for Verifications" OnClick="Sendforvalidations_Click" ID="validations" Visible="false" />

                <div class="clearfix"></div>
            </div>

        </div>
    </div>
    <%} %>
</asp:Content>
