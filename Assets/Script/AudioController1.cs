using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController1 : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] float startVolume;

    private float volume = 0.5f;

    private void OnEnable()
    {
        VolumeController.volumeChanged += VolumeChanged;
        if (PlayerPrefs.HasKey("Volume"))
        {
            volume = PlayerPrefs.GetFloat("Volume");
            VolumeChanged(volume);
        }
    }

    private void OnDisable()
    {
        VolumeController.volumeChanged -= VolumeChanged;
    }

    private void VolumeChanged(float newVolume)
    {
        volume = newVolume;
        audioSource.volume = volume * startVolume;
    }
}
