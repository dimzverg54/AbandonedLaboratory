using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class USB : MonoBehaviour
{
    [SerializeField] private GameObject Antivirus;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private int hp;
    [SerializeField] private Inventory inventory;

    void Start()
    {

    }

    public void Heal()
    {
        inventory.UsingUSB(1);
    }

    public void DD()
    {
        inventory.UsingUSB(2);
    }

    public void Reviel()
    {
        inventory.UsingUSB(3);
    }

    public void Shock()
    {
        inventory.UsingUSB(4);
    }

}
