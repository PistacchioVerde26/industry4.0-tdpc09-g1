<%@ Page Title="" Language="C#" MasterPageFile="~/commerciale_gen.Master" AutoEventWireup="true" CodeBehind="assegnapostazione.aspx.cs" Inherits="Industry4_camerana_gruppo1.assegnapostazione" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-4 offset-4">
                <div class="card">
                    <div class="card-body form-group">
                        <h5 class="card-title">
                            <label for="drp_Macchinisti">Seleziona Macchinista</label>
                        </h5>
                        <asp:DropDownList CssClass="form-control" ID="drp_Macchinisti" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drp_Macchinisti_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
    </div>
<%--    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <div class="container" runat="server" ID="pnl_Postazioni" style="margin-top: 20px">
            </div>
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>


</asp:Content>
