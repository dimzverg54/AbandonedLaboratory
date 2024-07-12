using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] menuButtons;
    [SerializeField] private GameObject[] settingButtons;
    [SerializeField] private GameObject[] info;

    private void Start()
    {
        Cursor.visible = true;
        SettingsOff();
    }
    public void SettingsOn()
    {
        for (int i = 0; i < menuButtons.Length; i++)
        {
            menuButtons[i].SetActive(false);
        }
        for (int i = 0; i < info.Length; i++)
        {
            info[i].SetActive(false);
        }
        for (int i = 0; i < settingButtons.Length; i++)
        {
            settingButtons[i].SetActive(true);
        }
    }

    public void SettingsOff()
    {
        for (int i = 0; i < settingButtons.Length; i++)
        {
            settingButtons[i].SetActive(false);
        }
        for (int i = 0; i < info.Length; i++)
        {
            info[i].SetActive(false);
        }
        for (int i = 0; i < menuButtons.Length; i++)
        {
            menuButtons[i].SetActive(true);
        }
    }

    public void InfoOn()
    {
        for (int i = 0; i < settingButtons.Length; i++)
        {
            settingButtons[i].SetActive(false);
        }
        for (int i = 0; i < menuButtons.Length; i++)
        {
            menuButtons[i].SetActive(false);
        }
        for (int i = 0; i < info.Length; i++)
        {
            info[i].SetActive(true);
        }
    }

    public void InfoOff()
    {
        for (int i = 0; i < settingButtons.Length; i++)
        {
            settingButtons[i].SetActive(false);
        }
        for (int i = 0; i < info.Length; i++)
        {
            info[i].SetActive(false);
        }
        for (int i = 0; i < menuButtons.Length; i++)
        {
            menuButtons[i].SetActive(true);
        }
    }


}
