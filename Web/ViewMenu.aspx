<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Site.master" AutoEventWireup="true" CodeFile="ViewMenu.aspx.cs" Inherits="Web_ViewMenu" %>




<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div style="overflow: auto;float:left">
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
        </div>
        <div style=" float:left">
    <asp:GridView ID="GridView1" runat="server" onrowcommand="GridView1_RowCommand" 
                onrowdatabound="GridView1_RowDataBound" 
                onselectedindexchanged="GridView1_SelectedIndexChanged" >
    </asp:GridView>
            <asp:RadioButton ID="RadioButton1" runat="server" />
            <asp:CheckBox ID="CheckBox1" runat="server" />
    </div>
</asp:Content>

