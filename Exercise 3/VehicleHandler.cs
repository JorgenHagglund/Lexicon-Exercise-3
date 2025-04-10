using Exercise_3.Interfaces;

namespace Exercise_3
{
    // Svar på frågorna i del 5:
    // ===================================
    // 1: Att försöka lägga till en Car till List<Motorcycle> kommer generera ett kompileringsfel
    //      p.g.a. olika typer
    // 2: För att kunna lägga till alla fordonstyper, fungerar min 'pool' (List<Vehicle>) väldigt bra.
    // 3: Nej, för List innehåller en Clear(), men ingen Clean(). Däremot kan jag använda Clean() på varje
    //      fordon i listan som implementerar ICleanable.
    // 4: För att det är ett tvingande "kontrakt". Implementerande klasser måste implementera
    //      interfacets egenskaper (properties), metoder och händelser (events).
    internal class VehicleHandler
    {
        List<Vehicle> pool = new();
        public void AddVehicle(Vehicle vehicle)
        {
            pool.Add(vehicle);
        }

        public void AddVehicle(string brand, string model, int year, double weight)
        {
            pool.Add(new Car(brand, model, year, weight));
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

        private void ListVehicles()
        {
            for (int i = 0; i < pool.Count; i++)
            {
                Console.WriteLine($"{i}: {pool[i]}");
            }
        }

        private void ListVehicleStats()
        {
            foreach (var vehicle in pool)
            {
                Console.WriteLine(vehicle.Stats());
                vehicle.StartEngine();
                if (vehicle is ICleanable)
                {
                    (vehicle as ICleanable)?.Clean();
                }
            }
        }

        public void OpenForBusiness()
        {
            // Get the types of vehicles there are
            // This snippet is borrowed from Stack Overflow.
            var vehicleTypes = AppDomain.CurrentDomain.GetAssemblies()
                // alternative: .GetExportedTypes()
                .SelectMany(domainAssembly => domainAssembly.GetTypes())
                .Where(type => type.IsSubclassOf(typeof(Vehicle)) 
                // alternative: => typeof(Vehicle).IsAssignableFrom(type)
                // alternative: => type.IsSubclassOf(typeof(B))
                // alternative: && type != typeof(B)
                // alternative: && ! type.IsAbstract
                ).ToArray();

            Console.WriteLine("Welcome to the Vehicle Handler!");
            Console.WriteLine("We are now open for business.");
            try
            {
                // Simulate some operations, Car is default
                AddVehicle("Toyota", "Corolla", 2020, 1500);
                AddVehicle("Honda", "Civic", 2019, 1400);
                var eScooter = new ElectricScooter("Xiaomi", "M365", 2021, 125, 25);
                AddVehicle(eScooter);   

                // Create some errors
                List<SystemError> errors = new List<SystemError>
                {
                    new EngineFailureError(),
                    new BrakeFailureError(),
                    new TransmissionFailureError()
                };

                while (true)
                {
                    char choise = ShowMainMenu();
                    switch (choise)
                    {
                        case '0':
                            Console.WriteLine("Exiting...");
                            return;
                        case '1':
                            Console.WriteLine("Adding a new vehicle...");
                            Vehicle? vehicle = ShowVehicleMenu(vehicleTypes);
                            if (vehicle != null)
                            {
                                vehicle.GatherInfo();
                                AddVehicle(vehicle);
                            }
                            break;
                        case '2':
                            Console.WriteLine("Listing all vehicles...");
                            ListVehicles();
                            break;
                        case '3':
                            Console.WriteLine("Listing vehicle stats...");
                            ListVehicleStats();
                            break;
                        case '4':
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

        private char GetUserChoise(int max, string prompt)
        {
            int choise;
            do
            {
                Console.Write($"{prompt}: ");
                ConsoleKeyInfo ki = Console.ReadKey();
                if (int.TryParse("" + ki.KeyChar, out choise) && choise >= 0 && choise <= max)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Beep();
                    choise = -1;
                    continue;
                }
            } while (choise < 0 || choise > max);
            return choise.ToString().First();
        }

        private Vehicle? ShowVehicleMenu(Type[] vehicleTypes)
        {
            char choise;
            do
            {
                int i = 1;
                foreach (var type in vehicleTypes)
                {
                    Console.WriteLine($"{i++}: {type.Name}");
                }
                Console.WriteLine("0: Back to main menu");
                choise = GetUserChoise(vehicleTypes.Length, "Select a vehicle type");
                if (choise == '0')
                    return null;
                return (Vehicle?)Activator.CreateInstance(vehicleTypes[choise - '1']);
            } while (choise != '0'); 
        }

        private char ShowMainMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1: Add Vehicle");
            Console.WriteLine("2: List Vehicles");
            Console.WriteLine("3: List Vehicle's stats");   
            Console.WriteLine("4: List Availabe errors");
            Console.WriteLine("0: Exit");
            return GetUserChoise(4, "Select an option");
        }
    }
}
