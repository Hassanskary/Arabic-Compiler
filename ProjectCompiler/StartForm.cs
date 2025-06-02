using System;
using System.Windows.Forms;

namespace ProjectCompiler
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        // Hover effect: mouse enters the button
        private void btnStart_MouseEnter(object sender, EventArgs e)
        {
            btnStart.ForeColor = System.Drawing.Color.White;
            btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(130, 0, 0, 250);
        }

        // Hover effect: mouse leaves the button
        private void btnStart_MouseLeave(object sender, EventArgs e)
        {
            btnStart.ForeColor = System.Drawing.Color.Black;
        }

        // Start button click event
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Opens a new form and hides the current one
            Form1 mainForm = new Form1();
            this.Hide();
            mainForm.ShowDialog();
            this.Show();
        }

        // Label click event (if any action is required)
        private void labelDescription_Click(object sender, EventArgs e)
        {
            // Optional functionality for label click
        }
    }
}
