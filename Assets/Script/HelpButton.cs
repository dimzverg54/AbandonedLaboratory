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
                    txt.text = "��� �������������� ������, ����� ����� ����������� ���������� � ��� � �������������� ����������.\n������� ������ ��� �����������.";
                    break;

                case 1:
                    transform.position = new Vector2(-16.9f, 2.5f);
                    txt.text = "��� ��� ���������, �� ����� ��������� �� ���.\n������� ������ ��� �����������.";
                    break;
                case 2:
                    transform.position = new Vector2(-12f, 3.5f);
                    txt.text = "��� �����, �� ����� ��������� � ����.\n������� ������ ��� �����������.";
                    break;
                case 3:
                    transform.position = new Vector2(-11.3f, -0.7f);
                    txt.text = "��� ������ �������� �� ����� ������ ����������.\n������� ������ ��� �����������.";
                    break;
                case 4:
                    transform.position = new Vector2(-11.3f, -1.8f);
                    txt.text = "��� ������� �������� �� �������������� ������� ���.\n������� ������ ��� ���������� ��������.";
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
