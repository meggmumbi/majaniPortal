<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CorporateDependantConditions.aspx.cs" Inherits="MajaniPortal.CorporateDependantConditions" %>

<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            Dependant Conditions
                <span class="pull-right"><i class="fa fa-chevron-left"></i> <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div class="row">
                <div runat="server" id="conditionsfeedback"></div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Condition Name</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="txtConditionName" ></asp:DropDownList>
                    </div>
                </div><br />
                 <div class="row">
                  <asp:Button runat="server" CssClass="btn btn-success" Text="Add Conditions" ID="next" OnClick="AddConditions_Click" />
                </div>
            </div>
             <table id="example1" class="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th>Dependant Code</th>
                        <th>Condition Code</th>
                        <th>Condition Name</th>
                        <th>Remove</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                        var nav = Config.ReturnNav();
                        var DependantNo = Request.QueryString["DependantNo"].Trim();
                        var RequisitionNo = Request.QueryString["requisitionNo"].Trim();
                        var applications = nav.DependantConditions.Where(r => r.Depandant_Code == DependantNo&&r.Client_Id==RequisitionNo);
                        foreach (var application in applications)
                        {
                    %>
                    <tr>
                        <td><%= application.Depandant_Code %></td>
                        <td><%= application.code %></td>
                        <td><%= application.Description %></td>
                        <td>
                            <label class="btn btn-danger" onclick="removeDependant('<%=application.Depandant_Code %>');"><i class="fa fa-trash"></i>Remove</label></td>

                    </tr>
                    <%
                        }
                    %>
                </tbody>
            </table>
             <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Proceed" OnClick="previousstep_Click" />
        </div>
      
    </div>
    </asp:Content>
