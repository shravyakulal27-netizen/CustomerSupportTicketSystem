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
    public class StatusHistoryController : ApiController
    {
        [HttpGet]
        [Route("api/tickets/{id}/history")]
        public IHttpActionResult GetHistory(int id)
        {
            try
            {
                List<TicketStatusHistoryDTO> history = new List<TicketStatusHistoryDTO>();
                string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    // Join with users to get username
                    string query = @"
                        SELECT h.OldStatus, h.NewStatus, h.ChangedDate, h.ChangedBy, u.Username
                        FROM ticketstatushistory h
                        INNER JOIN users u ON h.ChangedBy = u.UserId
                        WHERE h.TicketId = @ticketId
                        ORDER BY h.ChangedDate";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ticketId", id);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        history.Add(new TicketStatusHistoryDTO()
                        {
                            OldStatus = reader["OldStatus"].ToString(),
                            NewStatus = reader["NewStatus"].ToString(),
                            ChangedDate = Convert.ToDateTime(reader["ChangedDate"]),
                            ChangedBy = Convert.ToInt32(reader["ChangedBy"]),
                            Username = reader["Username"].ToString()  // <-- fetch username
                        });
                    }
                }
                return Ok(history);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

    }
}
