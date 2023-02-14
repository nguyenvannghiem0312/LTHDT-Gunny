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
        HitPoint--;
        _mediator3.Hurt();
        if(HitPoint <= 0)
        {
            _mediator2.Notify2(this.gameObject, new Collider2D(), "end");
        }
        return;
    }
    public float HitPoint { get; set; }
    public float ManaPoint { get; set; }
    public Animator animator { get; set; }
    public InterControl _control { get; set; }
    public IMediator _mediator { get; set; }
    public IMediator _mediator2 { get; set; }
    public IMediator _mediator3 { get; set; }
    public bool MyTurn { get; set; }
    public bool IsShoot { get; set; }
    public Transform _transform { get; set; }
    public string _name { get; set; }
    float a = 0f;
    float b = 0f;
    public void Move()
    {
        if (_control.LeftDirection())
        {
            GetComponent<Transform>().localScale = new Vector3(-1.5f, GetComponent<Transform>().localScale.y, GetComponent<Transform>().localScale.z);
            _transform.position -= new Vector3(_mediator3.Move(), 0, 0);
            animator.SetBool("Velocity", true);
            _mediator.Notify("Left");
        }
        else if (_control.RightDirection())
        {
            GetComponent<Transform>().localScale = new Vector3(1.5f, GetComponent<Transform>().localScale.y, GetComponent<Transform>().localScale.z);
            _transform.position += new Vector3(_mediator3.Move(), 0, 0);
            animator.SetBool("Velocity", true);
            _mediator.Notify("Right");
        }
        else
        {
            animator.SetBool("Velocity", false);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "DeathZone")
        {
            HitPoint = -10;
            _mediator2.Notify2(this.gameObject, new Collider2D(), "end");
        }
    }
    void Start()
    {
        HitPoint = 10;
        _transform = this.transform;
        _name = this.gameObject.name;
    }
    public void Update()
    {
        if (MyTurn)
        {
            a = a + Time.deltaTime;
            b = b + Time.deltaTime;
            animator.SetBool("Shoot", false);
            if (a > 2)
            {
                animator.SetBool("Cry", false);
            }

            if(b> 2.5f)
            {
                Move();
            }
        }
        else
        {
            animator.SetBool("Velocity", false);
            a = 0;
            b = 0;
        }
    }
}
