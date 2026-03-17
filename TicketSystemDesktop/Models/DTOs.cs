using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystemDesktop.Models
{
    public class LoginResponseDTO
    {
        public int UserId { get; set; }
        public string Role { get; set; }
    }

    public class TicketDTO
    {
        public int TicketId { get; set; }
        public string TicketNumber { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? AssignedTo { get; set; }

        public string AssignedToUsername { get; set; }
    }

    public class TicketStatusHistoryDTO
    {
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
        public DateTime ChangedDate { get; set; }
        public int ChangedBy { get; set; }
        public string Username { get; set; }
    }

    public class CommentDTO
    {
        public int CommentId { get; set; }
        public int TicketId { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string Username { get; set; } 
    }

    public class TicketRequest
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public int CreatedBy { get; set; }
    }

    public class AddCommentRequest
    {
        public string CommentText { get; set; }
        public int CreatedBy { get; set; }
    }

    public class AdminDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
    }
}
