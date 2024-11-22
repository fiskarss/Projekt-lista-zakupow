public class Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Count { get; set; }
    public double Price { get; set; }
}


namespace System.Linq
{

}

namespace GFG
{

    class Program
    {

        static void Main(string[] args)
        {

            // Display current Foreground color 
            Console.WriteLine("Default Foreground Color: {0}",
                                     Console.ForegroundColor);

            // Set the Foreground color to blue 
            Console.ForegroundColor
                = ConsoleColor.Blue;

            // Display current Foreground color 
            Console.WriteLine("Changed Foreground Color: {0}",
                                    Console.ForegroundColor);
        }
    }
}
