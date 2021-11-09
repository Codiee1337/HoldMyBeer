using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp2
{
    
    internal class Program
    {
        private static System.Timers.Timer aTimer;
        static void Main(string[] args)
        {

            Console.WriteLine("Mennyi kép kő?");
            int count = int.Parse(Console.ReadLine());
            Console.WriteLine("Vájjá csinálom!");
            var start = DateTime.Now;
            ImageGenerator.GenerateXNumberOfRandomImage(count);
            Console.WriteLine("KÉSZ!");
            var end = DateTime.Now.Subtract(start).TotalSeconds;
            Console.WriteLine(end);
            
           
            Console.WriteLine("Press a button to exit the program!");
            Console.ReadKey();
            

        }

        
    }
}

