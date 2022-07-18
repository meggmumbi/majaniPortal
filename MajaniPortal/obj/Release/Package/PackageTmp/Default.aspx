<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="MajaniPortal.Default" %>

<%@ Import Namespace="MajaniPortal" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainBody" runat="server">
   <%{
           var Connection = Config.ReturnNav();
           var EmplyeeNumber = Session["empNo"].ToString();
           DateTime todayX = DateTime.Now;
           DateTime prevMonths = DateTime.Now;
           prevMonths = prevMonths.AddMonths(-1);
           DateTime firstDayOfMonth = new DateTime(todayX.Year, todayX.Month, 1);
           Double commission = 0.2;
           double xtotalAmount = 0;
           double totalAmount = 0;

           string today = DateTime.Now.Month.ToString();
           int prevMonth = Convert.ToInt32(today) - 1;
           DateTime Document_date = DateTime.Now;

           try
           {
               var applications = Connection.ClientApplicationQuery.Where(r => r.Requestor == Convert.ToString(Session["empNo"])&&r.Status!="Open" && r.Document_Date >= firstDayOfMonth && r.Business_Type=="Micro-Insurance").ToList();

               var serviceContracts = Connection.ServiceContracts.Where(r => r.Salesperson_Code == EmplyeeNumber && r.Document_Date >= firstDayOfMonth && r.Business_Type=="Micro-Insurance").ToList();

               foreach (var premCount in serviceContracts)
               {
                   xtotalAmount = Convert.ToDouble((xtotalAmount + Convert.ToDouble(premCount.Total_Premiums)));
               }
               totalAmount = xtotalAmount * commission;



%>
    <div class="row">
        <div class="col-lg-3 col-xs-6">
            <div class="small-box bg-aqua">
                <div class="inner">
                    <h3><%=applications.Count %></h3>

                    <p>New Applications for the month of <%=todayX.ToString("MMMM") %> </p>
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
                    <h3><sup style="font-size: 20px"></sup><%=serviceContracts.Count %></h3>

                    <p>Upgrades for the month of <%=todayX.ToString("MMMM") %>  </p>
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
                    <h3><%=xtotalAmount %> ksh</h3>

                    <p>Total Premium</p>
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
                    <h3><%=totalAmount %></h3>

                    <p>Total Commission</p>
                </div>
                <div class="icon">
                    <i class="ion ion-pie-graph"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
    </div>
      <div class="row">
        <div class="col-lg-3 col-xs-6">
            <div class="small-box bg-aqua">
                <div class="inner">
                    <h3>2800</h3>

                    <p>Target </p>
                </div>
                <div class="icon">
                    <i class="ion ion-bag"></i>
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
             <div class="table-responsive">
            <table id="example2" class="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th>Customer No</th>
                        <th>Name</th>
                        <th>Grower No/Client ID</th>
                        <th>ID No./Passport No</th>
                        <th>Phone No.</th>
                        <th>Balance</th>
                        <th>Balance Due</th>
                        <th>Payments</th>
                        <th></th>
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
                                    <td><% =Gno %></td>
                                    <td><% =mobile %></td>
                                    <td><% =ID %></td>
                                     <td><% =balance %></td>
                                     <td><% =balanceDue %></td>
                                     <td><% =payment %></td>
                                    <td> <a href="PrintCustStatement?clientNo=<%=No %>" class="btn btn-success">View Statement</a></td>
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
    <%}


            catch (Exception ex)
            {

            }
        }


        %>
</asp:Content>
