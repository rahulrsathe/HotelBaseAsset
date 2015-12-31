<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Site.master" AutoEventWireup="true"
    CodeFile="OrderDetail.aspx.cs" Inherits="Web_TablesHome" %>

<%@ Register Src="../ctl/OrderItem.ascx" TagName="OrderItem" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
  <div id="inner" style="border-spacing:0px;overflow:hidden;width: 900px">
     <div style="float:left;width:56%;">
      <asp:DataList ID="dlOrderItems" runat="server" CellPadding="0" ForeColor="#333333" 
             onitemdatabound="dlOrderItems_ItemDataBound" 
             onitemcommand="dlOrderItems_ItemCommand">

          <AlternatingItemStyle BackColor="White" />
          <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <HeaderTemplate>
              Order Details
          </HeaderTemplate>
          <ItemStyle BackColor="#E3EAEB" />

          <ItemTemplate>
              <table>
                <tr>
                    <td>
                            <uc1:OrderItem ID="OrderItem1" runat="server" />
                    </td>
                    <td>
                            <asp:ImageButton ID="btnDelOrderItem" runat="server" 
                          ImageUrl="~/img/delImage.JPG" />
                    </td>
                    <td>
                        <asp:ImageButton ID="chkCmplmntry" runat="server"> </asp:ImageButton>
                    </td>
                </tr>
              </table>
              
          </ItemTemplate>
          

          <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />

      </asp:DataList>

        <br />
        <asp:DataList ID="dlOrderTax" runat="server" CellPadding="4" ForeColor="#333333">
                <AlternatingItemStyle BackColor="White" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderTemplate>
                    Order Total:
                </HeaderTemplate>
                <ItemStyle BackColor="#EFF3FB" />
                <ItemTemplate>
                    <table>
                        <tr width="130px">
                            <td>
                                <asp:Label ID="lblTaxName" runat="server"  Width="130px"
                                Text='<%# DataBinder.Eval(Container.DataItem, "taxdesc")%>'
                                ></asp:Label> 
                            </td>
                            <td>
                                <asp:TextBox ID="txtTaxAmt" runat="server" ReadOnly="True" Width="50px"
                                Text='<%# DataBinder.Eval(Container.DataItem, "taxamt")%>'
                                ></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            </asp:DataList>
            <br />
           <div>
              
                <asp:HiddenField ID="hidOrderID" runat="server" />
                <asp:HiddenField ID="hidTableID" runat="server" />
                <asp:HiddenField ID="hidBillID" runat="server" />
           </div>
                                
                     
        <h1>
            
            Order Options:</h1>
         <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" /> &nbsp;
         <asp:Button ID="btnClose" runat="server" Text="Payments" 
             onclick="btnClose_Click" />&nbsp;
         <asp:Button ID="btnVoid" runat="server" Text="Cancel" />
     </div>
     <div style="float:left;width:10%;border-spacing:0px">
      
     <asp:DataList ID="dlMenuCat" runat="server" BorderColor="Black" CellPadding="1" ForeColor="#333333"
                                GridLines="Both" onitemcommand="dlMenuCat_ItemCommand" 
             onitemdatabound="dlMenuCat_ItemDataBound" >
                                <AlternatingItemStyle BackColor="White" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderTemplate>
                                    Categories
                                </HeaderTemplate>
                                <ItemStyle BackColor="#EFF3FB" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnMenuCat" runat="server" 
                                        Text='<%# DataBinder.Eval(Container.DataItem, "codedesc","{0:d}")%>' 
                                        Font-Size="Medium" CommandName="select" ></asp:LinkButton>
                                </ItemTemplate>
                                <SelectedItemStyle BackColor="#CC3399" Font-Bold="True"  
                                    Font-Italic="False" Font-Overline="False" Font-Size="Large" 
                                    Font-Strikeout="False" Font-Underline="False" BorderColor="#FFCC00" />
                                <SelectedItemTemplate>
                                   <asp:Label  ID="lblMenuItemSelected" runat="server"  
                                   Text='<%# DataBinder.Eval(Container.DataItem, "codedesc","{0:d}")%>'
                                        Font-Size="Medium" ForeColor="White" ></asp:Label>
                                </SelectedItemTemplate>
                            </asp:DataList>

     </div>
     <div style="float:left;width:33%;background-color:Silver" >
      
     <asp:DataList ID="dlMenuItems" runat="server" RepeatColumns="2" BackColor="White"
                                BorderColor="White" BorderStyle="Ridge" 
             BorderWidth="1px" CellPadding="0" CellSpacing="0"
                                GridLines="Both" 
             onitemcommand="dlMenuItems_ItemCommand" 
             onitemdatabound="dlMenuItems_ItemDataBound" style="margin-left: 0px">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderTemplate>
                                    Menu Items
                                </HeaderTemplate>
                                <ItemStyle BackColor="#CC3399" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemTemplate>
                                    <asp:Button ID="btnMenuItem" runat="server" Width="150px" Height="40px"  Text='<%# DataBinder.Eval(Container.DataItem, "menuitemname","{0:d}")%>'
                                        Font-Size="Medium" ForeColor="Black"></asp:Button>
                                </ItemTemplate>
                                <SelectedItemStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                            </asp:DataList>
     </div>
  </div> 
                           
</asp:Content>
