using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadAchievements : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private string[] info;
    [SerializeField] private TMP_Text[] text;
    [SerializeField] SpriteRenderer[] spriteRenderers;
    [SerializeField] private char[] achievement;

    private string achievements="000000000000";


    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("Achievements"))
        {
            achievements = PlayerPrefs.GetString("Achievements");
            achievement = achievements.ToCharArray(0, 12);
            
            for (int i = 0; i < sprites.Length; i++)
            {
                if (achievement[i] == '1')
                {

                    text[i].text = info[i];
                    spriteRenderers[i].sprite = sprites[i];
                }
            }
        }
    }
}
