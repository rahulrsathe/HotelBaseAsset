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
                            <triggers>


                            </triggers>

                        </asp:updatepanel>
                         

                    </div>

                </div>
        </div>  


</asp:Content>

