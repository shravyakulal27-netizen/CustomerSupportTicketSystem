using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using MySql.Data.MySqlClient;
using TicketsystemFinal.Models;

namespace TicketsystemFinal.Controllers
{
    public class CommentsController : ApiController
    {
        [HttpPost]
        [Route("api/tickets/{id}/comments")]
        public IHttpActionResult AddComment(int id, [FromBody] AddCommentRequest req)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"INSERT INTO ticketcomments
                                    (TicketId, CommentText, CreatedDate, CreatedBy)
                                     VALUES (@ticketId, @text, NOW(), @createdBy)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ticketId", id);
                    cmd.Parameters.AddWithValue("@text", req.CommentText);
                    cmd.Parameters.AddWithValue("@createdBy", req.CreatedBy);
                    cmd.ExecuteNonQuery();
                    return Ok("Comment added successfully.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/tickets/{id}/comments")]
        public IHttpActionResult GetComments(int id)
        {
            try
            {
                List<CommentDTO> comments = new List<CommentDTO>();
                string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"
                SELECT c.CommentId, c.TicketId, c.CommentText, c.CreatedDate, c.CreatedBy, u.Username
                FROM ticketcomments c
                INNER JOIN users u ON c.CreatedBy = u.UserId
                WHERE c.TicketId=@ticketId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ticketId", id);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comments.Add(new CommentDTO()
                        {
                            CommentId = Convert.ToInt32(reader["CommentId"]),
                            TicketId = Convert.ToInt32(reader["TicketId"]),
                            CommentText = reader["CommentText"].ToString(),
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                            CreatedBy = Convert.ToInt32(reader["CreatedBy"]),
                            Username = reader["Username"].ToString()  // <-- fetch username
                        });
                    }
                }

                return Ok(comments);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        public class AddCommentRequest
        {
            public string CommentText { get; set; }
            public int CreatedBy { get; set; }
        }

    }
}
