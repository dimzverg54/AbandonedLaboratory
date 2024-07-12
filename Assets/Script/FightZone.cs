using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightZone : MonoBehaviour
{
    [SerializeField] private int lvl;
    private bool agro = false;
    [SerializeField] private GameObject Fight;
    private bool CD = false;
    [SerializeField] private Rigidbody2D Player;
    [SerializeField] private float chance = 0;
    [SerializeField] private Enemy enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            agro = true;
            enemy.LvlUpdate(lvl);
            StartCoroutine(Fighting());
        }
    }

    IEnumerator Fighting()
    {
        while (agro)
        {
            yield return new WaitForSeconds(0.5f);
            while (Player.velocity != new Vector2(0, 0))
            {
                yield return new WaitForSeconds(3f);
                if (UnityEngine.Random.Range(0, 15)+ chance <= 1)
                {
                    Fight.GetComponent<FightController>().FightStart(lvl);
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            agro = false;
        }
    }
   
}
