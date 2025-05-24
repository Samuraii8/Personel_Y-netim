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
	public partial class AnaSayfa : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindResimler();
            }
        }

        private void BindResimler()
        {
           
            List<Personel> personelList = PersonelDAL.GetAll();

           
            

            rptResimler.DataSource = personelList;
            rptResimler.DataBind();
        }

        public string GetResimUrl(object resimObj)
        {
            if (resimObj == null || resimObj == DBNull.Value)
            {
                return "images/varsayılan.jpg";
            }
            else
            {
                
                return "data:image/jpeg;base64," + Convert.ToBase64String((byte[])resimObj);
            }
        }
    }
}