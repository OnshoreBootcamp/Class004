using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class MovieDAO
    {
        public List<MovieDM> ReadMovie(string statement, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(
                @"Data Source=.\SQLEXPRESS;Initial Catalog=MovieDB;Integrated Security=SSPI;"))
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
                    List<MovieDM> movies = new List<MovieDM>();
                    while (data.Read())
                    {
                        MovieDM movie = new MovieDM();
                        movie.id = Convert.ToInt32(data["movieId"]);
                        movie.title = data["title"].ToString();
                        movie.releaseDate = Convert.ToDateTime(
                            data["releaseDate"]);
                        movie.genreId = Convert.ToInt32(data["genreId"]);
                        movies.Add(movie);
                    }
                    return movies;
                }
            }
        }
        public void CreateMovie(string title, DateTime releaseDate, string genre)
        {
            GenreDAO gdao = new GenreDAO();
            DAO dao = new DAO();
            int genreId = gdao.GetGenreId(genre);
            if (genreId == 0)
            {
                gdao.CreateGenre(genre);
                genreId = gdao.GetGenreId(genre);
            }
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Title",title),
                new SqlParameter("@ReleaseDate",releaseDate),
                new SqlParameter("@GenreId",genreId)
            };
            dao.Write("CreateMovie", parameters);
        }
        public void DeleteMovie(int id)
        {
            DAO dao = new DAO();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",id)
            };
            dao.Write("DeleteMovieById", parameters);
        }
        public List<MovieDM> GetAllMovies()
        {
            List<MovieDM> allMovies = ReadMovie("GetAllMovies", null);
            if (allMovies != null)
            {
                return allMovies;
            }
            else
            {
                allMovies.Take(0).ToList();
                return allMovies;
            }
        }
        public MovieDM GetMovieById(int id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",id)
            };
            return ReadMovie("GetMovieById", parameters).SingleOrDefault();
        }
        public void UpdateMovieDB(int id, string title, DateTime releaseDate, int genreId)
        {
            DAO dao = new DAO();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Title", title),
                new SqlParameter("@ReleaseDate", releaseDate), 
                new SqlParameter("@GenreId", genreId)
            };
            dao.Write("UpdateMovie", parameters);
        }
        public bool DoesMovieExist(int id)
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
        public MovieDM GetMovie(string title, DateTime releaseDate, string genre)
        {
            GenreDAO dao = new GenreDAO();
            int genreId = dao.GetGenreId(genre);
            if (genreId == 0)
            {
                dao.CreateGenre(genre);
                genreId = dao.GetGenreId(genre);
            }
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Title",title),
                    new SqlParameter("@ReleaseDate",releaseDate),
                    new SqlParameter("@GenreId",genreId)
                };
                return ReadMovie("GetMovieId",
                    parameters).SingleOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}