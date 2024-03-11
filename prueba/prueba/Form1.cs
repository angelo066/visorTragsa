using visorParcelas_1.Controllers;

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
            ParcelaController controller = new ParcelaController();

            controller.Get();
        }
    }
}
