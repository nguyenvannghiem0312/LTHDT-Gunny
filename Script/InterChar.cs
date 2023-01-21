using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterChar
{
    public float HitPoint { get; set; }
    public float ManaPoint { get; set; }
    public void Move();
    public void Hurted();
    public void Shoot();
}
