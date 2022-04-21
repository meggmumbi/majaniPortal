<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MotorDebitNotes.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MajaniPortal.MotorDebitNotes" %>

<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
           Motor Debit Notes
        </div>
        <div class="box-body">
            <div class="box">
                <div runat="server" id="opencommunicationsdetails"></div>
                <div class="tab-content">
                    <div class="box-body">
                        <table id="example1" class="table table-bordered table-striped datatable">
                            <thead>
                                <tr>
                                    
                                    <th>Client ID/Grower No</th>
                                    <th>Contract No</th>
                                    <th>Customer No</th>
                                    <th>Name</th>
                                    <th>Policy Start Date</th>
                                    <th>Policy End Date</th>
                                    <th>Claim</th>
                                    <th>Ammend</th>
                                </tr>
                            </thead>
                            <tbody>
                                  <%
                                      var nav = Config.ReturnNav();
                                      var applications = nav.ServiceContracts.Where(x => x.Business_Type == "Micro-Insurance").ToList();
                                      foreach (var application in applications)
                                      {
                                   %>
                                  <tr>
                                    <td><%= application.Grower_No_Client_ID %></td>
                                    <td><%= application.Contract_No %></td>
                                    <td><%= application.Customer_No %></td>
                                    <td><%= application.Name %></td>
                                    <td><%= Convert.ToDateTime(application.Policy_Start_Date).ToString("dd/MM/yyyy")%></td>
                                    <td><%= Convert.ToDateTime(application.Policy_End_Date).ToString("dd/MM/yyyy")%></td>
                                    <td>
                                        <a href="NewClaimNotification.aspx?GrowerNo=<%=application.Grower_No_Client_ID %>&&ContractNo=<%=application.Contract_No %>&&CustomerNo=<%=application.Customer_No %>" class="btn btn-success"><i class="fa fa-share"></i>Claim</a>
                                    </td>
                                     <%
                                         if (application.Customer_Type == "Individual")
                                         {
                                      %>
                                     <td>
                                        <a href="KYMIndividualClientsPolicyAmmendments.aspx?GrowerNo=<%=application.Grower_No_Client_ID %>&&ContractNo=<%=application.Contract_No %>&&CustomerNo=<%=application.Customer_No %>" class="btn btn-success"><i class="fa fa-share"></i>Ammend</a>
                                      </td>
                                      <%
                                          }
                                          else
                                          {
                                        %>
                                      <td>
                                        <a href="KYMCorporatePolicyAmmendments?GrowerNo=<%=application.Grower_No_Client_ID %>&&ContractNo=<%=application.Contract_No %>&&CustomerNo=<%=application.Customer_No %>" class="btn btn-success"><i class="fa fa-share"></i>Ammend</a>
                                      </td>
                                       <%
                                        }
                                      %>
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
</asp:Content>
