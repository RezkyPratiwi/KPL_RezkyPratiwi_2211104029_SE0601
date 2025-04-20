using System;

class Program
{
    static void Main(string[] args)
    {
        BankTransferConfig config = BankTransferConfig.LoadConfig();

        Console.WriteLine("=== Rezky Pratiwi - 2211104029 ===");
        Console.Write(config.lang == "en" ?
            "\nPlease insert the amount of money to transfer: " :
            "\nMasukkan jumlah uang yang akan di-transfer:");

        int amount = int.Parse(Console.ReadLine());

        int fee = amount <= config.transfer.threshold ? config.transfer.low_fee : config.transfer.high_fee;
        int total = amount + fee;

        // Fee Output
        if (config.lang == "en")
        {
            Console.WriteLine($"\nTransfer fee = {fee}");
            Console.WriteLine($"Total amount = {total}");
            Console.WriteLine("\nSelect transfer method:");
        }
        else
        {
            Console.WriteLine($"\nBiaya transfer = {fee}");
            Console.WriteLine($"Total biaya = {total}");
            Console.WriteLine("Pilih metode transfer:");
        }

        // Print methods
        for (int i = 0; i < config.methods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {config.methods[i]}");
        }

        Console.ReadLine(); // Method selection input

        // Confirmation
        string confirmKeyword = config.lang == "en" ? config.confirmation.en : config.confirmation.id;
        Console.Write(config.lang == "en" ?
            $"\nPlease type \"{confirmKeyword}\" to confirm the transaction: " :
            $"\nKetik \"{confirmKeyword}\" untuk mengkonfirmasi transaksi:");

        string userConfirm = Console.ReadLine();

        if (userConfirm == confirmKeyword)
        {
            Console.WriteLine(config.lang == "en" ? "\nThe transfer is completed" : "\nProses transfer berhasil");
        }
        else
        {
            Console.WriteLine(config.lang == "en" ? "Transfer is cancelled" : "Transfer dibatalkan");
        }
    }
}