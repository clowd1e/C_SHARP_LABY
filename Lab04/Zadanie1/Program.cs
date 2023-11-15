namespace Zadanie1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>() { new Triangle { X = 0, Y = 0, Height = 4, Width = 5}, new Circle { X = 45, Y = 65, Width = 87, Height = 15 }, new Rectangle() };

            foreach(Shape shape in shapes)
            {
                shape.Draw();
            }
        }
    }
}