<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BHT_Bookstore_ASP_NET.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta charset="utf-8" />
    <script>
        addEventListener("load", function () {
            setTimeout(hideURLbar, 0);
        }, false);

        function hideURLbar() {
            window.scrollTo(0, 1);
        }
    </script>
    <link rel="stylesheet" href="/assets/css/login.css" type="text/css" media="all" />
    <link href="//fonts.googleapis.com/css?family=Mukta+Mahee:200,300,400,500,600,700,800" rel="stylesheet" />
    <link rel="stylesheet" href="/assets/css/font-awesome.css" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="title-agile text-center">BHT Bookstore</h1>
        <div class="content-w3ls">
            <div class="agileits-grid">
                <div class="content-bottom">
                    <div class="field_w3ls">
                        <div class="field-group">
                            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                        </div>
                        <div class="field-group">
                            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                            <span toggle="#password-field" class="fa fa-fw fa-eye field-icon toggle-password"></span>
                        </div>
                    </div>
                    <div class="wthree-field">
                        <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" OnClick="btnLogin_Click" />
                    </div>
                    <ul class="list-login">
                        <li class="switch-agileits">
                            <label class="switch">
                                <input type="checkbox" />
                                <span class="slider round"></span>
                                Giữ đăng nhập
                            </label>
                        </li>
                        <li>
                            <a href="#" class="text-right">Quên mật khẩu</a>
                        </li>
                        <li class="clearfix"></li>
                    </ul>
                </div>
            </div>
        </div>
        <script src="/assets/js/jquery-2.2.3.min.js"></script>
        <script>
            $(".toggle-password").click(function () {

                $(this).toggleClass("fa-eye fa-eye-slash");
                var input = $($(this).attr("toggle"));
                if (input.attr("type") == "password") {
                    input.attr("type", "text");
                } else {
                    input.attr("type", "password");
                }
            });
        </script>
    </form>
</body>
</html>
