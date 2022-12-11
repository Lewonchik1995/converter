namespace converter
{
    internal class ChangeFile
    {
        static int position = 2;
        public static List<string> strings = new List<string>();
        public static void Cursor()
        {
            position = 2;
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("  ");
                    position = Fix(position - 1);
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("->");
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("  ");
                    position = Fix(position + 1);
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("->");
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    string newString = Console.ReadLine();
                    strings[position - 2] = newString;
                    Saving();
                    Console.Clear();
                    Figure.PrintFigure();
                }
                else if (key.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    WriteFile.ConverterS();
                }
                else if (key.Key == ConsoleKey.Escape)
                {

                }
            }
        }

        private static int Fix(int position)
        {
            if (position < 2)
            {
                position = 10;
            }
            else if (position > 10)
            {
                position = 2;
            }
            return position;
        }

        public static void Changing()
        {
            strings.Clear();
            foreach (Figure f in Figure.figures)
            {
                strings.Add(f.name);
                strings.Add(f.width);
                strings.Add(f.height);
            }
        }

        private static void Saving()
        {
            Figure.figures.Clear();
            for (int i = 0; i < strings.Count; i += 3)
            {
                Figure figure = new Figure();
                figure.name = strings[i];
                figure.width = strings[i + 1];
                figure.height = strings[i + 2];

                Figure.figures.Add(figure);
            }
        }
    }
}
