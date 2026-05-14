using System;
using System.Collections.Generic;
using System.Text;

namespace LightHTML
{
    // 2. Кожен елемент розмітки має наслідувати абстрактний клас LightNode
    public abstract class LightNode
    {
        // Базові методи для всіх вузлів
        public abstract string InnerHtml();
        public abstract string OuterHtml();
    }

    // 3. Дочірній клас LightTextNode
    // 4. Може містити лише текст
    public class LightTextNode : LightNode
    {
        private string _text;

        public LightTextNode(string text)
        {
            _text = text;
        }

        public override string InnerHtml() => _text;
        public override string OuterHtml() => _text;
    }

    // 3. Дочірній клас LightElementNode
    // 5. Містить дочірні елементи, назву тега, тип відображення, тип закриття, CSS класи, кількість елементів
    public class LightElementNode : LightNode
    {
        public string TagName { get; set; }
        public bool IsBlock { get; set; }
        public bool IsSelfClosing { get; set; }
        public List<string> CssClasses { get; set; }

        // Список дочірніх елементів типу LightNode
        private List<LightNode> _children;

        // Властивість для кількості дочірніх елементів
        public int ChildCount => _children.Count;

        public LightElementNode(string tagName, bool isBlock = true, bool isSelfClosing = false)
        {
            TagName = tagName;
            IsBlock = isBlock;
            IsSelfClosing = isSelfClosing;
            CssClasses = new List<string>();
            _children = new List<LightNode>();
        }

        public void AddChild(LightNode node)
        {
            _children.Add(node);
        }

        public void AddCssClass(string className)
        {
            CssClasses.Add(className);
        }

        // 5. Вивід InnerHtml (вміст всередині тегу)
        public override string InnerHtml()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var child in _children)
            {
                sb.Append(child.OuterHtml());
            }
            return sb.ToString();
        }

        // 5. Вивід OuterHtml (сам тег + його вміст)
        public override string OuterHtml()
        {
            StringBuilder sb = new StringBuilder();

            // Відкриваючий тег
            sb.Append($"<{TagName}");

            // Додаємо CSS класи, якщо вони є
            if (CssClasses.Count > 0)
            {
                sb.Append($" class=\"{string.Join(" ", CssClasses)}\"");
            }

            // Якщо тег одиничний (наприклад <img /> або <br />)
            if (IsSelfClosing)
            {
                sb.Append(" />");
                return sb.ToString();
            }

            // Якщо тег парний
            sb.Append(">");
            sb.Append(InnerHtml());
            sb.Append($"</{TagName}>");

            return sb.ToString();
        }
        public void SaveHtmlToFile( string fileName)
        {
            string finalHtml = this.OuterHtml();
            File.WriteAllText(fileName + ".html", finalHtml);
            Console.WriteLine($"[Файл збережено] -> {fileName}.html");
        }
    }


}