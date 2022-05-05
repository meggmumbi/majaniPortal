<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MicroInsurancePolicies.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MajaniPortal.MicroInsurancePolicies" %>

<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            Micro-Insurance Policies           
        </div>
        <div class="box-body">
            <div class="box">
                <div runat="server" id="opencommunicationsdetails"></div>
                <div class="tab-content">
                    <div class="box-body">
                        <div class="table-responsive">
                        <table id="example1" class="table table-bordered table-striped datatable">
                            <thead>
                                <tr>
                                    <th>Client ID/Grower No</th>
                                  <%--  <th>Contract No</th>
                                    <th>Customer No</th>--%>
                                    <th>Name</th>
                                    <th>Policy Start Date</th>
                                    <th>Policy End Date</th>
                                    <th>Claim</th>
                                    <th>Ammend</th>
                                </tr>
                            </thead>
                            <tbody>
                                 <%

                                      string profileType = "";
                                      string profileCode = "";

                                      var Profle = Convert.ToString(Session["Profile"]);
                                      var empNo = Session["empNo"].ToString();
                                      var nav = Config.ReturnNav();

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
                                    string AllCustomers = new Config().ObjNav().FnGetServiceContracts(profileCode,profileType);
                                    String[] info = AllCustomers.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                                    if (info != null)
                                    {
                                        foreach (var allInfo in info)
                                        {
                                            String[] arr = allInfo.Split('*');
                                            %>
                                            <tr>
                                                <td><% =arr[0] %></td>
                                              <%--  <td><% =arr[1] %></td>
                                                <td><% =arr[2] %></td>--%>
                                                <td><% =arr[3] %></td>
                                                <td><% =arr[4] %></td>
                                                <td><% =arr[5] %></td>
                                                <td>
                                                    <a href="NewClaimNotification.aspx?GrowerNo=<%=arr[0] %>&&ContractNo=<%=arr[1] %>&&CustomerNo=<%=arr[2] %>" class="btn btn-success"><i class="fa fa-share"></i>Claim</a>
                                                </td>
                                                 <%
                                                     if (arr[6] == "Individual")
                                                     {
                                                  %>
                                                 <td>
                                                    <a href="KYMIndividualClientsPolicyAmmendments.aspx?GrowerNo=<%=arr[0] %>&&ContractNo=<%=arr[1] %>&&CustomerNo=<%=arr[2] %>" class="btn btn-success"><i class="fa fa-share"></i>Ammend</a>
                                                  </td>
                                                  <%
                                                      }
                                                      else
                                                      {
                                                    %>
                                                  <td>
                                                    <a href="KYMCorporatePolicyAmmendments?GrowerNo=<%=arr[0] %>&&ContractNo=<%=arr[1] %>&&CustomerNo=<%=arr[2] %>" class="btn btn-success"><i class="fa fa-share"></i>Ammend</a>
                                                  </td>
                                                   <%
                                                    }
                                                  %>
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
