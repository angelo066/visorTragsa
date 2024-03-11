using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buscarParcela_Click(object sender, EventArgs e)
        {
            textLabel.Text = provinciaText.Text + municipioText.Text + agregadoText.Text + zonaText.Text + poligonoText.Text + parcelaText.Text;
        }

        private void textLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void provinciaText_TextChanged(object sender, EventArgs e)
        {
            municipioText.Visible = true;
        }
        private void municipioText_TextChanged(object sender, EventArgs e)
        {
            agregadoText.Visible = true;
        }

        private void agregadoText_TextChanged(object sender, EventArgs e)
        {
            zonaText.Visible = true;
        }

        private void zonaText_TextChanged(object sender, EventArgs e)
        {
            poligonoText.Visible = true;
        }

        private void poligonoText_TextChanged(object sender, EventArgs e)
        {
            parcelaText.Visible = true;
        }

        private void parcelaText_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
