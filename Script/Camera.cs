using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public bool Action;
    public float x;
    public bool IsLeft;
    public float time;
    public void Move(float x, bool Isleft)
    {
        time += Time.deltaTime;
        if(time > 1.5)
        {
            if (transform.position.x > x)
            {
                transform.position -= new Vector3(30 * Time.deltaTime, 0, 0);
                if (transform.position.x < x)
                {
                    transform.position = new Vector3(x, 0, 0);
                    Action = false;
                    time = 0;
                }

            }
            else
            {
                transform.position += new Vector3(30 * Time.deltaTime, 0, 0);
                if (transform.position.x > x)
                {
                    transform.position = new Vector3(x, 0, 0);
                    Action = false;
                    time = 0;
                }
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Action)
        {
            Move(x, IsLeft);
        }
    }
}
