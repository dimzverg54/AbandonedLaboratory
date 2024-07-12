using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float volume;

    public static Action<float> volumeChanged;

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            volume = PlayerPrefs.GetFloat("Volume");
            slider.value = volume;
        }
    }

    public void Changed()
    {
        volume = slider.value;
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
        volumeChanged?.Invoke(volume);
    }

}
