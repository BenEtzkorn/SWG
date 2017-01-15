using DvdLibrary.Data.Interfaces;
using DvdLibrary.Models.Queries;
using DvdLibrary.Models.Tables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data.ADO
{

    public class DvdLibraryRepositoryADO : IDvdsRepository
    {
        
        public Dvds GetDvdId(int dvdId)
        {
            Dvds dvds = null;

            Dvds Dvd = new Dvds();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdId", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@dvdId", dvdId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if(dr.Read())
                    {
                        dvds = new Dvds();
                        dvds.dvdId = (int)dr["dvdId"];
                        dvds.title = dr["title"].ToString();
                        dvds.releaseYear = dr["releaseYear"].ToString();
                        dvds.director = dr["director"].ToString();
                        dvds.rating = dr["rating"].ToString();
                        dvds.notes = dr["notes"].ToString();       
                    }
                }

                return dvds;

            }
        }

        public List<Dvds> GetDvds()
        {
            List<Dvds> dvds = new List<Dvds>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvds", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvds currentRow = new Dvds();
                        currentRow.dvdId = (int)dr["dvdId"];
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.notes = dr["notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }

                return dvds;

            }
        }

        public List<Dvds> GetDvdsDirector(string director)
        {
            List<Dvds> List = new List<Dvds>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdsDirector", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@director", director);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvds currentRow = new Dvds();
                        currentRow.dvdId = (int)dr["dvdId"];
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.notes = dr["notes"].ToString();

                        List.Add(currentRow);
                    }
                }

                return List;

            }
        }

        public List<Dvds> GetDvdsRating(string rating)
        {
            List<Dvds> List = new List<Dvds>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdsRating", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@rating", rating);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvds currentRow = new Dvds();
                        currentRow.dvdId = (int)dr["dvdId"];
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.notes = dr["notes"].ToString();

                        List.Add(currentRow);
                    }
                }

                return List;

            }
        }

        public List<Dvds> GetDvdsTitle(string title)
        {
            List<Dvds> List = new List<Dvds>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdsTitle", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@title", title);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvds currentRow = new Dvds();
                        currentRow.dvdId = (int)dr["dvdId"];
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.notes = dr["notes"].ToString();

                        List.Add(currentRow);
                    }
                }

                return List;

            }
        }

        public List<Dvds> GetDvdsYear(string releaseYear)
        {
            List<Dvds> List = new List<Dvds>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdsYear", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@releaseYear", releaseYear);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvds currentRow = new Dvds();
                        currentRow.dvdId = (int)dr["dvdId"];
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.notes = dr["notes"].ToString();

                        List.Add(currentRow);
                    }
                }

                return List;

            }
        }

        public void PostDvd(Dvds dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PostDvd", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@dvdId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@title", dvd.title);
                cmd.Parameters.AddWithValue("@releaseYear", dvd.releaseYear);
                cmd.Parameters.AddWithValue("@director", dvd.director);
                cmd.Parameters.AddWithValue("@rating", dvd.rating);
                cmd.Parameters.AddWithValue("@notes", dvd.notes);

                cn.Open();

                cmd.ExecuteNonQuery();

                dvd.dvdId = (int)param.Value;
            }
        }

        public void UpdateDvdId(Dvds dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateDvdId", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@dvdId", dvd.dvdId);
                cmd.Parameters.AddWithValue("@title", dvd.title);
                cmd.Parameters.AddWithValue("@releaseYear", dvd.releaseYear);
                cmd.Parameters.AddWithValue("@director", dvd.director);
                cmd.Parameters.AddWithValue("@rating", dvd.rating);
                cmd.Parameters.AddWithValue("@notes", dvd.notes);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteDvdId(int dvdId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteDvdId", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@dvdId", dvdId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
