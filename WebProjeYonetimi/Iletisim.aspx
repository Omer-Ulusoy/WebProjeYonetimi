<%@ Page Title="" Language="C#" MasterPageFile="~/anaMasterPage.master" AutoEventWireup="true" CodeFile="Iletisim.aspx.cs" Inherits="Iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .auto-style2 {
            height: 53px;
        }


        .dogrulama {
            
            padding: 12px 16px;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            transition: filter 0.3s;
            background: #8064A2;
            color: #f1faee;
            min-width:35px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <form runat="server">
        <section class="page-contain">
            <div class="contain">
                <div class="login-form">
                    <br />
                    <br />
                    <asp:TextBox ID="txtAdiniz" runat="server" placeholder="* Adınız"></asp:TextBox>
                    <asp:TextBox ID="txtSoyadiniz" runat="server" placeholder="* Soyadınız"></asp:TextBox>
                    <asp:TextBox ID="txtTcKimlikNo" runat="server" placeholder="* Tc Kimlik Numaranız (11 Hane Olmalıdır.)"></asp:TextBox>
                    <asp:TextBox ID="txtDogumTarihi" runat="server" placeholder="* Doğum Tarihiniz (Sadece Yıl)"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtGorusveOneriler" runat="server" TextMode="MultiLine" placeholder="* Görüş Ve Önerileriniz"></asp:TextBox>         
                    <table class="table-primary">
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="lblsayi1" runat="server" Font-Size="Larger"></asp:Label>
                                &nbsp;
                            </td>
                            <td class="auto-style2">
                                <asp:Label ID="lblIsaret" runat="server" Font-Size="Larger"></asp:Label>
                                &nbsp;
                            </td>
                            <td class="auto-style2">
                                <asp:Label ID="lblsayi2" runat="server" Font-Size="Larger"></asp:Label>
                                &nbsp;
                            </td>
                            <td class="auto-style2">
                                <asp:Label ID="lblEsittir" runat="server" Text="="></asp:Label>
                                &nbsp;
                            </td>
                            <td class="auto-style2" style="width:270px">
                                <asp:TextBox ID="txtSonuc" runat="server" placeholder="*"></asp:TextBox>
                            </td>

                            

                            <td class="auto-style2">
                                <br />
                                <asp:Button ID="btnDogrulama" CssClass="dogrulama" runat="server" Text="Dogrulama Kodu Alın" OnClick="btnDogrulama_Click" />
                                &nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="* İle İşaretlenmiş alanlar boş geçilemez."></asp:Label>
                    <br />
                    <div class="contain">
                        <asp:Button runat="server" class="button-default" ID="btnİletisimKaydet" Text="Gönder" OnClick="btnİletisimKaydet_Click" />
                        &nbsp; 
                        &nbsp;
            <asp:Button ID="btnTemizle" runat="server" Text="Temizle" class="button-default" BackColor="Green" OnClick="btnTemizle_Click" />
                    </div>
                </div>
            </div>
        </section>
    </form>
</asp:Content>

