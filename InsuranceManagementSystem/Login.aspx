<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InsuranceManagementSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Insurance Management System</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/jquery-3.7.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

    <style>
        .login,
        .image {
            min-height: 100vh;
        }

        .bg-image {
            background-image: url('../Images/background.jpg');
            background-size: contain;
            background-repeat: no-repeat;
            background-position: center
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <div class="container-fluid">
            <div class="row no-gutter">
                <div class="col-md-5 d-none d-md-flex bg-image"></div>

                <div class="col-md-7" style="background-color: cornflowerblue">
                    <div class="login d-flex align-items-center py-5">

                        <div class="container">
                            <div class="row">
                                <div class="col-lg-10 col-xl-8 mx-auto">
                                    <h3 class="display-3 pb-3 align-text-top" style="font-family: 'Lucida Calligraphy';
                                        color: white; font-weight: 500">Guardian Life Insurance</h3>
                                    <p class="text-light mb-4" style="font-size: 25px; font-weight: 600">Sign In</p>
                                    <div class="form-group mb-3">
                                        <input id="inputUsername" type="text" placeholder="Username" required="required"
                                            runat="server" autofocus="" class="form-control runded-pill border-0 shadow-sm px-4" />
                                    </div>

                                    <div class="form-group mb-3 mb-2">
                                        <input id="inputPassword" type="password" placeholder="Password" required="required"
                                            runat="server" autofocus="" class="form-control runded-pill border-0 shadow-sm px-4 text-primary" />
                                    </div>

                                    <asp:Button ID="btnLogin" runat="server" Text="Sign In" CssClass="btn btn-primary btn-block text-uppercase mb-2 mt-2 rounded-pill shadow-sm"
                                        Width="125px" BackColor="#5558C9" OnClick="btnLogin_Click" />
                                    <div class="text-center d-flex justify-content-between mt-4">
                                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>