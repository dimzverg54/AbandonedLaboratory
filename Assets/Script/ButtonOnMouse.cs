using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonOnMouse : MonoBehaviour
{
    [SerializeField] private TMP_Text txt;
    [SerializeField] private string pastText;
    [SerializeField] private string newText;

    public void Enter()
    {
        txt.text = newText;
    }

    public void NewText(string text)
    {
        newText = text;
    }

    public void Exit()
    {
        //txt.text = pastText;
    }
}
