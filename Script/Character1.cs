using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Character1 : MonoBehaviour1
{
    public class Character_1 : BaseChar
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
    Character_1 Kernel = new Character_1();
    Control _control = new LeftControl();
    public Animator animator;
    public GameObject Line;
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
        //LineControll();
    }
}
