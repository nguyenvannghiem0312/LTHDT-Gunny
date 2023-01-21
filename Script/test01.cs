using UnityEngine;

public class test01 : MonoBehaviour
{
    GameObject GO;
    GameObject HO;
    private void Start()
    {
        GO = new GameObject();
        HO = new GameObject();
        CharConstruct.CreatChar(ref GO, "Char/Char3", "AnimationOfChar03/Char03", true);
        WeaponConstruct.CreatWeapon(ref HO, "Weapon/W01", 0, true);
        HO.transform.position = new Vector3(1, 1, 0);
    }
    private void Update()
    {
        GO.GetComponent<KernelChar>().Move();
    }
}