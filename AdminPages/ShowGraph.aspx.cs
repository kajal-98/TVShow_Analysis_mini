using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
//using System.Reflection.Missing;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

public partial class AdminPages_ShowGraph : System.Web.UI.Page
{
     protected void Page_Load(object sender, EventArgs e)
    {
        Label4.Text = "Welcome " + Session["Uname"].ToString();
        Label4.Text = Label4.Text + "\n";
        Label4.ForeColor = System.Drawing.Color.Blue;

    }
   
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        String ExcelPath = Server.MapPath("~/ExcelSheet/Prime_TV_Shows_Data_set.xlsx");
        OleDbConnection con1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
        con1.Open();
        String strConString1 = "SELECT Show_Name FROM [Worksheet$] WHERE Genre=@gen";
        OleDbCommand objCmdSelect1 = new OleDbCommand(strConString1, con1);
        objCmdSelect1.Parameters.AddWithValue("@gen", DropDownList1.SelectedValue);
        OleDbDataAdapter objAdapter2 = new OleDbDataAdapter();
        objAdapter2.SelectCommand = objCmdSelect1;
        DataTable objDataset2 = new DataTable();
        objAdapter2.Fill(objDataset2);
        List<ListItem> lstCategories1 = new List<ListItem>();

        string sheetName1 = string.Empty;
        foreach (DataRow dr in objDataset2.Rows)
        {
            sheetName1 = dr["Show_Name"].ToString();
            if (!sheetName1.Contains("Sheet"))
                lstCategories1.Add(new ListItem(
                            sheetName1.Replace("$", "")));
        }
        DropDownList2.DataSource = lstCategories1

            ;
        DropDownList2.DataBind();
        con1.Close();
        
    }
    protected void ViewGraph(object sender, EventArgs e)
    {
        Label6.Text = DropDownList2.SelectedValue;
        String ExcelPath = Server.MapPath("~/ExcelSheet/Prime_TV_Shows_Data_set.xlsx");
        using (OleDbConnection con1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False")) {
            con1.Open();
            string conString2="SELECT Female,male FROM [Worksheet$] WHERE Show_Name=@name";
            String popularity = "SELECT IMDb_rating FROM [Worksheet$] WHERE Show_Name=@name";
            OleDbCommand objselect1 = new OleDbCommand(conString2, con1);
            OleDbCommand objselect2 = new OleDbCommand(popularity, con1);
            objselect1.Parameters.AddWithValue("@name",DropDownList2.SelectedValue);
            objselect2.Parameters.AddWithValue("@name", DropDownList2.SelectedValue);
            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
            objAdapter1.SelectCommand = objselect1;
            OleDbDataAdapter objAdapter2 = new OleDbDataAdapter();
            objAdapter2.SelectCommand = objselect2;
            DataTable dt1 = new DataTable();
            objAdapter1.Fill(dt1);
            DataTable dt2 = new DataTable();
            objAdapter2.Fill(dt2);
            Label7.Text += dt2.Rows[0][0];
            int[] x = new int[dt1.Rows.Count];
            int[] y = new int[dt1.Rows.Count];
            Response.Write(dt1.Rows.Count);
            for (int i = 0; i < dt1.Rows.Count; i++) {
             x[i] = Convert.ToInt32(dt1.Rows[i][0]);
             y[i] = Convert.ToInt32(dt1.Rows[i][1]);
            }
           //Chart1.Series[0].Points.DataBindY(x);
           Chart1.Series[0].Points.DataBindXY(x,y);
            Chart1.Series[0].ChartType = SeriesChartType.Pie;
        }
    }
}