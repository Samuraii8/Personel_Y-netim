using PERSO.DAL;
using PERSO.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PERSO.Pages
{
	public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPersonelList();
            }
        }
        private void BindPersonelList()
        {
            
            List<Personel> personelList = PersonelDAL.GetAll();
            rptPersonel.DataSource = personelList;  
            rptPersonel.DataBind();
        }
        
        protected string GetResimUrl(object resimObj)   
        {
            if (resimObj == null || resimObj == DBNull.Value)
            {
                return "images/varsayılan.jpg"; //bunu eklemedim (klasör ıcıne default resim) bilerek nedenini bilmiom boşver canım ıstedi
            }
            else
            {
                return "data:image/jpeg;base64," + Convert.ToBase64String((byte[])resimObj);
            }
        }
    }
}