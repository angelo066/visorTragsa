
using Newtonsoft.Json;
using System.ComponentModel;
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

                var data = root.features.Select(f => new
                {
                    Provincia = f.properties.provincia,
                    Municipio = f.properties.municipio,
                    Agregado = f.properties.agregado,
                    Zona = f.properties.zona,
                    Poligono = f.properties.poligono,
                    Parcela = f.properties.parcela,
                    Recinto = f.properties.recinto,
                    Altitud = f.properties.altitud,
                    PendienteMedia = f.properties.pendiente_media,
                    Coordinates = string.Join(", ", f.geometry.coordinates.SelectMany(level1 => level1.SelectMany(level2 => level2))),
                    GeometryType = f.geometry.type,
                }).ToList<object>();

                dataGridView1.DataSource = new BindingList<object>(data);

                dataGridView1.AllowUserToAddRows = false;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("Homer");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si se hizo clic en la última fila
            if (e.RowIndex == dataGridView1.Rows.Count - 1)
            {
                // Evita acciones en la última fila
                return;
            }

            // Acciones específicas al hacer clic en una celda válida
            // Puedes acceder a la fila y sus valores usando dataGridView1.Rows[e.RowIndex]
        }
    }
}
