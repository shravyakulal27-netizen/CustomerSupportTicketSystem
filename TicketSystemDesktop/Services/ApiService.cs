using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using TicketSystemDesktop.Models;

namespace TicketSystemDesktop.Services
{
    class ApiService
    {
        private readonly string baseUrl = "https://localhost:44366/api/"; // Change if your API runs on different port
        private HttpClient client;

        public ApiService()
        {
            ServicePointManager.ServerCertificateValidationCallback +=
    (sender, cert, chain, sslPolicyErrors) => true;

            client = new HttpClient();
        }

        // Login
        //public async Task<LoginResponseDTO> LoginAsync(string username, string password)
        //{
        //    var data = new { Username = username, Password = password };
        //    var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        //    var response = await client.PostAsync(baseUrl + "login", content);
        //    response.EnsureSuccessStatusCode();
        //    var json = await response.Content.ReadAsStringAsync();
        //    return JsonConvert.DeserializeObject<LoginResponseDTO>(json);
        //}

        public async Task<LoginResponseDTO> LoginAsync(string username, string password)
        {
            var data = new { Username = username, Password = password };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(baseUrl + "login", content);

            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception("API Error: " + response.StatusCode + " - " + error);
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LoginResponseDTO>(json);
        }

        // Get Tickets
        public async Task<List<TicketDTO>> GetTicketsAsync(int userId, string role)
        {
            var response = await client.GetStringAsync($"{baseUrl}tickets?userId={userId}&role={role}");
            return JsonConvert.DeserializeObject<List<TicketDTO>>(response);
        }

        // Get Ticket Details
        public async Task<TicketDTO> GetTicketDetailsAsync(int ticketId)
        {
            var response = await client.GetStringAsync($"{baseUrl}tickets/{ticketId}");
            return JsonConvert.DeserializeObject<TicketDTO>(response);
        }

        // Create Ticket
        public async Task<string> CreateTicketAsync(TicketRequest req)
        {
            var content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(baseUrl + "tickets", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        // Add Comment
        public async Task<string> AddCommentAsync(int ticketId, AddCommentRequest req)
        {
            var content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{baseUrl}tickets/{ticketId}/comments", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        // Assign Ticket (Admin)
        public async Task<string> AssignTicketAsync(int ticketId, int assignedTo)
        {
            var data = new { AssignedTo = assignedTo };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{baseUrl}tickets/{ticketId}/assign", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        // Update Status (Admin)
        public async Task<string> UpdateStatusAsync(int ticketId, string newStatus, int changedBy)
        {
            var data = new { NewStatus = newStatus, ChangedBy = changedBy };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{baseUrl}tickets/{ticketId}/status", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        // Get Comments
        public async Task<List<CommentDTO>> GetCommentsAsync(int ticketId)
        {
            var response = await client.GetStringAsync($"{baseUrl}tickets/{ticketId}/comments");
            return JsonConvert.DeserializeObject<List<CommentDTO>>(response);
        }

        // Get Status History
        public async Task<List<TicketStatusHistoryDTO>> GetStatusHistoryAsync(int ticketId)
        {
            var response = await client.GetStringAsync($"{baseUrl}tickets/{ticketId}/history");
            return JsonConvert.DeserializeObject<List<TicketStatusHistoryDTO>>(response);
        }

        public async Task<List<AdminDTO>> GetAdminsAsync()
        {
            var response = await client.GetStringAsync(baseUrl + "users/admins");
            return JsonConvert.DeserializeObject<List<AdminDTO>>(response);
        }

    }
}
