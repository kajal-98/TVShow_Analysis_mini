using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;


public partial class Register : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
       // RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
    }

    protected void CreateUserButton_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ConnectionString);
        String Param = "INSERT INTO UserTable VALUES(@UserName,@EmailId,@Gender,@password)";
        con.Open();
        int i = 0;
        try {
            
            i++;
            SqlCommand cmd = new SqlCommand(Param,con);
            //cmd.Parameters.AddWithValue("@ID", i);
            cmd.Parameters.AddWithValue("@UserName",UserName.Text);
            cmd.Parameters.AddWithValue("@password",ConfirmPassword.Text);
            cmd.Parameters.AddWithValue("@Gender", Ddl1.SelectedValue);
            cmd.Parameters.AddWithValue("@EmailId",Email.Text);
            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Registered Successfully!!!');", true);
            Response.Redirect(@"~\Login.aspx");
        }
        catch (Exception ex) {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
        }
        
        
    }
}
