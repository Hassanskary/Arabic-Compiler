using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjectCompiler
{
    public partial class Form2 : Form
    {
        public Form2(List<string> tokens)
        {
            InitializeComponent();

            foreach (var token in tokens)
            {
                IsResult.Items.Add(token);
            }
        }
    }
}
