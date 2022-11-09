namespace lab_4
{
    partial class MainForm
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
        #endregion

        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bounds_poly = new System.Windows.Forms.RadioButton();
            this.bounds_middle = new System.Windows.Forms.RadioButton();
            this.boudns_off = new System.Windows.Forms.RadioButton();
            this.bounds_button = new System.Windows.Forms.Button();
            this.draw_poly_button = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.draw_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.y_max_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Y2_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.x_max_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.X2_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.y_min_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.x_min_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Y1_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.X1_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.random_button = new System.Windows.Forms.Button();
            this.count_of_rand_points_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.draw_panel = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.y_max_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y2_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_max_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.X2_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_min_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_min_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y1_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.X1_numericUpDown)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.count_of_rand_points_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.tableLayoutPanel1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1519, 956);
            this.panel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.draw_panel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.83263F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.16736F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1519, 956);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.70025F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.29975F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 814);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1513, 139);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bounds_poly);
            this.panel1.Controls.Add(this.bounds_middle);
            this.panel1.Controls.Add(this.boudns_off);
            this.panel1.Controls.Add(this.bounds_button);
            this.panel1.Controls.Add(this.draw_poly_button);
            this.panel1.Controls.Add(this.clear_button);
            this.panel1.Controls.Add(this.draw_button);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.y_max_numericUpDown);
            this.panel1.Controls.Add(this.Y2_numericUpDown);
            this.panel1.Controls.Add(this.x_max_numericUpDown);
            this.panel1.Controls.Add(this.X2_numericUpDown);
            this.panel1.Controls.Add(this.y_min_numericUpDown);
            this.panel1.Controls.Add(this.x_min_numericUpDown);
            this.panel1.Controls.Add(this.Y1_numericUpDown);
            this.panel1.Controls.Add(this.X1_numericUpDown);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1154, 133);
            this.panel1.TabIndex = 0;
            // 
            // bounds_poly
            // 
            this.bounds_poly.AutoSize = true;
            this.bounds_poly.Location = new System.Drawing.Point(605, 103);
            this.bounds_poly.Name = "bounds_poly";
            this.bounds_poly.Size = new System.Drawing.Size(112, 24);
            this.bounds_poly.TabIndex = 0;
            this.bounds_poly.TabStop = true;
            this.bounds_poly.Text = "bounds poly";
            this.bounds_poly.UseVisualStyleBackColor = true;
            // 
            // bounds_middle
            // 
            this.bounds_middle.AutoSize = true;
            this.bounds_middle.Location = new System.Drawing.Point(460, 103);
            this.bounds_middle.Name = "bounds_middle";
            this.bounds_middle.Size = new System.Drawing.Size(130, 24);
            this.bounds_middle.TabIndex = 0;
            this.bounds_middle.TabStop = true;
            this.bounds_middle.Text = "bounds middle";
            this.bounds_middle.UseVisualStyleBackColor = true;
            // 
            // boudns_off
            // 
            this.boudns_off.AutoSize = true;
            this.boudns_off.Location = new System.Drawing.Point(346, 103);
            this.boudns_off.Name = "boudns_off";
            this.boudns_off.Size = new System.Drawing.Size(100, 24);
            this.boudns_off.TabIndex = 0;
            this.boudns_off.TabStop = true;
            this.boudns_off.Text = "no bounds";
            this.boudns_off.UseVisualStyleBackColor = true;
            // 
            // bounds_button
            // 
            this.bounds_button.Location = new System.Drawing.Point(1050, 48);
            this.bounds_button.Name = "bounds_button";
            this.bounds_button.Size = new System.Drawing.Size(94, 29);
            this.bounds_button.TabIndex = 1;
            this.bounds_button.Text = "bounds";
            this.bounds_button.UseVisualStyleBackColor = true;
            this.bounds_button.Click += new System.EventHandler(this.bounds_button_Click);
            // 
            // draw_poly_button
            // 
            this.draw_poly_button.Location = new System.Drawing.Point(581, 48);
            this.draw_poly_button.Name = "draw_poly_button";
            this.draw_poly_button.Size = new System.Drawing.Size(94, 29);
            this.draw_poly_button.TabIndex = 2;
            this.draw_poly_button.Text = "Draw poly";
            this.draw_poly_button.UseVisualStyleBackColor = true;
            this.draw_poly_button.Click += new System.EventHandler(this.draw_poly_button_Click);
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(481, 48);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(94, 29);
            this.clear_button.TabIndex = 2;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // draw_button
            // 
            this.draw_button.Location = new System.Drawing.Point(381, 48);
            this.draw_button.Name = "draw_button";
            this.draw_button.Size = new System.Drawing.Size(94, 29);
            this.draw_button.TabIndex = 2;
            this.draw_button.Text = "Draw";
            this.draw_button.UseVisualStyleBackColor = true;
            this.draw_button.Click += new System.EventHandler(this.draw_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(937, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(777, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            // 
            // y_max_numericUpDown
            // 
            this.y_max_numericUpDown.Location = new System.Drawing.Point(894, 81);
            this.y_max_numericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.y_max_numericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.y_max_numericUpDown.Name = "y_max_numericUpDown";
            this.y_max_numericUpDown.Size = new System.Drawing.Size(150, 27);
            this.y_max_numericUpDown.TabIndex = 0;
            // 
            // Y2_numericUpDown
            // 
            this.Y2_numericUpDown.Location = new System.Drawing.Point(175, 86);
            this.Y2_numericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Y2_numericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.Y2_numericUpDown.Name = "Y2_numericUpDown";
            this.Y2_numericUpDown.Size = new System.Drawing.Size(150, 27);
            this.Y2_numericUpDown.TabIndex = 0;
            // 
            // x_max_numericUpDown
            // 
            this.x_max_numericUpDown.Location = new System.Drawing.Point(738, 81);
            this.x_max_numericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.x_max_numericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.x_max_numericUpDown.Name = "x_max_numericUpDown";
            this.x_max_numericUpDown.Size = new System.Drawing.Size(150, 27);
            this.x_max_numericUpDown.TabIndex = 0;
            // 
            // X2_numericUpDown
            // 
            this.X2_numericUpDown.Location = new System.Drawing.Point(19, 86);
            this.X2_numericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.X2_numericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.X2_numericUpDown.Name = "X2_numericUpDown";
            this.X2_numericUpDown.Size = new System.Drawing.Size(150, 27);
            this.X2_numericUpDown.TabIndex = 0;
            // 
            // y_min_numericUpDown
            // 
            this.y_min_numericUpDown.Location = new System.Drawing.Point(894, 48);
            this.y_min_numericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.y_min_numericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.y_min_numericUpDown.Name = "y_min_numericUpDown";
            this.y_min_numericUpDown.Size = new System.Drawing.Size(150, 27);
            this.y_min_numericUpDown.TabIndex = 0;
            // 
            // x_min_numericUpDown
            // 
            this.x_min_numericUpDown.Location = new System.Drawing.Point(738, 48);
            this.x_min_numericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.x_min_numericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.x_min_numericUpDown.Name = "x_min_numericUpDown";
            this.x_min_numericUpDown.Size = new System.Drawing.Size(150, 27);
            this.x_min_numericUpDown.TabIndex = 0;
            // 
            // Y1_numericUpDown
            // 
            this.Y1_numericUpDown.Location = new System.Drawing.Point(175, 53);
            this.Y1_numericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Y1_numericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.Y1_numericUpDown.Name = "Y1_numericUpDown";
            this.Y1_numericUpDown.Size = new System.Drawing.Size(150, 27);
            this.Y1_numericUpDown.TabIndex = 0;
            // 
            // X1_numericUpDown
            // 
            this.X1_numericUpDown.Location = new System.Drawing.Point(19, 53);
            this.X1_numericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.X1_numericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.X1_numericUpDown.Name = "X1_numericUpDown";
            this.X1_numericUpDown.Size = new System.Drawing.Size(150, 27);
            this.X1_numericUpDown.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.random_button);
            this.panel2.Controls.Add(this.count_of_rand_points_numericUpDown);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1163, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(347, 133);
            this.panel2.TabIndex = 1;
            // 
            // random_button
            // 
            this.random_button.Location = new System.Drawing.Point(120, 82);
            this.random_button.Name = "random_button";
            this.random_button.Size = new System.Drawing.Size(94, 29);
            this.random_button.TabIndex = 1;
            this.random_button.Text = "RandPoints";
            this.random_button.UseVisualStyleBackColor = true;
            this.random_button.Click += new System.EventHandler(this.random_button_Click);
            // 
            // count_of_rand_points_numericUpDown
            // 
            this.count_of_rand_points_numericUpDown.Location = new System.Drawing.Point(98, 48);
            this.count_of_rand_points_numericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.count_of_rand_points_numericUpDown.Name = "count_of_rand_points_numericUpDown";
            this.count_of_rand_points_numericUpDown.Size = new System.Drawing.Size(150, 27);
            this.count_of_rand_points_numericUpDown.TabIndex = 0;
            // 
            // draw_panel
            // 
            this.draw_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.draw_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.draw_panel.Location = new System.Drawing.Point(3, 3);
            this.draw_panel.Name = "draw_panel";
            this.draw_panel.Size = new System.Drawing.Size(1513, 805);
            this.draw_panel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1519, 956);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.y_max_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y2_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_max_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.X2_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_min_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_min_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y1_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.X1_numericUpDown)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.count_of_rand_points_numericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        private Panel panel;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private Button draw_button;
        private Label label2;
        private Label label1;
        private NumericUpDown Y1_numericUpDown;
        private NumericUpDown X1_numericUpDown;
        private Panel draw_panel;
        private Button clear_button;
        private NumericUpDown Y2_numericUpDown;
        private NumericUpDown X2_numericUpDown;
        private Panel panel2;
        private NumericUpDown count_of_rand_points_numericUpDown;
        private Button random_button;
        private Button draw_poly_button;
        private Label label4;
        private Label label3;
        private NumericUpDown y_max_numericUpDown;
        private NumericUpDown x_max_numericUpDown;
        private NumericUpDown y_min_numericUpDown;
        private NumericUpDown x_min_numericUpDown;
        private RadioButton bounds_poly;
        private RadioButton bounds_middle;
        private RadioButton boudns_off;
        private Button bounds_button;
    }
}