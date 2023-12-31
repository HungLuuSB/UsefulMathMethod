﻿using System;
using StackExchange.Redis;
using System.Diagnostics;
using System.Data.SqlTypes;
using static System.Net.WebRequestMethods;
using MySql.Data.MySqlClient;

namespace UsefulMathMethod
{
    internal class Program
    {
        static readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis-15499.c299.asia-northeast1-1.gce.cloud.redislabs.com:15499,password=jgrA7tDZBR9QHTnXEe6H6S3UfnNpszQM");
        static string _username;
        public static bool checkUser(string username, string password)
        {
            var db = redis.GetDatabase();
            const string key = "User";
            if (db.HashGet(key, "hungluu12") == password)
            {
                _username = username;
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int lineLength = 100;
        static void drawLine(int Length)
        {
            for (int i = 0; i < Length; i++)
            {
                if (i == 5 || i == 31)
                {
                    Console.Write("|");
                }
                else
                {
                    Console.Write("-");
                }
            }
            Console.WriteLine();
        }
        static void drawResultLine(int Length)
        {
            for (int i = 0; i < Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
        static bool checkTriangle(double a, double b, double c)
        {
            if (a + b > c && b + c > a && a + c > b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void info()
        {
            Console.WriteLine($"App name: Useful commonly used Math");
            Console.WriteLine($"App version: v1.3.1");
            Console.WriteLine($"Updated date: 2023-10-6");
            Console.WriteLine($"Aurthor: Luu Thai Hung");
            Console.WriteLine($"Date created: 2023-10-5");
            Console.WriteLine($"Purpose: This acts as a library for\n" +
                $"commonly used math formulas/methods\n"+
                $"Every aglorithms are hand-written");
        }//0
        public static void product_of_n()
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
        }//1
        public static void sum_of_n()
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
        }//2
        public static void checkPrime()
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
        }//3
        public static void convert_sec_to_hh_mm_ss()
        {
            int sec;
            Console.Write("Input time(s): ");
            sec = Convert.ToInt32(Console.ReadLine());
            int hours = sec / 3600;
            int minutes = sec % 3600 / 60;
            int seconds = sec % 3600 % 60;
            Console.WriteLine($"{hours:00}:{minutes:00}:{seconds:00}");
        }//4
        public static void quadratic_equation()
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
        }//5
        public static void convert_10_to_2()
        {
            Console.Write("Input n(10): ");
            int n = Convert.ToInt32(Console.ReadLine());
            int old_n = n;
            string result = "";
            while (n >= 1)
            {
                int digit = n % 2;
                result = result + Convert.ToString(digit);
                n = n/2;
            }
            Console.Write($"{old_n}(1) = ");
            for (int i = result.Length-1; i >= 0; i--)
            {
                Console.Write(result[i]);
            }
            Console.WriteLine($"(2)");
        }//6
        public static void convert_2_to_10()
        {
            double sum;
            sum = 0;
            Console.Write("Input n(2): ");
            string n = Console.ReadLine();
            int length = n.Length - 1;
            for (int i = 0; i < n.Length; i++)
            {
                double kq = Char.GetNumericValue(n[i]) * Math.Pow(2,length);
                length -= 1;
                sum += kq;
            }
            Console.WriteLine($"{n}(2) = {sum}(10)");
        }//7
        public static void circle()
        {
            double r, p, a;
            Console.Write("Input r(m) : ");
            r = Convert.ToDouble(Console.ReadLine());
            p = 2*Math.PI*r;
            a = Math.PI*Math.Pow(r,2);
            Console.WriteLine($"{"Perimater".PadRight(10)} = {Math.Round(p,2)}");
            Console.WriteLine($"{"Area".PadRight(10)} = {Math.Round(a, 2)}");
        }//8
        public static void square()
        {
            double a,perimeter,area;
            Console.Write("Input a(m) : ");
            a = Convert.ToDouble(Console.ReadLine());
            perimeter = 4 * a;
            area = Math.Pow(a,2);
            Console.WriteLine($"{"Perimater".PadRight(10)} = {Math.Round(perimeter, 2)}");
            Console.WriteLine($"{"Area".PadRight(10)} = {Math.Round(area, 2)}");
        }//9
        public static void triangle()
        {
            double a, b, c;
            Console.Write("Input a: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Input b: ");
            b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Input c: ");
            c = Convert.ToDouble(Console.ReadLine());

            if (checkTriangle(a, b, c) == true)
            {
                Console.WriteLine($"Can make a triangle out of three values determined :{a},{b},{c}");
            } else
            {
                Console.WriteLine($"Can not make a triangle out of three values determined :{a},{b},{c}");
            }
        }//10
        static void displayMenu(int index_page, int max_page, string name)
        {
            Console.WriteLine($"This was made by Luu Thai Hung (C) All rights reserved");
            Console.WriteLine($"Hello, {name}!\nChoose from this menu:");
            Console.WriteLine($"Type +/- to change page");
            Console.WriteLine($"{index_page}/{max_page}");
            switch (index_page){
                case 1:
                    Console.WriteLine($"{"No".PadRight(5)}|{"Method's name".PadRight(25)}|{"Method's description"}");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[0]".PadRight(5)}|{"App infomation".PadRight(25)}|Retrieve app's infomation");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[1]".PadRight(5)}|{"Sum of n".PadRight(25)}|Return S=n(1)+n(2)+...+n(n)");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[2]".PadRight(5)}|{"Product of n".PadRight(25)}|Return S=n(1)*n(2)*...*n(n)");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[3]".PadRight(5)}|{"Check prime number".PadRight(25)}|Return boolean of whether n is a prime number");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[4]".PadRight(5)}|{"Convert sec(s) to time".PadRight(25)}|Return a formatted time string from seconds");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[5]".PadRight(5)}|{"Quadratic equation".PadRight(25)}|Return value(s) of a quadratic equation");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[6]".PadRight(5)}|{"Base(10) to base(2)".PadRight(25)}|Return a convertted number in base(10) to base(2)");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[7]".PadRight(5)}|{"Base(2) to base(10)".PadRight(25)}|Return a convertted number in base(2) to base(10)");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[8]".PadRight(5)}|{"Circle".PadRight(25)}|Return perimeter, area of a circle");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[9]".PadRight(5)}|{"Square".PadRight(25)}|Return perimeter, area of a square");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[x]".PadRight(5)}|{"Exit".PadRight(25)}|Close the application");
                    drawLine(lineLength);
                    break;
                case 2:
                    Console.WriteLine($"{"No".PadRight(5)}|{"Method's name".PadRight(25)}|{"Method's description"}");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[10]".PadRight(5)}|{"Check triangle".PadRight(25)}|Check if you can make a triangle from 3 values");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[11]".PadRight(5)}|{"".PadRight(25)}|");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[12]".PadRight(5)}|{"".PadRight(25)}|");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[13]".PadRight(5)}|{"".PadRight(25)}|");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[14]".PadRight(5)}|{"".PadRight(25)}|");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[15]".PadRight(5)}|{"".PadRight(25)}|");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[16]".PadRight(5)}|{"".PadRight(25)}|");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[17]".PadRight(5)}|{"".PadRight(25)}|");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[18]".PadRight(5)}|{"".PadRight(25)}|");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[19]".PadRight(5)}|{"".PadRight(25)}|");
                    drawLine(lineLength);
                    Console.WriteLine($"{"[x]".PadRight(5)}|{"Exit".PadRight(25)}|Close the application");
                    break;
                default:
                    Console.Clear();
                    displayMenu(1, max_page,name);
                    break;
            }
            
            
        }
        static void displayLogin()
        {
            Console.WriteLine("Login in");
            Console.Write("[Username]: ");
            string username = Console.ReadLine();
            Console.Write("[Password]: ");
            string password = Console.ReadLine();
            
            if (checkUser(username, password) != true)
            {
                Console.WriteLine("Wrong username/password");
                Console.ReadLine();
                displayLogin();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Connecting to server...");
            try
            {
                Console.Clear();
                displayLogin();
                string choice;
                string name = _username;
                int index_page = 1;
                int max_page = 2;
                while (true)
                {
                    if (index_page < max_page)
                    {
                        index_page = 1;
                    }
                    else
                    {
                        index_page = max_page;
                    }
                    Console.Clear();
                    displayMenu(index_page, max_page, name);
                    Console.Write("Your choice: ");
                    try
                    {
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "+":
                                index_page++;
                                break;
                            case "-":
                                index_page--;
                                break;
                            case "ytb":
                                Console.Clear();
                                Console.WriteLine("Directing to youtube.com");
                                var psi = new ProcessStartInfo("chrome.exe");
                                psi.Arguments = "www.google.com";
                                Process.Start(psi);
                                Console.WriteLine("Press any key to navigate back to menu");
                                Console.ReadLine();
                                break;
                            case "0":
                                Console.Clear();
                                info();
                                drawResultLine(lineLength);
                                Console.WriteLine("Press any key to navigate back to menu");
                                Console.ReadLine();
                                break;
                            case "x":
                                Console.WriteLine($"Goodbye {name}! Hope to see you again!");
                                Environment.Exit(0);
                                break;
                            case "1":
                                Console.Clear();
                                sum_of_n();
                                drawResultLine(lineLength);
                                Console.ReadLine();
                                break;
                            case "2":
                                Console.Clear();
                                product_of_n();
                                drawResultLine(lineLength);
                                Console.ReadLine();
                                break;
                            case "3":
                                Console.Clear();
                                checkPrime();
                                drawResultLine(lineLength);
                                Console.WriteLine("Press any key to navigate back to menu");
                                Console.ReadLine();
                                break;
                            case "4":
                                Console.Clear();
                                convert_sec_to_hh_mm_ss();
                                drawResultLine(lineLength);
                                Console.WriteLine("Press any key to navigate back to menu");
                                Console.ReadLine();
                                break;
                            case "5":
                                Console.Clear();
                                quadratic_equation();
                                drawResultLine(lineLength);
                                Console.WriteLine("Press any key to navigate back to menu");
                                Console.ReadLine();
                                break;
                            case "6":
                                Console.Clear();
                                convert_10_to_2();
                                drawResultLine(lineLength);
                                Console.WriteLine("Press any key to navigate back to menu");
                                Console.ReadLine();
                                break;
                            case "7":
                                Console.Clear();
                                convert_2_to_10();
                                drawResultLine(lineLength);
                                Console.WriteLine("Press any key to navigate back to menu");
                                Console.ReadLine();
                                break;
                            case "8":
                                Console.Clear();
                                circle();
                                drawResultLine(lineLength);
                                Console.WriteLine("Press any key to navigate back to menu");
                                Console.ReadLine();
                                break;
                            case "9":
                                Console.Clear();
                                square();
                                drawResultLine(lineLength);
                                Console.WriteLine("Press any key to navigate back to menu");
                                Console.ReadLine();
                                break;
                            case "10":
                                Console.Clear();
                                triangle();
                                drawResultLine(lineLength);
                                Console.WriteLine("Press any key to navigate back to menu");
                                Console.ReadLine();
                                break;
                            default:
                                Console.WriteLine("Invail choice!P ress any key to try again");
                                Console.ReadLine();
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        drawResultLine(lineLength);
                        Console.WriteLine("Error! Press any key to try again!");
                        Console.ReadLine();
                    }
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Couldn't establish connection");
                Console.ReadLine();
                Environment.Exit(0);
            }
            
        }
    }
}