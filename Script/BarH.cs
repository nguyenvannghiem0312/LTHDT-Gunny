using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarH : MonoBehaviour
{
    public int IsLeft { get; set; }
    public Camera camera1 { get; set; }
    public Camera MyCamera;
    public InterControl _control { get; set; }
    public float Move()
    {
        transform.position -= new Vector3(1.15f, 0, 0);
        return -1f;
    }
    public void Back()
    {

    }
    public void Start()
    {
        camera1 = MyCamera;
    }
}
