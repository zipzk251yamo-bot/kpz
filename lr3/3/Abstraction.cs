namespace GraphicsEditor.Bridge
{
    // Абстракція
    public abstract class Shape
    {
        protected IRenderer _renderer;

        // Міст між абстракцією (Shape) та реалізацією (IRenderer)
        public Shape(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public abstract void Draw();
    }

    // Розширена абстракція: Коло
    public class Circle : Shape
    {
        public Circle(IRenderer renderer) : base(renderer) { }

        public override void Draw()
        {
            _renderer.Render("Circle");
        }
    }

    // Розширена абстракція: Квадрат
    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer) { }

        public override void Draw()
        {
            _renderer.Render("Square");
        }
    }

    // Розширена абстракція: Трикутник
    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer) { }

        public override void Draw()
        {
            _renderer.Render("Triangle");
        }
    }
}