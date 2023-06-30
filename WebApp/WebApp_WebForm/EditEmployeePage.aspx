<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditEmployeePage.aspx.cs" Inherits="WebApp_WebForm.EditEmployeePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="姓名:" AssociatedControlID="Name" />
            <asp:TextBox runat="server" ID="Name" /><br />
            <asp:Label runat="server" Text="年齡:" AssociatedControlID="Birthday" />
            <asp:TextBox runat="server" ID="Age" /><br />
            <asp:Label runat="server" Text="生日:" AssociatedControlID="Birthday" />
            <asp:TextBox runat="server" ID="Birthday" /><br />
            <asp:Button runat="server" ID="btnEdit" Text="修改" OnClick="btnEdit_Click" />
        </div>
    </form>
</body>
</html>
