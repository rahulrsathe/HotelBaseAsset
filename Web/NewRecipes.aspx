﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Site.master" AutoEventWireup="true" CodeFile="NewRecipes.aspx.cs" Inherits="Web_NewRecipes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


<div style="float:left ; width:50%">
    <div>
        <div> Select material and  quantity for your recipe</div>
    <div>
        
        <div style="float:left">
            Menu item of this recipe:
        </div>
        <div>
            <asp:DropDownList ID="dlMenuItems" runat="server" DataTextField="menuitemname"
                        DataValueField="menuitemid" AutoPostBack="True" OnSelectedIndexChanged="dlMenuItems_SelectedIndexChanged" ></asp:DropDownList>
         </div>
    </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    
    <div>
        <div style="float:left">
            Inventory category:
        </div>
        <div>
            <asp:DropDownList ID="dlInventCat" runat="server" 
                DataTextField="codedesc" DataValueField="code" AutoPostBack="True" OnSelectedIndexChanged="dlInventCat_SelectedIndexChanged"></asp:DropDownList>
        </div>
     </div>
            
        <div>
        <div style="float:left">
            Inventory item
        </div>
        <div>
            <asp:DropDownList ID="dlInvItem" runat="server" DataTextField="inventorytypename" DataValueField="inventoryheaderid" AutoPostBack="True" OnSelectedIndexChanged="dlInvItem_SelectedIndexChanged" ></asp:DropDownList>
        </div>
     </div>

    <div>
        <div style="float:left">
            Quantity consumed:
        </div>
        <div>
            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox> <asp:Label ID="lblQtyMeasure" runat="server"></asp:Label>
        </div>
     </div>
    </ContentTemplate>
            <triggers>
             <asp:AsyncPostBackTrigger controlid="dlMenuItems" eventname="SelectedIndexChanged" />
             <asp:AsyncPostBackTrigger controlid="dlInventCat" eventname="SelectedIndexChanged" />
             <asp:AsyncPostBackTrigger controlid="dlInvItem" eventname="SelectedIndexChanged" />
             <asp:AsyncPostBackTrigger controlid="btnSave" eventname="Click" />
              
             
            </triggers>
    </asp:UpdatePanel>

        <div>
        <div style="float:left">
             <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
        <div>
            <asp:Button ID="btnClear" runat="server" Text="Clear" />
        </div>
     </div>

</div>
</div>

<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hidNewEditFlag" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <div style="float:left ; width:50%">
            <asp:GridView ID="grdRecipe" runat="server" AutoGenerateColumns ="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" OnRowCommand="grdRecipe_RowCommand">
                         
                <Columns>
                    <asp:BoundField DataField="InventoryTypeName" HeaderText="Inventroy Name" ReadOnly="True" />
                    <asp:BoundField DataField="reduceinvqty" HeaderText="Qty" ReadOnly="True" />
                    <asp:BoundField DataField="Measure" HeaderText="Measure" ReadOnly="True" />
                    <asp:BoundField DataField="idinvmnuassn" ShowHeader="false" Visible="false" ReadOnly="True" />
                    <asp:BoundField DataField="menuitemid" ShowHeader="false" Visible="false" ReadOnly="True" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server"
                                CommandArgument='<%# Eval("idinvmnuassn")  +"|"+ Eval("InventoryTypeName") %>' 
				                    CommandName="Delete">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server"
                                CommandArgument='<%# Eval("idinvmnuassn") %>' 
				                    CommandName="Edit">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>


                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#33276A" />


            </asp:GridView>
        </div>
    </ContentTemplate>
    <triggers>
         <asp:AsyncPostBackTrigger controlid="dlMenuItems" eventname="SelectedIndexChanged" />
         <asp:AsyncPostBackTrigger controlid="btnSave" eventname="Click" />
    </triggers>
</asp:UpdatePanel>
</asp:Content>

