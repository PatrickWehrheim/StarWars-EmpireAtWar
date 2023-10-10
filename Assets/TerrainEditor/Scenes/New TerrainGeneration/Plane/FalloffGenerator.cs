using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FalloffGenerator
{
    public static float[,] GenerateFalloffMap(int size)
    {
        float[,] falloffMap = new float[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                float x = (float)i / size * 2 - 1;
                float y = (float)j / size * 2 - 1;
                float value = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));
                falloffMap[i, j] = Evaluate(value);
            }
        }

        return falloffMap;
    }

    private static float Evaluate(float value)
    {
        float a = 3f;
        float b = 2.25f; // Erh�hen f�r dichter am Rand enden
        return Mathf.Pow(value, a) / (Mathf.Pow(value, a) + Mathf.Pow(b - b * value, a));
    }
}
