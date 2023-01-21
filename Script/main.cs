using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public GameObject Char;
    public GameObject Weapon;
    public GameObject Line;
    void Start()
    {
        Char = new GameObject();
        Weapon = new GameObject();
        Line = new GameObject();
        CharConstruct.CreatChar(ref Char, "Char/Char3", "AnimationOfChar03/Char03", false);
        WeaponConstruct.CreatWeapon(ref Weapon, "Weapon/W03", 4, false);
        LineConstruct.CreatLine(ref Line, "Line", false);
        new Mediator1(Char, Weapon, Line);
    }
    void Update()
    {
        Char.GetComponent<KernelChar>().Move();
        Line.GetComponent<KernelLine>().Move();
    }
}
