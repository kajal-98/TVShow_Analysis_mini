<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="AdminPages_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .textEntry
        {
            margin-top: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style=" margin-left: 185px;
    margin-right: 180px; width:47%">
<p>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</p>
<fieldset>
<legend style="text-align:left;color:Orange">Add Show Name</legend>
<p>
    <asp:Label ID="Label2" runat="server" Text="Enter Show Name:"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="textEntry"></asp:TextBox>
    <asp:RequiredFieldValidator ID="ShownameRequired" runat="server" ControlToValidate="TextBox1" 
                             CssClass="failureNotification" ErrorMessage="Show Name is required." ToolTip="Show Name is required.">*</asp:RequiredFieldValidator>
</p>
<p>
    <asp:Label ID="Label3" runat="server" Text="Catgory:"></asp:Label><br/>
     <asp:DropDownList ID="DropDownList1" runat="server" CssClass="textEntry" 
        Height="25px" Width="319px">
        <asp:ListItem>Choose Category</asp:ListItem>
        <asp:ListItem>Drama</asp:ListItem>
        <asp:ListItem>Sci-fi</asp:ListItem>
        <asp:ListItem>Comedy</asp:ListItem>
        <asp:ListItem>Culture</asp:ListItem>
        <asp:ListItem>Documentry</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1" 
                             CssClass="failureNotification" ErrorMessage="Category is required." ToolTip="Category is required.">*</asp:RequiredFieldValidator>

</p>
    <p>
    <asp:Label ID="Label4" runat="server" Text="Enter Starting Year:"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" CssClass="textEntry"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" 
                             CssClass="failureNotification" ErrorMessage="Year is required." ToolTip="Year is required.">*</asp:RequiredFieldValidator>

   </p>
   <p class="submitButton">
   <asp:Button ID="AddButton" runat="server" Text="Add" onclick="Add_Button_Click"/>
                    <br/>
   </p>
   <p>
       <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
   </p>
</fieldset>
</div>
</asp:Content>

