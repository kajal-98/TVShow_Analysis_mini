using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetImageUrl();
        }
    }

    private void SetImageUrl()
    {
        Random rd = new Random();
        int change = rd.Next(1, 3);
        Image1.ImageUrl = "~/timer_imgs/" + change.ToString() + ".jpg";
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        SetImageUrl();
    }
}