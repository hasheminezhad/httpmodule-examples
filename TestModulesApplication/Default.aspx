<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestModulesApplication.Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 400px; margin: 0 auto;">
        <h1><%= Request.QueryString["msg"] %></h1>
        <asp:Panel runat="server" GroupingText="Long Request Tester">
            <asp:Button ID="btnShort" Text="Short" runat="server" OnClick="btnShort_Click" />
            <asp:Button ID="btnMedium" Text="Medium" runat="server" OnClick="btnMedium_Click" />
            <asp:Button ID="btnLong" Text="Long" runat="server" OnClick="btnLong_Click" />
            <hr />  
            <asp:Label EnableViewState="false" ID="lblLongRequestMesage" runat="server"
                Text="Click on a button to start." />
        </asp:Panel>
        <asp:Panel runat="server" GroupingText="Cookie Verifier Tester">
            <asp:Button ID="btnSetCookie" Text="Set Cookie" runat="server" OnClick="btnSetCookie_Click" />
            <asp:Button ID="btnGetCookie" Text="Get Cookie" runat="server" OnClick="btnGetCookie_Click" />
            <hr />  
            Value: <asp:TextBox ID="txtCookieValue" runat="server" />
        </asp:Panel>
        <asp:Panel runat="server" GroupingText="SimpleUrlRewriter Tester">
            Choose one:
            <a href="Default.aspx?msg=This+is+Default.aspx">Default.aspx</a>
            <a href="Fake.aspx">Fake.aspx</a>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
