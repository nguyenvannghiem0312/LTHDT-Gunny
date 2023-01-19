using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Female : MonoBehaviour1
{
    public class FemaleChar : BaseChar
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
    FemaleChar Kernel = new FemaleChar();
    Control _control = new RightControl();
    public Animator animator;
    public float MovSpeed { get; set; }
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
            animator.SetBool("Left", true);
            animator.SetBool("Velocity", true);
            animator.SetBool("Right", false);
        }
        else if (_control.RightDirection())
        {
            float movestep = 1 * 1 * Time.deltaTime;
            transform.position += new Vector3(movestep, 0, 0);
            animator.SetBool("Right", true);
            animator.SetBool("Velocity", true);
            animator.SetBool("Left", false);
        }
        else
        {
            animator.SetBool("Velocity", false);
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
