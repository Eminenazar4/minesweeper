﻿namespace mayin_tarlasi
{
    partial class Form3
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
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.DarkTurquoise;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(249, 38);
            label1.Name = "label1";
            label1.Size = new Size(207, 38);
            label1.TabIndex = 1;
            label1.Text = "SKOR TABLOSU";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(287, 394);
            button1.Name = "button1";
            button1.Size = new Size(140, 29);
            button1.TabIndex = 2;
            button1.Text = "Yeniden Başla";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;

            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(748, 490);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
    }
}