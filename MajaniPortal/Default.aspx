<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="MajaniPortal.Default" %>

<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
   <%{
           var Connection = Config.ReturnNav();
           var EmplyeeNumber = Session["empNo"].ToString();
       } %>

    <div class="row">
        <div class="col-lg-3 col-xs-6">
            <div class="small-box bg-aqua">
                <div class="inner">
                    <h3>150</h3>

                    <p>New Business Applications</p>
                </div>
                <div class="icon">
                    <i class="ion ion-bag"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
        <div class="col-lg-3 col-xs-6">
            <div class="small-box bg-green">
                <div class="inner">
                    <h3>53<sup style="font-size: 20px">%</sup></h3>

                    <p>Claim Applications</p>
                </div>
                <div class="icon">
                    <i class="ion ion-stats-bars"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
        <div class="col-lg-3 col-xs-6">
            <div class="small-box bg-yellow">
                <div class="inner">
                    <h3>44</h3>

                    <p>Open Policy Ammendments</p>
                </div>
                <div class="icon">
                    <i class="ion ion-person-add"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
        <div class="col-lg-3 col-xs-6">
            <div class="small-box bg-red">
                <div class="inner">
                    <h3>65</h3>

                    <p>New Clients Applications</p>
                </div>
                <div class="icon">
                    <i class="ion ion-pie-graph"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
    </div>
      <div runat="server" id="feedbackdetails"></div>
    <div class="panel panel-primary">
        <div class="panel-heading">
          Clients List
        </div>
        <div class="box-body">
            <table id="example2" class="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th>Customer No</th>
                        <th>Name</th>
                        <th>Grower No/Client ID</th>
                        <th>ID No./Passport No</th>
                        <th>Phone No.</th>
                    </tr>
                </thead>
                <tbody>
                  <%--  <%
                        var status = new Config().ObjNav().FnGetCustomersList();
                        var res = status.Split('*');
                        if (!string.IsNullOrEmpty(res[0]))
                        {
                    %>
                    <tr>
                        <td><%= res[0] %></td>
                        <td><%= res[1] %></td>
                        <td><%= res[2] %></td>
                        <td><%= res[3]%></td>
                        <td><%= res[4] %></td>                      
                    </tr>
                    <%
                      }
                    %>--%>
                      <%
                         var No = "";
                          var Name = "";
                          var Gno = "";
                          var mobile = "";
                          var ID = "";

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

                                %>
                                <tr>
                                    <td><% =No %></td>
                                    <td><% =Name %></td>
                                    <td><% =Gno %></td>
                                    <td><% =mobile %></td>
                                    <td><% =ID %></td>
                                </tr>
                                <% 
                            }
                        }
                    %>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
