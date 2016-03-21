<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Site.master" AutoEventWireup="true"
    CodeFile="InvntryRecordNewWaste.aspx.cs" Inherits="Web_InventoryCentral" %>
<%@ Register Src="../ctl/IncrDecrControl.ascx" TagName="OrderItem" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">    
<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
    <asp:HiddenField ID="hdInventoryAction" runat="server" Visible="False" />
    <div id="inner" style="overflow: hidden; width: 900px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
         
                <div>
                    <h1>                      
                        <asp:LinkButton ID="btnNewInventory" runat="server" Text="Record New Inventory" 
                            onclick="btnNewInventory_Click"></asp:LinkButton>
                        &nbsp;
                    
                        &nbsp;&nbsp;| &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnRecordWaste" runat="server"
                            Text="Record Waste" onclick="btnRecordWaste_Click"></asp:LinkButton>
                    </h1>
                    
                    <p>
                        <asp:Label ID="lblValSummary" runat="server" ForeColor="Red"></asp:Label>
                        </p>
                    
                </div>
                <div id="dvCenter" style="float: left;">
                    Select Category:
                    <br />
                    Select Inventory Item:
                    <br />
                    <br />
                    Buy Quantity
                    <br />
                    <br />
                    Buy Date
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br>
                    Price per item
                </div>
                <div id="Div1" style="float: left;">
                    <asp:DropDownList ID="dlInventoryCategory" runat="server" DataTextField="codedesc"
                        OnSelectedIndexChanged="dlInventoryCategory_SelectedIndexChanged" 
                        DataValueField="code" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="valItemType" runat="server" ErrorMessage="*" 
                        ForeColor="Red" ControlToValidate="dlInventoryCategory"></asp:RequiredFieldValidator>
                    <br/>
                    <asp:DropDownList ID="dlInventoryItem" runat="server" DataTextField="inventorytypename"
                        DataValueField="inventoryheaderid" AutoPostBack="True" 
                        onselectedindexchanged="dlInventoryItem_SelectedIndexChanged">
                    </asp:DropDownList><asp:RequiredFieldValidator ID="valItemName" runat="server" 
                        ErrorMessage="*" ForeColor="Red" ControlToValidate="dlInventoryItem"></asp:RequiredFieldValidator>
                    <br />
                    <uc1:OrderItem ID="ucInventoryQty" runat="server" />
                    
                    <asp:Label ID="lblInventoryMeasure" runat="server"></asp:Label>
                    <br />
                    <asp:Calendar ID="clrInventoryBuyDt" runat="server" BackColor="White" BorderColor="#3366CC"
                        BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
                        Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" 
                        FirstDayOfWeek="Monday">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                            Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar>
                    <uc1:OrderItem ID="ucInventoryCost" runat="server" />
                     
                    <br />
                   
                </div>
    </div> </ContentTemplate>
    <triggers>
             <asp:AsyncPostBackTrigger controlid="dlInventoryCategory" eventname="SelectedIndexChanged" />
             <asp:AsyncPostBackTrigger controlid="dlInventoryItem" eventname="SelectedIndexChanged" />
             <asp:AsyncPostBackTrigger controlid="btnSave" eventname="Click" /> 
             
            </triggers>
    </asp:UpdatePanel>
    <div>
        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
    </div>
</asp:Content>
