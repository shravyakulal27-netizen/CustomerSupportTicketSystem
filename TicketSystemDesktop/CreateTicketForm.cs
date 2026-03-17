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
    public partial class CreateTicketForm : Form
    {
        int userId;
        ApiService apiService = new ApiService();
        public CreateTicketForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void CreateTicketForm_Load(object sender, EventArgs e)
        {
            cmbPriority.Items.Add("Low");
            cmbPriority.Items.Add("Medium");
            cmbPriority.Items.Add("High");
            cmbPriority.SelectedIndex = 0;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(txtSubject.Text))
                {
                    MessageBox.Show("Please enter subject");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    MessageBox.Show("Please enter description");
                    return;
                }

                TicketRequest req = new TicketRequest()
                {
                    Subject = txtSubject.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Priority = cmbPriority.Text,
                    CreatedBy = userId
                };

                string result = await apiService.CreateTicketAsync(req);

                MessageBox.Show("Ticket created successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating ticket: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbPriority.SelectedIndex = 0;
            txtSubject.Text = "";
            txtDescription.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
