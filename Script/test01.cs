using UnityEngine;

public class test01 : MonoBehaviour
{
    GameObject GO;
    GameObject HO;
    private void Start()
    {
    }
    private void Update()
    {
        GO.GetComponent<KernelChar>().Move();
    }
}