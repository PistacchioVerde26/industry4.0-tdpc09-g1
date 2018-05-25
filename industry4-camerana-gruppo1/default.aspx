<%@ Page Title="" Language="C#" MasterPageFile="~/generic.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container" id="container" runat="server">

        <%--<script src="js/default.js"></script>
        <link href="css/dimension.css" rel="stylesheet" />


        <div class="sfondo" style="background: black"></div>

        <div class="main">

            <div class="logo"><i class="far fa-gem fa-3x fa-fw "></i></div>
            <div class="riga"></div>

            <header class="header">

                <h1>DIMENSION</h1>
                <h2>
                    <a href="#">ADMINISTRATORE</a>
                    <br />
                    <a href="#">CLIENTE</a>.
                </h2>
            </header>

            <nav class="navbar">
                <ul>
                    <li>
                        <asp:ImageButton ID="btn_Commerciale" CssClass="mx-auto d-block width-70" ImageUrl="~/imgs/iccommerciale.png" runat="server" />
                        <div class="card-title">
                            <span>Commerciale</span>
                        </div>
                    </li>
                    <li>
                        <asp:ImageButton ID="btn_Materiale" CssClass="mx-auto d-block width-70" ImageUrl="~/imgs/icmateriale.png" runat="server" OnClick="btn_Materiale_Click" />
                        <div class="card-title">
                            <span>Materiale</span>
                        </div>
                    </li>
                    <li>
                        <asp:ImageButton ID="btn_Foratura" CssClass="mx-auto d-block width-70" ImageUrl="~/imgs/icforatura.png" runat="server" />
                        <div class="card-title">
                            <span>Foratura</span>
                        </div>

                    </li>
                    <li>
                        <asp:ImageButton ID="btn_Etichettatura" CssClass="mx-auto d-block width-70" ImageUrl="~/imgs/icetichettatura.png" runat="server" />
                        <div class="card-title">
                            <span>Etichettatura</span>
                        </div>
                    </li>
                    <li>
                        <asp:ImageButton ID="Colorazione" CssClass="mx-auto d-block width-70" ImageUrl="~/imgs/iccolore.png" runat="server" />
                        <div class="card-title">
                            <span>Colore</span>
                        </div>
                        >
                    </li>
                </ul>
            </nav>

        </div>

        <h3 runat="server" id="txt_welcomeMessage"></h3>--%>

        
      <div class="row">
            <div class="col text-center">
                <h3 runat="server" id="txt_welcomeMessage">Bentornato Luigi - sei un Amministratore</h3>
            </div>
        </div>
        <%--  
        <div class="row">
            <div class="col" runat="server" id="div_Commerciale">

                <div class="card text-center">
                    <asp:ImageButton ID="btn_Commerciale" CssClass="mx-auto d-block width-70" ImageUrl="~/imgs/iccommerciale.png" runat="server" />
                    <div class="card-title">
                        <span>Commerciale</span>
                    </div>
                </div>

            </div>
        </div>
        <div class="row">
            <div class="col" runat="server" id="div1">
                <div class="card text-center">
                    <asp:ImageButton ID="btn_Materiale" CssClass="mx-auto d-block width-70" ImageUrl="~/imgs/icmateriale.png" runat="server" OnClick="btn_Materiale_Click" />
                    <div class="card-title">
                        <span>Materiale</span>
                    </div>
                </div>
            </div>
            <div class="col" runat="server" id="div_Foratura">
                <div class="card text-center">
                    <asp:ImageButton ID="btn_Foratura" CssClass="mx-auto d-block width-70" ImageUrl="~/imgs/foratura.png" runat="server" />
                    <div class="card-title">
                        <span>Foratura</span>
                    </div>
                </div>
            </div>
            <div class="col" runat="server" id="div_Etichettatura">
                <div class="card text-center">
                    <asp:ImageButton ID="btn_Etichettatura" CssClass="mx-auto d-block width-70" ImageUrl="~/imgs/icetichettatura.png" runat="server" />
                    <div class="card-title">
                        <span>Etichettatura</span>
                    </div>
                </div>
            </div>
            <div class="col" runat="server" id="div_Colorazione">
                <div class="card text-center">
                    <asp:ImageButton ID="Colorazione" CssClass="mx-auto d-block width-70" ImageUrl="~/imgs/iccolore.png" runat="server" />
                    <div class="card-title">
                        <span>Colore</span>
                    </div>
                </div>
            </div>
        </div>--%>
    </div>

</asp:Content>

