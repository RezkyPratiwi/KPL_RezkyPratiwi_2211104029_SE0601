using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

public class CovidConfig
{
    private const string configFile = "covid_config.json";

    public string SatuanSuhu { get; set; }
    public int BatasHariDemam { get; set; }
    public string PesanDitolak { get; set; }
    public string PesanDiterima { get; set; }

    public CovidConfig()
    {
        if (File.Exists(configFile))
        {
            string json = File.ReadAllText(configFile);
            var configData = JsonConvert.DeserializeObject<CovidConfig>(json);
            SatuanSuhu = configData.SatuanSuhu;
            BatasHariDemam = configData.BatasHariDemam;
            PesanDitolak = configData.PesanDitolak;
            PesanDiterima = configData.PesanDiterima;
        }
        else
        {
            SatuanSuhu = "celcius";
            BatasHariDemam = 14;
            PesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            PesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }
    }

    public void UbahSatuan()
    {
        SatuanSuhu = SatuanSuhu == "celcius" ? "fahrenheit" : "celcius";
        SimpanKonfigurasi();
    }

    private void SimpanKonfigurasi()
    {
        var json = JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(configFile, json);
    }
}