using System;
using System.IO;
using System.Text.Json;

class GlossaryItem2211104029
{
    class GlossDef
    {
        public string para { get; set; }
        public string[] GlossSeeAlso { get; set; }
    }

    class GlossEntry
    {
        public string ID { get; set; }
        public string SortAs { get; set; }
        public string GlossTerm { get; set; }
        public string Acronym { get; set; }
        public string Abbrev { get; set; }
        public GlossDef GlossDef { get; set; }
        public string GlossSee { get; set; }
    }

    class GlossList
    {
        public GlossEntry GlossEntry { get; set; }
    }

    class GlossDiv
    {
        public string title { get; set; }
        public GlossList GlossList { get; set; }
    }

    class Glossary
    {
        public string title { get; set; }
        public GlossDiv GlossDiv { get; set; }
    }

    class Root
    {
        public Glossary glossary { get; set; }
    }

    public static void ReadJSON()
    {
        string filePath = "jurnal7_3_2211104029.json";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File JSON tidak ditemukan.");
            return;
        }

        // Membaca dan parsing JSON
        Root data = JsonSerializer.Deserialize<Root>(File.ReadAllText(filePath));

        // Mengambil bagian GlossEntry
        GlossEntry entry = data.glossary.GlossDiv.GlossList.GlossEntry;

        Console.WriteLine("===== Glossary Entry =====");
        Console.WriteLine($"ID        : {entry.ID}");
        Console.WriteLine($"SortAs    : {entry.SortAs}");
        Console.WriteLine($"Term      : {entry.GlossTerm}");
        Console.WriteLine($"Acronym   : {entry.Acronym}");
        Console.WriteLine($"Abbrev    : {entry.Abbrev}");
        Console.WriteLine($"Definition: {entry.GlossDef.para}");
        Console.Write("See Also  : ");
        Console.WriteLine(string.Join(", ", entry.GlossDef.GlossSeeAlso));
        Console.WriteLine($"GlossSee  : {entry.GlossSee}");
    }
}