<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Trang chủ</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="slider-area">
        <div class="block-slider block-slider4">
            <ul class="" id="bxslider-home4">
                <asp:Repeater ID="rptSlider" runat="server">
                    <ItemTemplate>
                        <li>
                            <img src="<%# Eval("Thumbnail") %>" alt="Slide">
                            <div class="caption-group">
                                <h2 class="caption title"><%# Eval("SliderName") %></span></h2>
                                <h4 class="caption subtitle"><%# Eval("Description") %></h4>
                                <a class="caption button-radius" href="#"><span class="icon"></span>Mua ngay</a>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <!-- End slider area -->

    <div class="promo-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-3 col-sm-6">
                    <div class="single-promo promo1">
                        <i class="fas fa-sync-alt"></i>
                        <p>30 ngày hoàn trả</p>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6">
                    <div class="single-promo promo2">
                        <i class="fa fa-truck"></i>
                        <p>Miễn phí vận chuyển</p>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6">
                    <div class="single-promo promo3">
                        <i class="fa fa-lock"></i>
                        <p>Thanh toán an toàn</p>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6">
                    <div class="single-promo promo4">
                        <i class="fa fa-gift"></i>
                        <p>Ưu đãi khuyến mãi</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End promo area -->

    <div class="maincontent-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="latest-product">
                        <h2 class="section-title">Sản phẩm mới nhất</h2>
                        <div class="product-carousel">
                            <asp:Repeater ID="rptLastedProduct" runat="server">
                                <ItemTemplate>
                                    <div class="single-product">
                                        <div class="product-f-image">
                                            <img src="<%# Eval("Thumbnail") %>" alt="<%# Eval("BookTitle") %>" style="height: 300px;">
                                            <div class="product-hover">
                                                <% if (Convert.ToInt32(Session["Role"]) == 3)
                                                    { %>
                                                <a href="/Cart.aspx?isbn=<%# Eval("ISBN") %>" class="add-to-cart-link"><i class="fas fa-cart-plus"></i>Thêm vào giỏ</a>
                                                <% } %>
                                                <a href="/BookDetails.aspx?isbn=<%# Eval("ISBN") %>" class="view-details-link"><i class="fa fa-link"></i>Chi tiết sách</a>
                                            </div>
                                        </div>
                                        <h2><a href="/BookDetails.aspx?isbn=<%# Eval("ISBN") %>"><%# Eval("BookTitle") %></a></h2>
                                        <div class="product-carousel-price">
                                            <ins><%# ObjToVnd(Eval("Price")) %></ins>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End main content area -->

    <div class="product-widget-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-4">
                    <div class="single-product-widget">
                        <h2 class="product-wid-title">Bán chạy nhất</h2>
                        <a href="#" class="wid-view-more">Xem tất cả</a>
                        <asp:Repeater ID="rptTopSellers" runat="server">
                            <ItemTemplate>
                                <div class="single-wid-product">
                                    <a href="#">
                                        <img src="<%# Eval("Thumbnail") %>" alt="<%# Eval("BookTitle") %>" class="product-thumb">
                                    </a>
                                    <h2><a href="/BookDetails.aspx?isbn=<%# Eval("ISBN") %>"><%# Eval("BookTitle") %></a></h2>
                                    <div class="product-wid-rating">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                    </div>
                                    <div class="product-wid-price">
                                        <ins><%# ObjToVnd(Eval("Price")) %></ins>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="single-product-widget">
                        <h2 class="product-wid-title">Đã xem gần đây</h2>
                        <a href="#" class="wid-view-more">Xem tất cả</a>
                        <asp:Repeater ID="rptRecentlyViewed" runat="server">
                            <ItemTemplate>
                                <div class="single-wid-product">
                                    <a href="#">
                                        <img src="<%# Eval("Thumbnail") %>" alt="<%# Eval("BookTitle") %>" class="product-thumb">
                                    </a>
                                    <h2><a href="/BookDetails.aspx?isbn=<%# Eval("ISBN") %>"><%# Eval("BookTitle") %></a></h2>
                                    <div class="product-wid-rating">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                    </div>
                                    <div class="product-wid-price">
                                        <ins><%# ObjToVnd(Eval("Price")) %></ins>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="single-product-widget">
                        <h2 class="product-wid-title">sách hàng đầu</h2>
                        <a href="#" class="wid-view-more">Xem tất cả</a>
                        <asp:Repeater ID="rptTopNew" runat="server">
                            <ItemTemplate>
                                <div class="single-wid-product">
                                    <a href="#">
                                        <img src="<%# Eval("Thumbnail") %>" alt="<%# Eval("BookTitle") %>" class="product-thumb">
                                    </a>
                                    <h2><a href="/BookDetails.aspx?isbn=<%# Eval("ISBN") %>"><%# Eval("BookTitle") %></a></h2>
                                    <div class="product-wid-rating">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                    </div>
                                    <div class="product-wid-price">
                                        <ins><%# ObjToVnd(Eval("Price")) %></ins>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End product widget area -->
</asp:Content>
