﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="GeneralOpenClientApplications.aspx.cs" Inherits="MajaniPortal.GeneralOpenClientApplications" %>

<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            Micro-Insurance Open Client Applications Requests             
        </div>
        <div class="box-body">
            <div class="box">
                <div class="tab-content">
                    <div class="tab-pane active in" id="tab_1_1">
                        <div class="box-body">
                            <table id="example1" class="table table-bordered table-striped datatable">
                                <thead>
                                    <tr>
                                        <th>Document No</th>
                                        <th>Business Type</th>
                                        <th>First Name</th>
                                        <th>Middle Name</th>
                                        <th>Last Name</th>
                                        <th>Id/Passport</th>
                                        <th>Status</th>
                                        <th>Send For Approval</th>
                                        <th>View/Edit</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%
                                        var universityCode = Session["UniversityCode"];
                                        var nav = Config.ReturnNav();
                                        var applications = nav.ClientApplicationQuery.Where(r => r.Requestor == Convert.ToString(Session["empNo"]));
                                        foreach (var application in applications)
                                        {
                                    %>
                                    <tr>
                                        <td><%= application.No %></td>
                                        <td><%= application.Business_Type %></td>
                                        <td><%= application.First_Name %></td>
                                        <td><%= application.Middle_Name %></td>
                                        <td><%= application.Last_Name %></td>
                                        <td><%= application.ID_No_Passport_No %></td>
                                        <td><%= application.Status %></td>
                                        <td>
                                            <%
                                                if (application.Status == "Pending Approval")
                                                {
                                            %>
                                            <label class="btn btn-danger" onclick="cancelApprovalRequest('<%=application.No %>');"><i class="fa fa-times"></i>Cancel Approval Request</label>

                                            <%   
                                                }
                                                else if (application.Status == "Open")
                                                {
                                            %>
                                            <label class="btn btn-success" onclick="sendApprovalRequest('<%=application.No %>');"><i class="fa fa-check"></i>Send Approval Request</label>
                                            <% 
                                                }
                                            %>
                                        </td>
                                         <td>
                                         <%
                                            if (application.Customer_Type == "Individual" && application.Status == "Open")
                                            {
                                            %>
                                          <a href="MotorIndividualClientApplication?step=1&&requisitionNo=<%=application.No %>" class="btn btn-success">View/Edit</a>
                                          <%   
                                            }
                                           if (application.Customer_Type == "Corporate" && application.Status == "Open")
                                            {
                                            %>
                                              <a href="MotorCorporateClientApplications?step=1&&requisitionNo=<%=application.No %>" class="btn btn-success">View/Edit</a>
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
