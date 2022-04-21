<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RiskNotes.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MajaniPortal.RiskNotes" %>

<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
    <div class="panel panel-primary">
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
                                    
                                    <th> No</th>
                                    <th>Customer No</th>
                                    <th>Customer Name</th>
                                    <th>Insurance Policy No</th>
                                    <th>Policy Type</th>
                                    <th>Total Premium</th>
                                    <th>Print</th>
                                </tr>
                            </thead>
                            <tbody>
                                  <%
                                      var nav = Config.ReturnNav();
                                      var applications = nav.DebitNoteHeader.Where(x => x.Status == "Released" && x.Posted==true).ToList();
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
                                        <a href="" class="btn btn-success"><i class="fa fa-pdf"></i>Print Risk Note</a>
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
</asp:Content>
