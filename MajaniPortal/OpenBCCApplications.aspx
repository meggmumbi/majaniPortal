<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="OpenBCCApplications.aspx.cs" Inherits="MajaniPortal.OpenBCCApplications" %>

<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
           Open BCC Applications Requests             
        </div>
        <div class="box-body">
            <div class="box">
                <div runat="server" id="opencommunicationsdetails"></div>
                <div class="tab-content">
                        <div class="box-body">
                            <table id="example1" class="table table-bordered table-striped datatable">
                                <thead>
                                    <tr>
                                        <th>No</th>
                                        <th>Name</th>
                                        <th>Phone No</th>
                                        <th>Factory Name</th>
                                        <th>ID Number</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%
                                        var nav = Config.ReturnNav();
                                        var applications = nav.AgentsApplications.ToList();
                                        foreach (var application in applications)
                                        {
                                    %>
                                    <tr>
                                        <td><%= application.No %></td>
                                        <td><%= application.Name %></td>
                                        <td><%= application.Phone_No %></td>
                                        <td><%= application.Factory_Name %></td>
                                        <td><%= application.Id_Number %></td>
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
