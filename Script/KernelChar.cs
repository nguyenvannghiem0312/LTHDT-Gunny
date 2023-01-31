using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KernelChar : MonoBehaviour,InterChar
{
    public void Shoot()
    {
        return;
    }
    public void Hurted()
    {
        _mediator3.Hurt();
        return;
    }
    public float HitPoint { get; set; }
    public float ManaPoint { get; set; }
    public Animator animator;
    public InterControl _control;
    public IMediator _mediator;
    public IMediator _mediator2;
    public IMediator _mediator3;
    public bool MyTurn;
    public bool IsShoot;
    float a = 0f;
    public void Move()
    {
        if (_control.LeftDirection())
        {
            GetComponent<Transform>().localScale = new Vector3(-1.5f, GetComponent<Transform>().localScale.y, GetComponent<Transform>().localScale.z);
            transform.position -= new Vector3(_mediator3.Move(), 0, 0);
            animator.SetBool("Velocity", true);
            _mediator.Notify("Left");
        }
        else if (_control.RightDirection())
        {
            GetComponent<Transform>().localScale = new Vector3(1.5f, GetComponent<Transform>().localScale.y, GetComponent<Transform>().localScale.z);
            transform.position += new Vector3(_mediator3.Move(), 0, 0);
            animator.SetBool("Velocity", true);
            _mediator.Notify("Right");
        }
        else
        {
            animator.SetBool("Velocity", false);
        }
    }
    public void Update()
    {
        if (MyTurn)
        {
            a = a + Time.deltaTime;
            animator.SetBool("Shoot", false);
            if (a > 2)
            {
                animator.SetBool("Cry", false);
            }

            Move();
        }
        else
        {
            animator.SetBool("Velocity", false);
            a = 0;
        }
    }
}
