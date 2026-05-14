using System;

namespace GraphicsEditor.Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створюємо "двигунці" для рендерингу
            IRenderer vectorRenderer = new VectorRenderer();
            IRenderer rasterRenderer = new RasterRenderer();

            Console.WriteLine("=== Векторний рендеринг ===");
            Shape vectorCircle = new Circle(vectorRenderer);
            Shape vectorSquare = new Square(vectorRenderer);
            Shape vectorTriangle = new Triangle(vectorRenderer);

            vectorCircle.Draw();
            vectorSquare.Draw();
            vectorTriangle.Draw();

            Console.WriteLine("\n=== Растровий рендеринг ===");
            Shape rasterCircle = new Circle(rasterRenderer);
            Shape rasterSquare = new Square(rasterRenderer);
            Shape rasterTriangle = new Triangle(rasterRenderer);

            rasterCircle.Draw();
            rasterSquare.Draw();
            rasterTriangle.Draw();

            Console.ReadKey();
        }
    }
}