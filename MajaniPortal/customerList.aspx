<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="customerList.aspx.cs" Inherits="MajaniPortal.customerList" %>
<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">


     <div class="panel panel-primary">
        <div class="panel-heading">
          Clients List
        </div>
        <div class="box-body">
             <div class="table-responsive">
            <table id="example2" class="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th>Customer No</th>
                        <th>Name</th>                      
                        <th>ID No./Passport No</th>
                        <th>Phone No.</th>
                        <th>Balance</th>
                        <th>Balance Due</th>
                        <th>Payments</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>    
                      <%
                          var No = "";
                          var Name = "";
                          var Gno = "";
                          var mobile = "";
                          var ID = "";
                          var balance = "";
                          var balanceDue = "";
                          var payment = "";

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

                          string AllCustomers = new Config().ObjNav().FnCustomerList(profileCode, profileType);
                          String[] info = AllCustomers.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                          if (info != null)
                          {
                              foreach (var allInfo in info)
                              {
                                  String[] arr = allInfo.Split('*');
                                  No = arr[0];
                                  Name = arr[1];
                                  Gno = arr[2];
                                  mobile = arr[3];
                                  ID = arr[4];
                                  balance = arr[5];
                                  balanceDue = arr[6];
                                  payment = arr[7];

                                %>
                                <tr>
                                    <td><% =No %></td>
                                    <td><% =Name %></td>                               
                                    <td><% =mobile %></td>
                                    <td><% =ID %></td>
                                     <td><% =balance %></td>
                                     <td><% =balanceDue %></td>
                                     <td><% =payment %></td>
                                      <td>  <a href="MotorPolicies.aspx?CustomerNo=<%=No %>" class="btn btn-success">View Policies</a></td>
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
</asp:Content>
