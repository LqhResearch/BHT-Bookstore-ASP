<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BHT_Bookstore_ASP_NET.admin.dashboard.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="icon" href="/assets/img/favicon.png" />
    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="/vendor/plugins/fontawesome-free/css/all.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- Tempusdominus Bootstrap 4 -->
    <link rel="stylesheet" href="/vendor/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css" />
    <!-- iCheck -->
    <link rel="stylesheet" href="/vendor/plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
    <!-- JQVMap -->
    <link rel="stylesheet" href="/vendor/plugins/jqvmap/jqvmap.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="/vendor/dist/css/adminlte.min.css" />
    <!-- overlayScrollbars -->
    <link rel="stylesheet" href="/vendor/plugins/overlayScrollbars/css/OverlayScrollbars.min.css" />
    <!-- Daterange picker -->
    <link rel="stylesheet" href="/vendor/plugins/daterangepicker/daterangepicker.css" />
    <!-- summernote -->
    <link rel="stylesheet" href="/vendor/plugins/summernote/summernote-bs4.min.css" />
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
        <div class="login-box">
            <!-- /.login-logo -->
            <div class="card card-outline card-primary">
                <div class="card-header text-center">
                    <a href="#" class="h1"><b>BHT</b> bookstore</a>
                </div>
                <div class="card-body">
                    <p class="login-box-msg">Đăng nhập để bắt đầu phiên làm việc</p>
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <div class="input-group-text">
                                <span class="fas fa-user"></span>
                            </div>
                        </div>
                        <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <div class="input-group-text">
                                <span class="fas fa-lock"></span>
                            </div>
                        </div>
                        <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <asp:Button ID="btnLogin" CssClass="btn btn-primary btn-block" runat="server" Text="Đăng nhập (quản trị viên)" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- jQuery -->
    <script src="/vendor/plugins/jquery/jquery.min.js"></script>
    <!-- jQuery UI 1.11.4 -->
    <script src="/vendor/plugins/jquery-ui/jquery-ui.min.js"></script>
    <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
    <script>
        $.widget.bridge('uibutton', $.ui.button)
    </script>
    <!-- Bootstrap 4 -->
    <script src="/vendor/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- ChartJS -->
    <script src="/vendor/plugins/chart.js/Chart.min.js"></script>
    <!-- Sparkline -->
    <script src="/vendor/plugins/sparklines/sparkline.js"></script>
    <!-- JQVMap -->
    <script src="/vendor/plugins/jqvmap/jquery.vmap.min.js"></script>
    <script src="/vendor/plugins/jqvmap/maps/jquery.vmap.usa.js"></script>
    <!-- jQuery Knob Chart -->
    <script src="/vendor/plugins/jquery-knob/jquery.knob.min.js"></script>
    <!-- daterangepicker -->
    <script src="/vendor/plugins/moment/moment.min.js"></script>
    <script src="/vendor/plugins/daterangepicker/daterangepicker.js"></script>
    <!-- Tempusdominus Bootstrap 4 -->
    <script src="/vendor/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"></script>
    <!-- Summernote -->
    <script src="/vendor/plugins/summernote/summernote-bs4.min.js"></script>
    <!-- overlayScrollbars -->
    <script src="/vendor/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"></script>
    <!-- AdminLTE App -->
    <script src="/vendor/dist/js/adminlte.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="/vendor/dist/js/demo.js"></script>
    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
    <script src="/vendor/dist/js/pages/dashboard.js"></script>
</body>
</html>
