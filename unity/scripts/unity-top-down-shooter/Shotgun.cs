using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [Header("!!! Manual Refrences")]
    [SerializeField] private GameObject shotgunBullet;
    [SerializeField] private GameObject empty;

    [Header("Editable")]
    [SerializeField] private int bulletAmount;
    [SerializeField] private float aoeInEuler;

    public override void MakeBullet()
    {
        for (int i = 1; i <= bulletAmount; i++)
        {
            GameObject _empty = Instantiate(empty, transform.position, transform.rotation);
            _empty.transform.Rotate(Vector3.forward, -aoeInEuler/2);
            _empty.transform.Rotate(Vector3.forward, aoeInEuler / (bulletAmount-1) * (i-1));
            _empty.transform.Translate(Vector2.up * 0.5f);
            Instantiate(shotgunBullet, _empty.transform.position, _empty.transform.rotation);
            Destroy(_empty);
        }
    }
}
