<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Site.master" AutoEventWireup="true" CodeFile="PrintBill.aspx.cs" Inherits="Web_PrintBill" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div id="inner" style="overflow:hidden;width: 900px">

    <div style="float:left;width:2%;">
    </div>

    <div style="float:left;width:96%;">
        <div>
        </div>
        <div>
            
            &nbsp;<rsweb:ReportViewer ID="vwrBill" runat="server" 
                ShowCredentialPrompts="False" Width="860px">
            </rsweb:ReportViewer>

        </div>

    </div>

    <div style="float:left;width:2%;">
    </div> 

</div>            
</asp:Content>

