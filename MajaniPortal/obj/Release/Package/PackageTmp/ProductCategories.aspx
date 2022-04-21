<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProductCategories.aspx.cs" Inherits="MajaniPortal.ProductCategories" %>

<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
           Product Categories            
        </div>
        <div class="box-body">
              <ul class="nav nav-pills" role="tablist">
                 <ul class="nav nav-tabs">
                        <li class="active" style="background-color:lightgreen">
                            <a href="#micro" data-toggle="tab"   <h3 class="panel-title" style="color:black">Micro-Insurance</h3></a>
                        </li>
                        <li style="background-color:forestgreen">
                            <a href="#general" data-toggle="tab"><h3 class="panel-title" style="color:black">General Insurance</h3></a>
                        </li>
                       <li style="background-color:forestgreen">
                            <a href="#life" data-toggle="tab"><h3 class="panel-title" style="color:black">Life Insurance</h3></a>
                        </li>
                  </ul>
            </ul>
            <div class="box">
                <div class="tab-content">
                    <div class="tab-pane active in" id="micro">
                        <div class="box-body">
                            <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th> No</th>
                                        <th>Policy Class</th>
                                        <th>Policy Sub Class</th>
                                        <th>Insurer Name</th>
                                        <th>Has Binder</th>
                                        <th>Policy Type</th>
                                    </tr>
                                </thead>
                                  <tbody>
                                    <%
                                        var nav = Config.ReturnNav();
                                        var applications1 = nav.Items.Where(r => r.Insurance_Item_type =="Insurance" &&r.Type=="Service" &&r.Insurance_Category=="General");
                                        foreach (var application in applications1)
                                        {
                                    %>
                                    <tr>
                                        <td><%= application.No %></td>
                                        <td><%= application.Policy_Class %></td>
                                        <td><%= application.Policy_SubClass %></td>
                                        <td><%= application.Insurer_Name %></td>
                                        <td><%= application.Has_Binder %></td>
                                        <td><%= application.Policy_Type %></td>                                    
                                    </tr>
                                    <%
                                        }
                                    %>
                                </tbody>
                            </table>
                        </div>
                </div>
                  <div class="tab-pane fade" id="general">
                        <div class="box-body">
                            <table id="example2" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th> No</th>
                                        <th>Policy Class</th>
                                        <th>Policy Sub Class</th>
                                        <th>Insurer Name</th>
                                        <th>Has Binder</th>
                                        <th>Policy Type</th>
                                    </tr>
                                </thead>
                                  <tbody>
                                    <%
                                        var nav2 = Config.ReturnNav();
                                        var applications2 = nav.Items.Where(r => r.Insurance_Item_type =="Insurance" &&r.Type=="Service" &&r.Insurance_Category=="General");
                                        foreach (var application in applications2)
                                        {
                                    %>
                                    <tr>
                                        <td><%= application.No %></td>
                                        <td><%= application.Policy_Class %></td>
                                        <td><%= application.Policy_SubClass %></td>
                                        <td><%= application.Insurer_Name %></td>
                                        <td><%= application.Has_Binder %></td>
                                        <td><%= application.Policy_Type %></td>                                    
                                    </tr>
                                    <%
                                        }
                                    %>
                                </tbody>
                            </table>
                        </div>
                   </div>
                     <div class="tab-pane fade" id="life">
                        <div class="box-body">
                            <table id="example3" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th> No</th>
                                        <th>Policy Class</th>
                                        <th>Policy Sub Class</th>
                                        <th>Insurer Name</th>
                                        <th>Has Binder</th>
                                        <th>Policy Type</th>
                                    </tr>
                                </thead>
                                  <tbody>
                                    <%
                                        var nav3 = Config.ReturnNav();
                                        var applications3 = nav.Items.Where(r => r.Insurance_Item_type =="Insurance" &&r.Type=="Service" &&r.Insurance_Category=="General");
                                        foreach (var application in applications3)
                                        {
                                    %>
                                    <tr>
                                        <td><%= application.No %></td>
                                        <td><%= application.Policy_Class %></td>
                                        <td><%= application.Policy_SubClass %></td>
                                        <td><%= application.Insurer_Name %></td>
                                        <td><%= application.Has_Binder %></td>
                                        <td><%= application.Policy_Type %></td>                                    
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
