using System;
using System.Collections.Generic;
public abstract class Shape
{
    private string _color;

    //Constructor
    public Shape(string color)
    { _color = color; }



    // Getter and Setter for color
    public string GetColor()
    { return _color; }


    public void SetColor(string color)
    { _color = color; }

    // Abstract method to calculate area
    public abstract double GetArea();
}