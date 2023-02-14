using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Store : ScriptableObject
{
    public KStore[] State;

    public int StateCount
    {
        get
        {
            return State.Length;
        }
    }

    public KStore GetCharacter(int index)
    {
        return State[index];
    }
}    