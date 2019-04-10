using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CarNumber
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // жёлтый цвет
            Console.WriteLine("Поиск автомобильных номеров");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green; // зелёный цвет
            Console.WriteLine("Введите автомобильный номер (1-6 символов):");

            string text = Console.ReadLine(); // считывание входящей строки от пользователя
            int counter = 0; // счётчик совпадений
            string line; // шаблон для поиска
            string answer; // переключатель (заново/выход)

            string pattern = @"^[АВСЕНКМОРТХУавсенкмортху0-9]{1,6}";

            Regex regex = new Regex(pattern);
            Match match = regex.Match(text);

            if (match.Success)
            {
                try
                {
                    // считывание строк в текстовом файле
                    StreamReader file = new StreamReader("num.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        // если есть совпадения со строкой пользователя, то выводим совпадающие строки и увеличиваем счётчик
                        if (line.StartsWith(text))
                        {
                            Console.WriteLine(line);
                            counter++;
                        }
                    }
                    file.Close(); // завершаем процедуру считывания строк
                }
                catch { }

                Console.WriteLine("Найдено совпадений: {0}", counter); // выводим количество совпадений
                Console.WriteLine();
                Console.WriteLine("Хотите повторить процедуру поиска? (+/-)");

                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }

                // либо выход по (+/-)
                answer = Console.ReadLine();

                try
                {
                    // если "+", то рестарт. "-" выход
                    if (answer == "+")
                    {
                        Process.Start(Assembly.GetExecutingAssembly().Location);
                        Environment.Exit(0);
                    }

                    if (answer == "-")
                    {
                        Environment.Exit(0);
                    }
                }
                catch { }
            }

            else
            {
                //throw new System.ArgumentException();
                Console.WriteLine("Ошибка");
                Console.WriteLine("Попробовать ещё раз? (+/-)");

                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }

                answer = Console.ReadLine();

                try
                {                  
                    if (answer == "+")
                    {
                        Process.Start(Assembly.GetExecutingAssembly().Location);
                        Environment.Exit(0);
                    }

                    if (answer == "-")
                    {
                        Environment.Exit(0);
                    }
                }
                catch { }
            }
        }
    }
}
