using System;
using System.IO;

namespace DesignPatterns.Flyweight
{
    class BookParser
    {
        // Допоміжний метод для визначення тегу за рядком
        private string GetTagNameForLine(int lineNumber, string line)
        {
            if (lineNumber == 0) return "h1";
            if (line.Length < 20) return "h2";
            if (line.StartsWith(" ") || line.StartsWith("\t")) return "blockquote";
            return "p";
        }

        // 1. ПАРСИНГ ВАЖКИМ МЕТОДОМ 
        public HeavyElementNode ParseFileHeavy(string filePath)
        {
            HeavyElementNode rootContainer = new HeavyElementNode("div");

            using (StreamReader file = new StreamReader(filePath))
            {
                int lineNumber = 0;
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string tagName = GetTagNameForLine(lineNumber, line);
                    
                    // Створюємо "важкий" об'єкт для кожного рядка
                    HeavyElementNode element = new HeavyElementNode(tagName);
                    //Console.WriteLine(element.OuterHtml());
                    element.AddChild(new LightTextNode(line.Trim()));
                   
                    rootContainer.AddChild(element);
                    lineNumber++;
                }
            }
            return rootContainer;
        }

        // 2. ПАРСИНГ З ЛЕГКОВАГОВИКОМ
        public FlyweightElementNode ParseFileWithFlyWeight(string filePath)
        {
            // Беремо тег "div" з фабрики
            FlyweightElementNode rootContainer = new FlyweightElementNode(TagFactory.GetTag("div"));

            using (StreamReader file = new StreamReader(filePath))
            {
                int lineNumber = 0;
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string tagName = GetTagNameForLine(lineNumber, line);

                    // Беремо спільний об'єкт тегу з фабрики замість створення нового рядка
                    TagInfo tag = TagFactory.GetTag(tagName);
              
                    //Console.WriteLine(tag.Name);
                    FlyweightElementNode element = new FlyweightElementNode(tag);
                    //Console.WriteLine(element.OuterHtml());
                    element.AddChild(new LightTextNode(line.Trim()));

                    rootContainer.AddChild(element);
                    lineNumber++;
                }
            }
            return rootContainer;
        }

        // Збереження у файл
        public void SaveHtmlToFile(LightNode rootNode, string fileName)
        {
            string finalHtml = rootNode.OuterHtml();
            File.WriteAllText(fileName + ".html", finalHtml);
            Console.WriteLine($"[Файл збережено] -> {fileName}.html");
        }
    }
}