<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MotorCorporateOptionalBenefits.aspx.cs" Inherits="MajaniPortal.MotorCorporateOptionalBenefits" %>

<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            Optional Benefits 
                <span class="pull-right"><i class="fa fa-chevron-left"></i> <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div class="row">
                <div runat="server" id="individualinsurancefeedback"></div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Insurance Option</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="insuranceOptions" ></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Amounts</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtamounts" TextMode="Number" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Total Optional Amounts</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtoptionalbenefits" ReadOnly="true" ></asp:TextBox>
                    </div>
                </div>
                <br />
                 <div class="col-md-6 col-lg-6" >
                  <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Add Risk Insurance Options" ID="next" OnClick="AddInsuranceBenefits_Click"  />
                </div><br /><br />
            </div>
             <table id="example1" class="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th>Insurance Option</th>
                        <th>Amount</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                        var nav = Config.ReturnNav();
                        var RiskCode = Request.QueryString["Code"].Trim();
                        var TotalOptionalAmounts = "";
                        var RequisitionNo = Request.QueryString["requisitionNo"].Trim();
                        var applications = nav.RiskInsuranceOptions.Where(r => r.Client_App_No == RequisitionNo&&r.Risk_Code==RiskCode);
                        foreach (var application in applications)
                        {
                            TotalOptionalAmounts =Convert.ToString(application.Total_Options_Amount);
                    %>
                    <tr>
                        <td><%= application.Insurance_Option %></td>
                        <td><%= application.Amount %></td>                   
                    </tr>
                    <%
                        }
                    %>
                </tbody>
            </table>
             <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Proceed" OnClick="previousstep_Click"  />
        </div>
      
    </div>
    </asp:Content>