using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharConstruct 
{
    private CharConstruct()
    {

    }
    public static void CreatChar(ref GameObject GO, string _sprite, string _animator, bool IsLeft)
    {
        if (IsLeft)
        {
            GO.name = "LeftChar";
        }
        else
        {
            GO.name = "RightChar";
        }
        GO.AddComponent<SpriteRenderer>();
        GO.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(_sprite);
        GO.AddComponent<Rigidbody2D>();
        GO.AddComponent<PolygonCollider2D>();
        GO.transform.position = new Vector3(0, 0, 0);
        GO.AddComponent<Animator>();
        GO.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(_animator) ;
        GO.AddComponent<KernelChar>();
        GO.GetComponent<KernelChar>().animator = GO.GetComponent<Animator>();
        if (IsLeft)
        {
            GO.transform.localScale = new Vector3(1.5f, 1.5f, 0f);
            GO.GetComponent<KernelChar>()._control = new LeftControl();
        }
        else
        {
            GO.transform.localScale = new Vector3(-1.5f, 1.5f, 0f);
            GO.GetComponent<KernelChar>()._control = new RightControl();
        }
    }
    public static void CreatChar2(ref GameObject GO, Sprite _sprite, string _animator, bool IsLeft)
    {
        if (IsLeft)
        {
            GO.name = "LeftChar";
        }
        else
        {
            GO.name = "RightChar";
        }
        GO.AddComponent<SpriteRenderer>();
        GO.GetComponent<SpriteRenderer>().sprite = _sprite;
        GO.AddComponent<Rigidbody2D>();
        GO.AddComponent<PolygonCollider2D>();
        GO.transform.position = new Vector3(0, 0, 0);
        GO.AddComponent<Animator>();
        GO.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(_animator);
        GO.AddComponent<KernelChar>();
        GO.GetComponent<KernelChar>().animator = GO.GetComponent<Animator>();
        if (IsLeft)
        {
            GO.transform.localScale = new Vector3(1.5f, 1.5f, 0f);
            GO.GetComponent<KernelChar>()._control = new LeftControl();
        }
        else
        {
            GO.transform.localScale = new Vector3(-1.5f, 1.5f, 0f);
            GO.GetComponent<KernelChar>()._control = new RightControl();
        }
    }
}
