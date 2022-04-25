<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="QuantityCart.aspx.cs" Inherits="BHT_Bookstore_ASP_NET.QuntityCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Sửa số lượng sách</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
    <asp:Button ID="btnSubmit" runat="server" Text="Cập nhật"  OnClick="btnSubmit_Click"/>
</asp:Content>
