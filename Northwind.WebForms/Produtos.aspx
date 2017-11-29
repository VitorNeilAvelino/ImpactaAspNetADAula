<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="Northwind.WebForms.Produtos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Produtos</h2>
    <div class="row">
        <div class="col-lg-12">
            <asp:RadioButtonList 
                ID="criterioRadioButtonList"
                runat="server"
                RepeatDirection="Horizontal"
                RepeatLayout="Flow">
                <asp:ListItem Text="Categoria" Value="0" />
                <asp:ListItem Text="Fornecedor" Value="1" />
            </asp:RadioButtonList>
            <asp:MultiView ID="criterioMultiview" ActiveViewIndex="0" runat="server">
                <asp:View id="categoriaView" runat="server">
                    <asp:DropDownList 
                        ID="categoriaDrop" 
                        runat="server"
                        DataTextField="CategoryName"
                        DataValueField="CategoryID"
                        DataSourceID="categoriaDataSource"
                        AppendDataBoundItems="true">
                        <asp:ListItem Text="Selecione uma categoria" 
                            Value="0" />                        
                    </asp:DropDownList>
                    <asp:ObjectDataSource 
                        id="categoriaDataSource"
                        runat="server"
                        TypeName="Northwind.Repositorios.SqlServer.Ado.CategoriaRepositorio"
                        SelectMethod="Selecionar" /> 
                </asp:View>
                <asp:View ID="fornecedorView" runat="server"></asp:View>
            </asp:MultiView>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            grid
        </div>
    </div>
</asp:Content>
