namespace Exercise_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vehicleHandler = new VehicleHandler();
            try
            {
                vehicleHandler.OpenForBusiness();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Vehicle handler is now closed.");
            }
        }
    }
}
