
using Newtonsoft.Json;
using visorParcelas_1.Geometry;

namespace prueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            provinciaText.Text = "28";
            municipioText.Text = "85";
            agregadoText.Text = "0";
            zonaText.Text = "0";
            poligonoText.Text = "1";
            parcelaText.Text = "1";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            resultLabel.Text = "HelloWorld: " + provinciaText.Text + ", " + municipioText.Text + ", " + agregadoText.Text + ", " +
                                                zonaText.Text + ", " + poligonoText.Text + ", " + parcelaText.Text + ".";

            callAsync();
        }

        private void provinciaText_TextChanged(object sender, EventArgs e)
        {
            municipioText.Visible = true;
            municipioLabel.Visible = true;
        }
        private void municipioText_TextChanged(object sender, EventArgs e)
        {
            agregadoText.Visible = true;
            agregadoLabel.Visible = true;
        }

        private void agregadoText_TextChanged(object sender, EventArgs e)
        {
            zonaText.Visible = true;
            zonaLabel.Visible = true;
        }

        private void zonaText_TextChanged(object sender, EventArgs e)
        {
            poligonoText.Visible = true;
            poligonoLabel.Visible = true;
        }

        private void poligonoText_TextChanged(object sender, EventArgs e)
        {
            parcelaText.Visible = true;
            parcelaLabel.Visible = true;
        }

        private void parcelaText_TextChanged(object sender, EventArgs e)
        {
            buscarParcela.Visible = true;
        }

        // llama a la url
        async Task callAsync()
        {
            var url = "https://localhost:7266/Parcela/" + provinciaText.Text + "/" + municipioText.Text + "/" + agregadoText.Text + "/"
                                                        + zonaText.Text + "/" + poligonoText.Text + "/" + parcelaText.Text;
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var geoJsonString = await response.Content.ReadAsStringAsync();
                resultLabel.Text = geoJsonString.Length.ToString();
                Root root = JsonConvert.DeserializeObject<Root>(geoJsonString);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
