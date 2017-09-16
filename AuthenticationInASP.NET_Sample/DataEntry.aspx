<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataEntry.aspx.cs" Inherits="AuthenticationInASP.NET_Sample.DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p>Congratulations, you have now logged in </p>
        <asp:Label ID="lblUsername" runat="server"></asp:Label>
        <asp:LinkButton id="hlSignOut" runat="server" Text="Sign out" OnClick="hlSignOut_Click"></asp:LinkButton> 
    </div>
    </form>
</body>
</html>
