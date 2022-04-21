<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MotorClaimNotifications.aspx.cs" Inherits="MajaniPortal.MotorClaimNotifications" %>

<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
    <%
        int step = 1;
        int ClaimType = 1;
        try
        {
            step = Convert.ToInt32(Request.QueryString["step"]);
            ClaimType = Convert.ToInt32(Request.QueryString["ClaimType"]);
            if (step > 3 || step < 1)
            {
                step = 1;
            }
        }
        catch (Exception)
        {
            step = 1;
        }
        if (step == 1)
        {
    %>
    <div class="panel panel-primary">
        <div class="panel-heading">
            Claim General Details
            <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 1 of 3<i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="feedbackdetails"></div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Customer No.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="lblselectedcustomers" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Policy No.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblpolicynumber"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Principal Name.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtnames" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Email Address</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtemailaddress" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Date of Reporting</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="dateofreporting" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>ID/Passport No</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="idpassportnumber" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Date Of Accident/Death/Loss</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="dateofaccident" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Claimant/Tel No</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="claimanttelnumber" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Place of Accident.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="placeofaccident"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>House No.</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="housenumber"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Mobile No.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="mobileNumber"></asp:TextBox>
                    </div>
                </div>

            </div>
        </div>
        <div class="panel-footer">
            <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" OnClick="SubmitApplication_Click" ID="submitapplication" />
            <div class="clearfix"></div>
        </div>
    </div>
    <% 
        }
        else if (step == 2)
        {
    %>
    <div class="panel panel-primary">
        <div class="panel-heading">
            Claim Validation
            <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 2 of 3<i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="Div1"></div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Risk Code.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="riskcodes" AutoPostBack="true" OnSelectedIndexChanged="ValidateMake_Text"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>RegistrationN No.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="registrationNumbers" ReadOnly="true"></asp:TextBox>
                    </div>

                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Make.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="makes" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Model</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="models" ReadOnly="true"></asp:TextBox>
                    </div>

                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Year of Manufucture</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="yearofmanufucture" TextMode="Number" ReadOnly="true"></asp:TextBox>
                        <span class="error" id="txtyearofmanaufucturedetails" runat="server" style="background-color: red"></span>
                    </div>
                    <div class="form-group">
                        <label>CC.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="ccnumber" ReadOnly="true"></asp:TextBox>
                    </div>

                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Trailer Registration No.</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="trailernumber"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Carrying Capacity</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="carryingcapacity"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Name of Owner</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="nameofwner"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Address of the Owner</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="addressofowner"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="panel-footer">
                <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" OnClick="previousstep_Click" />
                <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" OnClick="SubmitValidations_Click" />
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <% 
        }
        else if (step == 3)
        {
    %>
    <div class="panel panel-primary">
        <div class="panel-heading">
            Upload Supporting Documents
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 3 of 3 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="documentsfeedback"></div>
            <div class="col-md-6">
                <div class="form-group">
                    <strong>Claim Form:</strong>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="claimformupload" />
                </div>
                <div class="form-group">
                    <strong>Police Abstract:</strong>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="policeabstract" />
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <strong>LogBook:</strong>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="loogbook" />
                </div>
                <div class="form-group">
                    <strong>Driving License:</strong>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="drivingLicense" />
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <strong>Detailed Statement of accident occurrence:</strong>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="detailedstatement" />
                </div>
                <div class="form-group">
                    <strong>ID & KRA Pin:</strong>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="IDkraPin" />
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <strong>Inspection Report:</strong>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="inspectionreport" />
                </div>
                <div class="form-group">
                    <strong>Towing receipts:</strong>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="towingreceipt" />
                </div>
            </div>
            <div class="col-md-12">
                <div class="panel-footer">
                    <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Upload" ID="uploaddocuments" OnClick="upload_Click" />
                    <div class="clearfix"></div>
                </div>
            </div>
            <table class="table table-bordered table-striped" id="example2">
                <thead>
                    <tr>
                        <th>Document Title</th>
                        <th>Download</th>
                        <th>Delete</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                        try
                        {

                            String filesFolder = ConfigurationManager.AppSettings["FilesLocation"] + "Existing Policy/";
                            String PolicyNo = Request.QueryString["requisitionNo"].Trim();
                            PolicyNo = PolicyNo.Replace('/', '_');
                            PolicyNo = PolicyNo.Replace(':', '_');
                            String documentDirectory = filesFolder + PolicyNo + "/";
                            if (Directory.Exists(documentDirectory))
                            {
                                foreach (String file in Directory.GetFiles(documentDirectory, "*.*", SearchOption.AllDirectories))
                                {
                                    String url = documentDirectory;
                    %>
                    <tr>
                        <td><% =file.Replace(documentDirectory, "") %></td>
                        <td>
                            <label class="btn btn-success" onclick="downloadFile('<%=file.Replace(documentDirectory, "")%>');"><i class="fa fa-download">Download</label></td>
                        <td>
                            <label class="btn btn-danger" onclick="deleteFile('<%=file.Replace(documentDirectory, "")%>');"><i class="fa fa-trash-o"></i>Delete</label></td>
                    </tr>
                    <%
                                }
                            }
                        }
                        catch (Exception)
                        {

                        }%>
                </tbody>
            </table>
            <div class="panel-footer">
                <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" OnClick="previousstep_Click" />
                <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Send Claim for Validations" OnClick="Sendforvalidations_Click" ID="validations" />
                <div class="clearfix"></div>
            </div>

        </div>
    </div>
    <%} %>
</asp:Content>
