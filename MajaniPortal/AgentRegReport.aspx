<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgentRegReport.aspx.cs" Inherits="MajaniPortal.AgentRegReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">
        <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb float-sm-right">
                <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                <li class="breadcrumb-item active">  Agents Registration Report</li>
            </ol>
        </div>
    </div>
    <div class="row" style="width: 100%; margin: auto;">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <i class="icon-file"></i>
              Agents Registration Report
            </div>
            <!-- /widget-header -->
            <div class="panel-body">
                <div id="feedback" runat="server"></div>
                <div class="row">
                    <div class="col-md-6 col-lg-6">
                        <div class="form-group">
                            <label>Start Date</label>
                            <asp:DropdownList CssClass="form-control" runat="server" ID="txtDates" TextMode="Date"></asp:DropdownList>
                        </div>
                    </div>
                         <div class="col-md-6 col-lg-6">
                        <div class="form-group">
                            <label>End Date </label>
                            <asp:DropdownList CssClass="form-control" runat="server" ID="endDate" TesxtMode="Date"></asp:DropdownList>
                        </div>
                    </div>
                     <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        </br>
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
