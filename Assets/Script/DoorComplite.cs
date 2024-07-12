using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorComplite : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 transformObject;
    [SerializeField] private int cardId;

    private void OnEnable()
    {
        CardTermial.CardComplited += Complit;
    }

    private void OnDisable()
    {
        CardTermial.CardComplited -= Complit;
    }

    private void Complit(int id)
    {
        if (cardId == id)
        {
            gameObject.transform.position += transformObject;
        }
    }
}
