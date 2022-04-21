<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AgentsLists.aspx.cs" Inherits="MajaniPortal.AgentsLists" %>

<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
          Agents List         
        </div>
        <div class="box-body">
            <div class="box">
                <div runat="server" id="opencommunicationsdetails"></div>
                <div class="tab-content">
                        <div class="box-body">
                            <table id="example1" class="table table-bordered table-striped datatable">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>Phone No</th>
                                        <th>ID Number</th>
                                         <th>Phone No.</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%
                                        var nav = Config.ReturnNav();
                                        var applications = nav.SalesPersons.ToList();
                                        foreach (var application in applications)
                                        {
                                    %>
                                    <tr>
                                        <td><%= application.Name %></td>
                                        <td><%= application.Phone_No %></td>
                                        <td><%= application.Id_Number %></td>
                                         <td><%= application.Phone_No %></td>
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
