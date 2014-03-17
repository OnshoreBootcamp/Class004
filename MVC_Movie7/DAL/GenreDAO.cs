using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class GenreDAO
    {
        public List<GenreDM> ReadGenre(string statement, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(
                @"Data Source=.\SQLEXPRESS;Initial Catalog=MovieDB;
                    Integrated Security=SSPI;"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(statement, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    SqlDataReader data = command.ExecuteReader();
                    List<GenreDM> genres = new List<GenreDM>();
                    while (data.Read())
                    {
                        GenreDM genre = new GenreDM();
                        genre.id = Convert.ToInt32(data["id"]);
                        genre.genre = data["genre"].ToString();
                        genres.Add(genre);
                    }
                    return genres;
                }
            }
        }
        public string GetGenre(int id)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Id",id)
                };
                return ReadGenre("GetGenreById", parameters).SingleOrDefault().genre;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public int GetGenreId(string genre)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Genre",genre)
                };
                return ReadGenre("GetGenreIdByGenreName",
                    parameters).SingleOrDefault().id;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public void CreateGenre(string genre)
        {
            DAO dao = new DAO();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Genre",genre)
            };
            dao.Write("CreateGenre", parameters);
        }
        public bool DoesGenreExist(int id)
        {
            if (id != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}