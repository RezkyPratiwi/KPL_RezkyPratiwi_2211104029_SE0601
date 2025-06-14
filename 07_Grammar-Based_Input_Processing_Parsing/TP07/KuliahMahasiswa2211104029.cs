using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

class KuliahMahasiswa2211104005
{
    public class MataKuliah
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Kuliah
    {
        public List<MataKuliah> courses { get; set; }
    }

    public static void ReadJSON()
    {
        string filePath = "tp7_2_2211104029.json";  // Sesuaikan jika di folder "Data/"
        string jsonString = File.ReadAllText(filePath);

        Kuliah kuliah = JsonSerializer.Deserialize<Kuliah>(jsonString);

        Console.WriteLine("Daftar mata kuliah yang diambil:");
        int i = 1;
        foreach (var mk in kuliah.courses)
        {
            Console.WriteLine($"MK {i} {mk.code} - {mk.name}");
            i++;
        }
    }
}
