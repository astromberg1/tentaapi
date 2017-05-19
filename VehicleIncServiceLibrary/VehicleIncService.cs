using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace VehicleIncServiceLibrary
{

    [DataContract]
    public class Vehicle
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int wheels { get; set; }
        [DataMember]
        public int motorPower { get; set; }

    }
    [DataContract]
    public class Car:Vehicle
    {
        [DataMember]
        public int nbrOfDoors { get; set; }
        [DataMember]
        public string Model { get; set; }

    }
    [DataContract]
    public class Motorcycle:Vehicle
    {
        [DataMember]
        public string type { get; set; }

    }

    [ServiceContract]
    public interface IVehicleIncService

    {
       

        [OperationContract]
        void ByMotorcycle(Motorcycle motorcycle);

        [OperationContract]
        void ByCar(Car car);

        [OperationContract]
        List<Car> GetCar();

        [OperationContract]
        List<Motorcycle> GetMotorcycles();

        [OperationContract]
        Car SellCar(int id);


        [OperationContract]
        Motorcycle SellMotorcycle(int id);



    }



    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]// uppgift 5
    public class VehicleIncService:IVehicleIncService
    {
        private List<Car> cars = new List<Car>();
        private List<Motorcycle> Motorcycles = new List<Motorcycle>();

        public void ByCar(Car car)
        {
            cars.Add(car);
        }

        public void ByMotorcycle(Motorcycle motorcycle)
        {
            Motorcycles.Add(motorcycle);
        }

        public List<Car> GetCar()
        {
            return cars;
        }

        public List<Motorcycle> GetMotorcycles()
        {
            return Motorcycles;
        }

        public Car SellCar(int id)
        {
           var car= cars.FirstOrDefault(x => x.ID == id);
            if (car != null)
                cars.Remove(car);
            return car;

        }

        public Motorcycle SellMotorcycle(int id)
        {
            var mc = Motorcycles.FirstOrDefault(x => x.ID == id);
            if (mc != null)
                Motorcycles.Remove(mc);
            return mc;
        }
    }
}
