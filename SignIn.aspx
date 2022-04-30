<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="BHT_Bookstore_ASP_NET.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng ký</title>
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
            <div class="agileits-grid" style="width: 800px;">
                <div class="content-bottom">
                    <div class="field_w3ls">
                        <div class="field-group">
                            <asp:TextBox ID="txtUsername" runat="server" Text="Tên đăng nhập"></asp:TextBox>
                        </div>
                        <div class="field-group">
                            <asp:TextBox ID="txtPassword1" runat="server" TextMode="Password" Text="Mật khẩu"></asp:TextBox>
                        </div>
                        <div class="field-group">
                            <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password" Text="Mật khẩu"></asp:TextBox>
                        </div>
                        <div class="field-group">
                            <asp:TextBox ID="txtFullname" runat="server" Text="Họ tên"></asp:TextBox>
                        </div>
                        <div class="field-group">
                            <asp:TextBox ID="txtEmail" runat="server" Text="Email"></asp:TextBox>
                        </div>
                        <div class="field-group">
                            <asp:TextBox ID="txtPhone" runat="server" Text="Số điện thoại"></asp:TextBox>
                        </div>
                    </div>
                    <div class="wthree-field">
                        <asp:Button ID="btnSignIn" runat="server" Text="Đăng ký" OnClick="btnSignIn_Click" />
                    </div>
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

