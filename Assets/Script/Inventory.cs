using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text ddText;
    [SerializeField] private TMP_Text revivelText;
    [SerializeField] private TMP_Text shockText;
    [SerializeField] private TMP_Text hpChargeTxt;
    [SerializeField] private TMP_Text DDChargeTxt;
    [SerializeField] private TMP_Text revielChargeTxt;
    [SerializeField] private TMP_Text ShockChargeTxt;
    [SerializeField] private AntivirusController antivirusController;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer cardSprite;

    private int cardId = 0;
    private int heal = 5;
    private int dd = 5;
    private int revivel = 5;
    private int shock = 5;
    private bool haveUSB;

    private void Start()
    {
        hpChargeTxt.text = Convert.ToString(heal);
        hpText.text = Convert.ToString(heal);
        DDChargeTxt.text = Convert.ToString(dd);
        ddText.text = Convert.ToString(dd);
        revielChargeTxt.text = Convert.ToString(revivel);
        revivelText.text = Convert.ToString(revivel);
        ShockChargeTxt.text = Convert.ToString(shock);
        shockText.text = Convert.ToString(shock);
    }

    private void OnEnable()
    {
        Enemy.EnemyDead += RandomUSB;
    }

    private void OnDisable()
    {
        Enemy.EnemyDead -= RandomUSB;
    }

    public bool AddCard(int id)
    {
        if (cardId == 0) 
        {
            cardId = id;
            cardSprite.sprite = sprites[id];
            return (true);
        } 
        else
        {
            return (false);
        }
    }

    public bool UsedCard(int id)
    {
        bool f = false;
        if (cardId == id)
        {
            f = true;
            cardId = 0;
            cardSprite.sprite = sprites[0];
        }
        return (f);
    }

    private void RandomUSB(int count)
    {
        for (int i = 0; i < count; i++)
        {
            AddUSB(UnityEngine.Random.Range(0, 8));
        }
    }

    public void AddUSB(int usbId)
    {
        switch (usbId)
        {
            case 1:
                {
                    heal++;
                    hpChargeTxt.text = Convert.ToString(heal);
                    hpText.text = Convert.ToString(heal);
                    break;
                }
            case 2:
                {
                    dd++;
                    DDChargeTxt.text = Convert.ToString(dd);
                    ddText.text = Convert.ToString(dd);
                    break;
                }
            case 3:
                {
                    revivel++;
                    revielChargeTxt.text = Convert.ToString(revivel);
                    revivelText.text = Convert.ToString(revivel);
                    break;
                }
            case 4:
                {
                    shock++;
                    ShockChargeTxt.text = Convert.ToString(shock);
                    shockText.text = Convert.ToString(shock);
                    break;
                }
        }
    }

    public void UsingUSB(int usbId)
    {
        switch (usbId)
        {
            case 1:
                {
                    if (heal > 0)
                    {
                        heal--;
                        antivirusController.USB(1);
                        hpChargeTxt.text = Convert.ToString(heal);
                        hpText.text = Convert.ToString(heal);
                    }
                    break;

                }
            case 2:
                {

                    if (dd > 0)
                    {
                        dd--;
                        antivirusController.USB(2);
                        DDChargeTxt.text = Convert.ToString(dd);
                        ddText.text = Convert.ToString(dd);
                    }
                    break;
                }
            case 3:
                {
                    if (revivel > 0)
                    {
                        revivel--;
                        antivirusController.USB(3);
                        revielChargeTxt.text = Convert.ToString(revivel);
                        revivelText.text = Convert.ToString(revivel);
                    }
                    break;
                }
            case 4:
                {
                    if (shock > 0)
                    {
                        shock--;
                        antivirusController.USB(4);
                        ShockChargeTxt.text = Convert.ToString(shock);
                        shockText.text = Convert.ToString(shock);
                    }
                    break;
                }
        }
    }
}