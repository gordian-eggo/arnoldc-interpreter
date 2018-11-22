using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOLCodeInterpreterSulleza
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            lexemeGridView.DataSource = null;
            lexemeGridView.Rows.Clear();
            symbolTableGridView.DataSource = null;
            symbolTableGridView.Rows.Clear();
            Lexer.variables.Clear();
            Lexer.keyMatch.Clear();
            consoleTextBox.Clear();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            Stream myStream;
            openFileDialog1.Filter = "LOL Files (*.lol)|*.lol";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            string filePath;
            //RichTextBox codeTextBox = new RichTextBox();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                codeTextBox.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    filePath = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                    Lexer.getLexemes(codeTextBox.Text);
                    myStream.Close();
                }
                else
                {
                    MessageBox.Show("Error opening the file!");
                    return;
                }
            }
			Lexer.varInit(codeTextBox.Text);
            Lexer.visibleOps(codeTextBox.Text);
			Lexer.evaluateValue();

			//Lexer.itVALUE(codeTextBox.Text);
            foreach (Tuple<string, string> iterator in Lexer.keyMatch)
            {
                lexemeGridView.Rows.Add(iterator.Item1, iterator.Item2);
            }
			foreach (KeyValuePair<string, string> iterator in Lexer.variables)
            {
				symbolTableGridView.Rows.Add(iterator.Key, iterator.Value);
            }
            
            //Lexer.openFileProcedure(openFileDialog1.FileName);

        }

        private void codeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            lexemeGridView.DataSource = null;
            lexemeGridView.Rows.Clear();
            symbolTableGridView.DataSource = null;
            symbolTableGridView.Rows.Clear();
            consoleTextBox.Clear();
            Lexer.variables.Clear();
            Lexer.keyMatch.Clear();
            Lexer.getLexemes(codeTextBox.Text);
			Lexer.varInit(codeTextBox.Text);
			Lexer.visibleOps(codeTextBox.Text);
            Lexer.itVALUE(codeTextBox.Text);
            Lexer.evaluateValue();
            foreach (Tuple<string, string> iterator in Lexer.keyMatch)
            {
                lexemeGridView.Rows.Add(iterator.Item1, iterator.Item2);
            }
            foreach (KeyValuePair<string, string> iterator in Lexer.variables)
			{
				symbolTableGridView.Rows.Add(iterator.Key, iterator.Value);
			}
			
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public static void inputTextButton_Click(object sender, EventArgs e)
        {
			Lexer.inputFoundEnd = true;
        }

        private void consoleTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
