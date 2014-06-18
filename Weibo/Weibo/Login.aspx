<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Weibo.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form" runat="server">
    <div class="container">
        <div class="login">
            <h1>
                Login to Weibo</h1>
            <p>
                Account:
                <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
            </p>
            <p>
                Password:
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></p>
            <p class="remember_me">
            </p>
            <p class="submit">
                <asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_OnClick">
                </asp:Button></p>
            <p class="remember_me">
                <asp:Label ID="lblMessage" runat="server" Visible="true"></asp:Label>
            </p>
        </div>
    </div>
    </form>
</body>
</html>
