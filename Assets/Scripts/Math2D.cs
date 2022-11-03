using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = System.Random;

public static class Math2D
{
    public static long FactorialOf(int number)
    {
        long result = 1;

        for (int i = number; i > 1; i--)
        {
            result *= i;
        }

        return result;
    }
    
    public static Tuple<int, int> GetRandomTwoNumbers(int range)
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

    public static long CombinationsCount(int elementsCount, int groupLength)
    {
        if (groupLength > elementsCount) throw new Exception("Wrong length of elements.");
        return FactorialOf(elementsCount) / (FactorialOf(groupLength) * FactorialOf(elementsCount - groupLength));
    }
    
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

        if (u < 0.0f || u > 1.0f || v < 0.0f || v > 1.0f)
        {
            return false;
        }

        intersection.x = v1.x + u * (v2.x - v1.x);
        intersection.y = v1.y + u * (v2.y - v1.y);
        
        return true;
    }
    
    public static List<Tuple<int, int>> GetCombinationsOfTwo(int elementsCount)
    {
        List<Tuple<int, int>> elements = new List<Tuple<int,int>>();

        long allOptions = CombinationsCount(elementsCount, 2);
        int i = 0;
        while (i < allOptions)
        {
            Tuple<int, int> element = GetRandomTwoNumbers(elementsCount);

            if (!elements.Contains(element))
            {
                elements.Add(element);
                i++;
            }
        }
        return elements;
    }
}
