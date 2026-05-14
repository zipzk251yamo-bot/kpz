using System;

namespace DesignPatterns.Memento
{
    public interface IDocumentMemento
    {
        Guid Id { get; }
        DateTime Date { get; }
        
        // Метод для суворої інкапсуляції (Caretaker викликає його, не знаючи деталей)
        void Restore();
    }
}