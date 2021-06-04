
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
            this.IngresoTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.IngresoInformacionButton = new System.Windows.Forms.Button();
            this.TablaSimbolosButton = new System.Windows.Forms.Button();
            this.IngresoInfoButton = new System.Windows.Forms.Button();
            this.ErroresButton = new System.Windows.Forms.Button();
            this.panelSimbolos = new System.Windows.Forms.Panel();
            this.TablaDummies = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.TablaLiteralesGrid = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.TablaReservadas = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tablasimbolos = new System.Windows.Forms.DataGridView();
            this.panelErrores = new System.Windows.Forms.Panel();
            this.ErroresSemanticosGrid = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.ErroresSintacticosGrid = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ErroresLexicosGrid = new System.Windows.Forms.DataGridView();
            this.LexemaC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroLineaC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosicionInicialC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosicionFinalC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.EOFButton = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelSimbolos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaDummies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablaLiteralesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablaReservadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablasimbolos)).BeginInit();
            this.panelErrores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErroresSemanticosGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErroresSintacticosGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErroresLexicosGrid)).BeginInit();
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
            // panelSimbolos
            // 
            this.panelSimbolos.Controls.Add(this.TablaDummies);
            this.panelSimbolos.Controls.Add(this.label6);
            this.panelSimbolos.Controls.Add(this.TablaLiteralesGrid);
            this.panelSimbolos.Controls.Add(this.label5);
            this.panelSimbolos.Controls.Add(this.TablaReservadas);
            this.panelSimbolos.Controls.Add(this.label4);
            this.panelSimbolos.Controls.Add(this.label2);
            this.panelSimbolos.Controls.Add(this.tablasimbolos);
            this.panelSimbolos.Location = new System.Drawing.Point(12, 39);
            this.panelSimbolos.Name = "panelSimbolos";
            this.panelSimbolos.Size = new System.Drawing.Size(755, 402);
            this.panelSimbolos.TabIndex = 12;
            this.panelSimbolos.Visible = false;
            // 
            // TablaDummies
            // 
            this.TablaDummies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaDummies.Location = new System.Drawing.Point(27, 321);
            this.TablaDummies.Name = "TablaDummies";
            this.TablaDummies.Size = new System.Drawing.Size(699, 76);
            this.TablaDummies.TabIndex = 7;
            this.TablaDummies.Text = "dataGridView2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tabla de Dummies";
            // 
            // TablaLiteralesGrid
            // 
            this.TablaLiteralesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaLiteralesGrid.Location = new System.Drawing.Point(27, 215);
            this.TablaLiteralesGrid.Name = "TablaLiteralesGrid";
            this.TablaLiteralesGrid.Size = new System.Drawing.Size(699, 76);
            this.TablaLiteralesGrid.TabIndex = 5;
            this.TablaLiteralesGrid.Text = "dataGridView3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tabla de Literales";
            // 
            // TablaReservadas
            // 
            this.TablaReservadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaReservadas.Location = new System.Drawing.Point(27, 120);
            this.TablaReservadas.Name = "TablaReservadas";
            this.TablaReservadas.Size = new System.Drawing.Size(699, 74);
            this.TablaReservadas.TabIndex = 3;
            this.TablaReservadas.Text = "dataGridView2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Palabras reservadas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tabla de Simbolos";
            // 
            // tablasimbolos
            // 
            this.tablasimbolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablasimbolos.Location = new System.Drawing.Point(27, 23);
            this.tablasimbolos.Name = "tablasimbolos";
            this.tablasimbolos.Size = new System.Drawing.Size(699, 76);
            this.tablasimbolos.TabIndex = 0;
            this.tablasimbolos.Text = "dataGridView1";
            // 
            // panelErrores
            // 
            this.panelErrores.Controls.Add(this.ErroresSemanticosGrid);
            this.panelErrores.Controls.Add(this.label9);
            this.panelErrores.Controls.Add(this.ErroresSintacticosGrid);
            this.panelErrores.Controls.Add(this.label8);
            this.panelErrores.Controls.Add(this.label7);
            this.panelErrores.Controls.Add(this.ErroresLexicosGrid);
            this.panelErrores.Location = new System.Drawing.Point(12, 39);
            this.panelErrores.Name = "panelErrores";
            this.panelErrores.Size = new System.Drawing.Size(755, 406);
            this.panelErrores.TabIndex = 14;
            this.panelErrores.Visible = false;
            // 
            // ErroresSemanticosGrid
            // 
            this.ErroresSemanticosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ErroresSemanticosGrid.Location = new System.Drawing.Point(11, 265);
            this.ErroresSemanticosGrid.Name = "ErroresSemanticosGrid";
            this.ErroresSemanticosGrid.Size = new System.Drawing.Size(726, 86);
            this.ErroresSemanticosGrid.TabIndex = 4;
            this.ErroresSemanticosGrid.Text = "dataGridView3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Errores semánticos";
            // 
            // ErroresSintacticosGrid
            // 
            this.ErroresSintacticosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ErroresSintacticosGrid.Location = new System.Drawing.Point(11, 139);
            this.ErroresSintacticosGrid.Name = "ErroresSintacticosGrid";
            this.ErroresSintacticosGrid.Size = new System.Drawing.Size(726, 93);
            this.ErroresSintacticosGrid.TabIndex = 2;
            this.ErroresSintacticosGrid.Text = "dataGridView2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Errores Sintácticos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Errores Lexicos";
            // 
            // ErroresLexicosGrid
            // 
            this.ErroresLexicosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ErroresLexicosGrid.Location = new System.Drawing.Point(11, 32);
            this.ErroresLexicosGrid.Name = "ErroresLexicosGrid";
            this.ErroresLexicosGrid.Size = new System.Drawing.Size(726, 86);
            this.ErroresLexicosGrid.TabIndex = 0;
            this.ErroresLexicosGrid.Text = "dataGridView3";
            // 
            // LexemaC
            // 
            this.LexemaC.Name = "LexemaC";
            // 
            // CategoriaC
            // 
            this.CategoriaC.Name = "CategoriaC";
            // 
            // NumeroLineaC
            // 
            this.NumeroLineaC.Name = "NumeroLineaC";
            // 
            // PosicionInicialC
            // 
            this.PosicionInicialC.Name = "PosicionInicialC";
            // 
            // PosicionFinalC
            // 
            this.PosicionFinalC.Name = "PosicionFinalC";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 426);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(194, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "Resultado Proceso de Compilación:";
            // 
            // EOFButton
            // 
            this.EOFButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.EOFButton.Location = new System.Drawing.Point(212, 422);
            this.EOFButton.Name = "EOFButton";
            this.EOFButton.Size = new System.Drawing.Size(75, 23);
            this.EOFButton.TabIndex = 16;
            this.EOFButton.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(541, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(104, 19);
            this.radioButton1.TabIndex = 17;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Morse->Latino";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(660, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(104, 19);
            this.radioButton2.TabIndex = 18;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Latino->Morse";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.EOFButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panelSimbolos);
            this.Controls.Add(this.panelErrores);
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
            this.panelSimbolos.ResumeLayout(false);
            this.panelSimbolos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaDummies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablaLiteralesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablaReservadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablasimbolos)).EndInit();
            this.panelErrores.ResumeLayout(false);
            this.panelErrores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErroresSemanticosGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErroresSintacticosGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErroresLexicosGrid)).EndInit();
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
        private System.Windows.Forms.ToolStripTextBox IngresoTextBox;
        private System.Windows.Forms.Button IngresoInformacionButton;
        private System.Windows.Forms.Button TablaSimbolosButton;
        private System.Windows.Forms.Button IngresoInfoButton;
        private System.Windows.Forms.Button ErroresButton;
        private System.Windows.Forms.DataGridView tablasimbolos;
        private System.Windows.Forms.Panel panelSimbolos;
        private System.Windows.Forms.Panel panelErrores;
        private System.Windows.Forms.DataGridView ErroresLexicosGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn LexemaC;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroLineaC;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosicionInicialC;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosicionFinalC;
        private System.Windows.Forms.DataGridView TablaReservadas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView TablaLiteralesGrid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView TablaDummies;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView ErroresSemanticosGrid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView ErroresSintacticosGrid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button EOFButton;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}

