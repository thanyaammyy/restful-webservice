<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="Utility.aspx.cs" Inherits="WebserviceAdmin.Utility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#datepicker").datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function (dateText, inst) {
                    document.getElementById("<%= hiddenDate.ClientID %>").value = dateText;
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerMenuLabel">
        Utility</div>
    <table>
        <tr>
            <td>
               <span class="BlueText">Date</span> 
            </td>
            <td>
                <input type="text" id="datepicker"/>
                <asp:label Visible="False" id="lbStar" runat="server" class="BlueText" >*</asp:label>
                <asp:HiddenField ID="hiddenDate" runat="server"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label CssClass="BlueText" runat="server" ID="lbTicks"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button runat="server" ID="btnConvert" Text="Convert" OnClick="btnConvert_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:label id="lbError" runat="server" Visible="False" style="color:red">Please select date first!</asp:label>
            </td>
        </tr>
    </table>
</asp:Content>
