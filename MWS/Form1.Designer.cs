namespace MWS
{
    partial class Form1
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
            this.pnlMask = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCloseWarning = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCloseWarningMask = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMask.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMask
            // 
            this.pnlMask.BackColor = System.Drawing.Color.Transparent;
            this.pnlMask.BackgroundImage = global::MWS.Properties.Resources.bg_mask;
            this.pnlMask.Controls.Add(this.panel1);
            this.pnlMask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMask.Location = new System.Drawing.Point(0, 0);
            this.pnlMask.Name = "pnlMask";
            this.pnlMask.Size = new System.Drawing.Size(1354, 827);
            this.pnlMask.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnCloseWarning);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnCloseWarningMask);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(412, 191);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 486);
            this.panel1.TabIndex = 0;
            // 
            // btnCloseWarning
            // 
            this.btnCloseWarning.BackgroundImage = global::MWS.Properties.Resources.bg_title;
            this.btnCloseWarning.FlatAppearance.BorderSize = 0;
            this.btnCloseWarning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseWarning.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseWarning.ForeColor = System.Drawing.Color.White;
            this.btnCloseWarning.Location = new System.Drawing.Point(15, 449);
            this.btnCloseWarning.Name = "btnCloseWarning";
            this.btnCloseWarning.Size = new System.Drawing.Size(93, 29);
            this.btnCloseWarning.TabIndex = 4;
            this.btnCloseWarning.Text = "关闭警报";
            this.btnCloseWarning.UseVisualStyleBackColor = true;
            this.btnCloseWarning.Click += new System.EventHandler(this.btnCloseWarning_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 352);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(435, 88);
            this.textBox1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::MWS.Properties.Resources.bg_video;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(17, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(435, 293);
            this.panel2.TabIndex = 2;
            // 
            // btnCloseWarningMask
            // 
            this.btnCloseWarningMask.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseWarningMask.Location = new System.Drawing.Point(424, 14);
            this.btnCloseWarningMask.Name = "btnCloseWarningMask";
            this.btnCloseWarningMask.Size = new System.Drawing.Size(28, 23);
            this.btnCloseWarningMask.TabIndex = 1;
            this.btnCloseWarningMask.Text = "×";
            this.btnCloseWarningMask.UseVisualStyleBackColor = true;
            this.btnCloseWarningMask.Click += new System.EventHandler(this.btnCloseWarningMask_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(189, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "联动报警";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 827);
            this.Controls.Add(this.pnlMask);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlMask.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMask;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCloseWarning;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCloseWarningMask;
        private System.Windows.Forms.Label label1;
    }
}