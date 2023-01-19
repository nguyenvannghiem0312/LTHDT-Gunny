using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MonoBehaviour1 : MonoBehaviour
{
    public interface Control
    {
        public bool LeftDirection();
        public bool RightDirection();
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
    }
}
