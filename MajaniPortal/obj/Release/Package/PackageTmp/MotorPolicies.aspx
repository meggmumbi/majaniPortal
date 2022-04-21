<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MotorPolicies.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MajaniPortal.MotorPolicies" %>

<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            Motor UnderWriting Policies           
        </div>
        <div class="box-body">
            <div class="box">
                <div runat="server" id="opencommunicationsdetails"></div>
                <div class="tab-content">
                    <div class="tab-pane active in" id="tab_1_1">
                        <div class="box-body">
                            <table id="example1" class="table table-bordered table-striped datatable">
                                <thead>
                                    <tr>
                                        <th>Contract No</th>
                                        <th>Customer No</th>
                                        <th>Name</th>
                                        <th>Policy Start Date</th>
                                        <th>Policy End Date</th>
                                        <th>Claim</th>
                                        <th>Ammend</th>
                                         <th>Renewal</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%
                                        var nav = Config.ReturnNav();
                                        var applications = nav.ServiceContracts.Where(x => x.Business_Type == "General").ToList();
                                        foreach (var application in applications)
                                        {
                                    %>
                                    <tr>
                                        <td><%= application.Contract_No %></td>
                                        <td><%= application.Customer_No %></td>
                                        <td><%= application.Name %></td>
                                        <td><%= Convert.ToDateTime(application.Policy_Start_Date).ToString("dd/MM/yyyy")%></td>
                                        <td><%= Convert.ToDateTime(application.Policy_End_Date).ToString("dd/MM/yyyy")%></td>
                                       <td>
                                        <a href="MotorClaimNotifications.aspx?ContractNo=<%=application.Contract_No %>&&CustomerNo=<%=application.Customer_No %>" class="btn btn-success"><i class="fa fa-share"></i>Claim</a>
                                        </td> 
                                        <%
                                        if (application.Customer_Type == "Individual")
                                         {
                                          %>
                                        <td>
                                        <a href="MotorIndividualPolicyAmmendments.aspx?ContractNo=<%=application.Contract_No %>&&CustomerNo=<%=application.Customer_No %>" class="btn btn-success"><i class="fa fa-share"></i>Ammend</a>
                                        </td>
                                        <%
                                            }
                                            if (application.Customer_Type == "Corporate")
                                            { %>  
                                        <td>
                                        <a href="MotorCorporatePolicyAmmendments.aspx?ContractNo=<%=application.Contract_No %>&&CustomerNo=<%=application.Customer_No %>" class="btn btn-success"><i class="fa fa-share"></i>Ammend</a>
                                        </td>
                                        <% } %> 
                                         <td>
                                        <a href="MotorIndividualPolicyRenewals.aspx?ContractNo=<%=application.Contract_No %>&&CustomerNo=<%=application.Customer_No %>" class="btn btn-success"><i class="fa fa-share"></i>Renewal</a>
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
