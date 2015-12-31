<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Site.master" AutoEventWireup="true"
    CodeFile="CloseOrder.aspx.cs" Inherits="Web_CloseOrder" %>

<%@ Register src="../ctl/PaymentAmounts.ascx" tagname="PaymentAmounts" tagprefix="uc1" %>
<%@ Register src="../ctl/IncrDecrControl.ascx" tagname="IncrDecrControl" tagprefix="uc2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="inner" style="overflow: hidden; width: 900px">
        <div style="float: left; width: 10%;">
        &nbsp;
        </div>
        
        <div id ="dvCenter"style="float: left; width: 70%;">
             <h2>
                Order Closing Options
             </h2>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        
            <ContentTemplate>
              
             <h3>
                 <asp:Label ID="lblValSummary" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
                 </h3>
                 <h3>
                     Payment options:
                 </h3>
                 <h3>
                 <asp:RadioButton ID="rdrCash" runat="server" Checked="True" GroupName="PYMNOPT" 
                     text="Cash" />
                 &nbsp;
                 <asp:RadioButton ID="rdrCreditCard" runat="server" GroupName="PYMNOPT" 
                     text="Credit Card" />
                 &nbsp;
                 <asp:RadioButton ID="rdrDebit" runat="server" GroupName="PYMNOPT" 
                     text="DebitCard" />
                 &nbsp;
                 <br />
                 </h3>
                 <h1>
                     Discount percent:
                     <asp:TextBox ID="txtDiscount" runat="server" AutoPostBack="True" Columns="3" 
                         MaxLength="3" ontextchanged="txtDiscount_TextChanged" Width="25px">0</asp:TextBox>
                     </h1>
                     <h3>
                         <asp:Label ID="lblDisReason" runat="server" Font-Bold="True" Text = "Discount reason:" Visible="false"></asp:Label>
                     <asp:DropDownList ID="dlDiscountCode" runat="server" DataTextField="codedesc" 
                         DataValueField="code" Visible="false">
                     </asp:DropDownList>
                     </h3>
                     
                 <h3>
                     Customer payment:</h3>
                 <uc1:PaymentAmounts ID="ucNotes1000" runat="server" Multiplier="1000" 
                     NotesLabel="1000 * " />
                 <uc1:PaymentAmounts ID="ucNotes500" runat="server" Multiplier="500" 
                     NotesLabel="500  * " />
                 <uc1:PaymentAmounts ID="ucNotes100" runat="server" Multiplier="100" 
                     NotesLabel="100  * " />
                 <uc1:PaymentAmounts ID="ucNotes50" runat="server" Multiplier="50" 
                     NotesLabel="50   * " />
                 <uc1:PaymentAmounts ID="ucNotes20" runat="server" Multiplier="20" 
                     NotesLabel="20   * " />
                 <uc1:PaymentAmounts ID="ucNotes10" runat="server" Multiplier="10" 
                     NotesLabel="10 * " />
                 <asp:LinkButton ID="btnClearNotes" runat="server" onclick="btnClearNotes_Click" 
                     Text="Clear Amount"></asp:LinkButton>
                 <br />
                 <h3>
                         paid by customer:&nbsp;
                         <asp:Label ID="lblTotalPaid" runat="server" Font-Bold="True"></asp:Label>
                     </h3>
                     <h3>
                         Order total:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Label ID="lblOrderTotal" runat="server" Font-Bold="True" 
                             Text="lblOrderTotal"></asp:Label>
                     </h3>
                     <h3>
                         Return:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Label ID="lblReturn" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                     </h3>
                      
                      
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger controlid="btnClearNotes" eventname="Click" />
            <asp:AsyncPostBackTrigger controlid="txtDiscount" eventname="TextChanged" />

        </Triggers>
        </asp:UpdatePanel>
            
        <br />
            <asp:Button ID="btnCloseOrder" runat="server" Text="Complete Order" 
                 onclick="btnCloseOrder_Click" /> 
            <asp:Button ID="btnPrintBill" runat="server" Text="Print Bill" 
                 onclick="btnPrintBill_Click"/> 
            <asp:Button ID="btnVoidOrder" runat="server" Text="Void" />
            <asp:Button ID="btnBack" runat="server" Text="Back" />
        </div>


        <div style="float: left; width: 10%;">
        <asp:HiddenField ID="hidBillID" runat="server" />
        <asp:HiddenField ID="hidOrderID" runat="server" />
        <asp:HiddenField ID="hidOrgBillAmt" runat="server" />
        &nbsp;
        </div>
        
    </div>
    
</asp:Content>
