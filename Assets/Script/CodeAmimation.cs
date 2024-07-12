using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeAmimation : MonoBehaviour
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
            anim.Play("Eyes");
            yield return new WaitForSeconds(2f);
            anim.Play("Disable");

            yield return new WaitForSeconds(timeWait);
            anim.Play("Code1");
            yield return new WaitForSeconds(2f);
            anim.Play("Disable");

            yield return new WaitForSeconds(timeWait);

            for (int i = 0; i < 3; i++)
            {
                anim.Play("Code2");
                yield return new WaitForSeconds(0.5f);
                anim.Play("Disable");
                yield return new WaitForSeconds(0.5f);
            }


            for (int i = 0; i < 3; i++)
            {
                anim.Play("Code2");
                yield return new WaitForSeconds(1f);
                anim.Play("Disable");
                yield return new WaitForSeconds(0.5f);
            }

            for (int i = 0; i < 3; i++)
            {
                anim.Play("Code2");
                yield return new WaitForSeconds(0.5f);
                anim.Play("Disable");
                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(timeWait);

            for (int i = 0; i < 10; i++)
            { 
                anim.Play("Code3");
                yield return new WaitForSeconds(0.5f);
                anim.Play("Disable");
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
