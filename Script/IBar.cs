using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBar
{
    public Camera camera1 { get; set; }
    public int IsLeft { get; set; }
    public InterControl _control { get; set; }
    public float Move();
    public void Back();
}
