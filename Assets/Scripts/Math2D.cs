using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

/// <summary>
/// A class that contains static methods for mathematical calculations.
/// </summary>
public static class Math2D
{
    /// <summary>
    /// It takes a number, and returns the factorial of that number
    /// </summary>
    /// <param name="number">The number to calculate the factorial of.</param>
    /// <returns>
    /// The factorial of the number.
    /// </returns>
    public static long FactorialOf(int number)
    {
        long result = 1;

        for (int i = number; i > 1; i--)
        {
            result *= i;
        }

        return result;
    }
    
    /// <summary>
    /// It generates two random numbers between 0 and the range, and returns them as a tuple
    /// </summary>
    /// <param name="range">The range of numbers to choose from.</param>
    /// <returns>
    /// A tuple of two random numbers.
    /// </returns>
    private static Tuple<int, int> GetRandomTwoNumbers(int range)
    {
        Random random = new Random();
        int firstNumber = random.Next(0, range);
        int secondNumber = firstNumber;
        while (firstNumber == secondNumber)
        {
            secondNumber = random.Next(0, range);
        }

        return new Tuple<int, int>(firstNumber, secondNumber);
    }

    /// <summary>
    /// The number of combinations of n elements, taken k at a time, is n! / (k! * (n - k)!)
    /// </summary>
    /// <param name="elementsCount">The number of elements in the set.</param>
    /// <param name="groupLength">The length of the group of elements you want to find the combinations of.</param>
    /// <returns>
    /// The number of combinations of elementsCount elements, taken groupLength at a time.
    /// </returns>
    private static long CombinationsCount(int elementsCount, int groupLength)
    {
        if (groupLength > elementsCount) throw new Exception("Wrong length of elements.");
        return FactorialOf(elementsCount) / (FactorialOf(groupLength) * FactorialOf(elementsCount - groupLength));
    }

    /// <summary>
    /// If the lines intersect, return true and the intersection point. Otherwise, return false
    /// </summary>
    /// <param name="v1">First vector of first line.</param>
    /// <param name="v2">Second vector of first line.</param>
    /// <param name="v3">First vector of second line.</param>
    /// <param name="v4">Second vector of second line.</param>
    /// <param name="intersection">Saves the point of intersection.</param>
    /// <returns>
    /// A boolean value.
    /// </returns>
    public static bool IsLineIntersecting(Vector2 v1, Vector2 v2, Vector2 v3, Vector2 v4, out Vector2 intersection)
    {
        intersection = Vector2.zero;
        
        float d = (v2.x - v1.x) * (v4.y - v3.y) - (v2.y - v1.y) * (v4.x - v3.x);
    
        if (d == 0.0f)
        {
            return false;
        }
    
        float u = ((v3.x - v1.x) * (v4.y - v3.y) - (v3.y - v1.y) * (v4.x - v3.x)) / d;
        float v = ((v3.x - v1.x) * (v2.y - v1.y) - (v3.y - v1.y) * (v2.x - v1.x)) / d;
    
        if (u < 0.01f || u > 0.99f || v < 0.01f || v > 0.99f)
        {
            return false;
        }
    
        intersection.x = v1.x + u * (v2.x - v1.x);
        intersection.y = v1.y + u * (v2.y - v1.y);
        
        return true;
    }

    /// <summary>
    /// It generates a list of all possible combinations of two numbers from 1 to `elementsCount` without repeating the same
    /// combination twice
    /// </summary>
    /// <param name="elementsCount">The number of elements in the set.</param>
    /// <returns>
    /// A list of tuples of two numbers.
    /// </returns>
    public static List<Tuple<int, int>> GetCombinationsOfTwo(int elementsCount)
    {
        List<Tuple<int, int>> elements = new List<Tuple<int,int>>();

        long allOptions = CombinationsCount(elementsCount, 2);
        int i = 0;
        while (i < allOptions)
        {
            Tuple<int, int> element = GetRandomTwoNumbers(elementsCount);
            Tuple<int, int> reverseElement = Tuple.Create(element.Item2, element.Item1);
            
            if (!elements.Contains(element) && !elements.Contains(reverseElement))
            {
                elements.Add(element);
                i++;
            }
        }
        return elements;
    }
}
