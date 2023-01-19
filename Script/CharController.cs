using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    Transform tr;
    Rigidbody2D rb;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            Move(1, 1.5f);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            Move(-1, -1.5f);         
        }
    }

    void Move(int d, float s)
    {
        float moveStep = moveSpeed * d * Time.deltaTime;
        transform.position = transform.position + new Vector3(moveStep, 0, 0);
        tr.localScale = new Vector3(s, tr.localScale.y, tr.localScale.z);
    }

}
