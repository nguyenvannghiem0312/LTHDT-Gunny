using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public SelectCharacter[] characters;

    public int CharacterCount
    {
        get
        {
            return characters.Length;
        }
    }

    public SelectCharacter GetCharacter(int index)
    {
        return characters[index];
    }
}
