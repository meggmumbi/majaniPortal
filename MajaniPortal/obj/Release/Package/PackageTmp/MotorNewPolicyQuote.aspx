<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="MotorNewPolicyQuote.aspx.cs" Inherits="MajaniPortal.MotorNewPolicyQuote" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
    <%
        int step = 1;
        try
        {
            step = Convert.ToInt32(Request.QueryString["step"]);
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
            General Details
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 1 of 5 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="feedbackdetails"></div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Policy Holder  No</label>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="policyHolder" Placeholder="Select Policy Holder No"></asp:DropDownList>
                    </div>
                </div>

                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Policy Type</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblpolicytypes" Placeholder="Select Policy Holder No" ></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                 <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Insurer</label>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="txtinsurer" OnSelectedIndexChanged="GetVendorProducts_Onlick" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Type of Application</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="typeofapplications" Placeholder="Select Policy Holder No"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                 <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Mode of Payment</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblmodeofpayments" Placeholder="Select Policy Holder No"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Product Billing Cycle</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblproductbillingCycle" Placeholder="Select Policy Holder No"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Agent Detail</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblagentDetails" Placeholder="Select Policy Holder No"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Agent Code</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblagentCode" Placeholder="Select Policy Holder No"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Financier</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblfanancier" Placeholder="Select Policy Holder No"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Policy No</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="policynumbers"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Policy Start Date</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="policystartdate" TextMode="Date"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Policy Business Type</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblpolicybusinessTypes" Placeholder="Select Policy Holder No"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Payment Referrence </label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="paymentreference"></asp:TextBox>
                    </div>
                </div>                
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Member Type</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblmembertype" Placeholder="Select Policy Holder No"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-footer">
            <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" OnClick="Next_Click" ID="submitapplication" />
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
            Risk Details
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 2 of 4 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="risksfeedbackdetails"></div>
            <div class="panel-body pull-right">
                <label class="btn btn-success" data-toggle="modal" data-target="#RiskDetails"><i class="fa fa-plus fa-fw"></i>Add Risk Details</label>
            </div>
            <br />
            <br />
            <div class="box-body">
                <table id="example2" class="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <th>Registration No</th>
                            <th>Make</th>
                            <th>Model</th>
                            <th>Tonnage</th>
                            <th>Cover Type </th>
                            <th>Chasis No</th>
                        </tr>
                    </thead>
                    <tbody>
                      <%--  <%
                            var nav = Config.ReturnNav();
                            var requisitionNo = Request.QueryString["requisitionNo"].Trim();
                            var applications = nav.PolicyRiskDetails.Where(r => r.Qoute_No == requisitionNo);
                            foreach (var application in applications)
                            {
                        %>
                        <tr>
                            <td><%= application.Registration_No %></td>
                            <td><%= application.Make %></td>
                            <td><%= application.Model %></td>
                            <td><%= application.Tonnage %></td>
                            <td><%= application.Cover_Type %></td>
                            <td><%= application.Chassis_no %></td>

                        </tr>
                        <%
                            }
                        %>--%>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="panel-footer">
            <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" OnClick="previousstep_Click" ID="prevous4" />
            <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" OnClick="nextstep_Click" ID="Button2" />
            <div class="clearfix"></div>
        </div>
    </div>
    <asp:ScriptManager ID="SCManager" runat="server" />
    <div id="RiskDetails" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Risk Details</h4>
                </div>
                <asp:UpdatePanel ID="SCPanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Registration No</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="registrationnumber"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Certificate No.</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="certificateNo"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Make</label>
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="make" Placeholder="Select Policy Holder No" AutoPostBack="true" OnTextChanged="ValidateMake_Text"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Model</label>
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="model" Placeholder="Select Policy Holder No"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Vehicle Type</label>
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="vehicletype" Placeholder="Select Policy Holder No"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Cover Type</label>
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="covertype" Placeholder="Select Policy Holder No"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>CC</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="cc"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Chasis No</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="chasisnumber"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Engine No</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="enginenumber"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Year of Manufucture</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="yearofmanufucture"  TextMode="Number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Body Type</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="bodytype"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Policy Start Date</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="policystratdate"  TextMode="Date"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Duration</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="duration"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Tonnage</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="tonnage"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Value/Sum Insured</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="valuesuminsured"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-6">
                                    <div class="form-group">
                                        <label>Rate</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtrate"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="modal-footer">
                    <asp:Button runat="server" CssClass="btn btn-success" Text="Add Risk Detail" OnClick="SubmitRiskDetails_Click" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
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
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 5 of 5 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="documentsfeedback"></div>
            <div class="form-group">
                <strong>Upload Logbook:</strong>
                <asp:FileUpload runat="server" CssClass="form-control" ID="uploadLogbook" />
            </div>
            <br />
            <div class="form-group">
                <strong>Upload ID or Certificate of Incorporation (for Corporates):</strong>
                <asp:FileUpload runat="server" CssClass="form-control" ID="uploadIDCertificate" />
            </div>
            <br />
            <div class="form-group">
                <strong>Upload KRA PIN Certificate:</strong>
                <asp:FileUpload runat="server" CssClass="form-control" ID="uploadKRAPinCertificate" />
            </div>
            <br />
            <div class="form-group">
                <strong>Upload Application/Proposal Form:</strong>
                <asp:FileUpload runat="server" CssClass="form-control" ID="uploadApplicationForm" />
            </div>
            <br />
            <div class="panel-footer">
                 <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Upload" ID="uploaddocuments" OnClick="UploadDocumentsApplication_Click" />
                <div class="clearfix"></div>
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

                            String filesFolder = ConfigurationManager.AppSettings["FilesLocation"] + "New Clients/";
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
                <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Submit Application"  />
                <div class="clearfix"></div>
            </div>

        </div>
    </div>
    <%} %>
</asp:Content>