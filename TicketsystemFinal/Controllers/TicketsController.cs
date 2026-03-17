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
    public class TicketsController : ApiController
    {
        [HttpPost]
        [Route("api/tickets")]
        public IHttpActionResult CreateTicket([FromBody] TicketRequest req)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string ticketNumber = "TKT" + DateTime.Now.Ticks.ToString().Substring(10);

                    string query = @"INSERT INTO tickets (TicketNumber, Subject, Description, Priority, Status, CreatedDate, CreatedBy)
                                     VALUES (@ticketNumber, @subject, @desc, @priority, 'Open', NOW(), @createdBy)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ticketNumber", ticketNumber);
                    cmd.Parameters.AddWithValue("@subject", req.Subject);
                    cmd.Parameters.AddWithValue("@desc", req.Description);
                    cmd.Parameters.AddWithValue("@priority", req.Priority);
                    cmd.Parameters.AddWithValue("@createdBy", req.CreatedBy);
                    cmd.ExecuteNonQuery();
                    return Ok("Ticket created successfully with number " + ticketNumber);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/tickets")]
        public IHttpActionResult GetTickets(int userId, string role)
        {
            try
            {
                List<TicketDTO> tickets = new List<TicketDTO>();
                string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = role == "Admin" ?
                        @"SELECT t.*, u.Username AS AssignedToUsername
                  FROM tickets t
                  LEFT JOIN users u ON t.AssignedTo = u.UserId" :
                        @"SELECT t.*, u.Username AS AssignedToUsername
                  FROM tickets t
                  LEFT JOIN users u ON t.AssignedTo = u.UserId
                  WHERE t.CreatedBy=@userId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (role != "Admin") cmd.Parameters.AddWithValue("@userId", userId);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tickets.Add(new TicketDTO()
                        {
                            TicketId = Convert.ToInt32(reader["TicketId"]),
                            TicketNumber = reader["TicketNumber"].ToString(),
                            Subject = reader["Subject"].ToString(),
                            Description = reader["Description"].ToString(),
                            Priority = reader["Priority"].ToString(),
                            Status = reader["Status"].ToString(),
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                            CreatedBy = reader["CreatedBy"] as int?,
                            AssignedTo = reader["AssignedTo"] as int?,
                            AssignedToUsername = reader["AssignedToUsername"]?.ToString() ?? "Not Assigned"
                        });
                    }
                }
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/tickets/{id}")]
        public IHttpActionResult GetTicketDetails(int id)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"SELECT t.*, u.Username AS AssignedToUsername
                             FROM tickets t
                             LEFT JOIN users u ON t.AssignedTo = u.UserId
                             WHERE t.TicketId=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        var ticket = new TicketDTO()
                        {
                            TicketId = Convert.ToInt32(reader["TicketId"]),
                            TicketNumber = reader["TicketNumber"].ToString(),
                            Subject = reader["Subject"].ToString(),
                            Description = reader["Description"].ToString(),
                            Priority = reader["Priority"].ToString(),
                            Status = reader["Status"].ToString(),
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                            CreatedBy = reader["CreatedBy"] as int?,
                            AssignedTo = reader["AssignedTo"] as int?,
                            AssignedToUsername = reader["AssignedToUsername"]?.ToString() ?? "Not Assigned"
                        };
                        return Ok(ticket);
                    }
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
    }

        public class TicketRequest
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public int CreatedBy { get; set; }
    }
}
