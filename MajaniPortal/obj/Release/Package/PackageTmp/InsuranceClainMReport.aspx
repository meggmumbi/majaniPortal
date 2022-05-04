<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsuranceClainMReport.aspx.cs" Inherits="MajaniPortal.InsuranceClainMReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">
         <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb float-sm-right">
                <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                <li class="breadcrumb-item active">KYM Claims Report</li>
            </ol>
        </div>
    </div>
    <div class="row" style="width: 100%; margin: auto;">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <i class="icon-file"></i>
          KYM Claims Report
            </div>
            <!-- /widget-header -->
            <div class="panel-body">
                <div id="feedback" runat="server"></div>
                <div class="row">
                    <div class="col-md-6 col-lg-6">
                        <div class="form-group">
                            <label>Start Date</label>
                            <asp:DropDownList CssClass="form-control" runat="server" ID="txtDates"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6">
                        <div class="form-group">
                            <label>Factory Name</label>
                            <asp:TextBox CssClass="form-control" runat="server" ID="factoryName"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Button runat="server" CssClass="btn btn-success" Text="Generate" ID="generate" OnClick="generate_Click" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <iframe runat="server" class="col-sm-12 col-xs-12 col-md-12 col-lg-12" height="780px" id="p9form" style="margin-top: 10px;"></iframe>
                </div>
            </div>
        </div>
    </div>

    <div class="clearfix"></div>
    <script>
        $(document).ready(function () {
        });
    </script>
</asp:Content>
