using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjectCompiler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;

            // Get all tokens from the input text
            var tokens = inputText.GetAllTokens();

            // Show Form2 with the tokens (you can add more functionality if needed)
            Form2 resultsForm = new Form2(tokens);
            resultsForm.Show();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Close Form1 and return to StartForm
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;

            List<string> errors;
            List<string> parseTree;

            // Try to parse the program and get errors and parse tree
            bool isParsed = inputText.ParseProgram(out errors, out parseTree);

            // If parsing failed, show Form3 with errors
            if (!isParsed)
            {
                // Show Form3 with error list and status message
                Form3 errorForm = new Form3("Parsing failed!", errors);
                errorForm.Show();
            }
            else
            {
                // If parsing is successful, show the parse tree in Form3
                Form3 parserOutputForm = new Form3("Parsing successful!", parseTree);
                parserOutputForm.Show();
            }
        }
    }
}
