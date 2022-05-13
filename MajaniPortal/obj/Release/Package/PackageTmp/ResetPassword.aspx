<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="MajaniPortal.ResetPassword" %>
<!DOCTYPE html>
<html lang="en">
<head>
	<title>Reset Password</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
	<link rel="stylesheet" type="text/css" href="LoginAssets/vendor/bootstrap/css/bootstrap.min.css">
	<link rel="stylesheet" type="text/css" href="LoginAssets/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
	<link rel="stylesheet" type="text/css" href="LoginAssets/fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
	<link rel="stylesheet" type="text/css" href="LoginAssets/vendor/animate/animate.css">
	<link rel="stylesheet" type="text/css" href="LoginAssets/vendor/css-hamburgers/hamburgers.min.css">
	<link rel="stylesheet" type="text/css" href="LoginAssets/vendor/animsition/css/animsition.min.css">
	<link rel="stylesheet" type="text/css" href="LoginAssets/vendor/select2/select2.min.css">
	<link rel="stylesheet" type="text/css" href="LoginAssets/vendor/daterangepicker/daterangepicker.css">
	<link rel="stylesheet" type="text/css" href="LoginAssets/css/util.css">
	<link rel="stylesheet" type="text/css" href="LoginAssets/css/main.css">
</head>
<body>
	<form id="form1" runat="server">
	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<div class="login100-form-title" style="background-image: url(LoginAssets/images/bg-01.jpg);">
					<span class="login100-form-title-1">
						Majani  Insurance Brokers Portal
					</span>
                    <h4 class="login100-form-title-1">Reset Password</h4>
				</div>

				<div class="login100-form validate-form">
                    <div id="feedback" runat="server"></div>
					<div class="wrap-input100 validate-input m-b-26" data-validate="Username is required">
						<span class="label-input100">Email Address</span>
                         <asp:TextBox CssClass="input100" runat="server" ID="txtemailaddress" Placeholder="Please Enter Valid Email Address" TextMode="Email" required Style="height: 42px;" />
                           <span class="error" id="erroremail" runat="server" style="background-color: red"></span>
                           <asp:RequiredFieldValidator Display="Dynamic" runat="server" id="validateemail" controltovalidate="txtemailaddress" errormessage="Please enter email address, it cannot be empty!" ForeColor="Red"/>
						<span class="focus-input100"></span>
					</div>
					<div class="container-login100-form-btn">
                        <asp:Button runat="server" CssClass="login100-form-btn" ID="login" Text="Reset Password" OnClick="resetpassword_Click" />
					</div>
				</div>
			</div>
		</div>
	</div>
	<script src="LoginAssets/vendor/jquery/jquery-3.2.1.min.js"></script>
	<script src="LoginAssets/vendor/animsition/js/animsition.min.js"></script>
	<script src="LoginAssets/vendor/bootstrap/js/popper.js"></script>
	<script src="LoginAssets/vendor/bootstrap/js/bootstrap.min.js"></script>
	<script src="LoginAssets/vendor/select2/select2.min.js"></script>
	<script src="LoginAssets/vendor/daterangepicker/moment.min.js"></script>
	<script src="LoginAssets/vendor/daterangepicker/daterangepicker.js"></script>
	<script src="LoginAssets/vendor/countdowntime/countdowntime.js"></script>
	<script src="LoginAssets/js/main.js"></script>
</form>
</body>
</html>