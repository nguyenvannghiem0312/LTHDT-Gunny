using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class WeaponDatabase : ScriptableObject
{
    public SelectWeapon[] Weapons;

    public int WeaponCount
    {
        get
        {
            return Weapons.Length;
        }
    }

    public SelectWeapon GetCharacter(int index)
    {
        return Weapons[index];
    }
}
