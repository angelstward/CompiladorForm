using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace CompiladorForm
{
    public partial class Form1 : Form
    {
        public string routeName { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (archivoCheck.Checked)
            {
                inputText.Text = string.Empty;
                inputText.Enabled = false;
                consolaCheck.Checked = false;
                buttonSelectArchivo.Enabled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void consolaCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (consolaCheck.Checked)
            {
                inputText.Enabled = true;
                archivoCheck.Checked = false;
                buttonSelectArchivo.Enabled = false;
                nameArchivoText.Text = string.Empty;
            }
        }

        private void inputText_TextChanged(object sender, EventArgs e)
        {
            inputText.ScrollBars = ScrollBars.Vertical;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            string route = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                route = openFileDialog.FileName;
            }
            routeName = route;
            nameArchivoText.Text = routeName;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }


        public void ReadFile(string route)
        {
            var lines = File.ReadAllLines(route);
            var response = returnLinesNumber(lines);
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
                var response = returnLinesNumber(text.Split(Environment.NewLine));
                outputText.Text = String.Join(Environment.NewLine, response);
            }
            
        }

        private void outputText_TextChanged(object sender, EventArgs e)
        {
            if(outputText.Text != string.Empty)
            {
                outputText.Enabled = true;
            }
            outputText.ScrollBars = ScrollBars.Vertical;
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            outputText.Text = string.Empty;
            inputText.Text = string.Empty;
            nameArchivoText.Text = string.Empty;
        }

        private string[] returnLinesNumber(string[] vs)
        {            
            for(int i = 0; i< vs.Length; i++)
            {
                vs[i] = String.Format((i + 1).ToString() +". " + vs[i], vs[i]);
            }            
            return vs;
        }
    }
}
