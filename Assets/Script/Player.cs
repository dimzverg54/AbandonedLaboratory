using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private Camera cam1;
    [SerializeField] private Camera cam2;
    private Vector2 moveInput;
    private string direction;
    private bool move = true;
    private bool end = false;
    void Start()
    {
        direction = "D";

    }

    public void MoveControl(bool permission)
    {
        move = permission;
    }

    public void MoveEnd()
    {
        end = true;
    }

    void FixedUpdate()
    {
        if ((cam1.enabled) && (move))
        {
            Move();
        }
        else
        {
            rb.velocity = moveInput * 0f;
            anim.Play("Idle" + direction);
        }
        if (end)
        {
            End();
           
        }
    }
    private void End()
    {
        rb.velocity = new Vector2(2f, 0f);
        anim.Play("MoveR");
    }

    private void Move()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveInput.Normalize();
        rb.velocity = moveInput * speed;
        if (moveInput.x < 0) { direction = "L"; }
        if (moveInput.x > 0) { direction = "R"; }
        if (moveInput.y < 0) { direction = "D"; }
        if (moveInput.y > 0) { direction = "U"; }

        if(moveInput.magnitude > 0f)
        {
            anim.Play("Move" + direction);   
        }
        else
        {
            anim.Play("Idle" + direction);
        }

    }
}
