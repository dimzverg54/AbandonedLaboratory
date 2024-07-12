using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] Inventory inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inventory.AddCard(id))
        {
            Destroy(gameObject);
        }
    }
}
