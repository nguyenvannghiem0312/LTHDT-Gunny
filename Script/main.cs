using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    private GameObject CharL;
    private GameObject WeaponL;
    private GameObject LineL;
    public RedBar Red;
    public GameObject Square;
    private GameObject CharR;
    private GameObject WeaponR;
    private GameObject LineR;
    public GameObject HPL;
    public GameObject MPL;
    public GameObject HPR;
    public GameObject MPR;
    public Camera _camera;
    void Start()
    {
        Red = Square.GetComponent<RedBar>();
        CharL = new GameObject();
        WeaponL = new GameObject();
        LineL = new GameObject();
        CharR = new GameObject();
        WeaponR = new GameObject();
        LineR = new GameObject();
        CharConstruct.CreatChar(ref CharL, "Char/Char4", "AnimationOfChar04/Char04", true);
        WeaponConstruct.CreatWeapon(ref WeaponL, "Weapon/W02", 4, true);
        LineConstruct.CreatLine(ref LineL, "Line", true);
        new Mediator1(CharL, WeaponL, LineL);
        CharConstruct.CreatChar(ref CharR, "Char/Char3", "AnimationOfChar03/Char03", false);
        WeaponConstruct.CreatWeapon(ref WeaponR, "Weapon/W03", 4, false);
        LineConstruct.CreatLine(ref LineR, "Line", false);
        new Mediator1(CharR, WeaponR, LineR);
        new Mediator2(CharL, CharR, WeaponL, WeaponR, LineL, LineR, Square.GetComponent<RedBar>());
        CharL.GetComponent<InterChar>().MyTurn = true;
        CharL.tag = "Player";
        CharR.GetComponent<InterChar>().MyTurn = false;
        CharR.tag = "Player";
        WeaponL.GetComponent<InterWeapon>()._control = CharL.GetComponent<InterChar>()._control;
        LineL.GetComponent<KernelLine>()._control = CharL.GetComponent<InterChar>()._control;
        WeaponR.GetComponent<InterWeapon>()._control = CharR.GetComponent<InterChar>()._control;
        LineR.GetComponent<KernelLine>()._control = CharR.GetComponent<InterChar>()._control;
        CharL.GetComponent<KernelChar>().transform.position = new Vector3(-18f, 3f, 0);
        WeaponL.transform.position = new Vector3(-1.5f, 1f, 0);
        LineL.transform.position = new Vector3(-1.5f, 0, 0);
        CharR.GetComponent<KernelChar>().transform.position = new Vector3(12.34f, 3f, 0);
        WeaponR.transform.position = new Vector3(1.5f, 1f, 0);
        LineR.transform.position = new Vector3(1.5f, 0, 0);
        MPL.GetComponent<IBar>().camera1 = _camera;
        MPL.GetComponent<IBar>().IsLeft = -1;
        MPR.GetComponent<IBar>().camera1 = _camera;
        MPR.GetComponent<IBar>().IsLeft = 1;
        HPL.GetComponent<IBar>().IsLeft = -1;
        HPR.GetComponent<IBar>().IsLeft = 1;
        new Mediator3(CharL, HPL.GetComponent<IBar>(), MPL.GetComponent<IBar>());
        new Mediator3(CharR, HPR.GetComponent<IBar>(), MPR.GetComponent<IBar>());
        new Meidator4(WeaponL, WeaponR, _camera);
    }
}
    