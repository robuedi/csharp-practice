using System;

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3) => Triangle.IsTriangle(side1, side2, side3) && (side1 != side2 && side2 != side3 && side1 != side3) ? true : false;

    public static bool IsIsosceles(double side1, double side2, double side3) => Triangle.IsTriangle(side1, side2, side3) && (side1 == side2 || side1 == side3 || side2 == side3) ? true : false;

    public static bool IsEquilateral(double side1, double side2, double side3) => Triangle.IsTriangle(side1, side2, side3) && (side1 == side2 && side1 == side3) ? true : false;

    public static bool IsTriangle(double side1, double side2, double side3)
    {
        if(side1 == 0 || side2 == 0 || side3 == 0)
        {
            return false;
        }

        if(!(side1+side2 >= side3)||!(side1+side3 >= side2)||!(side3+side2 >= side1))
        {
            return false;
        }

        return true;
    }
}