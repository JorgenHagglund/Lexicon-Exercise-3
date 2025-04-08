using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    internal class VehicleHandler
    {
        List<Vehicle> pool = new();
        public void AddVehicle(Vehicle vehicle)
        {
            pool.Add(vehicle);
        }

        public void AddVehicle(string brand, string model, int year, double weight)
        {
            pool.Add(new Vehicle(brand, model, year, weight));
        }

        public void ModifyVehicle(int index, string brand, string model, int year, double weight)
        {
            if (index < 0 || index >= pool.Count)
                throw new ArgumentOutOfRangeException("Index out of range.");
            pool[index].Brand = brand;
            pool[index].Model = model;
            pool[index].Year = year;
            pool[index].Weight = weight;
        }

        public void ListVehicles()
        {
            for (int i = 0; i < pool.Count; i++)
            {
                Console.WriteLine($"{i}: {pool[i]}");
            }
        }

        public void OpenForBusiness()
        {
            Console.WriteLine("Welcome to the Vehicle Handler!");
            Console.WriteLine("We are now open for business.");
            try
            {
                // Simulate some operations
                AddVehicle("Toyota", "Corolla", 2020, 1500);
                AddVehicle("Honda", "Civic", 2019, 1400);

                // Create some errors
                List<SystemError> errors = new List<SystemError>
                {
                    new EngineFailureError(),
                    new BrakeFailureError(),
                    new TransmissionFailureError()
                };

                while (true)
                {
                    ShowMainMenu();
                    ConsoleKeyInfo ki = Console.ReadKey();
                    Console.WriteLine();
                    switch (ki.KeyChar)
                    {
                        case '0':
                            Console.WriteLine("Exiting...");
                            return;
                        case '1':
                            Console.WriteLine("Adding a new vehicle...");
                            Console.Write("Enter brand: ");
                            string brand = Console.ReadLine();
                            Console.Write("Enter model: ");
                            string model = Console.ReadLine();
                            Console.Write("Enter year: ");
                            int year = int.Parse(Console.ReadLine());
                            Console.Write("Enter weight: ");
                            double weight = double.Parse(Console.ReadLine());
                            AddVehicle(brand, model, year, weight);
                            break;
                        case '2':
                            Console.WriteLine("Listing all vehicles...");
                            ListVehicles();
                            break;
                        case '3':
                            Console.WriteLine("Available system errors...");
                            foreach (var error in errors)
                                Console.WriteLine(error.ErrorMessage());
                            break;
                        default:
                            Console.Beep();
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Thank you for using the Vehicle Handler!");
            }
        }

        private void ShowMainMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1: Add Vehicle");
            Console.WriteLine("2: List Vehicles");
            Console.WriteLine("3: List Availabe errors");
            Console.WriteLine("0: Exit");
            Console.Write("Select an option: ");
        }
    }
}
