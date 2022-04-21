<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MotorIndividualPolicyRenewals.aspx.cs" Inherits="MajaniPortal.MotorIndividualPolicyRenewals" %>

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
                        <label>Contract No</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control " runat="server" ID="contractNo" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Policy Holder Names</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="policyholdeName" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Mobile No</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control select2" runat="server" ID="MobileNumber" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Customer Category</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="customerCategory" ReadOnly="true" ></asp:TextBox>

                    </div>
                </div>
            </div>
                <div class="row">
                    <div class="col-md-6 col-lg-6">
                        <div class="form-group">
                            <label>Policy Type</label><span class="text-danger" style="font-size: 25px">*</span>
                            <asp:TextBox CssClass="form-control" runat="server" ID="policyType" ReadOnly="true" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6">
                        <div class="form-group">
                            <label>Policy No</label><span class="text-danger" style="font-size: 25px">*</span>
                            <asp:TextBox CssClass="form-control" runat="server" ID="PolicyNumbes" MaxLength="9" ReadOnly="true"></asp:TextBox>
                            <span class="error" id="growerdetails" runat="server" style="background-color: red"></span>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-lg-6" >
                        <div class="form-group">
                            <label>Insurer Name</label><span class="text-danger" style="font-size: 25px">*</span>
                            <asp:TextBox CssClass="form-control upper-case" runat="server" ID="insurareName" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6">
                        <div class="form-group">
                            <label>New Policy Start Date</label><span class="text-danger" style="font-size: 25px">*</span>
                            <asp:TextBox CssClass="form-control" runat="server" ID="policyStartDates" TextMode="Date" d OnTextChanged="validateEndDate_Click" AutoPostBack="true" ></asp:TextBox>
                        </div>
                    </div>
                </div>
               <div class="row">
                   <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label runat="server"><b>Service Period</b></asp:Label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="calenderDays" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Policy End Date</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control " runat="server" ID="policyEndDates" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                 <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Policy Business Type</label>
                        <asp:TextBox CssClass="form-control upper-case" runat="server" ID="policybusinessType" ReadOnly="true">Renewal</asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Agent Type</label>
                        <asp:DropDownList CssClass="form-control upper-case" runat="server" ID="agentDetails" OnSelectedIndexChanged="AgentDetails_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
            </div>
             <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Agent Name</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="salesgentcode"></asp:DropDownList>
                    </div>
                </div>
                 <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Mode of Payments</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="modeofpayments"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Payment Reference Code</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="paymentsReferenceCode"></asp:TextBox>
                    </div>
                </div>
                 <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Date Paid</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" TextMode="Date" runat="server" ID="datepaid"></asp:TextBox>
                    </div>
                </div>
            </div>
             <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Payment Amount</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="paidAmount" TextMode="Number"></asp:TextBox>
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
            Risk Details
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 2 of 4 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
            <br />
            <br />
        <div runat="server" id="submitApplications"></div>
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
                            <th>Update</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%
                            var nav = Config.ReturnNav();
                            string CustomerNo = Request.QueryString["CustomerNo"].Trim();
                            string QuoteNo = Request.QueryString["QuoteNo"].Trim();
                            string ContractNo = Request.QueryString["ContractNo"].Trim();
                            var applications = nav.QuoteRiskDetails.Where(r => r.Qoute_No == QuoteNo&&r.Vehicle_Status=="Active");
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
                             <label class="btn btn-success" onclick="UpdateValueInsured('<%=application.Registration_No %>','<%=application.Rate %>');"><i class="fa fa-pencil"></i>Update </label>
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
            <div class="panel-footer">
                <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" OnClick="previousstep_Click" />
                <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Initiate Renewal" OnClick="SubmitApplication_Click" />
                <div class="clearfix"></div>
            </div>
    </div>
     <div id="UpdateRiskModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Update Value/SumInsured Risk Details</h4>
                    </div>
                    <div class="box-body">
                      <asp:TextBox runat="server" ID="registrationNumber" type="hidden" />
                     <div class="row">
                    <div class="col-md-6 col-lg-6">
                        <div class="form-group">
                            <label>Value/Sum Insured</label>
                            <asp:TextBox CssClass="form-control" runat="server" ID="valueinsured" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6">
                        <div class="form-group">
                            <label>Rate</label>
                            <asp:TextBox CssClass="form-control" runat="server" ID="rate" ReadOnly="true"></asp:TextBox>
                        </div>
                     </div>
                     </div>
                     </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                        <asp:Button runat="server" CssClass="btn btn-success" Text="Update Amount" OnClick="UpdateRiskDetails_Click" />
                    </div>
                </div>
            </div>
         </div>
    <%} %>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
      <script type="text/javascript">
          function UpdateValueInsured(RegistrationNumber,rate) {
              document.getElementById("MainBody_rate").value = rate;
              document.getElementById("MainBody_registrationNumber").value = RegistrationNumber;
             $("#UpdateRiskModal").modal();
         }
    </script>
</asp:Content>
