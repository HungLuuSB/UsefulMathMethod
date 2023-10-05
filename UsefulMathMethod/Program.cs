using UsefulMathMethod.config;

namespace UsefulMathMethod
{
    internal class Program
    {
        static void info()
        {
            Console.WriteLine($"App name: Useful commonly used Math");
            Console.WriteLine($"App version: v1.1");
            Console.WriteLine($"Updated date: 2023-10-5");
            Console.WriteLine($"Aurthor: Luu Thai Hung");
            Console.WriteLine($"Date created: 2023-10-5");
            Console.WriteLine($"Purpose: This acts as a library for\n" +
                $"commonly used math formulas/methods");
        }
        static void product_of_n()
        {
            int product = 1;
            Console.Write("Input n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Prodct({n}) = ");
            for (int i = 1; i <= n; i++)
            {
                if (i > n - 1)
                {
                    Console.Write(i);
                }
                else
                {
                    Console.Write(i + " * ");
                }

                product *= i;
            }
            Console.WriteLine($" = {product}");
        }
        static void sum_of_n()
        {
            int sum = 0;
            Console.Write("Input n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Sum({n}) = ");
            for (int i = 0; i <= n; i++)
            {
                if (i > n - 1)
                {
                    Console.Write(i);
                }
                else
                {
                    Console.Write(i + " + ");
                }
                
                sum += i;
            }
            Console.WriteLine($" = {sum}");
        }
        static void checkPrime()
        {
            int n = 0;
            Console.Write("Input n: ");
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    Console.WriteLine($"{n} is not a prime number");
                    return;
                }
            }
            Console.WriteLine($"{n} is a prime number");
        }
        static void convert_sec_to_hh_mm_ss()
        {
            int sec;
            Console.Write("Input time(s): ");
            sec = Convert.ToInt32(Console.ReadLine());
            int hours = sec / 3600;
            int minutes = sec % 3600 / 60;
            int seconds = sec % 3600 % 60;
            Console.WriteLine($"{hours:00}:{minutes:00}:{seconds:00}");
        }
        static void quadratic_equation()
        {
            double a, b, c, delta; //ax^2 + bx + c = 0
            Console.Write("Input a: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Input b: ");
            b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Input c: ");
            c = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"{a}x^2{b}x{c}=0");
            if (a == 0)
            {
                if(b != 0)
                {
                    Console.WriteLine($"x = {-c/b}");
                }
                else
                {
                    Console.WriteLine($"Infinite");
                }
            }
            else
            {
                delta = Math.Pow(b,2) - 4 * a * c;
                Console.WriteLine($"Delta = {delta}");
                if (delta < 0)
                {
                    Console.WriteLine($"No value");
                }else if (delta > 0)
                {
                    double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    Console.WriteLine($"2 seperated values of x:\nx1 = {x1}\nx2 = {x2}");
                }
                else
                {
                    Console.WriteLine($"2 value of x:\nx1 = x2 = {(-b) / 2 * a}");

                }

            }
        }
        static void displayMenu(string name)
        {
            Console.WriteLine($"This was made by Luu Thai Hung (C) All rights reserved");
            Console.WriteLine($"Hello, {name}!\nChoose from this menu:");
            Console.WriteLine($"[{0:D2}] |App infomation");
            Console.WriteLine($"[{1:D2}] |Sum of n                -- Return S=n(1)+n(2)+...+n(n)");
            Console.WriteLine($"[{2:D2}] |Product of n            -- Return S=n(1)*n(2)*...*n(n)");
            Console.WriteLine($"[{3:D2}] |Check prime number      -- Return boolean of whether n is a prime number");
            Console.WriteLine($"[{4:D2}] |Convert sec to hh:mm:ss -- Return a formatted time string from seconds");
            Console.WriteLine($"[{5:D2}] |Quadratic equation      -- Return value(s) of a quadratic equation");
            Console.WriteLine($"[{-1:D1}]|Exit");
            Console.Write("Your choice: ");
        }
        static void Main(string[] args)
        {
            int choice;
            string name = System.Environment.UserName;
            while (true)
            {
                Console.Clear();
                displayMenu(name);
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            Console.Clear();
                            info();
                            Console.ReadLine();
                            break;
                        case -1:
                            Console.WriteLine($"Goodbye {name}! Hope to see you again!");
                            Environment.Exit(0);
                            break;
                        case 1:
                            Console.Clear();
                            sum_of_n();
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.Clear();
                            product_of_n();
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.Clear();
                            checkPrime();
                            Console.WriteLine("Press any key to navigate back to menu");
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.Clear();
                            convert_sec_to_hh_mm_ss();
                            Console.WriteLine("Press any key to navigate back to menu");
                            Console.ReadLine();
                            break;
                        case 5:
                            Console.Clear();
                            quadratic_equation();
                            Console.WriteLine("Press any key to navigate back to menu");
                            Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Invail choice\nPress any key to try again");
                            Console.ReadLine();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Only accepts integer. Press any key to try again!");
                    Console.ReadLine();
                }
            }
        }
    }
}