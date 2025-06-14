using System;
using System.IO;
using System.Text.Json;

public class DataMahasiswa2211104029
{
    // Class untuk merepresentasikan struktur JSON
    public class Address
    {
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }

    public class Course
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Mahasiswa
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public Address address { get; set; }
        public Course[] courses { get; set; }
    }

    public static void ReadJSON()
    {
        string filePath = "jurnal7_1_2211104029.json";

        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);

            Mahasiswa mahasiswa = JsonSerializer.Deserialize<Mahasiswa>(jsonString);

            Console.WriteLine("======= Data Mahasiswa =======");
            Console.WriteLine($"Nama  : {mahasiswa.firstName} {mahasiswa.lastName}");
            Console.WriteLine($"Gender: {mahasiswa.gender}");
            Console.WriteLine($"Usia  : {mahasiswa.age}");
            Console.WriteLine($"Alamat: {mahasiswa.address.streetAddress}, " +
                $"{mahasiswa.address.city}, {mahasiswa.address.state}");
            Console.WriteLine("\n======= Mata Kuliah =======");

            foreach (var course in mahasiswa.courses)
            {
                Console.WriteLine($"Kode: {course.code} - Nama: {course.name}");
            }
        }
        else
        {
            Console.WriteLine("File JSON tidak ditemukan.");
        }
    }
}