using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskComplit : MonoBehaviour
{
    [SerializeField] private Vector3 transformObject;
    [SerializeField] private int taskId;
    [SerializeField] private int countTask;

    private int numberTask = 0;

    private void OnEnable()
    {
        FightController.TaskComplited += Complit;
    }

    private void OnDisable()
    {
        FightController.TaskComplited -= Complit;
    }

    private void Complit(int id)
    {
        if (taskId == id)
        {
            numberTask++;
            if (numberTask >= countTask)
            {
                gameObject.transform.position += transformObject;
            }
        }
    }
}
