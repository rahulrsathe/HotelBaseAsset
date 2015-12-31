<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderItem.ascx.cs" Inherits="ctl_OrderItem" %>
<div>
    <asp:Label ID="lblMenuName" runat="server"  Width="130px" ></asp:Label>
    Rs.
    <asp:Label ID="lblMenuCost" runat="server" Width="30px" ></asp:Label>
    <asp:TextBox ID="txtQty" runat="server" Columns="2" MaxLength="2" style="text-align:right;"></asp:TextBox>
    <asp:ImageButton ID="imgIncr" runat="server"  ImageUrl="~/img/incr.png" onclick="Incr_Click"/>
    <asp:ImageButton ID="imgDecr" runat="server"  ImageUrl="~/img/decr.png" onclick="Decr_Click" />
    <asp:TextBox ID="txtTotal" runat="server" Columns="5" MaxLength="5" style="text-align:right;"/>
    <asp:HiddenField ID="hidMenuItemID" runat="server" />
    <asp:HiddenField ID="hidOrderDetailID" runat="server" />
    <asp:HiddenField ID="hidTaxID" runat="server" />
   </div>
