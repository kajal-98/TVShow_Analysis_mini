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
public partial class ShowbarGraph : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label4.Text = "Welcome " + Session["Uname"].ToString();
        Label4.Text = Label4.Text + "\n" + "Your ID is" + Session["Id"];
        Label4.ForeColor = System.Drawing.Color.Blue;

        //
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String ExcelPath = Server.MapPath("~/ExcelSheet/Prime_TV_Shows_Data_set.xlsx");
        using (OleDbConnection con1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False"))
        {
            con1.Open();
            String strConString1 = "SELECT Year_of_release,Language FROM [Worksheet$]";
            OleDbCommand objCmdSelect1 = new OleDbCommand(strConString1,con1);
            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
            objAdapter1.SelectCommand = objCmdSelect1;
            DataTable dt1 = new DataTable();
            objAdapter1.Fill(dt1);
            int[] x = new int[dt1.Rows.Count];
            int[] y = new int[dt1.Rows.Count];
            Response.Write(dt1.Rows.Count);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                x[i] = Convert.ToInt32(dt1.Rows[i][0]);
                y[i] = Convert.ToInt32(dt1.Rows[i][1]);
            }
            //Chart1.Series[0].Points.DataBindY(x);
            Chart1.Series[0].Points.DataBindXY(x,y);
            Chart1.Series[0].ChartType = SeriesChartType.Bar;


        }
    }
}