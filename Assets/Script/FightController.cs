using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FightController : MonoBehaviour
{
    // public static event Action FightMessage;
    [SerializeField] private Camera cam1;
    [SerializeField] private Camera cam2;
    [SerializeField] private Camera cam3;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private GameObject music;
    [SerializeField] private GameObject fightMusic;
    [SerializeField] private GameObject FightCanvas;
    [SerializeField] private Dialog dialog;
    [SerializeField] private Player player;
    [SerializeField] private GameObject enemyDialog;

    private int taskId;
    private bool free = true;

    public static Action<int> TaskComplited;

    private void OnEnable()
    {
        Dialog.DialogEnded += DialogEnd;
    }

    private void OnDisable()
    {
        Dialog.DialogEnded -= DialogEnd;
    }

    public void FightStart(int lvl)
    {
        if (free)
        {
            free = false;
            music.SetActive(false);
            fightMusic.SetActive(true);
            FightCanvas.SetActive(true);
            // Enemy.GetComponent<Enemy>().LvlUp(lvl);
            cam1.enabled = false;
            cam2.enabled = true;
            cam3.enabled = false;
            Cursor.visible = true;
        }
    }

    public void FightEnd()
    {
        Cursor.visible = false;
        music.SetActive(true);
        fightMusic.SetActive(false);
        FightCanvas.SetActive(false);
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
        free = true;
        enemyDialog?.SetActive(true);
    }

    public void TaskStart(int id)
    {
        if (free)
        {
            free = false;
            taskId = id;
            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = true;
        }
    }

    public void TaskEnd()
    {        
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
        TaskComplited?.Invoke(taskId);
        free = true;
    }

    public void DialogStart(string dialogId)
    {
        if (free)
        {
            free = false;
            dialog.Speak(dialogId);
            PlayerController();
        }
    }

    public void DialogEnd(string dialogId)
    {

        free = true;
        if (dialogId != "13")
        {
            PlayerController();
        }
        else
        {
            player.MoveEnd();
        }
    }

    public void PlayerController()
    {
        player.MoveControl(free);
    }
}
