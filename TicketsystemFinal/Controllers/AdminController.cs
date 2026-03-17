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
    public class AdminController : ApiController
    {
        [HttpPut]
        [Route("api/tickets/{id}/assign")]
        public IHttpActionResult AssignTicket(int id, [FromBody] AssignRequest req)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "UPDATE tickets SET AssignedTo=@assignedTo WHERE TicketId=@ticketId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@assignedTo", req.AssignedTo);
                    cmd.Parameters.AddWithValue("@ticketId", id);
                    cmd.ExecuteNonQuery();
                    return Ok("Ticket assigned successfully.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("api/tickets/{id}/status")]
        public IHttpActionResult UpdateStatus(int id, [FromBody] StatusUpdateRequest req)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // Get current status
                    string selectQuery = "SELECT Status FROM tickets WHERE TicketId=@ticketId";
                    MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn);
                    selectCmd.Parameters.AddWithValue("@ticketId", id);
                    var oldStatus = selectCmd.ExecuteScalar()?.ToString() ?? "Open";

                    // Update ticket status
                    string updateQuery = "UPDATE tickets SET Status=@newStatus WHERE TicketId=@ticketId";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@newStatus", req.NewStatus);
                    updateCmd.Parameters.AddWithValue("@ticketId", id);
                    updateCmd.ExecuteNonQuery();

                    // Insert into history
                    string insertHistory = @"INSERT INTO ticketstatushistory
                                            (TicketId, OldStatus, NewStatus, ChangedDate, ChangedBy)
                                            VALUES (@ticketId, @oldStatus, @newStatus, NOW(), @changedBy)";
                    MySqlCommand histCmd = new MySqlCommand(insertHistory, conn);
                    histCmd.Parameters.AddWithValue("@ticketId", id);
                    histCmd.Parameters.AddWithValue("@oldStatus", oldStatus);
                    histCmd.Parameters.AddWithValue("@newStatus", req.NewStatus);
                    histCmd.Parameters.AddWithValue("@changedBy", req.ChangedBy);
                    histCmd.ExecuteNonQuery();

                    return Ok("Status updated successfully.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
}

    public class AssignRequest
    {
        public int AssignedTo { get; set; }
    }

    public class StatusUpdateRequest
    {
        public string NewStatus { get; set; }
        public int ChangedBy { get; set; }
    }

}