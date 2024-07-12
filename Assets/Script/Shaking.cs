using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{
    public void DoShake()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        transform.position = transform.position + new Vector3(0.25f, 0.25f, 0);
        yield return new WaitForSeconds(0.1f);
        transform.position = transform.position - new Vector3(0.5f, 0.5f, 0);
        yield return new WaitForSeconds(0.1f);
        transform.position = transform.position + new Vector3(0.25f, 0.25f, 0);
    }   
}
