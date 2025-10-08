using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear una lista de figuras
        List<Shape> shapes = new List<Shape>();

        // Agregar un cuadrado, un rectángulo y un círculo
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle(3, "Green"));

        // Iterar sobre la lista y mostrar el color y área de cada forma
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea():0.00}\n");
        }
    }
}
