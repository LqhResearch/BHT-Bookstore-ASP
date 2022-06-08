<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="WebForm.admin.books.list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Kho sách</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1>Kho sách</h1>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="/admin/dashboard/Default.aspx"><i class="fas fa-home"></i></a></li>
                        <li class="breadcrumb-item active">Sách</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>

    <!-- Modal: Add -->
    <div class="modal fade" id="modal-add">
        <div class="modal-dialog" style="max-width: 800px">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title">Thêm sách</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="form-group col-md-6">
                            <label>ISBN</label>
                            <asp:TextBox ID="txtISBN_Add" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Tiêu đề</label>
                            <asp:TextBox ID="txtName_Add" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Mô tả: </label>
                            <asp:TextBox ID="txtDesc_Add" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Năm sản xuất: </label>
                            <asp:TextBox ID="txtPublishYear_Add" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Trọng lượng: </label>
                            <asp:TextBox ID="txtWeight_Add" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Kích thước: </label>
                            <div class="input-group mb-3">
                                <asp:TextBox ID="txtSize_Width_Add" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="input-group-text">x</span>
                                </div>
                                <asp:TextBox ID="txtSize_Height_Add" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="input-group-text">mm</span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Số trang: </label>
                            <asp:TextBox ID="txtPageNumber_Add" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Ảnh: </label>
                            <asp:FileUpload ID="fThumbnail_Add" CssClass="form-control" runat="server"></asp:FileUpload>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Ngôn ngữ: </label>
                            <asp:DropDownList ID="ddlLanguageID_Add" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Giá: </label>
                            <asp:TextBox ID="txtPrice_Add" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Thể loại: </label>
                            <asp:DropDownList ID="ddlCategoryID_Add" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Nhà xuất bản: </label>
                            <asp:DropDownList ID="ddlPublishID_Add" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="modal-footer justify-content-between">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Huỷ</button>
                    <asp:Button ID="btnAdd" CssClass="btn btn-success" runat="server" Text="Thêm" OnClick="btnAdd_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal: Edit -->
    <div class="modal fade" id="modal-edit">
        <div class="modal-dialog" style="max-width: 800px">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title">Cập nhật tác giả</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="form-group col-md-6">
                            <label>ISBN</label>
                            <asp:TextBox ID="txtISBN_Edit" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Tiêu đề</label>
                            <asp:TextBox ID="txtName_Edit" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Mô tả: </label>
                            <asp:TextBox ID="txtDesc_Edit" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Năm sản xuất: </label>
                            <asp:TextBox ID="txtPublishYear_Edit" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Trọng lượng: </label>
                            <asp:TextBox ID="txtWeight_Edit" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Kích thước: </label>
                            <div class="input-group mb-3">
                                <asp:TextBox ID="txtSize_Width_Edit" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="input-group-text">x</span>
                                </div>
                                <asp:TextBox ID="txtSize_Height_Edit" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="input-group-text">mm</span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Số trang: </label>
                            <asp:TextBox ID="txtPageNumber_Edit" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Ảnh: </label>
                            <asp:FileUpload ID="fThumbnail_Edit" CssClass="form-control" runat="server"></asp:FileUpload>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Ngôn ngữ: </label>
                            <asp:DropDownList ID="ddlLanguageID_Edit" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Giá: </label>
                            <asp:TextBox ID="txtPrice_Edit" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Thể loại: </label>
                            <asp:DropDownList ID="ddlCategoryID_Edit" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Nhà xuất bản: </label>
                            <asp:DropDownList ID="ddlPublishID_Edit" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
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
                        <p>Số lượng sách</p>
                    </div>
                    <div class="icon">
                        <i class="fas fa-book"></i>
                    </div>
                    <a href="/admin/books/list.aspx" class="small-box-footer">Xem chi tiết <i class="fas fa-arrow-circle-right"></i>
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
                        <th>ISBN</th>
                        <th>Tên sách</th>
                        <th>Ảnh</th>
                        <th>Giá</th>
                        <th>Danh mục</th>
                        <th>Nhà xuất bản</th>
                        <th width="159">Công cụ</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <th><%# Eval("ISBN") %></th>
                                <td><%# Eval("BookTitle") %></td>
                                <td class="text-center"><a href="<%# Eval("Thumbnail") %>" target="_blank">
                                    <img src="<%# Eval("Thumbnail") %>" alt="" height="50" /></a></td>
                                <td><%# ObjToVnd(Eval("Price")) %></td>
                                <td><%# Eval("CategoryName") %></td>
                                <td><%# Eval("PublishName") %></td>
                                <td>
                                    <a href="/BookDetails.aspx?isbn=<%# Eval("ISBN") %>" target="_blank" class="btn btn-info"><i class="fas fa-eye"></i></a>
                                    <span data-toggle="modal" data-target="#modal-edit">
                                        <a href="?edit-id=<%# Eval("ISBN") %>" class="btn btn-warning"><i class="fas fa-marker"></i></a>
                                    </span>
                                    <a href="?del-id=<%# Eval("ISBN") %>" class="btn btn-danger"><i class="fas fa-trash-alt"></i></a>
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
