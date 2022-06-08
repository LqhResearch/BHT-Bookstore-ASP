<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="WebForm.admin.publishes.list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Nhà xuất bản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1>Nhà xuất bản</h1>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="/admin/dashboard/Default.aspx"><i class="fas fa-home"></i></a></li>
                        <li class="breadcrumb-item active">Nhà xuất bản</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>

    <!-- Modal: Add -->
    <div class="modal fade" id="modal-add">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title">Thêm nhà xuất bản</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Tên nhà xuất bản</label>
                        <asp:TextBox ID="txtName_Add" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Số điện thoại</label>
                        <asp:TextBox ID="txtPhone_Add" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Địa chỉ</label>
                        <asp:TextBox ID="txtAddress_Add" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Số fax</label>
                        <asp:TextBox ID="txtFax_Add" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer justify-content-between">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Huỷ</button>
                    <asp:Button ID="btnAdd" CssClass="btn btn-success" runat="server" Text="Thêm" OnClick="btnAdd_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal: Add -->
    <div class="modal fade" id="modal-edit">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title">Cập nhật nhà xuất bản</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Mã nhà xuất bản</label>
                        <asp:TextBox ID="txtID_Edit" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Tên nhà xuất bản</label>
                        <asp:TextBox ID="txtName_Edit" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Số điện thoại</label>
                        <asp:TextBox ID="txtPhone_Edit" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Địa chỉ</label>
                        <asp:TextBox ID="txtAddress_Edit" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Số fax</label>
                        <asp:TextBox ID="txtFax_Edit" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer justify-content-between">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Huỷ</button>
                    <asp:Button ID="btnEdit" CssClass="btn btn-success" runat="server" Text="Cập nhật" OnClick="btnEdit_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Main content -->
    <section class="content">
        <div class="container-fluid row">
            <div class="col-lg-3 col-6">
                <div class="small-box bg-info">
                    <div class="inner">
                        <h3>
                            <asp:Label ID="lblCountAll" runat="server"></asp:Label>
                        </h3>
                        <p>Nhà xuất bản</p>
                    </div>
                    <div class="icon">
                        <i class="fas fa-print"></i>
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
                    <!-- Add button -->
                    <button type="button" class="btn btn-success mx-3" data-toggle="modal" data-target="#modal-add">
                        <i class="fas fa-plus"></i>
                    </button>

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
                        <th>Mã nhà xuất bản</th>
                        <th>Tên nhà xuất bản</th>
                        <th>Số điện thoại</th>
                        <th>Địa chỉ</th>
                        <th>Số fax</th>
                        <th width="112">Công cụ</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <th><%# Eval("PublishID") %></th>
                                <td><%# Eval("PublishName") %></td>
                                <td><%# Eval("Phone") %></td>
                                <td><%# Eval("Address") %></td>
                                <td><%# Eval("Fax") %></td>
                                <td>
                                    <span data-toggle="modal" data-target="#modal-edit">
                                        <a href="?edit-id=<%# Eval("PublishID") %>" class="btn btn-warning"><i class="fas fa-marker"></i></a>
                                    </span>
                                    <a href="?del-id=<%# Eval("PublishID") %>" class="btn btn-danger"><i class="fas fa-trash-alt"></i></a>
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
                console.log($("span[data-target='#editModal']")[0]);
                $("span[data-target='#modal-edit']")[0].click();
            }
        });
    </script>
</asp:Content>
