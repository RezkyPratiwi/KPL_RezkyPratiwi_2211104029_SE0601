using System;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        CovidConfig config = new CovidConfig();

        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
        int hariDemam = Convert.ToInt32(Console.ReadLine());

        if ((config.SatuanSuhu == "celcius" && suhu >= 36.5 && suhu <= 37.5) ||
            (config.SatuanSuhu == "fahrenheit" && suhu >= 97.7 && suhu <= 99.5))
        {
            if (hariDemam < config.BatasHariDemam)
                Console.WriteLine(config.PesanDiterima);
            else
                Console.WriteLine(config.PesanDitolak);
        }
        else
        {
            Console.WriteLine(config.PesanDitolak);
        }

        Console.WriteLine("Apakah ingin mengubah satuan suhu? (y/n)");
        if (Console.ReadLine().ToLower() == "y")
        {
            config.UbahSatuan();
            Console.WriteLine("Satuan suhu berhasil diubah ke " + config.SatuanSuhu);
        }
    }
}