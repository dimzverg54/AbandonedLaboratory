using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAchievements : MonoBehaviour
{
    [SerializeField] private SaveAchievements saveAchievements;
    [SerializeField] private int[] achievementId;

    private void OnEnable()
    {
        if (achievementId[0] == 4)
        {
            Enemy.EnemyDead += AddEnemy;
        }
        if (achievementId[0] == 10)
        {
            AntivirusController.USBUsed += AddUsb;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Add();
    }

    private void AddEnemy(int j)
    {
        Enemy.EnemyDead -= AddEnemy;
        Add();
    }

    private void AddUsb(int j)
    {
        AntivirusController.USBUsed -= AddUsb;
        Add();
    }

    public void Add()
    {
        for (int i = 0; i < achievementId.Length; i++)
        {
            saveAchievements.NewAchievement(achievementId[i]);
        }
        Destroy(gameObject);
    }
}
