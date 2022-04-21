<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MyPolicies.aspx.cs" Inherits="MajaniPortal.MyPolicies" %>

<%@ Import Namespace="MajaniPortal" %>
<asp:content id="MainContent" contentplaceholderid="MainBody" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
          My Policies        
        </div>
            <div class="box-body">
                <table id="example1" class="table table-bordered table-striped">
                    <thead>
                        <tr>
                        <th>No</th>
                        <th>Name</th>
                        <th>Policy Type</th>
                        <th>Applicant Type</th>
                        <th>Category</th>
                        <th>Product</th>
                        <th>DHB</th>
                        </tr>
                    </thead>
                        <tbody>
                        <%
                            var nav = Config.ReturnNav();
                            string requestor = Session["empNo"].ToString();
                            var applications1 = nav.ServiceContracts.Where(r => r.Customer_No == requestor);
                            foreach (var application in applications1)
                            {
                        %>
                        <tr>
                            <td><%= application.Contact_No %></td>
                            <td><%= application.Name %></td>
                            <td><%= application.Policy_Type %></td>
                            <td><%= application.Applicant_Type %></td>
                            <td><%= application.Customer_Category %></td>
                            <td><%= application.Type_of_Applicant %></td>
                            <td><%= application.DHB %></td>
                        </tr>
                        <%
                            }
                        %>
                    </tbody>
                </table>
            </div>
        </div>
        </asp:content>
