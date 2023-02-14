using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponConstruct
{
    private WeaponConstruct()
    {

    }
    public static void CreatWeapon(ref GameObject GO, Sprite _sprite, bool IsLeft)
    {
        if (IsLeft)
        {
            GO.name = "LeftWeapon";
        }
        else
        {
            GO.name = "RightWeapon";
        }
        GO.AddComponent<SpriteRenderer>();
        GO.GetComponent<SpriteRenderer>().sprite = _sprite;
        GO.GetComponent<SpriteRenderer>().sortingOrder = -1;
        GO.AddComponent<PolygonCollider2D>();
        GO.GetComponent<PolygonCollider2D>().isTrigger = true;
        GO.AddComponent<KernelWeapon>();
        if (IsLeft)
        {
            GO.transform.localScale = new Vector3(1.5f, 1.5f, 0f);
            GO.GetComponent<KernelWeapon>()._control = new LeftControl();
            GO.GetComponent<KernelWeapon>().IsLeft = false;
        }
        else
        {
            GO.transform.localScale = new Vector3(-1.5f, 1.5f, 0f);
            GO.GetComponent<KernelWeapon>()._control = new RightControl();
            GO.GetComponent<KernelWeapon>().IsLeft = true;
        }
        GO.GetComponent<KernelWeapon>().IsShoot = false;
        GO.GetComponent<KernelWeapon>().DeltaT = 0;
    }
}
