<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Web/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Tables
    </h2>
    <asp:DataList ID="dlTables" runat="server" RepeatColumns="4" BackColor="White" BorderColor="#E7E7FF"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        onitemcommand="dlTables_ItemCommand" onitemdatabound="dlTables_ItemDataBound" >
        <AlternatingItemStyle BackColor="#F7F7F7" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        
        <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C"/>
        <ItemTemplate>
            <div id="tbl" align="center" style="background-image: url('./img/table.jpg'); width:250px;height:250px"> 
            <br /><br /><br /><br /><br />
                    Table: <b>
                        <asp:Label ID="lblTableID" runat="server"></asp:Label>
                        <%# DataBinder.Eval(Container.DataItem, "tablenickname", "{0:d}")%><br /></b>
                    Start time: <b><%# DataBinder.Eval(Container.DataItem, "orderstarttime","{0:t}")%><br /></b>
                    Busy for hrs: <b><%# DataBinder.Eval(Container.DataItem, "busyfrom", "{0:t}")%><br /></b>
                    <asp:LinkButton ID="btnEditOrder" runat="server" Text="Edit/Create Order"
                         CommandArgument ='<%# DataBinder.Eval(Container.DataItem, "orderid", "{0:d}")%>' > </asp:LinkButton>
           </div>
        </ItemTemplate>
        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    </asp:DataList>
</asp:Content>
