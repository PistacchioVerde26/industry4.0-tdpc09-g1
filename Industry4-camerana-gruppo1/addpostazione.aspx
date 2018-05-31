<%@ Page Title="" Language="C#" MasterPageFile="~/commerciale_gen.Master" AutoEventWireup="true" CodeBehind="addpostazione.aspx.cs" Inherits="Industry4_camerana_gruppo1.addpostazione" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-4 offset-4">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title text-center">NUOVA POSTAZIONE</h5>
                        <label for="txt_Password">Tag</label>
                        <asp:TextBox ID="txt_Tag" CssClass="form-control" runat="server" placeholder="TAG"></asp:TextBox>
                        <div class="form-group">
                            <label for="drp_Ruolo">Tipo</label>
                            <asp:DropDownList ID="drp_Tipo" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <asp:Button ID="btn_AddNewPostazione" class="btn btn-primary" runat="server" Text="Inserisci" OnClick="btn_AddNewPostazione_Click" />
                        <asp:Panel Style="margin-top: 10px" runat="server" ID="pnl_Alert" CssClass="alert alert-danger">
                            <asp:Label ID="lbl_Alert" runat="server" Text="Label"></asp:Label>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
