namespace converter
{
    public class Figure
    {
        public string name;
        public string width;
        public string height;

        public static List<Figure> figures = new List<Figure> { };

        public static void PrintFigure()
        {
            Console.Clear();
            Console.WriteLine("F1 - сохранить файл в одном из 3-х форматов (.txt, .json, .xml). ESC - выход.");
            Console.WriteLine("--------------------------------------------------------------------------------");
            ChangeFile.Changing();
            foreach (string s in ChangeFile.strings)
            {
                Console.WriteLine("  " + s);
            }
            ChangeFile.Cursor();
        }

    }
}
