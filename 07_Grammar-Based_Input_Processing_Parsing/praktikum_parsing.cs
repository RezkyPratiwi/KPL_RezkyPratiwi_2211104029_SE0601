using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; //Mengambil data string dari internet
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace praktikum_parsing.json
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient c = new WebClient();
            var data = c.DownloadString("https://blockchain.info/ticker");
            //
            JObject currencies = JObject.Parse(data);
            var currency = currencies.SelectToken("GBP");
            var usdollar = currencies.SelectToken("USD");
            Console.WriteLine("British Pounds: " + currency);
            Console.WriteLine("US Dollar: " + usdollar);
            Console.Read();
        }
    }
}