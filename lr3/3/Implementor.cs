using System;

namespace GraphicsEditor.Bridge
{
    // Інтерфейс реалізації (Implementor)
    public interface IRenderer
    {
        void Render(string shapeName);
    }

    // Конкретна реалізація: Векторна графіка
    public class VectorRenderer : IRenderer
    {
        public void Render(string shapeName)
        {
            Console.WriteLine($"Drawing {shapeName} as lines (vector graphics)");
        }
    }

    // Конкретна реалізація: Растрова графіка
    public class RasterRenderer : IRenderer
    {
        public void Render(string shapeName)
        {
            Console.WriteLine($"Drawing {shapeName} as pixels (raster graphics)");
        }
    }
}