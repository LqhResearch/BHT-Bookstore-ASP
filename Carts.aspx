<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="Carts.aspx.cs" Inherits="BHT_Bookstore_ASP_NET.Carts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Giỏ hàng</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product-big-title-area">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="product-bit-title text-center">
                        <h2>Giỏ hàng của bạn</h2>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End Page title area -->

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ...
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>

    <div class="single-product-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="product-content-right">
                        <div class="woocommerce">
                            <table cellspacing="0" class="shop_table cart">
                                <thead>
                                    <tr>
                                        <th class="product-thumbnail">&nbsp;</th>
                                        <th class="product-name">Tên sản phẩm</th>
                                        <th class="product-price">Giá</th>
                                        <th class="product-quantity">Số lượng</th>
                                        <th class="product-subtotal">Thành tiền</th>
                                        <th class="product-remove">&nbsp;</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptCarts" runat="server">
                                        <ItemTemplate>
                                            <tr class="cart_item">
                                                <td class="product-thumbnail">
                                                    <a href="single-product.html">
                                                        <img width="145" height="145" alt="poster_1_up" class="shop_thumbnail" src="<%# Eval("Thumbnail") %>">
                                                    </a>
                                                </td>
                                                <td class="product-name">
                                                    <a href="single-product.html"><%# Eval("BookTitle") %></a>
                                                </td>
                                                <td class="product-price">
                                                    <span class="amount"><%# Eval("Price") %></span>
                                                </td>
                                                <td class="product-quantity">
                                                    <form method="get" action="#">
                                                        <div class="quantity buttons_added">
                                                            <span class="amount"><%# Eval("Amount") %></span>
                                                        </div>
                                                    </form>
                                                </td>
                                                <td class="product-subtotal">
                                                    <span class="amount"><%# Convert.ToInt32(Eval("Price")) * Convert.ToInt32(Eval("Amount")) %></span>
                                                </td>
                                                <td class="product-remove">
                                                    <a title="Sửa số lượng" class="remove" href="/QuantityCart.aspx?cart-id=<%# Eval("CartsISBN") %>">Số lượng</a>
                                                    <a title="Remove this item" class="remove" href="?del-cart-id=<%# Eval("CartsISBN") %>">×</a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr>
                                        <td class="actions" colspan="6">
                                            <div class="coupon">
                                                <label for="coupon_code">Mã giảm giá:</label>
                                                <input type="text" id="coupon_code" class="input-text" name="coupon_code">
                                                <input type="submit" value="Xác nhận" name="apply_coupon" class="button">
                                            </div>
                                            <asp:Button ID="btnPayment" CssClass="checkout-button button alt wc-forward" runat="server" Text="Tạo đơn hàng" OnClick="btnPayment_Click" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                            <div class="cart-collaterals">
                                <div class="cart_totals ">
                                    <h2>Tổng tiền giỏ hàng</h2>
                                    <table cellspacing="0">
                                        <tbody>
                                            <tr class="cart-subtotal">
                                                <th>Tổng tiền sản phẩm</th>
                                                <td><span class="amount"><%=TotalMoneyCarts(Session["username"]) %></span></td>
                                            </tr>

                                            <tr class="shipping">
                                                <th>Phí vận chuyển</th>
                                                <td>Free Shipping</td>
                                            </tr>

                                            <tr class="order-total">
                                                <th>Tổng tiền thanh toán</th>
                                                <td><strong><span class="amount"><%=TotalMoneyCarts(Session["username"]) %></span></strong> </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        var updateAmount = document.getElementsByClassName("cart-amount-value");

        updateAmount.forEach(function (e) {
            this.addEventListener('change', (e) => {
                console.log("Hhahha");
            });
        });
    </script>
</asp:Content>
