using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : Weapon
{
    [Header("!!! Manual Refrences")]
    [SerializeField] private GameObject smgBullet;
    public override void MakeBullet()
    {
        GameObject _bullet = Instantiate(smgBullet, transform.position, transform.rotation);
        _bullet.transform.Translate(Vector2.up * 0.5f);
    }
}
