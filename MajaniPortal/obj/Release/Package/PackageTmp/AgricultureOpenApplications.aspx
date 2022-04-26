<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgricultureOpenApplications.aspx.cs" Inherits="MajaniPortal.AgricultureOpenApplications" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">
      <div class="panel panel-primary">
        <div class="panel-heading">
        Open Client Applications Requests             
        </div>
        <div class="box-body">
            <div class="box">
                <div runat="server" id="opencommunicationsdetails"></div>
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
                                        <th>View/Edit</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%
                                        var nav = Config.ReturnNav();
                                        var applications = nav.ClientApplicationQuery.Where(r => r.Requestor == Convert.ToString(Session["empNo"]) && r.Business_Type=="General" && r.Policy_Type=="AGRICULTURAL INSURANCE");
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
                                            if (application.Status == "Open")
                                            {
                                            %>
                                          <a href="AgricultureIndividualClientApplication.aspx?step=1&&GrowerNumber=<%=application.Grower_No_Client_ID %>&&requisitionNo=<%=application.No %>" class="btn btn-success">View/Edit</a>
                                          <%   
                                            }
                                            else 
                                            {
                                            %>
                                             
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
