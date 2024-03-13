using Newtonsoft.Json;
using prueba.Exceptions;
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

            try
            {
                int provincia = int.Parse(provinciaText.Text);
                int municipio = int.Parse(municipioText.Text);
                int agregado = int.Parse(agregadoText.Text);
                int zona = int.Parse(zonaText.Text);
                int poligono = int.Parse(poligonoText.Text);
                int parcela = int.Parse(parcelaText.Text);
            }
            catch
            {

                MessageBox.Show("Los argumentos deben ser numeros enteros", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var url = "https://localhost:7266/Parcela/" + provinciaText.Text + "/" + municipioText.Text + "/" + agregadoText.Text + "/"
                                                        + zonaText.Text + "/" + poligonoText.Text + "/" + parcelaText.Text;
            var httpClient = new HttpClient();

            try
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var geoJsonString = await response.Content.ReadAsStringAsync();
                    Root root = JsonConvert.DeserializeObject<Root>(geoJsonString);
                    if (root.features == null) throw new ParcelaInexistenteException("Esa parcela no existe");
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
                else { 
                    MessageBox.Show("Hay algún parámetro erróneo o no existe esta parcela", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
