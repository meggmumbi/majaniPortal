<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="KYMPolicyAmendments.aspx.cs" Inherits="MajaniPortal.KYMPolicyAmendments" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
    <%
        int step = 1;
        try
        {
            step = Convert.ToInt32(Request.QueryString["step"]);
            if (step > 5 || step < 1)
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
                        <label>Policy No</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="policyNumber" Placeholder="Select Policy No"></asp:DropDownList>
                    </div>
                </div>

                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Policy Type</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="policyTypes" Placeholder="Select Policy Types" OnSelectedIndexChanged="Poducts_Onclick" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Type of Application</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="typeofapplications" Placeholder="Select Policy Types"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Mode of Payment</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="modeofpayments" Placeholder="Select Policy Types"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Product Billing Cycle</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="productbillingcycle" Placeholder="Select Policy Types"></asp:DropDownList>
                    </div>
                </div>

                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Member Type</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="membertypes" Placeholder="Select Policy Types"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Agent Detail</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="agentdetails" Placeholder="Select Policy Types"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 col-lg-6">
                    <div class="form-group">
                        <label>Agent Code</label>
                        <asp:DropDownList CssClass="form-control" runat="server" ID="agentcodes" Placeholder="Select Policy Types"></asp:DropDownList>
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
            Dependants Details
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 2 of 3 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="txtdependantsfeedbackdetails"></div>
            <div class="panel-body pull-right">
                <label class="btn btn-success" data-toggle="modal" data-target="#dependants"><i class="fa fa-plus fa-fw"></i>Add Dependants</label>
            </div>
            <br />
            <br />
            <table id="example1" class="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th>Dependant Code</th>
                        <th>Name</th>
                        <th>Relationship</th>
                        <th>DOB</th>
                        <th>ID No</th>
                        <th>Age</th>
                        <th>Dependant Type</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                        var nav = Config.ReturnNav();
                        var requisitionNo = Request.QueryString["requisitionNo"].Trim();
                        var applications = nav.PolicyDependants.Where(r => r.Policy_Qoute_No == requisitionNo);
                        foreach (var application in applications)
                        {
                    %>
                    <tr>
                        <td><%= application.Dependant_Code %></td>
                        <td><%= application.Name %></td>
                        <td><%= application.Relationship %></td>
                        <td><%= application.Date_Of_Birth %></td>
                        <td><%= application.ID_No %></td>
                        <td><%= application.Age %></td>
                        <td><%= application.Depandant_Type %></td>
                    </tr>
                    <%
                        }
                    %>
                </tbody>
            </table>
        </div>

    </div>
    <div class="panel panel-primary">
        <div class="panel-heading">
            Beneficiaries Details
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 2 of 3 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div runat="server" id="txtbeneficiariesdetails"></div>
        <div class="panel-body pull-right">
            <label class="btn btn-success" data-toggle="modal" data-target="#beneficiaries"><i class="fa fa-plus fa-fw"></i>Add Beneficiaries</label>
        </div>
        <br />
        <div class="box-body">
            <table id="example2" class="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th>Beneficiary</th>
                        <th>Name</th>
                        <th>Relationship</th>
                        <th>DOB</th>
                        <th>ID No</th>
                        <th>Age</th>
                        <th>Allocation</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                        var requisitionNo1 = Request.QueryString["requisitionNo"].Trim();
                        var applications1 = nav.PolicyBeneficiaries.Where(r => r.Policy_Qoute_No == requisitionNo);
                        foreach (var application in applications1)
                        {
                    %>
                    <tr>
                        <td><%= application.Beneficiary %></td>
                        <td><%= application.Name %></td>
                        <td><%= application.Relationship %></td>
                        <td><%= application.Date_Of_Birth %></td>
                        <td><%= application.ID_No %></td>
                        <td><%= application.Age %></td>
                        <td><%= application.Allocation %></td>
                    </tr>
                    <%
                        }
                    %>
                </tbody>
            </table>
        </div>
        <div class="panel-footer">
            <asp:Button runat="server" CssClass="btn btn-warning pull-left" Text="Previous" OnClick="previousstep_Click" />
            <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Next" OnClick="nextstep_Click" ID="Button1" />
            <div class="clearfix"></div>
        </div>
    </div>
    <div id="dependants" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Dependant Details</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Dependant Code:</strong><asp:TextBox runat="server" CssClass="form-control" placeholder="Dependant Code." ID="txtdependantcodes" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Name:</strong><asp:TextBox runat="server" CssClass="form-control" placeholder="Name" ID="txtname" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Relationship:</strong><asp:DropDownList runat="server" CssClass="form-control" ID="txtrelationship" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Date Of Birth:</strong><asp:TextBox runat="server" CssClass="form-control datepicker" placeholder="Date of Birth" ID="txtdateob" TextMode="Date" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Id number:</strong><asp:TextBox runat="server" CssClass="form-control" placeholder="ID Number" ID="lblIdNumber" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Age:</strong><asp:TextBox runat="server" CssClass="form-control" ID="txtage" TextMode="Number" placeholder="Age" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Gender:</strong><asp:DropDownList runat="server" CssClass="form-control" ID="txtgenders" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Dependant Type:</strong><asp:DropDownList runat="server" CssClass="form-control" ID="txtdependanttype" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>DHB:</strong><asp:TextBox CssClass="form-control" runat="server" ID="dhb"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>DHB Premium:</strong><asp:TextBox CssClass="form-control" runat="server" ID="dhbpremium"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" CssClass="btn btn-success" Text="Add Dependant" OnClick="AddDependants_Click" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div id="beneficiaries" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Beneficiaries Details</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Beneficiary:</strong><asp:TextBox runat="server" CssClass="form-control" placeholder="Beneficiary" ID="txtbeneficiary" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Name:</strong><asp:TextBox runat="server" CssClass="form-control" placeholder="Name" ID="txtnames" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Relationship:</strong><asp:DropDownList runat="server" CssClass="form-control" ID="bentxtrelationships" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Date Of Birth:</strong><asp:TextBox runat="server" CssClass="form-control bootstrapdatepicker" placeholder="Date of Birth" ID="txtdobs" TextMode="Date" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Id number:</strong><asp:TextBox runat="server" CssClass="form-control" placeholder="ID Number" ID="txtidnumbers" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Age:</strong><asp:TextBox runat="server" CssClass="form-control" ID="txtages" TextMode="Number" placeholder="Age" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Gender:</strong><asp:DropDownList runat="server" CssClass="form-control" ID="txtgender2" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-6">
                            <div class="form-group">
                                <strong>Allocation:</strong><asp:TextBox runat="server" CssClass="form-control " placeholder="Allocation" ID="txtallocation" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" CssClass="btn btn-success" Text="Add Beneficiaries" OnClick="AddBeneficaries_Click" />
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
                <span class="pull-right"><i class="fa fa-chevron-left"></i>Step 3 of 3 <i class="fa fa-chevron-right"></i></span><span class="clearfix"></span>
        </div>
        <div class="box-body">
            <div runat="server" id="documentsfeedback"></div>
                <div class="form-group">
                    <strong>Upload Supporting Documents:</strong>
                    <asp:FileUpload runat="server" CssClass="form-control" ID="filetoupload" />
                </div>
            <div class="panel-footer">
                <asp:Button runat="server" CssClass="btn btn-success pull-right" Text="Upload" ID="uploaddocuments" OnClick="upload_Click" />
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
                <div class="clearfix"></div>
            </div>

        </div>
    </div>
    <%} %>
</asp:Content>