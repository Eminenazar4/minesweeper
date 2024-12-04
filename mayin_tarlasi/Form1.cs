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
            InitializeComponent();//InitializeComponent() metodu, tasar�m a�amas�nda eklenen bile�enlerin (Label, TextBox, Button) ba�lat�lmas�n� sa�lar.

        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            // Kullan�c� ad� kontrol�
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text))
            {
                MessageBox.Show("L�tfen kullan�c� ad�n�z� girin.");
                return;
            }

            // Grid boyutunu kontrol et
            if (!int.TryParse(txtGridBoyutu.Text, out gridBoyutu) || gridBoyutu <= 10 || gridBoyutu > 30)
            {
                MessageBox.Show("L�tfen ge�erli bir grid boyutu (11-30) girin.");
                return;
            }

            // May�n say�s�n� kontrol et
            if (!int.TryParse(txtMayinSayisi.Text, out mayinSayisi) || mayinSayisi < 10)
            {
                MessageBox.Show("En az 10 adet may�n olmal�d�r.");
                return;
            }

            Oyun oyun = new Oyun(txtKullaniciAdi.Text, gridBoyutu, mayinSayisi); // Kullan�c�n�n girdi�i de�erleri kullan�n

            // Form2'yi ba�lat ve g�ster
            Form2 form2 = new Form2(oyun, Program.GlobalSkorboard); // GlobalSkorboard'u g�nderiyoruz
            form2.Show();
            this.Hide(); // Form1'i gizler
        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {
            // Kullan�c� ad� de�i�ti�inde, de�i�iklikleri kaydedebiliriz
            oyuncuAdi = txtKullaniciAdi.Text;
        }
        private void txtMayinSayisi_TextChanged(object sender, EventArgs e) {}

        private void txtGridBoyutu_TextChanged(object sender, EventArgs e) {}

        private void label3_Click(object sender, EventArgs e) { } //may�n say�s� label �
        private void label2_Click(object sender, EventArgs e) { } // grid boyutu label �
        private void label1_Click(object sender, EventArgs e) { } // ad�n�z label �

       
    }
}
