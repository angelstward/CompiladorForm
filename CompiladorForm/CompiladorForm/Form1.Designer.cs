
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.archivoCheck = new System.Windows.Forms.CheckBox();
            this.consolaCheck = new System.Windows.Forms.CheckBox();
            this.inputText = new System.Windows.Forms.TextBox();
            this.outputText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonSelectArchivo = new System.Windows.Forms.Button();
            this.nameArchivoText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CargarButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(408, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.CargarButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameArchivoText);
            this.Controls.Add(this.buttonSelectArchivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.consolaCheck);
            this.Controls.Add(this.archivoCheck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Compilador";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox archivoCheck;
        private System.Windows.Forms.CheckBox consolaCheck;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonSelectArchivo;
        private System.Windows.Forms.TextBox nameArchivoText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CargarButton;
        private System.Windows.Forms.Button limpiarButton;
    }
}

