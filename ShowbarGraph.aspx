<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="ShowbarGraph.aspx.cs" Inherits="ShowbarGraph" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="show">
<p>
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
</p>
</div>
<div class="show">
<table style="width: 811px">
<tr style="forecolor:#333300">
<td class="style1">
    <asp:Button ID="Button1" runat="server" Text="Show" onclick="Button1_Click" />
    <center><asp:Label ID="Label5" runat="server" Text="Language"></asp:Label><br/></center>
    <asp:Chart ID="Chart1" runat="server" BackColor="0, 0, 64" BackGradientStyle="LeftRight"  
        BorderlineWidth="0" Height="360px" Palette="Pastel" Width="380px" 
        BorderlineColor="64, 0, 64" PaletteCustomColors="Green">
        <Titles>  
            <asp:Title ShadowOffset="10" Name="Gender" />  
        </Titles>  
        <Legends>  
            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"  
                LegendStyle="Row" />  
        </Legends>
        <Series>
            <asp:Series Name="Series1">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <br/>
</td>
</tr>
</table>
</div>
</asp:Content>

