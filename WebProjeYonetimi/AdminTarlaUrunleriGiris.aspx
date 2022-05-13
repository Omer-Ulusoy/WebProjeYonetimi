<%@ Page Title="" Language="C#" MasterPageFile="~/anaMasterPage.master" AutoEventWireup="true" CodeFile="AdminTarlaUrunleriGiris.aspx.cs" Inherits="AdminTarlaUrunleriGiris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <style>
        .ddlSehir {
            padding: 12px;
            width: 25%;
            outline: none;
            background: #f8edeb;
            border: 0px;
            border-radius: 8px;
        }

        .ddlYil {
            padding: 12px;
            width: 25%;
            outline: none;
            background: #f8edeb;
            border: 0px;
            border-radius: 8px;
        }       

        .veriGetir {
            padding: 12px;
            min-width: 25%;
            outline: none;
            background: #96ceb4;
            color: #484f4f;
            border: 0px;
            border-radius: 8px;
            margin-right: 25px
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <form runat="server">
        <asp:HiddenField ID="hfSehir" runat="server" ClientIDMode="Static"/>
        <asp:Label ID="lblSehir" runat="server" Visible="False"></asp:Label>
        <section class="page-contain">
            <div class="contain">
                <div class="mini-scaling-map">

                    <div id="sehir"></div>

                    <div id="map"></div>
                </div>

                <div class="contain">
                    <div class="login-form">
                        <h4>Tarla Ürünleri Giriş</h4>
                        <asp:DropDownList ID="ddlSehir" CssClass="ddlSehir" runat="server"></asp:DropDownList>
                        <br />
                        <asp:DropDownList ID="ddlYil" CssClass="ddlYil" runat="server"></asp:DropDownList>
                        <asp:TextBox ID="txtYesilOt" runat="server" placeholder="Yeşil Ot (Ton Olarak Girilecektir.)"></asp:TextBox>
                        <asp:TextBox ID="txtMisir" runat="server" placeholder="Mısır (Ton Olarak Girilecektir.)"></asp:TextBox>
                        <asp:TextBox ID="txtBugday" runat="server" placeholder="Buğday (Ton Olarak Girilecektir.)"></asp:TextBox>
                        <asp:TextBox ID="txtPatates" runat="server" placeholder="Patates (Ton Olarak Girilecektir.)"></asp:TextBox>
                        <asp:TextBox ID="txtArpa" runat="server" placeholder="Arpa (Ton Olarak Girilecektir.)"></asp:TextBox>
                        <br />
                        <div class="button-container-top">
                            <asp:Button ID="btnGeri" runat="server" Text="Geri" CssClass="button-default" OnClick="btnGeri_Click" />
                            &nbsp;
                            <asp:Button runat="server" class="button-default" ID="BtnTarlaUrunleriKaydet" Text="Kaydet" OnClick="BtnTarlaUrunleriKaydet_Click" />
                            &nbsp;
                        <asp:Button ID="btnAdminHayvanGuncelle" CssClass="button-default" runat="server" Text="Güncelle" OnClick="btnAdminHayvanGuncelle_Click" />
                            &nbsp;
                            <asp:Button ID="btnAdminTarlaUrunleriSil" CssClass="button-default" runat="server" Text="Sil" OnClick="btnAdminTarlaUrunleriSil_Click" />
                        </div>
                         <div>
                            <br />
                            <asp:Button CssClass="veriGetir" ID="veriGetir" runat="server" Text="Bilgileri Göster" OnClick="veriGetir_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <br />

            <div class="lists">
                    <table class="table table-success table-striped">
                        <tr>
                            <th class="auto-style2">Tarla Ürünleri</th>
                            <th class="auto-style2">&nbsp;</th>
                            <th class="auto-style2">Meyveler</th>
                            <th class="auto-style2">&nbsp;</th>
                            <th class="auto-style2">Sebzeler</th>
                            <th class="auto-style2"></th>
                            <th class="auto-style2">Tarım Alanı ve Yüz ölçümü</th>
                            <th class="auto-style2"></th>
                            <th class="auto-style2">Hayvan Bilgileri</th>
                            <td class="auto-style2"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Yeşil Ot Miktarı"></asp:Label>
                                :</td>
                            <td>
                                <asp:Label ID="lblYesilOt" runat="server" Text=""></asp:Label>
                            </td>
                            <td>Elma Miktarı:</td>
                            <td>
                                <asp:Label ID="lblElma" runat="server" Text=""></asp:Label>
                            </td>
                            <td>Lahana Miktarı:</td>
                            <td>
                                <asp:Label ID="lblLahana" runat="server" Text=""></asp:Label>
                            </td>
                            <td>Nüfus Bilgisi:</td>
                            <td>
                                <asp:Label ID="lblNufusBilgisi" runat="server" Text=""></asp:Label>
                            </td>
                            <td>Küçükbaş:</td>
                            <td>
                                <asp:Label ID="lblKucukbas" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Mısır Miktarı:</td>
                            <td>
                                <asp:Label ID="lblMisir" runat="server" Text=""></asp:Label>
                            </td>
                            <td>Armut Miktarı:</td>
                            <td>
                                <asp:Label ID="lblArmut" runat="server" Text=""></asp:Label>
                            </td>
                            <td>Domates Miktarı:</td>
                            <td>
                                <asp:Label ID="lblDomates" runat="server" Text=""></asp:Label>
                            </td>
                            <td>Yüzölçümü:</td>
                            <td>
                                <asp:Label ID="lblYuzolcumu" runat="server" Text=""></asp:Label>
                            </td>
                            <td>Büyükbaş:</td>
                            <td>
                                <asp:Label ID="lblBuyukbas" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Buğday Miktarı:</td>
                            <td class="auto-style2">
                                <asp:Label ID="lblBugday" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="auto-style2">Erik Miktarı:</td>
                            <td class="auto-style2">
                                <asp:Label ID="lblErik" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="auto-style2">Fasulye Miktarı:</td>
                            <td class="auto-style2">
                                <asp:Label ID="lblFasulye" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="auto-style2">Tarım Alanı:</td>
                            <td class="auto-style2">
                                <asp:Label ID="lblTarimAlani" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="auto-style2"></td>
                            <td class="auto-style2"></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Patates Miktarı:</td>
                            <td class="auto-style2">
                                <asp:Label ID="lblPatates" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="auto-style2">Kayısı Miktarı</td>
                            <td class="auto-style2">
                                <asp:Label ID="lblKayisi" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="auto-style2">Salatalık Miktarı:</td>
                            <td class="auto-style2">
                                <asp:Label ID="lblSalatalik" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="auto-style2"></td>
                            <td class="auto-style2"></td>
                            <td class="auto-style2"></td>
                            <td class="auto-style2"></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Arpa Miktarı:</td>
                            <td class="auto-style2">
                                <asp:Label ID="lblArpa" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="auto-style2">Kiraz Miktarı:</td>
                            <td class="auto-style2">
                                <asp:Label ID="lblKiraz" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="auto-style2">Yeşil Biber Miktarı:</td>
                            <td class="auto-style2">
                                <asp:Label ID="lblYesilBiber" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="auto-style2"></td>
                            <td class="auto-style2"></td>
                            <td class="auto-style2"></td>
                            <td class="auto-style2"></td>
                        </tr>
                    </table>
                </div>
        </section>
    </form>
</asp:Content>

