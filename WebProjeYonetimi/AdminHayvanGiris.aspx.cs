using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminHayvanGiris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlIlDoldur(ddlSehir);
            DdlYilDoldur(ddlYil);
            ListItem lst = new ListItem("Lütfen Seçiniz", "-1");
            ddlSehir.Items.Insert(0, lst);
            ddlYil.Items.Insert(0, lst);
        }
    }

    private void DdlIlDoldur(DropDownList ddl)
    {
        using (DbWebEntities ent = new DbWebEntities())
        {
            var iller = ent.tbl_iller.ToList();

            ddl.DataSource = iller;
            ddl.DataTextField = "il_adi";
            ddl.DataValueField = "il_id";
            ddl.DataBind();           
        }
    }

    private void DdlYilDoldur(DropDownList ddl)
    {
        using (DbWebEntities ent = new DbWebEntities())
        {

            var meyve_yil = ent.tbl_meyve.Select(x => x.meyve_tarih).Distinct().ToList();
            var sebze_yil = ent.tbl_sebze.Select(x => x.sebze_tarih).Distinct().ToList();
            var il_yil = ent.tbl_iller.Select(x => x.il_tarih).Distinct().ToList();
            var hayvan_yil = ent.tbl_hayvan.Select(x => x.hayvan_tarih).Distinct().ToList();
            var tarimAlanı = ent.tbl_tarim_urunleri.Select(s => s.tarim_urunleri_tarih).Distinct().ToList();
            var tarlaUrunleri = ent.tbl_tarim_alani_ve_yuz_olcumu.Select(x => x.tarim_alani_ve_yuz_olcumu_tarih).Distinct().ToList();

            foreach (var item in sebze_yil)
            {
                meyve_yil.Add(item);
            }

            foreach (var item in il_yil)
            {
                meyve_yil.Add(item);
            }

            foreach (var item in hayvan_yil)
            {
                meyve_yil.Add(item);
            }

            foreach (var item in tarimAlanı)
            {
                meyve_yil.Add(item);
            }

            foreach (var item in tarlaUrunleri)
            {
                meyve_yil.Add(item);
            }

            foreach (var item in meyve_yil.Distinct())
            {
                ListItem li = new ListItem(item, item);

                ddl.Items.Add(li);
            }

            //dropdowna doldurulan yil bilgilerinin sıralanması
            List<ListItem> list = new List<ListItem>();

            foreach (ListItem li in ddlYil.Items)
            {
                //add ListItem to generic list
                list.Add(li);
            }

            //sort list items by item text alphabetically/ascending
            List<ListItem> sorted = list.OrderBy(b => b.Text).ToList();

            //empty dropdownlist
            ddlYil.Items.Clear();
            //repopulate dropdownlist with sorted items.
            foreach (ListItem li in sorted)
            {
                ddlYil.Items.Add(li);
            }
        }
    }

    private void Sartlılistele(int il, string yil)
    {
        using (DbWebEntities ent = new DbWebEntities())
        {
            //meyveler
            var meyveler = (from m in ent.tbl_meyve
                            where m.il_id == il
                            && m.meyve_tarih == yil
                            select m).ToList();

            foreach (var item in meyveler)
            {
                if (item.armut.ToString() != string.Empty)
                {
                    lblArmut.Text = item.armut.ToString() + " Ton.";
                }
                else
                {
                    lblArmut.Text = "Bu yıla ait veri bulunamadı";
                }

                if (item.kiraz.ToString() != string.Empty)
                {
                    lblKiraz.Text = item.kiraz.ToString() + " Ton.";
                }
                else
                {
                    lblKiraz.Text = "Bu yıla ait veri bulunamadı";
                }

                if (item.elma.ToString() != string.Empty)
                {
                    lblElma.Text = item.elma.ToString() + " Ton.";
                }
                else
                {
                    lblElma.Text = "Bu yıla ait veri bulunamadı";
                }

                if (item.erik.ToString() != string.Empty)
                {
                    lblErik.Text = item.erik.ToString();
                }
                else
                {
                    lblErik.Text = "Bu yıla ait veri bulunamadı";
                }

                if (item.kayısı.ToString() != string.Empty)
                {
                    lblKayisi.Text = item.kayısı.ToString() + " Ton.";
                }
                else
                {
                    lblKayisi.Text = "Bu yıla ait veri bulunamadı";
                }
            }


            //sebzeler
            var sebzeler = (from s in ent.tbl_sebze
                            where s.il_id == il
                            && s.sebze_tarih == yil
                            select s).ToList();

            foreach (var item in sebzeler)
            {
                if (item.yesil_biber.ToString() != string.Empty)
                {
                    lblYesilBiber.Text = item.yesil_biber.ToString() + " Ton.";
                }
                else
                {
                    lblYesilBiber.Text = "Bu yıla ait veri bulunamadı";
                }

                if (item.salatalik.ToString() != string.Empty)
                {
                    lblSalatalik.Text = item.salatalik.ToString() + " Ton.";
                }
                else
                {
                    lblSalatalik.Text = "Bu yıla ait veri bulunamadı";
                }

                if (item.lahana.ToString() != string.Empty)
                {
                    lblLahana.Text = item.lahana.ToString() + " Ton.";
                }
                else
                {
                    lblLahana.Text = "Bu yıla ait veri bulunamadı";
                }

                if (item.domates.ToString() != string.Empty)
                {
                    lblDomates.Text = item.domates.ToString() + " Ton.";
                }
                else
                {
                    lblDomates.Text = "Bu yıla ait veri bulunamadı";
                }

                if (item.fasulye.ToString() != string.Empty)
                {
                    lblFasulye.Text = item.fasulye.ToString() + " Ton.";
                }
                else
                {
                    lblFasulye.Text = "Bu yıla ait veri bulunamadı";
                }
            }

            //tarla ürünleri
            var tarlaUrun = (from t in ent.tbl_tarim_urunleri
                             where
                             t.il_id == il
                             && t.tarim_urunleri_tarih == yil
                             select t).ToList();

            foreach (var item in tarlaUrun)
            {
                if (item.bugday.ToString() != string.Empty)
                {
                    lblBugday.Text = item.bugday.ToString() + " Ton.";
                }
                else
                {
                    lblBugday.Text = "Bu yıla ait veri bulunamadı";
                }

                if (item.arpa.ToString() != string.Empty)
                {
                    lblArpa.Text = item.arpa.ToString() + " Ton.";
                }
                else
                {
                    lblArpa.Text = "Bu yıla ait veri bulunamadı";
                }

                if (item.yesil_ot.ToString() != string.Empty)
                {
                    lblYesilOt.Text = item.yesil_ot.ToString() + " Ton.";
                }
                else
                {
                    lblYesilOt.Text = "Bu yıla ait veri bulunamadı";
                }

                if (item.mısır.ToString() != string.Empty)
                {
                    lblMisir.Text = item.mısır.ToString() + " Ton.";
                }
                else
                {
                    lblMisir.Text = "Bu yıla ait veri bulunamadı";
                }

                if (item.patates.ToString() != string.Empty)
                {
                    lblPatates.Text = item.patates.ToString() + " Ton.";
                }
                else
                {
                    lblPatates.Text = "Bu yıla ait veri bulunamadı";
                }
            }

            //tarım alanı ve yüz ölcümü
            var tarimAlaniYuzOlcumu = (from ta in ent.tbl_tarim_alani_ve_yuz_olcumu
                                       where
                                       ta.il_id == il
                                       && ta.tarim_alani_ve_yuz_olcumu_tarih == yil
                                       select ta).ToList();

            foreach (var item in tarimAlaniYuzOlcumu)
            {
                if (item.nufus_bilgisi.ToString() != string.Empty)
                {
                    lblNufusBilgisi.Text = item.nufus_bilgisi.ToString() + " Kişi.";
                }
                else
                {
                    lblNufusBilgisi.Text = "Bu yıla ait veri bulunamadı";
                }

                if (item.yuz_olcumu.ToString() != string.Empty)
                {
                    lblYuzolcumu.Text = item.yuz_olcumu.ToString() + " km²";
                }
                else
                {
                    lblYuzolcumu.Text = "Bu yıla ait veri bulunamadı";
                }

                if (item.tarim_alani.ToString() != string.Empty)
                {
                    lblTarimAlani.Text = item.tarim_alani.ToString() + " Hektar.";
                }
                else
                {
                    lblTarimAlani.Text = "Bu yıla ait veri bulunamadı";
                }
            }

            //hayvanBilgi
            var hayvanBilgi = (from h in ent.tbl_hayvan
                               where
                               h.il_id == il
                               && h.hayvan_tarih == yil
                               select h).ToList();

            foreach (var item in hayvanBilgi)
            {
                if (item.kucukbas.ToString() != string.Empty)
                {
                    lblKucukbas.Text = item.kucukbas.ToString() + " Adet.";
                }
                else
                {
                    lblKucukbas.Text = "Bu yıla ait veri bulunamadı";
                }

                if (item.buyukbas.ToString() != string.Empty)
                {
                    lblBuyukbas.Text = item.buyukbas.ToString() + " Adet.";
                }
                else
                {
                    lblBuyukbas.Text = "Bu yıla ait veri bulunamadı";
                }
            }
        }
    }

    protected void btnAdminHayvanGiris_Click(object sender, EventArgs e)
    {
        HayvanEkle();
    }

    private void LblTemizle()
    {
        lblYesilOt.Text = string.Empty;
        lblMisir.Text = string.Empty;
        lblBugday.Text = string.Empty;
        lblPatates.Text = string.Empty;
        lblArpa.Text = string.Empty;
        lblElma.Text = string.Empty;
        lblArmut.Text = string.Empty;
        lblErik.Text = string.Empty;
        lblKayisi.Text = string.Empty;
        lblKiraz.Text = string.Empty;
        lblLahana.Text = string.Empty;
        lblDomates.Text = string.Empty;
        lblFasulye.Text = string.Empty;
        lblSalatalik.Text = string.Empty;
        lblYesilBiber.Text = string.Empty;
        lblNufusBilgisi.Text = string.Empty;
        lblYuzolcumu.Text = string.Empty;
        lblTarimAlani.Text = string.Empty;
        lblKucukbas.Text = string.Empty;
        lblBuyukbas.Text = string.Empty;
        ddlYil.Items.Clear();
    }

    private void Temizle()
    {
        txtBuyukbas.Text = string.Empty;
        txtKucukbas.Text = string.Empty;
    }
    private bool Kontrol(int il_id)
    {
        bool dogrulama = false;
        using (DbWebEntities ent = new DbWebEntities())
        {
            var il_sorgu = ent.tbl_hayvan.Where(x => x.il_id == il_id).Count();
            if (il_sorgu > 0)
            {
                dogrulama = true;
            }
        }
        return dogrulama;
    }

    private void HayvanEkle()
    {
        if (ddlYil.SelectedValue != "-1")
        {
            if (string.IsNullOrEmpty(txtBuyukbas.Text) && string.IsNullOrEmpty(txtKucukbas.Text))
            {
                Araclar.MesajPenceresi("Giriş Yapılacak Veri Bulunamadı");
            }
            else
            {
                if (!Kontrol(Convert.ToInt16(ddlSehir.SelectedIndex + 1)))
                {
                    using (DbWebEntities ent = new DbWebEntities())
                    {
                        string eklenenler = string.Empty;
                        tbl_hayvan hayvan = new tbl_hayvan();
                        hayvan.il_id = Convert.ToInt16(ddlSehir.SelectedIndex + 1);
                        if (!string.IsNullOrEmpty(txtBuyukbas.Text))
                        {
                            hayvan.buyukbas = Convert.ToInt16(txtBuyukbas.Text);
                            eklenenler += "Büyükbaş : " + hayvan.buyukbas;
                        }
                        if (!string.IsNullOrEmpty(txtKucukbas.Text))
                        {
                            hayvan.kucukbas = Convert.ToInt16(txtKucukbas.Text);
                            eklenenler += " Küçükbaş : " + hayvan.kucukbas;
                        }

                        hayvan.hayvan_tarih = DateTime.Now.ToString("yyyy");
                        Araclar.MesajPenceresi(eklenenler + " Hayvan Kaydedildi.");
                        ent.tbl_hayvan.Add(hayvan);
                        ent.SaveChanges();
                        Temizle();
                    }
                }
                else
                {
                    Araclar.MesajPenceresi("Eklenecek İle Ait Bilgiler Zaten Mevcuttur. Lütfen Güncelleme Kullanınız.");
                }
            }
        }
        else
        {
            Araclar.MesajPenceresi("Girilecek Veriye ait Yılı Seçiniz.");
        }
        
    }

    protected void btnAdminHayvanSil_Click(object sender, EventArgs e)
    {
        Sil(int.Parse(ddlSehir.SelectedValue));
    }

    private void Sil(int il_id)
    {
        if (Kontrol(Convert.ToInt16(ddlSehir.SelectedValue)))
        {
            using (DbWebEntities ent = new DbWebEntities())
            {
                var silinecek_il_id = ent.tbl_hayvan.Where(x => x.il_id == il_id).FirstOrDefault();
                ent.tbl_hayvan.Remove(silinecek_il_id);
                ent.SaveChanges();
                Araclar.MesajPenceresi("Silinme İşlemi Başarıyla Gerçekleşti.");
            }
        }
        else
        {
            Araclar.MesajPenceresi("Silinecek İle Ait Veri Bulunamadı");
        }

    }

    protected void btnGeri_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminGirisSecici.aspx");
    }

    private void Guncelle(int il_id)
    {
        if (Kontrol(Convert.ToInt16(ddlSehir.SelectedValue)))
        {
            using (DbWebEntities ent = new DbWebEntities())
            {
                var guncellenecek_veriler = ent.tbl_hayvan.Where(x => x.il_id == il_id).FirstOrDefault();
                guncellenecek_veriler.il_id = int.Parse(ddlSehir.SelectedValue);
                if (!string.IsNullOrEmpty(txtBuyukbas.Text))
                {
                    guncellenecek_veriler.buyukbas = Convert.ToInt32(txtBuyukbas.Text);
                }
                if (!string.IsNullOrEmpty(txtKucukbas.Text))
                {

                    guncellenecek_veriler.kucukbas = Convert.ToInt32(txtKucukbas.Text);
                }

                if (!string.IsNullOrEmpty(ddlYil.SelectedValue))
                {
                    guncellenecek_veriler.hayvan_tarih = ddlYil.SelectedValue;
                }
                ent.SaveChanges();
                Araclar.MesajPenceresi("Güncelleme İşlemi Başarılı.");
            }
        }
        else
        {
            Araclar.MesajPenceresi("Güncellenecek İle Ait Veri Bulunamadı");
        }
    }

    protected void btnAdminHayvanGuncelle_Click(object sender, EventArgs e)
    {
        Guncelle(int.Parse(ddlSehir.SelectedValue));
    }

    protected void veriGetir_Click(object sender, EventArgs e)
    {
        int dropdownListIl = int.Parse(ddlSehir.SelectedValue);
        string dropdownListYil = ddlYil.SelectedItem.ToString();
        LblTemizle();
        DdlYilDoldur(ddlYil);
        Sartlılistele(dropdownListIl, dropdownListYil);
    }

    protected void hfSehir_ValueChanged(object sender, EventArgs e)
    {
        ddlSehir.SelectedValue = hfSehir.Value;
    }
}