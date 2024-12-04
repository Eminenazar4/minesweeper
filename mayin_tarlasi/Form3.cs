using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace mayin_tarlasi
{
    public partial class Form3 : Form
    {
        private ListView skorListesi;

        private void label1_Click(object sender, EventArgs e)
        {
            // label1'e tıklanınca gerçekleşecek işlemler burada tanımlanabilir.
        }
        private Form2 form2;
        public Form3(Form2 form2)
        {
            InitializeComponent();
            // Global skorboard nesnesini kullanıyoruz

            // Skorları göstermek için ListView oluşturuyoruz
            SkorTablosuOlustur();
            SkorlariGoster();

            // Form boyutunu ayarlıyoruz
            this.Size = new System.Drawing.Size(500, 500);
            this.Load += Form3_Load;
            this.Resize += Form3_Resize; // Form yeniden boyutlandırıldığında ortalamayı güncelle
            this.form2 = form2;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SkorlariGoster();
            CenterListView(); // ListView'i başta ortala
        }

        private void CenterListView()
        {
            label1.Location = new Point(skorListesi.Location.X + (skorListesi.Width - label1.Width) / 2,
                skorListesi.Location.Y - label1.Height - 10);
            // ListView'in formun ortasında yer almasını sağla
            skorListesi.Location = new System.Drawing.Point(
                (this.ClientSize.Width - skorListesi.Width) / 2,
                (this.ClientSize.Height - skorListesi.Height) / 2 + 20
            );
        }

        private void Form3_Resize(object sender, EventArgs e)
        {
            CenterListView(); // Form yeniden boyutlandırıldığında ListView'i ortala
        }

        private void SkorTablosuOlustur()
        {
            // ListView ayarlarını yapıyoruz
            skorListesi = new ListView();
            skorListesi.Columns.Add("Sıra No", 80, HorizontalAlignment.Center);
            skorListesi.Columns.Add("Oyuncu Adı", 110, HorizontalAlignment.Center);
            skorListesi.Columns.Add("Skor", 80, HorizontalAlignment.Center);
            skorListesi.Columns.Add("Süre (saniye)", 100, HorizontalAlignment.Center);

            skorListesi.View = View.Details;
            skorListesi.FullRowSelect = true;  // Satırın tamamını seçmek için
            skorListesi.GridLines = true;      // Hücreler arasında çizgiler eklemek için
            skorListesi.Size = new System.Drawing.Size(375,272); // ListView boyutu

            // ListView'i formun kontrol listesine ekliyoruz
            this.Controls.Add(skorListesi);
            this.Text = "Skor Tablosu";
        }

        private void SkorlariGoster()
        {
            skorListesi.Items.Clear();

            var enIyiSkorlar = Program.GlobalSkorboard.EnIyiSkorlar(); // Skorları alıyoruz
            int sira = 1;
            if (enIyiSkorlar.Count == 0)
            {
                MessageBox.Show("Hiçbir skor bulunamadı.");
            }


            foreach (var skor in enIyiSkorlar)
            {
                ListViewItem item = new ListViewItem(sira.ToString());
                item.SubItems.Add(skor.OyuncuAdi);
                item.SubItems.Add(skor.SkorDegeri.ToString());
                item.SubItems.Add(skor.Sure.ToString());

                skorListesi.Items.Add(item);
                sira++;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            form2.Close(); // Form2'yi kapatır
            this.Close();  // Mevcut Form3 penceresini kapatır
        }

    }
}