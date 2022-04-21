<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenMemberClaimNotifications.aspx.cs" Inherits="MajaniPortal.OpenMemberClaimNotifications" %>

<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            Open Client Notifications             
        </div>
        <div class="box-body">
            <div class="box">
                <div class="tab-content">
                    <div class="tab-pane active in" id="tab_1_1">
                        <div class="box-body">
                            <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th>Document No</th>
                                        <th>Customer No</th>
                                        <th>Policy No</th>
                                        <th>Date Of Reporting</th>
                                        <th>Date Of Accident</th>
                                        <th>Place Of Occurence</th>
                                        <th>Status</th>
                                    </tr>
                                </thead>
                                  <tbody>
                                    <%
                                        var nav = Config.ReturnNav();
                                         string requestor = Session["empNo"].ToString();
                                        var applications1 = nav.InsuranceClaims.Where(r => r.Customer_No==requestor);
                                        foreach (var application in applications1)
                                        {
                                    %>
                                    <tr>
                                        <td><%= application.No %></td>
                                        <td><%= application.Customer_No %></td>
                                        <td><%= application.Policy_No %></td>
                                        <td><%= application.Date_of_Reporting %></td>
                                        <td><%= application.Date_of_Accident_Loss_Death %></td>
                                        <td><%= application.Place_of_Occurence %></td>
                                        <td><%= application.Claim_Position %></td>
                                       
                                    </tr>
                                    <%
                                        }
                                    %>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="tab-pane fade setup-contents" id="tab_1_2">
                        <div class="box-header">
                            <h3 class="box-title">All Approved Claim Notifications</h3>
                        </div>
                        <div class="box-body">
                            <table id="example2" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th>Document No</th>
                                        <th>Customer No</th>
                                        <th>Policy No</th>
                                        <th>Date Of Reporting</th>
                                        <th>Date Of Accident</th>
                                        <th>Place Of Occurence</th>
                                        <th>Status</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%
                                        var applications = nav.InsuranceClaims.Where(r => r.Claim_Position =="CLAIM NOTIFICATION");
                                        foreach (var application in applications)
                                        {
                                    %>
                                    <tr>
                                        <td><%= application.No %></td>
                                        <td><%= application.Customer_No %></td>
                                        <td><%= application.Policy_No %></td>
                                        <td><%= application.Date_of_Reporting %></td>
                                        <td><%= application.Date_of_Accident_Loss_Death %></td>
                                        <td><%= application.Place_of_Occurence %></td>
                                        <td><%= application.Claim_Position %></td>
                                        <td>
                                            <%
                                                if (application.Claim_Position == "Pending Approval")
                                                {
                                            %>
                                            <label class="btn btn-danger" onclick="cancelApprovalRequest('<%=application.No %>');"><i class="fa fa-times"></i>Cancel Approval Request</label>

                                            <%   
                                                }
                                                else if (application.Claim_Position == "Open")
                                                {
                                            %>
                                            <label class="btn btn-success" onclick="sendApprovalRequest('<%=application.No %>');"><i class="fa fa-check"></i>Send Approval Request</label>
                                            <% 
                                                }
                                            %>
                                        </td>
                                    </tr>
                                    <%
                                        }
                                    %>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

