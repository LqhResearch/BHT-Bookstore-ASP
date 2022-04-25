<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BHT_Bookstore_ASP_NET.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="slider-area">
        <div class="block-slider block-slider4">
            <ul class="" id="bxslider-home4">
                <asp:Repeater ID="rptSliders" runat="server">
                    <ItemTemplate>
                        <li>
                            <img src="<%# Eval("Thumbnail") %>" alt="Slide">
                            <div class="caption-group">
                                <h2 class="caption title"><%# Eval("SliderName") %></h2>
                                <h4 class="caption subtitle"><%# Eval("Description") %></h4>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>

    <div class="promo-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-3 col-sm-6">
                    <div class="single-promo promo1">
                        <i class="fa fa-refresh"></i>
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
                        <p>Thanh toán tín dụng</p>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6">
                    <div class="single-promo promo4">
                        <i class="fa fa-gift"></i>
                        <p>Quà tặng</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End promo area -->

    <div id="books" class="maincontent-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="latest-product">
                        <h2 class="section-title">Sách mới nhất</h2>
                        <div class="product-carousel">
                            <asp:Repeater ID="rptLastestBooks" runat="server">
                                <ItemTemplate>
                                    <div class="single-product">
                                        <div class="product-f-image">
                                            <img src="<%# Eval("Thumbnail") %>" alt="<%# Eval("BookTitle") %>">
                                            <div class="product-hover">
                                                <% if (Convert.ToInt32(Session["user_type"]) == 3)
                                                    { %>
                                                <a href="?cart-isbn=<%# Eval("ISBN") %>" class="add-to-cart-link"><i class="fa fa-shopping-cart"></i>Thêm vào giỏ</a>
                                                <% } %>
                                                <a href="single-product.html" class="view-details-link"><i class="fa fa-link"></i>Thông tin</a>
                                            </div>
                                        </div>
                                        <h2><a href="single-product.html"><%# Eval("BookTitle") %></a></h2>
                                        <div class="product-carousel-price">
                                            <ins><%# Eval("Price") %></ins>
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
</asp:Content>
