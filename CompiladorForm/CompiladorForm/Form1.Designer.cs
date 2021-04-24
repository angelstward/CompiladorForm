
namespace CompiladorForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.archivoCheck = new System.Windows.Forms.CheckBox();
            this.consolaCheck = new System.Windows.Forms.CheckBox();
            this.inputText = new System.Windows.Forms.TextBox();
            this.outputText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSelectArchivo = new System.Windows.Forms.Button();
            this.nameArchivoText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CargarButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroLineaC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosicionInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosicionFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngresoTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.IngresoInformacionButton = new System.Windows.Forms.Button();
            this.TablaSimbolosButton = new System.Windows.Forms.Button();
            this.IngresoInfoButton = new System.Windows.Forms.Button();
            this.ErroresButton = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSimbolos = new System.Windows.Forms.Panel();
            this.panelErrores = new System.Windows.Forms.Panel();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panelSimbolos.SuspendLayout();
            this.panelErrores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // archivoCheck
            // 
            this.archivoCheck.AutoSize = true;
            this.archivoCheck.Location = new System.Drawing.Point(49, 99);
            this.archivoCheck.Name = "archivoCheck";
            this.archivoCheck.Size = new System.Drawing.Size(67, 19);
            this.archivoCheck.TabIndex = 0;
            this.archivoCheck.Text = "Archivo";
            this.archivoCheck.UseVisualStyleBackColor = true;
            this.archivoCheck.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // consolaCheck
            // 
            this.consolaCheck.AutoSize = true;
            this.consolaCheck.Location = new System.Drawing.Point(49, 124);
            this.consolaCheck.Name = "consolaCheck";
            this.consolaCheck.Size = new System.Drawing.Size(69, 19);
            this.consolaCheck.TabIndex = 1;
            this.consolaCheck.Text = "Consola";
            this.consolaCheck.UseVisualStyleBackColor = true;
            this.consolaCheck.CheckedChanged += new System.EventHandler(this.ConsolaCheck_CheckedChanged);
            // 
            // inputText
            // 
            this.inputText.Enabled = false;
            this.inputText.Location = new System.Drawing.Point(23, 182);
            this.inputText.Multiline = true;
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(359, 223);
            this.inputText.TabIndex = 2;
            this.inputText.TextChanged += new System.EventHandler(this.InputText_TextChanged);
            // 
            // outputText
            // 
            this.outputText.Enabled = false;
            this.outputText.Location = new System.Drawing.Point(408, 182);
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(359, 223);
            this.outputText.TabIndex = 3;
            this.outputText.TextChanged += new System.EventHandler(this.OutputText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // buttonSelectArchivo
            // 
            this.buttonSelectArchivo.Enabled = false;
            this.buttonSelectArchivo.Location = new System.Drawing.Point(640, 48);
            this.buttonSelectArchivo.Name = "buttonSelectArchivo";
            this.buttonSelectArchivo.Size = new System.Drawing.Size(96, 54);
            this.buttonSelectArchivo.TabIndex = 6;
            this.buttonSelectArchivo.Text = "Selecionar Archivo";
            this.buttonSelectArchivo.UseVisualStyleBackColor = true;
            this.buttonSelectArchivo.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // nameArchivoText
            // 
            this.nameArchivoText.Enabled = false;
            this.nameArchivoText.Location = new System.Drawing.Point(49, 65);
            this.nameArchivoText.Name = "nameArchivoText";
            this.nameArchivoText.Size = new System.Drawing.Size(585, 23);
            this.nameArchivoText.TabIndex = 7;
            this.nameArchivoText.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Archivo:";
            // 
            // CargarButton
            // 
            this.CargarButton.Location = new System.Drawing.Point(640, 108);
            this.CargarButton.Name = "CargarButton";
            this.CargarButton.Size = new System.Drawing.Size(96, 35);
            this.CargarButton.TabIndex = 9;
            this.CargarButton.Text = "Cargar";
            this.CargarButton.UseVisualStyleBackColor = true;
            this.CargarButton.Click += new System.EventHandler(this.CargarButton_Click);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(692, 415);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 23);
            this.limpiarButton.TabIndex = 10;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.LimpiarButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ColumnLexema";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "ColumnCategoriaC";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "ColumnNumeroLineaC";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "ColumnPosicinInicial";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "ColumnPosicionFinal";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // Lexema
            // 
            this.Lexema.HeaderText = "ColumnLexema";
            this.Lexema.Name = "Lexema";
            // 
            // CategoriaC
            // 
            this.CategoriaC.HeaderText = "ColumnCategoriaC";
            this.CategoriaC.Name = "CategoriaC";
            // 
            // NumeroLineaC
            // 
            this.NumeroLineaC.HeaderText = "ColumnNumeroLineaC";
            this.NumeroLineaC.Name = "NumeroLineaC";
            // 
            // PosicionInicial
            // 
            this.PosicionInicial.HeaderText = "ColumnPosicinInicial";
            this.PosicionInicial.Name = "PosicionInicial";
            // 
            // PosicionFinal
            // 
            this.PosicionFinal.HeaderText = "ColumnPosicionFinal";
            this.PosicionFinal.Name = "PosicionFinal";
            // 
            // IngresoTextBox
            // 
            this.IngresoTextBox.Name = "IngresoTextBox";
            this.IngresoTextBox.Size = new System.Drawing.Size(100, 23);
            // 
            // IngresoInformacionButton
            // 
            this.IngresoInformacionButton.Location = new System.Drawing.Point(1, 1);
            this.IngresoInformacionButton.Name = "IngresoInformacionButton";
            this.IngresoInformacionButton.Size = new System.Drawing.Size(165, 23);
            this.IngresoInformacionButton.TabIndex = 13;
            this.IngresoInformacionButton.Text = "Ingreso Información";
            this.IngresoInformacionButton.UseVisualStyleBackColor = true;
            // 
            // TablaSimbolosButton
            // 
            this.TablaSimbolosButton.Location = new System.Drawing.Point(172, 1);
            this.TablaSimbolosButton.Name = "TablaSimbolosButton";
            this.TablaSimbolosButton.Size = new System.Drawing.Size(165, 23);
            this.TablaSimbolosButton.TabIndex = 13;
            this.TablaSimbolosButton.Text = "Tabla de Simbolos";
            this.TablaSimbolosButton.UseVisualStyleBackColor = true;
            this.TablaSimbolosButton.Click += new System.EventHandler(this.TablaSimbolosButton_Click);
            // 
            // IngresoInfoButton
            // 
            this.IngresoInfoButton.Location = new System.Drawing.Point(1, 1);
            this.IngresoInfoButton.Name = "IngresoInfoButton";
            this.IngresoInfoButton.Size = new System.Drawing.Size(165, 23);
            this.IngresoInfoButton.TabIndex = 13;
            this.IngresoInfoButton.Text = "Ingreso Información";
            this.IngresoInfoButton.UseVisualStyleBackColor = true;
            this.IngresoInfoButton.Click += new System.EventHandler(this.IngresoInfoButton_Click);
            // 
            // ErroresButton
            // 
            this.ErroresButton.Location = new System.Drawing.Point(343, 1);
            this.ErroresButton.Name = "ErroresButton";
            this.ErroresButton.Size = new System.Drawing.Size(165, 23);
            this.ErroresButton.TabIndex = 13;
            this.ErroresButton.Text = "Errores";
            this.ErroresButton.UseVisualStyleBackColor = true;
            this.ErroresButton.Click += new System.EventHandler(this.ErroresButton_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView2.Location = new System.Drawing.Point(30, 101);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(480, 127);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.Text = "dataGridView1";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // panelSimbolos
            // 
            this.panelSimbolos.Controls.Add(this.dataGridView2);
            this.panelSimbolos.Location = new System.Drawing.Point(388, 43);
            this.panelSimbolos.Name = "panelSimbolos";
            this.panelSimbolos.Size = new System.Drawing.Size(400, 384);
            this.panelSimbolos.TabIndex = 12;
            this.panelSimbolos.Visible = false;
            // 
            // panelErrores
            // 
            this.panelErrores.Controls.Add(this.dataGridView3);
            this.panelErrores.Location = new System.Drawing.Point(35, 43);
            this.panelErrores.Name = "panelErrores";
            this.panelErrores.Size = new System.Drawing.Size(316, 384);
            this.panelErrores.TabIndex = 14;
            this.panelErrores.Visible = false;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView3.Location = new System.Drawing.Point(14, 65);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(186, 150);
            this.dataGridView3.TabIndex = 0;
            this.dataGridView3.Text = "dataGridView3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelErrores);
            this.Controls.Add(this.panelSimbolos);
            this.Controls.Add(this.TablaSimbolosButton);
            this.Controls.Add(this.ErroresButton);
            this.Controls.Add(this.IngresoInfoButton);
            this.Controls.Add(this.IngresoInformacionButton);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.CargarButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameArchivoText);
            this.Controls.Add(this.buttonSelectArchivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.consolaCheck);
            this.Controls.Add(this.archivoCheck);
            this.Name = "Form1";
            this.Text = "Compilador";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panelSimbolos.ResumeLayout(false);
            this.panelErrores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox archivoCheck;
        private System.Windows.Forms.CheckBox consolaCheck;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelectArchivo;
        private System.Windows.Forms.TextBox nameArchivoText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CargarButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroLineaC;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosicionInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosicionFinal;
        private System.Windows.Forms.ToolStripTextBox IngresoTextBox;
        private System.Windows.Forms.Button IngresoInformacionButton;
        private System.Windows.Forms.Button TablaSimbolosButton;
        private System.Windows.Forms.Button IngresoInfoButton;
        private System.Windows.Forms.Button ErroresButton;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Panel panelSimbolos;
        private System.Windows.Forms.Panel panelErrores;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}

