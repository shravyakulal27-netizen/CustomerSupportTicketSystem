using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicketSystemDesktop.Services;
using TicketSystemDesktop.Models;

namespace TicketSystemDesktop
{
    public partial class TicketListForm : Form
    {

        private ApiService apiService;
        private int userId;
        private string role;
        private List<TicketDTO> tickets;

        public TicketListForm(int userId, string role)
        {
            InitializeComponent();
            apiService = new ApiService();
            this.userId = userId;
            this.role = role;

            if (role == "Admin")
            {
                btnCreateTicket.Visible = false;
            }
            else
            {
                btnCreateTicket.Visible = true;
            }

            LoadTickets();
        }

        private async void LoadTickets()
        {
            try
            {
                tickets = await apiService.GetTicketsAsync(userId, role);
                dgvTickets.DataSource = null;
                dgvTickets.DataSource = tickets;

                // Optional: hide certain columns if needed
                dgvTickets.Columns["TicketId"].Visible = false;
                dgvTickets.Columns["CreatedBy"].Visible = false;
                dgvTickets.Columns["AssignedTo"].Visible = false;
                dgvTickets.Columns["Description"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tickets: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTickets();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvTickets.CurrentRow == null)
            {
                MessageBox.Show("Please select a ticket.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ticket = (TicketDTO)dgvTickets.CurrentRow.DataBoundItem;

            // Open Ticket Details Form
            TicketDetailsForm detailsForm = new TicketDetailsForm(ticket, role, userId);
            detailsForm.ShowDialog();

            // Refresh tickets after closing details
            LoadTickets();
        }

        private void btnCreateTicket_Click(object sender, EventArgs e)
        {
            CreateTicketForm form = new CreateTicketForm(userId);
            form.ShowDialog();

            LoadTickets(); // refresh ticket list
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            // Create and show login form
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            // Close current form (TicketListForm)
            this.Close();
        }
    }
}
