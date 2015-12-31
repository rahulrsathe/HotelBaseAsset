<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaymentAmounts.ascx.cs" Inherits="ctl_PaymentAmounts" %>
<div>
    <asp:Label ID="lblNoteAmt" runat="server"></asp:Label>
    <asp:TextBox ID="txtNote" runat="server" MaxLength="4" Width="50px" Height="15px" style="text-align:right;"></asp:TextBox>
    <asp:ImageButton ID="imgIncr" runat="server"  ImageUrl="~/img/incr.png" onclick="imgIncr_Click"/>
    <asp:ImageButton ID="imgDecr" runat="server"  ImageUrl="~/img/decr.png" onclick="imgDecr_Click"/>
    <asp:HiddenField ID="hidMultiplier" runat="server" />
</div>