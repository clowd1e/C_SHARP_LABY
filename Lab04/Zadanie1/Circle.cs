using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Circle : Shape
    {
        public override void Draw() { Console.WriteLine($"Drawing a circle: x = {X}, y = {Y}, width = {Width}, height = {Height}"); }
    }
}
