using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VehicleIncServiceLibrary;

namespace VehicleIncHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hosten kopplar upp sig vänta...");
            ServiceHost host = new ServiceHost(typeof(VehicleIncService));

            try
            {
                Console.Clear();
                host.Open();
                if (host.State==CommunicationState.Opened)
                    PrintServiceInfo(host);
                else
                {
                    Console.WriteLine("hosten ej uppkopplad kontakta support...");
                    Environment.Exit(-1);
                }
                Console.WriteLine("");

                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
                host.Abort();


            }
        }

        static void PrintServiceInfo(ServiceHost host)
        {
            Console.WriteLine("Tjänsten" +host.Description + "är uppe och körs med följande endpoints");

            foreach (var item in host.Description.Endpoints)
            {
                Console.WriteLine(item.Address);
            }

        }




    }
}
