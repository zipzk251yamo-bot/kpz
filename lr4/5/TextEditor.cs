using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Memento
{
    public class TextEditor
    {
        private List<IDocumentMemento> _history = new List<IDocumentMemento>();

        // Збереження поточного стану
        public void Backup(IDocumentMemento snapshot)
        {
            _history.Add(snapshot);
            Console.WriteLine($"[Редактор]: Стан збережено. (ID: {snapshot.Id.ToString().Substring(0, 8)}...)");
        }

        // Скасування останньої зміни (Undo)
        public void Undo()
        {
            if (_history.Count == 0)
            {
                Console.WriteLine("[Редактор]: Історія порожня, немає що скасовувати.");
                return;
            }

            var snapshot = _history.Last();
            Console.WriteLine($"\n[Редактор]: Скасування до знімка від {snapshot.Date:HH:mm:ss}");
            
            // Відновлюємо стан і видаляємо знімок з історії
            snapshot.Restore();
            _history.Remove(snapshot);
        }

        public void ShowHistory()
        {
            Console.WriteLine("\n--- Історія збережень ---");
            foreach (var snapshot in _history)
            {
                Console.WriteLine($"- Знімок {snapshot.Id.ToString().Substring(0, 8)}... ({snapshot.Date:HH:mm:ss})");
            }
            Console.WriteLine("-------------------------\n");
        }
    }
}