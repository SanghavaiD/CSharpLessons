using Microsoft.Data.SqlClient;
using System.Data;
namespace MyFirstMCPApp.Models

{
    public class MovieDbRepository
    {
            public static List<Movie> GetMovieList()
            {
                List<Movie> movielist = new List<Movie>();
                using (SqlConnection cn = SqlHelper.CreateConnection())
                {
                    if (cn.State != ConnectionState.Open)
                    {
                        cn.Open();
                    }
                    SqlCommand selectmoviecmd = cn.CreateCommand();
                    String selectAllMovie = "Select*from Movie";
                    selectmoviecmd.CommandText = selectAllMovie;
                    SqlDataReader moviedr = selectmoviecmd.ExecuteReader();
                    while (moviedr.Read())
                    {
                        Movie movie = new Movie
                        {
                            Id = moviedr.GetInt32(0),
                            Title = moviedr.GetString(1),
                            MLanguage = moviedr.GetString(2),
                            Hero = moviedr.GetString(3),
                            Director = moviedr.GetString(4),
                            MusicDirector = moviedr.GetString(5),
                            ReleaseDate = moviedr.GetDateTime(6),
                            Cost=(int)moviedr.GetDecimal(7),
                            MCollection = (int)moviedr.GetDecimal(8),
                            Review=moviedr.GetString(9)
                        };
                        movielist.Add(movie);
                    }
                }
                return movielist;

            }
            public static Movie GetMovieById(int id)
            {
                Movie moviefound = null;
                using (SqlConnection cn = SqlHelper.CreateConnection())
                {
                    if (cn.State != ConnectionState.Open)
                    {
                        cn.Open();
                    }
                    SqlCommand selectmoviecmd = cn.CreateCommand();
                    String selectionMovie = "Select*from Movie where Id=@id";   //Parameter
                    selectmoviecmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    selectmoviecmd.CommandText = selectionMovie;
                    SqlDataReader moviedr = selectmoviecmd.ExecuteReader();
                    while (moviedr.Read())
                    {
                        moviefound = new Movie
                        {
                            Id = moviedr.GetInt32(0),
                            Title = moviedr.GetString(1),
                            MLanguage = moviedr.GetString(2),
                            Hero = moviedr.GetString(3),
                            Director = moviedr.GetString(4),
                            MusicDirector = moviedr.GetString(5),
                            ReleaseDate = moviedr.GetDateTime(6),
                            Cost = (int)moviedr.GetDecimal(7),
                            MCollection = (int)moviedr.GetDecimal(8),
                            Review = moviedr.GetString(9)
                        };

                    }

                    return moviefound;
                }

            }
            public static int AddNewMovie(Movie newmovie)
            {
                int query_result = 0;
                using (SqlConnection cn = SqlHelper.CreateConnection())
                {
                    if (cn.State != ConnectionState.Open)
                    {
                        cn.Open();
                    }
                    SqlCommand insertMoviecmd = cn.CreateCommand();
                    String insertNewMovieQuery = "insert into Movie values( @id,@title,@MLanguage,@Hero,@Director,@MusicDirector,@ReleaseDate,@Cost,@MCollection,@Review )";
                    insertMoviecmd.Parameters.Add("@id", SqlDbType.Int).Value = newmovie.Id;
                    insertMoviecmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = newmovie.Title;
                    insertMoviecmd.Parameters.Add("@MLanguage", SqlDbType.NVarChar).Value = newmovie.MLanguage;
                    insertMoviecmd.Parameters.Add("@Hero", SqlDbType.NVarChar).Value = newmovie.Hero;
                    insertMoviecmd.Parameters.Add("@Director", SqlDbType.NVarChar).Value = newmovie.Director;
                    insertMoviecmd.Parameters.Add("@MusicDirector", SqlDbType.NVarChar).Value = newmovie.MusicDirector;
                    insertMoviecmd.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = newmovie.ReleaseDate;
                    insertMoviecmd.Parameters.Add("@Cost", SqlDbType.Decimal).Value = newmovie.Cost;
                    insertMoviecmd.Parameters.Add("@MCollection", SqlDbType.Decimal).Value = newmovie.MCollection;
                    insertMoviecmd.Parameters.Add("@Review", SqlDbType.NVarChar).Value = newmovie.Review;



                insertMoviecmd.CommandText = insertNewMovieQuery;
                    query_result = insertMoviecmd.ExecuteNonQuery();
                }
                return query_result;
            }
            public static int UpdateMovie(Movie modifiedMovie)
            {
                int query_result = 0;
                using (SqlConnection cn = SqlHelper.CreateConnection())
                {
                    if (cn.State != ConnectionState.Open)
                    {
                        cn.Open();
                    }
                SqlCommand insertMoviecmd = cn.CreateCommand();
                String insertNewMovieQuery = "insert into Movie values( @id,@title,@MLanguage,@Hero,@Director,@MusicDirector,@ReleaseDate,@Cost,@MCollection,@Review )";
                insertMoviecmd.Parameters.Add("@id", SqlDbType.Int).Value = modifiedMovie.Id;
                insertMoviecmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = modifiedMovie.Title;
                insertMoviecmd.Parameters.Add("@MLanguage", SqlDbType.NVarChar).Value = modifiedMovie.MLanguage;
                insertMoviecmd.Parameters.Add("@Hero", SqlDbType.NVarChar).Value = modifiedMovie.Hero;
                insertMoviecmd.Parameters.Add("@Director", SqlDbType.NVarChar).Value = modifiedMovie.Director;
                insertMoviecmd.Parameters.Add("@MusicDirector", SqlDbType.NVarChar).Value = modifiedMovie.MusicDirector;
                insertMoviecmd.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = modifiedMovie.ReleaseDate;
                insertMoviecmd.Parameters.Add("@Cost", SqlDbType.Decimal).Value = modifiedMovie.Cost;
                insertMoviecmd.Parameters.Add("@MCollection", SqlDbType.Decimal).Value = modifiedMovie.MCollection;
                insertMoviecmd.Parameters.Add("@Review", SqlDbType.NVarChar).Value = modifiedMovie.Review;

            }
            return query_result;
            }
        public static int DeleteMovie(int id)
        {
            int query_result = 0;
            using (SqlConnection cn = SqlHelper.CreateConnection())
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                SqlCommand deleteMoviecmd = cn.CreateCommand();
                String deleteMovieQuery = "Delete from emptbl where eno=@id";
                deleteMoviecmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                deleteMoviecmd.CommandText = deleteMovieQuery;
                query_result = deleteMoviecmd.ExecuteNonQuery();
            }
            return query_result;
        }

    }
}

