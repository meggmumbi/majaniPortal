<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WelfareMembership.aspx.cs" Inherits="MajaniPortal.WelfareMembership" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
             Welfare Membership
        </div>
        <div class="panel-body">
            <div runat="server" id="membershipFeedback"></div>
            <div class="col-md-6 col-lg-6">
                <div class="form-group" style="display:none">
                    <strong>Employee No:</strong>
                    <asp:DropDownList runat="server" CssClass="form-control select2" ID="employeeno"/>
                </div>
                <div class="form-group">
                    <label class="control-label">Employee No.</label>
                    <asp:Label runat="server" class="form-control" readonly="true"> <%=Session["employeeNo"] %></asp:Label>
                </div>
            </div>
            <div class="col-md-6 col-lg-6">
                <div class="form-group">
                    <strong>Description:</strong>
                    <asp:Textbox runat="server" CssClass="form-control" ID="description" TextMode="MultiLine" Rows="3" placeholder="Description"/>
                </div>
            </div>
            <div class="form-group">
                <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Request Welfare Membership" ID="membership" OnClick="requestmembership_Click"/>
                <div class="clearfix"></div>
            </div>
            <hr/>
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
