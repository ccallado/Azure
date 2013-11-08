﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Contador"] == null)
            Session["Contador"] = 0;

        Session["Contador"] = ((int)Session["Contador"]) + 1;

        if (!Page.IsPostBack)
            Label0.Text = "Carga..." + DateTime.Now.ToLongTimeString();
        else
            Label0.Text = "Recarga..." + DateTime.Now.ToLongTimeString();

        Label0.Text += "<br /><i>Llamadas: " + Session["Contador"] + "</i>";

        Label1.Text = "";
        Label2.Text = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = DateTime.Now.ToLongTimeString();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Label2.Text = DateTime.Now.ToLongTimeString();
    }
}