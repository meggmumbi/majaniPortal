<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="NewClaimNotification.aspx.cs" Inherits="MajaniPortal.NewClaimNotification" %>

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
                        <label>Principal Name.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtnames" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">


                    <div class="form-group">
                        <label>Policy No.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblpolicynumber"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Claim  Against</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblclaimagainst" Placeholder="Select Claim Against" OnSelectedIndexChanged="DependantsDetails_OnClick" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6">

                    <div class="form-group">
                        <label>Claim Category</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblclaimcategory" Placeholder="Select Claim Category"></asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label>Dependant No</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="tlbldependantNumber" Placeholder="Select Customers"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6">

                    <div class="form-group">
                        <label>Claim Amount</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="claimAmount" TextMode="Number"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Place of Occurence Types</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="lblplaceofOccurrences" Placeholder="Select Place of Occurrences"></asp:DropDownList>
                    </div>

                </div>
                <div class="col-md-6">

                    <div class="form-group">
                        <label>Place Of Occurence</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="placeofoccurrences"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="panel-footer">
                <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" OnClick="SubmitApplication_Click" ID="submitapplication" />
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <% 
        }
        else if (step == 2)
        {
    %>
    <div class="panel panel-primary">
        <div class="panel-heading">
            Claim Verifications
            <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 2 of 3<i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="verificationdetails"></div>
            <%
                if (ClaimType == 1)
                {
            %>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Event Type.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="eventtypes"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Patient Name.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="PatientName"></asp:TextBox>
                    </div>

                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Hospital.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="hospital"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Date of Admission</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="dateofAdmission" TextMode="Date"></asp:TextBox>
                    </div>

                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Date of Discharge</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="dateofdischarge" TextMode="Date" OnTextChanged="ValidateNumberOfDays_Click" AutoPostBack="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Re-imbursement Type</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control select2" runat="server" ID="reimbursementType" AppendDataBoundItems="true">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Medical Soft</asp:ListItem>
                            <asp:ListItem Value="2">Medical MIB</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>No of Days(Occurence Place)</label>
                        <asp:TextBox CssClass="form-control" runat="server" ID="noOfDays" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Surgery Benefit</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="SurgeryBenefit" TextMode="Number"></asp:TextBox>
                    </div>


                </div>


                <div class="col-md-6">
                    <div class="form-group">
                        <label>Invoice No.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="invoiceNo"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Invoice Amount</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="invoiceAmount" TextMode="Number"></asp:TextBox>
                    </div>

                </div>
            </div>
        <%}
            else
            {
        %>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Event Type.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="eventtypes1"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Date of Death</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtDateofDate" TextMode="Date"></asp:TextBox>
                    </div>

                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label>Deceased Name.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="deceasedName"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>Burial Permit No</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:TextBox CssClass="form-control" runat="server" ID="buriapermitNo"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Payment Type.</label><span class="text-danger" style="font-size: 25px">*</span>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="paymenttype" AppendDataBoundItems="true">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Death Soft</asp:ListItem>
                            <asp:ListItem Value="2">Death MIB</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        <%} %>
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
            <%
                if (ClaimType == 1)
                {
            %>
            <div class="col-md-6">
                <div class="form-group">
                    <strong>Medical Documents:</strong><span class="text-danger" style="font-size: 25px">*</span>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="filetoupload" />
                </div>
                <div class="form-group">
                    <strong>Other Document:</strong>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="otherdocuments" />
                </div>
                <%--  <div class="form-group">
                    <strong>Hospital Invoice:</strong><span class="text-danger" style="font-size: 25px">*</span>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="hospitalinvoice" />
                </div>--%>
            </div>
            <%-- <div class="col-md-6">
                <div class="form-group">
                    <strong>Receipts:</strong><span class="text-danger" style="font-size: 25px">*</span>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="receipts" />
                </div>
                <div class="form-group">
                    <strong>Principal's ID Copy:</strong><span class="text-danger" style="font-size: 25px">*</span>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="payments" />
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <strong>Claimants ID Copy:</strong><span class="text-danger" style="font-size: 25px">*</span>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="claimsidcopy" />
                </div>
                <div class="form-group">
                    <strong>Other Document:</strong>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="otherdocuments" />
                </div>
            </div>--%>
            <%}
                else
                {
            %>
            <div class="col-md-6">
                <div class="form-group">
                    <strong>Burial Documents:</strong><span class="text-danger" style="font-size: 25px">*</span>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="burialpermit" />
                </div>
                <div class="form-group">
                    <strong>Other Document:</strong>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="deathotherdocument" />
                </div>

            </div>
            <%--        <div class="col-md-6">
                <div class="form-group">
                    <strong>Grower Payslip:</strong><span class="text-danger" style="font-size: 25px">*</span>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="growerpayslip" />
                </div>
                <div class="form-group">
                    <strong>Deceased ID Copy:</strong><span class="text-danger" style="font-size: 25px">*</span>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="deceasedslip" />
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <strong>Beneficiary ID Copy:</strong><span class="text-danger" style="font-size: 25px">*</span>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="beneficiaryid" />
                </div>
                    <div class="form-group">
                    <strong>Claim Form:</strong><span class="text-danger" style="font-size: 25px">*</span>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="claimform" />
                </div>
               
            </div>--%>
            <%} %>
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

                            String filesFolder = ConfigurationManager.AppSettings["FilesLocation"] + "Claims Verification Card/";
                            String PolicyNo = Request.QueryString["requisitionNo"].Trim();
                            PolicyNo = PolicyNo.Replace('/', '_');
                            PolicyNo = PolicyNo.Replace(':', '_');
                            string GrowerNo = Request.QueryString["GrowerNo"].Trim();
                            String documentDirectory = filesFolder + PolicyNo + "_" + GrowerNo + "/";
                            if (Directory.Exists(documentDirectory))
                            {
                                validations.Visible = true;

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
                <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Send Claim for Verifications" OnClick="Sendforvalidations_Click" ID="validations" Visible="false" />

                <div class="clearfix"></div>
            </div>

        </div>
    </div>
    <%} %>
</asp:Content>
