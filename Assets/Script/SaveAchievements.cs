using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAchievements : MonoBehaviour
{
    [SerializeField] private char[] achievement;

    private string achievements = "000000000000";

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("Achievements"))
        {
            achievements = PlayerPrefs.GetString("Achievements");
            achievement = achievements.ToCharArray(0, 12);
        }
        else
        {
            achievements = "000000000000";
        }
    }

    public void NewAchievement(int id)
    {
        achievement[id] = '1';
        achievements = "";
        for(int i = 0; i < achievement.Length; i++)
        {
            achievements = achievements + achievement[i];
        }
        PlayerPrefs.SetString("Achievements", achievements);
        PlayerPrefs.Save();
    }
}
