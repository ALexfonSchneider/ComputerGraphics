namespace lab_4
{
    partial class Output
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.outbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // outbox
            // 
            this.outbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outbox.Location = new System.Drawing.Point(0, 0);
            this.outbox.Multiline = true;
            this.outbox.Name = "outbox";
            this.outbox.Size = new System.Drawing.Size(800, 450);
            this.outbox.TabIndex = 0;
            // 
            // Output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.outbox);
            this.Name = "Output";
            this.Text = "Output";
            this.Shown += new System.EventHandler(this.Output_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SaveFileDialog saveFileDialog1;
        private TextBox outbox;
    }
}