using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private ScenesController scenesController;

    private void Start()
    {
        animator.Play("idleEnd");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(END());
        animator.Play("END");
    }

    IEnumerator END()
    {
        yield return new WaitForSeconds(2.5f);
        scenesController.SceneLoad(0);
    }
}
