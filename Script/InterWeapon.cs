using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterWeapon
{
    public bool IsShoot { get; set; }
    public float DeltaT { get; set; }
    public float Mass { get; set; }
    public float Corner { get; set; }
    public float V0 { get; set; }
    public float x0 { get; set; }
    public float y0 { get; set; }
    public bool IsLeft { get; set; }
    public IMediator _mediator { get; set; }
    public IMediator _mediator2 { get; set; }
    public IMediator _mediator3 { get; set; }
    public InterControl _control { get; set; }
    public Transform _transform { get; set; }
    public void Move(float x, float y, float z );
    public void MoveShoot();
}
