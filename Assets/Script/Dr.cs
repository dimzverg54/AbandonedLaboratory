using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dr : MonoBehaviour
{
    private int id = 0;
    private int damage = 10;
    [SerializeField] private int hp = 100;
    private int maxHp = 100;
    private int lvl = 1;
    private int xp = 0;
    private int maxXp = 100;
    [SerializeField] private HealthBar xpBar;
    [SerializeField] private GameObject info;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject FightPanel;
    public bool turn = true;
    private bool cooldown = false;
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private GameObject NameInfo;
    [SerializeField] private GameObject LvlInfo;
    private string name = "ERROR http://dr";
    private int dd = 1;
    private bool life = true;
    [SerializeField] private TMP_Text txt;
    [SerializeField] private Animator animator;
    [SerializeField] private Inventory inventory;
    [SerializeField] private AntivirusController antivirusController;
    [SerializeField] private int complexity = 3;

    [SerializeField] private ButtonOnMouse[] bom;

    [SerializeField] private string[] newBom;

    private void OnEnable()
    {
        Enemy.EnemyAttacked += TakeDamage;
        AntivirusController.Turn += Turn;
        AntivirusController.AttackTransferred += Attack;
        AntivirusController.USBUsed += USB;
        Enemy.EnemyDead += Lvlup;
        NameInfo.GetComponent<FightInfo>().Name(name);
        LvlInfo.GetComponent<FightInfo>().Lvl(lvl);
        HealthBar.GetComponent<HealthBar>().NewHp(maxHp, hp);
        xpBar.NewHp(maxXp, xp);
        animator.Play("IdleDr");
        antivirusController.Life(life);
        Complexity.complexityChanged += ComplexityChanged;
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            complexity = PlayerPrefs.GetInt("Difficulty");
        }
        for (int i = 0; i < bom.Length; i++)
        {
            bom[i].NewText(newBom[i]);
        }
    }

    private void OnDisable()
    {
        Enemy.EnemyAttacked -= TakeDamage;
        AntivirusController.Turn -= Turn;
        AntivirusController.AttackTransferred -= Attack;
        AntivirusController.USBUsed -= USB;
        Enemy.EnemyDead -= Lvlup;
        Complexity.complexityChanged -= ComplexityChanged;
    }

    private void ComplexityChanged(int newComplexity)
    {
        complexity = newComplexity;
    }

    void Start()
    {
      
    }

    public void TrueTurn()
    {
        turn = true;
        cooldown = false;
    }

    public void Turn(bool turnControll)
    {
        turn = turnControll;
        /**
        if (cooldown) 
        {
            enemy.GetComponent<Enemy>().Turn();
            cooldown = false;
        }
        **/
    }

    public void TakeDamage(int inputDamage)
    {
        //  anim.Play("TakeDamage" + id);
        FightPanel.GetComponent<Shaking>().DoShake();
        hp -= inputDamage - complexity * 2;
        if (hp < 0)
        {
            hp = 0;
        }
        HealthBar.GetComponent<HealthBar>().NewHp(maxHp, hp);
        if (hp == 0)
        {
            Death();
        }
    }

    private void Death()
    {
        life = false;
        antivirusController.Life(life);
    }

    private void Attack(int id)
    {
        switch (id)
        {
            case 1:
                Attack1();
                break;
            case 2:
                Attack2();
                break;
            case 3:
                Attack3();
                break;
        }
    }

    public void Attack1()
    {
        if ((turn) && (life))
        {
            txt.text = "ERROR http://dr кидает в вирус... битые файлы?";
            enemy.GetComponent<Enemy>().TakeDamage(damage * dd * lvl * complexity);
            dd = 1;
            enemy.GetComponent<Enemy>().Turn();
            //Turn();
        }
    }

    public void Attack2()
    {
        if ((turn) && (life))
        {
            txt.text = "ERROR http://dr помещает вирус к себе в карантин!";
            enemy.GetComponent<Enemy>().AddDebuff();
            // SwapTurn.Invoke();
            //Turn();
        }
    }

    public void Attack3()
    {
        if ((turn) && (life))
        {
            txt.text = "ERROR $!!#$&& //почините уже эту ссылку!";
            enemy.GetComponent<Enemy>().TakeDamage(Random.Range(1, 50) * dd * lvl * complexity);
            dd = 1;
            enemy.GetComponent<Enemy>().Turn();
        }
    }

    public void Lvlup(int addXp)
    {
        //  cooldown = false;
        xp += addXp * 10;
        if (xp >= maxXp)
        {
            xp -= maxXp;
            maxXp *= 2;
            lvl++;
            maxXp += 100;
            xp = maxXp;
        }
        xpBar.NewHp(maxXp, xp);
        LvlInfo.GetComponent<FightInfo>().Lvl(lvl);
        NameInfo.GetComponent<FightInfo>().Name(name);
    }

    public void USB(int USBId)
    {
        switch (USBId)
        {
            case 1:
                {
                    USBHeal();
                    break;
                }
            case 2:
                {
                    USBDD();
                    break;
                }
            case 3:
                {
                    USBRevivel();
                    break;
                }
        }
    }

    private void USBHeal()
    {
        hp += 30 * lvl;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        HealthBar.GetComponent<HealthBar>().NewHp(maxHp, hp);
    }

    private void USBRevivel()
    {
        if (life == false)
        {
            hp = maxHp / 2;
            life = true;
            HealthBar.GetComponent<HealthBar>().NewHp(maxHp, hp);
            antivirusController.Life(life);
        }
        else
        {
            inventory.AddUSB(3);
        }
    }

    private void USBDD()
    {
        dd = 2;
    }
}
