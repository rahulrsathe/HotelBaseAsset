<%@ Control Language="C#" AutoEventWireup="true" CodeFile="IncrDecrControl.ascx.cs" Inherits="ctl_IncrDecrControl" %>
<asp:TextBox ID="txtQty" runat="server" MaxLength="10" Width="50px" Height="15px" style="text-align:right;"></asp:TextBox>
<asp:ImageButton ID="imgIncr" runat="server"  ImageUrl="~/img/incr.png" onclick="imgIncr_Click"/>
<asp:ImageButton ID="imgDecr" runat="server"  ImageUrl="~/img/decr.png" onclick="imgDecr_Click"/>
    