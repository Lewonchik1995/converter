using Newtonsoft.Json;
using System.Diagnostics;
using System.Xml.Serialization;

namespace converter
{
    internal class WriteFile
    {
        private static void SerializeTXT()
        {
            File.Create(Program.filePath).Close();
            foreach (Figure f in Figure.figures)
            {
                File.AppendAllText(path: Program.filePath, f.name + "\n");
                File.AppendAllText(path: Program.filePath, f.width + "\n");
                File.AppendAllText(path: Program.filePath, f.height + "\n");
            }
        }

        private static void SerializeJSON()
        {
            string json = JsonConvert.SerializeObject(Figure.figures);
            File.WriteAllText(path: Program.filePath, json);
        }

        private static void SerializeXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Figure>));
            using (FileStream fs = new FileStream(path: Program.filePath, FileMode.Create))
            {
                xml.Serialize(fs, Figure.figures);
            }
        }
        public static void ConverterS()
        {
            Console.WriteLine("Введите путь до файла (вместе с названием), куда вы хотите сохранить текст: ");
            Console.WriteLine("---------------------------------------------------------------------");
            bool nextApp = true;
            do
            {
                Program.filePath = Console.ReadLine();
                if (Program.filePath.Contains(".txt"))
                {
                    SerializeTXT();
                }
                else if (Program.filePath.Contains(".json"))
                {
                    SerializeJSON();
                }
                else if (Program.filePath.Contains(".xml"))
                {
                    SerializeXML();
                }
                else
                {
                    Console.WriteLine("Ошибка!!! Можно конвертировать в: '.txt', '.json' и '.xml'. Повторите ввод: \n");
                    nextApp = false;
                }
            } while (nextApp != true);
            Console.WriteLine("Файл: " + Program.filePath + " - успешно сохранен!");
            Thread.Sleep(2000);
            Continue();
        }

        private static void Continue()
        {
            Console.Clear();
            Console.WriteLine("Конвертировать еще файл? \n" +
                "ESC - НЕТ, Enter - ДА");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape) 
            {
                Console.WriteLine("Спасибо что воспользовались конвертером!");
                Process.GetCurrentProcess().Kill();
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                ReadFile.ConverterD();
            }
            else
            {
                Console.WriteLine("Сделайте ваш выбор!");
                Thread.Sleep(1000);
                Continue();
            }

        }
    }
}
