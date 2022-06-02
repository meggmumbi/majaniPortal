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
                                        <th>Customer No</th>
                                        <th>Name</th>
                                        <th>Policy Start Date</th>
                                        <th>Policy End Date</th>
                                        <th>Claim</th>
                                        <th>Ammend</th>
                                         <th>Renewal</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%
                                      var nav = Config.ReturnNav();
                                      string profileType = "";
                                      string profileCode = "";

                                      var Profle = Convert.ToString(Session["Profile"]);
                                      var empNo = Session["empNo"].ToString();
                                     

                                      var employee = nav.Employees.Where(x => x.No == empNo).ToList();
                                      foreach (var user in employee)
                                      {
                                          if (Profle == "Region")
                                          {
                                              profileType = "Region";
                                              profileCode = user.Region_Code;
                                          }
                                          if (Profle == " Zone")
                                          {
                                              profileType = "Zone";
                                              profileCode = user.Zone_Code;
                                          }
                                          if (Profle == " Factory")
                                          {
                                              profileType = "Factory";
                                              profileCode = user.Factory_name;
                                          }
                                          if (Profle == "Branch")
                                          {
                                              profileType = "Branch";
                                              profileCode = user.Global_Dimension_2_Code;
                                          }
                                      }
                                        //var applications = nav.ServiceContracts.Where(x => x.Business_Type == "General").ToList();
                                        string AllCustomers = new Config().ObjNav().FnGetMotorPolicies(profileCode,profileType);
                                        String[] info = AllCustomers.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                                        if (info != null)
                                        {
                                            foreach (var allInfo in info)
                                            {
                                                String[] arr = allInfo.Split('*');
                                            %>
                                     
                                  
                                    <tr>
                                        <td><%= arr[0] %></td>
                                        <td><%= arr[1]%></td>
                                        <td><%= arr[2]%></td>
                                        <td><%= Convert.ToDateTime(arr[3]).ToString("dd/MM/yyyy")%></td>
                                        <td><%= Convert.ToDateTime(arr[4]).ToString("dd/MM/yyyy")%></td>
                                       <td>
                                        <a href="MotorClaimNotifications.aspx?ContractNo=<%=arr[0] %>&&CustomerNo=<%=arr[1] %>" class="btn btn-success"><i class="fa fa-share"></i>Claim</a>
                                        </td> 
                                        <%
                                            if (arr[5] == "Individual")
                                            {
                                          %>
                                        <td>
                                        <a href="MotorIndividualPolicyAmmendments.aspx?ContractNo=<%=arr[0] %>&&CustomerNo=<%=arr[1] %>" class="btn btn-success"><i class="fa fa-share"></i>Ammend</a>
                                        </td>
                                        <%
                                            }
                                            if (arr[5] == "Corporate")
                                            { %>  
                                        <td>
                                        <a href="MotorCorporatePolicyAmmendments.aspx?ContractNo=<%=arr[0] %>&&CustomerNo=<%=arr[1]%>" class="btn btn-success"><i class="fa fa-share"></i>Ammend</a>
                                        </td>
                                        <% } %> 
                                         <td>
                                        <a href="MotorIndividualPolicyRenewals.aspx?ContractNo=<%=arr[0] %>&&CustomerNo=<%=arr[1] %>" class="btn btn-success"><i class="fa fa-share"></i>Renewal</a>
                                        </td>                                       
                                     </tr>
                                    <%
                                            }
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
