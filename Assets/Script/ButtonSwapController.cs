using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonSwapController : MonoBehaviour
{
    [SerializeField] private GameObject AttackButton;
    [SerializeField] private GameObject USBButton;
    [SerializeField] private GameObject AntivirusButton;
    [SerializeField] private TMP_Text txt;
    [SerializeField] private TMP_Text antivirusText;
    [SerializeField] private TMP_Text USBText;

    private string back = "";

    public void Swap(string button)
    {
        switch (button)
        {
            case "antivirus":
                if (back == "antivirus")
                {
                    back = "";
                    USBButton.SetActive(false);
                    AntivirusButton.SetActive(false);
                    AttackButton.SetActive(true);
                    antivirusText.text = "������� ����������";
                }
                else
                {
                    back = "antivirus";
                    AttackButton.SetActive(false);
                    USBButton.SetActive(false);
                    AntivirusButton.SetActive(true);
                    antivirusText.text = "�����";
                    USBText.text = "���������";
                }
                break;

            case "USB":
                if (back == "USB")
                {
                    back = "";
                    AntivirusButton.SetActive(false);
                    USBButton.SetActive(false);
                    AttackButton.SetActive(true);
                    USBText.text = "���������";
                }
                else
                {
                    back = "USB";
                    AttackButton.SetActive(false);
                    AntivirusButton.SetActive(false);
                    USBButton.SetActive(true);
                    USBText.text = "�����";
                    antivirusText.text = "������� ����������";
                }
                break;
        }
    }

}
