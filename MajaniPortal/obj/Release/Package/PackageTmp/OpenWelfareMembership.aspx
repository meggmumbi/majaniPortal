<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OpenWelfareMembership.aspx.cs" Inherits="MajaniPortal.OpenWelfareMembership" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
             Open Welfare Membership
        </div>
        <div class="panel-body">            
            <table  id="example1" class="table table-bordered table-striped">
                <thead>
                <tr>
                    <th>Welfare No.</th>
                    <th>Welfare Type</th>
                    <th>Raisee</th>
                    <th>Description</th>
                    <th>Date Applied</th>
                    <th>Status</th>
                </tr>
                </thead>
                <tbody>
                <%
                    var nav =  Config.ReturnNav();
                    String employeeNo = Convert.ToString(Session["employeeNo"]);
                    var membership = nav.RequestsWelfareMembership.Where(x =>  x.Raised_By == Session["employeeNo"].ToString() && x.Status == "Open").ToList();
                    foreach (var member in membership)
                    {
                        %>
                    <tr>
                        <td><%=member.Welfare_No %></td>
                        <td><%=member.Welfare_Type %></td> 
                        <td><%=member.Raisee_Name %></td>
                        <td><%=member.Description %></td> 
                        <td><%=Convert.ToDateTime(member.Created_On).ToString("d/M/yyyy") %></td>
                        <td><%=member.Status %></td>                        
                    </tr>
                            <%
                    }
                     %>
                </tbody>
            </table>

        </div>
    </div>

</asp:Content>
