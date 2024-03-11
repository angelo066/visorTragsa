namespace WindowsFormsApp1
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
            this.municipioText = new System.Windows.Forms.TextBox();
            this.agregadoText = new System.Windows.Forms.TextBox();
            this.zonaText = new System.Windows.Forms.TextBox();
            this.poligonoText = new System.Windows.Forms.TextBox();
            this.parcelaText = new System.Windows.Forms.TextBox();
            this.buscarParcela = new System.Windows.Forms.Button();
            this.textLabel = new System.Windows.Forms.Label();
            this.provinciaLabel = new System.Windows.Forms.Label();
            this.municipioLabel = new System.Windows.Forms.Label();
            this.agregadoLabel = new System.Windows.Forms.Label();
            this.zonaLabel = new System.Windows.Forms.Label();
            this.poligonoLabel = new System.Windows.Forms.Label();
            this.parcelaLabel = new System.Windows.Forms.Label();
            this.provinciaText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // municipioText
            // 
            this.municipioText.Location = new System.Drawing.Point(12, 67);
            this.municipioText.Name = "municipioText";
            this.municipioText.Size = new System.Drawing.Size(192, 20);
            this.municipioText.TabIndex = 1;
            this.municipioText.Visible = false;
            this.municipioText.TextChanged += new System.EventHandler(this.municipioText_TextChanged);
            // 
            // agregadoText
            // 
            this.agregadoText.Location = new System.Drawing.Point(12, 110);
            this.agregadoText.Name = "agregadoText";
            this.agregadoText.Size = new System.Drawing.Size(192, 20);
            this.agregadoText.TabIndex = 2;
            this.agregadoText.Visible = false;
            this.agregadoText.TextChanged += new System.EventHandler(this.agregadoText_TextChanged);
            // 
            // zonaText
            // 
            this.zonaText.Location = new System.Drawing.Point(12, 153);
            this.zonaText.Name = "zonaText";
            this.zonaText.Size = new System.Drawing.Size(192, 20);
            this.zonaText.TabIndex = 3;
            this.zonaText.Visible = false;
            this.zonaText.TextChanged += new System.EventHandler(this.zonaText_TextChanged);
            // 
            // poligonoText
            // 
            this.poligonoText.Location = new System.Drawing.Point(12, 196);
            this.poligonoText.Name = "poligonoText";
            this.poligonoText.Size = new System.Drawing.Size(192, 20);
            this.poligonoText.TabIndex = 4;
            this.poligonoText.Visible = false;
            this.poligonoText.TextChanged += new System.EventHandler(this.poligonoText_TextChanged);
            // 
            // parcelaText
            // 
            this.parcelaText.Location = new System.Drawing.Point(12, 239);
            this.parcelaText.Name = "parcelaText";
            this.parcelaText.Size = new System.Drawing.Size(192, 20);
            this.parcelaText.TabIndex = 5;
            this.parcelaText.Visible = false;
            this.parcelaText.TextChanged += new System.EventHandler(this.parcelaText_TextChanged);
            // 
            // buscarParcela
            // 
            this.buscarParcela.Location = new System.Drawing.Point(12, 266);
            this.buscarParcela.Name = "buscarParcela";
            this.buscarParcela.Size = new System.Drawing.Size(192, 23);
            this.buscarParcela.TabIndex = 6;
            this.buscarParcela.Text = "Buscar";
            this.buscarParcela.UseVisualStyleBackColor = true;
            this.buscarParcela.Click += new System.EventHandler(this.buscarParcela_Click);
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(424, 186);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(0, 13);
            this.textLabel.TabIndex = 7;
            this.textLabel.Click += new System.EventHandler(this.textLabel_Click);
            // 
            // provinciaLabel
            // 
            this.provinciaLabel.AutoSize = true;
            this.provinciaLabel.Location = new System.Drawing.Point(12, 12);
            this.provinciaLabel.Name = "provinciaLabel";
            this.provinciaLabel.Size = new System.Drawing.Size(51, 13);
            this.provinciaLabel.TabIndex = 8;
            this.provinciaLabel.Text = "Provincia";
            // 
            // municipioLabel
            // 
            this.municipioLabel.AutoSize = true;
            this.municipioLabel.Location = new System.Drawing.Point(9, 51);
            this.municipioLabel.Name = "municipioLabel";
            this.municipioLabel.Size = new System.Drawing.Size(52, 13);
            this.municipioLabel.TabIndex = 9;
            this.municipioLabel.Text = "Municipio";
            this.municipioLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // agregadoLabel
            // 
            this.agregadoLabel.AutoSize = true;
            this.agregadoLabel.Location = new System.Drawing.Point(12, 94);
            this.agregadoLabel.Name = "agregadoLabel";
            this.agregadoLabel.Size = new System.Drawing.Size(53, 13);
            this.agregadoLabel.TabIndex = 10;
            this.agregadoLabel.Text = "Agregado";
            // 
            // zonaLabel
            // 
            this.zonaLabel.AutoSize = true;
            this.zonaLabel.Location = new System.Drawing.Point(12, 137);
            this.zonaLabel.Name = "zonaLabel";
            this.zonaLabel.Size = new System.Drawing.Size(32, 13);
            this.zonaLabel.TabIndex = 11;
            this.zonaLabel.Text = "Zona";
            // 
            // poligonoLabel
            // 
            this.poligonoLabel.AutoSize = true;
            this.poligonoLabel.Location = new System.Drawing.Point(12, 180);
            this.poligonoLabel.Name = "poligonoLabel";
            this.poligonoLabel.Size = new System.Drawing.Size(50, 13);
            this.poligonoLabel.TabIndex = 12;
            this.poligonoLabel.Text = "Polígono";
            // 
            // parcelaLabel
            // 
            this.parcelaLabel.AutoSize = true;
            this.parcelaLabel.Location = new System.Drawing.Point(12, 223);
            this.parcelaLabel.Name = "parcelaLabel";
            this.parcelaLabel.Size = new System.Drawing.Size(43, 13);
            this.parcelaLabel.TabIndex = 13;
            this.parcelaLabel.Text = "Parcela";
            // 
            // provinciaText
            // 
            this.provinciaText.Location = new System.Drawing.Point(12, 29);
            this.provinciaText.Name = "provinciaText";
            this.provinciaText.Size = new System.Drawing.Size(192, 20);
            this.provinciaText.TabIndex = 14;
            this.provinciaText.TextChanged += new System.EventHandler(this.provinciaText_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 646);
            this.Controls.Add(this.provinciaText);
            this.Controls.Add(this.parcelaLabel);
            this.Controls.Add(this.poligonoLabel);
            this.Controls.Add(this.zonaLabel);
            this.Controls.Add(this.agregadoLabel);
            this.Controls.Add(this.municipioLabel);
            this.Controls.Add(this.provinciaLabel);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.buscarParcela);
            this.Controls.Add(this.parcelaText);
            this.Controls.Add(this.poligonoText);
            this.Controls.Add(this.zonaText);
            this.Controls.Add(this.agregadoText);
            this.Controls.Add(this.municipioText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

