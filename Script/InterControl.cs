using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterControl
{
    public bool LeftDirection();
    public bool RightDirection();
    public bool UpDirection();
    public bool DownDirection();
    public bool SpaceControl();
}
public class LeftControl : InterControl
{
    public bool LeftDirection()
    {
        return Input.GetKey(KeyCode.A);
    }
    public bool RightDirection()
    {
        return Input.GetKey(KeyCode.D);
    }
    public bool SpaceControl()
    {
        return Input.GetButtonUp("Jump");
    }
    public bool UpDirection()
    {
        return Input.GetKey(KeyCode.W);
    }
    public bool DownDirection()
    {
        return Input.GetKey(KeyCode.S);
    }
}
public class RightControl : InterControl
{
    public bool LeftDirection()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }
    public bool RightDirection()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }
    public bool SpaceControl()
    {
        return Input.GetKey(KeyCode.Space);
    }
    public bool UpDirection()
    {
        return Input.GetKey(KeyCode.UpArrow);
    }
    public bool DownDirection()
    {
        return Input.GetKey(KeyCode.DownArrow);
    }
}
