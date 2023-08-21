using DataAccess;
using System.Data;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using System.Data.Entity;
using System.Data.SqlClient;
using MTDataAccess.Models;
using System;

// Tested with Postman

namespace MultiTracksAPI.Controllers
{
    public class ArtistController : System.Web.Http.ApiController
    {
        // Search Artist Name using SearchArtist stored Procedure
        [HttpGet()]
        [Route("artist/search")]
        public HttpResponseMessage SearchArtist(string name)
        {
            var sql = new SQL("admin");
            sql.Parameters.Add("@name", name);
            DataTable results = sql.ExecuteStoredProcedureDT("SearchArtist");
            return Request.CreateResponse<DataTable>(HttpStatusCode.OK, results);
        }

        // Get Song List
        [HttpGet()]
        [Route("song/list")]
        public HttpResponseMessage GetSong(int pageSize = 10, int pageNumber = 1)
        {
            var sql = new SQL("admin");
            sql.Parameters.Add("@PageSize", pageSize);
            sql.Parameters.Add("@PageNumber", pageNumber * pageSize);
            string query = "SELECT * FROM Song ORDER BY songID OFFSET @PageNumber ROWS FETCH NEXT @PageSize ROWS ONLY";
            DataTable results = sql.ExecuteDT(query);
            results.TableName = "list";
            return Request.CreateResponse<DataTable>(HttpStatusCode.OK, results);
        }

        // POST: Add an Artist
        [HttpPost]
        [Route("artist/add")]
        public IHttpActionResult AddArtist([FromBody] Artist artist)
        {
            try
            {
                SQL SQL = new SQL("admin");

                string query = "INSERT INTO ARTIST (title, biography, imageURL, heroURL) VALUES (@title, @biography, @imageURL, @heroURL)";
                SQL.Parameters.Add("@title", artist.title);
                SQL.Parameters.Add("@biography", artist.biography);
                SQL.Parameters.Add("@imageURL", artist.imageURL);
                SQL.Parameters.Add("@heroURL", artist.heroURL);

                int rowsAffected = SQL.Execute(query);

                if (rowsAffected > 0)
                {
                    return Ok();
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
