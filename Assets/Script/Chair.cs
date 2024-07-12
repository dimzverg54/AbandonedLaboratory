using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float timeWait;
    [SerializeField] private string animStr;
    [SerializeField] private float animTime;

    void Start()
    {
        //anim = GetComponent<Animator>();
        anim.Play("Disable");
        StartCoroutine(Anim());
    }

    IEnumerator Anim()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeWait);
            anim.Play(animStr);
            yield return new WaitForSeconds(animTime);
            anim.Play("Disable");
        }
    }
}
