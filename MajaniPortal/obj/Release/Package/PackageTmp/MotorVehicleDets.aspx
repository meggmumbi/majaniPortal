<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MotorVehicleDets.aspx.cs" Inherits="MajaniPortal.MotorVehicleDets" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
       Motor Vehicle Details
        </div>
        <div class="box-body">
            <div id="feedback" runat="server"></div>
            <div class="box">
                <div class="tab-content">
                        <div class="box-body">
                               <div class="table-responsive">
                            <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th>Code</th>
                                        <th>Registration No</th>
                                        <th>Make</th>
                                        <th>Model</th>
                                        <th>Vehicle Type</th> 
                                        <th>Cover Type</th>                                     
                                        <th>Tonnage</th>
                                        <th>Certificate No</th>
                                        <th>Value/Sum Insured</th>
                                        <th>Premium</th>
                                        <th>Total Line Premiums</th>
                                        <th>Generate Certificate</th>
                                    </tr>
                                </thead>
                                  <tbody>
                                    <%
                                        var nav = Config.ReturnNav();
                                        string customerNo = Convert.ToString(Request.QueryString["customerNo"]); 
                                        string contractNo = Convert.ToString(Request.QueryString["contractNo"]); 
                                        var applications1 = nav.MotorVehicleDetails.Where(r => r.Customer_No==customerNo && r.Contract_No==contractNo);
                                        foreach (var application in applications1)
                                        {
                                    %>
                                    <tr>
                                        <td><%= application.Code %></td>
                                        <td><%= application.Registration_No %></td>
                                        <td><%= application.Make %></td>
                                        <td><%= application.Model %></td>
                                        <td><%= application.Body_Type %></td>
                                        <td><%= application.Tonnage %></td>
                                         <td><%= application.Certificate_No %></td>
                                         <td><%= application.Value_Sum_Insured %></td>
                                         <td><%= application.Premium %></td>
                                         <td><%= application.Total_Line_Premiums %></td>
                                        <td> <asp:Button runat="server" CssClass="btn btn-success" Text="Generate" ID="generate" OnClick="generate_Click" /></td>
                                                      
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
