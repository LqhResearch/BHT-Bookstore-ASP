<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bill.aspx.cs" Inherits="WebForm.Bill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hóa đơn</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="/assets/css/style.css" rel="stylesheet" />
    <style>
        .span {
            display: inline-block;
            width: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row py-4 text-center d-flex-center text-primary">
                <p><b>CỬA HÀNG BÁN SÁCH TRỰC TRUYẾN BHT BOOKSTORE</b></p>
                <img src="/assets/img/bht_bookstore_logo.png" alt="Main logo" style="width: 386px; height: 120px;" />
            </div>

            <div class="row py-4 text-center text-primary">
                <h2>HÓA ĐƠN BÁN HÀNG</h2>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <p class="text-success"><b>I. THÔNG TIN ĐƠN HÀNG</b></p>
                    <p>
                        <b>Mã đơn hàng: </b>
                        <asp:Label ID="lblOrderID" runat="server"></asp:Label>
                    </p>
                    <p>
                        <b>Ngày tạo đơn: </b>
                        <asp:Label ID="lblCreatedAt" runat="server"></asp:Label>
                    </p>
                    <p>
                        <b>Ngày thanh toán: </b>
                        <asp:Label ID="lblPaymentDate" runat="server"></asp:Label>
                    </p>
                </div>
                <div class="col-md-6">
                    <p class="text-success"><b>II. THÔNG TIN KHÁCH HÀNG</b></p>
                    <p>
                        <b>Họ tên: </b>
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                    </p>
                    <p>
                        <b>Số điện thoại: </b>
                        <asp:Label ID="lblPhone" runat="server"></asp:Label>
                    </p>
                    <p>
                        <b>Email: </b>
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    </p>
                </div>
            </div>

            <div class="row">
                <p class="text-success"><b>III. CHI TIẾT SẢN PHẨM</b></p>
                <table class="table table-bordered">
                    <thead>
                        <tr class="bg-primary text-white">
                            <th>ISBN</th>
                            <th>Tên sách</th>
                            <th>Giá</th>
                            <th>Số lượng</th>
                            <th>Thành tiền</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <th><%# Eval("ISBN") %></th>
                                    <td><%# Eval("BookTitle") %></td>
                                    <td><%# ObjToVnd(Eval("Price")) %></td>
                                    <td><%# Eval("Amount") %></td>
                                    <td><%# ObjToVnd(Eval("TotalPrice")) %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>

            <div class="row text-end">
                <p>
                    <b>Tổng tiền: </b>
                    <asp:Label ID="lblTotal" runat="server" CssClass="span"></asp:Label>
                </p>
                <p><b>Phí vận chuyển: </b><span class="span">0 ₫</span></p>
                <p>
                    <b>Tổng cộng: </b>
                    <asp:Label ID="lblFinalTotal" runat="server" CssClass="span"></asp:Label>
                </p>
            </div>

            <div class="row d-flex-center">
                <div class="col">
                    <button type="button" class="btn btn-primary print_bill">In hóa đơn</button>
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
    <script>
        document.querySelector(".print_bill").onclick = function () {
            this.style.display = 'none';
            window.print();
        }
    </script>
</body>
</html>
