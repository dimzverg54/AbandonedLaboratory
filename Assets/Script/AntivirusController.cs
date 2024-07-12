using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AntivirusController : MonoBehaviour
{
    [SerializeField] private Kasper kasper;
    [SerializeField] private AVA ava;
    [SerializeField] private Dr dr;
    [SerializeField] private TMP_Text button1;
    [SerializeField] private TMP_Text button2;
    [SerializeField] private TMP_Text button3;
    [SerializeField] private bool[] availableAntivirus = new bool[] { true, true, true };
    [SerializeField] private Particle particle;
    [SerializeField] private Particle particleEnemy;

    private string activeAntivirus = "Kasper";
    private bool turn = true;
    private bool life;

    public static Action<int> EnemyDead;
    public static Action<bool> Turn;
    public static Action<int> AttackTransferred;
    public static Action<int> USBUsed;

    private void OnEnable()
    {
        Enemy.EnemyWented += SwapTurn;
        Enemy.EnemyDead += EnemyDeath;
    }

    private void OnDisable()
    {
        Enemy.EnemyWented -= SwapTurn;
        Enemy.EnemyDead -= EnemyDeath;
    }

    private void SwapTurn()
    {
        turn = true;
        Turn?.Invoke(turn);
    }

    private void EnemyDeath(int xp)
    {
        EnemyDead?.Invoke(xp);
        SwapTurn();
    }

    public void USB(int USBId)
    {
        USBUsed?.Invoke(USBId);
        switch (USBId)
        {
            case 1:
                {
                    particle.ParticleStart("Heal");
                }
                break;
            case 2:
                {
                    particle.ParticleStart("DD");
                }
                break;
            case 3:
                {
                    particle.ParticleStart("Revival");
                }
                break;
            case 4:
                {
                    particleEnemy.ParticleStart("Shoke");
                }
                break;

        }
    }

    public void Life(bool nowLife)
    {
        life = nowLife;
    }

    public void Swap(string name)
    {
        if (turn)
        {
            switch (name)
            {
                case "Kasper":
                    if (availableAntivirus[0])
                    {
                        ava.enabled = false;
                        dr.enabled = false;
                        kasper.enabled = true;
                        activeAntivirus = "Kasper";
                        button1.text = "Прямая атака";
                        button2.text = "Лечение битых файлов";
                        button3.text = "Перегрузка";
                        Turn?.Invoke(turn);
                    }
                    break;
                case "AVA":
                    if (availableAntivirus[1])
                    {
                        dr.enabled = false;
                        kasper.enabled = false;
                        ava.enabled = true;
                        activeAntivirus = "Ava";
                        button1.text = "Прямая атака";
                        button2.text = "Паранойя";
                        button3.text = "Aaaaaa Virus Aaaaaa";
                        Turn?.Invoke(turn);
                    }
                    break;
                case "Dr":
                    if (availableAntivirus[2])
                    {
                        ava.enabled = false;
                        kasper.enabled = false;
                        dr.enabled = true;
                        activeAntivirus = "Dr";
                        button1.text = "Прямая атака";
                        button2.text = "Карантин";
                        button3.text = "Сломанная атака";
                        Turn?.Invoke(turn);
                    }
                    break;
            }
        }
    }

    public void AttackButton1()
    {
        if (life)
        {
            if (turn)
            {
                AttackTransferred?.Invoke(1);
                turn = false;
                Turn?.Invoke(turn);
            }
        }
    }

    public void AttackButton2()
    {
        if (life)
        {
            if (turn)
            {
                AttackTransferred?.Invoke(2);
                turn = false;
                Turn?.Invoke(turn);
            }
        }
    }

    public void AttackButton3()
    {
        if (life)
        {
            if (turn)
            {
                AttackTransferred?.Invoke(3);
                turn = false;
                Turn?.Invoke(turn);
            }
        }
    }

    public void AddAntivirus(int i)
    {
        availableAntivirus[i] = true;
    }
}
