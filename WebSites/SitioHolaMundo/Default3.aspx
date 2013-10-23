<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "Hola Mundo .... (Todo en uno)";
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hola mundo (Todo en uno)</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Saludo" onclick="Button1_Click" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <hr />
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <!-- HTML -->
        <input id="Submit1" type="submit" value="submit" />
        <input id="Text1" type="text" />
        <br />
        <!-- ASP -->
        <% Response.Write("Esto está escrito por ASP..."); %>
        <br />
    </div>
    </form>
</body>
</html>
