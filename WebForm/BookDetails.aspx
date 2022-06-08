<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="WebForm.BookDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Toolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Chi tiết sách</title>

    <style>
        .green {
            color: #5FD068;
        }

        .yellow {
            color: #F9D923;
        }

        .black {
            color: #000000;
        }

        .my-3 {
            margin: 1rem 0;
        }

        .starRating {
            font-size: 16px;
            padding: 1rem 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 class="text-center" style="padding-top: 32px;">Chi tiết sản phẩm</h2>
        <div class="d-flex p-3">
            <div class="p-3" style="width: 300px;">
                <asp:Image ID="img" runat="server" />
            </div>
            <div class="p-3">
                <p>
                    <b>ISBN: </b>
                    <asp:Label ID="lblISBN" runat="server"></asp:Label>
                </p>
                <p>
                    <b>Tên sách: </b>
                    <asp:Label ID="lblBookTitle" runat="server"></asp:Label>
                </p>
                <p>
                    <b>Năm xuất bản: </b>
                    <asp:Label ID="lblPublishYear" runat="server"></asp:Label>
                </p>
                <p>
                    <b>Trọng lượng: </b>
                    <asp:Label ID="lblWeight" runat="server"></asp:Label>
                </p>
                <p>
                    <b>Kích thước: </b>
                    <asp:Label ID="lblSize" runat="server"></asp:Label>
                </p>
                <p>
                    <b>Số trang: </b>
                    <asp:Label ID="lblPageNumber" runat="server"></asp:Label>
                </p>
                <p>
                    <b>Giá: </b>
                    <asp:Label ID="lblPrice" runat="server"></asp:Label>
                </p>
                <p>
                    <b>Ngôn ngữ: </b>
                    <asp:Label ID="lblLanguage" runat="server"></asp:Label>
                </p>
                <p>
                    <b>Danh mục: </b>
                    <asp:Label ID="lblCategory" runat="server"></asp:Label>
                </p>
                <p>
                    <b>Nhà xuất bản: </b>
                    <asp:Label ID="lblPublish" runat="server"></asp:Label>
                </p>
                <p>
                    <b>Mô tả: </b>
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                </p>
            </div>
        </div>

        <asp:Repeater ID="rptComment" runat="server">
            <ItemTemplate>
                <div class="d-flex">
                    <div style="width: 200px;">
                        <b><%# Eval("Fullname") %></b>
                        <p><%# FormatDate(Eval("CreatedAt")) %></p>
                    </div>
                    <div>
                        <p><%# RatingStar(Eval("Point")) %></p>
                        <p><%# Eval("Description") %></p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <h2 class="text-center" style="padding-top: 32px;">Bình luận</h2>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" CssClass="form-control" runat="server">
            <ContentTemplate>
                <Toolkit:Rating ID="Rating1" runat="server"
                    StarCssClass="starRating"
                    FilledStarCssClass="fas fa-star yellow"
                    EmptyStarCssClass="fas fa-star txt-primary"
                    WaitingStarCssClass="fas fa-star black"
                    CurrentRating="0"
                    MaxRating="5" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="my-3">
            <asp:TextBox ID="txtComment" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:Button ID="btnCommentSubmit" runat="server" Text="Gửi" Style="margin-top: 12px;" OnClick="btnCommentSubmit_Click" />
        </div>
    </div>
</asp:Content>
