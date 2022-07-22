﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyHelpDeskRequests.aspx.cs" Inherits="MajaniPortal.MyHelpDeskRequests" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">
      <% var nav = Config.ReturnNav(); %>
    <div class="row">
        <div class="cil-md-12 col-lg-12 col-sm-12 col-xs-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    My Help Desk Requests
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-sm-6">
                            <ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Help Desk Requests</a></li>
                                <li class="breadcrumb-item active">My Help Desk Requests </li>
                            </ol>
                        </div>
                    </div>
                    <div runat="server" id="feedback"></div>
                    <table id="example1" class="table table-striped table-bordered" style="width: 100%">
                        <thead>
                            <tr>
                                <th>Job No</th>
                                <th>Employee No </th>
                                <th>Description </th>
                                <th>Request Date</th>
                                <th>Request Time</th>
                                <th>Assigned To</th>
                                <th>Status</th>
                                <th>Edit</th>

                            </tr>
                        </thead>
                        <tbody>
                            <%
                                var empNo = Session["employeeNo"].ToString();
                                var requests = nav.MyHeldeskRequests.Where(x => x.Employee_No == empNo && x.Status == "Pending").ToList();
                                foreach (var request in requests)
                                {
                            %>
                            <tr>
                                <td><%=request.Job_No%> </td>
                                <td><%=request.Employee_No%> </td>
                                <td><%=request.Description_of_the_issue %> </td>
                                <td><%=Convert.ToDateTime(request.Request_Date).ToString("dd/MM/yyyy") %> </td>
                                <td><%=request.Request_Time %> </td>
                                <td><%=request.Assigned_To %> </td>
                                <td><%=request.Status %> </td>
                                <%
                                    if (request.Status == "Pending")
                                    {
                                %>
                                <td><a href="EditHelpDeskRequests.aspx?jobNo=<%=request.Job_No%>" class="btn btn-success"><i class="fa fa-edit"></i>Edit</a> </td>
                                <%
                                    }
                                %>
                                <%--<td><a href="HelpDeskRequestsFeedback.aspx?jobNo=<%=request.Job_No%>" class="btn btn-success"><i class="fa fa-edit"></i> Feedback</a> </td>--%>


                                <%--  <td><a href="leaveapplication.aspx?leaveno=<%=leave.Application_Code %>" class="btn btn-success"><i class="fa fa-edit"></i> Edit</a> </td>
                           <td><a href="ApproverEntry.aspx?leaveno=<%=leave.Application_Code %>" class="btn btn-success"><i class="fa fa-file"></i> View Entries</a> </td>

                  
                    <td>
                      
                        <%
                            if (leave.Status=="Open"||leave.Status=="Rejected")
                            {
                                %>
                         <label class="btn btn-success" onclick="sendLeaveForApproval('<%=leave.Application_Code %>', '<%=leave.Leave_Type %>', ' <%=Convert.ToDateTime(leave.Start_Date).ToString("dd/MM/yyyy") %>');"><i class="fa fa-check"></i> Send Approval Request</label>
                        <%
                            }else if (leave.Status=="Pending Approval")
                            {
                                
                               %>
                         <label class="btn btn-danger" onclick="cancelLeaveApproval('<%=leave.Application_Code %>', '<%=leave.Leave_Type %>', ' <%=Convert.ToDateTime(leave.Start_Date).ToString("dd/MM/yyyy") %>');"><i class="fa fa-times"></i> Cancel Approval Request</label>
                        
                        <% 
                            } %>
                       
                        

                    </td>--%>
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
</asp:Content>
