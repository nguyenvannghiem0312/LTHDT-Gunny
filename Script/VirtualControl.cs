using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualControl : InterControl
{
    private bool[] State = new bool[4] { true, true, false, false };
    public bool LeftDirection()
    {
        return State[0];
    }
    public bool RightDirection()
    {
        return !State[0];
    }
    public bool UpDirection()
    {
        return State[1];
    }
    public bool DownDirection()
    {
        return !State[1];
    }
    public bool SpaceDirection()
    {
        return State[2];
    }
    public bool PressSpace()
    {
        return State[3];
    }
}
