<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BHT_Bookstore_ASP_NET.admin.dashboard.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Bảng điều khiển</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1 class="m-0">Bảng điều khiển</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="/admin/dashboard/Default.aspx"><i class="fas fa-home"></i></a></li>
                            <li class="breadcrumb-item active">Bảng điều khiển</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

        <!-- Main content -->
        <section class="content">
            <div class="container-fluid">
                <h1>Hello world</h1>
            </div>
        </section>
    </div>
</asp:Content>
