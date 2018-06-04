<%@ Page Title="" Language="C#" MasterPageFile="~/commerciale_gen.Master" AutoEventWireup="true" CodeBehind="ordiniInseriti.aspx.cs" Inherits="Industry4_camerana_gruppo1.ordiniInseriti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="1000"></asp:Timer>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col center-block-block text-center">
                        <h4>Nuovi ordini</h4>
                        <asp:Table ID="tblOdini" runat="server" CssClass="table table-hover" BorderWidth="1px" CellPadding="1" CellSpacing="1" GridLines="Both" HorizontalAlign="Center"></asp:Table>
                    </div>
                </div>

                <div class="row">
                    <div class="col center-block-block text-center">
                        <h4>Ordini in lavorazione</h4>
                        <asp:CheckBox ID="cbNascondiOK" AutoPostBack="true" Text="Nascondi ordini eseguiti" TextAlign="Right" Checked="false" runat="server" OnCheckedChanged="cbNascondiOK_CheckedChanged" />
                        <asp:Table ID="tblOdiniLavoro" runat="server" CssClass="table table-hover" BorderWidth="1px" CellPadding="1" CellSpacing="1" GridLines="Both" HorizontalAlign="Center"></asp:Table>
                    </div>
                </div>
            </ContentTemplate>

            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>

    </div>
</asp:Content>
