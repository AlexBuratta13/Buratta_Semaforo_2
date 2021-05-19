using System;
using System.Threading;

namespace Buratta_Semaforo_2
{
    class Program
    {
        private static int s;
        static SemaphoreSlim s1 = new SemaphoreSlim(1);
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => Procedura1());
            Thread t2 = new Thread(() => Procedura2());
            t1.Start();
            t2.Start();
            while (t1.IsAlive) { }
            while (t2.IsAlive) { }

            Console.ReadLine();
        }

        private static void Procedura1()
        {
            Console.WriteLine("Inserisci primo numero intero");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserire primo numero intero");
            int b = int.Parse(Console.ReadLine());
            s = a + b;
            Console.WriteLine(a + ", " + b);
        }

        private static void Procedura2()
        {
            Random n = new Random();
            int c = n.Next(10, 99);
            s1.Wait();
            Console.WriteLine($"Random : {c}");
            s = s + c;
            Console.WriteLine($"Somma : {s}");
        }
    }
}
