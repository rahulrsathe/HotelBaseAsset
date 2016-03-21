<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Site.master" AutoEventWireup="true" CodeFile="ViewMenu.aspx.cs" Inherits="Web_ViewMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <div class="page">
         
                <div class="header">
                    <h2 style="color:White">
                        Menu Item Management and costing
                    </h2>
                </div>
                <div class="main" >
                    <div  style="width: 57%; float:left; height: 100%;" >
                        <asp:updatepanel id="updatePanel1" runat="server">
                            <ContentTemplate>

                            </ContentTemplate>

                            <triggers>

                            </triggers>
                        </asp:updatepanel>

                    </div>
                    <div style="width:42%;float:left" >
                        <asp:updatepanel id="updatePanel2" runat="server">
                            <ContentTemplate>

                                <asp:GridView ID="grdMenus" runat="server" AutoGenerateColumns ="False" 
                                        BackColor="White" BorderColor="White" BorderStyle="Ridge"  
                                        BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" >

                                    <Columns>
                                        <asp:BoundField DataField="MenuItemName" HeaderText="Menu Item Name" ReadOnly="True" />
                                        <asp:BoundField DataField="MenuItemCost" HeaderText="Cost" ReadOnly="True" />
                                        <asp:BoundField DataField="showinorder" HeaderText="Available in Order" ReadOnly="True" />
                                        <asp:BoundField DataField="MenuItemID" ShowHeader="false" Visible="false" ReadOnly="True" />
                                        <asp:BoundField DataField="idmenutaxassn" ShowHeader="false" Visible="false" ReadOnly="True" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" AutoPostBack="True"
                                                    CommandArgument='<%# Eval("MenuItemID")  +"|"+ Eval("MenuItemName") %>' 
				                                        CommandName="Delete" >Delete</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                     
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" runat="server" AutoPostBack="True"
                                                      CommandArgument='<%# Eval("MenuItemID")  +"|"+ Eval("idmenutaxassn") %>' 
				                                        CommandName="Edit">Edit</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>


                                </asp:GridView>

                            </ContentTemplate>
                            <triggers>


                            </triggers>

                        </asp:updatepanel>
                         

                    </div>

                </div>
        </div>  


</asp:Content>

