using KometSales.Common.Entities.Dtos;
using KometSales.Common.Entities.Models;
using KometSales.Common.Exceptions;
using KometSales.Common.Utils;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace KometSales.Administrator
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            try
            {
                string token = await Authenticate(username, password);

                if (!string.IsNullOrEmpty(token))
                {
                    AppContext.AuthToken = token;
                    var mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid credentials. Try again");
                }
            }
            catch (AppException)
            {
                MessageBox.Show("Invalid credentials. Try again");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Auth error: " + ex.Message);
            }
        }

        private async Task<string> Authenticate(string username, string password)
        {
            var requestBody = new LoginModel
            {
                UserName = username,
                Password = password
            };

            var tokenResponse = await HttpUtil.SendAsync<LoginModel, TokenDto>(AppContext.AuthToken, $"{Constants.ApiBaseUrl}auth/login", HttpMethod.Post, body: requestBody);

            return tokenResponse.Token;
        }
    }
}
