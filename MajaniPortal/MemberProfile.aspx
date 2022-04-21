<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberProfile.aspx.cs" Inherits="MajaniPortal.MemberProfile" %>

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
                            <b>My Claims</b> <a class="pull-right">1,322</a>
                        </li>
                        <li class="list-group-item">
                            <b>My Policies</b> <a class="pull-right">543</a>
                        </li>
                    </ul>
                    <a href="#" class="btn btn-primary btn-block"><b>Follow</b></a>
                </div>
            </div>
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">About Me</h3>
                </div>
            </div>
        </div>
        <div class="col-md-9">
            <div class="nav-tabs-custom">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#activity" data-toggle="tab">Personal Details</a></li>
                    <li><a href="#timeline" data-toggle="tab">Communication Details</a></li>
                    <%--              <li><a href="#settings" data-toggle="tab">Settings</a></li>--%>
                </ul>
                <div class="tab-content">
                    <div class="active tab-pane" id="activity">
                        <div class="box-body">
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>No</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>First Name</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Middle Name</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Last Name</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Job Title</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Gender</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Phone Number</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Email Address</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Status</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Date of Birth</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
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
                                        <label>Address 1</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Address 2</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>City</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Post Code</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Country Code</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Phone Number</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Email Address</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
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
