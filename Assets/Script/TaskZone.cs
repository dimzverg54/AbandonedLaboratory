using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskZone : MonoBehaviour
{
    [SerializeField] private FightController controller;
    [SerializeField] private int taskId;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private BoxCollider2D taskZone;

    private void OnEnable()
    {
       // FightController.TaskComplited += Complite;
    }

    private void OnDisable()
    {
       // FightController.TaskComplited -= Complite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            controller.TaskStart(taskId);
            spriteRenderer.sprite = sprites[1];
            taskZone.enabled = false;
        }
    }

    private void Complite(int id)
    {
        if (id == taskId)
        {
            
        }
    }
}
