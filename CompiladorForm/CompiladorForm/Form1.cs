using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using CompiladorForm.AnalisisLexico;
using CompiladorForm.GestorErrores;
using CompiladorForm.Tablas;
using CompiladorForm.Transversal;

namespace CompiladorForm
{
    public partial class Form1 : Form
    {
        Boolean existTaSimbolos = false;
        Boolean existTaErrores = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Resetear()
        {
            Cache.ObtenerCache().Limpiar();
            ManejadorErrores.Limpiar();
            TablaMaestra.Limpiar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            string linesConvert = lines[0];
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

            if (ManejadorErrores.HayErrores())
            {
                EOFButton.Text = "Fallido";
                EOFButton.BackColor = Color.FromArgb(255, 189, 189);
            }
            else
            {
                EOFButton.Text = "Exitoso";
                EOFButton.BackColor = Color.FromArgb(204, 255, 217);
            }

        }

        private string GoToMorse(string text)
        {
            Resetear();
            //Cargar a caché los datos
            Cache cache = Cache.ObtenerCache();
            cache.AgregarLineas(text);

            try
            {
                //Disparar el procesamiento a nivel de Analizador Léxico
                AnalizadorLexico anaLex = new AnalizadorLexico();
                ComponenteLexico componente = anaLex.Analizar();

                while (!componente.ObtenerCategoria().Equals(Categoria.FIN_ARCHIVO))
                {
                    MessageBox.Show(componente.ToString());
                    componente = anaLex.Analizar();
                }
                if (ManejadorErrores.HayErrores())
                {
                    MessageBox.Show("El proceso de compilación ha finalizado con errores.");
                }
                else
                {
                    MessageBox.Show("El proceso de compilación ha finalizado de forma exitosa.");
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            //AnalizadorLexicoMorse analizadorLexicoMorse = new AnalizadorLexicoMorse();
            //analizadorLexicoMorse.Analizar();
            //return AnalizadorLexicoMorse.Compilado;

            string[] response = ReturnLinesNumber(text.Split(Environment.NewLine));
            return string.Join(Environment.NewLine, response);
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
            existTaErrores = false;
            existTaSimbolos = false;
            Resetear();
            LimpiarTablas();
            //AnalizadorLexicoMorse.Compilado = "";
        }
        private void LimpiarTablas()
        {
            TablaDummies.Rows.Clear();
            TablaDummies.Columns.Clear();
            TablaLiteralesGrid.Rows.Clear();
            TablaLiteralesGrid.Columns.Clear();
            tablasimbolos.Rows.Clear();
            tablasimbolos.Columns.Clear();
            ErroresLexicosGrid.Rows.Clear();
            ErroresLexicosGrid.Columns.Clear();
            ErroresSintacticosGrid.Rows.Clear();
            ErroresSintacticosGrid.Columns.Clear();
            ErroresSemanticosGrid.Rows.Clear();
            ErroresSemanticosGrid.Columns.Clear();
        }

        private string[] ReturnLinesNumber(string[] vs)
        {
            for (int i = 0; i < vs.Length; i++)
            {
                vs[i] = string.Format((i + 1).ToString() + "-> " + vs[i], vs[i]);
            }
            return vs;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void TablaSimbolosButton_Click(object sender, EventArgs e)
        {
            panelErrores.Visible = false;
            panelSimbolos.Visible = true;
            if (!existTaSimbolos)
            {

                foreach (string col in TablaSimbolosList.ColumnasTablaSimbolos)
                {
                    tablasimbolos.Columns.Add(col + "S", col);
                    TablaReservadas.Columns.Add(col + "R", col);
                    TablaLiteralesGrid.Columns.Add(col + "L", col);
                    TablaDummies.Columns.Add(col + "D", col);

                }
                ListarTablasSimbolos(TablaSimbolos.ObtenerSimbolos(), tablasimbolos);
                ListarTablasSimbolos(TablaDummys.ObtenerDummys(), TablaDummies);
                ListarTablasSimbolos(TablaLiterales.ObtenerLiterales(), TablaLiteralesGrid);

                existTaSimbolos = true;
            }


        }

        private void ListarTablasSimbolos(List<ComponenteLexico> list, DataGridView tabla)
        {
            foreach (ComponenteLexico simbolo in list)
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(tabla);
                fila.Cells[0].Value = simbolo.ObtenerLexema();
                fila.Cells[1].Value = simbolo.ObtenerCategoria();
                fila.Cells[2].Value = simbolo.ObtenerNumeroLinea();
                fila.Cells[3].Value = simbolo.ObtenerPosicionInicial();
                fila.Cells[4].Value = simbolo.ObtenerPosicionFinal();
                tabla.Rows.Add(fila);
            }
        }
        private void ErroresButton_Click(object sender, EventArgs e)
        {
            panelErrores.Visible = true;
            panelSimbolos.Visible = false;
            foreach (string col in TablaSimbolosList.ColumnasTablaErrores)
            {
                ErroresLexicosGrid.Columns.Add(col + "S", col);
                ErroresSemanticosGrid.Columns.Add(col + "R", col);
                ErroresSintacticosGrid.Columns.Add(col + "L", col);
            }
            ListarTablaErrores(TipoError.LEXICO, ErroresLexicosGrid);
            ListarTablaErrores(TipoError.SINTACTICO, ErroresSintacticosGrid);
            ListarTablaErrores(TipoError.SEMANTICO, ErroresSemanticosGrid);
        }
        private void ListarTablaErrores(TipoError tipoError, DataGridView tabla)
        {
            if (!existTaErrores)
            {
                List<Error> errores = ManejadorErrores.ObtenerErrores(tipoError);
                foreach (Error error in errores)
                {
                    DataGridViewRow fila = new DataGridViewRow();
                    fila.CreateCells(tabla);
                    fila.Cells[0].Value = error.ObtenerLexema();
                    fila.Cells[1].Value = error.ObtenerCategoria();
                    fila.Cells[2].Value = error.ObtenerNumeroLinea();
                    fila.Cells[3].Value = error.ObtenerPosicionInicial();
                    fila.Cells[4].Value = error.ObtenerPosicionFinal();
                    fila.Cells[5].Value = error.ObtenerFalla();
                    fila.Cells[6].Value = error.ObtenerCausa();
                    fila.Cells[7].Value = error.ObtenerSolucion();
                    tabla.Rows.Add(fila);
                }
                existTaErrores = true;
            }
        }

        private void IngresoInfoButton_Click(object sender, EventArgs e)
        {
            panelSimbolos.Visible = false;
            panelErrores.Visible = false;
        }
    }
}
