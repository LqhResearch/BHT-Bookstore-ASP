<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebForm.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Giỏ hàng</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product-big-title-area">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="product-bit-title text-center">
                        <h2>Giỏ hàng của tôi</h2>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="single-product-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <div class="row">
                <div class="col-md-12">
                    <div class="product-content-right">
                        <div class="woocommerce">
                            <div>
                                <table cellspacing="0" class="shop_table cart">
                                    <thead>
                                        <tr>
                                            <th class="product-thumbnail">ISBN</th>
                                            <th class="product-name">Sản phẩm</th>
                                            <th class="product-thumbnail">Ảnh</th>
                                            <th class="product-price">Giá</th>
                                            <th class="product-quantity">Số lượng</th>
                                            <th class="product-subtotal">Tổng cộng</th>
                                            <th class="product-remove">&nbsp;</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptCart" runat="server">
                                            <ItemTemplate>
                                                <tr class="cart_item">
                                                    <td class="product-name"><%# Eval("ISBN") %></td>
                                                    <td class="product-name"><%# Eval("BookTitle") %></td>
                                                    <td class="product-thumbnail">
                                                        <a href="<%# Eval("Thumbnail") %>" target="_blank">
                                                            <img width="145" height="145" alt="" class="shop_thumbnail" src="<%# Eval("Thumbnail") %>">
                                                        </a>
                                                    </td>
                                                    <td class="product-name"><%# ObjToVnd(Eval("Price")) %></td>
                                                    <td class="product-name">
                                                        <input min="1" type="number" value="<%# Eval("Amount") %>" style="width: 60px;" />
                                                        <button type="button" class="btn btn-quanlity" onclick="update_quanlity(<%# Eval("ISBN") %>, this)"><i class="fas fa-save"></i></button>
                                                    </td>
                                                    <td class="product-name"><%# ObjToVnd(Eval("Total")) %></td>
                                                    <td class="product-name"><a style="color: #fff;" class="btn btn-danger" href="?del-isbn=<%# Eval("ISBN") %>"><i class="fas fa-times"></i></a></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                            <td class="actions" colspan="6">
                                                <div class="coupon">
                                                    <label for="coupon_code">Khuyến mãi :</label>
                                                    <input type="text" placeholder="XXX-XXX" value="" id="coupon_code" class="input-text" name="coupon_code">
                                                    <input type="submit" value="Xác nhận" name="apply_coupon" class="button">
                                                </div>
                                                <asp:Button ID="btnCreateOrder" runat="server" Text="Tạo đơn hàng" OnClick="btnCreateOrder_Click" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                            <div class="cart-collaterals">
                                <div class="cart_totals ">
                                    <h2>Tổng cộng giỏ hàng</h2>
                                    <table cellspacing="0">
                                        <tbody>
                                            <tr class="cart-subtotal">
                                                <th>Tổng tiền sách: </th>
                                                <td><span class="amount"><%=totalOrder %></span></td>
                                            </tr>

                                            <tr class="shipping">
                                                <th>Phí vận chuyển: </th>
                                                <td>Miễn phí</td>
                                            </tr>

                                            <tr class="order-total">
                                                <th>Tổng cộng: </th>
                                                <td><strong><span class="amount"><%=totalOrder %></span></strong> </td>
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
        function update_quanlity(isbn, _this) {
            var amount = _this.parentElement.querySelector("input").value;
            location.href = location.protocol + "//" + location.host + "/Cart.aspx?action=update_quanlity&isbn=" + isbn + "&amount=" + amount;
        }
    </script>
</asp:Content>
