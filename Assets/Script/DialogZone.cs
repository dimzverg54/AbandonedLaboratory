using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogZone : MonoBehaviour
{
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
