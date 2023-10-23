<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="_0406homework2.add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增主題</title>
    <link href="StyleSheet.css" rel="stylesheet" />
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Noto+Sans+TC:wght@100;300;400;500;700;900&display=swap');
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <section class="container">
            <section class="display-center-col">
                <p class="margin-top-8-">
                    <asp:Label ID="Label1" runat="server" Text="*表示必填欄位" ></asp:Label>
                </p>
                <p >
                    <asp:Label ID="Label2" runat="server" Text="*主題："></asp:Label>
                </p>
                <p class="margin-top-16-">
                    <asp:TextBox ID="TextBox1" runat="server" placeholder="請勿空白！" AutoPostBack="True"  OnTextChanged="TextBox1_TextChanged"  ></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label3" runat="server" Text="*暱稱："></asp:Label>
                </p>
                <p class="margin-top-16-">
                    <asp:TextBox ID="TextBox2" runat="server"  placeholder="請勿空白！" AutoPostBack="True" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label4" runat="server" Text="*內容：" ></asp:Label>

                </p>
                <p class="margin-top-16-">
                    <asp:TextBox ID="TextBox3" runat="server" Height="200px"
                        TextMode="MultiLine"  placeholder="請勿空白！" AutoPostBack="True" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
                </p>
            </section>
            <section>
                <asp:Button ID="Button1" runat="server" Text="確認發表" OnClick="Button1_Click" class="btn" />
                <asp:Button ID="Button2" runat="server" Text="清除內容" OnClick="Button2_Click" class="btn" />
                <asp:Button ID="Button3" runat="server" Text="回首頁" OnClick="Button3_Click" class="btn" />
            </section>
        </section>

    </form>
</body>
</html>
