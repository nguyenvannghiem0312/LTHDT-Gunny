using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MonoBehaviour1 : MonoBehaviour
{
    public interface BaseChar
    {
        // public void Shoot(float pow);
        public void Hurted();
        public float HitPoint { get; set; }
        public float ManaPoint { get; set; }
    }
}
