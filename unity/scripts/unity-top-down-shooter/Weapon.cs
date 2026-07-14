using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    [Header("Editable")]
    [SerializeField] private float cooldownBetweenShots;
    [SerializeField] private int maxAmmo;
    [SerializeField] private int ammo;
    [SerializeField] private float reloadCooldown;


    //vars
    private bool shootOnCooldown;
    private bool cooldownCountdownAlreadyStarted;
    private bool canReload;
    private float reloadTimeLeft;
    private bool canShoot;

    void Awake()
    {
        //variables
        shootOnCooldown = false;
        cooldownCountdownAlreadyStarted = false;
        canReload = true;

        RefillAmmo();
    }
    void OnEnable()
    {
        shootOnCooldown = false;
        cooldownCountdownAlreadyStarted = false;
        canReload = true;
        canShoot = true;
        reloadTimeLeft = 0;
    }
    void Update()
    {
        Shoot();
        Cooldown();
        Reload();
        UpdateCounter();
        UpdateReloadTimer();
    }
    void Shoot()
    {
        if(Input.GetMouseButton(0) && !shootOnCooldown && ammo > 0 && canShoot)
        {
            shootOnCooldown = true;
            DepleteAmmo();
            MakeBullet();
        }
    }
    void Cooldown()
    {
        if(shootOnCooldown && !cooldownCountdownAlreadyStarted)
        {
            cooldownCountdownAlreadyStarted = true;
            StartCoroutine("ShootCooldown");
        }
    }
    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(cooldownBetweenShots);
        shootOnCooldown = false;
        cooldownCountdownAlreadyStarted = false;
    }

    void Reload()
    {
        if(Input.GetKey(KeyCode.R) && canReload && ammo != maxAmmo)
        {
            canShoot = false;
            StartCoroutine("ReloadCooldown");
            StartCoroutine("ReloadTimer");
            canReload = false;
        }
    }

    IEnumerator ReloadTimer()
    {
        reloadTimeLeft = reloadCooldown;
        for(int i = 1; i <= reloadCooldown * 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            reloadTimeLeft -= 0.1f;
        }
        canShoot = true;
    }

    IEnumerator ReloadCooldown()
    {
        yield return new WaitForSeconds(reloadCooldown);
        RefillAmmo();
        canReload = true;
    }

    void UpdateCounter()
    {
        AmmoCounter ammoCounter = GameObject.Find("AmmoCounter").GetComponent<AmmoCounter>();
        ammoCounter.ammoToDisplay = ammo;
        ammoCounter.maxAmmoToDisplay = maxAmmo;
    }

    void UpdateReloadTimer()
    {
        ReloadTimer reloadTimer = GameObject.Find("ReloadTimer").GetComponent<ReloadTimer>();
        reloadTimer.timeLeft = reloadTimeLeft;
    }
    public void RefillAmmo()
    {
        ammo = maxAmmo;
    }
    public void DepleteAmmo()
    {
        ammo -= 1;
    }
    abstract public void MakeBullet();
}
