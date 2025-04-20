using System.Text.Json;
using System.IO;

public class BankTransferConfig
{
    public string lang { get; set; }
    public Transfer transfer { get; set; }
    public List<string> methods { get; set; }
    public Confirmation confirmation { get; set; }

    public static string filePath = "bank_transfer_config.json";

    public static BankTransferConfig LoadConfig()
    {
        if (!File.Exists(filePath))
        {
            var defaultConfig = new BankTransferConfig
            {
                lang = "en",
                transfer = new Transfer { threshold = 10000000, low_fee = 4000, high_fee = 10000 },
                methods = new List<string> {"BRIVA", "QRIS", "LinkAja" },
                confirmation = new Confirmation { en = "yes", id = "ya" }
            };

            string json = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            return defaultConfig;
        }
        else
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<BankTransferConfig>(json);
        }
    }
}

public class Transfer
{
    public int threshold { get; set; }
    public int low_fee { get; set; }
    public int high_fee { get; set; }
}

public class Confirmation
{
    public string en { get; set; }
    public string id { get; set; }
}