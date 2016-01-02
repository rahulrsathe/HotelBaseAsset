<%@ Page Title="Log In" Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs"
    Inherits="Account_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" runat="server">
    <div class="loginpage">
         
                <div class="header">
                    <h2 style="color:White">
                        Log In
                    </h2>
                </div>
                <div class="main" >
                         <div  style="width: 43%; float:left; height: 267px;" >
                        <img alt="" src="/img/header.jpg" style="height: 266px; text-align:right; width: 300px;" />
                    </div>
                    <div style="width:50%;float:left" >
                        <p>
                            Please enter your username and password. 
                        </p>
                        <asp:Login ID="LoginUser" runat="server" EnableViewState="False" BackColor="#E3EAEB"
                            BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px"
                            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" OnLoggedIn="LoginUser_LoggedIn"
                            OnLoginError="LoginUser_Error" OnLoggingIn="LoginUser_LoginIn" OnAuthenticate="LoginUser_OnAuthenticate"
                            TextLayout="TextOnTop" Width="375px">
                            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                            <LayoutTemplate>
                                <span class="failureNotification">
                                    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                                </span>
                                <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                                    ValidationGroup="LoginUserValidationGroup" />
                                <div class="accountInfo">
                                    <fieldset class="login">
                                        <legend>Account Information</legend>
                                        <p>
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                                            <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                        </p>
                                        <p>
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                            <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                        </p>
                                     
                                    </fieldset>
                                    <p class="submitButton">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup"
                                            OnClick="LoginButton_Click" />
                                    </p>
                                </div>
                            </LayoutTemplate>
                            <LoginButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid" BorderWidth="1px"
                                Font-Names="Verdana" Font-Size="0.8em" ForeColor="#1C5E55" />
                            <TextBoxStyle Font-Size="0.8em" />
                            <TitleTextStyle BackColor="#1C5E55" Font-Bold="True" Font-Size="0.9em" 
                                ForeColor="White" />
                        </asp:Login>
                    </div>        
               
               
    </div>
    </form>
</body>
</html> 