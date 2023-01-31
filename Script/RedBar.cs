using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBar : MonoBehaviour
{
    public float Ratio;
    public Camera _camera;
    public IMediator _mediator2;
    private InterControl _control = new LeftControl();
    private Transform Tr;
    private bool Increment;
    public void Start()
    {
        Tr = GetComponent<Transform>();
        Tr.localScale = new Vector3(0, -0.5f, 0);
        Increment = true;
    }
    public void Move()
    {
        if (_control.SpaceDirection())
        {
            Tr.localScale = new Vector3(22.5f, -0.5f, 0);
            if (Increment)
            {
                Tr.position += new Vector3(11 * 1 * Time.deltaTime, 0, 0);
                if (Tr.position.x > _camera.transform.position.x)
                {
                    Increment = false;
                }
            }
            else
            {
                Tr.localScale -= new Vector3(11 * 1 * Time.deltaTime, 0, 0);
                Tr.position -= new Vector3(11 * 1 * Time.deltaTime, 0, 0);
                if (Tr.position.x < _camera.transform.position.x-22.5)
                {
                    Increment = true;
                }
            }
        }
        if (_control.PressSpace())
        {
            Ratio = 1 - (_camera.transform.position.x - Tr.transform.position.x)/22.5f ;
            Tr.position = new Vector3((float)(_camera.transform.position.x - 22.5), Tr.position.y, Tr.position.z);
            Tr.localScale = new Vector3(0, -0.5f, 0);
            _mediator2.Notify("Shoot");
        }
    }
    public void Update()
    {
        Move();
    }
}
