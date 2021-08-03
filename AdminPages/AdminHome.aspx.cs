using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "Welcome " + Session["Uname"].ToString();
        Label1.Text = Label1.Text + "\n";
        Label1.ForeColor = System.Drawing.Color.Blue;
    }
}