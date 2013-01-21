<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Property.aspx.cs" Inherits="WebserviceAdmin.Property" %>
<%@ Register TagPrefix="cc1" Namespace="Trirand.Web.UI.WebControls" Assembly="Trirand.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        var lastSelection;

        function editRow(id) {
            if (id && id !== lastSelection) {
                var grid = jQuery("#<%= JqgridProperty.ClientID %>");
                grid.restoreRow(lastSelection);
                grid.editRow(id, true);
                lastSelection = id;
            }
        }          
       
       </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerMenuLabel">
        Property</div>
    <asp:UpdatePanel ID="updatepanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <cc1:JQGrid ID="JqgridProperty" AutoWidth="True" runat="server" Height="80%" 
                onrowadding="JqgridProperty_RowAdding" onrowdeleting="JqgridProperty_RowDeleting" 
                onrowediting="JqgridProperty_RowEditing" oninit="JqgridProperty_Init" >
                <Columns>
                    <cc1:JQGridColumn DataField="PropertyId" Searchable="False" PrimaryKey="True" Width="55" Visible="False" />
                    <cc1:JQGridColumn HeaderText="Property Code" DataField="PropertyCode" Editable="True"
                        TextAlign="Center">
                        <EditClientSideValidators>
                            <cc1:RequiredValidator />
                        </EditClientSideValidators>
                    </cc1:JQGridColumn>
                    <cc1:JQGridColumn HeaderText="Property Name" DataField="PropertyName" Editable="True"
                        TextAlign="Center" />
                </Columns>
                <AddDialogSettings CloseAfterAdding="True" />
                <EditDialogSettings CloseAfterEditing="True" />
                <ToolBarSettings ShowEditButton="True" ShowDeleteButton="true" ShowAddButton="True"
                    ShowRefreshButton="True" ShowSearchButton="True" />
                <AppearanceSettings ShowRowNumbers="true" HighlightRowsOnHover="True"/>
                <PagerSettings PageSize="20" />
                <DeleteDialogSettings LeftOffset="497" TopOffset="241"></DeleteDialogSettings>
                <AddDialogSettings Width="300" Modal="True" TopOffset="250" LeftOffset="500" Height="300"
                    CloseAfterAdding="True" Caption="Add Property" ClearAfterAdding="True"></AddDialogSettings>
                <EditDialogSettings Width="300" Modal="True" TopOffset="250" LeftOffset="500" Height="300"
                    CloseAfterEditing="True" Caption="Edit Property"></EditDialogSettings>
                <ClientSideEvents RowDoubleClick="editRow" />
            </cc1:JQGrid>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
