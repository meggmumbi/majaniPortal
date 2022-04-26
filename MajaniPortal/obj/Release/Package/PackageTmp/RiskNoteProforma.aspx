﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RiskNoteProforma.aspx.cs" Inherits="MajaniPortal.RiskNoteProforma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">


    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb float-sm-right">
                <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                <li class="breadcrumb-item active">  Proforma Risk Note</li>
            </ol>
        </div>
    </div>
    <div class="row" style="width: 100%; margin: auto;">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <i class="icon-file"></i>
                Proforma Risk Note
            </div>
            <!-- /widget-header -->
            <div class="panel-body">
                <div id="feedback" runat="server"></div>
                <div class="form-group">
                    <iframe runat="server" class="col-sm-12 col-xs-12 col-md-12 col-lg-12" height="780px" id="p9form" style="margin-top: 10px;"></iframe>
                </div>
            </div>
        </div>
    </div>
      <div class="panel-footer">
                <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" CausesValidation="false" ID="previoes" OnClick="previoes_Click"/>
             <asp:Button runat="server" CssClass="btn btn-success pull-right " Text="Next" id="next" OnClick="next_Click" />
            <div class="clearfix"></div>
        </div>
    <div class="clearfix"></div>
    <script>
        $(document).ready(function () {
        });
    </script>
</asp:Content>
