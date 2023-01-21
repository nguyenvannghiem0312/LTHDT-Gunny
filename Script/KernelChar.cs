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
        return;
    }
    public float HitPoint { get; set; }
    public float ManaPoint { get; set; }
    public Animator animator;
    public InterControl _control;
    public IMediator _mediator;
    public void Move()
    {
        animator.SetBool("Shoot", false);
        if (_control.LeftDirection())
        {
            GetComponent<Transform>().localScale = new Vector3(-1.5f, GetComponent<Transform>().localScale.y, GetComponent<Transform>().localScale.z);
            float movestep = 1 * -1 * Time.deltaTime;
            transform.position += new Vector3(movestep, 0, 0);
            animator.SetBool("Velocity", true);
            _mediator.Notify("Left");
        }
        else if (_control.RightDirection())
        {
            GetComponent<Transform>().localScale = new Vector3(1.5f, GetComponent<Transform>().localScale.y, GetComponent<Transform>().localScale.z);
            float movestep = 1 * 1 * Time.deltaTime;
            transform.position += new Vector3(movestep, 0, 0);
            animator.SetBool("Velocity", true);
            _mediator.Notify("Right");
        }
        else
        {
            animator.SetBool("Velocity", false);
        }
    }
}
