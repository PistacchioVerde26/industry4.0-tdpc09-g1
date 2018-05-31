<%@ Page Title="" Language="C#" MasterPageFile="~/commerciale_gen.Master" AutoEventWireup="true" CodeBehind="avanzamento.aspx.cs" Inherits="Industry4_camerana_gruppo1.avanzamento" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel class="container" runat="server" ID="pnl_Ordini">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="upd_Lavorazioni" runat="server">
            <ContentTemplate>
                <div class="row" style="margin-bottom: 20px">
                    <div class="col">
                        <div class="card scrollable">
                            <div class="card-body form-group text-center">
                                <h5 class="card-title">
                                    <asp:Label for="tbl_Ordini" ID="lbl_Title" runat="server">Ordini inseriti</asp:Label>
                                </h5>
                                <asp:Table ID="tbl_Ordini" CssClass="table table-hover table-sm" runat="server"></asp:Table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 30px">
                    <div class="col">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">
                                    <asp:Label ID="lbl_OrderDetails" runat="server"></asp:Label>
                                </h5>
                                <asp:Table CssClass="table table-light table-sm" ID="tbl_OrderDetails" runat="server"></asp:Table>
                            </div>
                        </div>

                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>


</asp:Content>
