using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RabbitMQ.Practice.Core.Extensions;

namespace RabbitMQ.Practice.WinApp
{
    public partial class Form1 : Form
    {
        private string hostUrl;
        private string userName;
        private string password;

        public Form1()
        {
            InitializeComponent();
            this.tb_host_name.Text = "http://localhost:15672";
            this.tb_username.Text = "guest";
            this.tb_password.Text = "guest";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hostUrl = this.tb_host_name.Text.Trim();
            userName = this.tb_username.Text.Trim();
            password = this.tb_password.Text.Trim();

            DisplayExchanges(hostUrl);
        }

        private async void DisplayExchanges(string url)
        {
            listbox_exists_exchanges.Items.Clear();
            // TODO: Debug exception
            var exchangesList = await GetExchanges(url);
            if (exchangesList.IsNullOrEmpty())
            {
                foreach (var exchange in exchangesList)
                {
                    listbox_exists_exchanges.Items.Add(exchange);
                }
            }
        }

        private async Task<List<ExchangeEntity>> GetExchanges(string url)
        {
            string jsonContent = await ShowApiResult(url);
            var exchanges = JsonConvert.DeserializeObject<List<ExchangeEntity>>(jsonContent);
            var sysExchanges = (from object item in listbox_exists_exchanges.Items select item.ToString().Trim()).ToList();
            var exchangeEntities = exchanges.Where(x => !sysExchanges.Contains(x.name.Trim())).ToList();
            return exchangeEntities;
        }

        private async Task<string> ShowApiResult(string url)
        {
            var response = await ShowHttpClientResult(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        private async Task<HttpResponseMessage> ShowHttpClientResult(string url)
        {
            var client = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes($"{userName}:{password}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",Convert.ToBase64String(byteArray));
            HttpResponseMessage response = await client.GetAsync(url);
            return response;
        }
    }

}
