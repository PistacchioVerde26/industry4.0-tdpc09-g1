<%@ Page Title="" Language="C#" MasterPageFile="~/commerciale_gen.master" AutoEventWireup="true" CodeFile="nuovorinde.aspx.cs" Inherits="nuovorinde" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/Gadget.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="mainContainer">
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
        </div>
</asp:Content>

