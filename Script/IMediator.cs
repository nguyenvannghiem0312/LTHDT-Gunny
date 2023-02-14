using UnityEngine.SceneManagement;
using UnityEngine;

public interface IMediator
{
    public void Notify(string ev);
    public void Notify2(GameObject _object, Collider2D other, string ev);
    public string Name();
    public float Move();
    public float Hurt();
    public void Back();
}
public class Mediator1 : IMediator
{
    private GameObject Char;
    private GameObject Weapon;
    private GameObject Line;
    public void Back()
    {

    }
    public float Move()
    {
        return Char.GetComponent<InterChar>()._transform.position.x;
    }
    public float Hurt()
    {
        return Char.GetComponent<InterChar>()._transform.position.y;
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
        Char.GetComponent<InterChar>()._mediator = this;
        Weapon.GetComponent<InterWeapon>()._mediator = this;
        Line.GetComponent<KernelLine>()._mediator = this;
    }
    public void Notify(string ev)
    {
        InterChar Char = this.Char.GetComponent<InterChar>();
        InterWeapon W = this.Weapon.GetComponent<InterWeapon>();
        KernelLine L = this.Line.GetComponent<KernelLine>();
        if (ev == "Left")
        {
            W.Move(Char._transform.position.x, Char._transform.position.y, Char._transform.position.z);
            L.Move(Char._transform.position.x, Char._transform.position.y, Char._transform.position.z);
            if (!W.IsLeft)
            {
                W._transform.localScale = new Vector3(-1.5f, 1.5f, 0f);
                W.IsLeft = !W.IsLeft;
            }
        }
        else if(ev == "Right")
        {
            W.Move(Char._transform.position.x, Char._transform.position.y, Char._transform.position.z);
            L.Move(Char._transform.position.x, Char._transform.position.y, Char._transform.position.z);
            if (W.IsLeft)
            {
                W._transform.localScale = new Vector3(1.5f, 1.5f, 0f);
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
    private Camera MyCamera;
    private ParticleSystem PS;
    private Store store;
    public void Back()
    {

    }
    public float Move()
    {
        return 0;
    }
    public float Hurt()
    {
        return 0;
    }
    public Mediator2(GameObject LeftC, GameObject RightC, GameObject LeftW, GameObject RightW, GameObject LeftL, GameObject RightL, RedBar red, Camera c, ParticleSystem p, Store s)
    {
        LeftPlayer = LeftC;
        RightPlayer = RightC;
        LeftWe = LeftW;
        RightWe = RightW;
        LeftLi = LeftL;
        RightLi = RightL;
        Red = red;
        MyCamera = c;
        PS = p;
        store = s;
        LeftPlayer.GetComponent<InterChar>()._mediator2 = this;
        RightPlayer.GetComponent<InterChar>()._mediator2 = this;
        LeftWe.GetComponent<InterWeapon>()._mediator2 = this;
        RightWe.GetComponent<InterWeapon>()._mediator2 = this;
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
        InterChar LeftC = this.LeftPlayer.GetComponent<InterChar>();
        KernelChar RightC = this.RightPlayer.GetComponent<KernelChar>();
        KernelWeapon LeftWe = this.LeftWe.GetComponent<KernelWeapon>();
        KernelWeapon RightWe = this.RightWe.GetComponent<KernelWeapon>();
        KernelLine LeftLi = this.LeftLi.GetComponent<KernelLine>();
        KernelLine RightLi = this.RightLi.GetComponent<KernelLine>();
        if (ev == "Shoot")
        {
            if (LeftC.MyTurn && !LeftWe.IsShoot)
            {
                store.GetCharacter(0).x = LeftC._transform.position.x;
                store.GetCharacter(0).y = LeftC._transform.position.y;
                LeftC.MyTurn = false;
                LeftC.animator.SetBool("Shoot", true);
                LeftWe.DeltaT = 0;
                LeftWe.V0 = 15 * Red.Ratio;
                LeftWe.Corner = LeftLi.Corner + 45;
                LeftWe.IsShoot = true;
            }
            if(RightC.MyTurn && !RightWe.IsShoot)
            {
                store.GetCharacter(1).x = RightC._transform.position.x;
                store.GetCharacter(1).y = RightC._transform.position.y;
                RightC.MyTurn = false;
                RightC.animator.SetBool("Shoot", true);
                RightWe.DeltaT = 0;
                RightWe.V0 = 15 * Red.Ratio;
                RightWe.Corner = RightLi.Corner + 135;
                RightWe.IsShoot = true;
            }
        }
    }
    public void Notify2(GameObject _object, Collider2D other, string ev)
    {
        InterChar LeftC = LeftPlayer.GetComponent<InterChar>();
        InterChar RightC = RightPlayer.GetComponent<InterChar>();
        InterWeapon LeftWe = this.LeftWe.GetComponent<InterWeapon>();
        InterWeapon RightWe = this.RightWe.GetComponent<InterWeapon>();
        Camera _Mycamera = MyCamera.GetComponent<Camera>();
        if (ev == "Switch")
        {
            if (LeftC._name == _object.GetComponent<InterWeapon>()._mediator.Name())
            {
                PS.transform.position = LeftWe._transform.position;
                PS.Play();
                _Mycamera.x = RightC._transform.position.x;
                _Mycamera.IsLeft = false;
                _Mycamera.Action = true;
                LeftWe.Move(LeftWe.x0, LeftWe.y0, 0);
                LeftC.MyTurn = false;
                LeftWe.IsShoot = false;
                RightC.MyTurn = true;
                LeftC._mediator3.Back();
                RightC._mediator3.Back();
            }
            else
            {
                PS.transform.position = RightWe._transform.position;
                PS.Play();
                _Mycamera.x = LeftC._transform.position.x;
                _Mycamera.IsLeft = true;
                _Mycamera.Action = true;
                RightWe.Move(RightWe.x0, RightWe.y0, 0);
                RightC.MyTurn = false;
                RightWe.IsShoot = false;
                LeftC.MyTurn = true;
                LeftC._mediator3.Back();
                RightC._mediator3.Back();
            }
        }
        else if(ev == "Hurted")
        {
            if (LeftC._name == _object.GetComponent<InterWeapon>()._mediator.Name())
            {
                RightC.animator.SetBool("Cry", true);
                RightC.Hurted();
            }
            else
            {
                LeftC.animator.SetBool("Cry", true);
                LeftC.Hurted();
            }
        }
        else if(ev == "end")
        {
            if(_object.name == "LeftChar")
            {
                SceneManager.LoadScene(5);
            }
            else
            {
                SceneManager.LoadScene(4);
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
        c.GetComponent<InterChar>()._mediator3 = this;
        MP._control = c.GetComponent<InterChar>()._control;
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
    public void Back()
    {
        MP.Back();
    }
}
public class Meidator4 : IMediator
{
    private GameObject LeftWe;
    private GameObject RightWe;
    private Camera MainCamera;
    public Meidator4(GameObject l, GameObject r, Camera c)
    {
        LeftWe = l;
        RightWe = r;
        MainCamera = c;
        l.GetComponent<InterWeapon>()._mediator3 = this;
        r.GetComponent<InterWeapon>()._mediator3 = this;
    }
    public void Notify(string ev)
    {

    }
    public void Notify2(GameObject _object, Collider2D other, string ev)
    {
        if(_object.name == LeftWe.name && !MainCamera.GetComponent<Camera>().Action)
        {
            MainCamera.transform.position = new Vector3(LeftWe.transform.position.x, 0, 0);
        }
        else if(_object.name == RightWe.name && !MainCamera.GetComponent<Camera>().Action)
        {
            MainCamera.transform.position = new Vector3(RightWe.transform.position.x, 0, 0);
        }
    }
    public string Name()
    {
        return "Null";
    }
    public float Move()
    {
        return 0f;
    }
    public float Hurt()
    {
        return 0f;
    }
    public void Back()
    {

    }
}