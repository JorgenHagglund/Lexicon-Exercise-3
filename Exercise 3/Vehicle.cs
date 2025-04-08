using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3;

internal class Vehicle
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

    public Vehicle(string brand, string model, int year, double weight)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Weight = weight;
    }

    public override string ToString()
    {
        return $"{Brand} {Model} {Year}, {Weight} kg";
    }
}

