<%@ Page Title="" Language="C#" MasterPageFile="~/generic.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/login.css" rel="stylesheet" />
    <script src="js/login.js"></script>
    <div class="wrapper">
        <form class="login">
            <p class="title">Log in</p>
            <input type="text" placeholder="Username" autofocus />
            <i class="fa fa-user"></i>
            <input type="password" placeholder="Password" />
            <i class="fa fa-key"></i>
            <a href="#">Forgot your password?</a>
            <button>
                <i class="spinner"></i>
                <span class="state">Log in</span>
            </button>
        </form>
    </div>

    <%--<div class="container">
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
    </div>--%>
</asp:Content>
