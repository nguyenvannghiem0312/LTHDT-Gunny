using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterWeapon
{
    public bool IsShoot { get; set; }
    public float DeltaT { get; set; }
    public float Mass { get; set; }
    public void Move(float x, float y, float z );
    public void MoveShoot();
}
