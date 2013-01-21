<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="WebserviceAdmin.Department" %>
<%@ Register TagPrefix="cc1" Namespace="Trirand.Web.UI.WebControls" Assembly="Trirand.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        var lastSelection;

        function editRow(id) {
            if (id && id !== lastSelection) {
                var grid = jQuery("#<%= JqgridDept.ClientID %>");
                grid.restoreRow(lastSelection);
                grid.editRow(id, true);
                lastSelection = id;
            }
        }          
       
       </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerMenuLabel">
        Department</div>
    <asp:UpdatePanel ID="updatepanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <cc1:JQGrid ID="JqgridDept" AutoWidth="True" runat="server" Height="80%" 
                onrowadding="JqgridDept_RowAdding" onrowdeleting="JqgridDept_RowDeleting" 
                onrowediting="JqgridDept_RowEditing" oninit="JqgridDept_Init" >
                <Columns>
                    <cc1:JQGridColumn DataField="DepartmentId" Searchable="False" PrimaryKey="True" Width="55" Visible="False" />
                    <cc1:JQGridColumn HeaderText="Department Code" DataField="DepartmentCode" Editable="True"
                        TextAlign="Center">
                        <EditClientSideValidators>
                            <cc1:RequiredValidator />
                        </EditClientSideValidators>
                    </cc1:JQGridColumn>
                    <cc1:JQGridColumn HeaderText="Department Name" DataField="DepartmentName" Editable="True"
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
                    CloseAfterAdding="True" Caption="Add Department" ClearAfterAdding="True"></AddDialogSettings>
                <EditDialogSettings Width="300" Modal="True" TopOffset="250" LeftOffset="500" Height="300"
                    CloseAfterEditing="True" Caption="Edit Department"></EditDialogSettings>
                <ClientSideEvents RowDoubleClick="editRow" />
            </cc1:JQGrid>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
