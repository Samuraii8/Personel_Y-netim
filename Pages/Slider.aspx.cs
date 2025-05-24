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
	public partial class Slider : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptSlider.DataSource = PersonelDAL.GetAll(); // Resimleri içeren veri
                rptSlider.DataBind();
                BindSlides();
            }
        }

        private void BindSlides()
        {
            // Veritabanından yalnızca resim verilerini çekiyoruz
            List<Personel> list = PersonelDAL.GetAll();
            rptSlider.DataSource = list;
            rptSlider.DataBind();
        }

        // Daha önceki sayfalarda kullandığınız GetResimUrl metodu
        public string GetResimUrl(object resimObj)
        {
            if (resimObj == null || resimObj == DBNull.Value)
                return "images/varsayilan.jpg"; // varsa varsayılan görselin yolu

            return "data:image/jpeg;base64," + Convert.ToBase64String((byte[])resimObj);
        }
    }
}