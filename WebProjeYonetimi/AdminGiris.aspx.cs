using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class AdminGiris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void btnGirisYap_Click(object sender, EventArgs e)
    {
        adminGiris();
    }
                    
    private void adminGiris()
    {
        using(DbWebEntities ent = new DbWebEntities())
        {
            var kullaniciBilgi = ent.tbl_admin.Where(x=> x.admin_adi == txtKullaniciAdi.Text && x.sifre == txtSifre.Text);
            if (kullaniciBilgi.Count() > 0)
            {
                Session["admin_adi"] = ent.tbl_admin.Select(x => x.admin_adi);
                Session["sifre"] = ent.tbl_admin.Select(x => x.sifre);
                Response.Redirect("AdminGirisSecici.aspx");
            }
            else
            {
                Araclar.MesajPenceresi("Kullanıcı adı veya şifre hatalı.");
            }
        }
    }
}