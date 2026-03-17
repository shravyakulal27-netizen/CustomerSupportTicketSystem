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
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login([FromBody] LoginRequest req)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT * FROM users WHERE Username=@username AND Password=@password";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", req.Username);
                    cmd.Parameters.AddWithValue("@password", req.Password);

                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {

                        reader.Read();
                        var response = new LoginResponseDTO()
                        {
                            UserId = Convert.ToInt32(reader["UserId"]),
                            Role = reader["Role"].ToString()
                        };
                        return Ok(response);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }


        [HttpGet]
        [Route("api/users/admins")]
        public IHttpActionResult GetAdmins()
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                List<AdminDTO> admins = new List<AdminDTO>();

                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT UserId, Username FROM users WHERE Role='Admin'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        admins.Add(new AdminDTO()
                        {
                            UserId = Convert.ToInt32(reader["UserId"]),
                            Username = reader["Username"].ToString()
                        });
                    }
                }

                return Ok(admins);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
    }


    public class AdminDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; } // use this instead of Role
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}


