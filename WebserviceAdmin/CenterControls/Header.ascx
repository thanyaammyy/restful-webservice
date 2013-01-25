<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="WebserviceAdmin.CenterControls.Header" %>
<div class="header">
    <div style="text-align: center; padding: 10px;">
         <h2>
            Onyx Hospitality</h2>
        <br />
        <div style=" font-size: 13px">
            Welcome <b><asp:Label ID="lbUsername" runat="server"></asp:Label></b> to Web Service Repository</div>
        <div style="float: right">
            <asp:ImageButton ID="btnLogout" ToolTip="Log out" ImageUrl="../Styles/images/logout.png" runat="server"
                Width="32" Height="32" onclick="btnLogout_Click" />
        </div>
    </div>
    <div id="divAdmin" style="padding: 20px; text-align: center">
        <a href="../Service.aspx" class="menu" >Service</a> <span style="color: white; padding: 2px">l</span> 
        <a href="../Users.aspx" class="menu" >User</a> <span style="color: white; padding: 2px">l</span> 
        <a href="../UserService.aspx" class="menu" >User Service Management</a>
    </div>
</div>
