<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OpenWelfareBenefit.aspx.cs" Inherits="MajaniPortal.OpenWelfareBenefit" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">

    <div class="panel panel-primary">
        <div class="panel-heading">
             Open Welfare Benefit    
        </div>
        <div class="panel-body">
            <table  id="example1" class="table table-bordered table-striped">
                <thead>
                <tr>
                    <th>Welfare No.</th>
                    <th>Description</th>
                    <th>Creator</th>
                    <th>Date Created</th>
                    <th>Benefit Allocation</th>
                </tr>
                </thead>
                <tbody>
                <%
                    var nav =  Config.ReturnNav();
                    String employeeNo = Convert.ToString(Session["employeeNo"]);
                    var benefit = nav.RequestsWelfareBenefit.Where(x =>  x.Raised_By == Session["employeeNo"].ToString() && x.Status == "Open").ToList();
                    foreach (var member in benefit)
                    {
                        %>
                    <tr>
                        <td><%=member.Welfare_No %></td>                         
                        <td><%=member.Description %></td>                         
                        <td><%=member.Created_By %></td> 
                        <td><%=member.Created_On %></td>
                        <td><%=member.Benefit_Allocation %></td>                  
                    </tr>
                            <%
                    }
                     %>
                </tbody>
            </table>
        </div>
    </div>

</asp:Content>
