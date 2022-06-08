<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="SearchBook.aspx.cs" Inherits="WebForm.SearchBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Tìm kiếm sách</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="single-product-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
            <h3 class="text-center">Danh mục:
                <asp:Label ID="lblKeyword" runat="server"></asp:Label>
            </h3>

            <div class="row">
                <asp:Repeater ID="rptBookList" runat="server">
                    <ItemTemplate>
                        <div class="col-md-3 col-sm-6">
                            <div class="single-shop-product">
                                <div class="product-upper">
                                    <img src="<%# Eval("Thumbnail") %>" alt="<%# Eval("BookTitle") %>" style="height: 300px">
                                </div>
                                <h2><a href="/BookDetails.aspx?isbn=<%# Eval("ISBN") %>"><%# Eval("BookTitle") %></a></h2>
                                <div class="product-carousel-price">
                                    <ins><%# ObjToVnd(Eval("Price")) %></ins>
                                </div>

                                <% if (Convert.ToInt32(Session["Role"]) == 3)
                                    { %>
                                <div class="product-option-shop">
                                    <a class="add_to_cart_button" data-quantity="1" data-product_sku="" data-product_id="70" rel="nofollow" href="/Cart.aspx?isbn=<%# Eval("ISBN") %>">Thêm vào giỏ</a>
                                </div>
                                <% } %>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
