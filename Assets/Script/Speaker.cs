using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    [SerializeField] private Animator anim;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void say(string who, string how)
    {
        anim.Play(who + how);
    }
    
}
