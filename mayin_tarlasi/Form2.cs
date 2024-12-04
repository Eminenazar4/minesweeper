using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace mayin_tarlasi
{
    public partial class Form2 : Form
    {
        private int hamleSayaci = 0;
        private Label gelistiriciBilgiLabel;
        private Oyun oyun;
        private Skorboard skorboard;
        public Button[,] hucreler;
        private Button buttonSkorTablosu;

        public Form2(Oyun oyun, Skorboard skorboard) //Bu, Form2'nin yapıcı yöntemidir. public olduğu için başka sınıflardan çağrılabilir.
        {
            InitializeComponent();
            this.oyun = oyun; //form2'nin içinde oyunla ilgili işlemler yapılabilir.
            this.skorboard = skorboard;
            this.Load += new System.EventHandler(this.Form2_Load);
            oyun.OyunBitti += OyunBittiHandler; // OyunBitti olayına abone olun
            GridOlustur();
            
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            int hucreBoyutu = 30;
            int gridBoyutu = oyun.GridBoyutu;

            panel1.AutoScroll = true; //kaydırma çubukları
            panel1.Width = hucreBoyutu * gridBoyutu;
            panel1.Height = hucreBoyutu * gridBoyutu;

            panel1.Location = new Point(20, 40);
            int ekranGenisligi = Screen.PrimaryScreen.WorkingArea.Width;
            int ekranYuksekligi = Screen.PrimaryScreen.WorkingArea.Height;
            int yeniGenislik = panel1.Width + 40;
            int yeniYukseklik = panel1.Height + 100;

            this.ClientSize = new Size(panel1.Width + 40, panel1.Height + 100);

            if (hucreler.GetLength(0) > 0 && hucreler.GetLength(1) > 0)
            {
                int merkezX = (this.ClientSize.Width - button1.Width) / 2;
                int yukariY = hucreler[0, 0].Location.Y;
                button1.Location = new Point(merkezX, yukariY);
            }
            if (yeniGenislik > ekranGenisligi)
            {
                yeniGenislik = ekranGenisligi;
            }
            if (yeniYukseklik > ekranYuksekligi)
            {
                yeniYukseklik = ekranYuksekligi;
            }

            this.ClientSize = new Size(yeniGenislik, yeniYukseklik);

            // Eğer form ekranın dışında kalıyorsa, konumunu ekranın içine ayarla
            if (this.Left + yeniGenislik > ekranGenisligi)
            {
                this.Left = ekranGenisligi - yeniGenislik;
            }
            if (this.Top + yeniYukseklik > ekranYuksekligi)
            {
                this.Top = ekranYuksekligi - yeniYukseklik;
            }


            label1.Location = new Point(0, 0);
            label1.Text = "Hamle Sayısı: 0";
            this.Controls.Add(label1);
        }

        private void GridOlustur()
        {
            int gridBoyutu = oyun.GridBoyutu;
            hucreler = new Button[gridBoyutu, gridBoyutu];
            int hucreBoyutu = 30;

            for (int x = 0; x < gridBoyutu; x++)
            {
                for (int y = 0; y < gridBoyutu; y++)
                {
                    hucreler[x, y] = new Button();
                    hucreler[x, y].Size = new Size(hucreBoyutu, hucreBoyutu);
                    hucreler[x, y].Location = new Point(x * hucreBoyutu, y * hucreBoyutu);
                    hucreler[x, y].MouseUp += Hucre_MouseUp;
                    panel1.Controls.Add(hucreler[x, y]);
                }
            }
        }

        private void Hucre_MouseUp(object sender, MouseEventArgs e)
        {
            Button tiklananHucre = sender as Button;
            int x = tiklananHucre.Location.X / 30;
            int y = tiklananHucre.Location.Y / 30;

            if (e.Button == MouseButtons.Right)
            {
                oyun.BayrakKoy(x, y);
                tiklananHucre.Text = oyun.BayrakVarMi(x, y) ? "🚩" : "";
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (oyun.MayinVarMi(x, y))
                {
                    OyunBitir();
                }
                else
                {
                    int komsuMayinSayisi = oyun.HucreyiAc(x, y);
                    tiklananHucre.Enabled = false;
                    tiklananHucre.Text = komsuMayinSayisi.ToString();

                    tiklananHucre.BackColor = Color.DarkGray;
                    if (komsuMayinSayisi == 0)
                    {
                        BosHucreleriAc(x, y);
                    }
                    if (oyun.KazanmaDurumu())
                    {
                        OyunKazandiniz();
                    }

                    hamleSayaci++;
                    label1.Text = "Hamle Sayısı: " + hamleSayaci;
                }
            }
        }

        private void BosHucreleriAc(int x, int y)
        {
            Queue<(int, int)> hucreKuyrugu = new Queue<(int, int)>();
            hucreKuyrugu.Enqueue((x, y));
            bool[,] ziyaretEdildi = new bool[oyun.GridBoyutu, oyun.GridBoyutu];

            while (hucreKuyrugu.Count > 0)
            {
                var (cx, cy) = hucreKuyrugu.Dequeue();

                if (ziyaretEdildi[cx, cy]) continue;
                ziyaretEdildi[cx, cy] = true;

                int komsuMayinSayisi = oyun.HucreyiAc(cx, cy);
                hucreler[cx, cy].Enabled = false;
                hucreler[cx, cy].Text = komsuMayinSayisi.ToString();
                hucreler[cx, cy].BackColor = Color.DarkGray;

                if (komsuMayinSayisi == 0)
                {
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int nx = cx + i;
                            int ny = cy + j;

                            if (nx >= 0 && ny >= 0 && nx < oyun.GridBoyutu && ny < oyun.GridBoyutu && !ziyaretEdildi[nx, ny])
                            {
                                hucreKuyrugu.Enqueue((nx, ny));
                            }
                        }
                    }
                }
            }
        }

        private void OyunKazandiniz()
        {
            int dogruBayrakSayisi = oyun.DogruBayrakSayisi;
            int skor = oyun.SkorHesapla(dogruBayrakSayisi);

            MessageBox.Show($"Tebrikler! Kazandınız! Skorunuz: {skor}");

            for (int x = 0; x < oyun.GridBoyutu; x++)
            {
                for (int y = 0; y < oyun.GridBoyutu; y++)
                {
                    if (oyun.MayinVarMi(x, y))
                    {
                        hucreler[x, y].Text = "*";
                        hucreler[x, y].BackColor = Color.Green;
                        hucreler[x, y].Enabled = false;
                    }
                }
            }

            Skor yeniSkor = new Skor(oyun.OyuncuAdi, skor, oyun.OyunSuresi);
            Program.GlobalSkorboard.SkorEkle(yeniSkor);
            Console.WriteLine($"Skor eklendi: {yeniSkor.OyuncuAdi}, {yeniSkor.SkorDegeri}, {yeniSkor.Sure}");

            Form3 form3 = new Form3(this);
            form3.Show();
            panel1.Invalidate();
        }

        private void OyunBittiHandler()
        {
            Form3 form3 = new Form3(this);
            form3.Show();
            this.Close(); // Form2'yi kapat
        }
        private void OyunBitir()
        {
            int dogruBayrakSayisi = oyun.DogruBayrakSayisi;
            int skor = oyun.SkorHesapla(dogruBayrakSayisi);

            if (oyun.OyunKazandiMi())
            {
                MessageBox.Show("Tebrikler! Oyunu kazandınız! Skorunuz: " + skor.ToString());
            }
            else
            {
                MessageBox.Show("Kaybettiniz! Skorunuz: " + skor.ToString());

                // Eğer kaybedildiğinde de skoru kaydetmek istiyorsanız buraya ekleyin
                Skor yeniSkor = new Skor(oyun.OyuncuAdi, skor, oyun.OyunSuresi);
                Program.GlobalSkorboard.SkorEkle(yeniSkor);
                Console.WriteLine($"Kaybedilen skor eklendi: {yeniSkor.OyuncuAdi}, {yeniSkor.SkorDegeri}, {yeniSkor.Sure}");
            }

            // Tüm hücreleri aç ve devre dışı bırak
            for (int x = 0; x < oyun.GridBoyutu; x++)
            {
                for (int y = 0; y < oyun.GridBoyutu; y++)
                {
                    if (oyun.MayinVarMi(x, y))
                    {
                        hucreler[x, y].Text = "*";
                        hucreler[x, y].BackColor = Color.Red;
                    }

                    hucreler[x, y].Enabled = false;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int gridBoyutu = oyun.GridBoyutu;
            int hucreBoyutu = 30;

            for (int x = 0; x < gridBoyutu; x++)
            {
                for (int y = 0; y < gridBoyutu; y++)
                {
                    Rectangle hucre = new Rectangle(x * hucreBoyutu, y * hucreBoyutu, hucreBoyutu, hucreBoyutu);
                    g.DrawRectangle(Pens.Black, hucre);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this);
            form3.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }
    }
}