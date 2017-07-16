using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDRepoWebApi.Models;
using System.Data.SqlClient;
using System.Configuration;
using DVDRepoWebApi.Models.Interfaces;
using DVDRepoWebApi.Models.Models;

namespace DVDRepoWebApi.Data.Repositories
{
    public class DVDRepositoryADO : IDvdRepository
    {
        private List<DVD> _DvdList = new List<DVD>();
        private List<DvdViewModel> _DvdViewList = new List<DvdViewModel>();

        public List<DvdViewModel> GetAll()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDCatalog"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT d.dvdid, d.title, d.realeaseyear, di.directorName, r.ratingType, d.notes FROM DVDs d " +
                    "JOIN Ratings r ON d.ratingid = r.ratingid JOIN Directors di ON d.directorid = di.directorid " +
                    "ORDER BY title";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DvdViewModel currentRow = new DvdViewModel();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = (int)dr["RealeaseYear"];
                        currentRow.Director = dr["DirectorName"].ToString();
                        currentRow.Rating = dr["RatingType"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        _DvdViewList.Add(currentRow);
                    }
                }
            }
            return _DvdViewList;
        }

        public DvdViewModel GetById(int id)
        {
            DvdViewModel currentRow = new DvdViewModel();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDCatalog"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT d.dvdid, d.title, d.realeaseyear, di.directorName, r.ratingType, d.notes FROM DVDs d " +
                    "JOIN Ratings r ON d.ratingid = r.ratingid JOIN Directors di ON d.directorid = di.directorid " +
                    "WHERE dvdid = @id";
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = (int)dr["RealeaseYear"];
                        currentRow.Director = dr["DirectorName"].ToString();
                        currentRow.Rating = dr["RatingType"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();
                    }
                }
            }
            return currentRow;
        }

        public List<DvdViewModel> GetByDirector(string director)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDCatalog"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT d.dvdid, d.title, d.realeaseyear, di.directorName, r.ratingType, d.notes FROM DVDs d " +
                    "JOIN Ratings r ON d.ratingid = r.ratingid JOIN Directors di ON d.directorid = di.directorid " +
                    "WHERE directorName LIKE '%' + @searchString + '%'";
                cmd.Parameters.AddWithValue("@searchString", director);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DvdViewModel currentRow = new DvdViewModel();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = (int)dr["RealeaseYear"];
                        currentRow.Director = dr["DirectorName"].ToString();
                        currentRow.Rating = dr["RatingType"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        _DvdViewList.Add(currentRow);
                    }
                }
            }
            return _DvdViewList;
        }

        public List<DvdViewModel> GetByRating(string rating)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDCatalog"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT d.dvdid, d.title, d.realeaseyear, di.directorName, r.ratingType, d.notes FROM DVDs d " +
                    "JOIN Ratings r ON d.ratingid = r.ratingid JOIN Directors di ON d.directorid = di.directorid " +
                    "WHERE ratingType = @searchString";
                cmd.Parameters.AddWithValue("@searchString", rating);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DvdViewModel currentRow = new DvdViewModel();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = (int)dr["RealeaseYear"];
                        currentRow.Director = dr["DirectorName"].ToString();
                        currentRow.Rating = dr["RatingType"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        _DvdViewList.Add(currentRow);
                    }
                }
            }
            return _DvdViewList;
        }

        public List<DvdViewModel> GetByTitle(string title)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDCatalog"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT d.dvdid, d.title, d.realeaseyear, di.directorName, r.ratingType, d.notes FROM DVDs d " +
                    "JOIN Ratings r ON d.ratingid = r.ratingid JOIN Directors di ON d.directorid = di.directorid " +
                    "WHERE title LIKE '%' + @searchString + '%'";
                cmd.Parameters.AddWithValue("@searchString", title);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DvdViewModel currentRow = new DvdViewModel();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = (int)dr["RealeaseYear"];
                        currentRow.Director = dr["DirectorName"].ToString();
                        currentRow.Rating = dr["RatingType"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        _DvdViewList.Add(currentRow);
                    }
                }
            }
            return _DvdViewList;
        }

        public List<DvdViewModel> GetByYear(int year)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDCatalog"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT d.dvdid, d.title, d.realeaseyear, di.directorName, r.ratingType, d.notes FROM DVDs d " +
                    "JOIN Ratings r ON d.ratingid = r.ratingid JOIN Directors di ON d.directorid = di.directorid " +
                    "WHERE realeaseyear = @searchString";
                cmd.Parameters.AddWithValue("@searchString", year);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DvdViewModel currentRow = new DvdViewModel();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = (int)dr["RealeaseYear"];
                        currentRow.Director = dr["DirectorName"].ToString();
                        currentRow.Rating = dr["RatingType"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        _DvdViewList.Add(currentRow);
                    }
                }
            }
            return _DvdViewList;
        }

        public DvdViewModel Create(DvdViewModel dvd)
        {
            DvdViewModel currentRow = new DvdViewModel();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDCatalog"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();

                cmd.CommandText = "SELECT directorid FROM directors WHERE directorname = @dirName";
                cmd.Parameters.AddWithValue("@dirName", dvd.Director);
                var dirId = cmd.ExecuteScalar();
                if (dirId == null)
                {
                    cmd.CommandText = "INSERT INTO directors VALUES(@directorname)";
                    cmd.Parameters.AddWithValue("@directorname", dvd.Director);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SELECT max(directorid) FROM directors";
                    dirId = cmd.ExecuteScalar();
                }
                    

                cmd.CommandText = "SELECT ratingid FROM ratings WHERE ratingtype = @ratingType";
                cmd.Parameters.AddWithValue("@ratingType", dvd.Rating);
                var ratingId = cmd.ExecuteScalar();

                cmd.CommandText = "INSERT INTO dvds (title, realeaseyear, directorId, ratingId, notes) " +
                    "VALUES (@newTitle, @newRealeaseYear, @newDirector, @newRating, @newNotes);";
                cmd.Parameters.AddWithValue("@newTitle", dvd.Title);
                cmd.Parameters.AddWithValue("@newRealeaseYear", dvd.RealeaseYear);
                cmd.Parameters.AddWithValue("@newDirector", dirId);
                cmd.Parameters.AddWithValue("@newRating", ratingId);
                if (dvd.Notes != null)
                    cmd.Parameters.AddWithValue("@newNotes", dvd.Notes);
                else cmd.Parameters.AddWithValue("@newNotes", "");

                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT max(dvdid) FROM dvds";
                var id = cmd.ExecuteScalar();

                cmd.CommandText = "SELECT * FROM DVDs WHERE dvdid = @id";
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = (int)dr["RealeaseYear"];
                        currentRow.Director = dirId.ToString();
                        currentRow.Rating = ratingId.ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                    }
                }
            }
            return currentRow;
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDCatalog"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM dvds WHERE dvdid = @id";
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void Update(int id, DvdViewModel dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDCatalog"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT directorId from directors WHERE directorName = @dirName";
                cmd.Parameters.AddWithValue("@dirName", dvd.Director);
                conn.Open();

                var dirId = cmd.ExecuteScalar();
                if (dirId == null)
                {
                    cmd.CommandText = "INSERT INTO directors VALUES(@directorname)";
                    cmd.Parameters.AddWithValue("@directorname", dvd.Director);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SELECT max(directorid) FROM directors";
                    dirId = cmd.ExecuteScalar();
                }

                cmd.CommandText = "SELECT RatingId from ratings WHERE ratingtype = @ratingType";
                cmd.Parameters.AddWithValue("@ratingType", dvd.Rating);
                var ratingId = cmd.ExecuteScalar();

                cmd.CommandText = "UPDATE dvds SET title = @newTitle, realeaseyear = @newRealeaseYear, " +
                    "directorId = @newDirector, ratingId = @newRating, notes = @newNotes " +
                    "WHERE dvdid = @id;";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@newTitle", dvd.Title);
                cmd.Parameters.AddWithValue("@newRealeaseYear", dvd.RealeaseYear);
                cmd.Parameters.AddWithValue("@newDirector", dirId);
                cmd.Parameters.AddWithValue("@newRating", ratingId);
                cmd.Parameters.AddWithValue("@newNotes", dvd.Notes);

                cmd.ExecuteNonQuery();
            }
        }
    }
}