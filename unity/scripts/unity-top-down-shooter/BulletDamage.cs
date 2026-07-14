using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    private Entity entity;
    void Awake()
    {
        entity = GetComponent<Entity>();
    }
    void Update()
    {
        if(entity.colliding)
        {
            entity.Damage();
            entity.health = 0;
        }
    }
}
