using PERSO.DAL;
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
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int personelId;
                    if (int.TryParse(Request.QueryString["id"], out personelId))
                    {
                        PersonelDAL personelDal = new PersonelDAL();
                        personelDal.DeletePersonel(personelId);
                        Response.Redirect("Default.aspx");
                    }
                }
            }
        }
    }
}