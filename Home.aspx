<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                <asp:Image ID="Image1" runat="server"  Height="282px" Width="891px" 
                    BorderColor="#000099" BorderStyle="Solid" />
                </ContentTemplate>
                <Triggers>
                <asp:AsyncPostBackTrigger ControlId="Timer1" Eventname="Tick" />
                
                </Triggers>
            </asp:UpdatePanel>
             <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick">
                    </asp:Timer>
</asp:Content>

