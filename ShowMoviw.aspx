<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="ShowMoviw.aspx.cs" Inherits="ShowMoviw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 392px;
        }
        .style2
        {
            width: 397px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="show">
<p>
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
</p>
<p>

    <asp:Label ID="Label1" runat="server" 
        Text="Select the given fields to get the graph" BorderColor="#FF3399" 
        ForeColor="Red" ></asp:Label><br/>
    
    <b>
        <asp:Label ID="Label2" runat="server" Text="Category" ></asp:Label></b>
     <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
         <asp:ListItem>Choose Items</asp:ListItem>
         <asp:ListItem>Drama</asp:ListItem>
         <asp:ListItem>Sci-fi</asp:ListItem>
         <asp:ListItem>Comedy</asp:ListItem>
         <asp:ListItem>Culture</asp:ListItem>
         <asp:ListItem>Documentary</asp:ListItem>
    </asp:DropDownList> 
&nbsp;&nbsp;<b><asp:Label ID="Label3" runat="server" Text="Show Name:" ></asp:Label></b>
    <asp:DropDownList ID="DropDownList2" runat="server" >
    </asp:DropDownList>
&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="View Graph" 
        onclick="ViewGraph"/>
</p>
<div class="show">
<table style="width: 811px">
<tr style="forecolor="#333300">
<td class="style1">
    <center><asp:Label ID="Label5" runat="server" Text="Gender"></asp:Label><br/></center>
    <asp:Chart ID="Chart1" runat="server" BackColor="0, 0, 64" BackGradientStyle="LeftRight"  
        BorderlineWidth="0" Height="360px" Palette="Pastel" Width="380px" BorderlineColor="64, 0, 64" PaletteCustomColors="Green">
        <Titles>  
            <asp:Title ShadowOffset="10" Name="Gender" />  
        </Titles>  
        <Legends>  
            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"  
                LegendStyle="Row" />  
        </Legends>
        <Series>
            <asp:Series Name="Series1" ChartType="Pie">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <br />
</td>
<td class="style2">
<div>
<fieldset>
   <center><h3><b><asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></b></h3></center>
    <asp:Label ID="Label7" runat="server" Text="Popularity:"></asp:Label>
</fieldset>
</div>
</td>
</tr>
</table>
</div>
</div>
</asp:Content>

