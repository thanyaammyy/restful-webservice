<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="Users.aspx.cs" Inherits="WebserviceAdmin.Users" %>

<%@ Register TagPrefix="cc1" Namespace="Trirand.Web.UI.WebControls" Assembly="Trirand.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        var lastSelection;

        function editRow(id) {
            if (id && id !== lastSelection) {
                var grid = jQuery("#<%= JqgridUser.ClientID %>");
                grid.restoreRow(lastSelection);
                grid.editRow(id, true);
                lastSelection = id;
            }
        }

        function validateIp(value, column) {
            if (value) {
                var pattern = /\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b/;
                if (pattern.test(value))
                    return [true, ""];
                else
                    return [false, "Please enter a valid IP format"];
            }
            else return [true, ""];
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerMenuLabel">
        User</div>
    <asp:UpdatePanel ID="updatepanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="ddlProperty" ToolTip="Property is required." DataSourceID="PropertyDataSource"
                DataValueField="PropertyId" DataTextField="PropertyCode" Width="90" runat="server">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="PropertyDataSource" DataObjectTypeName="DataModelLib.Property"
                SelectMethod="ListProperty" TypeName="DataModelLib.Page.PropertyHelper" runat="server">
            </asp:ObjectDataSource>
            <asp:DropDownList ID="ddlDepartment" ToolTip="Department is required." DataSourceID="DepartmentDataSource"
                DataValueField="DepartmentId" DataTextField="DepartmentCode" Width="90" runat="server">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="DepartmentDataSource" DataObjectTypeName="DataModelLib.Department"
                SelectMethod="ListDepartment" TypeName="DataModelLib.Page.DepartmentHelper" runat="server">
            </asp:ObjectDataSource>
            <cc1:JQGrid ID="JqgridUser" AutoWidth="True" runat="server" Height="80%" OnRowAdding="JqgridUser_RowAdding"
                OnRowDeleting="JqgridUser_RowDeleting" OnRowEditing="JqgridUser_RowEditing" OnInit="JqgridUser_Init">
                <Columns>
                    <cc1:JQGridColumn DataField="UserId" Searchable="False" PrimaryKey="True" Width="55"
                        Visible="False" />
                    <cc1:JQGridColumn HeaderText="Property" DataField="PropertyCode" Editable="True"
                        EditorControlID="ddlProperty" EditType="DropDown" TextAlign="Left">
                        <EditClientSideValidators>
                            <cc1:RequiredValidator />
                        </EditClientSideValidators>
                    </cc1:JQGridColumn>
                    <cc1:JQGridColumn HeaderText="Department" DataField="DepartmentCode" Editable="True"
                        EditType="DropDown" EditorControlID="ddlDepartment" TextAlign="Left">
                        <EditClientSideValidators>
                            <cc1:RequiredValidator />
                        </EditClientSideValidators>
                    </cc1:JQGridColumn>
                    <cc1:JQGridColumn HeaderText="Username" DataField="Username" Editable="True" TextAlign="Left">
                        <EditClientSideValidators>
                            <cc1:RequiredValidator />
                        </EditClientSideValidators>
                    </cc1:JQGridColumn>
                    <cc1:JQGridColumn HeaderText="Password" DataField="Password" Editable="True" TextAlign="Left" >
                        <EditClientSideValidators>
                            <cc1:RequiredValidator />
                        </EditClientSideValidators>
                    </cc1:JQGridColumn>
                    <cc1:JQGridColumn HeaderText="IP" DataField="IP" Editable="True" TextAlign="Left">
                        <EditClientSideValidators>
                            <cc1:CustomValidator ValidationFunction="validateIp" />
                        </EditClientSideValidators>
                    </cc1:JQGridColumn>
                    <cc1:JQGridColumn HeaderText="Status" DataField="StatusLabel" Editable="True" EditType="DropDown"
                        EditValues="0:InActive;1:Active" TextAlign="Center" />
                </Columns>
                <AddDialogSettings CloseAfterAdding="True" />
                <EditDialogSettings CloseAfterEditing="True" />
                <ToolBarSettings ShowEditButton="True" ShowDeleteButton="true" ShowAddButton="True"
                    ShowRefreshButton="True" ShowSearchButton="True" />
                <AppearanceSettings ShowRowNumbers="true" HighlightRowsOnHover="True" />
                <PagerSettings PageSize="20" />
                <DeleteDialogSettings LeftOffset="497" TopOffset="241"></DeleteDialogSettings>
                <AddDialogSettings Width="300" Modal="True" TopOffset="250" LeftOffset="500" Height="300"
                    CloseAfterAdding="True" Caption="Add User" ClearAfterAdding="True"></AddDialogSettings>
                <EditDialogSettings Width="300" Modal="True" TopOffset="250" LeftOffset="500" Height="300"
                    CloseAfterEditing="True" Caption="Edit User"></EditDialogSettings>
                <ClientSideEvents RowDoubleClick="editRow" />
            </cc1:JQGrid>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
