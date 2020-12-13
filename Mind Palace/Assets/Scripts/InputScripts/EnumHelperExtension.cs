using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnumHelperExtension 
{
    //Helper function taken from StackOverflow but I edited it to fit my needs.
    public static T Move<T>(this T src, int step) where T : struct {
        if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

        T[] Arr = (T[])Enum.GetValues(src.GetType());
        int j = Array.IndexOf<T>(Arr, src) + step;
        if (j < 0) j = Arr.Length + j;

        return (Arr.Length == j) ? Arr[0] : Arr[j];
    }
}
