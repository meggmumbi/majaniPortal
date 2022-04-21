<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OurProducts.aspx.cs" Inherits="MajaniPortal.OurProducts" %>

<%@ Import Namespace="MajaniPortal" %>
<asp:content id="MainContent" contentplaceholderid="MainBody" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
          Our Products      
        </div>
            <div class="box-body">
                <table id="example1" class="table table-bordered table-striped">
                    <thead>
                        <tr>
                        <th>No</th>
                        <th>Description</th>
                        <th>Policy Type</th>
                        <th>Policy Class</th>
                        <th>Policy SubClasss</th>
                        <th>Has Binder</th>
                        </tr>
                    </thead>
                        <tbody>
                        <%
                            var nav = Config.ReturnNav();
                            var applications1 = nav.Items.Where(x => x.Insurance_Item_type == "Insurance").ToList();
                            foreach (var application in applications1)
                            {
                        %>
                        <tr>
                            <td><%= application.No %></td>
                            <td><%= application.Description %></td>
                            <td><%= application.Policy_Type %></td>
                            <td><%= application.Policy_Class %></td>
                            <td><%= application.Policy_SubClass %></td>
                            <td><%= application.Has_Binder %></td>
                        </tr>
                        <%
                            }
                        %>
                    </tbody>
                </table>
            </div>
        </div>
 </asp:content>

