using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConstruct
{
    private LineConstruct()
    {

    }
    public static void CreatLine(ref GameObject GO, string _sprite, bool IsLeft)
    {
        if (IsLeft)
        {
            GO.name = "LeftLine";
        }
        else
        {
            GO.name = "RightLine";
        }
        GO.AddComponent<SpriteRenderer>();
        GO.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(_sprite);
        GO.GetComponent<SpriteRenderer>().sortingOrder = -2;
        GO.AddComponent<KernelLine>();
        if (IsLeft)
        {
            GO.transform.localScale = new Vector3(2f, 2f, 0f);
            GO.GetComponent<KernelLine>()._control = new LeftControl();
        }
        else
        {
            GO.transform.localScale = new Vector3(-2f, 2f, 0f);
            GO.GetComponent<KernelLine>()._control = new RightControl();
        }

    }
}
