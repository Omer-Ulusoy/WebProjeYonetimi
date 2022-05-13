using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminGirisSecici : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void BtnTarlaUrunleriGiris_Click(object sender, EventArgs e)
    {
        TarlaUrunleriGirisSayfasinaGit();
    }

    private void TarlaUrunleriGirisSayfasinaGit()
    {
        Response.Redirect("AdminTarlaUrunleriGiris.aspx");
    }

    protected void BtnMeyveGirisi_Click(object sender, EventArgs e)
    {
        MeyveUrunleriGirisSayfasinagit();
    }

    private void MeyveUrunleriGirisSayfasinagit()
    {
        Response.Redirect("AdminMeyveGiris.aspx");
    }

    protected void BtnHayvanGirisi_Click(object sender, EventArgs e)
    {
        HayvanGirisSayfasinaGit();
    }

    private void HayvanGirisSayfasinaGit()
    {
        Response.Redirect("AdminHayvanGiris.aspx");
    }

    protected void BtnNufusYuzolcumuveTarimalaniGirisi_Click(object sender, EventArgs e)
    {
        TarimAlaniveYuzolcumuSayfasinaGit();
    }

    private void TarimAlaniveYuzolcumuSayfasinaGit()
    {
        Response.Redirect("AdminTarimAlaniveYuzolcumuGiris.aspx");
    }

    protected void btnSebzeGirisi_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminSebzeGiris.aspx");
    }
}