using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VehicleClient.VehicleIncService;

namespace VehicleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IVehicleIncServiceChannel> channelFactory =
                new ChannelFactory<IVehicleIncServiceChannel>("WSHttpBinding_IVehicleIncService");
            try
            {


                var ch = channelFactory.CreateChannel();

                ch.ByCar(new Car() {ID = 1, Model = "Tesla Sportscar", motorPower = 400, nbrOfDoors = 4, wheels = 4});
                ch.ByMotorcycle(new Motorcycle() {ID = 2, type = "Chopper", motorPower = 500, wheels = 2});

                Array carArray = ch.GetCar();
                Array mcArray = ch.GetMotorcycles();
                List<Car> carlist = carArray.Cast<Car>().ToList();
                List<Motorcycle> mclist = mcArray.Cast<Motorcycle>().ToList();
                Console.WriteLine("inköpta bilar");
                foreach (var item in carlist)
                {
                    Console.WriteLine("ID: " + item.ID + " Model: " + item.Model + " Motorstyrka: " + item.motorPower +
                                      " Antal dörrar: " + item.nbrOfDoors + " Antal hjul: " + item.wheels);
                }
                Console.WriteLine("inköpta motorcyclar");
                foreach (var item in mclist)
                {
                    Console.WriteLine("ID: " + item.ID + " type: " + item.type + " Motorstyrka: " + item.motorPower +
                                       " Antal hjul: " + item.wheels);
                }

                var bil = ch.SellCar(1);
                var mc = ch.SellMotorcycle(2);
                Array carArrayny = ch.GetCar();
                Array mcArrayny = ch.GetMotorcycles();
                List<Car> carlistny = carArrayny.Cast<Car>().ToList();
                List<Motorcycle> mclistny = mcArrayny.Cast<Motorcycle>().ToList();


                Console.WriteLine("");
                Console.WriteLine("nu säljer vi en bil och en mc");
                Console.WriteLine("då ska vi ha inga fordon kvar");
                Console.WriteLine("antalbilar:");
                Console.WriteLine(carlistny.Count());

                Console.WriteLine("antalmc:");
                Console.WriteLine(mclistny.Count());
                Console.WriteLine("");
                Console.WriteLine("The service is finito.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.ReadLine();
                ch.Close();
               channelFactory.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
                channelFactory.Abort();
            }


        }
    }
}
