using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProjectCompiler
{
    public partial class Form2 : Form
    {
        private ListBox IsResult;
        private Label label2;

        public Form2()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.IsResult = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IsResult
            // 
            this.IsResult.BackColor = System.Drawing.Color.Gainsboro;
            this.IsResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.IsResult.Font = new System.Drawing.Font("Tahoma", 14F);
            this.IsResult.FormattingEnabled = true;
            this.IsResult.ItemHeight = 23;
            this.IsResult.Location = new System.Drawing.Point(83, 67);
            this.IsResult.Margin = new System.Windows.Forms.Padding(2);
            this.IsResult.Name = "IsResult";
            this.IsResult.Size = new System.Drawing.Size(313, 418);
            this.IsResult.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(318, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "النتيجة";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IsResult);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Result Of Scanner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Define darker gradient colors similar to Form1
            Color color1 = Color.FromArgb(0, 102, 204); // Darker Blue
            Color color2 = Color.FromArgb(102, 51, 153); // Dark Purple

            // Create a brush with a vertical gradient
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle, color1, color2, 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
