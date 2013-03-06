<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="Service.aspx.cs" Inherits="WebserviceAdmin.Service" %>

<%@ Register TagPrefix="cc1" Namespace="Trirand.Web.UI.WebControls" Assembly="Trirand.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        var lastSelection;

        function editRow(id) {
            if (id && id !== lastSelection) {
                var grid = jQuery("#<%= JqgridService.ClientID %>");
                grid.restoreRow(lastSelection);
                grid.editRow(id, true);
                lastSelection = id;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerMenuLabel">
        Service</div>
    <asp:UpdatePanel ID="updatepanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <cc1:JQGrid ID="JqgridService" AutoWidth="True" runat="server" Height="80%" OnRowAdding="JqgridService_RowAdding"
                OnRowDeleting="JqgridService_RowDeleting" OnRowEditing="JqgridService_RowEditing"
                OnInit="JqgridService_Init">
                <Columns>
                    <cc1:JQGridColumn DataField="ServiceId" Searchable="False" PrimaryKey="True" Width="55"
                        Visible="False" />
                    <cc1:JQGridColumn HeaderText="Name" DataField="Servicename" Editable="True" TextAlign="Center">
                        <EditClientSideValidators>
                            <cc1:RequiredValidator />
                        </EditClientSideValidators>
                    </cc1:JQGridColumn>
                    <cc1:JQGridColumn HeaderText="URL" DataField="ServiceUrl" Editable="True" TextAlign="Left">
                        <EditClientSideValidators>
                            <cc1:RequiredValidator />
                        </EditClientSideValidators>
                    </cc1:JQGridColumn>
                    <cc1:JQGridColumn HeaderText="Description" DataField="Description" Editable="True" TextAlign="Left">
                        <EditClientSideValidators>
                            <cc1:RequiredValidator />
                        </EditClientSideValidators>
                    </cc1:JQGridColumn>
                </Columns>
                <AddDialogSettings CloseAfterAdding="True" />
                <EditDialogSettings CloseAfterEditing="True" />
                <ToolBarSettings ShowEditButton="True" ShowDeleteButton="true" ShowAddButton="True"
                    ShowRefreshButton="True" ShowSearchButton="True" />
                <AppearanceSettings ShowRowNumbers="true" HighlightRowsOnHover="True" />
                <PagerSettings PageSize="20" />
                <DeleteDialogSettings LeftOffset="497" TopOffset="241"></DeleteDialogSettings>
                <AddDialogSettings Width="300" Modal="True" TopOffset="250" LeftOffset="500" Height="300"
                    CloseAfterAdding="True" Caption="Add Service" ClearAfterAdding="True"></AddDialogSettings>
                <EditDialogSettings Width="300" Modal="True" TopOffset="250" LeftOffset="500" Height="300"
                    CloseAfterEditing="True" Caption="Edit Service"></EditDialogSettings>
                <ClientSideEvents RowDoubleClick="editRow" />
            </cc1:JQGrid>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
