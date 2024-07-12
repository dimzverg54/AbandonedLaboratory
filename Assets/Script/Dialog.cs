using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Dialog : MonoBehaviour
{
    
    [SerializeField] private GameObject speaker;
    [SerializeField] private GameObject tmp;
    [SerializeField] private GameObject panel;
    [SerializeField] private int number;
    [SerializeField] private string[] fullDialog;

    [SerializeField] private string dialog;
    [SerializeField] private string[] temporaryDialog;
    [SerializeField] private string id;
    [SerializeField] private string who;
    [SerializeField] private string phrase;
    private bool starter = false;
    private string newId;

    public static Action<string> DialogEnded;
    public void Speak(string dialogId)
    {
        //  int i = 0;
        newId = dialogId;
       
        number = 0;
        do
        {
            dialog = fullDialog[number];
            temporaryDialog = dialog.Split(new char[] { '&' });
            id = temporaryDialog[0];
            who = temporaryDialog[1];
            phrase = temporaryDialog[2];

            number++;
        }
        while (dialogId != id);

        panel.SetActive(true);
        speaker.SetActive(true);
        tmp.SetActive(true);

       
        NextPhrase(dialogId);
    }

    public void NextPhrase(string dialogId)
    {
        if (dialogId == id)
        {

            speaker.GetComponent<Animator>().Play(who);
            tmp.GetComponent<TMP_Text>().text = phrase;
            dialog = fullDialog[number];
            temporaryDialog = dialog.Split(new char[] { '&' });
            id = temporaryDialog[0];
            who = temporaryDialog[1];
            phrase = temporaryDialog[2];
            starter = true;
            number++;
        }
        else
        {
            panel.SetActive(false);
            speaker.SetActive(false);
            tmp.SetActive(false);
            starter = false;
            DialogEnded?.Invoke(dialogId);
        }
    }

    private void Update()
    {
        if ((Input.GetKeyDown("return"))&&(starter))
        {
            starter = false;
            NextPhrase(newId);
        }
    }

}
