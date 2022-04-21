<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="KYMClaimsRequests.aspx.cs" Inherits="MajaniPortal.KYMClaimsRequests" %>

<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
         Micros-Insurance Client Claims             
        </div>
        <div class="box-body">
            <div class="box">
                <div class="tab-content">
                        <div class="box-body">
                            <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th>Document No</th>
                                        <th>Customer No</th>
                                        <th>Policy No</th>
                                        <th>Date Of Reporting</th>
                                        <th>Date Of Accident</th> 
                                        <th>Reason For Relisting</th>                                     
                                        <th style="background-color:cadetblue">Status</th>
                                    </tr>
                                </thead>
                                  <tbody>
                                    <%
                                        var nav = Config.ReturnNav();
                                        var applications1 = nav.InsuranceClaims.Where(r => r.Business_Type=="Micro-Insurance");
                                        foreach (var application in applications1)
                                        {
                                    %>
                                    <tr>
                                        <td><%= application.No %></td>
                                        <td><%= application.Customer_No %></td>
                                        <td><%= application.Policy_No %></td>
                                        <td><%= application.Date_of_Reporting %></td>
                                        <td><%= application.Date_of_Accident_Loss_Death %></td>
                                        <td><%= application.Reason_For_Relisting %></td>
                                        <%
                                        if (application.Claim_Position == "CLAIM VERIFICATION")
                                        {
                                         %>
                                        <td style="background-color:cornsilk"><%= application.Claim_Position %></td>   
                                        <%}
                                         else
                                         {
                                           %>   
                                         <td style="background-color:darksalmon"><%= application.Claim_Position %></td> 
                                        <%} %>                                
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
