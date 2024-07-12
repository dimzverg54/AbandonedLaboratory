using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardTermial : MonoBehaviour
{
    [SerializeField] private Vector3 transformObject;
    [SerializeField] private int cardId;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Inventory inventory;

    public static Action<int> CardComplited;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inventory.UsedCard(cardId))
        {
            CardComplited?.Invoke(cardId);
            spriteRenderer.sprite = sprite;
        }
    }

}
