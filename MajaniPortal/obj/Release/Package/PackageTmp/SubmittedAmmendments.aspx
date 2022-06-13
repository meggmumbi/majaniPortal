<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubmittedAmmendments.aspx.cs" Inherits="MajaniPortal.SubmittedAmmendments" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">
      <div class="panel panel-primary">
        <div class="panel-heading">
            Micro-Insurance Open Client Applications Requests             
        </div>
        <div class="box-body">
            <div class="box">
                <div runat="server" id="opencommunicationsdetails"></div>
                <div class="tab-content">
                    <div class="tab-pane active in" id="tab_1_1">
                        <div class="box-body">
                              <div class="table-responsive">
                            <table id="example1" class="table table-bordered table-striped datatable">
                                <thead>
                                    <tr>
                                        <th>Document No</th>
                                        
                                        <th>Name</th>
                                     
                                       
                                       
                                    </tr>
                                </thead>
                                <tbody>
                                    <%
                                        var nav = Config.ReturnNav();
                                        var applications = nav.SalesHeader.Where(r => r.Salesperson_Code == Convert.ToString(Session["empNo"]));
                                        foreach (var application in applications)
                                        {
                                    %>
                                    <tr>
                                        <td><%= application.No %></td>
                                    
                                        <td><%= application.First_Name +" "+ application.Middle_Name +" "+ application.Last_Name %></td>
                                      
                                     
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
    </div>
</asp:Content>
