using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private void Start()
    {
        Continue();
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        Time.timeScale = 1f;
    }
}
