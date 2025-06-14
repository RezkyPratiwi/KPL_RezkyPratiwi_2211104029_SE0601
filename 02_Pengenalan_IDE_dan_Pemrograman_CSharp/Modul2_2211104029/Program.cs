using System;

class Program
{
    static void Main()
    {
        // A. Menerima input nama praktikan
        Console.Write("Masukkan nama Anda: ");
        string nama = Console.ReadLine();
        Console.WriteLine($"Selamat datang, {nama}!");

        // B. Membuat array int berisi 50 elemen dengan nilai sesuai index
        int[] arr = new int[50];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i;
        }

        // Menampilkan isi array dengan aturan tertentu
        for (int i = 0; i < arr.Length; i++)
        {
            if (i % 2 == 0 && i % 3 == 0)
                Console.WriteLine($"{i} #$#$");
            else if (i % 2 == 0)
                Console.WriteLine($"{i} ##");
            else if (i % 3 == 0)
                Console.WriteLine($"{i} $$");
            else
                Console.WriteLine(i);
        }

        // C. Meminta input angka untuk dicek apakah bilangan prima
        Console.Write("Masukkan angka (1-10000): ");
        string nilaiString = Console.ReadLine();
        int nilaiInt = Convert.ToInt32(nilaiString);

        if (IsPrime(nilaiInt))
            Console.WriteLine($"Angka {nilaiInt} merupakan bilangan prima");
        else
            Console.WriteLine($"Angka {nilaiInt} bukan merupakan bilangan prima");
    }

    static bool IsPrime(int number)
    {
        if (number < 2)
            return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
}