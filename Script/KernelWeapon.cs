using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class KernelWeapon : MonoBehaviour, InterWeapon
{
    public bool IsShoot { get; set; }
    public float DeltaT { get; set; }
    public float Mass { get; set; }
    public bool IsLeft;
    public IMediator _mediator;
    public void Move(float x, float y, float z)
    {
        transform.position = new Vector3(x, y , z);
    }
    public void MoveShoot(float corner, float v0, float x, float y, float z)
    {
        if (IsShoot)
        {
            transform.position = new Vector3(v0 * (float)Math.Cos(corner)*DeltaT + x,(float) (y + v0 * (float)(Math.Sin(corner))*DeltaT - 1/2 * 9.8 * DeltaT *DeltaT), z);
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z - 20, 0) ;
        }
        else
        {
            return;
        }
    }
    public Animator _animator;
    public InterControl _control;
}
