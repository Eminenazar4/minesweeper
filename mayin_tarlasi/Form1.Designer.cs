namespace mayin_tarlasi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtKullaniciAdi = new TextBox();
            btnBaslat = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtGridBoyutu = new TextBox();
            txtMayinSayisi = new TextBox();
            SuspendLayout();
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(395, 88);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(125, 27);
            txtKullaniciAdi.TabIndex = 0;
            txtKullaniciAdi.TextChanged += txtKullaniciAdi_TextChanged;
            // 
            // btnBaslat
            // 
            btnBaslat.Location = new Point(312, 263);
            btnBaslat.Name = "btnBaslat";
            btnBaslat.Size = new Size(132, 43);
            btnBaslat.TabIndex = 3;
            btnBaslat.Text = "BAŞLA";
            btnBaslat.UseVisualStyleBackColor = true;
            btnBaslat.Click += btnBaslat_Click;
            // 
            // label1
            // 
            label1.Location = new Point(245, 88);
            label1.Name = "label1";
            label1.Size = new Size(80, 27);
            label1.TabIndex = 4;
            label1.Text = "Adınız :";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.Location = new Point(245, 143);
            label2.Name = "label2";
            label2.Size = new Size(117, 27);
            label2.TabIndex = 5;
            label2.Text = "Grid  Boyutu :";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.Location = new Point(245, 201);
            label3.Name = "label3";
            label3.Size = new Size(117, 27);
            label3.TabIndex = 6;
            label3.Text = "Mayın Sayısı  :";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += label3_Click;
            // 
            // txtGridBoyutu
            // 
            txtGridBoyutu.Location = new Point(395, 143);
            txtGridBoyutu.Name = "txtGridBoyutu";
            txtGridBoyutu.Size = new Size(125, 27);
            txtGridBoyutu.TabIndex = 7;
            txtGridBoyutu.TextChanged += txtGridBoyutu_TextChanged;
            // 
            // txtMayinSayisi
            // 
            txtMayinSayisi.Location = new Point(395, 201);
            txtMayinSayisi.Name = "txtMayinSayisi";
            txtMayinSayisi.Size = new Size(125, 27);
            txtMayinSayisi.TabIndex = 8;
            txtMayinSayisi.TextChanged += txtMayinSayisi_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSlateGray;
            ClientSize = new Size(808, 442);
            Controls.Add(txtMayinSayisi);
            Controls.Add(txtGridBoyutu);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnBaslat);
            Controls.Add(txtKullaniciAdi);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtKullaniciAdi;
        private Button btnBaslat;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtGridBoyutu;
        private TextBox txtMayinSayisi;
    }
}
