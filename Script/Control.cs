using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MonoBehaviour1 : MonoBehaviour
{
    public interface Control
    {
        public bool LeftDirection();
        public bool RightDirection();
        public bool UpLine();
        public bool DownLine();
        public float Shot();
    }
    public class LeftControl : Control
    {
        public bool LeftDirection()
        {
            return Input.GetKey(KeyCode.A);
        }
        public bool RightDirection()
        {
            return Input.GetKey(KeyCode.D);
        }
        public bool UpLine()
        {
            return Input.GetKey(KeyCode.W);
        }
        public bool DownLine()
        {
            return Input.GetKey(KeyCode.S);
        }

        public float Shot()
        {
            return Input.GetAxis("Jump");
        }
    }
    public class RightControl : Control
    {
        public bool LeftDirection()
        {
            return Input.GetKey(KeyCode.LeftArrow);
        }
        public bool RightDirection()
        {
            return Input.GetKey(KeyCode.RightArrow);
        }
        public bool UpLine()
        {
            return Input.GetKey(KeyCode.UpArrow);
        }
        public bool DownLine()
        {
            return Input.GetKey(KeyCode.DownArrow);
        }
        public float Shot()
        {
            return Input.GetAxis("Jump");
        }
    }
}
