using Exercise_3.Interfaces;

namespace Exercise_3;

class Car : Vehicle, ICleanable
{
    private int numberOfDoors;
    public int NumberOfDoors { get => numberOfDoors; }
    public Car() : base()
    {
        numberOfDoors = 4; // Default number of doors for a car 
    }

    public Car(string brand, string model, int year, double weight, int numberOfDoors = 4) : base()
    {
        Brand = brand;
        Model = model;
        Year = year;
        Weight = weight;
        this.numberOfDoors = numberOfDoors; 
    }

    public override void StartEngine()
    {
        Console.WriteLine("Car engine started.");
    }

    public override string Stats()
    {
        return $"Car: {Brand} {Model}, Year: {Year}, Weight: {Weight} kg, Doors: {NumberOfDoors}";  
    }

    public override void GatherInfo()
    {
        base.GatherInfo();
        Console.Write("Enter number of doors: ");
        if (int.TryParse(Console.ReadLine(), out int doors))
        {
            numberOfDoors = doors;
        }
        else
        {
            Console.WriteLine($"{Environment.NewLine}Invalid input. Defaulting to 4 doors.");
            numberOfDoors = 4;
        }
    }

    public void Clean()
    {
        Console.WriteLine("Swoosh! Car cleaned");
    }

    public override string ToString()
    {
        return $"Car: {Brand} {Model}, Year: {Year}, Weight: {Weight} kg";
    }   
}

class Truck : Vehicle, ICleanable
{
    public int Capacity { get; set; }

    public Truck() : base()
    {
        Capacity = 52000; // Default capacity for a truck in kg
    }

    public override void StartEngine()
    {
        Console.WriteLine("Truck engine started.");
    }

    public override string Stats()
    {
        return $"Truck: {Brand} {Model}, Year: {Year}, Weight: {Weight} kg, Capacity: {Capacity} kg";
    }

    public override void GatherInfo()
    {
        base.GatherInfo();
        Console.Write("Enter truck capacity in kg: ");
        if (int.TryParse(Console.ReadLine(), out int capacity))
        {
            Capacity = capacity;
        }
        else
        {
            Console.WriteLine($"{Environment.NewLine}Invalid input. Defaulting to 52000 kg.");
            Capacity = 52000;
        }   
    }

    public void Clean()
    {
        Console.WriteLine("Swoosh! Truck cleaned");
    }

    public override string ToString()
    {
        return $"Truck: {Brand} {Model}, Year: {Year}, Weight: {Weight} kg";
    }
}

class Motorcycle : Vehicle
{
    public bool HasSideCart { get; set; }
    public Motorcycle() : base()
    {
        HasSideCart = false; // Default value for side cart
    }

    public override void StartEngine()
    {
        Console.WriteLine("Kickstarting... Motorcycle engine started.");
    }

    public override string Stats()
    {
        return $"Motorcycle: {Brand} {Model}, Year: {Year}, Weight: {Weight} kg, Side Cart: {(HasSideCart ? "Yes" : "No")}";
    }

    public override void GatherInfo()
    {
        base.GatherInfo();
        Console.Write("Does the motorcycle have a side cart? (yes/no): ");
        string input = Console.ReadLine().ToLower();
        if (input == "yes")
        {
            HasSideCart = true;
        }
        else if (input == "no")
        {
            HasSideCart = false;
        }
        else
        {
            Console.WriteLine("Invalid input. Defaulting to no side cart.");
            HasSideCart = false;
        }
    }

    public override string ToString()
    {
        return $"Motorcycle: {Brand} {Model}, Year: {Year}, Weight: {Weight} kg";
    }
}  

class ElectricScooter : Vehicle
{
    public int BatteryRange { get; set; }

    public ElectricScooter() : base()
    {
        BatteryRange = 50; // Default battery range in km
    }

    public ElectricScooter(string brand, string model, int year, double weight, int batteryRange = 50) : base(brand, model, year, weight)
    {
        BatteryRange = batteryRange;
    }
    public override string ToString()
    {
        return $"Electric Scooter: {Brand} {Model}, Year: {Year}, Weight: {Weight} kg";
    }

    public override void StartEngine()
    {
        Console.WriteLine("Electric scooter engine started silently.");
    }

    public override void GatherInfo()
    {
        base.GatherInfo();
        Console.Write("Enter battery range in km: ");
        if (int.TryParse(Console.ReadLine(), out int range))
        {
            BatteryRange = range;
        }
        else
        {
            Console.WriteLine("Invalid input. Defaulting to 50 km.");
            BatteryRange = 50;
        }
    }

    public override string Stats()
    {
        return $"Electric Scooter: {Brand} {Model}, Year: {Year}, Weight: {Weight} kg, Battery Range: {BatteryRange} km";
    }
}