using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarM : MonoBehaviour
{
    public int IsLeft { get; set; }
    public Camera camera1 { get; set; }
    public Camera MyCamera;
    public InterControl _control { get; set; }
    public float Move()
    {
        if ((float)IsLeft * (-camera1.transform.position.x + transform.position.x) > 11.5)
        {
            return 0f;
        }
        if (_control.LeftDirection() && _control.RightDirection())
        {
            float i = Time.deltaTime;
            transform.position -= new Vector3(i * 3, 0, 0);
            return i;
        }

        return 0f;
    }
    public void Back()
    {
        transform.position = new Vector3((float)(camera1.transform.position.x + IsLeft * 5.625), (float)(camera1.transform.position.y + 4.5), 0);
    }
    public void Start()
    {
        camera1 = MyCamera;
    }
}
