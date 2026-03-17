using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicketSystemDesktop.Models;
using TicketSystemDesktop.Services;

namespace TicketSystemDesktop
{
    public partial class TicketDetailsForm : Form
    {
        private TicketDTO ticket;
        private string role;
        private int userId;
        private ApiService apiService;

        private List<CommentDTO> comments;
        private List<TicketStatusHistoryDTO> history;

        public TicketDetailsForm(TicketDTO ticket, string role, int userId)
        {
            InitializeComponent();
            this.ticket = ticket;
            this.role = role;
            this.userId = userId;
            apiService = new ApiService();

            // Hide Admin panel if user is not admin
            panelAdmin.Visible = role.Equals("Admin", StringComparison.OrdinalIgnoreCase);

            LoadTicketDetails();

        }

        private async Task LoadAdminDropdown()
        {
            var admins = await apiService.GetAdminsAsync(); // fetch from API

            cmbAssignTo.DataSource = admins;
            cmbAssignTo.DisplayMember = "Username"; // show usernames
            cmbAssignTo.ValueMember = "UserId";     // store IDs
            cmbAssignTo.SelectedIndex = 0;
        }

        private async void LoadTicketDetails()
        {
            try
            {
                // Fill Ticket Info labels
                lblTicketNumber.Text = ticket.TicketNumber;
                lblSubject.Text = ticket.Subject;
                txtDescription.Text = ticket.Description;
                lblPriority.Text = ticket.Priority;
                lblStatus.Text = ticket.Status;
                lblCreatedDate.Text = ticket.CreatedDate.ToString("g"); // general format
                lblAssignedTo.Text = string.IsNullOrEmpty(ticket.AssignedToUsername)
                     ? "Not Assigned"
                     : ticket.AssignedToUsername;

                // Load Comments
                comments = await apiService.GetCommentsAsync(ticket.TicketId);
                dgvComments.DataSource = null;
                dgvComments.DataSource = comments;
                dgvComments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Hide unnecessary columns safely
                if (dgvComments.Columns["CommentId"] != null)
                    dgvComments.Columns["CommentId"].Visible = false;

                if (dgvComments.Columns["TicketId"] != null)
                    dgvComments.Columns["TicketId"].Visible = false;

                if (dgvComments.Columns["CreatedBy"] != null)
                    dgvComments.Columns["CreatedBy"].Visible = false;

                // Rename Username column if exists
                if (dgvComments.Columns["Username"] != null)
                    dgvComments.Columns["Username"].HeaderText = "Created By";

                if (dgvComments.Columns["CreatedDate"] != null)
                    dgvComments.Columns["CreatedDate"].HeaderText = "Created Date";

                // Load Status History
                history = await apiService.GetStatusHistoryAsync(ticket.TicketId);
                dgvHistory.DataSource = null;
                dgvHistory.DataSource = history;

                // Hide numeric ID column
                if (dgvHistory.Columns["ChangedBy"] != null)
                    dgvHistory.Columns["ChangedBy"].Visible = false;

                // Rename the Username column to show "Updated By"
                if (dgvHistory.Columns["Username"] != null)
                    dgvHistory.Columns["Username"].HeaderText = "Updated By";

                // Optional: adjust column sizing
                dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Load Admin dropdowns if admin
                if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    await LoadAdminDropdown(); // <-- this loads all admins from API and binds usernames
                    cmbStatus.Items.Clear();
                    cmbStatus.Items.AddRange(new string[] { "Open", "In Progress", "Closed" });
                    cmbStatus.SelectedItem = ticket.Status;
                    cmbStatus.Items.Clear();
                    cmbStatus.Items.AddRange(new string[] { "Open", "In Progress", "Closed" });
                    cmbStatus.SelectedItem = ticket.Status;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading ticket details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAddComment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewComment.Text))
            {
                MessageBox.Show("Please enter a comment.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                AddCommentRequest req = new AddCommentRequest()
                {
                    CommentText = txtNewComment.Text,
                    CreatedBy = userId
                };

                await apiService.AddCommentAsync(ticket.TicketId, req);

                txtNewComment.Clear();

                LoadTicketDetails(); // reload comments
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding comment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                int assignedTo = (int)cmbAssignTo.SelectedValue;
                string newStatus = cmbStatus.SelectedItem.ToString();

                // Update assignment
                await apiService.AssignTicketAsync(ticket.TicketId, assignedTo);

                // Update status
                await apiService.UpdateStatusAsync(ticket.TicketId, newStatus, userId);

                MessageBox.Show("Ticket updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadTicketDetails(); // reload ticket info
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating ticket: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

