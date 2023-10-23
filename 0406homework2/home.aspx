<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="_0406homework2.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>首頁</title>
    <link href="StyleSheet.css" rel="stylesheet" />
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Noto+Sans+TC:wght@100;300;400;500;700;900&display=swap');
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <section class="container text-center">

            <h1 class="color-tan font-wieght margin-bottom-0-">童叟無欺留言板</h1>
            <div class="display-sb border-bottom mt-16 hidden">
                <h4 class="margin-bottom-0- margin-left-16- margin-top-0- padding-4- nowrap">版規1：請自由自在的留言吧!</h4>
                <h4 class="margin-bottom-0- margin-top-0- padding-4 nowrap">版規2：一言既出，駟馬難追！</h4>
                <h4 class="margin-bottom-0- margin-top-0- padding-4 nowrap">版規3：我想到再跟你說。</h4>
                <h4 class="margin-bottom-0- margin-top-0- padding-4 nowrap">版規4：... ... ... ... ... ... ... ... </h4>
                <h4 class="margin-bottom-0- margin-top-0- padding-4 nowrap">版規5：你的螢幕還真大=.=</h4>
            </div>

            <section class="mb-20 text-center mt-16">
                <asp:Button ID="Button1" runat="server" Text="發表主題" OnClick="Button1_Click1" class="btn" />
                <asp:Button ID="Button2" runat="server" Text="最新到最舊" OnClick="Button2_Click1" class="btn" />
                <asp:Button ID="Button3" runat="server" Text="最舊到最新" OnClick="Button3_Click1" class="btn" />
            </section>
            <section class="display-center">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="white" BorderColor="black" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" BorderStyle="None">
                    <AlternatingRowStyle BackColor="tan" />
                    <Columns>

                        <asp:TemplateField HeaderText="編號" InsertVisible="False" SortExpression="Article_id" ItemStyle-CssClass="padding-5 border-radious-10r" HeaderStyle-CssClass="padding-5 border-radious-10r">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Article_id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="主題" SortExpression="Article_theme" ItemStyle-CssClass="padding-5 " HeaderStyle-CssClass="padding-5">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "description.aspx?id="+Eval("Article_id") %>' Text='<%# Eval("Article_theme") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="發表人" SortExpression="Article_name" ItemStyle-CssClass="padding-5" HeaderStyle-CssClass="padding-5">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Article_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="發表時間" SortExpression="Initdate" ItemStyle-CssClass="padding-5 border-radious-10l" HeaderStyle-CssClass="padding-5 border-radious-10l">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Initdate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <HeaderStyle BackColor="Tan" />
                </asp:GridView>

            </section>
        </section>

    </form>
</body>
</html>
