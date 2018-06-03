<%@ Page Title="" Language="C#" MasterPageFile="~/commerciale_gen.Master" AutoEventWireup="true" CodeBehind="nuovordine.aspx.cs" Inherits="Industry4_camerana_gruppo1.nuovordine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/Gadget.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="css/tool.css" rel="stylesheet" />
    <script src="js/tool.js"></script>

    <div class="container" style="margin-top: 5px;">
        <div class="row">
            <div class="col-md-3">
                <div class="row">
                    <div class="col">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">MATERIALE</h5>
                                <asp:DropDownList ID="drp_Materiale" CssClass="form-control" runat="server" AutoPostBack="false" onchange="ChangeMateriale(this)"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">FORO</h5>
                                <asp:DropDownList ID="drp_Foro" CssClass="form-control" runat="server" AutoPostBack="false" onchange="ChangeForo(this)"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body" style="position: relative">
                        <div class="card" runat="server" id="tool_card">
                            <img src="imgs/foro.png" class="foro-5" id="img_foro" />
                            <div class="etichetta">
                                <span class="text-center h6" id="lbl_etichetta"></span>
                            </div>
                            <svg version="1.1" id="Livello_1" x="0px" y="0px" viewBox="0 0 802.7 309" style="enable-background: new 0 0 802.7 309;" xml:space="preserve">
                                <g id="layer101">
                                    <path d="M636.5,266l-43.3-39.6l-253.5,34.8L86.3,295.9L49,278.7l-37.2-17.2l-3.9-52.2c-2.1-28.6-3.7-53.1-3.5-54.4
                        c0.3-1.5,11.6-12.2,33.9-31.8l33.5-29.6L331.3,94l259.5,0.6l30.9-39.9l31-39.8l4.5-0.5c10-1.2,137-10.1,137.5-9.6
                        c0.3,0.2,0.8,66.4,1.2,147l0.7,146.4l-55.4,3.8c-30.5,2.1-56.7,3.7-58.4,3.7C680.3,305.6,672.4,298.8,636.5,266z M743.8,293l47-1.7
                        l-2.7-116.5c-1.5-64.2-2.7-125.3-2.7-135.8l-0.1-19.3h-2.7c-1.6-0.1-30.3,1.6-63.8,3.7l-61,3.7L627.3,64
                        c-16.8,20.3-31.3,37.4-32.2,38c-1.7,1.1-1.8,4.9-1.7,57.2v56l46.2,39.7l46.2,39.7l5.5,0.1C694.3,294.7,718,294,743.8,293z
                         M576.9,217.7c1.2,0,1.4-9.1,1.4-57v-57h-11.2c-6.2-0.1-119.5,0.9-251.8,2.2l-240.5,2.2L45,131.9c-22.7,18.2-29.7,24.4-29.7,26.1
                        c-0.1,1.2,1.4,24,3.2,50.7l3.2,48.5l32.1,14.7c17.6,8,33.1,14.7,34.4,14.7c1.3,0.1,111.5-15.4,244.9-34.4" />
                                </g>
                                <polygon id="manico" class="metal" points="578.3,103.7 580,219.3 88.2,286.6 21.7,257.2 15.3,155.2 74.8,108.1 " />
                                <path id="inserto" d="M785.3,19.7l-127.5,7.4l-67.3,76.6v113.8l95.3,77.1l105-3.3L785.3,19.7z M711.5,267.8l-54.2-59.5l30.8-48.9
                    l-33.2-36.1l47.7-68.6l58-8.2l1,220.7L711.5,267.8z" />
                                <path d="M676.5,244.2c-17-18.7-31-34.4-31.2-35c-0.2-0.5,6.7-12.3,15.4-26.2l15.8-25.2l-17.2-16.6c-9.5-9.1-17.2-17.1-17.2-17.7
                    c0-1.1,48.1-75.7,50.4-78.1c1-1,65.7-9.2,73.2-9.2h2.4v118.4v118.5l-4.2,0.5c-7.7,1.1-48.6,4.6-52.6,4.6
                    C707.4,278.2,707,277.8,676.5,244.2z M761.3,157c-0.1-60.6-0.5-110.4-0.7-110.6c-0.2-0.3-13.4,1.5-29.2,3.9l-28.8,4.3l-8.1,11.5
                    c-4.4,6.4-15.1,21.8-23.8,34.4l-15.8,22.7l16.6,17.5c9.1,9.6,16.6,17.9,16.6,18.6c0,0.6-6.6,11.8-14.6,25l-14.6,23.8l26.3,29.8
                    l26.3,29.8l25.1-0.3l25-0.3L761.3,157z" />
                            </svg>

                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="row">
                    <div class="col">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">COLORE INSERTO</h5>
                                <asp:DropDownList ID="drp_Colore" CssClass="form-control" runat="server" AutoPostBack="false" onchange="ChangeInserto(this)"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">ETICHETTA</h5>
                                <asp:TextBox ID="txt_Etichetta" placeholder="Testo etichetta" CssClass="form-control" runat="server" onkeydown="WriteText(this)" onkeyup="WriteText(this)"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col center-block text-center">
                <%--<label for="txt_Qta">QTA</label>
                <asp:TextBox ID="txt_Qta" CssClass="" runat="server"></asp:TextBox>--%>
                <asp:Button ID="btn_Inserisci" runat="server" CssClass="btn btn-primary d-inline" Style="margin-top: 10px" Text="Inserisci" OnClick="btn_Inserisci_Click" />
                <asp:Panel runat="server" ID="pnl_Result" CssClass="alert alert-success alert-dismissible">
                    <asp:Label ID="lbl_Result" runat="server"><strong>OK!</strong> Ordine inserito corretamente.</asp:Label>
                </asp:Panel>
            </div>
        </div>


    </div>

    <%--<div class="mainContainer">
            <div class="lato">
                <div class="testoCentro">
                    <h2>Personalizza ilgadget e premi il tasto "Aggiungi" per salvare l'ordine.</h2>
                </div>
                <div>
                    <div class="g_container">
                        <div class="center">
                                <asp:Label ID="lblEtichetta" runat="server" Text="Selezionare il materiale:"></asp:Label>
                                <asp:RadioButtonList ID="rblMateriale" runat="server">
                                    <asp:ListItem Text="Ferro" Value="ferro" Selected="True" />
                                    <asp:ListItem Text="Alluminio" Value="alluminio" Selected="False" />
                                </asp:RadioButtonList>
                            </div>
                       
                        <div class="g_image">
                            <div class="g_2optional floatL">
                                <asp:Label ID="lblForo" runat="server" Text="Selezionare il diametro di foro:"></asp:Label>
                                <asp:RadioButtonList ID="rblDiametro" runat="server">
                                    <asp:ListItem Text="10 mm" Value="10" Selected="True" />
                                    <asp:ListItem Text="20 mm" Value="20" Selected="False" />
                                </asp:RadioButtonList>
                            </div>
                            <div class="floatL">
                                <asp:Image ID="Image1" class="image1" runat="server" src="imgs/Immagine.png" />
                            </div>
                             <div class="g_2optional floatL">
                            <asp:Label ID="lblColore" runat="server" Text="Selezionare il colore:"></asp:Label>
                            <asp:RadioButtonList ID="rblColore" runat="server">
                                <asp:ListItem Text="Rosso" Value="rosso" Selected="True" />
                                <asp:ListItem Text="Nero" Value="nero" Selected="False" />
                            </asp:RadioButtonList>
                        </div>
                        </div>
                        <div class="center2">
                            <div>
                                <asp:Label ID="lbl" runat="server" Text="Scrivi il testo da incidere:"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox ID="tbTesto" runat="server"></asp:TextBox>
                            </div>

                        </div>
                        <div class="testoCentro marginBottom20">
                            <asp:Button ID="btnAggiungi" runat="server" Text="Aggiungi" OnClick="btnAggiungi_Click" />
                        </div>
                    </div>


                </div>
            </div>
            <div class="lato">
                <asp:Table ID="tblOrdini" runat="server"></asp:Table>
            </div>
        </div>--%>
    <%-- ELEMENTS COLOR --%>
    <svg xmlns="http://www.w3.org/2000/svg" version="1.1">
        <defs>
            <linearGradient spreadMethod="pad" id="acciaio" x1="38%" y1="129%" x2="0%" y2="0%">
                <stop offset="0%" style="stop-color: rgb(92, 87, 87); stop-opacity: 1;" />
                <stop offset="100%" style="stop-color: rgb(255, 255, 255); stop-opacity: 1;" />
            </linearGradient>
        </defs>
    </svg>
    <svg xmlns="http://www.w3.org/2000/svg" version="1.1">
        <defs>
            <linearGradient spreadMethod="pad" id="plastica" x1="0%" y1="100%" x2="0%" y2="0%">
                <stop offset="0%" style="stop-color: rgb(111, 115, 118); stop-opacity: 1;" />
                <stop offset="84%" style="stop-color: rgb(32, 151, 194); stop-opacity: 1;" />
                <stop offset="100" style="stop-color: rgb(32, 151, 194); stop-opacity: 1;" />
            </linearGradient>
        </defs>
        <rect width="300" height="300" y="0" x="0" fill="url(#gradient)" />
    </svg>


</asp:Content>
