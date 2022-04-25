<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="BHT_Bookstore_ASP_NET.admin.orders.list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Đơn hàng</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1 class="m-0">Đơn hàng</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="/admin/dashboard/Default.aspx"><i class="fas fa-home"></i></a></li>
                            <li class="breadcrumb-item active">Đơn hàng</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

        <!-- Main content -->
        <section class="content">
            <!-- Message box -->
            <div class="container-fluid">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>

            <!-- Tools -->
            <div class="container-fluid">
                <div class="clear-fix">
                    <div class="float-right d-flex my-3">
                        <!-- Add button -->
                        <button type="button" class="btn btn-success mx-3" data-toggle="modal" data-target="#addModal">
                            <i class="fas fa-plus"></i>
                        </button>

                        <!-- Search data -->
                        <div class="input-group">
                            <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server"></asp:TextBox>
                            <div class="input-group-append">
                                <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="🍳" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Table -->
            <div class="container-fluid">
                <table class="table table-bordered bg-white">
                    <thead class="bg-primary">
                        <tr>
                            <th>Mã đơn hàng</th>
                            <th>Tổng đơn hàng</th>
                            <th>Tổng tiền thanh toán</th>
                            <th>Trạng thái</th>
                            <th>Ngày thanh toán</th>
                            <th>Ngày tạo</th>
                            <th>Người mua</th>
                            <th width="177">Công cụ</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("OrderID") %></td>
                                    <td><%# Eval("TotalMoney") %></td>
                                    <td><%# Eval("TotalRevenue") %></td>
                                    <td><%# Eval("Status").ToString() == "True" ? "<span class='badge badge-success'>Thanh toán</span>" : "<span class='badge badge-danger'>Chưa thanh toán</span>" %></td>
                                    <td><%# Eval("PaymentDate") %></td>
                                    <td><%# Eval("CreatedAt") %></td>
                                    <td><%# Eval("Username") %></td>
                                    <td>
                                        <span data-toggle="modal" data-target="#editModal">
                                            <asp:HyperLink ID="hplEdit" CssClass="btn btn-info" NavigateUrl='<%# "OrderDetails.aspx?id=" + Eval("OrderID") %>' runat="server"><i class="fas fa-eye"></i></asp:HyperLink>
                                        </span>
                                        <asp:HyperLink ID="hplPayment" CssClass="btn btn-success" NavigateUrl='<%# "?payment-id=" + Eval("OrderID") %>' runat="server" style='<%# Eval("Status").ToString() == "True" ? "display: none" : "" %>'>Thanh toán</asp:HyperLink>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Label ID="lblList" runat="server" Text=""></asp:Label>
                    </tbody>
                </table>
            </div>

            <!-- Pagination -->
            <asp:Label ID="lblPaginationDisable" CssClass="" runat="server" Text="">
                <div class="container-fluid d-flex align-content-center justify-content-between">
                    <div>Hiển thị từ <%=pager["StartPage"] %> đến <%=pager["EndPage"] %> của <%=pager["TotalItems"] %> dòng</div>
                    <ul class="pagination">
                        <% for (int i = 1; i <= pager["TotalPages"]; i++)
                            {%>
                        <li class="page-item <%=pager["CurrentPage"] == i ? "active" : "" %>">
                            <a class="page-link" href="?page=<%=i %>"><%=i %></a>
                        </li>
                        <% } %>
                    </ul>
                </div>
            </asp:Label>
        </section>
    </div>

    <!-- jQuery -->
    <script src="/vendor/plugins/jquery/jquery.min.js"></script>

    <script>
        $(document).ready(function () {
            function GetParameterValues(param) {
                var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
                for (var i = 0; i < url.length; i++) {
                    var urlparam = url[i].split('=');
                    if (urlparam[0] == param) {
                        return urlparam[1];
                    }
                }
            }

            if (GetParameterValues('id')) {
                $("span[data-target='#editModal']").click();
            }
        });
    </script>
</asp:Content>
