<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_01_HelloWorld_WebForms_ASP.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <p>
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                <asp:Label ID="lblErrorNombre" Name="lblErrorNombre" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblApellidos" runat="server" Text="Apellidos:"></asp:Label>
                <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox>
                <asp:Label ID="lblErrorApellidos" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
            </p>
            <p>
                <asp:Button runat="server" ID="btnSubmit" Text="Enviar" OnClick="btnSubmit_Click" />
            </p>
            <p>
                <asp:Label ID="allOk" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
            </p>

        </div>
    </form>
</body>
</html>
