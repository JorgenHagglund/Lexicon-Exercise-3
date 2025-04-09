namespace Exercise_3;

class Car : Vehicle
{
    private int numberOfDoors;
    public int NumberOfDoors { get => numberOfDoors; }
    public Car(string brand, string model, int year, double weight) : base(brand, model, year, weight)
    {
        numberOfDoors = 4; // Default number of doors for a car 
    }

    public override void StartEngine()
    {
        Console.WriteLine("Car engine started.");
    }

    public override string Stats()
    {
        return $"Car: {Brand} {Model}, Year: {Year}, Weight: {Weight} kg, Doors: {NumberOfDoors}";  
    }
    public override string ToString()
    {
        return $"Car: {Brand} {Model}, Year: {Year}, Weight: {Weight} kg";
    }   
}

class Truck : Vehicle
{
    public int Capacity { get; set; }

    public Truck(string brand, string model, int year, double weight) : base(brand, model, year, weight)
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

    public override string ToString()
    {
        return $"Truck: {Brand} {Model}, Year: {Year}, Weight: {Weight} kg";
    }
}

class Motorcycle : Vehicle
{
    public bool HasSideCart { get; set; }
    public Motorcycle(string brand, string model, int year, double weight) : base(brand, model, year, weight)
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

    public override string ToString()
    {
        return $"Motorcycle: {Brand} {Model}, Year: {Year}, Weight: {Weight} kg";
    }
}  

class ElectricScooter : Vehicle
{
    public int BatteryRange { get; set; }

    public ElectricScooter(string brand, string model, int year, double weight) : base(brand, model, year, weight)
    {
        BatteryRange = 50; // Default battery range in km
    }
    public override string ToString()
    {
        return $"Electric Scooter: {Brand} {Model}, Year: {Year}, Weight: {Weight} kg";
    }

    public override void StartEngine()
    {
        Console.WriteLine("Electric scooter engine started silently.");
    }

    public override string Stats()
    {
        return $"Electric Scooter: {Brand} {Model}, Year: {Year}, Weight: {Weight} kg, Battery Range: {BatteryRange} km";
    }
}