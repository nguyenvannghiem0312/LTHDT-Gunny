using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class KernelWeapon : MonoBehaviour, InterWeapon
{
    public bool IsShoot { get; set; }
    public float DeltaT { get; set; }
    public float Mass { get; set; }
    public float Corner { get; set; }
    public float V0 { get; set; }
    public float x0 { get; set; }
    public float y0 { get; set; }
    public bool IsLeft;
    public IMediator _mediator;
    public IMediator _mediator2;
    public InterControl _control;
    public void Move(float x, float y, float z)
    {
        x0 = x;
        y0 = y;
        transform.position = new Vector3(x, (float)(y+0.2) , z);
    }
    public void MoveShoot()
    {
        if (IsShoot)
        {
            DeltaT += Time.deltaTime;
            if (DeltaT > 1)
            {
                transform.position = new Vector3(x0 + (float)V0 * (float)Math.Cos(Corner * 3.14 / 180) * (DeltaT - 1), y0 + (float)(V0 * (float)(Math.Sin(Corner * 3.14 / 180)) * (DeltaT - 1) - 0.5 * 1 * (DeltaT - 1) * (DeltaT - 1)), 0);
            }
        }
        else
        {
            return;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Land")
        {
            _mediator2.Notify2(this.gameObject, other,"Switch");
            Debug.Log(other.tag);
        }
        else if(other.tag == "Player" && other.gameObject.name != _mediator.Name())
        {
            _mediator2.Notify2(this.gameObject,other,"Hurted");
            Debug.Log(other.tag);
        }
    }
    public void Start()
    {
        IsShoot = false;
    }
    public void Update()
    {
        MoveShoot();
        transform.rotation = Quaternion.Euler(0, 0, 20 + DeltaT*60);
    }
}
