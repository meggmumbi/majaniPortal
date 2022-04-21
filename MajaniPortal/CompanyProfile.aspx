<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CompanyProfile.aspx.cs" Inherits="MajaniPortal.CompanyProfile" %>

<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
    <div class="row">
        <div class="col-md-3">
            <div class="box box-primary">
                <div class="box-body box-profile">
                    <img class="profile-user-img img-responsive img-circle" src="dist/img/logo.png" alt="User profile picture">

                    <h3 class="profile-username text-center"><% =Session["name"] %></h3>

                    <p class="text-muted text-center">Majani Insurance Brokers</p>

                    <ul class="list-group list-group-unbordered">
                        <li class="list-group-item">
                            <b>General Details</b> <a class="pull-right"></a>
                        </li>
                        <li class="list-group-item">
                            <b>Communication Details</b> <a class="pull-right"></a>
                        </li>
                    </ul>                   
                </div>
            </div>
        </div>
        <div class="col-md-9">
            <div class="nav-tabs-custom">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#activity" data-toggle="tab">General Details</a></li>
                    <li><a href="#timeline" data-toggle="tab">Communication Details</a></li>
                </ul>
                <div class="tab-content">
                    <div class="active tab-pane" id="activity">
                        <div class="box-body">
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Company Name</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="companame" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Our Vission</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="ourvission" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Our Mission</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="mission" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>City</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="city" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Address</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="address" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Phone Number</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="phonenumber" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Email Address</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="emailaddress" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane" id="timeline">
                        <div class="box-body">
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Mobile Phone</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="mobilenumber" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Address </label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="addressess" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>City</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="cities" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Post Code</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="postcodes" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Country Code</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="country" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Phone Number</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="phonenumbers" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Email Address</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="emailaddresses" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="tab-pane" id="settings">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

