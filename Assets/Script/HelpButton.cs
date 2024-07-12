using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HelpButton : MonoBehaviour
{
    [SerializeField] private TMP_Text txt;
    public bool help = true;
    private int step = 0;
    [SerializeField] private Camera cam; 

    void OnEnable()
    {
        transform.position = new Vector2(-20, -0.6f);
        step = 0;
    }
    void Start()
    {
        transform.position = new Vector2(-20, -0.6f);
        step = 0;
    }

    void Update()
    {
        if (cam.enabled)
        {
            switch (step)
            {
                case 0:
                    transform.position = new Vector2(-20, -0.6f);
                    txt.text = "Это информациооная панель, здесь будет указываться информация о бое и дополнительная информация.\nНажмите пробел для продолжения.";
                    break;

                case 1:
                    transform.position = new Vector2(-16.9f, 2.5f);
                    txt.text = "Это ваш антивирус, он будет сражаться за вас.\nНажмите пробел для продолжения.";
                    break;
                case 2:
                    transform.position = new Vector2(-12f, 3.5f);
                    txt.text = "Это вирус, он будет сражаться с вами.\nНажмите пробел для продолжения.";
                    break;
                case 3:
                    transform.position = new Vector2(-11.3f, -0.7f);
                    txt.text = "Эти кнопки отвечают за атаки вашего антивируса.\nНажмите пробел для продолжения.";
                    break;
                case 4:
                    transform.position = new Vector2(-11.3f, -1.8f);
                    txt.text = "Эти кнуопки отвечают за дополнительные функции боя.\nНажмите пробел для завершения обучения.";
                    break;
                case 5:
                    txt.text = "";
                    step = 0;
                    gameObject.SetActive(false);
                    break;
            }

            if (Input.GetKeyDown("space"))
            {
                step++;
            }
        }
    }

    

}
