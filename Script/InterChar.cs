using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterChar
{
    public float HitPoint { get; set; }
    public float ManaPoint { get; set; }
    public Animator animator { get; set; }
    public InterControl _control { get; set; }
    public IMediator _mediator { get; set; }
    public IMediator _mediator2 { get; set; }
    public IMediator _mediator3 { get; set; }
    public bool MyTurn { get; set; }
    public bool IsShoot { get; set; }
    public void Move();
    public void Hurted();
    public void Shoot();
}
