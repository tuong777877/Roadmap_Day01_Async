using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Demo
{
    internal class Program
    {
        static void Run(string mess, ConsoleColor color, int start,int end)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mess,10} ... Start in {start} second");
                Console.ResetColor();
            }
            for (int i = start; i <= end; i++)
            {

                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{mess,10} is running {i}");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                }

            }
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mess,10} ... Finish in {end} second");
                Console.ResetColor();
            }
        }
        static async Task Car1()
        {
            Task car1= new Task(
                () =>{
                Run("Car 1", ConsoleColor.Green,3,7);
        });
            car1.Start();
            await car1;
            Console.WriteLine("Car 1 is finished");
        }
        static async Task Car2()
        {
            Task car2 = new Task(
                () => {
                    Run("Car 2", ConsoleColor.Red,5,9);
                });
            car2.Start();
            await car2;
            Console.WriteLine("Car 2 is finished");
        }
        static async Task Car3()
        {
            Task car3 = new Task(
                (Object ob) => {
                    string car3 = (string)ob;
                    Run(car3, ConsoleColor.Cyan,1,4);
                }, "Car3");
            car3.Start();
            await car3;
            Console.WriteLine("Car 3 is finished");
        }
        static async Task Car4()
        {
            Task car4 = new Task(
                (Object ob) => {
                    string car4 = (string)ob;
                    Run("Car 4", ConsoleColor.Magenta,2,4);
                },"Car 4");
            car4.Start();
            await car4;
            Console.WriteLine("Car 4 is finished");
        }
        static async Task Main(string[] args)
        {
            Task c1 = Car1();
            Task c2 = Car2();
            Task c3 = Car3();
            Task c4 = Car4();
            //Task.WaitAll(c1,c2,c3,c4);
            await c1;
            await c2;
            await c3;
            await c4;
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
}
