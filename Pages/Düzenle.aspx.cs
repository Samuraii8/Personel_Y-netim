using System;
using System.IO;
using PERSO.DAL;
using PERSO.Models;
using System.Web.UI;

namespace PERSO.Pages
{
    public partial class Duzenle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                string idParam = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idParam))
                {
                    int personelId;
                    if (int.TryParse(idParam, out personelId))
                    {
                        LoadPersonel(personelId);
                    }
                    else
                    {
                        lblMessage.Text = "Geçersiz ID.";
                        pnlForm.Visible = false;
                    }
                }
                else
                {
                    lblMessage.Text = "ID parametresi eksik.";
                    pnlForm.Visible = false;
                }
            }
        }

        private void LoadPersonel(int personelId)
        {
           
            Personel personel = PersonelDAL.GetById(personelId);
            if (personel != null)
            {
                hfPersonelID.Value = personel.PersonelID.ToString();
                txtAd.Text = personel.Ad;
                txtSoyad.Text = personel.Soyad;
                txtDepartman.Text = personel.Departman;

                if (personel.Resim != null && personel.Resim.Length > 0)
                {
                    string base64 = Convert.ToBase64String(personel.Resim);
                    imgResim.ImageUrl = "data:image/jpeg;base64," + base64;
                }
                else
                {
                    imgResim.ImageUrl = "images/varsayılan.jpg";
                }
            }
            else
            {
                lblMessage.Text = "Kayıt bulunamadı.";
                pnlForm.Visible = false;
            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            int personelId = int.Parse(hfPersonelID.Value);
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string departman = txtDepartman.Text;
            byte[] resim = null;

            
            if (fuResim.HasFile)
            {
                using (BinaryReader br = new BinaryReader(fuResim.PostedFile.InputStream))
                {
                    resim = br.ReadBytes(fuResim.PostedFile.ContentLength);
                }
            }
            bool success = PersonelDAL.GuncellePersonel(personelId, ad, soyad, departman, resim);
            if (success)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMessage.Text = "Güncelleme sırasında bir hata oluştu.";
            }
        }
    }
}
