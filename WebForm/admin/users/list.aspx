<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="WebForm.admin.users.list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Tài khoản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1>Tài khoản</h1>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="/admin/dashboard/Default.aspx"><i class="fas fa-home"></i></a></li>
                        <li class="breadcrumb-item active">Tài khoản</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>

    <!-- Modal: Edit -->
    <div class="modal fade" id="modal-edit">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title">Cập nhật tài khoản</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Tên đăng nhập</label>
                        <asp:TextBox ID="txtID_Edit" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Trạng thái</label>
                        <asp:DropDownList ID="ddlStatus_Edit" CssClass="form-control" runat="server">
                            <asp:ListItem Value="1">Hoạt động</asp:ListItem>
                            <asp:ListItem Value="0">Khóa</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Loại tài khoản</label>
                        <asp:DropDownList ID="ddlAccountTypeID_Edit" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="modal-footer justify-content-between">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Huỷ</button>
                    <asp:Button ID="btnEdit" CssClass="btn btn-success" runat="server" Text="Cập nhật" OnClick="btnEdit_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal: Edit -->
    <div class="modal fade" id="modal-coins">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title">Nạp tiền</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Tên đăng nhập</label>
                        <asp:TextBox ID="txtID_Money" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Số tiền</label>
                        <asp:TextBox ID="txtValue_Money" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer justify-content-between">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Huỷ</button>
                    <asp:Button ID="btnMoney" CssClass="btn btn-success" runat="server" Text="Cập nhật" OnClick="btnMoney_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Main content -->
    <section class="content">
        <div class="container-fluid row">
            <div class="col-lg-3 col-6">
                <div class="small-box bg-success">
                    <div class="inner">
                        <h3>
                            <asp:Label ID="lblCountAll" runat="server"></asp:Label>
                        </h3>
                        <p>Tài khoản</p>
                    </div>
                    <div class="icon">
                        <i class="fas fa-user-circle"></i>
                    </div>
                    <a href="#" class="small-box-footer">Xem chi tiết <i class="fas fa-arrow-circle-right"></i>
                    </a>
                </div>
            </div>
            <div class="col-lg-3 col-6">
                <div class="small-box bg-warning">
                    <div class="inner">
                        <h3>
                            <asp:Label ID="lblCountAdmin" runat="server"></asp:Label>
                        </h3>
                        <p>Quản trị viên</p>
                    </div>
                    <div class="icon">
                        <i class="fas fa-user-shield"></i>
                    </div>
                    <a href="#" class="small-box-footer">Xem chi tiết <i class="fas fa-arrow-circle-right"></i>
                    </a>
                </div>
            </div>
            <div class="col-lg-3 col-6">
                <div class="small-box bg-info">
                    <div class="inner">
                        <h3>
                            <asp:Label ID="lblCountCustomer" runat="server"></asp:Label>
                        </h3>
                        <p>Khách hàng</p>
                    </div>
                    <div class="icon">
                        <i class="fas fa-user-alt"></i>
                    </div>
                    <a href="#" class="small-box-footer">Xem chi tiết <i class="fas fa-arrow-circle-right"></i>
                    </a>
                </div>
            </div>
            <div class="col-lg-3 col-6">
                <div class="small-box bg-danger">
                    <div class="inner">
                        <h3>
                            <asp:Label ID="lblCountActive" runat="server"></asp:Label>
                        </h3>
                        <p>Tài khoản đang hoạt động</p>
                    </div>
                    <div class="icon">
                        <i class="fas fa-unlock"></i>
                    </div>
                    <a href="#" class="small-box-footer">Xem chi tiết <i class="fas fa-arrow-circle-right"></i>
                    </a>
                </div>
            </div>
        </div>

        <!-- Message box -->
        <div class="container-fluid">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>

        <!-- Tools -->
        <div class="container-fluid">
            <div class="clear-fix">
                <div class="float-right d-flex my-3">
                    <!-- Search data -->
                    <div class="input-group">
                        <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server"></asp:TextBox>
                        <div class="input-group-append">
                            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="Tìm" OnClick="btnSearch_Click" />
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
                        <th>Tên đăng nhập</th>
                        <th>Họ tên</th>
                        <th>Số điện thoại</th>
                        <th>Email</th>
                        <th>Số tiền</th>
                        <th>Ảnh đại diện</th>
                        <th>Trạng thái</th>
                        <th>Loại tài khoản</th>
                        <th width="157">Công cụ</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <th><%# Eval("Username") %></th>
                                <td><%# Eval("Fullname") %></td>
                                <td><a class="text-dark" href="tel:<%# Eval("Phone") %>"><%# Eval("Phone") %></a></td>
                                <td><a class="text-dark" href="mailto:<%# Eval("Email") %>"><%# Eval("Email") %></a></td>
                                <td><%# ObjToVnd(Eval("Money")) %></td>
                                <td class="text-center"><a href="<%# Eval("Avatar") %>" target="_blank">
                                    <img width="50" height="50" src="<%# Eval("Avatar") %>" alt="" style="border-radius: 50%;" /></a></td>
                                <td><%# (Convert.ToInt32(Eval("Status")) == 1) ? "<span class='badge badge-success'>Có</span>" : "<span class='badge badge-danger'>Không</span>" %></td>
                                <td><span class='badge badge-info'><%# Eval("AccountTypeName") %></span></td>
                                <td>
                                    <span data-toggle="modal" data-target="#modal-coins">
                                        <a href="?coin-id=<%# Eval("Username") %>" class="btn btn-info"><i class="fas fa-coins"></i></a>
                                    </span>
                                    <span data-toggle="modal" data-target="#modal-edit">
                                        <a href="?edit-id=<%# Eval("Username") %>" class="btn btn-warning"><i class="fas fa-marker"></i></a>
                                    </span>
                                    <a href="?del-id=<%# Eval("Username") %>" class="btn btn-danger"><i class="fas fa-trash-alt"></i></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Label ID="lblNoData" runat="server" Text=""></asp:Label>
                </tbody>
            </table>
        </div>

        <!-- Pagination -->
        <asp:Label ID="lblPaginationDisable" CssClass="" runat="server" Text="">
            <div class="container-fluid d-flex align-content-center justify-content-between">
                <div>Hiển thị từ <%=pager["Startpage"] %> đến <%=pager["EndPage"] %> của <%=pager["TotalItems"] %> dòng</div>
                <ul class="pagination">
                    <% for (int i = 1; i <= Convert.ToInt32(pager["TotalPages"]); i++)
                        {%>
                    <li class="page-item <%=Convert.ToInt32(pager["CurrentPage"]) == i ? "active" : "" %>">
                        <a class="page-link" href="?page=<%=i %>"><%=i %></a>
                    </li>
                    <% } %>
                </ul>
            </div>
        </asp:Label>
    </section>

    <!-- jQuery -->
    <script src="/vendor/adminlte/plugins/jquery/jquery.min.js"></script>

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

            if (GetParameterValues('edit-id')) {
                $("span[data-target='#modal-edit']")[0].click();
            }

            if (GetParameterValues('coin-id')) {
                $("span[data-target='#modal-coins']")[0].click();
            }
        });
    </script>
</asp:Content>
