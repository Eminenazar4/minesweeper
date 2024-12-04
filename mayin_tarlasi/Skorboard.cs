using System;
using System.Collections.Generic;
using System.Linq;

public class Skor
{
    public string OyuncuAdi { get; set; }
    public int SkorDegeri { get; set; }
    public int Sure { get; set; } // Oyun süresi (saniye cinsinden)

    public Skor(string oyuncuAdi, int skorDegeri, int sure)
    {
        OyuncuAdi = oyuncuAdi;
        SkorDegeri = skorDegeri;
        Sure = sure;
    }
}
public class Skorboard
{
    private List<Skor> skorlar = new List<Skor>();
    public void SkorEkle(Skor yeniSkor)
    {
        skorlar.Add(yeniSkor);
        skorlar = skorlar.OrderByDescending(s => s.SkorDegeri).ThenBy(s => s.Sure).ToList();

        if (skorlar.Count > 10)
        {
            skorlar = skorlar.Take(10).ToList();
        }
    }
    public List<Skor> EnIyiSkorlar()
    {
        return skorlar;
    }
}