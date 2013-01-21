<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Repository.aspx.cs" Inherits="WebserviceAdmin.Repository" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul>
        <li>
            <asp:HyperLink  runat="server" Target="_blank" NavigateUrl="http://localhost:3638/Services/EmailService.svc/help" Text="Email Service"></asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink  runat="server" NavigateUrl="http://localhost:3638/Services/EmailService.svc/help">Email Service</asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink runat="server" NavigateUrl="http://localhost:3638/Services/EmailService.svc/help">Email Service</asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink  runat="server" NavigateUrl="http://localhost:3638/Services/EmailService.svc/help">Email Service</asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink  runat="server" NavigateUrl="http://localhost:3638/Services/EmailService.svc/help">Email Service</asp:HyperLink>
        </li>
    </ul>
    
</asp:Content>
