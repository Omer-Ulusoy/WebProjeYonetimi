using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Iletisim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblEsittir.Visible = false;
        txtSonuc.Visible = false;
    }

    protected void btnİletisimKaydet_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtAdiniz.Text) && !string.IsNullOrEmpty(txtSoyadiniz.Text)
            && !string.IsNullOrEmpty(txtGorusveOneriler.Text) && !string.IsNullOrEmpty(txtDogumTarihi.Text)
            && !string.IsNullOrEmpty(txtTcKimlikNo.Text) && !string.IsNullOrEmpty(txtSonuc.Text))
        {
            KisiKontrol();
            kontrolCaptcha();
            if (kontrolCaptchaa == true)
            {
                İletisimKaydet();
            }
            else
            {
                Araclar.MesajPenceresi("doğrulama hatalı");
            }
        }
        else
        {
            Araclar.MesajPenceresi("İlgili Alanlar boş olmamalıdır");
        }
    }

    private void Temizle()
    {
        txtAdiniz.Text = String.Empty;
        txtSoyadiniz.Text = String.Empty;
        txtGorusveOneriler.Text = String.Empty;
        txtDogumTarihi.Text = String.Empty;
        txtTcKimlikNo.Text = String.Empty;
    }

    private void İletisimKaydet()
    {

        using (DbWebEntities ent = new DbWebEntities())
        {
            tbl_iletisim iletisim = new tbl_iletisim();
            iletisim.yorumcu_adi = txtAdiniz.Text;
            iletisim.yorumcu_soyadi = txtSoyadiniz.Text;
            iletisim.tc_kimlik_no = txtTcKimlikNo.Text;
            iletisim.dogum_yili = txtDogumTarihi.Text;
            iletisim.gorus_ve_oneriler = txtGorusveOneriler.Text;

            ent.tbl_iletisim.Add(iletisim);
            ent.SaveChanges();
            Araclar.MesajPenceresi("Mesajınız Başarı ile Gönderildi.");
            Temizle();
        }



    }
    bool kisiKontrolDurum = false;
    private bool KisiKontrol()
    {
        long Tckimlik = long.Parse(txtTcKimlikNo.Text);
        int DogumTarihi = int.Parse(txtDogumTarihi.Text);
        bool durum;
        try
        {
            using (KisiDogrulama.KPSPublicSoapClient services = new KisiDogrulama.KPSPublicSoapClient())
            {
                durum = services.TCKimlikNoDogrula(Tckimlik, txtAdiniz.Text, txtSoyadiniz.Text, DogumTarihi);
            }
        }
        catch (Exception ex)
        {
            durum = false;
        }

        if (durum == true)
        {
            kisiKontrolDurum = true;
            İletisimKaydet();
            Temizle();
        }
        else
        {
            Araclar.MesajPenceresi("Girdiğiniz Bilgilere Ait Kişi Bulunamadı.");
            Temizle();
        }
        return durum;
    }

    protected void btnTemizle_Click(object sender, EventArgs e)
    {
        Temizle();
    }

    private void captcha()
    {
        Random random = new Random();
        int sayi1 = random.Next(1, 10);
        int sayi2 = random.Next(1, 10);
        int isaret = random.Next(1, 5);
        bool dene = false;
        if (dene == false)
        {
            lblsayi1.Text = sayi1.ToString();
            lblsayi2.Text = sayi2.ToString();

            if (isaret == 1)
            {
                lblIsaret.Text = "+";
            }
            if (isaret == 2)
            {
                lblIsaret.Text = "-";
            }
            if (isaret == 3)
            {
                lblIsaret.Text = "*";
            }
            if (isaret == 4)
            {
                lblIsaret.Text = "/";
            }
            dene = true;
        }
    }

    bool kontrolCaptchaa = false;
    private bool kontrolCaptcha()
    {
        int sayi1 = Convert.ToInt32(lblsayi1.Text);
        int sayi2 = Convert.ToInt32(lblsayi2.Text);

        bool dogrulama = false;
        int sonuc;

        if (lblIsaret.Text == "+")
        {
            sonuc = Convert.ToInt32(lblsayi1.Text) + Convert.ToInt32(lblsayi2.Text);
            if (Convert.ToInt32(txtSonuc.Text) == sonuc)
            {
                dogrulama = true;

            }
            if (lblIsaret.Text == "/")
            {
                sonuc = Convert.ToInt32(lblsayi1.Text) / Convert.ToInt32(lblsayi2.Text);
                if (Convert.ToInt32(txtSonuc.Text) == sonuc)
                {
                    dogrulama = true;
                }
            }
            if (lblIsaret.Text == "-")
            {
                sonuc = Convert.ToInt32(lblsayi1.Text) - Convert.ToInt32(lblsayi2.Text);
                if (Convert.ToInt32(txtSonuc.Text) == sonuc)
                {
                    dogrulama = true;
                }
            }
            if (lblIsaret.Text == "*")
            {
                sonuc = Convert.ToInt32(lblsayi1.Text) * Convert.ToInt32(lblsayi2.Text);
                if (Convert.ToInt32(txtSonuc.Text) == sonuc)
                {
                    dogrulama = true;
                }
            }
            if (dogrulama == true)
            {
                kontrolCaptchaa = true;
                return dogrulama;
            }
            else
            {
                return dogrulama;
            }           
        }
        return dogrulama;
    }

    protected void btnDogrulama_Click(object sender, EventArgs e)
    {
        lblEsittir.Visible = true;
        txtSonuc.Visible = true;
        captcha();
    }
}
