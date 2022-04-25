<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="BHT_Bookstore_ASP_NET.admin.books.list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Sách</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1 class="m-0">Sách</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="/admin/dashboard/Default.aspx"><i class="fas fa-home"></i></a></li>
                            <li class="breadcrumb-item active">Sách</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal: Add -->
        <div class="modal fade" id="addModal" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog modal-dialog-scrollable" role="document" style="max-width: 800px">
                <div class="modal-content">
                    <div class="modal-header bg-primary">
                        <h5 class="modal-title">Thêm sách</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-6 form-group">
                                <label>Mã sách</label>
                                <asp:TextBox ID="txtID_Add" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Tên sách</label>
                                <asp:TextBox ID="txtName_Add" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Mô tả</label>
                                <asp:TextBox ID="txtDescription_Add" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Năm xuất bản</label>
                                <asp:DropDownList ID="ddlPublishYear_Add" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="2018" Text="2018"></asp:ListItem>
                                    <asp:ListItem Value="2019" Text="2019"></asp:ListItem>
                                    <asp:ListItem Value="2020" Text="2020"></asp:ListItem>
                                    <asp:ListItem Value="2021" Text="2021"></asp:ListItem>
                                    <asp:ListItem Value="2022" Text="2022"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Trọng lượng</label>
                                <div class="input-group">
                                    <asp:TextBox ID="txtWeight_Add" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                    <div class="input-group-append">
                                        <span class="input-group-text">gam</span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Kích thước</label>
                                <div class="input-group">
                                    <asp:TextBox ID="txtSizeWidth_Add" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                    <div class="input-group-append">
                                        <span class="input-group-text">x</span>
                                    </div>
                                    <asp:TextBox ID="txtSizeHeight_Add" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                    <div class="input-group-append">
                                        <span class="input-group-text">mm</span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Số trang</label>
                                <asp:TextBox ID="txtPageNumber_Add" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Ngôn ngữ</label>
                                <asp:DropDownList ID="ddlLanguageID_Add" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Giá bán</label>
                                <asp:TextBox ID="txtSalePrice_Add" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Danh mục</label>
                                <asp:DropDownList ID="ddlCategoryID_Add" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Nhà xuất bản</label>
                                <asp:DropDownList ID="ddlPublishID_Add" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Hình ảnh</label>
                                <asp:FileUpload ID="fThumbnail_Add" CssClass="form-control" runat="server"></asp:FileUpload>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Huỷ</button>
                        <asp:Button ID="btnSubmit_Add" CssClass="btn btn-primary" runat="server" Text="Thêm" OnClick="btnSubmit_Add_Click" />
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal: Edit -->
        <div class="modal fade" id="editModal" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog modal-dialog-scrollable" role="document" style="max-width: 800px">
                <div class="modal-content">
                    <div class="modal-header bg-primary">
                        <h5 class="modal-title">Sửa sách</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-6 form-group">
                                <label>Mã sách</label>
                                <asp:TextBox ID="txtID_Edit" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Tên sách</label>
                                <asp:TextBox ID="txtName_Edit" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Mô tả</label>
                                <asp:TextBox ID="txtDescription_Edit" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Năm xuất bản</label>
                                <asp:DropDownList ID="ddlPublishYear_Edit" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="2018" Text="2018"></asp:ListItem>
                                    <asp:ListItem Value="2019" Text="2019"></asp:ListItem>
                                    <asp:ListItem Value="2020" Text="2020"></asp:ListItem>
                                    <asp:ListItem Value="2021" Text="2021"></asp:ListItem>
                                    <asp:ListItem Value="2022" Text="2022"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Trọng lượng</label>
                                <div class="input-group">
                                    <asp:TextBox ID="txtWeight_Edit" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                    <div class="input-group-append">
                                        <span class="input-group-text">gam</span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Kích thước</label>
                                <div class="input-group">
                                    <asp:TextBox ID="txtSizeWidth_Edit" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                    <div class="input-group-append">
                                        <span class="input-group-text">x</span>
                                    </div>
                                    <asp:TextBox ID="txtSizeHeight_Edit" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                    <div class="input-group-append">
                                        <span class="input-group-text">mm</span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Số trang</label>
                                <asp:TextBox ID="txtPageNumber_Edit" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Ngôn ngữ</label>
                                <asp:DropDownList ID="ddlLanguageID_Edit" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Giá bán</label>
                                <asp:TextBox ID="txtSalePrice_Edit" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Danh mục</label>
                                <asp:DropDownList ID="ddlCategoryID_Edit" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Nhà xuất bản</label>
                                <asp:DropDownList ID="ddlPublishID_Edit" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Hình ảnh</label>
                                <asp:FileUpload ID="fThumbnail_Edit" CssClass="form-control" runat="server"></asp:FileUpload>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Huỷ</button>
                        <asp:Button ID="btnSubmit_Edit" CssClass="btn btn-primary" runat="server" Text="Sửa" OnClick="btnSubmit_Edit_Click" />
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
                                <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="🍳" OnClick="btnSearch_Click" />
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
                            <th>Mã sách</th>
                            <th>Tên sách</th>
                            <th>Mô tả</th>
                            <th>Hình ảnh</th>
                            <th>Giá bán</th>
                            <th>Thể loại</th>
                            <th>Nhà xuất bản</th>
                            <th width="158">Công cụ</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("ISBN") %></td>
                                    <td><%# Eval("BookTitle") %></td>
                                    <td><%# Eval("Description") %></td>
                                    <td><%# "<img height='50' src='" + Eval("Thumbnail") + "' alt='' />" %></td>
                                    <td><%# Eval("Price") %></td>
                                    <td><%# Eval("CategoryName") %></td>
                                    <td><%# Eval("PublishName") %></td>
                                    <td>
                                        <asp:HyperLink ID="hplShowBook" CssClass="btn btn-info" NavigateUrl='<%# "info.aspx?show-id=" + Eval("ISBN") %>' runat="server"><i class="fas fa-eye"></i></asp:HyperLink>
                                        <span data-toggle="modal" data-target="#editModal">
                                            <asp:HyperLink ID="hplEdit" CssClass="btn btn-warning" NavigateUrl='<%# "?id=" + Eval("ISBN") %>' runat="server"><i class="fas fa-marker"></i></asp:HyperLink>
                                        </span>
                                        <asp:HyperLink ID="hplDelete" CssClass="btn btn-danger" NavigateUrl='<%# "?del-id=" + Eval("ISBN") %>' runat="server"><i class="fas fa-trash"></i></asp:HyperLink>
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
