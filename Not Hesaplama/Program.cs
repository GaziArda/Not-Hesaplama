namespace Not_Hesaplama
{
 
   using System;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Kaç öğrenci kaydetmek istiyorsunuz: ");
                int ogrenciSayisi = int.Parse(Console.ReadLine());

               
                string[,] ogrenciler = new string[ogrenciSayisi, 7]; 
                double[] ortalamalar = new double[ogrenciSayisi];

                for (int i = 0; i < ogrenciSayisi; i++)
                {
                    Console.WriteLine($"{i + 1}. Öğrencinin bilgilerini giriniz:");

                    Console.Write("Numarasını giriniz: ");
                    ogrenciler[i, 0] = Console.ReadLine();

                    Console.Write("Adını giriniz: ");
                    ogrenciler[i, 1] = Console.ReadLine();

                    Console.Write("Soyadını giriniz: ");
                    ogrenciler[i, 2] = Console.ReadLine();

                    
                    ogrenciler[i, 3] = NotGirisi("Vize");

                   
                    ogrenciler[i, 4] = NotGirisi("Final");

                   
                    double vize = double.Parse(ogrenciler[i, 3]);
                    double final = double.Parse(ogrenciler[i, 4]);
                    double ortalama = vize * 0.4 + final * 0.6;
                    ogrenciler[i, 5] = ortalama.ToString("F2");
                    ortalamalar[i] = ortalama;

                    
                    ogrenciler[i, 6] = HarfNotuHesapla(ortalama);
                }

               
                double sinifOrtalamasi = 0;
                double enDusukNot = double.MaxValue;
                double enYuksekNot = double.MinValue;

                for (int i = 0; i < ogrenciSayisi; i++)
                {
                    sinifOrtalamasi += ortalamalar[i];
                    if (ortalamalar[i] < enDusukNot) enDusukNot = ortalamalar[i];
                    if (ortalamalar[i] > enYuksekNot) enYuksekNot = ortalamalar[i];
                }

                sinifOrtalamasi /= ogrenciSayisi;

                
                Console.WriteLine("\n{0,-10}{1,-15}{2,-15}{3,-10}{4,-10}{5,-10}{6,-10}", "Numara", "Ad", "Soyad", "Vize", "Final", "Ortalama", "Harf Notu");
                Console.WriteLine(new string('-', 80));

                for (int i = 0; i < ogrenciSayisi; i++)
                {
                    Console.WriteLine("{0,-10}{1,-15}{2,-15}{3,-10}{4,-10}{5,-10}{6,-10}",
                        ogrenciler[i, 0],
                        ogrenciler[i, 1],
                        ogrenciler[i, 2],
                        ogrenciler[i, 3],
                        ogrenciler[i, 4],
                        ogrenciler[i, 5],
                        ogrenciler[i, 6]);
                }

                
                Console.WriteLine(new string('-', 80));
                Console.WriteLine($"\nSınıf Ortalaması : {sinifOrtalamasi,6:F2}");
                Console.WriteLine($"En Düşük Not    : {enDusukNot,6:F2}");
                Console.WriteLine($"En Yüksek Not   : {enYuksekNot,6:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bir hata oluştu: {ex.Message}");
            }
        }

        static string NotGirisi(string notTuru)
        {
            while (true)
            {
                try
                {
                    Console.Write($"{notTuru} notunu giriniz (0-100): ");
                    int not = int.Parse(Console.ReadLine());
                    if (not < 0 || not > 100)
                    {
                        throw new ArgumentOutOfRangeException($"{notTuru} notu 0-100 arasında olmalıdır.");
                    }
                    return not.ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hatalı giriş: {ex.Message}");
                }
            }
        }

        static string HarfNotuHesapla(double ortalama)
        {
            if (ortalama >= 90) return "AA";
            if (ortalama >= 80) return "BA";
            if (ortalama >= 70) return "BB";
            if (ortalama >= 60) return "CB";
            if (ortalama >= 50) return "CC";
            return "FF";
        }
    }
}
