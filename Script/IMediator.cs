using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMediator
{
    public void Notify(string ev);
    public void Notify2(GameObject _object, Collider2D other, string ev);
    public string Name();
    public float Move();
    public float Hurt();
}
public class Mediator1 : IMediator
{
    private GameObject Char;
    private GameObject Weapon;
    private GameObject Line;
    public float Move()
    {
        return 0;
    }
    public float Hurt()
    {
        return 0;
    }
    public void Notify2(GameObject _object, Collider2D other, string ev)
    {

    }
    public string Name()
    {
        return Char.name;
    }
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
                W.transform.localScale = new Vector3(-1f, 1f, 0f);
                W.IsLeft = !W.IsLeft;
            }
        }
        else if(ev == "Right")
        {
            W.Move(Char.transform.position.x, Char.transform.position.y, Char.transform.position.z);
            L.Move(Char.transform.position.x, Char.transform.position.y, Char.transform.position.z);
            if (W.IsLeft)
            {
                W.transform.localScale = new Vector3(1f, 1f, 0f);
                W.IsLeft = !W.IsLeft;
            }
        }
    }
}
public class Mediator2 : IMediator
{
    private GameObject LeftPlayer;
    private GameObject RightPlayer;
    private GameObject LeftWe;
    private GameObject RightWe;
    private GameObject LeftLi;
    private GameObject RightLi;
    private RedBar Red;
    public float Move()
    {
        return 0;
    }
    public float Hurt()
    {
        return 0;
    }
    public Mediator2(GameObject LeftC, GameObject RightC, GameObject LeftW, GameObject RightW, GameObject LeftL, GameObject RightL, RedBar red)
    {
        LeftPlayer = LeftC;
        RightPlayer = RightC;
        LeftWe = LeftW;
        RightWe = RightW;
        LeftLi = LeftL;
        RightLi = RightL;
        Red = red;
        LeftPlayer.GetComponent<KernelChar>()._mediator2 = this;
        RightPlayer.GetComponent<KernelChar>()._mediator2 = this;
        LeftWe.GetComponent<KernelWeapon>()._mediator2 = this;
        RightWe.GetComponent<KernelWeapon>()._mediator2 = this;
        LeftLi.GetComponent<KernelLine>()._mediator2 = this;
        RightLi.GetComponent<KernelLine>()._mediator2 = this;
        red.GetComponent<RedBar>()._mediator2 = this;
    }
    public string Name()
    {
        return "Null";
    }
    public void Notify(string ev)
    {
        KernelChar LeftC = this.LeftPlayer.GetComponent<KernelChar>();
        KernelChar RightC = this.RightPlayer.GetComponent<KernelChar>();
        KernelWeapon LeftWe = this.LeftWe.GetComponent<KernelWeapon>();
        KernelWeapon RightWe = this.RightWe.GetComponent<KernelWeapon>();
        KernelLine LeftLi = this.LeftLi.GetComponent<KernelLine>();
        KernelLine RightLi = this.RightLi.GetComponent<KernelLine>();
        if (ev == "Shoot")
        {
            if (LeftC.MyTurn && !LeftWe.IsShoot)
            {
                LeftC.MyTurn = false;
                LeftC.animator.SetBool("Shoot", true);
                LeftWe.DeltaT = 0;
                LeftWe.V0 = 5;
                LeftWe.Corner = LeftLi.Corner + 45;
                LeftWe.IsShoot = true;
            }
            if(RightC.MyTurn && !RightWe.IsShoot)
            {
                RightC.MyTurn = false;
                RightC.animator.SetBool("Shoot", true);
                RightWe.DeltaT = 0;
                RightWe.V0 = 5;
                RightWe.Corner = RightLi.Corner + 135;
                RightWe.IsShoot = true;
            }
        }
    }
    public void Notify2(GameObject _object, Collider2D other, string ev)
    {
        KernelChar LeftC = this.LeftPlayer.GetComponent<KernelChar>();
        KernelChar RightC = this.RightPlayer.GetComponent<KernelChar>();
        KernelWeapon LeftWe = this.LeftWe.GetComponent<KernelWeapon>();
        KernelWeapon RightWe = this.RightWe.GetComponent<KernelWeapon>();
        KernelLine LeftLi = this.LeftLi.GetComponent<KernelLine>();
        KernelLine RightLi = this.LeftLi.GetComponent<KernelLine>();
        if (ev == "Switch")
        {
            if (LeftC.name == _object.GetComponent<KernelWeapon>()._mediator.Name())
            {
                LeftWe.Move(LeftWe.x0, LeftWe.y0, 0);
                LeftC.MyTurn = false;
                RightC.MyTurn = true;
                LeftWe.IsShoot = false;
            }
            else
            {
                RightWe.Move(RightWe.x0, RightWe.y0, 0);
                LeftC.MyTurn = true;
                RightC.MyTurn = false;
                RightWe.IsShoot = false;
            }
        }
        else if(ev == "Hurted")
        {
            if (LeftC.name == _object.GetComponent<KernelWeapon>()._mediator.Name())
            {
                RightC.GetComponent<KernelChar>().animator.SetBool("Cry", true);
                LeftWe.Move(LeftWe.x0, LeftWe.y0, 0);
                LeftC.MyTurn = false;
                RightC.MyTurn = true;
                LeftWe.IsShoot = false;
            }
            else
            {
                LeftC.GetComponent<KernelChar>().animator.SetBool("Cry", true);
                RightWe.Move(RightWe.x0, RightWe.y0, 0);
                LeftC.MyTurn = true;
                RightC.MyTurn = false;
                RightWe.IsShoot = false;
            }
        }
    }
}
public class Mediator3 : IMediator
{
    GameObject Char;
    IBar HP;
    IBar MP;

    public Mediator3(GameObject c, IBar h, IBar m)
    {
        Char = c;
        HP = h;
        MP = m;
        c.GetComponent<KernelChar>()._mediator3 = this;
    }
    public void Notify(string ev)
    {

    }
    public void Notify2(GameObject _object, Collider2D other, string ev)
    {

    }
    public string Name()
    {
        return "Null";
    }
    public float Move()
    {
        return MP.Move();
    }
    public float Hurt()
    {
        return HP.Move();
    }
}