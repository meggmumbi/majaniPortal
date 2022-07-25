<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ICTHelpDesk.aspx.cs" Inherits="MajaniPortal.ICTHelpDesk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">
      <div class="panel panel-primary">
        <div class="panel-heading">Send Request to ICT Help Desk
            <span class="pull-right"></span><span class="clearfix"></span>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-sm-12">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#"> Help Desk </a></li>
                            <li class="breadcrumb-item active">  Help Desk Request</li>
                        </ol>
                    </div>
            </div>
            <div id="ictFeedback" runat="server"></div>
              <div class="row" >
        <div class="col-md-6 col-lg-12">
            <div class="form-group">
                <strong>ICT Issue Category:</strong>
                <asp:DropDownList CssClass="form-control select2" runat="server" ID="category" Required/>
            </div>
            <div class="form-group">
                <strong>Description:</strong>
                <asp:TextBox runat="server" ID="Description" CssClass="form-control" placeholder="Description" TextMode="MultiLine" required/>
            </div>

            
            </div>    
      </div>
                  <div class="row">
                    <div class="col-md-6 col-lg-12">
                        <div class="form-group">
                            <label>Upload document</label><span class="text-danger" style="font-size: 25px">*</span>
                            <asp:FileUpload runat="server" CssClass="form-control" ID="document" />
                        </div>
                    </div>
                </div>
        </div>
        <div class="panel-footer">
            <asp:Button runat="server" CssClass="btn btn-success pull-left" Text="Send Request
                " ID="addICTHelpDeskRequest" OnClick="addICTHelpDeskRequest_Click"/>
            <span class="clearfix"></span>
        </div>
    </div>

</asp:Content>
