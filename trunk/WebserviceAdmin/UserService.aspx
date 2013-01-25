<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UserService.aspx.cs" Inherits="WebserviceAdmin.UserService" %>
<%@ Register TagPrefix="cc1" Namespace="Trirand.Web.UI.WebControls" Assembly="Trirand.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        var lastSelection;

        function editRow(id) {
            if (id && id !== lastSelection) {
                var grid = jQuery("#<%= JqgridUserService.ClientID %>");
                grid.restoreRow(lastSelection);
                grid.editRow(id, true);
                lastSelection = id;
            }
        }

        function validateIp(value, column) {
            var pattern = /\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b/;
            if (value.indexOf(';') !== -1) {
                var ips = value.split(';');
                for (var i = 0; i < ips.length; i++) {
                    if (ips[i]) {
                        if (!pattern.test(ips[i]))
                            return [false, "Please enter a valid IP format"];
                    }
                }
                return [true, ""];
            }
            else {
                if (pattern.test(value))
                    return [true, ""];
                else
                    return [false, "Please enter a valid IP format"];
            }
        }
       </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerMenuLabel">
        Property</div>
    <asp:UpdatePanel ID="updatepanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
             <asp:DropDownList ID="ddlUser" ToolTip="User is required." DataSourceID="UserDataSource"
                DataValueField="UserId" DataTextField="Username" Width="90" runat="server">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="UserDataSource" DataObjectTypeName="DataModelLib.User"
                SelectMethod="ListUser" TypeName="DataModelLib.Page.UserHelper" runat="server">
            </asp:ObjectDataSource>
            <asp:DropDownList ID="ddlService" ToolTip="Service is required." DataSourceID="ServiceDataSource"
                DataValueField="ServiceId" DataTextField="ServiceName" Width="90" runat="server">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ServiceDataSource" DataObjectTypeName="DataModelLib.Service"
                SelectMethod="ListService" TypeName="DataModelLib.Page.ServiceHelper" runat="server">
            </asp:ObjectDataSource>
            <cc1:JQGrid ID="JqgridUserService" AutoWidth="True" runat="server" Height="80%" OnRowAdding="JqgridUserService_RowAdding"
                OnRowDeleting="JqgridUserService_RowDeleting" OnRowEditing="JqgridUserService_RowEditing" OnInit="JqgridUserService_Init">
                <Columns>
                    <cc1:JQGridColumn DataField="Id" Searchable="False" PrimaryKey="True" Width="55"
                        Visible="False" />
                    <cc1:JQGridColumn HeaderText="User" DataField="Username" Editable="True"
                        EditorControlID="ddlUser" EditType="DropDown" TextAlign="Left">
                        <EditClientSideValidators>
                            <cc1:RequiredValidator />
                        </EditClientSideValidators>
                    </cc1:JQGridColumn>
                    <cc1:JQGridColumn HeaderText="Service Name" DataField="ServiceName" Editable="True"
                        EditType="DropDown" EditorControlID="ddlService" TextAlign="Left">
                        <EditClientSideValidators>
                            <cc1:RequiredValidator />
                        </EditClientSideValidators>
                    </cc1:JQGridColumn>
                    <cc1:JQGridColumn HeaderText="Service Url" DataField="ServiceUrl" Editable="False" TextAlign="Left">
                    </cc1:JQGridColumn>
                    <cc1:JQGridColumn HeaderText="IP" DataField="IPs" Editable="True" TextAlign="Left">
                        <EditClientSideValidators>
                            <cc1:CustomValidator ValidationFunction="validateIp" />
                        </EditClientSideValidators>
                    </cc1:JQGridColumn>
                    <cc1:JQGridColumn HeaderText="Status" DataField="StatusLabel" Editable="True" EditType="DropDown"
                        EditValues="1:Active;0:InActive" TextAlign="Center" />
                </Columns>
                <AddDialogSettings CloseAfterAdding="True" />
                <EditDialogSettings CloseAfterEditing="True" />
                <ToolBarSettings ShowEditButton="True" ShowDeleteButton="true" ShowAddButton="True"
                    ShowRefreshButton="True" ShowSearchButton="True" />
                <AppearanceSettings ShowRowNumbers="true" HighlightRowsOnHover="True" />
                <PagerSettings PageSize="20" />
                <DeleteDialogSettings LeftOffset="497" TopOffset="241"></DeleteDialogSettings>
                <AddDialogSettings Width="300" Modal="True" TopOffset="250" LeftOffset="500" Height="300"
                    CloseAfterAdding="True" Caption="Add User Service" ClearAfterAdding="True"></AddDialogSettings>
                <EditDialogSettings Width="300" Modal="True" TopOffset="250" LeftOffset="500" Height="300"
                    CloseAfterEditing="True" Caption="Edit User Service"></EditDialogSettings>
                <ClientSideEvents RowDoubleClick="editRow" />
            </cc1:JQGrid>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
