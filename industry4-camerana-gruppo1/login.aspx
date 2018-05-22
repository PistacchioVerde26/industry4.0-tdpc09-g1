<%@ Page Title="" Language="C#" MasterPageFile="~/generic.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <div class="row">
            <div class="col-md-4 offset-4">
                <div class="card text-center" style="width: 20rem;">
                    <h4 class="card-title">Login</h4>
                    <div class="card-body">
                        <div class="form-group">
                            <asp:TextBox ID="txt_Utente" CssClass="form-control" placeholder="Utente" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txt_Password" CssClass="form-control" placeholder="Password" TextMode="password" runat="server"></asp:TextBox>
                            <asp:Button ID="btn_Login" CssClass="btn btn-primary" runat="server" Text="Entra" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
