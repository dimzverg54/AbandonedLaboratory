using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Enemy : MonoBehaviour
{
    public static Action<int> EnemyAttacked;
    public static Action EnemyWented;
    public static Action<int> EnemyDead;

    private int id;
    private int damage;
    [SerializeField] private Camera cam1;
    [SerializeField] private Camera cam2;
    [SerializeField] private int hp;
    private int maxHp;
    [SerializeField] private int lvl;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject NameInfo;
    [SerializeField] private GameObject LvlInfo;
    [SerializeField] private GameObject Antivirus;
    [SerializeField] private GameObject FightPanel;
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private string name;
    private bool cooldown = false;
    private bool turn;
    [SerializeField] private TMP_Text txt;
    [SerializeField] private GameObject music;
    [SerializeField] private GameObject fightMusic;
    [SerializeField] private AudioSource punch;
    [SerializeField] private FightController controller;
    private int debuff=1;

    private void OnEnable()
    {
        // Kasper.SwapTurn += Turn;
        AntivirusController.USBUsed += Shoke;
    }

    void Start()
    {     
        Respawn();
       
    }

    void Update()
    {
  
        
    }

    public void LvlUpdate(int newLvl)
    {
        lvl = newLvl;
        Respawn();
    }

    public void Respawn()
    {
        cooldown = false;
        if (lvl == 3)
        {
            id = 2;
        }
        else
        {
            id = UnityEngine.Random.Range(0, 2);
        }
        name = "Вирус";
        hp = 30 * lvl;
        maxHp = hp;
        damage = 10 * lvl;
        debuff = 1;
        Idle();
        HealthBar.GetComponent<HealthBar>().NewHp(maxHp, hp);
        LvlInfo.GetComponent<FightInfo>().Lvl(lvl);
        NameInfo.GetComponent<FightInfo>().Name(name);
    }

    public void LvlUp(int up)
    {

    }

    private void Idle()
    {
        anim.Play("Idle" + id);
    }

    public void Shoke(int USBId)
    {
        if (USBId == 4)
        {
            cooldown = true;
        }
    }

    public void AddDebuff()
    {
        debuff = 2;
    }

    public void Turn()
    {
        
            StartCoroutine(AttackTime());
       
    }

    IEnumerator AttackTime()
    {
        if (cooldown == false)
        {
            if (hp > 0)
            {
                yield return new WaitForSeconds(1f);
                txt.text = "Вирус атакует!";
                anim.Play("Attack" + id);
                yield return new WaitForSeconds(0.5f);
                EnemyAttacked?.Invoke(damage / debuff);
                punch.Play();
                if (id == 1)
                {
                    hp += 5 * lvl;
                    if (hp > maxHp)
                    {
                        hp = maxHp;
                    }
                    HealthBar.GetComponent<HealthBar>().NewHp(maxHp, hp);
                }
                if (id==2)
                Idle();
                yield return new WaitForSeconds(0.5f);
                EnemyWented?.Invoke();
            }
            else
            {
                anim.Play("Death" + id);
            }
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            cooldown = false;
            EnemyWented?.Invoke();
        }
    }

    public void TakeDamage(int inputDamage)
    {
        FightPanel.GetComponent<Shaking>().DoShake();
        punch.Play();
        hp -= inputDamage;
        if (hp > 0)
        {
            anim.Play("TakeDamage" + id);
        }
        if (hp < 0)
        {
            hp = 0;
        }
        HealthBar.GetComponent<HealthBar>().NewHp(maxHp,hp);
        if (hp == 0)
        {
            StartCoroutine (Death());
        }
    }

    IEnumerator Death()
    {
        txt.text = "Вирус успешно удалён!";
        anim.Play("Death" + id);
        yield return new WaitForSeconds(1f);
        controller.FightEnd();
        txt.text = "";
        EnemyDead?.Invoke(lvl);
        /**
        Antivirus.GetComponent<Kasper>().Lvlup();
        Antivirus.GetComponent<Kasper>().Turn();
        Antivirus.GetComponent<Kasper>().TrueTurn();
        **/
        Respawn();
    }

    public void Escape()
    {
        if (id != 2)
        {
            // Antivirus.GetComponent<Kasper>().Turn();
            if (UnityEngine.Random.Range(0, 2) >= 1)
            {
                EnemyAttacked?.Invoke(damage / debuff);
            }
            EnemyWented?.Invoke();
            controller.FightEnd();
            Respawn();
        }
    }


}
