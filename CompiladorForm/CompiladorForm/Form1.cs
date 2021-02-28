using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace CompiladorForm
{
    public partial class Form1 : Form
    {       
        public Form1()
        {
            InitializeComponent();
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
            var lines = File.ReadAllLines(route);
            var response = ReturnLinesNumber(lines);
            outputText.Text = String.Join(Environment.NewLine,response);
            
        }

        private void CargarButton_Click(object sender, EventArgs e)
        {
            if (archivoCheck.Checked)
            {
                ReadFile(nameArchivoText.Text);
            }
            if (consolaCheck.Checked)
            {
                var text = inputText.Text;
                var response = ReturnLinesNumber(text.Split(Environment.NewLine));
                outputText.Text = String.Join(Environment.NewLine, response);
            }
            
        }

        private void OutputText_TextChanged(object sender, EventArgs e)
        {
            if(outputText.Text != string.Empty)
            {
                outputText.Enabled = true;
            }
            outputText.ScrollBars = ScrollBars.Vertical;
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            outputText.Text = string.Empty;
            inputText.Text = string.Empty;
            nameArchivoText.Text = string.Empty;
        }

        private string[] ReturnLinesNumber(string[] vs)
        {            
            for(int i = 0; i< vs.Length; i++)
            {
                vs[i] = String.Format((i + 1).ToString() +"-> " + vs[i], vs[i]);
            }            
            return vs;
        }
    }
}
