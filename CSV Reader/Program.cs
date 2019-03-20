using System;

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

    
}
