using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace mayin_tarlasi
{
    public class Oyun
    {
        private int hamleSayaci;
        public Stopwatch stopwatch;

        public int OyunSuresi
        {
            get { return (int)(stopwatch.ElapsedMilliseconds / 1000); }
        }

        public string OyuncuAdi { get; private set; }
        public int DogruBayrakSayisi { get; set; }
        public int GridBoyutu { get; private set; }
        public int MayinSayisi { get; private set; }
        private bool[,] mayinKonumu;
        private bool[,] bayrakKonumu;
        private bool[,] acilanHuceler;

        public Oyun(string oyuncuAdi, int gridBoyutu, int mayinSayisi)
        {
            OyuncuAdi = oyuncuAdi;
            GridBoyutu = gridBoyutu;
            MayinSayisi = mayinSayisi;
            mayinKonumu = new bool[gridBoyutu, gridBoyutu];
            bayrakKonumu = new bool[gridBoyutu, gridBoyutu];
            acilanHuceler = new bool[gridBoyutu, gridBoyutu];
            MayinlariYerlestir();
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        public bool HucreAcildiMi(int x, int y)
        {
            return acilanHuceler[x, y];
        }

        public int SkorHesapla(int dogruBayrakSayisi)
        {
            long oyunSuresi = stopwatch.ElapsedMilliseconds / 1000;
            if (oyunSuresi == 0) oyunSuresi = 1;

            int skor = (dogruBayrakSayisi * 1000) / (int)oyunSuresi;
            return Math.Max(skor, 0);
        }

        private void MayinlariYerlestir()
        {
            Random rnd = new Random();
            int yerlesenMayin = 0;
            while (yerlesenMayin < MayinSayisi)
            {
                int x = rnd.Next(GridBoyutu);
                int y = rnd.Next(GridBoyutu);
                if (!mayinKonumu[x, y])
                {
                    mayinKonumu[x, y] = true;
                    yerlesenMayin++;
                }
            }
        }
        public void BayrakKoy(int x, int y)
        {
            if (mayinKonumu[x, y] && !bayrakKonumu[x, y])
            {
                DogruBayrakSayisi++;
            }
            else if (mayinKonumu[x, y] && bayrakKonumu[x, y])
            {
                DogruBayrakSayisi--;
            }
            bayrakKonumu[x, y] = !bayrakKonumu[x, y];
        }

        public bool BayrakVarMi(int x, int y)
        {
            return bayrakKonumu[x, y];
        }

        public bool MayinVarMi(int x, int y)
        {
            return mayinKonumu[x, y];
        }

        public int HucreyiAc(int x, int y)
        {
            int komsuMayinSayisi = HesaplaKomsuMayinSayisi(x, y);
            bool[,] ziyaretEdildi = new bool[GridBoyutu, GridBoyutu];
            Queue<(int, int)> hucreKuyrugu = new Queue<(int, int)>();
            acilanHuceler[x, y] = true;
            hucreKuyrugu.Enqueue((x, y));

            while (hucreKuyrugu.Count > 0)
            {
                var (cx, cy) = hucreKuyrugu.Dequeue();

                if (ziyaretEdildi[cx, cy]) continue;

                ziyaretEdildi[cx, cy] = true;

                int komsuMayinSayisiYerel = HesaplaKomsuMayinSayisi(cx, cy);

                if (komsuMayinSayisiYerel == 0)
                {
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int nx = cx + i;
                            int ny = cy + j;

                            if (nx >= 0 && ny >= 0 && nx < GridBoyutu && ny < GridBoyutu && !ziyaretEdildi[nx, ny])
                            {
                                hucreKuyrugu.Enqueue((nx, ny));
                            }
                        }
                    }
                }
            }

            return komsuMayinSayisi;
        }

        public int HesaplaKomsuMayinSayisi(int x, int y)
        {
            int komsuMayinSayisi = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;

                    int nx = x + i;
                    int ny = y + j;

                    if (nx >= 0 && ny >= 0 && nx < GridBoyutu && ny < GridBoyutu)
                    {
                        if (mayinKonumu[nx, ny]) komsuMayinSayisi++;
                    }
                }
            }

            return komsuMayinSayisi;
        }

        public bool OyunKazandiMi()
        {
            for (int x = 0; x < GridBoyutu; x++)
            {
                for (int y = 0; y < GridBoyutu; y++)
                {
                    if (!HucreAcildiMi(x, y) && !MayinVarMi(x, y))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool KazanmaDurumu()
        {
            int acilanHucreSayisi = 0;
            int dogruBayrakSayisi = 0;
            int toplamHucreSayisi = GridBoyutu * GridBoyutu;

            for (int x = 0; x < GridBoyutu; x++)
            {
                for (int y = 0; y < GridBoyutu; y++)
                {
                    if (HucreAcildiMi(x, y)) // Bu hücre açıldıysa
                        acilanHucreSayisi++;

                    if (BayrakVarMi(x, y) && MayinVarMi(x, y)) // Bu hücrede doğru bayrak varsa
                        dogruBayrakSayisi++;
                }
            }

            return acilanHucreSayisi == (toplamHucreSayisi - MayinSayisi) || dogruBayrakSayisi == MayinSayisi;
        }
        public event Action OyunBitti;

        public void OyunBitir()
        {
            stopwatch.Stop();

            int dogruBayrakSayisi = DogruBayrakSayisi;
            int skorDegeri = SkorHesapla(dogruBayrakSayisi);
            Skor yeniSkor = new Skor(OyuncuAdi, skorDegeri, OyunSuresi);

            Program.GlobalSkorboard.SkorEkle(yeniSkor);

            MessageBox.Show("Oyun bitti! Skorunuz: " + skorDegeri);

            OyunBitti?.Invoke(); // Oyun bitti olayını tetikleyin
        }


    }
}