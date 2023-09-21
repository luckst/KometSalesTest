using KometSales.Common.Entities.Models;
using Newtonsoft.Json;
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
            catch (Exception ex)
            {
                MessageBox.Show("Auth error: " + ex.Message);
            }
        }

        private async Task<string> Authenticate(string username, string password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.ApiBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestBody = new LoginModel
                {
                    UserName = username,
                    Password = password
                };

                string jsonRequestBody = JsonConvert.SerializeObject(requestBody);

                var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();
                    return token;
                }

                return null;
            }
        }
    }
}
