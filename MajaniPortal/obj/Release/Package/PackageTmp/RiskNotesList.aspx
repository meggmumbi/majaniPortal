<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="RiskNotesList.aspx.cs" Inherits="MajaniPortal.RiskNotesList" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">    <div class="panel panel-primary">
        <div class="panel-heading">
           Risk Notes
        </div>
        <div class="box-body">
            <div class="box">
                <div runat="server" id="opencommunicationsdetails"></div>
                <div class="tab-content">
                    <div class="box-body">
                        <table id="example1" class="table table-bordered table-striped datatable">
                            <thead>
                                <tr>
                                    <th>No</th>
                                    <th>Customer No</th>
                                    <th>Customer Name</th>
                                    <th>Insurance Policy No</th>
                                    <th>Policy Type</th>
                                    <th>Total Premium</th>
                                    <th>Print Risk Note</th>
                                    <th>Print Debit Note</th>
                                    <th>Motor Vehicle Details</th>
                                </tr>
                            </thead>
                            <tbody>
                                  <%
                                       string agentNo = Convert.ToString(Session["empNo"]);
                                      var nav = Config.ReturnNav();
                                      var applications = nav.DebitNoteHeader.Where(x =>x.Salesperson_Code==agentNo).ToList();
                                      foreach (var application in applications)
                                      {
                                   %>
                                  <tr>
                                    <td><%= application.No %></td>
                                    <td><%= application.Sell_to_Customer_No %></td>
                                    <td><%= application.Sell_to_Customer_Name %></td>
                                    <td><%= application.Insurance_Policy_No %></td>
                                    <td><%= application.Policy_Type %></td>
                                     <td><%= application.Total_Premium %></td>
                                    <td>
                                    <a href="RiskReportsPrintOut.aspx?ReportNumber=<%=application.No %>" class="btn btn-success"><i class="fa fa-pdf"></i>Print Risk Note</a>
                                    </td>
                                    <td>
                                    <a href="DebitNotePrintOut.aspx?ReportNumber=<%=application.No %>" class="btn btn-success"><i class="fa fa-pdf"></i>Print Debit Note</a>
                                    </td>
                                      <td>  <a href="MotorVehicleDets.aspx?customerNo=<%=application.Sell_to_Customer_No%>&&contractNo=<%=application.Policy_No%>&&No=<%application.No %>" class="btn btn-success"><i class="fa fa-pdf"></i>View</a></td>
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
