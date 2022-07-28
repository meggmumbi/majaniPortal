<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MotorPolicies.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MajaniPortal.MotorPolicies" %>

<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            Motor UnderWriting Policies           
        </div>
        <div class="box-body">
            <div class="box">
                <div runat="server" id="opencommunicationsdetails"></div>
                <div class="tab-content">
                    <div class="tab-pane active in" id="tab_1_1">
                        <div class="box-body">
                            <table id="example1" class="table table-bordered table-striped datatable">
                                <thead>
                                    <tr>
                                        <th>Contract No</th>
                                        <th>Customer Name</th>
                                       
                                        <th>Policy Start Date</th>
                                        <th>Policy End Date</th>
                                        <th>Claim</th>
                                        <th>Ammend</th>
                                         <th>Renewal</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%
                                        var nav = Config.ReturnNav();                                     

                                        var Profle = Convert.ToString(Session["Profile"]);
                                        var empNo = Session["empNo"].ToString();
                                        var customerNo = Convert.ToString(Request.QueryString["CustomerNo"]);

                                     
                                        var applications = nav.ServiceContracts.Where(x => x.Customer_No == customerNo && x.Business_Type=="General" && x.Policy_Status=="Active").ToList();
                                      
                                        foreach (var allInfo in applications)
                                        {
                                         
                                            %>
                                     
                                  
                                    <tr>
                                        <td><%= allInfo.Contract_No %></td>
                                        <td><%= allInfo.Contact_Name%></td>
                                       
                                        <td><%= Convert.ToDateTime(allInfo.Policy_Start_Date).ToString("dd/MM/yyyy")%></td>
                                        <td><%= Convert.ToDateTime(allInfo.Policy_End_Date).ToString("dd/MM/yyyy")%></td>
                                       <td>
                                        <a href="MotorClaimNotifications.aspx?ContractNo=<%=allInfo.Contract_No %>&&CustomerNo=<%=allInfo.Customer_No %>" class="btn btn-success"><i class="fa fa-share"></i>Claim</a>
                                        </td> 
                                        <%
                                            if (allInfo.Customer_Type == "Individual")
                                            {
                                          %>
                                        <td>
                                        <a href="MotorIndividualPolicyAmmendments.aspx?ContractNo=<%=allInfo.Contract_No %>&&CustomerNo=<%=allInfo.Customer_No %>" class="btn btn-success"><i class="fa fa-share"></i>Ammend</a>
                                        </td>
                                        <%
                                            }
                                            if (allInfo.Customer_Type == "Corporate")
                                            { %>  
                                        <td>
                                        <a href="MotorCorporatePolicyAmmendments.aspx?ContractNo=<%=allInfo.Contract_No %>&&CustomerNo=<%=allInfo.Customer_No%>" class="btn btn-success"><i class="fa fa-share"></i>Ammend</a>
                                        </td>
                                        <% } %> 
                                         <td>
                                        <a href="MotorIndividualPolicyRenewals.aspx?ContractNo=<%=allInfo.Contract_No %>&&CustomerNo=<%=allInfo.Customer_No %>" class="btn btn-success"><i class="fa fa-share"></i>Renewal</a>
                                        </td> 
                                         <td>
                                                     <a href="ClientProfile?ContractNo=<%=allInfo.Contract_No %>" class="btn btn-success"><i class="fa fa-file"></i>View profile</a>
                                                </td>                                      
                                     </tr>
                                    <%
                                          
                                        }
                                    %>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
