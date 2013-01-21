<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebserviceAdmin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta content="Onyx Hospitality Group" name="KEYWORDS">
    <meta content="Onyx Hospitality: Corporate Office" name="DESCRIPTION">
    <title>Login | Web Service Administration</title>
    <link href="Styles/jquery-ui-1.9.1.custom.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function clearLabel() {
            $("#lbRequired").hide();
            $("#lbError").hide();
            $("#lbPwdRequired").hide();
            $("#lbUserRequired").hide();
        }
    </script>
    <style>
        .TextBlack12 {
            color: white;
            font-family: Verdana;
            font-size: 12px;
        }
        .asteric {
            color: white;
            font-family: Verdana;
            font-size: 12px; 
        }
        .TextBlack11 {
            color: #003366;
            font-family: Verdana;
            font-size: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updateTeamPanel" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <table width="450px" border="0" bgcolor="#003366" cellspacing="3" cellpadding="3" align="center" 
            style="margin-top:-3em; margin-left: -4em; left: 40%; top:30%;position:absolute; padding-bottom: 20px">
                <tr>
                    <td colspan="2" style="text-align: center; padding: 15px;">
                        <span style="color: #ffffff; font-weight: bold; font-family: Verdana; font-size: 18pt;">Web Service Administration</span>
                        <br/>
                        <br/>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" class="TextBlack12">
                        Username
                    </td>
                    <td>
                        <asp:TextBox ID="tbUsername" class="TextBlack11" Width="100" MaxLength="50" runat="server"
                            ErrorMessage="Username is required." ToolTip="Username is required."></asp:TextBox><asp:Label
                                ID="lbUserRequired" Visible="False" CssClass="asteric" runat="server">*</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" class="TextBlack12">
                        Password
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="tbPassword" TextMode="Password" ToolTip="Password is required."
                            ErrorMessage="Password is required." class="TextBlack11" Width="100" MaxLength="50"></asp:TextBox><asp:Label
                                ID="lbPwdRequired" Visible="False" CssClass="asteric" runat="server">*</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; margin-top: 10px">
                        <asp:Button runat="server" ID="btnLogin" ForeColor="#003366" Font-Names="Verdana" Font-Size="14px" BackColor="#ffffff" Text="Login" OnClientClick="clearLabel();"
                            OnClick="btnLogin_Click" />
                        <asp:Button runat="server" ID="btnReset" ForeColor="#003366" Font-Names="Verdana" Font-Size="14px" BackColor="#ffffff" Text="Reset" OnClick="btnReset_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <div style="filter: progid:DXImageTransform.Microsoft.Alpha(opacity=70);">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="Styles/images/loader.gif"></asp:Image><br />
                                    <asp:Label ID="lblUpdateProgress" runat="server" Font-Size="12px" ForeColor="#ffffff" Font-Names="Verdana"
                                        Text="Please wait while authenticating your account..."></asp:Label>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:Label ID="lbError" CssClass="TextBlack12" Visible="False" runat="server">Your login attempt was not successful. Please try again.</asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
