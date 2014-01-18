<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication5.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel='stylesheet' type="text/css" href="StyleSheet1.css" />
</head>



<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label3" runat="server" Text="Блог разработки блога" Font-Bold="true" Font-Size="22px"></asp:Label>

        <div class="denide"></div>

        <div class="divClass">
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Rows="5" Width="200" Text="type your minds..."></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Create" onclick="Button1_Click" />
        </div>

        <div class="denide"></div>

        <div class="divClass">
            <asp:Label ID="Label1" runat="server" Text="Type the number of post you want to delete:"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" Width="20"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="Delete" onclick="Button2_Click" />
        </div>

        <div class="denide"></div>

        <div class="divClass">
            <asp:Label ID="Label2" runat="server" Text="To change any post type new text in the large textbox and the number in the small textbox below."></asp:Label>
            <div class="divClass">
                <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Width="200" Rows="5"></asp:TextBox>
                <asp:TextBox ID="TextBox4" runat="server" Width="20"></asp:TextBox>
                <asp:Button ID="Button3" runat="server" Text="Update" onclick="Button3_Click" />
            </div>
        </div>

        <div class="denide"></div>

        <div class="divClass">
            <asp:PlaceHolder ID="ContentPlaceHolder" runat="server"></asp:PlaceHolder>
        </div>

    </div>
    </form>
</body>
</html>
