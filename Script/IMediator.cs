using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMediator
{
    public void Notify(string ev);
}
public class Mediator1 : IMediator
{
    private GameObject Char;
    private GameObject Weapon;
    private GameObject Line;
    public Mediator1 (GameObject Char, GameObject Weapon, GameObject Line)
    {
        this.Char = Char;
        this.Weapon = Weapon;
        this.Line = Line;
        Char.GetComponent<KernelChar>()._mediator = this;
        Weapon.GetComponent<KernelWeapon>()._mediator = this;
        Line.GetComponent<KernelLine>()._mediator = this;
    }
    public void Notify(string ev)
    {
        KernelChar Char = this.Char.GetComponent<KernelChar>();
        KernelWeapon W = this.Weapon.GetComponent<KernelWeapon>();
        KernelLine L = this.Line.GetComponent<KernelLine>();
        if (ev == "Left")
        {
            W.Move(Char.transform.position.x, Char.transform.position.y, Char.transform.position.z);
            L.Move(Char.transform.position.x, Char.transform.position.y, Char.transform.position.z);
            if (!W.IsLeft)
            {
                W.transform.localScale = new Vector3(-1.5f, 1.5f, 0f);
                W.IsLeft = !W.IsLeft;
            }
            if (!L.IsLeft)
            {
                L.transform.localScale = new Vector3(-2f, 2f, 0f);
                L.IsLeft = !L.IsLeft;
            }
        }
        else if(ev == "Right")
        {
            W.Move(Char.transform.position.x, Char.transform.position.y, Char.transform.position.z);
            L.Move(Char.transform.position.x, Char.transform.position.y, Char.transform.position.z);
            if (W.IsLeft)
            {
                W.transform.localScale = new Vector3(1.5f, 1.5f, 0f);
                W.IsLeft = !W.IsLeft;
            }
            if (L.IsLeft)
            {
                L.transform.localScale = new Vector3(2f, 2f, 0f);
                L.IsLeft = !L.IsLeft;
            }
        }
    }
}
