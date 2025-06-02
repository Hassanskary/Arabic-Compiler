using System.Drawing.Drawing2D;
using System.Drawing;

namespace ProjectCompiler
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListView lvMessages;

        private void InitializeComponent()
        {
            this.lblStatus = new System.Windows.Forms.Label();
            this.lvMessages = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(49, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(160, 29);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status Label";
            // 
            // lvMessages
            // 
            this.lvMessages.BackColor = System.Drawing.Color.Gainsboro;
            this.lvMessages.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lvMessages.ForeColor = System.Drawing.Color.Black;
            this.lvMessages.FullRowSelect = true;
            this.lvMessages.HideSelection = false;
            this.lvMessages.Location = new System.Drawing.Point(54, 50);
            this.lvMessages.Name = "lvMessages";
            this.lvMessages.Size = new System.Drawing.Size(443, 391);
            this.lvMessages.TabIndex = 1;
            this.lvMessages.UseCompatibleStateImageBehavior = false;
            this.lvMessages.View = System.Windows.Forms.View.List;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 496);
            this.Controls.Add(this.lvMessages);
            this.Controls.Add(this.lblStatus);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.Text = "Error Display";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            Color color1 = Color.FromArgb(0, 102, 204); 
            Color color2 = Color.FromArgb(102, 51, 153); 

            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle, color1, color2, 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
