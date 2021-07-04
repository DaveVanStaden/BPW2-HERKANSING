using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUp : MonoBehaviour
{
    private Gun gun;
    private int ExtraValue = 96;
    void Start()
    {
        gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
                if (gun.ammo + ExtraValue >= gun.baseAmmo)
                {
                    gun.ammo = gun.baseAmmo;
                    gun.ammoInUse = gun.clipSize;
                    Destroy(gameObject);
                }
                else
                {
                    gun.ammo += ExtraValue;
                    gun.ammoInUse = gun.clipSize;
                    Destroy(gameObject);
                }
        }
    }
}
