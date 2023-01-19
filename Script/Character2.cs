using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Character2 : MonoBehaviour1
{
    public class Character_2 : BaseChar
    {
        public void Shoot()
        {
            return;
        }
        public void Hurted()
        {
            return;
        }
        public float HitPoint { get; set; }
        public float ManaPoint { get; set; }
    }
    Character_2 Kernel = new Character_2();
    Control _control = new RightControl();
    public GameObject Line;
    // public Animator animator;
    public float MoveSpeed { get; set; }
    public void Hihi()
    {
        Debug.Log("Hello World");
    }
    public void Move()
    {
        if (_control.LeftDirection())
        {
            float movestep = 1 * -1 * Time.deltaTime;
            transform.position += new Vector3(movestep, 0, 0);
            GetComponent<Transform>().localScale = new Vector3(-1.5f, GetComponent<Transform>().localScale.y, GetComponent<Transform>().localScale.z);
        }
        else if (_control.RightDirection())
        {
            float movestep = 1 * 1 * Time.deltaTime;
            transform.position += new Vector3(movestep, 0, 0);
            GetComponent<Transform>().localScale = new Vector3(1.5f, GetComponent<Transform>().localScale.y, GetComponent<Transform>().localScale.z);
        }
        else if (_control.UpLine())
        {
            Line.GetComponent<Transform>().eulerAngles += new Vector3(0, 0, 1 * 10 * Time.deltaTime * GetComponent<Transform>().localScale.x);
        }
        else if (_control.DownLine())
        {
            Line.GetComponent<Transform>().eulerAngles += new Vector3(0, 0, -1 * 10 * Time.deltaTime * GetComponent<Transform>().localScale.x);
        }
        else
        {

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Kernel.HitPoint = 1000;
        Kernel.ManaPoint = 500;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
