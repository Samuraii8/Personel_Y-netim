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
	public partial class Detay : System.Web.UI.Page
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
                       
                        Personel personel = PersonelDAL.GetById(personelId);
                        if (personel != null)
                        {
                            lblAd.Text = personel.Ad + " ";
                            lblSoyad.Text = personel.Soyad;
                            lblDepartman.Text = string.IsNullOrEmpty(personel.Departman)
                                ? "Belirtilmedi" : personel.Departman;

                           
                            if (personel.Resim == null || personel.Resim.Length == 0)
                            {
                                
                                imgResim.ImageUrl = "images/varsayılan.jpg";
                            }
                            else
                            {
                                
                                string base64 = Convert.ToBase64String(personel.Resim);
                                imgResim.ImageUrl = "data:image/jpeg;base64," + base64;
                            }
                        }
                    }
                }
            }
        }
    }
}