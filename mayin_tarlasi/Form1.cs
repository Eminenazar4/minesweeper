using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace mayin_tarlasi
{
    public partial class Form1 : Form
    {
        private string oyuncuAdi;
        private int gridBoyutu;
        private int mayinSayisi;

        public Form1()
        {
            InitializeComponent();//InitializeComponent() metodu, tasarým aþamasýnda eklenen bileþenlerin (Label, TextBox, Button) baþlatýlmasýný saðlar.

        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            // Kullanýcý adý kontrolü
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text))
            {
                MessageBox.Show("Lütfen kullanýcý adýnýzý girin.");
                return;
            }

            // Grid boyutunu kontrol et
            if (!int.TryParse(txtGridBoyutu.Text, out gridBoyutu) || gridBoyutu <= 10 || gridBoyutu > 30)
            {
                MessageBox.Show("Lütfen geçerli bir grid boyutu (11-30) girin.");
                return;
            }

            // Mayýn sayýsýný kontrol et
            if (!int.TryParse(txtMayinSayisi.Text, out mayinSayisi) || mayinSayisi < 10)
            {
                MessageBox.Show("En az 10 adet mayýn olmalýdýr.");
                return;
            }

            Oyun oyun = new Oyun(txtKullaniciAdi.Text, gridBoyutu, mayinSayisi); // Kullanýcýnýn girdiði deðerleri kullanýn

            // Form2'yi baþlat ve göster
            Form2 form2 = new Form2(oyun, Program.GlobalSkorboard); // GlobalSkorboard'u gönderiyoruz
            form2.Show();
            this.Hide(); // Form1'i gizler
        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {
            // Kullanýcý adý deðiþtiðinde, deðiþiklikleri kaydedebiliriz
            oyuncuAdi = txtKullaniciAdi.Text;
        }
        private void txtMayinSayisi_TextChanged(object sender, EventArgs e) {}

        private void txtGridBoyutu_TextChanged(object sender, EventArgs e) {}

        private void label3_Click(object sender, EventArgs e) { } //mayýn sayýsý label ý
        private void label2_Click(object sender, EventArgs e) { } // grid boyutu label ý
        private void label1_Click(object sender, EventArgs e) { } // adýnýz label ý

       
    }
}
