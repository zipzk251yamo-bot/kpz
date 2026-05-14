using System;

namespace DesignPatterns.Memento
{
    public class DocumentMemento : IDocumentMemento
    {
        // Стан незмінний після створення
        private readonly string _state;
        private TextDocument _document;

        public Guid Id { get; } = Guid.NewGuid();
        public DateTime Date { get; } = DateTime.Now;

        public DocumentMemento(TextDocument document, string state)
        {
            _document = document;
            _state = state;
        }

        // Знімок сам знає, як відновити свій Originator
        public void Restore()
        {
            _document.SetContent(_state);
        }
    }
}