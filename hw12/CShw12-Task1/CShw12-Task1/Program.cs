namespace task1
{

    public interface ICarBody { }
    public class Sedan : ICarBody { }
    public class Coupe : ICarBody { }

    public interface IEngine
    {
        public int NumberOfCylinders { get; }
    }
    public class LineFourEngine : IEngine
    {
        public int NumberOfCylinders => 4;
    }
    public class VEightEngine : IEngine
    {
        public int NumberOfCylinders => 8;
    }

    public interface IChassis { }
    public class RoadChassis : IChassis { }
    public class RaceChassis : IChassis { }

    public interface ITransmission { }
    public class ManualTransmission : ITransmission { }

    public interface ICarPanel { }
    public class DigitalCarPanel : ICarPanel { }

    public interface IStereoSystem { }
    public class HarmanCordon : IStereoSystem { }


    public class Car
    {
        public int VinNumber { get; }

        public ICarBody Body { get; }

        public IEngine Engine { get; }

        public IChassis Chassis { get; }
        public ITransmission Transmission { get; }
        public ICarPanel Panel { get; }

        public IStereoSystem StereoSystem { get; }


        public Car(int vin, ICarBody body, IEngine engine, IChassis chassis, ICarPanel panel, IStereoSystem stereoSystem, ITransmission transmission)
        {
            VinNumber = vin;
            Body = body;
            Engine = engine;
            Chassis = chassis;
            Panel = panel;
            StereoSystem = stereoSystem;
            Transmission = transmission;
            Chassis = chassis;
        }

        public override string ToString()
        {
            return "Car(" + VinNumber + ")";
        }
    }

    public class CarFactory
    {
        private CarFactory() { }
        private static int vin = 0;
        public static Car CreateFamilyCar() {
            return new Car(vin++, new Sedan(), new LineFourEngine(), new RoadChassis(), new DigitalCarPanel(), new HarmanCordon(), new ManualTransmission());
        }

        public static Car CreateMuscleCar() {
            return new Car(vin++, new Coupe(), new VEightEngine(), new RaceChassis(), new DigitalCarPanel(), new HarmanCordon(), new ManualTransmission());
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            var car1 = CarFactory.CreateFamilyCar();
            var car2 = CarFactory.CreateMuscleCar();
            Console.WriteLine(car1);
            Console.WriteLine(car2);
        }
    }
}
