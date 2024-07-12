using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class Task : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private char[] actions;
    [SerializeField] private FightController controller;
    [SerializeField] private Camera cam3;
    [SerializeField] private TaskComplit taskComplit;

    private char action;
    private string task;
    private int num1;
    private int num2;
    private int answer;
    private string insert;
    private char line = '|';

    private void Start()
    {
        Respoawn();
        StartCoroutine(LineTick());
    }

    private void Update()
    {
        if (cam3.enabled)
        {
            if (Input.GetKeyDown("1"))
            {
                insert += 1;
                OutputAnswer();
            }
            if (Input.GetKeyDown("2"))
            {
                insert += 2;
                OutputAnswer();
            }
            if (Input.GetKeyDown("3"))
            {
                insert += 3;
                OutputAnswer();
            }
            if (Input.GetKeyDown("4"))
            {
                insert += 4;
                OutputAnswer();
            }
            if (Input.GetKeyDown("5"))
            {
                insert += 5;
                OutputAnswer();
            }
            if (Input.GetKeyDown("6"))
            {
                insert += 6;
                OutputAnswer();
            }
            if (Input.GetKeyDown("7"))
            {
                insert += 7;
                OutputAnswer();
            }
            if (Input.GetKeyDown("8"))
            {
                insert += 8;
                OutputAnswer();
            }
            if (Input.GetKeyDown("9"))
            {
                insert += 9;
                OutputAnswer();
            }
            if (Input.GetKeyDown("0"))
            {
                insert += 0;
                OutputAnswer();
            }
            if (Input.GetKeyDown("backspace"))
            {
                if (insert.Length != 0)
                {
                    insert = insert.Remove(insert.Length - 1);
                    OutputAnswer();
                }
            }
            if (Input.GetKeyDown("return"))
            {
                if (insert == answer.ToString())

                {
                    controller.TaskEnd();
                    Respoawn();
                }
            }
        }
    }

    private void OutputAnswer()
    {
        task = num1 + " " + action + " " + num2 + " = " + insert + line;
        text.text = task;
    }

    private void Respoawn()
    {
        insert = "";
        num1 = UnityEngine.Random.Range(10, 20);
        num2 = UnityEngine.Random.Range(0, 11);
        action = actions[UnityEngine.Random.Range(0, actions.Length)];

        switch (action)
        {
            case '+':
                answer = num1 + num2;
                break;
            case '-':
                answer = num1 - num2;
                break;
            case '*':
                answer = num1 * num2;
                break;
        }
        OutputAnswer();
    }

    IEnumerator LineTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            line = ' ';
            OutputAnswer();
            yield return new WaitForSeconds(0.5f);
            line = '|';
            OutputAnswer();
        }
    }
}
