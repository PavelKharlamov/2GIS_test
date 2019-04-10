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
    public class Tasks
    {
        public string Task1(string text)
        {
            string line;
            StreamReader file = new StreamReader("num.txt");
            while ((line = file.ReadLine()) != null)
            {
                 if(line.StartsWith(text))
                 {
                    return line;
                 }
            }
            file.Close();
            return line;
        }

        public bool Task2(string text)
        {
            string pattern = @"^[АВСЕНКМОРТХУавсенкмортху0-9]{1,6}";

            Regex regex = new Regex(pattern);
            Match match = regex.Match(text);

            if (match.Success)
            {
                return true;
            }

            else
            {
                throw new System.ArgumentException();
            }
        }

        public int Task3(string text)
        {
            string line;
            int counter = 0;
            StreamReader file = new StreamReader("num.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith(text))
                {
                    counter++;
                }
            }
            file.Close();
            return counter;
        }

        public bool Task4(string key)
        {
            if (key == "+")
            {
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
                return true;
            }

            else
            {
                //Environment.Exit(0);
                return false;
            }
        }

        public bool Task5(ConsoleKey key)
        {
            if (key == ConsoleKey.Escape)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
