using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Estado1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label4.Text = "Vuelta: ";
        if (!Page.IsPostBack)
        {
            HiddenField1.Value = "1";
         }
        else 
        {
            int x = int.Parse(HiddenField1.Value);
            x++;
            HiddenField1.Value = x.ToString();
        }
        Label4.Text += HiddenField1.Value;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() != "")
            Label1.Text = TextBox1.Text;

        if (TextBox2.Text.Trim() != "")
            Label2.Text = TextBox2.Text;
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        if (TextBox3.Text.Trim() != "")
            Label3.Text = TextBox3.Text;
    }
}