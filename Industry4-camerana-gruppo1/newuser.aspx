<%@ Page Title="" Language="C#" MasterPageFile="~/commerciale_gen.Master" AutoEventWireup="true" CodeBehind="newuser.aspx.cs" Inherits="Industry4_camerana_gruppo1.newuser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-4 offset-4">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title text-center">NUOVO UTENTE</h5>
                        <div class="form-group">
                            <label for="txt_Nome">Nome utente</label>
                            <asp:TextBox ID="txt_Nome" CssClass="form-control" runat="server" placeholder="Inserisci un nome utente"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txt_Password">Password</label>
                            <asp:TextBox ID="txt_Password" TextMode="password" CssClass="form-control" runat="server" placeholder="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="drp_Ruolo">Ruolo</label>
                            <asp:DropDownList ID="drp_Ruolo" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <asp:Button ID="btn_AddNewUser" class="btn btn-primary" runat="server" Text="Inserisci" OnClick="btn_AddNewUser_Click" />
                        <asp:Panel Style="margin-top: 10px" runat="server" ID="pnl_Alert" CssClass="alert alert-danger">
                            <asp:Label ID="lbl_Alert" runat="server" Text="Label"></asp:Label>
                        </asp:Panel>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
