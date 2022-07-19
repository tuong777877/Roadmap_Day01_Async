// See https://aka.ms/new-console-template for more information
namespace Demo2
{
    internal class Program
    {
        static void DoSomeThing(string mess, int seconds, ConsoleColor color, int delay, int sleep)
        {
            Task.Delay(sleep);
            for (int i = 0; i <= seconds; i++)
            {
                if (i == 0)
                {

                    Console.ForegroundColor = color;
                    Console.WriteLine($"{mess} ... ... Start");
                    Thread.Sleep(sleep);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{mess} Time : {i}");
                    Thread.Sleep(sleep);
                    Console.ResetColor();
                }

            }
            Console.ForegroundColor = color;
            Console.WriteLine($"-------{mess} is done-------");
            Console.ResetColor();
        }
        static async Task Buy()
        {
            Task buycoffee = new Task(
                () =>
                {
                    DoSomeThing("Buying Coffee", 10, ConsoleColor.Red, 0, 1000);
                });
            buycoffee.Start();
            await buycoffee;
        }
        static async Task Booking()
        {
            Task booking = new Task(
                () =>
                {
                    DoSomeThing("Booking", 4, ConsoleColor.Green, 3000, 2000);
                });
            booking.Start();
            await booking;
        }
        static void Main(string[] args)
        {
            Task buycoffee = Buy();
            Task booking = Booking();
            Task.WaitAll(buycoffee, booking);
            Console.WriteLine($"--------------");
            Console.WriteLine($"Total money is 25$");
        }

    }
}


