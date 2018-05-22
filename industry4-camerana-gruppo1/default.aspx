<%@ Page Title="" Language="C#" MasterPageFile="~/generic.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">

        <div class="row">
            <div class="col text-center">
                <h3 runat="server" id="txt_welcomeMessage">Bentornato l Lugi - sei un Amministratore</h3>
            </div>
        </div>

        <div class="row">
            <div class="col" runat="server" id="div_Commerciale">

                <div class="card text-center">
                    <asp:ImageButton ID="btn_Commerciale" CssClass="mx-auto d-block width-70" ImageUrl="~/imgs/icComm.png" runat="server" />
                    <div class="card-title">
                        <span>Commerciale</span>
                    </div>
                </div>

            </div>
        </div>
        <div class="row">
            <div class="col" runat="server" id="div1">
                <div class="card text-center">
                    <asp:ImageButton ID="btn_Materiale" CssClass="mx-auto d-block width-70" ImageUrl="~/imgs/icmateriale.png" runat="server" />
                    <div class="card-title">
                        <span>Selezione materiale</span>
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
                    <asp:ImageButton ID="btn_Etichettatura" CssClass="mx-auto d-block width-70" ImageUrl="~/imgs/etichettatura.png" runat="server" />
                    <div class="card-title">
                        <span>Etichettatura</span>
                    </div>
                </div>
            </div>
            <div class="col" runat="server" id="div_Colorazione">
                <div class="card text-center">
                    <asp:ImageButton ID="Colorazione" CssClass="mx-auto d-block width-70" ImageUrl="~/imgs/colorazione.png" runat="server" />
                    <div class="card-title">
                        <span>Colorazione</span>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>

