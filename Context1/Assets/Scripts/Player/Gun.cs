using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float baseFireRate = 15f;
    public float fireRate = 15f;
    [SerializeField] private float impactForce = 1200f;
    [SerializeField] private float velocity = 2000f;

    public int clips;
    public int maxClips;
    public int clipSize;
    [SerializeField] private int _ammoInUse => ammoInUse;
    [SerializeField] private Text AmmoText;

    public int baseAmmo;
    public int ammo;
    public int ammoInUse;
    private bool _isReloading = false;

    [SerializeField] private Camera cam;

    [SerializeField] private GameObject impactEffect;

    [SerializeField] private GameObject Projectile;

    [SerializeField] private ParticleSystem muzzleFlash;

    [SerializeField] private GameObject Muzzle;

    public PlayerStats playerStats;

    public AudioSource GunShot;

    private float NextTimeToFire = 1f;

    private bool exec = false;

    private void Start()
    {
        ammo = clips * clipSize;
        baseAmmo = ammo;
        ammoInUse = clipSize;
        AmmoText = GameObject.FindGameObjectWithTag("GunText").GetComponent<Text>();
    }
    void Update()
    {
        if(ammo < 0)
        {
            ammo = 0;
        } else if( ammo > baseAmmo)
        {
            ammo = baseAmmo;
        }
        if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire)
        {
            NextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && ammo > 0)
        {
            Reload();
        }
        AmmoText.text = ammoInUse.ToString() + "/" + ammo.ToString();
    }
    void Shoot()
    {
        if (ammo + ammoInUse <= 0)
            return;
        if (ammoInUse > 0)
        {
            ammoInUse--;
            muzzleFlash.Play();
            GunShot.Play();
            RaycastHit hit;
            GameObject tempBullet = Instantiate(Projectile, Muzzle.transform.position, Quaternion.identity);
            tempBullet.GetComponent<Rigidbody>().AddForce(transform.forward * velocity);
        }
    }


    private void Reload()
    {
        if (!exec)
        {
            if(ammo >= 0)
            {
                ammo -= clipSize;
                clips--;
            }
            exec = true;

        }
        _isReloading = true;
        ammoInUse = clipSize;
        exec = false;
        _isReloading = false;
    }
}
