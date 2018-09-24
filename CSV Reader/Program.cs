using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.SetWindowSize(100, 25);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Path to file: ");
                string path = Console.ReadLine();
                CSVFile file = new CSVFile(path);
                file.Display(1);
                bool isOpenFile = true;
                do
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            file.PreviousLine();
                            break;
                        case ConsoleKey.DownArrow:
                            file.NextLine();
                            break;
                        case ConsoleKey.PageUp:
                            file.PreviousPage();
                            break;
                        case ConsoleKey.PageDown:
                            file.NextPage();
                            break;
                        case ConsoleKey.Escape:
                            isOpenFile = false;
                            break;
                    }
                } while (isOpenFile);
            } while (true);
        }
    }

    class CSVFile
    {
        int currentStartPosition = 1;
        int countRowsConsole = 23;

        List<string> lines = new List<string>();
       
        public CSVFile(string pathFile)
        {
            using (StreamReader fileStream = new StreamReader(pathFile))
            {
                string line = fileStream.ReadLine();
                while (line != null)
                {
                    lines.Add(line);
                    line = fileStream.ReadLine();
                }
            }
        }

        public void Display(int startPosition)
        {
            if (startPosition < 1)
            {
                startPosition = 1;
                currentStartPosition = startPosition;
            }
            else if (startPosition + countRowsConsole > lines.Count)
            {
                startPosition = lines.Count;
                currentStartPosition = startPosition;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < lines[0].Split(',').Length; i++)
            {
                if (i == 2)
                    Console.Write(lines[0].Split(',')[i] + "\t\t\t");
                else
                    Console.Write(lines[0].Split(',')[i] + "\t");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            for (int i = startPosition; i < startPosition + countRowsConsole; i++)
            {
                foreach (string s in lines[i].Split(','))
                    Console.Write(s + "\t");
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[↑] - Prev line [↓] - Next line [Page Up] - Prev page [Page Down] - Next page");
        }

        public void NextLine()
        {
            Display(++currentStartPosition);
        }

        public void PreviousLine()
        {
            Display(--currentStartPosition);
        }

        public void NextPage()
        {
            Display(currentStartPosition += countRowsConsole);
        }

        public void PreviousPage()
        {
            Display(currentStartPosition -= countRowsConsole);
        }
    }
}
