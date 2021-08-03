using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    int count;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ConnectionString);
        count++;
        String id;
        if (UserName.Text == "Admin" && Password.Text == "Admin")
        {
            Session["Uname"] = UserName.Text;
            Response.Redirect("~/AdminPages/AdminHome.aspx");
            
        }
        else {
            con.Open();
            String query = "SELECT * from UserTable WHERE UserName=@uname and password=@pass";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@uname", UserName.Text);
            cmd.Parameters.AddWithValue("@pass", Password.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Login Successfull!');", true);
                //Response.Redirect("~/Admin/Profile_Page.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid Login!');", true);
            }
            if (count > 3)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('All Attempts are Over!!');", true);
                this.Dispose();
            }
            dr.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            id = dt.Rows[0]["Id"].ToString();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                Session["Id"] = id;
                Session["Uname"] =UserName.Text;
                Response.Redirect(@"~/ShowMoviw.aspx");
            }
            else
            {
                Label1.Text = "Your Username or Password Might be Wrong!!!";
                Label1.ForeColor = System.Drawing.Color.Red;
            } 
        }
        
    }

}
