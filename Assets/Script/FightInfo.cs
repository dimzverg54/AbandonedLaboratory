using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text txt;

    public void Name(string name)
    {
        txt.text = name;
    }

    public void Lvl(int lvl)
    {
        txt.text = "Уровень " + lvl.ToString();
    }
}
