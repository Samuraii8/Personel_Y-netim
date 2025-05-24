using PERSO.DAL;
using PERSO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PERSO.Pages
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnEkle_Click(object sender, EventArgs e)
        {
            byte[] resimBytes = null;
            if (fuResim.HasFile)
            {
                
                resimBytes = fuResim.FileBytes;
            }

            Personel yeniPersonel = new Personel  //personel nesnem he
            {
                Ad = txtAd.Text,
                Soyad = txtSoyad.Text,
                Resim = resimBytes,
                Departman = txtDepartman.Text
            };

            bool sonuc = PersonelDAL.Insert(yeniPersonel);
            if (sonuc)
            {
                Response.Redirect("https://localhost:44390/Pages/Default.aspx");
            }
            else
            {
                lblMessage.Text = "Kayıt eklenirken hata oluştu.";
            }
        }
    }
}