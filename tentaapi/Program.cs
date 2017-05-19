using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tentaapi.ServiceReference1;

namespace tentaapi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kopplar upp mot riksbanken...");
            var client = new ServiceReference1.SweaWebServicePortTypeClient();
            
            var res = client.getAllCrossNames(LanguageType.sv);
            Console.Clear();
            foreach (var item in res)
            {
                Console.WriteLine(item.seriesid+ " "+ item.seriesname+" "+ item.seriesdescription);
            }
            Console.WriteLine("");
            Console.WriteLine("Klar, tryck return för att avsluta");
            Console.ReadLine();
        }
    }
}
