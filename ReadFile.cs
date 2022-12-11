using Newtonsoft.Json;
using System.Xml.Serialization;

namespace converter
{
    internal class ReadFile
    {
        private static void DeserializeTXT()
        {
            string[] lines = File.ReadAllLines(path: Program.filePath);

            for (int i = 0; i < lines.Length; i += 3)
            {
                Figure figure = new Figure();
                figure.name = lines[i];
                figure.width = lines[i + 1];
                figure.height = lines[i + 2];

                Figure.figures.Add(figure);
            }
            Figure.PrintFigure();
        }

        private static void DeserializeJSON()
        {
            string json = File.ReadAllText(path: Program.filePath);
            Figure.figures = JsonConvert.DeserializeObject<List<Figure>>(json);

            Figure.PrintFigure();
        }

        private static void DeserializeXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Figure>));
            using (FileStream fs = new FileStream(path: Program.filePath, FileMode.Open))
            {
                List<Figure> readFigures = xml.Deserialize(fs) as List<Figure>;
                foreach (Figure f in readFigures)
                {
                    Figure.figures.Add(f);
                }
            }
            Figure.PrintFigure();
        }

        public static void ConverterD()
        {
            Console.WriteLine("Введите путь до файла (вместе с названием), который вы хотите открыть");
            Console.WriteLine("---------------------------------------------------------------------");
            bool nextApp = true;
            do
            {
                Program.filePath = Console.ReadLine();
                if (Program.filePath.Contains(".txt"))
                {
                    DeserializeTXT();

                }
                else if (Program.filePath.Contains(".json"))
                {
                    DeserializeJSON();
                }
                else if (Program.filePath.Contains(".xml"))
                {
                    DeserializeXML();
                }
                else
                {
                    Console.WriteLine("Можно открыть: '.txt', '.json' и '.xml'!!! Повторите ввод пути до файла (вместе с названием): \n");
                    nextApp = false;
                }
            } while (nextApp != true);
        }
    }
}
