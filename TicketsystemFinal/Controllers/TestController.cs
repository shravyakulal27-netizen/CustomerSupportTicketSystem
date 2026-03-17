using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;      // For ConfigurationManager           // For ApiController
using MySql.Data.MySqlClient;    // For MySQL connection

namespace TicketsystemFinal.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("api/testdb")]  // URL: http://localhost:yourPort/api/testdb
        public IHttpActionResult TestDatabase()
        {
            try
            {
                // 1️⃣ Read connection string from Web.config
                string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                // 2️⃣ Create MySQL connection
                using (var conn = new MySqlConnection(connStr))
                {
                    // 3️⃣ Open the connection
                    conn.Open();

                    // 4️⃣ Optional: run a simple query to check
                    string sql = "SELECT COUNT(*) FROM Users";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    object result = cmd.ExecuteScalar();

                    return Ok("Database Connected! Users table has " + result + " rows.");
                }
            }
            catch (Exception ex)
            {
                // Catch and return any error
                return BadRequest("Database connection failed: " + ex.Message);
            }
        }
    }
}
