using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleAnimation : MonoBehaviour
{

    [SerializeField] private Animator anim;
    [SerializeField] private float timeWait;
    void Start()
    {
        //anim = GetComponent<Animator>();
        anim.Play("Disable");
        StartCoroutine(CodeAnim());
    }

    IEnumerator CodeAnim()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeWait);
            anim.Play("Tentacle");
            yield return new WaitForSeconds(2f);
            anim.Play("Disable");
        }
    }
}
