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
        // llama a la url
        async Task callAsync()
        {
            if (!checkArgsType()) return;

            //Conexión al servidor
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
                else
                {
                    MessageBox.Show("Hay algún parámetro erróneo o no existe esta parcela", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool checkArgsType()
        {
            //Comprobamos que los argumentos se pueden parsear a números enteros y resaltamos en rojo el que esté mal.
            bool isCorrect = true;
            try
            {
                int provincia = int.Parse(provinciaText.Text);
                provinciaLabel.ForeColor = Color.Black;
            }
            catch
            {
                provinciaLabel.ForeColor = Color.Red;
                isCorrect = false;
            }
            try
            {
                int municipio = int.Parse(municipioText.Text);
                municipioLabel.ForeColor = Color.Black;
            }
            catch
            {
                municipioLabel.ForeColor = Color.Red;
                isCorrect = false;
            }
            try
            {
                int agregado = int.Parse(agregadoText.Text);
                agregadoLabel.ForeColor = Color.Black;
            }
            catch
            {
                agregadoLabel.ForeColor = Color.Red;
                isCorrect = false;
            }
            try
            {
                int zona = int.Parse(zonaText.Text);
                zonaLabel.ForeColor = Color.Black;
            }
            catch
            {
                zonaLabel.ForeColor = Color.Red;
                isCorrect = false;
            }
            try
            {
                poligonoLabel.ForeColor = Color.Black;
                int poligono = int.Parse(poligonoText.Text);
            }
            catch
            {
                poligonoLabel.ForeColor = Color.Red;
                isCorrect = false;
            }
            try
            {
                int parcela = int.Parse(parcelaText.Text);
                parcelaLabel.ForeColor = Color.Black;
            }
            catch
            {
                parcelaLabel.ForeColor = Color.Red;
                isCorrect = false;
            }
            if(!isCorrect)
                MessageBox.Show("Los parámetros deben ser números enteros", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return isCorrect;
        }
    }
}
