<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BHT_Bookstore_ASP_NET.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Trang chủ</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Login form  -->
    <div class="login-form-container">
        <div id="close-login-btn" class="fas fa-times"></div>
        <form action="#">
            <h3>Đăng nhập</h3>
            <span>Tên tài khoản</span>
            <asp:TextBox ID="txtUsername" CssClass="box" runat="server"></asp:TextBox>
            <span>Mật khẩu</span>
            <asp:TextBox ID="txtPassword" CssClass="box" runat="server" TextMode="Password"></asp:TextBox>
            <div class="checkbox">
                <input type="checkbox" name="" id="remember-me">
                <label for="remember-me">Nhớ mật khẩu</label>
            </div>
            <asp:Button ID="btnLogin" CssClass="btn" runat="server" Text="Đăng nhập" />
            <p><a href="#">Quên mật khẩu</a></p>
            <p>Tôi chưa có tài khoản. <a href="#">Tạo ngay</a></p>
        </form>
    </div>
</asp:Content>
