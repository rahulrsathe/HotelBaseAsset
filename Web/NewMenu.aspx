<%@ Page Language="C#" MasterPageFile="~/Web/Site.master" AutoEventWireup="true" CodeFile="NewMenu.aspx.cs" Inherits="Web_NewMenu" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <div class="page">
         
                <div class="header">
                    <h2 style="color:White">
                        Create new menu items
                    </h2>
                </div>
                <div class="main" >
                    <div  style="width: 57%; float:left; height: 100%;" >
                        <asp:updatepanel id="updatePanel1" runat="server">
                            <ContentTemplate>
                                    <div  > 
                                        <asp:Label ID="lblValidation" runat="server" ></asp:Label>
                                    </div>
        
                       
                                    <div style="float:Left; ">
                                        <div>Menu Name: </div>
                                    </div>
                                    
                                    <div>
                                        <div> <asp:TextBox ID="txtMenuName" runat="server" MaxLength="45"></asp:TextBox> </div>
                                    </div>

                       
                                    <div style="float:Left; ">
                                        <div>Menu type: </div>
                                    </div>
                                    
                                    <div>
                                        <div> <asp:DropDownList ID="dlMenuType" runat="server"></asp:DropDownList></div>
                                    </div>

                                    <div style="float:Left; ">
                                        <div>Menu Tax config:</div>
                                    </div>
                                    
                                    <div>
                                        <asp:CheckBoxList ID="chkTaxMaster" runat="server"></asp:CheckBoxList>
                                    </div>

                                    <div style="float:Left; ">
                                        <div>Cost: </div>
                                    </div>
                                    
                                    <div>
                                        <div> <asp:TextBox ID="txtCost" runat="server" MaxLength="45" TextMode="Number"></asp:TextBox> </div>
                                    </div>


                                    <div style="float:Left; ">
                                        <div> <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></div>
                                    </div>
                                    
                                    <div>
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                                    </div>


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

