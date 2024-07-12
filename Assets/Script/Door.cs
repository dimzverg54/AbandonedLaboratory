using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private AudioSource door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.enabled = false;
        door.Play();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        spriteRenderer.enabled = true;
    }
}
