<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="LifePolicies.aspx.cs" Inherits="MajaniPortal.LifePolicies" %>

<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">  
    <div class="row">
         <div class="col-lg-3 col-xs-6">
            <div class="small-box bg-green">
                <div class="inner">
                     <h3>Medical    </h3>
                    <p>Medical UnderWriting</p>
                </div>
                <div class="icon">
                    <i class="ion ion-pie-graph"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
        <div class="col-lg-3 col-xs-6">
            <div class="small-box bg-orange">
                <div class="inner">
                    <h3>Pension </h3>
                    <p>Pension UnderWriting</p>
                </div>
                <div class="icon">
                    <i class="ion ion-pie-graph"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
    </div>
</asp:Content>
