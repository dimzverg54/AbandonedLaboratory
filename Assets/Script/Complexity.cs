using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Complexity : MonoBehaviour
{
    private int complexity = 5;
    public static Action<int> complexityChanged;

    public void Changed(int newComplexity)
    {
        complexity = newComplexity;
        complexityChanged?.Invoke(complexity);
        PlayerPrefs.SetInt("Difficulty", complexity);
        PlayerPrefs.Save();
    }
}
