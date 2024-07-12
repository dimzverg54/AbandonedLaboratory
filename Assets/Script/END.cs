using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class END : MonoBehaviour
{
    [SerializeField] private GameObject[] antiviruses;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < antiviruses.Length; i++)
        {
            antiviruses[i].SetActive(true);
        }
    }

}
