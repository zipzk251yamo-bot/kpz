using System;

namespace DesignPatterns.Memento
{
    public class TextDocument
    {
        private string _content;

        public TextDocument(string initialContent = "")
        {
            _content = initialContent;
        }

        public void AddText(string text)
        {
            _content += text;
        }

        public void Print()
        {
            Console.WriteLine($"[Вміст документа]: {_content}");
        }

        // Створення знімка (Memento)
        public IDocumentMemento Save()
        {
            return new DocumentMemento(this, _content);
        }

        // Внутрішній метод для відновлення, який викликається самим знімком
        public void SetContent(string content)
        {
            _content = content;
        }
    }
}