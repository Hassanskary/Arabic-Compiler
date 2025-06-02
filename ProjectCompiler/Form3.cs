using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjectCompiler
{
    public partial class Form3 : Form
    {
        // Constructor that takes status and messages
        public Form3(string status, List<string> messages)
        {
            InitializeComponent(); // Initialize components from the designer
            PopulateMessages(status, messages); // Populate the ListView with messages
        }

        // Method to populate messages based on the status
        private void PopulateMessages(string status, List<string> messages)
        {
            lblStatus.Text = status; // Set the status label text
            lvMessages.Items.Clear(); // Clear previous items

            // Add messages to the ListView
            foreach (var message in messages)
            {
                ListViewItem item = new ListViewItem(message);
                item.ForeColor = status == "Parsing failed!" ? System.Drawing.Color.Red : System.Drawing.Color.Black; // Errors in red
                lvMessages.Items.Add(item);
            }
        }
    }
}
