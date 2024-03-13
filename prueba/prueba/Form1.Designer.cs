namespace prueba
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            municipioText = new TextBox();
            agregadoText = new TextBox();
            zonaText = new TextBox();
            poligonoText = new TextBox();
            parcelaText = new TextBox();
            buscarParcela = new Button();
            textLabel = new Label();
            provinciaLabel = new Label();
            municipioLabel = new Label();
            agregadoLabel = new Label();
            zonaLabel = new Label();
            poligonoLabel = new Label();
            parcelaLabel = new Label();
            provinciaText = new TextBox();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // municipioText
            // 
            municipioText.Anchor = AnchorStyles.Top;
            municipioText.Location = new Point(147, 82);
            municipioText.Margin = new Padding(4, 3, 4, 3);
            municipioText.Name = "municipioText";
            municipioText.Size = new Size(223, 23);
            municipioText.TabIndex = 1;
            // 
            // agregadoText
            // 
            agregadoText.Anchor = AnchorStyles.Top;
            agregadoText.Location = new Point(147, 132);
            agregadoText.Margin = new Padding(4, 3, 4, 3);
            agregadoText.Name = "agregadoText";
            agregadoText.Size = new Size(223, 23);
            agregadoText.TabIndex = 2;
            // 
            // zonaText
            // 
            zonaText.Anchor = AnchorStyles.Top;
            zonaText.Location = new Point(147, 182);
            zonaText.Margin = new Padding(4, 3, 4, 3);
            zonaText.Name = "zonaText";
            zonaText.Size = new Size(223, 23);
            zonaText.TabIndex = 3;
            // 
            // poligonoText
            // 
            poligonoText.Anchor = AnchorStyles.Top;
            poligonoText.Location = new Point(147, 231);
            poligonoText.Margin = new Padding(4, 3, 4, 3);
            poligonoText.Name = "poligonoText";
            poligonoText.Size = new Size(223, 23);
            poligonoText.TabIndex = 4;
            // 
            // parcelaText
            // 
            parcelaText.Anchor = AnchorStyles.Top;
            parcelaText.Location = new Point(147, 281);
            parcelaText.Margin = new Padding(4, 3, 4, 3);
            parcelaText.Name = "parcelaText";
            parcelaText.Size = new Size(223, 23);
            parcelaText.TabIndex = 5;
            // 
            // buscarParcela
            // 
            buscarParcela.Anchor = AnchorStyles.Top;
            buscarParcela.Location = new Point(147, 325);
            buscarParcela.Margin = new Padding(4, 3, 4, 3);
            buscarParcela.Name = "buscarParcela";
            buscarParcela.Size = new Size(224, 27);
            buscarParcela.TabIndex = 6;
            buscarParcela.Text = "Buscar";
            buscarParcela.UseVisualStyleBackColor = true;
            buscarParcela.Click += button1_Click;
            // 
            // textLabel
            // 
            textLabel.Anchor = AnchorStyles.Top;
            textLabel.Location = new Point(133, 0);
            textLabel.Margin = new Padding(4, 0, 4, 0);
            textLabel.Name = "textLabel";
            textLabel.Size = new Size(117, 27);
            textLabel.TabIndex = 15;
            // 
            // provinciaLabel
            // 
            provinciaLabel.Anchor = AnchorStyles.Top;
            provinciaLabel.AutoSize = true;
            provinciaLabel.Location = new Point(147, 14);
            provinciaLabel.Margin = new Padding(4, 0, 4, 0);
            provinciaLabel.Name = "provinciaLabel";
            provinciaLabel.Size = new Size(56, 15);
            provinciaLabel.TabIndex = 8;
            provinciaLabel.Text = "Provincia";
            // 
            // municipioLabel
            // 
            municipioLabel.Anchor = AnchorStyles.Top;
            municipioLabel.AutoSize = true;
            municipioLabel.Location = new Point(147, 64);
            municipioLabel.Margin = new Padding(4, 0, 4, 0);
            municipioLabel.Name = "municipioLabel";
            municipioLabel.Size = new Size(61, 15);
            municipioLabel.TabIndex = 9;
            municipioLabel.Text = "Municipio";
            // 
            // agregadoLabel
            // 
            agregadoLabel.Anchor = AnchorStyles.Top;
            agregadoLabel.AutoSize = true;
            agregadoLabel.Location = new Point(147, 113);
            agregadoLabel.Margin = new Padding(4, 0, 4, 0);
            agregadoLabel.Name = "agregadoLabel";
            agregadoLabel.Size = new Size(59, 15);
            agregadoLabel.TabIndex = 10;
            agregadoLabel.Text = "Agregado";
            // 
            // zonaLabel
            // 
            zonaLabel.Anchor = AnchorStyles.Top;
            zonaLabel.AutoSize = true;
            zonaLabel.Location = new Point(147, 163);
            zonaLabel.Margin = new Padding(4, 0, 4, 0);
            zonaLabel.Name = "zonaLabel";
            zonaLabel.Size = new Size(34, 15);
            zonaLabel.TabIndex = 11;
            zonaLabel.Text = "Zona";
            // 
            // poligonoLabel
            // 
            poligonoLabel.Anchor = AnchorStyles.Top;
            poligonoLabel.AutoSize = true;
            poligonoLabel.Location = new Point(147, 213);
            poligonoLabel.Margin = new Padding(4, 0, 4, 0);
            poligonoLabel.Name = "poligonoLabel";
            poligonoLabel.Size = new Size(55, 15);
            poligonoLabel.TabIndex = 12;
            poligonoLabel.Text = "Polígono";
            // 
            // parcelaLabel
            // 
            parcelaLabel.Anchor = AnchorStyles.Top;
            parcelaLabel.AutoSize = true;
            parcelaLabel.Location = new Point(147, 262);
            parcelaLabel.Margin = new Padding(4, 0, 4, 0);
            parcelaLabel.Name = "parcelaLabel";
            parcelaLabel.Size = new Size(45, 15);
            parcelaLabel.TabIndex = 13;
            parcelaLabel.Text = "Parcela";
            // 
            // provinciaText
            // 
            provinciaText.Anchor = AnchorStyles.Top;
            provinciaText.Location = new Point(147, 33);
            provinciaText.Margin = new Padding(4, 3, 4, 3);
            provinciaText.Name = "provinciaText";
            provinciaText.Size = new Size(223, 23);
            provinciaText.TabIndex = 14;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(377, 33);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(750, 319);
            dataGridView1.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1281, 515);
            Controls.Add(dataGridView1);
            Controls.Add(provinciaText);
            Controls.Add(parcelaLabel);
            Controls.Add(poligonoLabel);
            Controls.Add(zonaLabel);
            Controls.Add(agregadoLabel);
            Controls.Add(municipioLabel);
            Controls.Add(provinciaLabel);
            Controls.Add(textLabel);
            Controls.Add(buscarParcela);
            Controls.Add(parcelaText);
            Controls.Add(poligonoText);
            Controls.Add(zonaText);
            Controls.Add(agregadoText);
            Controls.Add(municipioText);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox municipioText;
        private System.Windows.Forms.TextBox agregadoText;
        private System.Windows.Forms.TextBox zonaText;
        private System.Windows.Forms.TextBox poligonoText;
        private System.Windows.Forms.TextBox parcelaText;
        private System.Windows.Forms.Button buscarParcela;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Label provinciaLabel;
        private System.Windows.Forms.Label municipioLabel;
        private System.Windows.Forms.Label agregadoLabel;
        private System.Windows.Forms.Label zonaLabel;
        private System.Windows.Forms.Label poligonoLabel;
        private System.Windows.Forms.Label parcelaLabel;
        private System.Windows.Forms.TextBox provinciaText;
        private DataGridView dataGridView1;
    }
}

