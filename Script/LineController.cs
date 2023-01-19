using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    Transform tr;
    Rigidbody2D rb;
    public GameObject chara, weapon, spawnWeapon;
    public float speedRot, speedPower, powerMax;
    float powerUp, power, powerDown;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

        powerDown = powerMax;
    }

    // Update is called once per frame
    void Update()
    {
        float d = Input.GetAxis("Vertical");
        if (d != 0)
        {
            tr.eulerAngles += new Vector3(0, 0, d * speedRot * Time.deltaTime);
        }
        float p = Input.GetAxis("Jump");
        if(p != 0)
        {
            if(powerUp < powerMax)
            {
                powerUp += speedPower * Time.deltaTime;
                power = powerUp;
            }
            else
            {
                powerDown -= speedPower * Time.deltaTime;
                power = powerDown;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            // Shot(power);
        }
    }

    /*void Shot(float p)
    {
        Vector2 posi = spawnWeapon.transform.position;
        Vector2 velo = posi - (Vector2)transform.position;
        velo.Normalize();
        Instantiate(weapon, spawnWeapon.transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(velo * p, ForceMode2D.Impulse);


        powerDown = powerMax;
        power = 0;
        powerUp = 0;
    }*/
}
