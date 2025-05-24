using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using PERSO.Models;

namespace PERSO.DAL
{
    public class PersonelDAL
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["PersonelDB"].ConnectionString;
        public static Personel GetById(int personelId)
        {
            Personel personel = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT PersonelID, Ad, Soyad, Resim, Departman FROM Personel WHERE PersonelID = @PersonelID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PersonelID", personelId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    personel = new Personel
                    {
                        PersonelID = Convert.ToInt32(dr["PersonelID"]),
                        Ad = dr["Ad"].ToString(),
                        Soyad = dr["Soyad"].ToString(),
                        Resim = dr["Resim"] as byte[],
                        Departman = dr["Departman"] as string
                    };
                }
            }
            return personel;
        }
        public static List<Personel> GetAll()
        {
            List<Personel> list = new List<Personel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT PersonelID, Ad, Soyad, Resim ,Departman FROM Personel";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Personel p = new Personel
                    {
                        PersonelID = Convert.ToInt32(dr["PersonelID"]),
                        Ad = dr["Ad"].ToString(),
                        Soyad = dr["Soyad"].ToString(),
                        Resim = dr["Resim"] as byte[],
                        Departman = dr["Departman"].ToString()
                    };
                    list.Add(p);
                }
            }
            return list;
        }

        public static bool Insert(Personel personel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Personel (Ad, Soyad,Resim,Departman) VALUES (@Ad, @Soyad, @Resim ,@Departman)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Ad", personel.Ad);
                cmd.Parameters.AddWithValue("@Soyad", personel.Soyad);
                cmd.Parameters.AddWithValue("@Departman",personel.Departman);
                cmd.Parameters.AddWithValue("@Resim", personel.Resim);  
                con.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
        public void DeletePersonel(int personelId)
        {   
           

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Personel WHERE PersonelID = @PersonelID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PersonelID", personelId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public static bool GuncellePersonel(int personelId, string ad, string soyad, string departman, byte[] resim)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Eğer yeni resim yüklenmişse güncelle, aksi halde resim sütununu değiştirmeyebiliriz.
                
                string query = "UPDATE Personel SET Ad = @Ad, Soyad = @Soyad, Departman = @Departman, Resim = @Resim WHERE PersonelID = @PersonelID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Ad", ad);
                    cmd.Parameters.AddWithValue("@Soyad", soyad);
                    cmd.Parameters.AddWithValue("@Departman", departman);
                    if (resim != null)
                        cmd.Parameters.AddWithValue("@Resim", resim);
                    else
                        cmd.Parameters.AddWithValue("@Resim", DBNull.Value);
                    cmd.Parameters.AddWithValue("@PersonelID", personelId);

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
    }
}
