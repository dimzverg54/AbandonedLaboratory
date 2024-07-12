using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public void NewHp(int maxHp, int hp)
    {
        transform.localScale = new Vector3((float)hp / (float)maxHp, 1, 1);
    }
}
