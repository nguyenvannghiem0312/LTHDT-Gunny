using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KernelLine : MonoBehaviour
{
    public IMediator _mediator;
    public IMediator _mediator2;
    public InterControl _control;
    public float Corner;
    public void Move()
    {
        float i = Time.deltaTime;
        if (_control.UpDirection())
        {
            Corner += (float)(1 * 40 * i);
            transform.eulerAngles += new Vector3(0,0, (float)(1*40*i));

        }
        else if (_control.DownDirection())
        {
            Corner -= (float)(1 * 40 * i);
            transform.eulerAngles -= new Vector3(0, 0, (float)(1 * 40 * i));
        }
    }
    public void Move(float x, float y, float z)
    {
        transform.position = new Vector3(x, y, z);
    }
    private void Start()
    {
        Corner = 0f;
    }
    public void Update()
    {
        Move();
    }
}
