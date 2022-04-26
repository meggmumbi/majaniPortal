<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgriculturalPolicies.aspx.cs" Inherits="MajaniPortal.AgriculturalPolicies" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">



      <div class="panel panel-primary">
        <div class="panel-heading">
           Agricultural Policies           
        </div>
        <div class="box-body">
            <div class="box">
                <div runat="server" id="opencommunicationsdetails"></div>
                <div class="tab-content">
                    <div class="box-body">
                        <table id="example1" class="table table-bordered table-striped datatable">
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Product</th>
                                    <th>Id Number</th>                                   
                                    <th>Phone Number</th>
                                    <th>Insurer</th>
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
                                    string AllCustomers = new Config().ObjNav().FnGetServiceContractsAgriculture(profileCode,profileType);
                                    String[] info = AllCustomers.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                                    if (info != null)
                                    {
                                        foreach (var allInfo in info)
                                        {
                                            String[] arr = allInfo.Split('*');
                                            %>
                                            <tr>
                                                <td><% =arr[2] %></td>
                                                <td><% =arr[3] %></td>
                                                <td><% =arr[4] %></td>
                                                <td><% =arr[5] %></td>
                                                <td><% =arr[6] %></td>                                              
                                                <td>
                                                    <a href="NewClaimNotificationAgriculture.aspx?ContractNo=<%=arr[0] %>&&CustomerNo=<%=arr[1] %>" class="btn btn-success"><i class="fa fa-share"></i>Claim</a>
                                                </td>
                                                 <%
                                                     if (arr[7] == "Individual")
                                                     {
                                                  %>
                                                 <td>
                                                    <a href="AgricultureIndividualClientsPolicyAmmendments.aspx?ContractNo=<%=arr[0] %>&&CustomerNo=<%=arr[1] %>" class="btn btn-success"><i class="fa fa-share"></i>Ammend</a>
                                                  </td>
                                                  <%
                                                      }
                                                      else
                                                      {
                                                    %>
                                                  <td>
                                                    <a href="AgricultureCorporatePolicyAmmendments?ContractNo=<%=arr[0] %>&&CustomerNo=<%=arr[1] %>" class="btn btn-success"><i class="fa fa-share"></i>Ammend</a>
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
</asp:Content>
