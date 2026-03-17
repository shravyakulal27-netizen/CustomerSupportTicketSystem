using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using TicketSystemDesktop.Services;
using TicketSystemDesktop.Models;

namespace TicketSystemDesktop
{
    public partial class LoginForm : Form
    {
        private ApiService apiService;
        public LoginForm()
        {
            InitializeComponent();
            apiService = new ApiService();
        }
        // Map API response
        public class LoginResponse
        {
            public string message { get; set; }
            public string role { get; set; }
            public int userId { get; set; }
        }

        private async void btnlogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            btnLogin.Enabled = false;

            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    lblError.Text = "Please enter username and password.";
                    btnLogin.Enabled = true;
                    return;
                }

                LoginResponseDTO response = await apiService.LoginAsync(username, password);

                if (response != null)
                {
                    MessageBox.Show($"Login successful! Role: {response.Role}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TicketListForm ticketList = new TicketListForm(response.UserId, response.Role);
                    ticketList.Show();

                    this.Hide();
                }
                else
                {
                    lblError.Text = "Invalid credentials.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error: " + ex.Message;
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}


