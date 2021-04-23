using CompiladorForm.AnalisisLexico;
using CompiladorForm.Transversal;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CompiladorForm
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void Resetear(){
            Cache.ObtenerCache().Limpiar();
            ManejadorErrores.Limpirar();
            TablaMaestra.Limpiar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Resetear
            Resetear();

            //Cargar a caché los datos

            try{
                //Disparar el procesamiento a nivel de Analizador Léxico
                AnalizadorLexico anaLex = new AnalizadorLexico();
                ComponenteLexico componente = anaLex.Analizar();

                while(!componente.ObtenerCategoria.Equals(Categoria.FIN_ARCHIVO))
                {
                     MessageBox.Show(componente.ToString());
                     componente = anaLex.Analizar();
                }
                if(ManejadorErrores.HayErrores()){
                    MessageBox.Show("El proceso de compilación ha finalizado con errores.");
                }
                else {
                    MessageBox.Show("El proceso de compilación ha finalizado de forma exitosa.");
                }

            }catch(Exception exception) 
            {
                MessageBox.Show(exception.Message);
            }
           

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (archivoCheck.Checked)
            {
                inputText.Text = string.Empty;
                inputText.Enabled = false;
                consolaCheck.Checked = false;
                buttonSelectArchivo.Enabled = true;
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ConsolaCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (consolaCheck.Checked)
            {
                inputText.Enabled = true;
                archivoCheck.Checked = false;
                buttonSelectArchivo.Enabled = false;
                nameArchivoText.Text = string.Empty;
            }
        }

        private void InputText_TextChanged(object sender, EventArgs e)
        {
            inputText.ScrollBars = ScrollBars.Vertical;
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            string route = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                route = openFileDialog.FileName;
            }
            nameArchivoText.Text = route;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        public void ReadFile(string route)
        {
            string[] lines = File.ReadAllLines(route);
            var linesConvert = lines[0];
            for (int i = 1; i < lines.Count(); i++)
            {
                linesConvert += "\r\n" + lines[i];
            }

            string morse = GoToMorse(linesConvert.ToUpper());
            string[] response = ReturnLinesNumber(morse.Split(Environment.NewLine));
            outputText.Text = string.Join(Environment.NewLine, response);

        }

        private void CargarButton_Click(object sender, EventArgs e)
        {
            if (archivoCheck.Checked)
            {
                ReadFile(nameArchivoText.Text);
            }
            if (consolaCheck.Checked)
            {
                string text = inputText.Text.ToUpper();
                string Morse = GoToMorse(text);
                string[] response = ReturnLinesNumber(Morse.Split(Environment.NewLine));
                outputText.Text = string.Join(Environment.NewLine, response);
            }

        }

        private string GoToMorse(string text)
        {
            AnalizadorLexicoMorse analizadorLexicoMorse = new AnalizadorLexicoMorse();
            Cache cache = Cache.ObtenerCache();
            cache.AgregarLineas(text);
            analizadorLexicoMorse.Analizar();
            return AnalizadorLexicoMorse.Compilado;
        }

        private void OutputText_TextChanged(object sender, EventArgs e)
        {
            if (outputText.Text != string.Empty)
            {
                outputText.Enabled = true;
            }
            outputText.ScrollBars = ScrollBars.Vertical;
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            Cache cache = Cache.ObtenerCache();
            cache.Limpiar();
            outputText.Text = string.Empty;
            inputText.Text = string.Empty;
            nameArchivoText.Text = string.Empty;
            AnalizadorLexicoMorse.Compilado = "";
        }

        private string[] ReturnLinesNumber(string[] vs)
        {
            for (int i = 0; i < vs.Length; i++)
            {
                vs[i] = string.Format((i + 1).ToString() + "-> " + vs[i], vs[i]);
            }
            return vs;
        }
    }
}
