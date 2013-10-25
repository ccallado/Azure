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

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() != "")
            Label1.Text = TextBox1.Text;

        if (TextBox2.Text.Trim() != "")
            Label2.Text = TextBox2.Text;
    }
}