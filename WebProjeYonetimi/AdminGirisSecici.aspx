<%@ Page Title="" Language="C#" MasterPageFile="~/anaMasterPage.master" AutoEventWireup="true" CodeFile="AdminGirisSecici.aspx.cs" Inherits="AdminGirisSecici" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .abc {
            display: flex;
            justify-content: center;
            align-items: center;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <form runat="server">
        <section class="page-contain">
            <div class="contain">                
                <div class="page-right">
                    <div class="button-container">
                        <div class="button-container-top" style="margin-top:40px;">
                            <div class="tarlaUrunleri" style="margin-right: 35px;">
                                <asp:ImageButton ID="ImageButton1" runat="server" src="img/tarla_urunleri.jpg" OnClick="BtnTarlaUrunleriGiris_Click" />
                                <br />
                                <br />
                                <div class="abc">
                                    <asp:Button ID="btnTarlaUrunleriGiris" runat="server" Text="Tarla Ürünleri Girişi" class="button-default" OnClick="BtnTarlaUrunleriGiris_Click" />
                                </div>
                            </div>

                            <div class="meyve" style="margin-right: 35px;">
                                <asp:ImageButton ID="ImageButton2" runat="server" src="img/meyve.jpg" OnClick="BtnMeyveGirisi_Click" />
                                <br />
                                <br />
                                <div class="abc">
                                    <asp:Button ID="btnMeyveGirisi" runat="server" Text="Meyve girişi" class="button-default" OnClick="BtnMeyveGirisi_Click" />
                                </div>
                            </div>

                            <div class="hayvan" style="margin-right: 35px;">
                                <asp:ImageButton ID="ImageButton3" runat="server" src="img/hayvan.jpg" OnClick="BtnHayvanGirisi_Click" />
                                <br />
                                <br />
                                <div class="abc">
                                    <asp:Button ID="btnHayvanGirisi" runat="server" Text="Hayvan girişi" class="button-default" OnClick="BtnHayvanGirisi_Click" />
                                </div>
                            </div>

                            <div class="nufusYuzolcumuVeTarimalani" style="margin-right: 35px;">
                                <div class="button-container-bottom">
                                    <asp:ImageButton ID="ImageButton4" runat="server" src="img/tarim_alani.jpg" Style="margin-left: 25px;" OnClick="BtnNufusYuzolcumuveTarimalaniGirisi_Click" />
                                    <br />
                                    <br />
                                    <div class="abc">
                                        <asp:Button ID="btnNufusYuzolcumuveTarimalaniGirisi" runat="server" Text="Nüfus Yüzölçümü ve tarım alanı girişi" class="button-default" OnClick="BtnNufusYuzolcumuveTarimalaniGirisi_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="" style="margin-right: 35px;">
                                <asp:ImageButton ID="ImageButton5" runat="server" src="img/sebze.jpg" OnClick="btnSebzeGirisi_Click" />
                                <br />
                                <br />
                                <div class="abc">
                                    <asp:Button ID="btnSebzeGirisi" runat="server" Style="" Text="Sebze Girişi" CssClass="button-default" OnClick="btnSebzeGirisi_Click" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </section>

    </form>
</asp:Content>

