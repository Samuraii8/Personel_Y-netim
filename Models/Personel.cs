using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PERSO.Models
{
	public class Personel
	{
        public int PersonelID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public byte[] Resim { get; set; }
        public string Departman { get; internal set; }
    }
}