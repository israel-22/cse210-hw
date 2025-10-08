using System;
using System.Collections.Generic;

public class Circle : Shape
{
    private double _radius;

    // Constructor
    public Circle(double radius, string color) : base(color)
    { _radius = radius; }

    // override method GetArea
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }

 }