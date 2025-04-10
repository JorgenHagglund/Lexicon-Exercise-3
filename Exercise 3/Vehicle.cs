namespace Exercise_3;

internal abstract class Vehicle
{
    private string brand;
    private string model;
    private int year;
    private double weight;

    public string Brand
    {
        get => brand;
        set
        {
            if (value.Length < 2 || value.Length > 20)
                throw new ArgumentException("Brand must be between 2 and 20 characters long.");
            brand = value;
        }
    }
    public string Model
    {
        get => model;
        set
        {
            if (value.Length < 2 || value.Length > 20)
                throw new ArgumentException("Model must be between 2 and 20 characters long.");
            model = value;
        }
    }
    public int Year
    {
        get => year;
        set
        {
            if (value < 1886 || value > DateTime.Now.Year)
                throw new ArgumentException("Year must be between 1886 and the current year.");
            year = value;
        }
    }
    public double Weight
    {
        get => weight;
        set
        {
            if (value < 0)
                throw new ArgumentException("Weight must be a positive number.");
            weight = value;
        }
    }

    public Vehicle()
    {
        Brand = "Unknown";
        Model = "Unknown";
        Year = 1886;
        Weight = 0;
    }

    public Vehicle(string brand, string model, int year, double weight)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Weight = weight;
    }

    public abstract void StartEngine();
    public abstract string Stats();   

    public override string ToString()
    {
        return $"{Brand} {Model} {Year}, {Weight} kg";
    }

    public virtual void GatherInfo()
    {
        Console.Write("Enter brand: ");
        Brand = Console.ReadLine();
        Console.Write("Enter model: ");
        Model = Console.ReadLine();
        Console.Write("Enter year: ");
        Year = int.Parse(Console.ReadLine());
        Console.Write("Enter weight: ");
        Weight = double.Parse(Console.ReadLine());
    }
}

