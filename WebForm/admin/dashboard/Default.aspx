<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm.admin.dashboard.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Trang chủ</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1>Bảng điều khiển</h1>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="/admin/dashboard/Default.aspx"><i class="fas fa-home"></i></a></li>
                        <li class="breadcrumb-item active">Bảng điều khiển</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>

    <section class="content">
        <!-- Message box -->
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-3 col-6">
                    <div class="small-box bg-info">
                        <div class="inner">
                            <h3>
                                <asp:Label ID="lblCountCategories" runat="server"></asp:Label>
                            </h3>
                            <p>Thể loại</p>
                        </div>
                        <div class="icon">
                            <i class="fas fa-clipboard-list"></i>
                        </div>
                        <a href="/admin/categories/list.aspx" class="small-box-footer">Xem chi tiết <i class="fas fa-arrow-circle-right"></i>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-6">
                    <div class="small-box bg-success">
                        <div class="inner">
                            <h3>
                                <asp:Label ID="lblCountAuthors" runat="server"></asp:Label>
                            </h3>
                            <p>Tác giả</p>
                        </div>
                        <div class="icon">
                            <i class="fas fa-users"></i>
                        </div>
                        <a href="/admin/authors/list.aspx" class="small-box-footer">Xem chi tiết <i class="fas fa-arrow-circle-right"></i>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-6">
                    <div class="small-box bg-warning">
                        <div class="inner">
                            <h3>
                                <asp:Label ID="lblCountPublishes" runat="server"></asp:Label>
                            </h3>
                            <p>Nhà xuất bản</p>
                        </div>
                        <div class="icon">
                            <i class="fas fa-print"></i>
                        </div>
                        <a href="/admin/publishes/list.aspx" class="small-box-footer">Xem chi tiết <i class="fas fa-arrow-circle-right"></i>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-6">
                    <div class="small-box bg-danger">
                        <div class="inner">
                            <h3>
                                <asp:Label ID="lblCountSuppliers" runat="server"></asp:Label>
                            </h3>
                            <p>Nhà cung cấp</p>
                        </div>
                        <div class="icon">
                            <i class="fas fa-boxes"></i>
                        </div>
                        <a href="/admin/suppliers/list.aspx" class="small-box-footer">Xem chi tiết <i class="fas fa-arrow-circle-right"></i>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-6">
                    <div class="small-box bg-primary">
                        <div class="inner">
                            <h3>
                                <asp:Label ID="lblCountBooks" runat="server"></asp:Label>
                            </h3>
                            <p>Sách</p>
                        </div>
                        <div class="icon">
                            <i class="fas fa-book"></i>
                        </div>
                        <a href="/admin/books/list.aspx" class="small-box-footer">Xem chi tiết <i class="fas fa-arrow-circle-right"></i>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-6">
                    <div class="small-box bg-secondary">
                        <div class="inner">
                            <h3>
                                <asp:Label ID="lblCountOrders" runat="server"></asp:Label>
                            </h3>
                            <p>Đơn hàng</p>
                        </div>
                        <div class="icon">
                            <i class="fas fa-truck-loading"></i>
                        </div>
                        <a href="/admin/orders/list.aspx" class="small-box-footer">Xem chi tiết <i class="fas fa-arrow-circle-right"></i>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-6">
                    <div class="small-box bg-light">
                        <div class="inner">
                            <h3>
                                <asp:Label ID="lblCountUsers" runat="server"></asp:Label>
                            </h3>
                            <p>Tài khoản</p>
                        </div>
                        <div class="icon">
                            <i class="fas fa-user-circle"></i>
                        </div>
                        <a href="/admin/users/list.aspx" class="small-box-footer">Xem chi tiết <i class="fas fa-arrow-circle-right"></i>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-6">
                    <div class="small-box bg-dark">
                        <div class="inner">
                            <h3>
                                <asp:Label ID="lblCountSliders" runat="server"></asp:Label>
                            </h3>
                            <p>Slider</p>
                        </div>
                        <div class="icon" style="color: #FFF">
                            <i class="fas fa-images"></i>
                        </div>
                        <a href="/admin/sliders/list.aspx" class="small-box-footer">Xem chi tiết <i class="fas fa-arrow-circle-right"></i>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
