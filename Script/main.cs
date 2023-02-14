using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public CharacterDatabase characterDatabase;
    public WeaponDatabase weaponDatabase;
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
    public ParticleSystem PS;
    public Store store;
    void Start()
    {
        Red = Square.GetComponent<RedBar>();
        CharL = new GameObject();
        WeaponL = new GameObject();
        LineL = new GameObject();
        CharR = new GameObject();
        WeaponR = new GameObject();
        LineR = new GameObject();
        for (int i = 0; i < characterDatabase.CharacterCount; i++)
        {
            if (characterDatabase.GetCharacter(i).Isleft)
            {
                CharConstruct.CreatChar(ref CharL, characterDatabase.GetCharacter(i).Char, characterDatabase.GetCharacter(i).animator, true);

            }
            if (weaponDatabase.GetCharacter(i).IsLeft)
            {
                WeaponConstruct.CreatWeapon(ref WeaponL, weaponDatabase.GetCharacter(i).Weapon, true);
            }
            if (characterDatabase.GetCharacter(i).IsRight)
            {
                CharConstruct.CreatChar(ref CharR, characterDatabase.GetCharacter(i).Char, characterDatabase.GetCharacter(i).animator, false);
            }
            if (weaponDatabase.GetCharacter(i).IsRight)
            {
                WeaponConstruct.CreatWeapon(ref WeaponR, weaponDatabase.GetCharacter(i).Weapon, false);
            }
        }
        LineConstruct.CreatLine(ref LineL, "Line", true);
        new Mediator1(CharL, WeaponL, LineL);
        LineConstruct.CreatLine(ref LineR, "Line", false);
        new Mediator1(CharR, WeaponR, LineR);
        new Mediator2(CharL, CharR, WeaponL, WeaponR, LineL, LineR, Square.GetComponent<RedBar>(), _camera, PS, store);
        CharL.GetComponent<InterChar>().MyTurn = true;
        CharL.tag = "Player";
        CharR.GetComponent<InterChar>().MyTurn = false;
        CharR.tag = "Player";
        WeaponL.GetComponent<InterWeapon>()._control = CharL.GetComponent<InterChar>()._control;
        LineL.GetComponent<KernelLine>()._control = CharL.GetComponent<InterChar>()._control;
        WeaponR.GetComponent<InterWeapon>()._control = CharR.GetComponent<InterChar>()._control;
        LineR.GetComponent<KernelLine>()._control = CharR.GetComponent<InterChar>()._control;
        if (store.GetCharacter(0).Repeat)
        {
            CharL.transform.position = new Vector3(store.GetCharacter(0).x, store.GetCharacter(0).y, 0);
            CharL.GetComponent<InterChar>()._transform = CharL.transform;
            WeaponL.transform.position = CharL.transform.position;
            LineL.transform.position = CharL.transform.position;
            CharR.transform.position = new Vector3(store.GetCharacter(1).x, store.GetCharacter(1).y, 0);
            CharR.GetComponent<InterChar>()._transform = CharR.transform;
            WeaponR.transform.position = CharR.transform.position;
            LineR.transform.position = CharR.transform.position;
        }
        else
        {
            CharL.transform.position = new Vector3(-18f, -1.4654f, 0);
            CharL.GetComponent<InterChar>()._transform = CharL.transform;
            WeaponL.transform.position = CharL.transform.position;
            LineL.transform.position = CharL.transform.position;
            CharR.transform.position = new Vector3(12.34f, -1.3142f, 0);
            CharR.GetComponent<InterChar>()._transform = CharR.transform;
            WeaponR.transform.position = CharR.transform.position;
            LineR.transform.position = CharR.transform.position;
        }
        MPL.GetComponent<IBar>().camera1 = _camera;
        MPL.GetComponent<IBar>().IsLeft = -1;
        MPR.GetComponent<IBar>().camera1 = _camera;
        MPR.GetComponent<IBar>().IsLeft = 1;
        HPL.GetComponent<IBar>().IsLeft = -1;
        HPR.GetComponent<IBar>().IsLeft = 1;
        new Mediator3(CharL, HPL.GetComponent<IBar>(), MPL.GetComponent<IBar>());
        new Mediator3(CharR, HPR.GetComponent<IBar>(), MPR.GetComponent<IBar>());
        new Meidator4(WeaponL, WeaponR, _camera);
        _camera.transform.position = new Vector3(-16, 0, 0 );
    }
}
    