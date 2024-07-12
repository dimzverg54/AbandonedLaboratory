using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Particle : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float time;

    public void ParticleStart(string name)
    {
        animator.Play(name);
        StartCoroutine(ParticleEnd());
    }

    IEnumerator ParticleEnd()
    {
        yield return new WaitForSeconds(time);
        animator.Play("Idle");
    }
}
