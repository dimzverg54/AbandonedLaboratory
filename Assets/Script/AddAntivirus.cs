using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAntivirus : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private AntivirusController antivirusController;
    [SerializeField] private FightController fightController;
    [SerializeField] private string dialogId;

    private void OnEnable()
    {
        Dialog.DialogEnded += DestroyAntivirus;
    }

    private void OnDisable()
    {
        Dialog.DialogEnded -= DestroyAntivirus;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        antivirusController.AddAntivirus(id);
        fightController.DialogStart(dialogId);
    }

    public void DestroyAntivirus(string backId)
    {
        if (dialogId == backId)
        {
            Destroy(gameObject);
        }
    }
}
