<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="DebitNotePrintOut.aspx.cs" Inherits="MajaniPortal.DebitNotePrintOut" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">    <div class="panel panel-primary">
        <div class="panel-heading">
         Debit Note Print Out
        </div>
        <div class="box-body">
            <div class="box">
                <div runat="server" id="documentsFeedback"></div>
                 <div class="panel-footer">
            </div>
                <div class="tab-content">
                    <div class="box-body">
                      <div class="panel panel-primary">
                        <div class="form-group">
                            <hr />
                            <div runat="server" id="feedback"></div>
                            <asp:Literal ID="ltEmbed" runat="server" />
                        </div>
                      </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

