<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="WebForm.MyOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Đơn hàng của tôi</title>

    <style>
        .my_money {
            font-size: 16px;
            padding: 1rem 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product-big-title-area">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="product-bit-title text-center">
                        <h2>Đơn hàng của tôi</h2>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="single-product-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>

            <p class="my_money">
                <i class="fas fa-money-bill-alt"></i>
                <asp:Label ID="lblMyMoney" runat="server"></asp:Label>
            </p>

            <table class="table">
                <thead>
                    <tr class="bg-primary">
                        <th>Mã đơn hàng</th>
                        <th>Tổng đơn hàng</th>
                        <th>Tiền thanh toán</th>
                        <th>Trạng thái</th>
                        <th>Ngày thanh toán</th>
                        <th>Ngày tạo đơn</th>
                        <th width="217"></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <th><%# Eval("OrderID") %></th>
                                <td><%# ObjToVnd(Eval("TotalMoney")) %></td>
                                <td><%# ObjToVnd(Eval("TotalRevenue")) %></td>
                                <td><%# Convert.ToInt32(Eval("Status")) == 1 ? "<span class='badge alert-success'>Đã giao</span>" : "<span class='badge alert-warning'>Chưa giao</span>" %></td>
                                <td><%# FormatDate(Eval("PaymentDate")) %></td>
                                <td><%# FormatDate(Eval("CreatedAt")) %></td>
                                <td>
                                    <a href="/Bill.aspx?order-id=<%# Eval("OrderID") %>" class="btn btn-info">Xem chi tiết</a>
                                    <%# Convert.ToInt32(Eval("Status")) != 1 ? "<a href='?order-id="+ Eval("OrderID") +"&pay=1' class='btn btn-success'>Thanh toán</a>" : "" %>;
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
