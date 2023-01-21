using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KernelLine : MonoBehaviour
{
    public IMediator _mediator;
    public InterControl _control;
    public bool IsLeft;
    public void Move()
    {
        if (_control.UpDirection())
        {
            transform.eulerAngles += new Vector3(0,0, (float)(1*40*Time.deltaTime));
        }
        else if (_control.DownDirection())
        {
            transform.eulerAngles -= new Vector3(0, 0, (float)(1 * 40 * Time.deltaTime));
        }
    }
    public void Move(float x, float y, float z)
    {
        transform.position = new Vector3(x, y, z);
    }
}
