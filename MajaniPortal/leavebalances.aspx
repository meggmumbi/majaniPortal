﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="leavebalances.aspx.cs" Inherits="MajaniPortal.leavebalances" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">

       <div class="row">
           <% var nav = Config.ReturnNav(); %>
   <div class="col-md-12 col-lg-12">
         <div class="panel panel-primary">
             <div class="panel-heading">
                 Employee Leave Details
             </div>
             <div class="panel-body">
                 <table class="table table-striped table-bordered">
                
                <tbody>
                <tbody>
                <% var employees = nav.Employees.Where(r => r.No == (String) Session["employeeNo"]);
                   foreach (var employee in employees)
                   {

                %>
                  <tr><td> Total Leave Taken:</td><td> <%=employee.Total_Leave_Taken %> </td></tr>
                  <tr><td> Total (Leave Days):</td><td> <%=employee.Total_Leave_Taken %> </td></tr>
                  <tr><td> Reimbursed Leave Days:</td><td> <%=employee.Reimbursed_Leave_Days %> </td></tr>
                  <tr><td> Allocated Leave Days:</td><td> <%=employee.Allocated_Leave_Days %> </td></tr>
                  <tr><td> Annual Leave Account:</td><td> <%=employee.Annual_Leave_Account %> </td></tr>
                  <tr><td> Compassionate Leave Account:</td><td> <%=employee.Compassionate_Leave_Acc %> </td></tr>
                  <tr><td> Maternity Leave Account:</td><td> <%=employee.Maternity_Leave_Acc %> </td></tr>
                  <tr><td> Paternity Leave Account:</td><td> <%=employee.Paternity_Leave_Acc %> </td></tr>
                  <tr><td> Sick Leave Account:</td><td> <%=employee.Sick_Leave_Acc %> </td></tr>
                  <tr><td> Study Leave Account:</td><td> <%=employee.Study_Leave_Acc %> </td></tr>
                  <tr><td> Leave Outstanding Balance:</td><td> <%=employee.Leave_Outstanding_Bal %> </td></tr>
                  <%
                          break;
                      } %>
                
                </tbody>
              </table>
             </div>
         </div>         
       </div>
   
    <div class="clearfix"></div>
    </div>




</asp:Content>
