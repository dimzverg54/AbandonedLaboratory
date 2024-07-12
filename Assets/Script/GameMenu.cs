using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private TimeController timeController;
    [SerializeField] private ScenesController scene;
    private bool menu = false;
    private bool settings = false;
    [SerializeField] private Camera cam1;
    [SerializeField] private GameObject[] menuButtons;
    [SerializeField] private GameObject[] settingButtons;
    [SerializeField] private GameObject[] info;

    private void Start()
    {
        Cursor.visible = false;
        MenuOff();
    }
    void Update()
    {
        if ((Input.GetKeyDown("escape")) && (cam1.enabled))
        {
            if (menu)
            {
                MenuOff();
                menu = false;
                Cursor.visible = false;
            }
            else
            {
                MenuOn();
                menu = true;
                Cursor.visible = true;
            }
        }
    }

    private void MenuOn()
    {
        timeController.Pause();
        for(int i = 0; i < menuButtons.Length; i++)
        {
            menuButtons[i].SetActive(true);
        }
    }

    public void MenuOff()
    {
        timeController.Continue();
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
            settingButtons[i].SetActive(false);
        }
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
