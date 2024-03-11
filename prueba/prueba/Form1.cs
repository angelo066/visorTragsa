using Newtonsoft.Json;
using System.Text.Json.Serialization;
using visorParcelas_1.Controllers;
using visorParcelas_1.Geometry;

namespace prueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void vomito_Click(object sender, EventArgs e)
        {
            lolAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        async Task lolAsync()
        {
            var url = "https://localhost:7266/Parcela/28/85/0/0/1/1"; // Reemplaza con la URL correcta
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var geoJsonString = await response.Content.ReadAsStringAsync();
                resultLabel.Text = geoJsonString.ToString();
                Root root = JsonConvert.DeserializeObject<Root>(geoJsonString);
                // Procesa el geojson según tus necesidades
            }
        }
    }
}
