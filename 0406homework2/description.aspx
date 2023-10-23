<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="description.aspx.cs" Inherits="_0406homework2.description" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>主題頁</title>
    <link href="StyleSheet.css" rel="stylesheet" />
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Noto+Sans+TC:wght@100;300;400;500;700;900&display=swap');
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <section class="container">
                            <p class="theme text-center bg-3 color-white width-100 padding-5 margin-top-1- margin-bottom-0-">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </p>
            <section class="theme display-center-col align-items-FS padding-5">

                <p class="margin-top-8- margin-top-16- position-relative width-100">
                    <asp:Label ID="Label3" runat="server" Text="發表人："></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>

                </p>
                <p class="margin-top-8- margin-top-16-">
                    <asp:Label ID="Label7" runat="server" Text="發表內容："></asp:Label>
                    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                </p>
                <p class="width-100 position-relative margin-bottom-4-">
                    <asp:Button ID="Button1" runat="server" Text="回覆主題" OnClick="Button1_Click" CssClass="btn2" />
                    <asp:Label ID="Label6" runat="server" Text="Label" CssClass="time"></asp:Label>
                </p>

            </section>
            <section class="margin-top-8 position-relative">
                <h2 class="color-blue">🚀 留言列表
                    <span class="position-absolute">
                        <asp:Button ID="Button2" runat="server" Text="從最新到最舊" OnClick="Button2_Click" class="btn2" />
                        <asp:Button ID="Button3" runat="server" Text="從最舊到最新" OnClick="Button3_Click" class="btn2" />
                        <asp:Button ID="Button4" runat="server" Text="回首頁" OnClick="Button4_Click" class="btn2" />
                    </span>
                </h2>

            </section>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <section class="reply">
                                            <p class=" bg-3 color-white width-100 padding-5 margin-top-1- margin-bottom-16-">
                        <%# "回覆人："+Eval("Reply_name")+"  , 回覆時間："+Eval("Initdate") %>
                    </p>
                    <p class="padding-5">
                        <%# Eval("Reply_description") %>
                    </p>
                    </section>

                </ItemTemplate>
            </asp:Repeater>
        </section>

    </form>
</body>
</html>
