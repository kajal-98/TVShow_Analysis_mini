using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Excel= Microsoft.Office.Interop.Excel;
//using System.Reflection.Missing;
using System.Data.OleDb;
using System.Runtime.InteropServices;

public partial class AdminPages_Add : System.Web.UI.Page
{
    public static String filepath = @"F:\mini_awt\Prime_TV_Shows_Data_set.xlsx";
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "Welcome " + Session["Uname"].ToString();
        Label1.Text = Label1.Text + "\n";
        Label1.ForeColor = System.Drawing.Color.Blue;
    }
    protected void Add_Button_Click(object sender, EventArgs e)
    {
         Excel.Application xlapp = new Excel.Application();
         Excel.Workbook xlworkbook = xlapp.Workbooks.Open(filepath, 0, false, 5, "", "", false,
       Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
        
        Excel._Worksheet xlWorkSheet = (Excel._Worksheet)xlworkbook.Worksheets.get_Item(1);
        //xlapp.Visible = true;
        xlapp.DisplayAlerts = false;
        Excel.Range xlRange = xlWorkSheet.UsedRange;
        int colCount = xlRange.Columns.Count;
        int rowNumber = xlRange.Rows.Count;
        String ExcelPath=Server.MapPath("~/ExcelSheet/Prime_TV_Shows_Data_set.xlsx");
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source ="+ExcelPath+"; Extended Properties=Excel 8.0; Persist Security Info = False");
       con.Open();
      
        string query= "INSERT INTO [Worksheet$] ([Sr_no],[Show_Name],[Year_of_release],[Genre]) VALUES(@no,@show,@yr,@gen)"; 
        OleDbCommand cmd = new OleDbCommand(query,con);
        cmd.Parameters.AddWithValue("@no",rowNumber+1);
        cmd.Parameters.AddWithValue("@Name_of_the_show",TextBox1.Text);
        cmd.Parameters.AddWithValue("@Year_of_release",TextBox2.Text);
        cmd.Parameters.AddWithValue("@Genre",DropDownList1.SelectedValue);
        cmd.ExecuteNonQuery();
        con.Close();
        xlworkbook.Close();
        xlapp.Quit();
        Label5.Text = "Data Has Been Saved in Excel File Successfully";
        TextBox1.Text = "";
        TextBox2.Text = "";
        //Response.Write("Record added Successfully...");
    }
    public class Showdetails { 
    public int SrNo{get;set;}
    public String ShowName { get; set; }
    public int Year { get; set; }
    public String Genre { get; set; }
    }
}