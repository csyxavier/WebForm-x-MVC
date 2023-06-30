<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeePage.aspx.cs" Inherits="WebApp_WebForm.EmployeePage" %>

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
            <asp:Button runat="server" ID="btnSubmit" Text="建立" OnClick="btnSubmit_Click" />
        </div>
        <div>
            <asp:GridView DataKeyNames="PK" ID="EmployeeList" AutoGenerateColumns="False" runat="server" OnRowEditing="EmployeeList_RowEditing" OnRowDeleting="EmployeeList_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                    <asp:BoundField DataField="Birthday" HeaderText="Birthday" SortExpression="Birthday" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnEdit" Text="Edit" CommandName="Edit" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CommandName="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
    <script>

</script>
</body>
</html>
